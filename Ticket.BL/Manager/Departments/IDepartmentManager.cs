using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.BL.ViewModels;

namespace Tickets.BL;

public interface IDepartmentManager
{
    IEnumerable<DepartmentReadVM> GetDepartments();
    public void AddVM(DepartmentAddVM departmentVM);
    public void Delete(Guid Id);
    DepartmentDetailsVM? DepartmentDetails(Guid Id);
}
