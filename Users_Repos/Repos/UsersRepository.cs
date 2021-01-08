using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users_DataModels.DataModels;

namespace Users_Repos.Repos
{
    public class UsersRepository : Repository<Users>
    {
        public UsersRepository(UsersDbContext dbContext)
            : base (dbContext)
        {
        }
    }
}
