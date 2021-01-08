using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users_DataModels.DataModels;

namespace Users_Repos.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UsersDbContext dbContext;

        public UsersRepository Users { get; }
        public GendersRepository Genders { get; }
        public MembershipsRepository Memberships { get; }

        public UnitOfWork()
        {
            dbContext = new UsersDbContext();

            Users = new UsersRepository(dbContext);
            Genders = new GendersRepository(dbContext);
            Memberships = new MembershipsRepository(dbContext);
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
