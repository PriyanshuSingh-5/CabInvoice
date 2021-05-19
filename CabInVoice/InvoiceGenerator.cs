using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInVoice
{
    private readonly int COST_PER_KM;
        private readonly int COST_PER_MIN;
        private readonly int MIN_FARE;
        double rideFare;

        public InvoiceGenerator()
        {
            COST_PER_KM = 10;
            COST_PER_MIN = 1;
            MIN_FARE = 5;
        }
  
        //calculate fare
        public double CalculateFare(Ride ride)
        {
            // Throw exceptions for wrong values
            if (ride.distance <= 0)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_DISTANCE, "Distance cannot be non positive");
            }
            else if (ride.time <= 0)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_TIME, "Time cannot be non positive");
            }

            // Calculate total fare and return it
            rideFare = ride.distance * COST_PER_KM + ride.time * COST_PER_MIN;
            return Math.Max(MIN_FARE, rideFare);
        }

}
