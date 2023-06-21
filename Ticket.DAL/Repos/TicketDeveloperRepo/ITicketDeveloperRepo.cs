using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Models;

namespace Tickets.DAL.Repos;

public interface ITicketDeveloperRepo : IGenericRepo<TicketDeveloperRepo>
{
    void AddDevelopersTickets(IEnumerable<TicketDevelopers> TicketDevelopersToAdd);
    public ICollection<Guid> GetTicketDevelopersId(Guid Id);
    public void DeleteRangeOfTicketDevelopers(IEnumerable<TicketDevelopers> developers);
    public ICollection<TicketDevelopers> GetTicketDevelopers(Ticket ticket);
}
