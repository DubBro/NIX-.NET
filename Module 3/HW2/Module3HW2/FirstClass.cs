namespace Module3HW2
{
    public class FirstClass
    {
        private Action<bool> _showDelegate = Program.Show;

        public Action<bool> ShowDelegate
        {
            get { return _showDelegate; }
        }

        public int Pow(int a, int b)
        {
            return a * b;
        }
    }
}
