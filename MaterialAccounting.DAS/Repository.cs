using MaterialAccounting.Common.Exceptions;
using MaterialAccounting.DAS.Interfaces;
using MaterialAccounting.DAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MaterialAccounting.DAS
{
    internal class Repository<T> : IRepository<T>
        where T: Model
    {
        public long Add(T entity)
        {
            using (var context = new MaterialDbContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
                return entity.Id;
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var context = new MaterialDbContext())
            {
                IEnumerable<T> entities = context.Set<T>()
                    .Where(x => x.Removed == false);

                foreach (var entity in entities)
                {
                    yield return entity;
                }
            }
        }

        public T GetById(long id)
        {
            T entity;
            using (var context = new MaterialDbContext())
            {
                entity = context.Set<T>()
                    .FirstOrDefault(x => x.Id.Equals(id));

                if (entity == null)
                {
                    throw new IdNotExistsException(id);
                }
            }
            return entity;
        }

        public IEnumerable<T> GetRemoved()
        {
            using (var context = new MaterialDbContext())
            {
                foreach (var entity in context.Set<T>())
                {
                    yield return entity;
                }
            }
        }

        public void Remove(T entity)
        {
            entity.Removed = true;
            Update(entity);
        }

        public void Remove(long id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException(id);
            }

            T entity = GetById(id);
            Remove(entity);
        }

        public void Restore(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entity.Removed = false;
            Update(entity);
        }

        public void Restore(long id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException(id);
            }

            T entity = GetById(id);
            Restore(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            using (var context = new MaterialDbContext())
            {
                var realEntity = context.Set<T>()
                    .FirstOrDefault(x => x.Id == entity.Id);
                if (!ReferenceEquals(realEntity, entity))
                {
                    CopyProperties(entity, realEntity);
                }

                context.SaveChanges();
            }
        }

        private void CopyProperties(T source, T dest)
        {
            Type type = typeof(T);
            IEnumerable<PropertyInfo> properties = type.GetProperties()
                .Where(x => x.CanWrite && x.CanRead);
            foreach (var property in properties)
            {
                object value = property.GetValue(source);
                property.SetValue(dest, value);
            }
        }
    }
}
