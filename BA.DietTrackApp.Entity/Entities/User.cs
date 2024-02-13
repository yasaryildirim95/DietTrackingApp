using BA.DietTrackApp.Entity.Anstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.DietTrackApp.Entity.Entities
{
    public class User:IEntity
    {
        public User()
        {
            Meals = new List<Meal>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Meal> Meals { get; set; }
    }
}
