using BA.DietTrackApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.DietTrackApp.DAL.Repository
{
    internal class FoodRepository : GenericRepository<Food>
    {
        public FoodRepository(DbContext context) : base(context)
        {
        }

    }
}
