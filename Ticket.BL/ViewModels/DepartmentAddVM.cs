using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.BL.ViewModels;

public class DepartmentAddVM
{
    public Guid Id { get; set; }
    [Required]
    [MaxLength(20), MinLength(5)]
    public string Name { get; set; }=string.Empty;
}
