using H3_CASE_API.Entities;

namespace H3_CASE_API.Entities.Dto
{
    public class DepartmentDto
    {
        public int DepartmentID { get; set; }
        public string? Name { get; set; }
        public string? Addrese { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public int PostalCode { get; set; }

        public List<Employee>? Employees { get; set; }
        public List<WarehousesDto>? Warehouses { get; set; }
    }
}
