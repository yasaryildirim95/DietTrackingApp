using BA.DietTrackApp.Entity.Anstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.DietTrackApp.Entity.Entities
{
    public class FoodType:IEntity
    {
        public FoodType()
        {
            Foods = new List<Food>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Food> Foods { get; set; }
    }
}
