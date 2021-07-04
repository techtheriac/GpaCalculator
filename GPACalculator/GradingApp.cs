using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GPACalculator
{
    public class GradingApp
    {
        List<Course> CourseList = new List<Course> { };

        private int GetWeightPointTotal ()
        {
            int total = 0;

            foreach (var item in CourseList)
            {
                total += item.WeightPoint;
            }

            return total;
        }

        private int GetCourseUnitTotal ()
        {
            int total = 0;

            foreach (var item in CourseList)
            {
                total += item.CourseUnit;
            }

            return total;
        }

        public int TotalCourseUnit => GetCourseUnitTotal();
        public int TotalWeightPoint => GetWeightPointTotal();
        public decimal GPA => Decimal.Round(TotalWeightPoint / TotalCourseUnit, 2);
    }
}
