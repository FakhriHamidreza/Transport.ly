namespace Transport.ly.Models
{
    public enum FlightStatus : byte
    {
        OnTime = 1,
        Started,
        Failed,
        Done,
        Suspended,
        Waiting
    }
}