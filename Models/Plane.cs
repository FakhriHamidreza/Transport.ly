namespace Transport.ly.Models
{
    using System.Collections.Generic;

    public class Plane : BaseModel
    {
        public string Name { get; set; }

        public string Model { get; set; }

        public byte Capacity { get; set; } = 20;

        public virtual IEnumerable<FlightSchedule> Flights { get; set; }

        public override string ToString()
            => $"Plane: {System.Environment.NewLine} {base.ToString()} - Name: {this.Name}  - Model: {this.Model} - Capacity: {this.Capacity}";
    }
}