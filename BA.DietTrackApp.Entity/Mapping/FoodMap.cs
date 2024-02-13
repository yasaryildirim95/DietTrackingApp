using BA.DietTrackApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.DietTrackApp.Entity.Mapping
{
    public class FoodMap: IEntityTypeConfiguration<Food>
    {
        void IEntityTypeConfiguration<Food>.Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.FName).HasMaxLength(50).IsRequired(true);
            builder.Property(f => f.Calori).HasPrecision(6, 2).IsRequired(true);
            builder.Property(f => f.FoodTypeId).IsRequired(true);

            builder
                .HasOne(f => f.FoodType)
                .WithMany(ft => ft.Foods)
                .HasForeignKey(f => f.FoodTypeId);

        }
    }
}
