using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3_CASE_API.Entities
{
    public class Users
    {
        [ForeignKey("Contact_InformaitionID")]
        public int Contact_InformaitionID { get; set; }

        [Key]
        public string UserName { get; set; }

        public string Password { get; set; }
        public string PasswordHash { get; set; }

    }
}
