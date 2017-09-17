using MaterialAccounting.DAS.Models;
using System;
using System.Collections.Generic;

namespace MaterialAccounting.DAS.Interfaces
{
    public interface IRepository<T>
        where T: Model
    {
        long Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Remove(long id);
        void Restore(T entity);
        void Restore(long id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetRemoved();
        T GetById(long id);
    }
}
