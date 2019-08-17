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

        public System.Data.Entity.DbSet<WebApplication5.Models.Comment> Comments { get; set; }
    }
    #endregion
}