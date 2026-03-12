using System;
using System.Collections.Generic;
using System.Text;

namespace Carapp_Menu
{
    public class Trip
    {
        private Car _car;
        private double _distance;
        private DateTime _startTime;
        private DateTime _endTime;

        public Car Car
        {
            get { return _car; }
        }

        public double Distance
        {
            get { return _distance; }
        }
        public DateTime StartTime
        {
            get { return _startTime; } 
        }
        public DateTime EndTime
        {
            get { return _endTime; } 
        }
        public DateTime TripDate
        {
            get { return _startTime.Date; }
        }
        //Constructor
        public Trip(Car car, double distance, DateTime startTime, DateTime endTime)
        {
            _car = car;
            _distance = distance;
            _startTime = startTime;
            _endTime = endTime;
        }

        public TimeSpan CalculateDuration()
        {
            return _endTime - _startTime;
        }
        
        public double CalculateFuelUsed()
        {
            return _distance / _car.KmPerLiter;
        }

        public double CalculateTripPrice(double literPrice)
        {
            return CalculateFuelUsed() * literPrice;
        }
        public string GetTripDetails(double literPrice)
        {
            return $"Turen tager: {CalculateDuration()}\n" +
                   $"Der er blevet brugt: {CalculateFuelUsed():0.00} liter\n" +
                   $"Hele turen kostede: {CalculateTripPrice(literPrice):0.00} kr";
        }
    }
}
