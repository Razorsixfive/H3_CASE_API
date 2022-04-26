namespace H3_CASE_API.Model;
public record User
{
    public int Contact_InformaitionID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string PasswordHash { get; set; }
}
