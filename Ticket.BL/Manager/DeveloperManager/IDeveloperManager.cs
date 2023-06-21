using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL;

namespace Tickets.BL;

public interface IDeveloperManager
{
    IEnumerable<TicketChildVM> GetDevelopers();
}
