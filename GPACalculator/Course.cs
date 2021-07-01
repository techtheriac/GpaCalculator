using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculator
{
    class Course
    {
        
        private string _courseNameAndCode;
        private int _courseUnit;
        private int _courseScore;

        public Course(string courseCodeAndName, int courseUnit, int courseScore)
        {
            _courseNameAndCode = courseCodeAndName;
            _courseUnit = courseUnit;
            _courseScore = courseScore;
        }

        public string CourseNameAndCode => _courseNameAndCode;
        public int CourseUnit => _courseUnit;
        public int CourseScore => _courseScore;
        public Tuple<Grader.Grades, string> GradeProps => Grader.GetGradeProperties(CourseScore);
        public string Grade => GradeProps.Item1.ToString();
        public string Remark => GradeProps.Item2;
        public int WeightPoint => (int)GradeProps.Item1 * CourseUnit;
    }
}
