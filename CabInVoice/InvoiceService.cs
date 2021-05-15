using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInVoice
{
      interface InvoiceService
    {
        //Ride details
        void AddRides(string userId, List<Ride> rides);
        List<Ride> GetAllUserRides(string userId);
    }
}
