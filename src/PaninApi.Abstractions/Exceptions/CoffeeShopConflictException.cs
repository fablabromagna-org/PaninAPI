using PaninApi.Abstractions.Models;

namespace PaninApi.Abstractions.Exceptions
{
    public class CoffeeShopConflictException : BaseProblemDetailsException
    {
        public CoffeeShopConflictException(CoffeeShop coffeeShop, Item item) : base(
            "Coffee shop conflict.",
            $"Invalid item '{item.Id.ToString()}' with coffee shop '{item.CoffeeShopId.ToString()}' for order at coffee shop '{coffeeShop.Id}'.",
            System.Net.HttpStatusCode.Conflict)
        {
        }
    }
}