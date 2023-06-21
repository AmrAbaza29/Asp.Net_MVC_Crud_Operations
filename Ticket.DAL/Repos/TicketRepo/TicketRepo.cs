using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL.Repos;
public class TicketRepo : GenericRepo<Ticket>, ITicketRepo
{
    private readonly TicketContext _ticketContext;

    public TicketRepo(TicketContext ticketContext) : base(ticketContext)
    {
        _ticketContext = ticketContext;
    }

    public IEnumerable<Ticket> GetTicketsForDepartment(Guid Id)
    {
        var tickets = _ticketContext.Tickets
                             .Include(t => t.Department).Where(t => t.DepartmentId == Id);
                                                             
        return tickets;
    }
}
//var developers = _ticketContext.Tickets
//                             .Include(t => t.TicketDevelopers)
//                                 .ThenInclude(td => td.Developer)
//                                    .FirstOrDefault(t => t.Id == Id)?.TicketDevelopers
//                                        .Select(td => td.Developer).ToList();
//        return developers;