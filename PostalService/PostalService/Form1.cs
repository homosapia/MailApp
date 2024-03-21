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

            if(!(await _PostalService.DownloadAllIncomingLetters()))
                MessageBox.Show(_PostalService.Exception.Message);

            var range = await _MemberRepository.GetAllMembers();
            employees.Items.Clear();
            employees.Items.AddRange(range.ToArray());

            MessageBox.Show($"������������ {_PostalService.Member.Login} ��������");
        }

        private async void employees_SelectedIndexChanged(object sender, EventArgs e)
        {
            string login = employees.SelectedItem.ToString();
            if (login == null)
                return;

            var �ompanyMember = await _MemberRepository.GetMember(login);
            await _PostalService.SetCompanyMember(�ompanyMember);

            foreach (var writing in _PostalService.Member.ListWriting)
            {
                var listItem = new
                {
                    Text = writing.Title,
                    Value = writing
                };

                letters.Items.Add(listItem);
            }
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
                    MessageBox.Show($"����������� ����� ������������ {_PostalService.Member.Login} ����������.");
                    return;
                }

                WriteLettersArray(_PostalService.Member.ListWriting);
            }
            else
            {
                MessageBox.Show($"���������� �� ��������. ��� ������������ {_PostalService.Member.Login} ���������� �������� �����. �������� ���������: {_PostalService.InternalTasks}");

                WriteLettersArray(_PostalService.Member.ListWriting);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var range = await _MemberRepository.GetAllMembers();
            employees.Items.AddRange(range.Select(x => x.Login).ToArray());
        }

        private void WriteLettersArray(IEnumerable<Writing> �ompanyMembers)
        {
            foreach (var writing in �ompanyMembers)
            {
                letters.Items.Add(writing);
            }
        }
    }
}
