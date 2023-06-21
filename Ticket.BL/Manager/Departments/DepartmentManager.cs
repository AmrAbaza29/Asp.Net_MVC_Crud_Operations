using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.BL.ViewModels;
using Tickets.DAL;
using Tickets.DAL.Repos;

namespace Tickets.BL;

public class DepartmentManager : IDepartmentManager
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IEnumerable<DepartmentReadVM> GetDepartments()
    {
        IEnumerable<Department> departmentsFromDB = _unitOfWork.DepartmentRepo.GetAll();
        IEnumerable<DepartmentReadVM> departmentsVM = departmentsFromDB.
            Select(d => new DepartmentReadVM
            {
                Id = d.Id,
                Name = d.Name
            });
        return departmentsVM;
    }
    public void AddVM(DepartmentAddVM departmentVM)
    {
        Department d = new Department()
        {
            Id = departmentVM.Id,
            Name = departmentVM.Name
        };
        _unitOfWork.DepartmentRepo.Add(d);
        _unitOfWork.Save();
    }

    public void Delete(Guid Id)
    {
        var departmentToDelete = _unitOfWork.DepartmentRepo.GetById(Id);
        if (departmentToDelete is null)
            return;
        _unitOfWork.DepartmentRepo.Delete(departmentToDelete);
        _unitOfWork.Save();
    }

    public DepartmentDetailsVM? DepartmentDetails(Guid Id)
    {
        var department = _unitOfWork.DepartmentRepo.GetById(Id);
        var tickets = _unitOfWork.TicketRepo.GetTicketsForDepartment(Id);
        if (department is null) 
            return null;
        DepartmentDetailsVM departmentVM = new DepartmentDetailsVM
        {
            Id = department.Id,
            Name = department.Name,
            Tickets = tickets
        };
        return departmentVM;
    }
}