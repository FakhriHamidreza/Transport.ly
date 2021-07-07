namespace Transport.ly.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Transport.ly.Models;

    public static class DataTools
    {
        public static IEnumerable<City> GetCities()
        {
            yield return new City { InstanceId = new Guid("de224be8-e155-425f-9003-21b41a56715f"), Name = "Montreal" };
            yield return new City { InstanceId = new Guid("ae2b77cc-ddd8-4bb8-9c58-44a2de18d64d"), Name = "Toronto" };
            yield return new City { InstanceId = new Guid("b2e885bf-c6b9-4fe5-9450-9492cc690475"), Name = "Calgery" };
            yield return new City { InstanceId = new Guid("3a386c33-dea8-4447-b695-662b9810e2a8"), Name = "Vancouver" };
            yield return new City { InstanceId = new Guid("842ffb6f-d1f3-4a4a-b4c7-10ead3724a54"), Name = "Edmonton" };
        }

        public static IEnumerable<Airport> GetAirports()
        {
            var Cities = GetCities();

            var Montreal = Cities.Where(city => city.Name.Equals("Montreal")).FirstOrDefault();
            var Toronto = Cities.Where(city => city.Name.Equals("Toronto")).FirstOrDefault();
            var Calgery = Cities.Where(city => city.Name.Equals("Calgery")).FirstOrDefault();
            var Vancouver = Cities.Where(city => city.Name.Equals("Vancouver")).FirstOrDefault();
            var Edmonton = Cities.Where(city => city.Name.Equals("Edmonton")).FirstOrDefault();

            yield return new Airport { InstanceId = new Guid("1c0c987f-6a52-4f81-be80-2ef6ff24543d"), Name = $"{Montreal.Name} Airport", IATA = "YUL", City = Montreal, CityId = Montreal.InstanceId };
            yield return new Airport { InstanceId = new Guid("52a7da96-a008-46e0-9186-76e84e3d45a0"), Name = $"{Toronto.Name} Airport", IATA = "YYZ", City = Toronto, CityId = Toronto.InstanceId };
            yield return new Airport { InstanceId = new Guid("daddacde-26ef-4d97-a33a-e78057ec833b"), Name = $"{Calgery.Name} Airport", IATA = "YYC", City = Calgery, CityId = Calgery.InstanceId };
            yield return new Airport { InstanceId = new Guid("da9f140c-2c78-42fa-8934-fd62c27de918"), Name = $"{Vancouver.Name} Airport", IATA = "YVR", City = Vancouver, CityId = Vancouver.InstanceId };
            yield return new Airport { InstanceId = new Guid("8e151655-4f14-40cc-9b48-6773bc29a02d"), Name = $"{Edmonton.Name} Airport", IATA = "YYE", City = Edmonton, CityId = Edmonton.InstanceId };
        }

        public static IEnumerable<Plane> GetPlanes()
        {
            yield return new Plane { InstanceId = new Guid("0054eb7e-b0fa-48e0-8e48-6244ea9e1337"), Name = "Antonov An-225 Mriya", Model = "123" };
            yield return new Plane { InstanceId = new Guid("46a1097d-f72d-45c4-aa43-475e7ffdcfdd"), Name = "Antonov An-226 Mriya", Model = "456" };
            yield return new Plane { InstanceId = new Guid("defba963-8d18-47bf-a0d0-14c2b878cd5a"), Name = "Antonov An-227 Mriya", Model = "789" };
        }

        public static Airport GetAirport(string name)
        {
            foreach (var airport in GetAirports())
            {
                if (string.Equals(airport.IATA.ToUpper(), name.ToUpper()))
                {
                    return airport;
                }
            }

            throw new Exception("Airport NOT found!");
        }

        public static T GetJsonFromFile<T>(string filename)
        {
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public static IEnumerable<FlightItinenary> GetFlightItinenary()
        {
            #region GetAirports
            var Airports = GetAirports();
            var YUL = Airports.Where(airport => airport.IATA.Equals("YUL")).FirstOrDefault();
            var YYC = Airports.Where(airport => airport.IATA.Equals("YYC")).FirstOrDefault();
            var YYZ = Airports.Where(airport => airport.IATA.Equals("YYZ")).FirstOrDefault();
            var YVR = Airports.Where(airport => airport.IATA.Equals("YVR")).FirstOrDefault();
            var YYE = Airports.Where(airport => airport.IATA.Equals("YYE")).FirstOrDefault();
            #endregion

            var Plane1 = GetPlanes().FirstOrDefault(p => p.Model == "123");
            var Plane2 = GetPlanes().FirstOrDefault(p => p.Model == "456");
            var Plane3 = GetPlanes().FirstOrDefault(p => p.Model == "789");

            yield return new FlightItinenary { InstanceId = new Guid("5688199b-2411-41c6-8241-4646f11659c7"), ArrivalId = YUL.InstanceId, Arrival = YUL, DepartureId = YYC.InstanceId, Departure = YYC, Plane = Plane1, PlaneId = Plane1.InstanceId, FlightNumber = "Flight-001" };
            yield return new FlightItinenary { InstanceId = new Guid("c793b3de-48d3-4b7f-8676-54880b324730"), ArrivalId = YUL.InstanceId, Arrival = YUL, DepartureId = YYZ.InstanceId, Departure = YYZ, Plane = Plane2, PlaneId = Plane2.InstanceId, FlightNumber = "Flight-002" };
            yield return new FlightItinenary { InstanceId = new Guid("363114d1-e364-4c93-b195-dd91aad51432"), ArrivalId = YUL.InstanceId, Arrival = YUL, DepartureId = YVR.InstanceId, Departure = YVR, Plane = Plane3, PlaneId = Plane3.InstanceId, FlightNumber = "Flight-003" };
            yield return new FlightItinenary { InstanceId = new Guid("8d728273-484c-48d6-b426-834a4bd9a83e"), ArrivalId = YUL.InstanceId, Arrival = YUL, DepartureId = YYE.InstanceId, Departure = YYE };

            yield return new FlightItinenary { InstanceId = new Guid("7eef4799-9042-4d14-909e-bcb8b13e1f87"), ArrivalId = YYC.InstanceId, Arrival = YYC, DepartureId = YUL.InstanceId, Departure = YUL, Plane = Plane1, PlaneId = Plane1.InstanceId, FlightNumber = "Flight-011" };
            yield return new FlightItinenary { InstanceId = new Guid("9b962e45-868d-4ee8-85bf-c84e35833100"), ArrivalId = YYZ.InstanceId, Arrival = YYZ, DepartureId = YUL.InstanceId, Departure = YUL, Plane = Plane2, PlaneId = Plane2.InstanceId, FlightNumber = "Flight-012" };
            yield return new FlightItinenary { InstanceId = new Guid("000e0d93-e5fa-4925-9a46-649571e0e920"), ArrivalId = YVR.InstanceId, Arrival = YVR, DepartureId = YUL.InstanceId, Departure = YUL, Plane = Plane3, PlaneId = Plane3.InstanceId, FlightNumber = "Flight-013" };
            yield return new FlightItinenary { InstanceId = new Guid("89f72036-de16-43fd-b166-6b368034b916"), ArrivalId = YYE.InstanceId, Arrival = YYE, DepartureId = YUL.InstanceId, Departure = YUL };
        }

        public static IEnumerable<Order> GetOrders()
        {
            var JsonOrders = GetJsonFromFile<Dictionary<string, Dictionary<string, string>>>("Infrastructure/Orders.json");

            foreach (var JsonOrder in JsonOrders)
            {
                var departure = GetAirport("YUL");
                var arrival = GetAirport(JsonOrder.Value.FirstOrDefault().Value);

                var itinenary = GetFlightItinenary()
                                    .Where(i => i.DepartureId == departure.InstanceId && i.ArrivalId == arrival.InstanceId)
                                    .FirstOrDefault();

                yield return new Order
                {
                    InstanceId = Guid.NewGuid(),
                    OrderNumber = JsonOrder.Key,
                    DepartureId = departure.InstanceId,
                    Departure = departure,
                    ArrivalId = arrival.InstanceId,
                    Arrival = arrival,
                };
            }
        }
    }
}