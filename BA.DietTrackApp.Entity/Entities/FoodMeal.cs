using BA.DietTrackApp.Entity.Anstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.DietTrackApp.Entity.Entities
{
    public class FoodMeal:IEntity
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public int FoodId { get; set; }
        public decimal Portion { get; set; }
        public Meal Meal { get; set; }
        public Food Food { get; set; }
    }
}
