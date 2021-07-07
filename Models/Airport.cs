namespace Transport.ly.Models
{
    using System;
    using System.Collections.Generic;

    public class Airport : BaseModel
    {
        public string Name { get; set; }

        public string IATA { get; set; }

        public System.Guid CityId { get; set; }

        public virtual City City { get; set; }

        public virtual IEnumerable<FlightSchedule> DepartureFlights { get; set; }

        public virtual IEnumerable<FlightSchedule> ArrivalFlights { get; set; }

        public override string ToString()
            => $@"Airport: {Environment.NewLine} {base.ToString()} Name: {this.Name} - IATA: {this.IATA} {this.City.ToString()}";
    }
}