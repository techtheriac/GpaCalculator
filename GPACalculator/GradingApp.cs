using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculator
{
    class GradingApp
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

        private int GetGradeUnitTotal ()
        {
            int total = 0;

            foreach (var item in CourseList)
            {
                total += item.GradeUnit;
            }

            return total;
        }

        public int TotalGradeUnit => GetGradeUnitTotal();
        public int TotalWeightPoint => GetWeightPointTotal();
    }
}
