using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInVoice
{
     class RideRepository : IInvoiceService
    {
        public Dictionary<string, List<Ride>> userDataSummary = new Dictionary<string, List<Ride>>();

        public List<Ride> GetAllUserRides(string userId)
        {
            // See if the user is registered 
            if (!userDataSummary.ContainsKey(userId))
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_USER_ID, "User is not registered");

            // Throw exception if user has zero rides
            if (userDataSummary[userId].Count == 0)
                throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "User has no rides");

            // If user has rides then return the list of rides
            return userDataSummary[userId];
        }

       
        // UC 4 Adds the rides.
        public void AddRides(string userId, List<Ride> rides)
        {
            // If user already exists then add the range of values given
            if (userDataSummary.ContainsKey(userId))
            {
                userDataSummary[userId].AddRange(rides);
                return;
            }

            // If user doesnt exist then add a new entry
            userDataSummary.Add(userId, rides);
        }
    }
}
