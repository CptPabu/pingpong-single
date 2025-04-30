using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace Repository.Interfaces
{
    public interface IRepository<T>
    {
        T Create(T entity);
        T Get(int id);
        IQueryable<T> GetAll();
        void Update();
        void Delete(T entity);
    }
}
