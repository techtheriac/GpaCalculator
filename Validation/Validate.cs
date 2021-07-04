using System;
using System.Collections.Generic;
using System.Text;

namespace GPALibrary
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

        //public static Orientation ToOrientation(Direction direction) => direction switch
        //{
        //    Direction.Up => Orientation.North,
        //    Direction.Right => Orientation.East,
        //    Direction.Down => Orientation.South,
        //    Direction.Left => Orientation.West,
        //    _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value: {direction}"),
        //};


        private static bool IsWithinScoreRange(int score)
              => 0 <= score && score <= 100;

        private static bool IsWithinCourseUnitRange(int courseUnit)
           => 0 <= courseUnit && courseUnit <= 5;

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

        //public static Tuple<string, string> CourseCode(int courseCode)
        //{

        //}

    }
}
