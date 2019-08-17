namespace WebApplication5.Models
{
    using System.Data.Entity;

    #region "DepartmentNewDataModel Partial Class"
    public partial class DepartmentNewDataModel : DbContext
    {
        public DepartmentNewDataModel()
            : base("name=DepartmentNewDataModel")
        {

        }
        public virtual DbSet<DepartmentNewTable> DepartmentNewTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentNewTable>()
                .Property(e => e.Dept_Name)
                .IsUnicode(false);

            modelBuilder.Entity<DepartmentNewTable>()
                .Property(e => e.Dept_Details)
                .IsUnicode(false);
        }
    }
    #endregion
}
