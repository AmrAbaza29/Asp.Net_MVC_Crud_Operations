using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL.Repos;

public interface ITicketRepo:IGenericRepo<Ticket>
{
    public IEnumerable<Ticket> GetTicketsForDepartment(Guid Id);
}
