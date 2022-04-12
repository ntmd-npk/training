using Repository.Models;
using Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {

        private readonly ManageContext _context;
        private DbSet<T> entities;

        public BaseRepository(ManageContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public IEnumerable<T> Get()
        {
            return entities;
        }

        public int Create(T entity)
        {
            var id = entities.Max(_ => _.Id);
            entities.Add(entity);
            _context.SaveChanges();
            return id;
        }

        public void Update(int id, T entity)
        {
            var editItem = entities.Find(id);
            if (editItem != null)
            {
                // Get properties
                // Loop in properties, get newValue from edit object
                //      - If edit object has null value on property ==> Continue
                //      - If edit object has value => set new value to object in database
                var props = entity.GetType().GetProperties();
                foreach (var prop in props)
                {
                    if (prop.Name == "Id") continue;
                    var value = prop.GetValue(entity, null);
                    if (value != null) { prop.SetValue(editItem, value, null); };
                }
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("This ID is not a valid ID.");
            }
        }

        public void Delete(int id)
        {
            var deleteItem = entities.Find(id);
            if (deleteItem != null)
            {
                entities.Remove(deleteItem);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("This ID is not valid ID.");
            }
        }
    }
}
