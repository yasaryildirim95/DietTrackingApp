using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BA.DietTrackApp.Entity.Entities;
using BA.DietTrackApp.Entity.Mapping;
using CsvHelper;
using CsvHelper.Configuration;

namespace BA.DietTrackApp.DAL.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<FoodMeal> FoodMeals { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=Gaming-PC\SQLEXPRESS;Initial Catalog=DietTrackingDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new MealMap());
            modelBuilder.ApplyConfiguration(new FoodMap());
            modelBuilder.ApplyConfiguration(new FoodMealMap());
            modelBuilder.ApplyConfiguration(new FoodTypeMap());
            modelBuilder.ApplyConfiguration(new MealTypeMap());

            modelBuilder.Entity<FoodType>().HasData(new FoodType { Id = 1, Name = "Meyve" });
            modelBuilder.Entity<FoodType>().HasData(new FoodType { Id = 2, Name = "Sebze/Baharat" });
            modelBuilder.Entity<FoodType>().HasData(new FoodType { Id = 3, Name = "Hamur İşi" });
            modelBuilder.Entity<FoodType>().HasData(new FoodType { Id = 4, Name = "Tahıl" });
            modelBuilder.Entity<FoodType>().HasData(new FoodType { Id = 5, Name = "Baklagil" });
            modelBuilder.Entity<FoodType>().HasData(new FoodType { Id = 6, Name = "Et" });
            modelBuilder.Entity<FoodType>().HasData(new FoodType { Id = 7, Name = "Deniz Ürünleri" });
            modelBuilder.Entity<FoodType>().HasData(new FoodType { Id = 8, Name = "Süt Ürünleri" });
            modelBuilder.Entity<FoodType>().HasData(new FoodType { Id = 9, Name = "Kuruyemiş" });
            modelBuilder.Entity<FoodType>().HasData(new FoodType { Id = 10, Name = "Tohumlar" });
            modelBuilder.Entity<FoodType>().HasData(new FoodType { Id = 11, Name = "Yağ" });
            modelBuilder.Entity<FoodType>().HasData(new FoodType { Id = 12, Name = "Soslar" });
            modelBuilder.Entity<FoodType>().HasData(new FoodType { Id = 13, Name = "Turşular" });
            modelBuilder.Entity<FoodType>().HasData(new FoodType { Id = 14, Name = "Tatlılar" });
            modelBuilder.Entity<FoodType>().HasData(new FoodType { Id = 15, Name = "Fastfood & Atıştırmalık" });
            modelBuilder.Entity<FoodType>().HasData(new FoodType { Id = 16, Name = "Yumurtalar" });

            modelBuilder.Entity<MealType>().HasData(new MealType { Id = 1, MTName = "Kahvaltı" });
            modelBuilder.Entity<MealType>().HasData(new MealType { Id = 2, MTName = "Öğle Yemeği" });
            modelBuilder.Entity<MealType>().HasData(new MealType { Id = 3, MTName = "Aşkam Yemeği" });
            modelBuilder.Entity<MealType>().HasData(new MealType { Id = 4, MTName = "Ara Öğün" });

            modelBuilder.SeedFromCsv();
        }
       
    }
}
