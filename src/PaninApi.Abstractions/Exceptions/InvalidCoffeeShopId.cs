using System.Net;

namespace PaninApi.Abstractions.Exceptions
{
    public class InvalidCoffeeShopIdException : BaseProblemDetailsException
    {
        public InvalidCoffeeShopIdException(int id) : base(
            "Invalid coffee shop id.",
            $"Requested coffee shop with id #{id.ToString()} but it is invalid.",
            System.Net.HttpStatusCode.BadRequest)
        {
        }
    }
}