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
    public class FoodTypeMap: IEntityTypeConfiguration<FoodType>
    {
        void IEntityTypeConfiguration<FoodType>.Configure(EntityTypeBuilder<FoodType> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Name).HasMaxLength(50).IsRequired(true);


    }
    
    }
}
