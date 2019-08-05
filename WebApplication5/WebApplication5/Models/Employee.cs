using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    #region "Employee Class"
    /// <summary>
    /// Employee Class
    /// </summary>
    [Table("Employee")]
    public class Employee
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
    #endregion

}