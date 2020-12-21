using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenericServis<T>
        where T : class,IDatabaseTable,new()
    {
        string Insert(T entity);
        string Delete(int id);
        string Update(T entity);
        T Get(int id);
        List<T> GetList();
    }
}
