using PostalService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models
{
    public class Writing
    {
        public int Id { get; set; }

        public int СompanyMemberId { get; set; }

        public UniqueId MailId { get; set; }

        public string Tityle { get; set; }

        public DateTime Date {  get; set; }
        
        public string Destination { get; set; }

        public string Sender { get; set; }

        public string Context { get; set; }
    }
}
