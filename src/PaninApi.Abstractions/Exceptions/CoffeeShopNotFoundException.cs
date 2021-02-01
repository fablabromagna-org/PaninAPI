using System.Net;

namespace PaninApi.Abstractions.Exceptions
{
    public class CoffeeShopNotFoundException : BaseProblemDetailsException
    {
        public CoffeeShopNotFoundException(int id) : base(
            "Coffee shop not found.",
            $"The requested coffee shop with id #{id.ToString()} but it does not exists.",
            System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}