using BA.DietTrackApp.Entity.Anstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.DietTrackApp.Entity.Entities
{
    public class MealType:IEntity
    {
        public MealType()
        {
            Meals = new List<Meal>();
        }
        public int Id { get; set; }
        public string MTName { get; set; }
        public List<Meal> Meals { get; set; }
    }
}
