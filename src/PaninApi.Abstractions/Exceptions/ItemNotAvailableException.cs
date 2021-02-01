using PaninApi.Abstractions.Models;

namespace PaninApi.Abstractions.Exceptions
{
    public class ItemNotAvailableException : BaseProblemDetailsException
    {
        public ItemNotAvailableException(Item item, int quantity) : base(
            "Item not available.",
            $"The item '{item.Name}' with id '{item.Id}' is not available with the requested quantity ({quantity.ToString()}).",
            System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}