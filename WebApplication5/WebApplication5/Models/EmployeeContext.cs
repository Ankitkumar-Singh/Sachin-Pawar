using System.Data.Entity;

namespace WebApplication5.Models
{
    #region "Context Class"
    /// <summary>
    /// Employee Context class extends DbContext
    /// </summary>
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
    #endregion
}