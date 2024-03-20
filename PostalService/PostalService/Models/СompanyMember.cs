using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models
{
    public class СompanyMember
    {
        public int Id { get; set; }

        public string Login {  get; set; }

        public string Password { get; set; }

        public string IncomingIMAP { get; set; }

        public List<Writing> ListWriting { get; set; }
    }
}
