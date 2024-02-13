using BA.DietTrackApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.DietTrackApp.DAL.Repository
{
    public class FoodMealRepository : GenericRepository<FoodMeal>
    {
        public FoodMealRepository(DbContext context) : base(context)
        {
            //TODO bunu sonra değiştir

        }
        public List<FoodMeal> GetAllTable()
        {
            return _dbset.Include(x=>x.Food).Include(x=>x.Meal).ToList();
        }

        public List<FoodMeal> GetTablewFT()
        {
            return _dbset.Include(x => x.Food).Include(x=>x.Food.FoodType).Include(x => x.Meal).ToList();
        }

        public List<FoodMeal> GetTablewMT()
        {
            return _dbset.Include(x=>x.Meal).Include(x=>x.Meal.MealType).Include(x=>x.Food).ToList();
        }
    }
}
