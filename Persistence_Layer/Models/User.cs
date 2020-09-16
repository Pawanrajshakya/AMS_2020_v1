using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class User : Audit
    {
        public User()
        {
            UserRole = new List<UserRole>();
        }
        [StringLength(100)]
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
        public int PasswordChangedCount { get; set; }
        public System.DateTime LastPasswordChangedOn { get; set; }

    }
}