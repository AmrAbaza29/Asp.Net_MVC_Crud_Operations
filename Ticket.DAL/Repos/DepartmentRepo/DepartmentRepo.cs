using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL.Repos;

public class DepartmentRepo:GenericRepo<Department>, IDepartmentRepo
{
    private readonly TicketContext _ticketContext;

    public DepartmentRepo(TicketContext ticketContext):base(ticketContext)
    {
        _ticketContext = ticketContext;
    }

    public Department? GetDepartmentByTicketId(Guid Id)
    {
        var x = _ticketContext.Set<Department>()
                       .Include(d => d.Tickets)
                        // Include the Department object for each Ticket
                       .Where(d => d.Tickets.Any(t => t.Id == Id)) // Filter Departments that have a Ticket with the given Id
                       .FirstOrDefault(); // Get the first matching
        return x;
    }

}
