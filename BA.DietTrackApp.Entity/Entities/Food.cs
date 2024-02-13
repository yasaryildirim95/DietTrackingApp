using BA.DietTrackApp.Entity.Anstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.DietTrackApp.Entity.Entities
{
    public class Food : IEntity
    {
        public Food()
        {
            FoodMeals = new List<FoodMeal>();
        }
        public int Id { get; set; }
        public string FName { get; set; }
        public decimal Calori { get; set; }
        public int FoodTypeId { get; set; }
        public FoodType FoodType { get; set; }
        public List<FoodMeal> FoodMeals { get; set; }
    }
}
