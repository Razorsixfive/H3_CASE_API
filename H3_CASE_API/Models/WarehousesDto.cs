using H3_CASE_API.Models;

namespace H3_CASE_API.Dto
{
    public class WarehousesDto
    {
        public int WarehouseID { get; set; }
        public string? WarehouseName { get; set; }
        public string? Email { get; set; }
        public string? Phone_Number { get; set; }
        public string? Mobile_Number { get; set; }
        public int? DepartmentID { get; set; }
        public virtual ICollection<AddreseDto>? addreses { get; set; }
        public virtual ICollection<Product_StockDto>? Product_Stocks { get; set; }

    }
}
