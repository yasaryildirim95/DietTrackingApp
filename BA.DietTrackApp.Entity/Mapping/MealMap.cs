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
    public class MealMap : IEntityTypeConfiguration<Meal>
    {
        void IEntityTypeConfiguration<Meal>.Configure(EntityTypeBuilder<Meal> builder)
        {

            builder.HasKey(m => m.Id);
            builder.Property(m => m.MealTypeId).IsRequired(true);
            builder.Property(m => m.Date).IsRequired(true);

            builder
                .HasOne(m => m.User)
            .WithMany(u => u.Meals)
            .HasForeignKey(m => m.UserId);
            builder
                .HasOne(m => m.MealType)
            .WithMany(mt => mt.Meals)
            .HasForeignKey(m => m.MealTypeId);


        }
    
    }
}
