using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3_CASE_API.Models
{
    public class Addrese
    {
        [Key]
        public int AddreseID { get; set; }
        [ForeignKey("Contact_Informaition"), Column(Order = 1)]
        public int Contact_InformaitionID { get; set; }
        public Contact_Informaition Contact_Informaition { get; set; }

        public int PostalCode { get; set; }
        [ForeignKey("PostalCode")]
        public PostalCodes? PostalCodes { get; set; }
        public string? Addrese_Name { get; set; }

        public Addrese(){}
        public Addrese(InputDataModels.Post_Addrese _Input, int Contact_ID) {
            this.Contact_InformaitionID = Contact_ID;
            this.PostalCode = _Input.PostalCode;
            this.Addrese_Name = _Input.Addrese_Name;
        }

    }
}
