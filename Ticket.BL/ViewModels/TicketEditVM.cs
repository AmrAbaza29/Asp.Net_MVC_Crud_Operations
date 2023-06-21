using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL;

namespace Tickets.BL;

public class TicketEditVM
{
    public Guid Id { get; set; }
   
    [DisplayName("Close")]
    public bool IsClosed { get; set; }
    [Required]
    [MaxLength(30)]
    [MinLength(5)]
    public string Description { get; set; } = string.Empty;
    public Severity Priority { get; set; }
    [DisplayName("Department")]
    [Required]
    public Guid DepartmentId { get; set; }
    [DisplayName("Developers")]
    [Required]
    public ICollection<Guid> DevelopersIds { get; set; } = new HashSet<Guid>();
}
