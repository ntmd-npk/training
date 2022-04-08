using Repository.Models;
using Repository.Context;

namespace Repository.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {

        private readonly ManageContext _context;
        //private DbSet<T> entities;

        public BaseRepository(ManageContext context)
        {
            _context = context;
            // entities = _context.Set<T>();
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>();
        }

        public int Create(T entity)
        {
            var id = _context.Set<T>().Max(_ => _.Id);
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return id;
        }

        public void Update(int id, T entity)
        {
            var editEmployee = _context.Set<T>().Find(id);
            if (editEmployee != null)
            {
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("This ID is not a valid ID.");
            }
        }

        public void Delete(int id)
        {
            var deleteEmployee = _context.Set<T>().Find(id);
            if (deleteEmployee != null)
            {
                _context.Set<T>().Remove(deleteEmployee);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("This ID is not valid ID.");
            }
        }
    }
}
