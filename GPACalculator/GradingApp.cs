using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Utils;

namespace GPACalculator
{
    public class GradingApp
    {
        List<Course> CourseList = new List<Course> { };


        private int _courseUnit;
        private int _score;
        private string _courseCode;

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
        
        public void AddCourseCode()
        {
            Console.Write("Input Course Code");
            string cc = Console.ReadLine();

            if(Validate.CourseCode(cc).Item1 != "")
            {
                _courseCode = Validate.CourseCode(cc).Item1;
                Console.WriteLine(Validate.CourseCode(cc).Item2);
                return;

            } else
            {
                Console.WriteLine(Validate.CourseCode(cc).Item2);
                AddCourseCode();
            }
        }

        public void AddCourseScore()
        {
            Console.Write("Input Score");
            var cs = Validate.SafeParseInt(Console.ReadLine());

            if(cs != -1 && Validate.Score(cs).Item1 != 0)
            {
                _score = Validate.Score(cs).Item1;
                Console.WriteLine(Validate.Score(cs).Item2);
                return;
            } else
            {
                Console.WriteLine(Validate.Score(cs).Item2);
                AddCourseScore();
            }
        }

        public void AddCourseUnit()
        {
            Console.Write("Input Course Unit");
            int cu = Validate.SafeParseInt(Console.ReadLine());

            if(cu != -1 && Validate.CourseUnit(cu).Item1 != 0)
            {
                _courseUnit = Validate.CourseUnit(cu).Item1;
                Console.WriteLine(Validate.CourseUnit(cu).Item2);
                return;
            } else
            {
                Console.WriteLine(Validate.CourseUnit(cu).Item2);
                AddCourseUnit();
            }
        }

        public void AddCourseDetails()
        {

            AddCourseCode();
            AddCourseUnit();
            AddCourseScore();

            CourseList.Add(new Course(_courseCode, _courseUnit, _score));
        }



        public int TotalCourseUnit => GetCourseUnitTotal();
        public int TotalWeightPoint => GetWeightPointTotal();
        public decimal GPA => Decimal.Round(TotalWeightPoint / TotalCourseUnit, 2);
    }
}
