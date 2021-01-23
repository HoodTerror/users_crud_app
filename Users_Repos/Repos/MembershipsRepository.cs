using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users_DataModels.DataModels;

namespace Users_Repos.Repos
{
    public class MembershipsRepository : Repository<Memberships>
    {
        public MembershipsRepository(UsersDbContext dbContext)
            : base (dbContext)
        {
        }
    }
}
