using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL.Data.Models;

public class TicketDevelopers
{
    public Guid TicketId { get; set; }
    public Guid DeveloperId { get; set; }
    public Ticket Ticket { get; set; } = null!;
    public Developer Developer { get; set; } = null!;
}
