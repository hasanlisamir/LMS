using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BL.Services.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        public T Add(T entity);
        public T Get(int id);
        public IList<T> GetAll();
        public void Update(T entity);
        public void Delete(int id);
    }
}
