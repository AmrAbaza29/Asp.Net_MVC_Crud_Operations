using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL;

namespace Tickets.BL;

public class TicketAddVM
{
    [DisplayName("Reservation Date")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage ="Please Enter A Valid Date.")]
    public DateTime CreatedDate { get; set; }
    [DisplayName("Close")]
    public bool IsClosed { get; set; }
    [Required(ErrorMessage ="Description Is Requied.")]
    [MaxLength(30, ErrorMessage ="Characters must be less than 30.")]
    [MinLength(5, ErrorMessage ="Characters Must be more than 5 and less than 30.")]
    public string Description { get; set; } = string.Empty;
    public Severity Priority { get; set; }
    [DisplayName("Department")]
    [Required(ErrorMessage ="Please select a department")]
    public Guid DepartmentId { get; set; }
    [DisplayName("Developers")]
    [Required(ErrorMessage ="Please Select 1 developer at least.")]
    public ICollection<Guid> DevelopersIds { get; set; }= new HashSet<Guid>();
}
