using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInVoice
{
   public class InvoiceSummary
    {
        
        public double totalFare;
        public int noOfRides;
        public double averageFarePerRide;

        
        // UC 3 Initializes a new instance of the <see cref="InvoiceSummary"/> class.
        public InvoiceSummary(double totalFare, int noOfRides, double averageFairPerRide)
        {
            this.totalFare = totalFare;
            this.noOfRides = noOfRides;
            this.averageFarePerRide = averageFairPerRide;
        }

        
        // Equalses the specified invoice summary
        public override bool Equals(Object invoiceSummary)
        {
            if (invoiceSummary == null)
            {
                return false;
            }
            if (!(invoiceSummary is InvoiceSummary))
            {
                return false;
            }
            InvoiceSummary invoice = (InvoiceSummary)invoiceSummary;
            return this.totalFare == invoice.totalFare && this.noOfRides == invoice.noOfRides && this.averageFarePerRide == invoice.averageFarePerRide;
        }

        
        // Returns a hash code for this instance.
        // A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        public override int GetHashCode()
        {
            return this.totalFare.GetHashCode() ^ this.noOfRides.GetHashCode() ^ this.averageFarePerRide.GetHashCode();
        }
    }
}



