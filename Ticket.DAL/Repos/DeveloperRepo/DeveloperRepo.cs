using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Models;

namespace Tickets.DAL.Repos;

public class DeveloperRepo : GenericRepo<Developer>, IDeveloperRepo
{
    private readonly TicketContext _ticketContext;

    public DeveloperRepo(TicketContext ticketContext) : base(ticketContext)
    {
        _ticketContext = ticketContext;
    }

    public IEnumerable<Developer> GetDevelopersForTicket(Guid Id)
    {
        var developers = _ticketContext.Tickets
                             .Include(t => t.TicketDevelopers)
                                 .ThenInclude(td => td.Developer)
                                    .FirstOrDefault(t => t.Id == Id)?.TicketDevelopers
                                        .Select(td => td.Developer).ToList();
        return developers;
    }
}
