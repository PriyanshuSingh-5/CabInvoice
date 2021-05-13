using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CabInVoice;
using System;

namespace CabInvoiceMSTest
{
    [TestClass]
    public class Tests
    {

        InvoiceGenerator generator;
        //calculate fare
        [TestMethod]
        public void WhenGivenDistanceAndTimeReturnFare()
        {
            Ride ride = new Ride(5, 15);
            double totalFare = generator.CalculateFare(ride);
            double expected = 65;
            Assert.AreEqual(expected, totalFare);
        }

        //calculate multiple fare
        [TestMethod]
        public void WhenGivenDistanceAndTimeReturnFareForMultipleRides()
        {
            // Create list for multiple rides
            List<Ride> rides = new List<Ride>();
            rides.Add(new Ride(5, 15));
            rides.Add(new Ride(5, 15));

            // Calculate fare for multiple rides
            double totalFare = generator.CalculateFare(rides);
            double expected = 130;
            Assert.AreEqual(expected, totalFare);
        }
    }
}
