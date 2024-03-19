using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PasaPhone.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // T - Phone
        //IEnumerable<T> GetAll(); // method for retrieving all records (phones)
        IQueryable<T> GetAll(); // method for retrieving all records (phones)
        Task<T?> Get(Expression<Func<T, bool>> filter); // method for retrieving individual record (phone)
        void Add(T entity); // method for adding a record (phone)
        void Remove(T entity); // method for deleting a record (phone)
        void RemoveRange(IEnumerable<T> entity); // method for deleting a range of records (phones)
        bool IsItemExists(Expression<Func<T, bool>> doesExist);
    }
}
