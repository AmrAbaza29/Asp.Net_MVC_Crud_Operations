using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Models;
using Tickets.DAL;

namespace Tickets.BL;

public class TicketDetailsVM
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsClosed { get; set; }
    public string Description { get; set; } = string.Empty;
    public Severity Priority { get; set; }
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
    public IEnumerable<Developer> Developers { get; set; } = new HashSet<Developer>();
}

public class TicketChildVM
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
