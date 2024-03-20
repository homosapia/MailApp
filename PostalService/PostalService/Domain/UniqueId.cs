using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Domain
{
    public class UniqueId
    {
        public UniqueId(uint Id, uint Validity) 
        {
            this.Id = Id;
            this.Validity = Validity;
        }

        public UniqueId(MailKit.UniqueId uniqueId)
        {
            this.Id = uniqueId.Id;
            this.Validity = uniqueId.Validity;
        }

        public uint Id { get; set; }

        public uint Validity { get; set; }

        public bool Same(UniqueId uniqueId)
        {
            if (this.Id == uniqueId.Id && this.Validity == uniqueId.Validity)
                return true;

            return false;
        }

        public bool Same(MailKit.UniqueId uniqueId)
        {
            if (this.Id == uniqueId.Id && this.Validity == uniqueId.Validity)
                return true;

            return false;
        }
    }
}
