using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Models;

namespace Tickets.DAL;
public class Ticket
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsClosed { get; set; }
    public string Description { get; set; } = string.Empty;
    public Severity Priority { get; set; }
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
    public ICollection<TicketDevelopers> TicketDevelopers { get; set; } = new HashSet<TicketDevelopers>();


}

