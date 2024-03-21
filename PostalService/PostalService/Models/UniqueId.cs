using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models
{
    public class UniqueId
    {
        public UniqueId() { }

        public UniqueId(MailKit.UniqueId uniqueId)
        {
            UintId = uniqueId.Id;
            UintValidity = uniqueId.Validity;
        }

        public int Id { get; set; }

        public int WritingId { get; set; }

        public uint UintId { get; set; }

        public uint UintValidity { get; set; }

        public bool Same(UniqueId uniqueId)
        {
            if (UintId == uniqueId.Id && UintId == uniqueId.UintValidity)
                return true;

            return false;
        }

        public bool Same(MailKit.UniqueId uniqueId)
        {
            if (UintId == uniqueId.Id && UintValidity == uniqueId.Validity)
                return true;

            return false;
        }
    }
}
