namespace PostalService.Models
{
    public class Writing
    {
        public int Id { get; set; }

        public int СompanyMemberId { get; set; }

        public UniqueId MailId { get; set; }

        public string Title { get; set; }

        public DateTime Date {  get; set; }
        
        public string Destination { get; set; }

        public string Sender { get; set; }

        public string Context { get; set; }
    }
}
