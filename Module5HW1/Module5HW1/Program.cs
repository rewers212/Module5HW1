using System;

namespace Module5HW1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var start = new Startup();
            start.Run().GetAwaiter().GetResult();
        }
    }
}
