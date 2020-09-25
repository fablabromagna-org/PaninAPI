namespace PaninApi.Core.Models
{
    public abstract class BaseUser
    {
        public string Id { get; set; }

        public string GivenName { get; set; }

        public string FamilyName { get; set; }
        
        public string Email { get; set; }
    }
}