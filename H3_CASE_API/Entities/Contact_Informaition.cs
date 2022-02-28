using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3_CASE_API.Models
{
    public class Contact_Informaition
    {
        [Key]
        public int Contact_InformaitionID { get; set; }

        public int Contact_TypeID { get; set; }
        [ForeignKey("Contact_TypeID")]
        public Contact_Type? Contact_Type { get; set; }

        [ForeignKey("Contact_InformaitionID")]
        public virtual ICollection<Addrese>? Addrese { get; set; }

        public string? Email { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Phone_Number { get; set; }
        public string? Mobile_Number { get; set; }

        public Contact_Informaition(InputDataModels.PostCustomer _Input)
        {
            this.Contact_TypeID = _Input.ContactTypeID;
            this.Email = _Input.Email;
            this.First_Name = _Input.First_Name;
            this.Last_Name = _Input.Last_Name;
            this.Phone_Number = _Input.Phone_Number;
            this. Mobile_Number = _Input.Mobile_Number;
        }
        public Contact_Informaition(){ }
    }
}
