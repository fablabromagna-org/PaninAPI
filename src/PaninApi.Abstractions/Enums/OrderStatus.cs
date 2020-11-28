namespace PaninApi.Abstractions.Enums
{
    public enum OrderStatus
    {
        Creating,
        Payed,
        Accepted,
        Ready,
        Rejected,
        Expired // Not in the database (only at runtime when we receive a request)
    }
}