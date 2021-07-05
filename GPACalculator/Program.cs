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

            GradingApp Application = new GradingApp();

            Application.AddCourseDetails();
        }
    }
}
