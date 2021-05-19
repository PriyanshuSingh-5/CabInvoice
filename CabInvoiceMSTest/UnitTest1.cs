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
        
         // TC 3 Whens the given multiple rides get invoice summary.
        [TestMethod]
        public void WhenGivenMultipleRidesGetInvoiceSummary()
        {
            // Create list for multiple rides
            List<Ride> rides = new List<Ride>();
            rides.Add(new Ride(5, 15));
            rides.Add(new Ride(5, 15));

            // Get invoice summary for multiple rides
            InvoiceSummary actual = generator.CalculateFare(rides);
            InvoiceSummary expected = new InvoiceSummary(130, 2, 65);
            Assert.AreEqual(expected, actual);
        }

        
        // TC 4.1 Given the user identifier get invoice summary.
        [TestMethod]
        public void GivenUserIdGetInvoiceSummary()
        {
            // Create list for multiple rides
            List<Ride> rides = new List<Ride>();
            rides.Add(new Ride(5, 15));
            rides.Add(new Ride(5, 15));

            // Add rides using invoice service
            InvoiceService invoiceService = new InvoiceService();
            invoiceService.AddRides("Ram", rides);

            // Get invoice summary for given user id
            InvoiceSummary actual = invoiceService.GetInvoiceSummary("Ram");
            InvoiceSummary expected = new InvoiceSummary(130, 2, 65);

            Assert.AreEqual(expected, actual);
        }

       
        // TC 4.2 Given the invalid user identifier get exception.
        [TestMethod]
        public void GivenInvalidUserIdGetException()
        {
            InvoiceService invoiceService = new InvoiceService();

            // Get invoice summary for given user id
            var actual = Assert.ThrowsException<InvoiceException>(() => invoiceService.GetInvoiceSummary("Ram"));
            Assert.AreEqual(InvoiceException.ExceptionType.INVALID_USER_ID, actual.type);
        }
    }
}
    }
}
