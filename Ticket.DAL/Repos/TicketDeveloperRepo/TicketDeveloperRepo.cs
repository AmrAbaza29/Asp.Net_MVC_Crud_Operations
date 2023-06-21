using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Models;

namespace Tickets.DAL.Repos;

public class TicketDeveloperRepo : GenericRepo<TicketDeveloperRepo>, ITicketDeveloperRepo
{
    private readonly TicketContext _ticketContext;
    public TicketDeveloperRepo(TicketContext ticketContext) : base(ticketContext) 
    {
        _ticketContext = ticketContext;
    }

    public void AddDevelopersTickets(IEnumerable<TicketDevelopers> TicketDevelopersToAdd)
    {
        _ticketContext.TicketDevelopers.AddRange(TicketDevelopersToAdd);
    }

    public void DeleteRangeOfTicketDevelopers(IEnumerable<TicketDevelopers> developers)
    {
       _ticketContext.TicketDevelopers.RemoveRange(developers);
    }

    public ICollection<TicketDevelopers> GetTicketDevelopers(Ticket ticket)
    {
        var developers = _ticketContext.TicketDevelopers.Where(t => t.TicketId == ticket.Id).ToList();
        return developers;
    }

    public ICollection<Guid> GetTicketDevelopersId(Guid Id)
    {
        return _ticketContext.TicketDevelopers.Where(d => d.TicketId == Id)
            .Select(d => d.DeveloperId).ToList();
    }
}
