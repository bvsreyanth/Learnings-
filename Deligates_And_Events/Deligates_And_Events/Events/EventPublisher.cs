using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deligates_And_Events.Events
{
    public class EventPublisher
    {
        // Define a delegate for the event handler
        public delegate void MyEventHandler(object sender, EventArgs e);

        // Define the event using the delegate
        public event MyEventHandler MyEvent;

        // Method to trigger the event
        public void RaiseEvent()
        {
            Console.WriteLine("Event raised!");
            // Check if there are subscribers (event handlers) before invoking the event
            MyEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
