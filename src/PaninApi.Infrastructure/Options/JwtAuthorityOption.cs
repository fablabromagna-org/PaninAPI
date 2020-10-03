namespace PaninApi.Infrastructure.Options
{
    public class JwtAuthorityOption
    {
        public string Authority { get; set; }
        
        public string Audience { get; set; }
        
        public string Issuer { get; set; }
    }
}