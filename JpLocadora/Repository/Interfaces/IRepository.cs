using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T model);

        T GetById(int id);

        IEnumerable<T> GetAll();

        void Remove(T model);

        void Update(T model);
    }
}
