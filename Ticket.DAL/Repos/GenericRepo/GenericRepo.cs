using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL.Repos;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly TicketContext _ticketContext;

    public GenericRepo(TicketContext ticketContext)
    {
        _ticketContext = ticketContext;
    }
    public IEnumerable<T> GetAll()
    {
        return _ticketContext.Set<T>().AsNoTracking();
    }
    public T? GetById(Guid Id)
    {
        return _ticketContext.Set<T>().Find(Id);
    }
    public void Add(T Entity)
    {
        _ticketContext.Add(Entity);
        _ticketContext.SaveChanges();
    }

    public void Delete(T Entity)
    {
        _ticketContext.Remove(Entity);
    }
    public void Update(T Entity)
    {
    }

    public int SaveChanges()
    {
       return _ticketContext.SaveChanges();
    }
}
