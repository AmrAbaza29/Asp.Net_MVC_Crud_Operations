using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.BL;

public interface ITicketManager
{
    IEnumerable<TicketReadVM> ticketsReadVM();
    TicketDetailsVM? TicketDetails(Guid Id);
    void AddVM(TicketAddVM ticketVM);
    void Delete(Guid Id);
    TicketEditVM? Edit(Guid Id);
    void EditUsingVM(TicketEditVM ticketEditVM);


}
