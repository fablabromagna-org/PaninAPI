using PaninApi.Abstractions.Models;

namespace PaninApi.Abstractions.Exceptions
{
    public class InvalidCoffeeShopForUserException : BaseProblemDetailsException
    {
        public InvalidCoffeeShopForUserException(BaseUser user, CoffeeShop coffeeShop) : base(
            "Invalid coffee shop.",
            $"Invalid coffee shop '{coffeeShop.Id.ToString()}' for user '{user.Id}'",
            System.Net.HttpStatusCode.Forbidden)
        {
        }
    }
}