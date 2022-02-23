using H3_CASE_API.Models;

namespace H3_CASE_API.Dto
{
    public class HATEOAS
    {
        public string? Href { get; set; }
        public string? Rel { get; set; }
        public string? Method { get; set; }
    }
}
