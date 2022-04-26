namespace H3_CASE_API.Entities.Dto
{
    public class CustomerDto
    {
        public int CustomerID { get; set; }
        public string? Full_Name { get; set; }
        public string? Phone_Number { get; set; }
        public string? Mobile_Number { get; set; }
        public string? Email { get; set; }
        public string? ContactType { get; set; }
        public virtual ICollection<AddreseDto>? addreses { get; set; }
        public virtual IEnumerable<Link>? Links { get; set; }

    }
}
