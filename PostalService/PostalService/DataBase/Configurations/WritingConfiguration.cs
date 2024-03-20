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
    public class WritingConfiguration : IEntityTypeConfiguration<Writing>
    {
        public void Configure(EntityTypeBuilder<Writing> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
