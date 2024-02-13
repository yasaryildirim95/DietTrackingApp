using BA.DietTrackApp.Entity.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

public static class CsvSeedData
{
    public static void SeedFromCsv(this ModelBuilder modelBuilder)
    {
        // CSV dosyanızın yolu
        string csvFilePath = "C:\\Users\\yasar\\Downloads\\BA.DietTrackApp\\BA.DietTrackApp.DAL\\Yemekler.csv";
        
        using (var reader = new StreamReader(csvFilePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            var records = new List<Food>();
            csv.Read();
            csv.ReadHeader();

            while (csv.Read())
            {
                var record = new Food
                {
                    Id = csv.GetField<int>("Id"),
                    FName = csv.GetField<string>("Name"),
                    Calori = csv.GetField<int>("Calori"),
                    FoodTypeId = csv.GetField<int>("FoodTypeId")
                };

                records.Add(record);
            }
            
            modelBuilder.Entity<Food>().HasData(records);
        }
    }
}
