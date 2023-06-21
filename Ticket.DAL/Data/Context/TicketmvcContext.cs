using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tickets.DAL.Data.Models;
using Tickets.DAL;
using System.Reflection.Emit;

namespace Tickets.mvc.Data;

public class TicketmvcContext : IdentityDbContext<IdentityUser>
{
    public TicketmvcContext(DbContextOptions<TicketmvcContext> options)
        : base(options)
    {
    }
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<Developer> Developers => Set<Developer>();
    public DbSet<TicketDevelopers> TicketDevelopers => Set<TicketDevelopers>();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<TicketDevelopers>().HasKey(k => new { k.TicketId, k.DeveloperId });

        var departments = new List<Department>
        {
            new() {Id=Guid.NewGuid(), Name="Back-End"},
            new() {Id=Guid.NewGuid(), Name="Front-End"},
            new() {Id=Guid.NewGuid(), Name="Full-Stack"},
            new() {Id=Guid.NewGuid(), Name="Android"},
            new() {Id=Guid.NewGuid(), Name="Flutter"}
        };
        var tickets = new List<Ticket>
        {
            new()
            {
                Id=Guid.NewGuid(),
                CreatedDate=new DateTime(2023, 6, 10),
                Description="Ticket 123456",
                IsClosed=false,
                Priority=Severity.high,
                DepartmentId=departments[0].Id
            },
            new()
            {
                Id=Guid.NewGuid(),
                CreatedDate=new DateTime(2023, 6, 4),
                Description="Ticket 123456",
                IsClosed=false,
                Priority=Severity.medium,
                DepartmentId=departments[4].Id
            },
            new()
            {
                Id=Guid.NewGuid(),
                CreatedDate=new DateTime(2023, 6, 7),
                Description="Ticket 123456",
                IsClosed=false,
                Priority=Severity.low,
                DepartmentId=departments[1].Id
            },
            new()
            {
                Id=Guid.NewGuid(),
                CreatedDate=new DateTime(2023, 6, 9),
                Description="Ticket 123456",
                IsClosed=false,
                Priority=Severity.high,
                DepartmentId=departments[2].Id
            },
            new()
            {
                Id=Guid.NewGuid(),
                CreatedDate=new DateTime(2023, 5, 30),
                Description="Ticket 123456",
                IsClosed=false,
                Priority=Severity.low,
                DepartmentId=departments[3].Id
            }
        };
        var developers = new List<Developer>
        {
            new(){Id=Guid.NewGuid(), FirstName="Ahmed", LastName="Elsayed"},
            new(){Id=Guid.NewGuid(), FirstName="Mohamed", LastName="Ashraf"},
            new(){Id=Guid.NewGuid(), FirstName="Eslam", LastName="Emad"},
            new(){Id=Guid.NewGuid(), FirstName="Mostafa", LastName="Saad"},
            new(){Id=Guid.NewGuid(), FirstName="Fawaz", LastName="Mahmoud"}
        };
        var ticketDevelopers = new List<TicketDevelopers>
        {
            new() { TicketId = tickets[0].Id, DeveloperId = developers[1].Id },
            new() { TicketId = tickets[0].Id, DeveloperId = developers[2].Id },
            new() { TicketId = tickets[1].Id, DeveloperId = developers[1].Id },
            new() { TicketId = tickets[1].Id, DeveloperId = developers[4].Id },
            new() { TicketId = tickets[2].Id, DeveloperId = developers[3].Id },
            new() { TicketId = tickets[2].Id, DeveloperId = developers[0].Id },
            new() { TicketId = tickets[3].Id, DeveloperId = developers[2].Id },
            new() { TicketId = tickets[3].Id, DeveloperId = developers[4].Id },
            new() { TicketId = tickets[4].Id, DeveloperId = developers[0].Id },
            new() { TicketId = tickets[4].Id, DeveloperId = developers[3].Id },
        };

        builder.Entity<Department>().HasData(departments);
        builder.Entity<Ticket>().HasData(tickets);
        builder.Entity<Developer>().HasData(developers);
        builder.Entity<TicketDevelopers>().HasData(ticketDevelopers);

    }
   
}
