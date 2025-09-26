using Deligates_And_Events.Events;

namespace Deligates_And_Events
{
    internal class Program
    {
        private static Transform square;
        private static Transform cube;

        static void Main(string[] args)
        {
            ////Deligate
            //MyDeligate deligates = new MyDeligate();
            //AddDeligate obj = new AddDeligate(deligates.Add);
            //obj(20, 30);
            //sayHello sayhello = new sayHello(MyDeligate.sayHello);
            //string print = sayhello("Deligate");
            //Console.WriteLine(print);
            //Console.ReadLine();

            ////Multicast Deligate
            //MultiCastDeligate multiCast = new MultiCastDeligate();
            //Multicasting? del = multiCast.Addmet;
            //del += multiCast.Mult;
            ////Addmet and Mult will be called
            //del(20, 30);
            ////Only Addmet
            //del -= multiCast.Mult;
            //del(40, 30);
            //Console.ReadLine();

            ////Event
            //int num = 20;
            //Console.WriteLine($"Entered number is {num}");

            //NotifyAnEvent notifier = new NotifyAnEvent();

            //// Subscribing to the event with the methods Square and Cube
            //notifier.TransformEvent += square;
            //notifier.TransformEvent += cube;

            //// Notify subscribers by invoking the event
            //notifier.NotifySubscribers(num);

            //Event
            // Create instances of the publisher and subscriber
            EventPublisher publisher = new EventPublisher();
            EventSubscriber subscriber = new EventSubscriber();

            // Subscribe to the event by adding the event handler method
            publisher.MyEvent += subscriber.HandleEvent;

            // Raise the event, which will invoke the event handler method in the subscriber
            publisher.RaiseEvent();

        }
    }
}