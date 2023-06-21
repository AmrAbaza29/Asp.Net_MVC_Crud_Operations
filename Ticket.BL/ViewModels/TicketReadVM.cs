using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL;

namespace Tickets.BL;

public class TicketReadVM
{
    public Guid Id { get; set; }
    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }
    public bool IsClosed { get; set; }
    public Severity Priority { get; set; }
    public string Description { get; set; } = string.Empty;
}
