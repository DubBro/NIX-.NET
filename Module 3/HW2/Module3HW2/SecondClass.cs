namespace Module3HW2
{
    public class SecondClass
    {
        private int _powResult;

        public Func<int, bool> Calc(Func<int, int, int> powDelegate, int a, int b)
        {
            _powResult = powDelegate(a, b);

            Func<int, bool> resultDelegate = Result;

            return resultDelegate;
        }

        private bool Result(int a)
        {
            return _powResult % a == 0;
        }
    }
}
