using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL;
using Tickets.DAL.Repos;

namespace Tickets.BL;

public class DeveloperManager : IDeveloperManager
{
    private readonly IDeveloperRepo _developerRepo;

    public DeveloperManager(IDeveloperRepo developerRepo)
    {
        _developerRepo = developerRepo;
    }
    public IEnumerable<TicketChildVM> GetDevelopers()
    {
        IEnumerable<Developer> DevelopersFromDB = _developerRepo.GetAll();
        return DevelopersFromDB.Select(d => new TicketChildVM
        {
            Id = d.Id,
            FirstName = d.FirstName,
            LastName = d.LastName,
        });
    }
}
