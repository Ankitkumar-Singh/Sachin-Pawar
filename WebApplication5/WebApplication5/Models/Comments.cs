namespace WebApplication5.Models
{
    using System.Data.Entity;
    #region "Partial Class Comments"    
    /// <summary>
    /// Partial Class Comments
    /// </summary>
    public partial class Comments : DbContext
    {
        public Comments()
            : base("name=Comments")
        {
        }

        public virtual DbSet<Comment> Commentsc { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
    #endregion
}
