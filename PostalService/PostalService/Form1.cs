using Microsoft.EntityFrameworkCore;
using MimeKit;
using PostalService.DataBase;
using PostalService.DataBase.Repositorys;
using PostalService.DataBase.Repositorys.Interfase;
using PostalService.Domain;
using PostalService.Models;
using System.Text;

namespace PostalService
{
    public partial class Form1 : Form
    {
        IPostalService _PostalService;
        IMemberRepository _MemberRepository;
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
            await _PostalService.DownloadAllIncomingLetters();

            var range = await _MemberRepository.GetAllMembers();
            employees.Items.Clear();
            employees.Items.AddRange(range.ToArray());

            MessageBox.Show($"Пользователь {_PostalService.Member.Login} добавлен");
        }

        private async void employees_SelectedIndexChanged(object sender, EventArgs e)
        {
            СompanyMember сompanyMember = (СompanyMember)employees.SelectedItem;
            сompanyMember = await _MemberRepository.GetMember(сompanyMember.Id);
            await _PostalService.SetCompanyMember(сompanyMember);
        }

        private async void UpdatingLettersList_Click(object sender, EventArgs e)
        {
            if (_PostalService.InternalTasks == 0)
            {
                var NewMail = await _PostalService.CheckStartDownloadingEmails();
                if(NewMail == null)
                {
                    MessageBox.Show(_PostalService.Exception.Message);
                    return;
                }
                if (NewMail.Any())
                {
                    await _PostalService.CreateTaskDownloadEmails(NewMail.ToList());
                    MessageBox.Show($"Электронная почта пользователя {_PostalService.Member.Login} начала обновляться. Осталось загрузить: { _PostalService.InternalTasks}");
                    return;
                }

                letters.Items.AddRange(_PostalService.Member.ListWriting.ToArray());

            }
            else
            {
                MessageBox.Show($"Для пользователя {_PostalService.Member.Login} происходит загрузка писем. Осталось загрузить: {_PostalService.InternalTasks}");
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var range = await _MemberRepository.GetAllMembers();
            employees.Items.AddRange(range.ToArray());
        }
    }
}
