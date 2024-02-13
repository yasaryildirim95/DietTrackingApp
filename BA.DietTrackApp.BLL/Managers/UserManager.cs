using BA.DietTrackApp.BLL.Services;
using BA.DietTrackApp.DAL.Repository;
using BA.DietTrackApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static BA.DietTrackApp.BLL.Managers.UserManager;

namespace BA.DietTrackApp.BLL.Managers
{
    public class UserManager : BaseManager<User>, IUserService
    {
        public UserManager(GenericRepository<User> repository) : base(repository)
        {
            _repository = repository;
        }
        public bool IsStrongPassword(string password)
        {
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;
            bool hasSpecialCharacter = false;

            foreach (char character in password)
            {
                if (char.IsUpper(character))
                    hasUpperCase = true;
                else if (char.IsLower(character))
                    hasLowerCase = true;
                else if (char.IsDigit(character))
                    hasDigit = true;
                else if (IsSpecialCharacter(character))
                    hasSpecialCharacter = true;
            }

            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialCharacter && password.Length >= 8;
        }

        public bool IsSpecialCharacter(char character)
        {
            string specialCharacters = "!@#$%^&*()+-=[]{}|;':,.<>?";

            return specialCharacters.Contains(character);
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9.%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$";

            return Regex.IsMatch(email, pattern);
        }
        public bool IsUserExist(string username)
        {
            var usernameKontrol = _repository.GetQueryable().Where(x => x.UserName == username).FirstOrDefault();
            if (usernameKontrol != null)
                return true;
            else
                return false;
        }

        public int IsAccountTrue(string username, string password)
        {
            var LoginKontrol = _repository.GetQueryable().Where(x => x.Password == password && x.UserName == username).FirstOrDefault();
            if (LoginKontrol != null)
            {
                int tempInt = LoginKontrol.Id;
                return tempInt;
            }

            else
            {
                return -1;
            }
        }

    }
}
