using System;
using Figgle;
using GPALibrary;

namespace GPACalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // My Guy, Catch errors early.
            // No need to overthink on subclass level
            Course maths = new Course("Math", 4, 190);

            Console.WriteLine(Validate.Score(100).Item1);
        }
    }
}
