namespace H3_CASE_API.Entities.Dto
{
    public class OrderLineDto
    {
        public Guid OrderLineID { get; set; }

        public int ProductID { get; set; }
        public int Ammount { get; set; }
        public double Price { get; set; }

    }
}
