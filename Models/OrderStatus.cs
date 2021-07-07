namespace Transport.ly.Models
{
    public enum OrderStatus : byte
    {
        Approved = 1,
        Loaded,
        Delivered,
        Unloaded,
    }
}