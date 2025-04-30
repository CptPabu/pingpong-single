using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;





namespace Repository.Interfaces
{
    public interface IRepositoryUser : IRepository<User>
    {
        User Get(string name, string password);
    }
}
