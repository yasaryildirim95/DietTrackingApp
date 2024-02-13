using BA.DietTrackApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.DietTrackApp.BLL.Services
{
    public interface IUserService : IService<User>
    {
        public bool IsStrongPassword(string password);
        public bool IsSpecialCharacter(char character);
        public bool IsUserExist(string username);
        public int IsAccountTrue(string username,string password);
        public bool IsValidEmail(string email);
    }
}
