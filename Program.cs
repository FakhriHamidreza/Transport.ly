using System;
using System.Collections.Generic;
using System.Linq;
using Transport.ly.Infrastructure;
using Transport.ly.Models;

namespace Transport.ly
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Story1
            var FlightScheduleList = new List<FlightSchedule>();
            //Schedule for Day1
            FlightScheduleList.AddRange(FlightSchedule.SetFlightSchedules(DateTime.Now));
            //Schedule for Day2
            FlightScheduleList.AddRange(FlightSchedule.SetFlightSchedules(DateTime.Now.AddDays(1)));
            //FlightScheduleList.Write();

            #endregion

            #region Story2
            FlightSchedule.LoadScheduleOrders(FlightScheduleList, DateTime.Now);
            #endregion

            Console.ReadKey();
        }
    }
}
