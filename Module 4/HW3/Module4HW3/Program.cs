using Microsoft.EntityFrameworkCore;
using Module4HW3.Context;

namespace Module4HW3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DbContext appContext = new ApplicationContext();
        }
    }
}