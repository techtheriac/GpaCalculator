using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Utils
{
    public static class Validate
    {
        private enum Valid {
            Success,
            Error
        }

        private static string ParseScore(Valid message) => message switch
        {
            Valid.Success => "Score Added Successfully",
            Valid.Error => "Kindly input score within the range 1 to 100",
            _ => throw new ArgumentOutOfRangeException(),
        };

        private static string ParseScoreUnit(Valid message) => message switch
        {
            Valid.Success => "Course Unit Added Successfully",
            Valid.Error => "Kindly input score unit within the range 1 to 5",
            _ => throw new ArgumentOutOfRangeException(),
        };

        private static string ParseCourseCode(Valid message) => message switch
        {
            Valid.Success => "Course Code Added Sucessfully",
            Valid.Error => "Invalid Course code. Kindly input course code of the format: MATH201",
            _ => throw new ArgumentOutOfRangeException(),
        };

        //    _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value: {direction}"),
       
        private static bool IsWithinScoreRange(int score)
              => 0 <= score && score <= 100;

        private static bool IsWithinCourseUnitRange(int courseUnit)
           => 0 <= courseUnit && courseUnit <= 5;

        public static bool IsValidAction(string action)
        {
            return action == "print" || action == "help" || action == "add" || action == "exit";
        } 


        private static bool isValidCourseCode(string courseCode)
        {
            string pattern = @"([A-Z]{1,5}[0-9$])\w+";
            Regex CodeRgx = new Regex(pattern, RegexOptions.IgnoreCase);
            return CodeRgx.IsMatch(courseCode);
        }

        public static Tuple<int, string> Score (int score)
        {
            if(!IsWithinScoreRange(score))
            {
                return Tuple.Create(0, ParseScore(Valid.Error));
            } else
            {
                return Tuple.Create(score, ParseScore(Valid.Success));
            }
        }

        public static int SafeParseInt(string x)
        {
            if (Int32.TryParse(x, out int j))
            {
                return j;
            }
            else
            {
                Console.WriteLine("Your Input is Invalid");
                return -1;
            }
        }
        public static Tuple<int, string> CourseUnit(int courseUnit)
        {
            if(!IsWithinCourseUnitRange(courseUnit))
            {
                return Tuple.Create(0, ParseScoreUnit(Valid.Error));
            } else
                return Tuple.Create(courseUnit, ParseScoreUnit(Valid.Success));
            {
            }

        }

        public static Tuple<string, string> CourseCode(string courseCode)
        {
            if(!isValidCourseCode(courseCode))
            {
                return Tuple.Create("", ParseCourseCode(Valid.Error));
            } else
            {
                return Tuple.Create(courseCode, ParseCourseCode(Valid.Success));
            }
        }

    }
}
