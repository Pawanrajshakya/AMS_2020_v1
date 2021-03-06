using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence_Layer.Models
{
    public class AccountType: Audit
    {

        [StringLength(100)]
        public string Description { get; set; }
        public int SortId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        public int GroupId { get; set; }

        [StringLength(40)]
        public string ShortName { get; set; }
    }
}