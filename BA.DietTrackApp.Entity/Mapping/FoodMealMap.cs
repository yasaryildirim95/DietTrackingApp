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
    public class FoodMealMap : IEntityTypeConfiguration<FoodMeal>
    {
        void IEntityTypeConfiguration<FoodMeal>.Configure(EntityTypeBuilder<FoodMeal> builder)
        {
            builder.HasKey(f => f.Id);
            builder
            .HasOne(fm => fm.Meal)
            .WithMany(m => m.FoodMeals)
            .HasForeignKey(fm => fm.MealId);

            builder
                .HasOne(fm => fm.Food)
                .WithMany(f => f.FoodMeals)
                .HasForeignKey(fm => fm.FoodId);
        }

    }
}
