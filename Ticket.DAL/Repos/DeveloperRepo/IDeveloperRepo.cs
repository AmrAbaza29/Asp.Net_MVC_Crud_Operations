using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Models;

namespace Tickets.DAL.Repos;

public interface IDeveloperRepo : IGenericRepo<Developer>
{
      IEnumerable<Developer> GetDevelopersForTicket(Guid Id);
}

