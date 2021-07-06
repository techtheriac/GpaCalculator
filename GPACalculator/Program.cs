using System;
using Utils;

namespace GPACalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // My Guy, Catch errors early.
            // No need to overthink beyond user input validation

            GradingApp Application = new GradingApp();
            Application.Init();
            Application.Prodecure(0, int.MaxValue);
        }
    }
}
