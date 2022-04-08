using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class BaseService<IEntity> : IBaseService<IEntity> where IEntity : class
    {
        private readonly IBaseRepository<IEntity> _repository;
        public BaseService(IBaseRepository<IEntity> repository)
        {
            _repository = repository;
        }
        public int Create(IEntity entity)
        {
            return _repository.Create(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<IEntity> Get()
        {
            return _repository.Get();
        }

        public void Update(int id, IEntity entity)
        {
            _repository.Update(id, entity);
        }
    }
}
