using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL;
using Tickets.DAL.Repos;

namespace Tickets.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly TicketContext _ticketContext;

    public UnitOfWork(TicketContext ticketContext, 
                        ITicketRepo ticketRepo, 
                        IDepartmentRepo departmentRepo, 
                        IDeveloperRepo developerRepo, 
                        ITicketDeveloperRepo ticketDeveloperRepo
                    )
                        {
                            _ticketContext = ticketContext;
                            TicketRepo = ticketRepo;
                            DepartmentRepo = departmentRepo;
                            DeveloperRepo = developerRepo;
                            TicketDeveloperRepo= ticketDeveloperRepo;
                        }
    public IDepartmentRepo DepartmentRepo { get; }

    public ITicketRepo TicketRepo { get; }

    public IDeveloperRepo DeveloperRepo {get; }

    public ITicketDeveloperRepo TicketDeveloperRepo { get; }

    public int Save()
    {
        return _ticketContext.SaveChanges();
    }
}
