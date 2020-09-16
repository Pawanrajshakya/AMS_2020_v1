using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class Role: Audit
    {
        public Role()
        {
            UserRole = new List<UserRole>();
        }

        [StringLength(50)]
        public string Description { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}