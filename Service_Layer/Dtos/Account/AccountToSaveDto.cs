using Service_Layer.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos
{
    public class AccountToSaveDto
    {
        public string AccountNo { get; set; }
        
        [
            Required(ErrorMessage = "Client is required."),
            NotZeroOrNullValidator(ErrorMessage = "Invalid Client.")
            ]
        public int ClientId { get; set; }
        public decimal Balance { get; private set; }
        
        [
            Required(ErrorMessage = "Account Type is required."),
            NotZeroOrNullValidator(ErrorMessage = "Invalid Account Type.")
        ]
        public int AccountTypeId { get; set; }
        public bool IsMain { get; set; } //One client can have multiple account

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public int RelationshipId { get; set; } //Relationship with main account
        public int SortId { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return LastName + " " + FirstName;
        }
    }
}