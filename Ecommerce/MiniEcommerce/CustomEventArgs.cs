namespace MiniEcommerce
{
    internal class CustomEventArgs
    {
        public int nob { get; set; }
        public int nop { get; set; }
        public CustomEventArgs(int NOB, int NOP)
        {
            nob = NOB;
            nop = NOP;
        }
    }
}
