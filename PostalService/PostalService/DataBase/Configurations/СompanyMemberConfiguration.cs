using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.DataBase.Configurations
{
    public class СompanyMemberConfiguration : IEntityTypeConfiguration<СompanyMember>
    {
        public void Configure(EntityTypeBuilder<СompanyMember> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
