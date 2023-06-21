using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL.Repos;

public interface IDepartmentRepo:IGenericRepo<Department>
{
    Department GetDepartmentByTicketId(Guid Id);
}
