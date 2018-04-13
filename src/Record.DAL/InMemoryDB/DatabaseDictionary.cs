using Record.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Record.DAL.InMemoryDB
{
    public class DatabaseDictionary
    {

        public static int index = 0;
        public static ConcurrentDictionary<int, UserEntity>
            UserCached = new ConcurrentDictionary<int, UserEntity>();
    }
}
