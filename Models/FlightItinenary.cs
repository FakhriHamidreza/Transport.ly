namespace Transport.ly.Models
{
    using System;
    using System.Collections.Generic;

    public class FlightItinenary : BaseModel
    {
        public FlightItinenary()
        {
            this.Orders = new List<Order>();
            this.FlightSchedules = new List<FlightSchedule>();
        }

        public string FlightNumber { get; set; }

        public Guid? PlaneId { get; set; }

        public virtual Plane Plane { get; set; }

        public Guid DepartureId { get; set; }

        public virtual Airport Departure { get; set; }

        public Guid ArrivalId { get; set; }

        public virtual Airport Arrival { get; set; }

        public virtual IEnumerable<FlightSchedule> FlightSchedules { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }

        public override string ToString()
            => $"Itinenary: {System.Environment.NewLine} {base.ToString()} - Departure: {this.Departure.ToString()}  - Arrival: {this.Arrival.ToString()}";
    }
}