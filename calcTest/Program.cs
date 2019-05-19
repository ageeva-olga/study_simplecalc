using System;

namespace calcTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Calc().Calculate("(((11+22+33+44)*3+(3-2)+1)/2)"));
            Console.ReadKey();
        }
    }
}
