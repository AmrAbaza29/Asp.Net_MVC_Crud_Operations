using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL.Repos;

public interface IGenericRepo<T> where T : class
{
    IEnumerable<T> GetAll();
    T? GetById(Guid Id);
    void Add(T Entity);
    void Update(T Entity);  
    void Delete(T Entity);
    int SaveChanges();
}
