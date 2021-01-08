using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users_DataModels.DataModels;

namespace Users_Repos.Repos
{
    public class GendersRepository : Repository<Genders>
    {
        public GendersRepository(UsersDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
