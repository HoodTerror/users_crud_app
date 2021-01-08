using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_Repos.Repos
{
    public interface IUnitOfWork : IDisposable
    {
        UsersRepository Users { get; }
        GendersRepository Genders { get; }
        MembershipsRepository Memberships { get; }

        int Commit();
    }
}
