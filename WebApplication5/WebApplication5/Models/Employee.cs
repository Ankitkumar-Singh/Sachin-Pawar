using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    #region "Employee Class Contains Fiels of Employee Table"
    /// <summary>
    /// Employee Class Contains Fiels of Employee Table
    /// </summary>
    [Table("Employee")]
    public class Employee
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public DateTime? DOB { get; set; }
    }
    #endregion
}