namespace WebApplication5.Models
{
    using System.ComponentModel.DataAnnotations;
    #region "Comment Class"
    public partial class Comment
    {
        /// <summary>
        /// Comment table fields
        /// </summary>
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Comments { get; set; }
    }
    #endregion
}
