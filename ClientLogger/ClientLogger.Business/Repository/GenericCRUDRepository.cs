using ClientLogger.Business.Infrastructure;
using System.Collections.Generic;

namespace ClientLogger.Business.Repository
{
    public class GenericCRUDRepository
    {
        DataContext _context;

        public DataContext Context
        {
            get
            {
                return _context;
            }
        }


        public GenericCRUDRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAllEntities<T>() where T: class
        {
          return _context.Set<T>().AsQueryable();
        }

        public T GetEntityById<T>(int id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public void DeleteEntity<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public T UpdateEntity<T>(T entity) where T : class
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public T CreateEntity<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
