using Microsoft.EntityFrameworkCore;
using PostalService.DataBase.Repositorys.Interfase;
using PostalService.Domain;
using PostalService.Models;

namespace PostalService
{
    public partial class Form1 : Form
    {
        IPostalService _PostalService;
        IMemberRepository _MemberRepository;
        ÑompanyMember _ÑurrentMember;
        public Form1(IPostalService postalService, IMemberRepository memberRepository)
        {
            InitializeComponent();
            _PostalService = postalService;
            _MemberRepository = memberRepository;
        }

        private async void AddEmployee_Click(object sender, EventArgs e)
        {
            ViewingLetter viewingLetter = new ViewingLetter(_PostalService);
            if (viewingLetter.ShowDialog() != DialogResult.OK)
                return;

            await _MemberRepository.AddAndSave(viewingLetter.Member);
            _ÑurrentMember = viewingLetter.Member;

            if (!(await _PostalService.DownloadAllIncomingLetters()))
                MessageBox.Show(_PostalService.Exception.Message);

            var range = await _MemberRepository.GetAllMembers();
            employees.Items.Clear();
            employees.Items.AddRange(range.ToArray());

            MessageBox.Show($"Ïîëüçîâàòåëü {_ÑurrentMember.Login} äîáàâëåí");
        }

        private async void employees_SelectedIndexChanged(object sender, EventArgs e)
        {
            string login = employees.SelectedItem?.ToString() ?? null;
            if (login == null)
                return;

            var ñompanyMember = await _MemberRepository.GetMember(login);
            _ÑurrentMember = ñompanyMember;
            WriteLettersArray(_ÑurrentMember.ListWriting);

            if (!(await _PostalService.SetCompanyMember(ñompanyMember)))
            {
                MessageBox.Show(_PostalService.Exception.Message);
                return;
            }
        }

        private async void UpdatingLettersList_Click(object sender, EventArgs e)
        {
            if (_PostalService.InternalTasks == 0)
            {
                if (!(await _PostalService.SetCompanyMember(_ÑurrentMember)))
                {
                    MessageBox.Show(_PostalService.Exception.Message);
                    return;
                }

                var NewMail = await _PostalService.CheckStartDownloadingEmails();
                if (NewMail == null)
                {
                    MessageBox.Show(_PostalService.Exception.Message);
                    return;
                }
                if (NewMail.Any())
                {
                    await _PostalService.CreateTaskDownloadEmails(NewMail.ToList());
                    MessageBox.Show($"Ýëåêòðîííàÿ ïî÷òà ïîëüçîâàòåëÿ {_PostalService.Member.Login} îáíîâèëàñü.");
                    WriteLettersArray(_PostalService.Member.ListWriting);
                }
                else
                {
                    MessageBox.Show($"Ýëåêòðîííàÿ ïî÷òà çàãðóæåíà.");
                }
            }
            else
            {
                MessageBox.Show($"Îáíîâëåíèå íå âîçìîæíî. Äëÿ ïîëüçîâàòåëÿ {_PostalService.Member.Login} ïðîèñõîäèò çàãðóçêà ïèñåì. Îñòàëîñü çàãðóçèòü: {_PostalService.InternalTasks}");

                WriteLettersArray(_PostalService.Member.ListWriting);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var range = await _MemberRepository.GetAllMembers();
            employees.Items.AddRange(range.Select(x => x.Login).ToArray());
        }

        private void WriteLettersArray(IEnumerable<Writing> ñompanyMembers)
        {
            letters.Items.Clear();
            var members = ñompanyMembers.OrderByDescending(x => x.Date);
            foreach (var writing in members)
            {
                letters.Items.Add(writing);
            }
        }

        private async void letters_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Item = (Writing)letters.SelectedItem;
            if (Item == null)
                return;

            letterDate.Text = Item.Date.ToString();
            letterTitle.Text = Item.Title;
            emailSenderName.Text = Item.Sender;
            emailRecipientName.Text = Item.Destination;
            richTextBox1.Text = Item.Context;
        }
    }
}
