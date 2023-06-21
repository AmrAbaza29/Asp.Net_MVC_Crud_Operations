using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL;

namespace Tickets.BL;

public class DepartmentDetailsVM
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
}
