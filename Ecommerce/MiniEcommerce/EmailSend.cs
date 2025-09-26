namespace MiniEcommerce
{
    internal class EmailSend
    {
        public EmailSend(EventPublisher pubs)
        {
            pubs.Notifier += SubscribingOrderEvent;
        }
        public void SubscribingOrderEvent(object sender, CustomEventArgs e)
        {

            Console.WriteLine($"email was sent to {sender} about his purchase of {e.nob} books and {e.nop} pens");
        }
    }
}

