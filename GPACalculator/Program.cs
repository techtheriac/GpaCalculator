using System;
using Utils;
using System.Text.RegularExpressions;

namespace GPACalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // My Guy, Catch errors early.
            // No need to overthink on subclass level
            Course maths = new Course("Math", 4, 190);

            Console.WriteLine(Validate.CourseCode("ENF910").Item2);
        }
    }
}
