using H3_CASE_API.Models;

namespace H3_CASE_API.Models
{
    public class InputDataModels
    {
        public class PostCustomer
        {
            public string? Email { get; set; }
            public string? First_Name { get; set; }
            public string? Last_Name { get; set; }
            public string? Phone_Number { get; set; }
            public string? Mobile_Number { get; set; }

            public int ContactTypeID { get; set; }
            public List<Post_Addrese>? addreses { get; set; }
        }
        public class PutCustomer
        {
            public string? Email { get; set; }
            public string? First_Name { get; set; }
            public string? Last_Name { get; set; }
            public string? Phone_Number { get; set; }
            public string? Mobile_Number { get; set; }
            public int ContactTypeID { get; set; }
        }


        public class PostProduct
        {
            public int ProductID { get; set; }
            public int CategoryID { get; set; }
            public int ManufactorID { get; set; }

            public string? Product_Description { get; set; }
            public string? Product_Name { get; set; }
            public double In_Price { get; set; }
            public double Out_Price { get; set; }
        }

        public class Post_Addrese
        {
            public string? Addrese_Name { get; set; }
            public int PostalCode { get; set; }
        }


        public class PostPut_Warehouse
        {
            public int DepartmentID { get; set; }
            public int ContactTypeID { get; set; }

            public string? Email { get; set; }
            public string? First_Name { get; set; }
            public string? Last_Name { get; set; }
            public string? Phone_Number { get; set; }
            public string? Mobile_Number { get; set; }

            public IEnumerable<Post_Addrese>? Addreses { get; set; }
        }

        public class Post_Order
        {
            public string? Addrese_Name { get; set; }
            public int PostalCode { get; set; }
        }
    }
}
