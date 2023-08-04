namespace WebApi.TokenOperations.Models;
public class Token
{
    public string AccsessToken { get; set; }
    public DateTime Expiration { get; set; }
    public string RefreshToken { get; set; }
}