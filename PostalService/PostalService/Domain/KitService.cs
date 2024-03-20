using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MailKit.Search;
using MailKit.Security;
using Microsoft.Identity.Client;
using MimeKit;
using PostalService.DataBase;
using PostalService.DataBase.Repositorys.Interfase;
using PostalService.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Formats.Asn1.AsnWriter;

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
        }

        public int InternalTasks => _WritingsTask.Count(t => t.Status != TaskStatus.RanToCompletion);

        public СompanyMember Member { get; private set; }

        public Exception Exception { get; private set; }

        public async Task<bool> SetCompanyMember(СompanyMember сompanyMember)
        {
            using (_ImapClient = new ImapClient())
            {
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
            var NewUids = uids.Where(x => memberUids.Any(u => u.Same(x)));
            return NewUids;
        }

        public async Task<bool> DownloadAllIncomingLetters()
        {
            if (!(await IsAuthorized()))
                return false;

            try 
            {
                var inbox = _ImapClient.Inbox;
                inbox.Open(FolderAccess.ReadOnly);
                var uids = inbox.Search(SearchQuery.All);

                if (Member.ListWriting == null)
                    Member.ListWriting = new List<Writing>();

                await CreateTaskDownloadEmails(uids);

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
            var writingsTask = new List<Task>();
            foreach (var uid in uids)
            {
                Task task = new Task(async () =>
                {
                    var fullMessage = await _ImapClient.Inbox.GetMessageAsync(uid);

                    var writing = new Writing
                    {
                        MailId = new UniqueId(uid),
                        Tityle = fullMessage.Subject,
                        Date = fullMessage.Date.Date,
                        Destination = string.Join(", ", fullMessage.To.Mailboxes.Select(x => x.Address)),
                        Sender = string.Join(", ", fullMessage.From.Mailboxes.Select(x => x.Address)),
                        Context = await GetTextFromMessage(fullMessage)
                    };

                    Member.ListWriting.Add(writing);
                });

                task.Start();
                writingsTask.Add(task);
            }

            await Task.Run(() =>
            {
                Task.WaitAll(_WritingsTask.ToArray());
                _MemberRepository.UpdataListWriting(Member.Id, Member.ListWriting);
            });

            _WritingsTask = writingsTask;
        }

        private async Task<string> GetTextFromMessage(MimeMessage message)
        {
            var builder = new StringBuilder();
            var textPart = message.BodyParts.OfType<TextPart>().FirstOrDefault();
            if (textPart != null)
            {
                builder.AppendLine(textPart.Text);
            }
            else
            {
                var multipart = (Multipart)message.Body;
                foreach (var part in multipart)
                {
                    if (part is TextPart textPart2)
                    {
                        builder.AppendLine(textPart2.Text);
                    }
                    else if (part is Multipart multipart2)
                    {
                        await GetTextFromMultipart(multipart2, builder);
                    }
                }
            }
            return builder.ToString();
        }

        private async Task GetTextFromMultipart(Multipart multipart, StringBuilder builder)
        {
            foreach (var part in multipart)
            {
                if (part is TextPart textPart)
                {
                    builder.AppendLine(textPart.Text);
                }
                else if (part is Multipart multipart2)
                {
                    await GetTextFromMultipart(multipart2, builder);
                }
            }
        }

        private async Task<bool> IsAuthorized()
        {
            if (!_ImapClient.IsConnected)
            {
                try
                {
                    await _ImapClient.ConnectAsync(Member.IncomingIMAP);
                    await _ImapClient.AuthenticateAsync(Member.Login, Member.Password);
                    return true;
                }
                catch
                {
                    Exception = new Exception("Пользователь не выбран");
                    return false;
                }
            }

            return true;
        } 
    }
}
