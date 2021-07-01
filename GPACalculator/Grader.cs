using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculator
{
    public static class Grader
    {
        // Grade point corresponds to enum index
        public enum Grades
        {
            F,
            E,
            D,
            C,
            B,
            A
        }

        public static Tuple<Grades, string> GetGradeProperties(int score)
        {
            if(score >= 70 && score <=100)
            {
                return Tuple.Create(Grades.A, "Excellent");
            } else if (score >= 60 && score <= 69)
            {
                return Tuple.Create(Grades.B, "Very Good");
            } else if (score >= 50 && score <= 59)
            {
                return Tuple.Create(Grades.C, "Good");
            } else if (score >= 45 && score <= 49)
            {
                return Tuple.Create(Grades.D, "Fair");
            } else if (score >= 40 & score <= 44)
            {
                return Tuple.Create(Grades.E, "Pass");
            } else
            {
                return Tuple.Create(Grades.F, "Fail");
            }
 
        }

    }
}
