using BA.DietTrackApp.BLL.Services;
using BA.DietTrackApp.DAL.Context;
using BA.DietTrackApp.DAL.Repository;
using BA.DietTrackApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.DietTrackApp.BLL.Managers
{
    public class FoodManager : BaseManager<Food>, IFoodService
    {
        public FoodManager(GenericRepository<Food> repository) : base(repository)
        {
            _repository = repository;
        }

    }
}
