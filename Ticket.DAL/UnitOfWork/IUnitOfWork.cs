using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Repos;

namespace Tickets.DAL;
public interface IUnitOfWork
{
    public IDepartmentRepo DepartmentRepo { get; }
    public ITicketRepo TicketRepo { get; }
    public IDeveloperRepo DeveloperRepo { get; }
    public ITicketDeveloperRepo TicketDeveloperRepo { get; }
    public int Save();
}
