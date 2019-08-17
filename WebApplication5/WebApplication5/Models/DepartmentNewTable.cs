namespace WebApplication5.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    #region "DepartmentNewTable Class"
    [Table("DepartmentNewTable")]
    public partial class DepartmentNewTable
    {

        /// <summary>
        /// DepartmentNewTable Fields
        /// </summary>
        [Key]
        [Column(Order = 0)]
        public int Dept_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Dept_Name { get; set; }

        [StringLength(200)]
        public string Dept_Details { get; set; }

        public int? TotalEmployee { get; set; }

        [StringLength(100)]
        public string Location { get; set; }
    }
    #endregion
}
