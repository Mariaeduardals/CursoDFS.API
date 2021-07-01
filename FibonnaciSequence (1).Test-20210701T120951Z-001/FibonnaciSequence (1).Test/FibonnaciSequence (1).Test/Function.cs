namespace FibonnaciSequence.Test
{
    public class Function
    {
        private  int [] Memo { get; set; }
        public Function()
        {
            Memo = new int[120];
        }
        
        
        public int Fibonnaci(int n)
        {
            Memo[1] = Memo[2] = 1;
            if (Memo[n] == 0)
                Memo[n] = Fibonnaci(n - 1) + Fibonnaci(n - 2);
            return Memo[n];
        }
    }
}