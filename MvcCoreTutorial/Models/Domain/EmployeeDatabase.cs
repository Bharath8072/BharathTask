using Microsoft.EntityFrameworkCore;

namespace MvcCoreTutorial.Models.Domain
{
    public class EmployeeDatabase:DbContext
    {
        public EmployeeDatabase(DbContextOptions<EmployeeDatabase>opts):base(opts)
        {
                
        }
        public DbSet<Employee>employee { get; set; }
    }
}
