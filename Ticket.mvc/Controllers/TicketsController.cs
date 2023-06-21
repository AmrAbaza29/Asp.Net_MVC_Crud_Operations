using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tickets.BL;
using Tickets.DAL;

namespace Tickets.mvc.Controllers
{

    public class TicketsController : Controller
    {
        private readonly ITicketManager _ticketManager;
        private readonly IDepartmentManager _departmentManager;
        private readonly IDeveloperManager _developerManager;

        public TicketsController(ITicketManager ticketManager, 
            IDepartmentManager departmentManager, 
            IDeveloperManager developerManager)
        {
            _ticketManager = ticketManager;
            _departmentManager = departmentManager;
            _developerManager = developerManager;
        }
        public void getData()
        {
            var departments = _departmentManager.GetDepartments();
            ViewData[Constants.Departments] = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString())).ToList();
            var developers = _developerManager.GetDevelopers();
            ViewData[Constants.Developers] = developers.Select(d => new SelectListItem($"{d.FirstName} {d.LastName}", 
                d.Id.ToString())).ToList();
        }

        public IActionResult Index()
        {
            IEnumerable<TicketReadVM> ticketsVM = _ticketManager.ticketsReadVM(); 
            return View(ticketsVM);
        }
        [HttpGet]
        public IActionResult Add()
        {
            getData();
            return View();
        }

        [HttpPost] 
        public IActionResult Add(TicketAddVM ticketVM)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Add));
            _ticketManager.AddVM(ticketVM);
            TempData[Constants.Operation] = Constants.Add;
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(Guid Id)
        {
            var ticket=_ticketManager.TicketDetails(Id);
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Delete(Guid Id)
        {
            _ticketManager.Delete(Id);
            TempData[Constants.Operation] = Constants.Delete;
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            getData();
            var ticketToEdit = _ticketManager.Edit(Id);
            return View(ticketToEdit);
        }
        [HttpPost]
        public IActionResult Edit(TicketEditVM ticketVM)
        {
            if(!ModelState.IsValid)
                return RedirectToAction(nameof(Edit));
            _ticketManager.EditUsingVM(ticketVM);
            TempData[Constants.Operation] = Constants.Edit;
            return RedirectToAction(nameof(Index));
        }
    }
}
