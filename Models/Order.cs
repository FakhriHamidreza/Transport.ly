using System;
using System.Linq;
using Transport.ly.Infrastructure;

namespace Transport.ly.Models
{
    public class Order : FlightItinenary
    {
        public string OrderNumber { get; set; }

        public OrderStatus OrderStatus { get; set; } = OrderStatus.Approved;

        public Guid? FlightItinenaryId { get; set; }

        public override string ToString()
        {
            var loadedStatus = string.Empty;

            if (this.OrderStatus == OrderStatus.Loaded)
            {
                loadedStatus += $" - FlightNumber: {this.FlightSchedules?.FirstOrDefault(fs => fs.FlightItinenaryId == this.FlightItinenaryId && this.FlightNumber == fs.FlightNumber)?.Plane.Name}";
                loadedStatus += $"FlightNumber: {this?.FlightNumber} - ";
                loadedStatus += $"DepartureTime: {this?.FlightSchedules?.FirstOrDefault(fs => fs.FlightItinenaryId == this.FlightItinenaryId && this.FlightNumber == fs.FlightNumber)?.DepartureTime}";
            }
            else
            {
                loadedStatus += $" - FlightNumber: Not Scheduled!";
            }

            return $"OrderNumber: {this?.OrderNumber} - OrderStatus: {this?.OrderStatus} - Departure: {this?.Departure?.IATA} - Arrival: {this?.Arrival?.IATA} {loadedStatus}";
        }
    }
}