using BA.DietTrackApp.BLL.Services;
using BA.DietTrackApp.DAL.Abstract;
using BA.DietTrackApp.DAL.Repository;
using BA.DietTrackApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.DietTrackApp.BLL.Managers
{
    public class FoodTypeManager : BaseManager<FoodType>, IFoodTypeService
    {
        public FoodTypeManager(GenericRepository<FoodType> repository) : base(repository)
        {
            _repository = repository;
        }

    }
}
