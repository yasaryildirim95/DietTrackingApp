using BA.DietTrackApp.Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.DietTrackApp.Entity.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasAlternateKey(u => u.UserName);
            builder.Property(u => u.UserName).HasMaxLength(50).IsRequired(true);
            builder.Property(u => u.Password).IsRequired(true);

        }
    
    }
}
