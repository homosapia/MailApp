using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using PostalService.DataBase.Repositorys.Interfase;
using PostalService.Models;
using System.Text;
using System.Threading;
using System.Xml;

namespace PostalService.Domain
{
    public class KitService : IPostalService
    {
        private IEnumerable<Task> _WritingsTask { get; set; }

        private IMemberRepository _MemberRepository { get; set; }

        private ImapClient _ImapClient { get; set; }

        public KitService(IMemberRepository memberRepository)
        {
            _MemberRepository = memberRepository;
            _WritingsTask = new List<Task>();
        }

        Semaphore semaphore = new Semaphore(1, 1);
        public int InternalTasks => _WritingsTask.Count(t => t.Status != TaskStatus.RanToCompletion);

        public СompanyMember Member { get; private set; }

        public Exception Exception { get; private set; }

        public async Task<bool> SetCompanyMember(СompanyMember сompanyMember)
        {
            if (сompanyMember == null)
            {
                Exception = new Exception("Выберите сотрудника");
                return false;
            }

            if (InternalTasks != 0)
            {
                var tasks = _WritingsTask.Where(t => t.Status == TaskStatus.Running);

                Exception = new Exception($"Подождите, получения писем {Member.Login}. Осталось: {InternalTasks}");
                return false;
            }

            _ImapClient = new ImapClient();
            try
            {
                await _ImapClient.ConnectAsync(сompanyMember.IncomingIMAP);
            }
            catch
            {
                Exception = new Exception("Хост IMAP указан неправильно");
                return false;
            }

            try
            {
                await _ImapClient.AuthenticateAsync(сompanyMember.Login, сompanyMember.Password);
            }
            catch
            {
                Exception = new Exception("Пользователь указан неверно");
                return false;
            }
            Member = сompanyMember;

            return true;
        }

        public async Task<IEnumerable<MailKit.UniqueId>> CheckStartDownloadingEmails()
        {
            if (!(await IsAuthorized()))
                return null;

            var inbox = _ImapClient.Inbox;
            inbox.Open(FolderAccess.ReadOnly);
            var uids = inbox.Search(SearchQuery.All);

            СompanyMember dbMember = await _MemberRepository.GetMember(Member.Id);
            var memberUids = dbMember.ListWriting.Select(u => u.MailId);
            var NewUids = uids.Where(x => !memberUids.Any(u => u.Same(x)));
            return NewUids;
        }

        public async Task<bool> DownloadAllIncomingLetters()
        {
            if (!(await IsAuthorized()))
                return false;

            if(InternalTasks != 0)
            {
                Exception = new Exception($"Невозможно начать загрузку для нового сотрудника. Завершается загрузка для пользователя {Member.Login}. Осталось: {InternalTasks}");
                return false;
            }

            try 
            {
                var uids = await CheckStartDownloadingEmails();
                if (uids == null)
                {
                    return false;
                }


                if (Member.ListWriting == null)
                    Member.ListWriting = new List<Writing>();

                await CreateTaskDownloadEmails(uids.ToList());

                _ImapClient.Disconnect(true);

                return true;
            }
            catch
            {
                Exception = new Exception("Ошибка при обработке сообщений");
                return false;
            }
        }

        public async Task CreateTaskDownloadEmails(IList<MailKit.UniqueId> uids)
        {
            object controlRoot = new object(); 
            var writingsTask = new List<Task>();
            foreach (var uid in uids)
            {
                Task task = new Task(async () =>
                {
                    semaphore.WaitOne();
                    MimeMessage fullMessage = await _ImapClient.Inbox.GetMessageAsync(uid);

                    var writing = new Writing
                    {
                        MailId = new Models.UniqueId(uid),
                        Title = fullMessage?.Subject ?? string.Empty,
                        Date = fullMessage.Date.UtcDateTime,
                        Destination = string.Join(", ", fullMessage.To.Mailboxes.Select(x => x.Address)),
                        Sender = string.Join(", ", fullMessage.From.Mailboxes.Select(x => x.Address)),
                        Context = await GetTextFromMessage(fullMessage)
                    };

                    Member.ListWriting.Add(writing);
                    await _MemberRepository.UpdataWriting(Member.Id, writing);
                    semaphore.Release();
                });
                task.Start();
                writingsTask.Add(task);
            }

            _WritingsTask = writingsTask;

            await Task.Run(async () => 
            {
                await Task.WhenAll(_WritingsTask);
                await _MemberRepository.Save();
            });
        }

        private async Task<string> GetTextFromMessage(MimeMessage message)
        {
            var builder = new StringBuilder();
            var textPart = message.BodyParts.OfType<TextPart>().FirstOrDefault();
            if (textPart != null)
            {
                builder.AppendLine(textPart.Text);
            }
            return builder.ToString();
        }

        private async Task<bool> IsAuthorized()
        {
            if(_ImapClient == null)
            {
                Exception = new Exception("Выберите сотрудника");
                return false;
            }

            if (!_ImapClient.IsConnected)
            {
                try
                {
                    await _ImapClient.ConnectAsync(Member.IncomingIMAP);
                }
                catch
                {
                    Exception = new Exception("Ошибка при коннекте IMAP");
                    return false;
                }
            }

            if (!_ImapClient.IsAuthenticated)
            {
                try
                {
                    await _ImapClient.AuthenticateAsync(Member.Login, Member.Password);
                }
                catch
                {
                    Exception = new Exception("Сотрудник не выбран");
                    return false;
                }
            }


            return true;
        } 
    }
}
