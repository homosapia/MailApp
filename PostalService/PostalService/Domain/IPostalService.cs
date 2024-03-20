using PostalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Domain
{
    public interface IPostalService 
    {
        public СompanyMember Member { get; }

        public int InternalTasks { get; }

        public Exception Exception { get; }

        public Task<bool> SetCompanyMember(СompanyMember сompanyMember);

        public Task<bool> DownloadAllIncomingLetters();

        public Task CreateTaskDownloadEmails(IList<MailKit.UniqueId> uids);

        public Task<IEnumerable<MailKit.UniqueId>> CheckStartDownloadingEmails();

    }
}
