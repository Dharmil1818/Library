using BOL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     public class UserDb
    {
        private LibraryDbContext objUserdb;

        public UserDb()
        {
            objUserdb = new LibraryDbContext();
        }

        public async Task<IEnumerable<User>>  GetALL()

        {
            return await objUserdb.Users.ToListAsync();
        }

        public async Task<User> GetbyUserName(string username)
        {
            return await objUserdb.Users.SingleOrDefaultAsync(x => x.UserName == username);
        }
    }
}
