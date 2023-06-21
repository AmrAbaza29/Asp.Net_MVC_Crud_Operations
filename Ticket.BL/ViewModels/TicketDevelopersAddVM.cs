using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.BL.ViewModels;

public class TicketDevelopersAddVM
{
    public Guid Id { get; set; }
    public IEnumerable<Guid> DevelopersIds { get; set; }   = new HashSet<Guid>();
}
