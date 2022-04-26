using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using H3_CASE_API.Entities;

namespace H3_CASE_API.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        public int Contact_InformaitionID { get; set; }
        [ForeignKey("Contact_InformaitionID")]
        public Contact_Informaition? Contact_Informaition { get; set; }

        public Customer(InputDataModels.PostCustomer _input){
            Contact_Informaition = new Contact_Informaition(_input);
        }
        public Customer() { }
    }
}
