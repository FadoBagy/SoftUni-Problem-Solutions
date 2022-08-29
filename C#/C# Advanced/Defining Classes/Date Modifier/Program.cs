using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dm = new DateModifier();         
            Console.WriteLine(Math.Abs(dm.Calculation(Console.ReadLine(), Console.ReadLine())));
        }
    }
}
