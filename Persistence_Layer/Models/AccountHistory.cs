using System;
using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class AccountHistory
    {
        public int Id { get; set; }
        public string AccountNo { get; set; }
        public Client Client { get; set; }
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

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public bool IsVisible { get; set; }

        public bool IsActive { get; set; }

        public byte[] RowVersion { get; set; }

        public DateTime DateAdded { get; set; }
    }
}