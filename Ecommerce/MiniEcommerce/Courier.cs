namespace MiniEcommerce
{
    internal class Courier
    {
        public Courier(EventPublisher pubs)
        {
            pubs.Notifier += SubscribingOrderEvent;
        }
        public void SubscribingOrderEvent(object sender, CustomEventArgs e)
        {

            Console.WriteLine($"{e.nob} books ,{e.nop} pens Couriered to {sender}");
        }
    }
}
