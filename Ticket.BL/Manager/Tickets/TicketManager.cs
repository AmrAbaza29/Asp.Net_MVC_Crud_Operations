using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.BL.Manager.TicketDeveloper;
using Tickets.DAL;
using Tickets.DAL.Data.Models;
using Tickets.DAL.Repos;

namespace Tickets.BL;

public class TicketManager : ITicketManager
{
    private readonly IUnitOfWork _unitOfWork;

    public TicketManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void AddVM(TicketAddVM ticketVM)
    {
        var selectedDepartment = _unitOfWork.DepartmentRepo.GetAll().
            FirstOrDefault(d=> d.Id == ticketVM.DepartmentId);
        var selectedDevelopers =_unitOfWork.DepartmentRepo.GetAll().
            Where(d => ticketVM.DevelopersIds.Contains(d.Id));
        Ticket t = new Ticket
        {
            Id = Guid.NewGuid(),
            CreatedDate = ticketVM.CreatedDate,
            DepartmentId = ticketVM.DepartmentId,
            Description = ticketVM.Description,
            IsClosed = ticketVM.IsClosed,
            Priority = ticketVM.Priority,
        };
        IEnumerable<TicketDevelopers> developers = ticketVM.DevelopersIds.Select(d => new TicketDevelopers
        {
            DeveloperId=d,
            TicketId=t.Id
        });
        _unitOfWork.TicketRepo.Add(t);
        _unitOfWork.TicketDeveloperRepo.AddDevelopersTickets(developers);
        _unitOfWork.Save();
    }

    public TicketDetailsVM? TicketDetails(Guid Id)
    {
        Ticket? ticketFromDb = _unitOfWork.TicketRepo.GetById(Id);
        var SelectedDevelopers = _unitOfWork.DeveloperRepo.GetDevelopersForTicket(Id);  
        var SelectedDepartment = _unitOfWork.DepartmentRepo.GetDepartmentByTicketId(Id);
        if (ticketFromDb == null)
            return null;
        var developersId = ticketFromDb.TicketDevelopers.Select(d => d.TicketId == Id);
        //    var developerNames = _ticketContext.Developers
        //.Where(d => _ticketContext.TicketDevelopers
        //    .Where(td => td.TicketId == Id)
        //    .Select(td => td.DeveloperId)
        //    .Contains(d.Id))
        //.Select(d => $"{d.FirstName} {d.LastName}")
        //.ToList();
        //return developerNames;
        return new TicketDetailsVM
        {
            Id = ticketFromDb.Id,
            Description = ticketFromDb.Description,
            IsClosed = ticketFromDb.IsClosed,
            CreatedDate=ticketFromDb.CreatedDate,
            Priority = ticketFromDb.Priority,
            Department = SelectedDepartment,
            Developers=SelectedDevelopers,
        };
    }

    public IEnumerable<TicketReadVM> ticketsReadVM()
    {
        IEnumerable<Ticket> ticketsFromDB = _unitOfWork.TicketRepo.GetAll();
        IEnumerable<TicketReadVM> ticketsVM = ticketsFromDB
            .Select(t => new TicketReadVM
            {
                Id= t.Id,
                Description= t.Description,
                IsClosed= t.IsClosed,
                Priority= t.Priority,
                CreatedDate=t.CreatedDate,
            });
        return ticketsVM;
    }

    public void Delete(Guid Id)
    {
        var ticketToDelete = _unitOfWork.TicketRepo.GetById(Id);
        if(ticketToDelete == null) 
            return;
        _unitOfWork.TicketRepo.Delete(ticketToDelete);
        _unitOfWork.Save();
    }

    public TicketEditVM? Edit(Guid Id)
    {
        
        var ticketFromDb = _unitOfWork.TicketRepo.GetById(Id);
        if (ticketFromDb == null)
            return null;
        //var devIds = _developerRepo.GetAll().Where(d=>d.);
        var devIds = _unitOfWork.TicketDeveloperRepo.GetTicketDevelopersId(Id);
        TicketEditVM ticketVM = new TicketEditVM
        {
            Id = ticketFromDb.Id,
            DepartmentId = ticketFromDb.DepartmentId,
            Description = ticketFromDb.Description,
            IsClosed = ticketFromDb.IsClosed,
            Priority = ticketFromDb.Priority,
            //DevelopersIds = ticketFromDb.TicketDevelopers.Select(d=>d.DeveloperId).ToList(),
            DevelopersIds=devIds
        };
        return ticketVM;
    }
    public void EditUsingVM(TicketEditVM ticket)
    {

        var ticketFromDb = _unitOfWork.TicketRepo.GetById(ticket.Id);
        if (ticketFromDb == null)
            return;
        var ticketDevelopersToDelete = _unitOfWork.TicketDeveloperRepo.GetTicketDevelopers(ticketFromDb);
        //var devIds = _developerRepo.GetAll().Where(d=>d.);
        ticketFromDb.DepartmentId = ticket.DepartmentId;
        ticketFromDb.Description = ticket.Description;
        ticketFromDb.IsClosed = ticket.IsClosed;
        ticketFromDb.Id= ticket.Id;
        _unitOfWork.TicketDeveloperRepo.DeleteRangeOfTicketDevelopers(ticketDevelopersToDelete);
        IEnumerable<TicketDevelopers> developers = ticket.DevelopersIds.Select(d => new TicketDevelopers
        {
            DeveloperId = d,
            TicketId = ticketFromDb.Id
        });
        _unitOfWork.TicketDeveloperRepo.AddDevelopersTickets(developers);
        _unitOfWork.TicketRepo.Update(ticketFromDb);
        _unitOfWork.Save();
    }

}
