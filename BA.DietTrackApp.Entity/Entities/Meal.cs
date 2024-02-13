using BA.DietTrackApp.Entity.Anstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BA.DietTrackApp.Entity.Entities
{
    public class Meal:IEntity
    {
        public Meal()
        {
            FoodMeals = new List<FoodMeal>();
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int MealTypeId { get; set; }
        public User User { get; set; }
        public MealType MealType { get; set; }
        public List<FoodMeal> FoodMeals { get; set; }
    }
}
