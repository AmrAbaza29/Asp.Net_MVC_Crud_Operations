using Microsoft.AspNetCore.Mvc;
using Tickets.BL;
using Tickets.BL.ViewModels;
using Tickets.mvc;

namespace Tickets.mvc.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ITicketManager _ticketManager;
        private readonly IDepartmentManager _departmentManager;
        private readonly IDeveloperManager _developerManager;

        public DepartmentsController(ITicketManager ticketManager,
            IDepartmentManager departmentManager,
            IDeveloperManager developerManager)
        {
            _ticketManager = ticketManager;
            _departmentManager = departmentManager;
            _developerManager = developerManager;
        }
        public IActionResult Index()
        {
            IEnumerable<DepartmentReadVM> departmentsReadVM = _departmentManager.GetDepartments();
            return View(departmentsReadVM);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(DepartmentAddVM DepartmentToAdd)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Add));
            _departmentManager.AddVM(DepartmentToAdd);
            TempData[Constants.Operation] = Constants.Add;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(Guid Id)
        {
            _departmentManager.Delete(Id);
            TempData[Constants.Operation] = Constants.Delete;
            return RedirectToAction(nameof(Index));
        }

        [HttpGet] 
        public IActionResult Details(Guid Id)
        {
            ViewData["url"] = "/Department";
            return View(_departmentManager.DepartmentDetails(Id));
        }
    }
}
