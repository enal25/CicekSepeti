using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetSingle(string id);
        Task<IEnumerable<T>> FindBy(string key);
        Task Add(T entity);
        Task<bool> Update(string id, T entity);
        Task<bool> Delete(string id);
        Task<bool> DeleteAll();
    }
}
