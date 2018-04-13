using Record.DAL.InMemoryDB;
using Record.Entities;
using Record.Util;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Record.DAL
{
    public class UserDAO
    {

        public static bool UserExists(string login)
        {
            return DatabaseDictionary.UserCached.Any(tr => tr.Value.Login.Equals(login, StringComparison.CurrentCultureIgnoreCase));
        }

        public static bool Create(UserEntity user)
        {

            int lenght = DatabaseDictionary.UserCached.Count;
            user.Id = lenght;

            Task task;

            task = Task.Run(() =>
            {

                if (DatabaseDictionary.UserCached.TryAdd(lenght, user))
                    RecordLogger.LogInfo("Item Adicionado");
                else
                    RecordLogger.LogInfo("Não foi possível adicionar o item");

            });

            task.Wait();

            return true;
        }

        public static bool Update(UserEntity currentUser)
        {

            try
            {
                DatabaseDictionary.UserCached[currentUser.Id] = currentUser;
                return true;
            }
            catch(Exception ex)
            {
                RecordLogger.LogError(ex);
            }


            return false;

        }

        public static UserEntity GetUserById(int id)
        {
            return DatabaseDictionary.UserCached.Values.First(p => p.Id == id);
        }

        public static List<UserEntity> GetAllUsers()
        {
            return DatabaseDictionary.UserCached.Values.ToList();
        }

        public static bool Delete(int id)
        {

            try
            {
                ((IDictionary)DatabaseDictionary.UserCached).Remove(id);
                return true;
            }
            catch (Exception ex)
            {
                RecordLogger.LogError(ex);
            }


            return false;
        }
    }
}
