namespace MiniEcommerce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Stationary Shop");
            Console.WriteLine("Enter your Name");
            var name = Console.ReadLine();
            Console.WriteLine("How Many number of Books, do you want...?");
            var NOB = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How Many number of Pens, do you want...?");
            var NOP = Convert.ToInt32(Console.ReadLine());
            EventPublisher pubs = new EventPublisher(NOB, NOP, name);
            Courier crr = new Courier(pubs);
            EmailSend emlsnd = new EmailSend(pubs);

            pubs.TriggerOrderEvent();
        }
    }
}