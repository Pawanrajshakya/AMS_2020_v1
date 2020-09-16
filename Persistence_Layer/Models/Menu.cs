using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class Menu : Audit
    {
        [StringLength(100)]
        [Required]
        public string Title { get; set; }
        public string Link { get; set; }
        [StringLength(100)]
        public string IconName { get; set; }
        public int MainMenuId { get; set; }
        public int SortId { get; set; }
        [StringLength(50)]
        public string UserRoles { get; set; }
    }
}