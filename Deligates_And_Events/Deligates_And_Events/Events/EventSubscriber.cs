using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deligates_And_Events.Events
{
    public class EventSubscriber
    {
        // Event handler method
        public void HandleEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Event handled by EventSubscriber");
        }
    }
}
