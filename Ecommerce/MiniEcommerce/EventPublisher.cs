namespace MiniEcommerce
{
    internal class EventPublisher
    {
        public delegate void OrderNotifier(object sender, CustomEventArgs e);
        public event OrderNotifier? Notifier;
        CustomEventArgs cstmEventArgs;
        string sender;
        public EventPublisher(int NOB, int NOP, string customer)
        {
            cstmEventArgs = new CustomEventArgs(NOB, NOP);
            sender = customer;
        }
        public void TriggerOrderEvent()
        {

            Publish(sender,cstmEventArgs);
        }
        protected virtual void Publish(String sender, CustomEventArgs e)
        {
            Notifier?.Invoke(sender, e);
        }
    }
}
