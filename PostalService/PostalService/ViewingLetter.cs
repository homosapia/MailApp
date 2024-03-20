using MailKit.Net.Imap;
using PostalService.Domain;
using PostalService.Models;

namespace PostalService
{
    public partial class ViewingLetter : Form
    {
        IPostalService _postalService;
        public ViewingLetter(IPostalService postalService)
        {
            InitializeComponent();
            _postalService = postalService;
        }

        public СompanyMember Member;

        private async void button1_Click(object sender, EventArgs e)
        {
            СompanyMember сompanyMember = new СompanyMember();
            сompanyMember.IncomingIMAP = incomingIMAP.Text;
            сompanyMember.Login = login.Text;
            сompanyMember.Password = password.Text;
            сompanyMember.ListWriting = new List<Writing>();

            if (await _postalService.SetCompanyMember(сompanyMember))
            {
                Member = сompanyMember;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                // Авторизация не прошла
                MessageBox.Show(_postalService.Exception.Message);
            }
        }
    }
}
