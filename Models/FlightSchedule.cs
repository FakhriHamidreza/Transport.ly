namespace Transport.ly.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Transport.ly.Infrastructure;

    public class FlightSchedule : FlightItinenary
    {
        public DateTime DepartureTime { get; set; }

        public DateTime? ArrivalTime { get; set; }

        public FlightStatus FlightStatus { get; set; } = FlightStatus.OnTime;

        public bool FlightDirection { get; set; } = false;

        public System.Guid FlightItinenaryId { get; set; }

        public static IEnumerable<FlightSchedule> SetFlightSchedules(DateTime scheduleDate)
        {
            var Schedule = GetScheduleTimes(scheduleDate);

            foreach (var item in Infrastructure.DataTools.GetFlightItinenary().Where(i => !(i.Plane is null)))
            {
                if (item.Departure.IATA.ToUpper() == "YUL")
                {
                    yield return new FlightSchedule
                    {
                        InstanceId = Guid.NewGuid(),
                        DepartureTime = Schedule.Departure,
                        ArrivalTime = Schedule.Departure.AddHours(2),
                        FlightDirection = false,

                        FlightItinenaryId = item.InstanceId,

                        FlightNumber = item.FlightNumber,
                        PlaneId = item.PlaneId,
                        Plane = item.Plane,

                        ArrivalId = item.ArrivalId,
                        Arrival = item.Arrival,
                        DepartureId = item.DepartureId,
                        Departure = item.Departure,
                    };
                }
                else if (item.Arrival.IATA.ToUpper() == "YUL")
                {
                    yield return new FlightSchedule
                    {
                        InstanceId = Guid.NewGuid(),
                        DepartureTime = Schedule.Arrival,
                        ArrivalTime = Schedule.Arrival.AddHours(2),
                        FlightDirection = true,

                        FlightItinenaryId = item.InstanceId,

                        FlightNumber = item.FlightNumber,
                        PlaneId = item.PlaneId,
                        Plane = item.Plane,

                        ArrivalId = item.ArrivalId,
                        Arrival = item.Arrival,
                        DepartureId = item.DepartureId,
                        Departure = item.Departure,
                    };
                }
            }
        }

        public static void LoadScheduleOrders(List<FlightSchedule> schedules, DateTime scheduleDate)
        {
            var orders = DataTools.GetOrders().ToList();

            // orders.Write();

            foreach (var schedule in schedules?.Where(sc => !sc.FlightDirection && sc?.Departure?.IATA?.ToUpper() == "YUL"))
            {
                foreach (var order in orders
                                        .Where(o => o.OrderStatus != OrderStatus.Loaded &&
                                                        string.IsNullOrEmpty(o.FlightNumber?.Trim()) &&
                                                        o.ArrivalId == schedule.ArrivalId &&
                                                        o.DepartureId == schedule.DepartureId)
                                        .Take(20))
                {
                    order.OrderStatus = OrderStatus.Loaded;
                    order.FlightNumber = schedule.FlightNumber;
                    order.FlightItinenaryId = schedule.FlightItinenaryId;
                    order.PlaneId = schedule.PlaneId;
                    order.Plane = schedule.Plane;
                    order.Arrival = schedule.Arrival;
                    order.ArrivalId = schedule.ArrivalId;
                    order.Departure = schedule.Departure;
                    order.DepartureId = schedule.DepartureId;

                    (schedule.Orders as List<Order>).Add(order);
                    (order.FlightSchedules as List<FlightSchedule>).Add(schedule);
                }
            }

            orders.Write();
        }

        public static (DateTime Departure, DateTime Arrival) GetScheduleTimes(DateTime scheduledate)
        {
            var date = scheduledate.AddDays(1);

            var ts = new TimeSpan(12, 00, 0);
            var departure = date.Date + ts;

            ts = new TimeSpan(24, 00, 0);
            var arrival = date.Date + ts;

            return (departure, arrival);
        }

        public override string ToString()
            => $@"FlightNumber: {this?.FlightNumber} - Departure: {this?.Departure?.IATA} - Arrival: {this?.Arrival?.IATA} - DepartureTime: {this?.DepartureTime} - Plane: {this?.Plane?.Name}";
    }
}