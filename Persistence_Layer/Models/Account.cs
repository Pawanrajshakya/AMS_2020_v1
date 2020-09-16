using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence_Layer.Models
{
    public class Account : Audit
    {
        [StringLength(100)]
        [Column(Order = 2)]
        [Required]
        public string AccountNo { get; set; }

        public Client Client{ get; set; }
        [Required]
        public int ClientId { get; set; }

        [DataType(DataType.Currency)]
        public decimal Balance { get; private set; }

        public AccountType AccountType { get; set; }

        [Required]
        public int AccountTypeId { get; set; }


        #region Detail
        [MaxLength(100), Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [MaxLength(100), Required]
        public string LastName { get; set; }

        [MaxLength(12)]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Address1 { get; set; }

        [MaxLength(100)]
        public string Address2 { get; set; }

        [MaxLength(2)]
        public string State { get; set; }

        [MaxLength(5)]
        public string ZipCode { get; set; }

        public bool IsMain { get; set; } //One client can have multiple account

        public Relationship Relationship { get; set; }

        public int? RelationshipId { get; set; } //Relationship with main account
        #endregion

        public int SortId { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
    }
}