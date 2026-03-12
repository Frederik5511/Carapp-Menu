using Carapp_Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CarAppTests
{
    [TestClass]
    public sealed class CarTests
    {
        [TestMethod]
        public void GetTripsByDate_ReturnsMatchingTrips()
        {
            Car car = new Car("Toyota", "Corolla", 2020, 'A', FuelType.Benzin, 22.5);
            car.StartEngine();

            DateTime today = new DateTime(2024, 6, 1, 10, 0, 0);

            Trip trip1 = new Trip(car, 50, today, today.AddHours(1));
            Trip trip2 = new Trip(car, 30, today, today.AddMinutes(45));
            Trip trip3 = new Trip(car, 20, today.AddDays(1), today.AddDays(1).AddHours(1));

            car.Drive(trip1);
            car.Drive(trip2);
            car.Drive(trip3);

            // Act
            List<Trip> result = car.GetTripsByDate(today);

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetTripsByDate_ReturnsEmptyList_WhenNoTripsMatch()
        {
            Car car = new Car("Toyota", "Corolla", 2020, 'A', FuelType.Benzin, 22.5);
            car.StartEngine();

            DateTime today = new DateTime(2024, 6, 1, 10, 0, 0);
            DateTime otherDate = new DateTime(2026, 7, 1, 10, 0, 0);

            Trip trip1 = new Trip(car,50, today, today.AddHours(1));
            Trip trip2 = new Trip(car, 30, today, today.AddMinutes(45));

            car.Drive(trip1);
            car.Drive(trip2);

            List<Trip> result = car.GetTripsByDate(otherDate);

            Assert.AreEqual(0, result.Count);
        }
        [TestMethod]
        public void GetTripsInTimeInterval_IncludesTripsAtBoundaryValues()
        {
            Car car = new Car("Toyota", "Corolla", 2020, 'A', FuelType.Benzin, 22.5);
            car.StartEngine();

            DateTime start = new DateTime(2026, 2, 26, 12, 0, 0);
            DateTime end = new DateTime(2026, 2, 26, 16, 0, 0);

            Trip trip1 = new Trip(car, 50, start, start.AddHours(1));
            Trip trip2 = new Trip(car, 30, end, end.AddHours(1));
            Trip trip3 = new Trip(car, 20, new DateTime(2025, 1, 1, 12, 0, 0), new DateTime(2027, 1,1,13,0,0));

            car.Drive(trip1);
            car.Drive(trip2);
            car.Drive(trip3);

            List<Trip> result = car.GetTripsInTimeInterval(start, end);
            Assert.AreEqual(2, result.Count);
        }
        [TestMethod]
        public void GetTripsInTimeInterval_ReturnsTripsWithinInterval()
        {
            Car car = new Car("Toyota", "Corolla", 2020, 'A', FuelType.Benzin, 22.5);
            car.StartEngine();

            DateTime start = new DateTime(2026, 2, 26, 12, 0, 0);
            DateTime end = new DateTime(2026, 2, 26, 16, 0, 0);

            Trip trip1 = new Trip(car, 50, new DateTime(2026, 2, 26, 13, 0, 0), new DateTime(2026, 2, 26, 14, 0, 0));
            Trip trip2 = new Trip(car, 30, new DateTime(2026, 2, 26, 15, 0, 0), new DateTime(2026, 2, 26, 16, 0, 0));
            Trip trip3 = new Trip(car, 20, new DateTime(2026, 2, 26, 18, 0, 0), new DateTime(2026, 2, 26, 19, 0, 0));

            car.Drive(trip1);
            car.Drive(trip2);
            car.Drive(trip3);

            List<Trip> result = car.GetTripsInTimeInterval(start, end);

            Assert.AreEqual(2, result.Count);

        }
    }
}
