using System.Data.Entity;

namespace WebApplication5.Models
{
    #region "DepartmentContext Class"
    /// <summary>
    /// DepartmentContext class established connection with department table
    /// </summary>
    public class DepartmentContext : DbContext
    {
        public DbSet<Department> Departments { get; set;}
    }
    #endregion

}