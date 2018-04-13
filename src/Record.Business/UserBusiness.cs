using Record.DAL;
using Record.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Record.Business
{
    public  class UserBusiness
    {
        public static bool SaveUser(UserEntity user)
        {
            if (UserDAO.UserExists(user.Login))      
                return false;         
            else
            {
                UserDAO.Create(user);
                return true;
            }
        }

        public static List<UserEntity> GetAllUsers()
        {
            return UserDAO.GetAllUsers();
        }

        public static bool UpdateUser(UserEntity user)
        {
            return UserDAO.Update(user);
        }

        public static UserEntity GetUserById(int id)
        {
           return  UserDAO.GetUserById(id);
        }

        public static bool DeleteUser(int id)
        {
            return UserDAO.Delete(id);
        }
    }
}
