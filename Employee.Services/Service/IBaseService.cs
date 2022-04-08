using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface IBaseService<IEntity> where IEntity : class
    {
        IEnumerable<IEntity> Get();
        int Create(IEntity entity);
        void Delete(int id);
        void Update(int id, IEntity entity);
    }
}
