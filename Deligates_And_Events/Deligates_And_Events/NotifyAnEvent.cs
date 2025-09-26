using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deligates_And_Events
{
    internal class NotifyAnEvent
    {
        public event Transform TransformEvent;

        public void NotifySubscribers(int x)
        {
          // Check if the event has subscribers before invoking

            TransformEvent?.Invoke(x);
        }
    }
}
