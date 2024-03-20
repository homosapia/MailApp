using Microsoft.EntityFrameworkCore;
using PostalService.DataBase.Repositorys.Interfase;
using PostalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.DataBase.Repositorys
{
    public class MemberRepository : IMemberRepository
    {
        private BaseDbContext _BaseDbContext { get; set; }
        public MemberRepository(BaseDbContext baseDbContext) 
        {
            _BaseDbContext = baseDbContext;
        }

        public async Task AddAndSave(СompanyMember сompanyMember)
        {
            await _BaseDbContext.Members.AddAsync(сompanyMember);
            await _BaseDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<СompanyMember>> GetAllMembers()
        {
            return await _BaseDbContext.Members.AsNoTracking().ToListAsync();
        }

        public async Task<СompanyMember> GetMember(int id)
        {
            return await _BaseDbContext.Members
                .Include(x => x.ListWriting)
                .FirstAsync(x => x.Id == id);
        }

        public async Task UpdataListWriting(int id, IEnumerable<Writing> ListWriting)
        {
            var member = await _BaseDbContext.Members.FindAsync(id);
            var newListWriting = ListWriting.Where(x => member.ListWriting.Any(y => y.MailId.Same(x.MailId)));
            member.ListWriting = member.ListWriting.Concat(newListWriting.ToList()).ToList();

            await _BaseDbContext.SaveChangesAsync();
        }
    }
}
