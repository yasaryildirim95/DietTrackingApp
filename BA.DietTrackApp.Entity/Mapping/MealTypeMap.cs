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
    public class MealTypeMap : IEntityTypeConfiguration<MealType>
    {
        void IEntityTypeConfiguration<MealType>.Configure(EntityTypeBuilder<MealType> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.MTName).HasMaxLength(50).IsRequired(true);


        }
    
    }
}
