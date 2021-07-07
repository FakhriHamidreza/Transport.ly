namespace Transport.ly.Models
{
    using System.Collections.Generic;

    public class City : BaseModel
    {
        public string Name { get; set; }

        public virtual IEnumerable<Airport> AirPorts { get; set; }

        public override string ToString()
            => $"{System.Environment.NewLine} City: {base.ToString()} - Name: {this.Name}";
    }
}