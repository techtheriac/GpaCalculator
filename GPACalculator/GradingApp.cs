using System;
using System.Collections.Generic;
using System.Text;
using Figgle;
using Utils;

namespace GPACalculator
{
    public class GradingApp
    {
        List<Course> CourseList = new List<Course> { };
        List<string> Manual = new List<string>
        {
            "Here are a list of thing you can do",
            "Type 'add' to add course details",
            "Type 'print' to view course listing and properties",
            "Type 'gpa' to view calculated Grade Point Average",
            "Type 'help' to view this manual",
            "Type 'exit' to terminate application"
        };

        private int _courseUnit;
        private int _score;
        private string _courseCode;
        private string _action;

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
            Console.WriteLine("Input Course Code");
            Console.Write(">> ");
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
            Console.WriteLine("Input Score");
            Console.Write(">> ");
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
            Console.WriteLine("Input Course Unit");
            Console.Write(">> ");
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

        private void PrintWelcomeMessage(string message)
        {
            Console.WriteLine("");
            Console.WriteLine($"{FiggleFonts.SlantSmall.Render(message)}");
            Console.WriteLine("\t Welcome to the GPA Calculator Application");
        }

        public void PrintMaual(List<string> manual)
        {
            foreach (var item in manual)
            {
                Console.WriteLine($"\t {item}");
            }
        }

        public void Prodecure(int count, int max)
        {
            Console.Write(">> ");
            string _action = Console.ReadLine().ToLower();

            if(count >= max || _action == "exit")
            {
                return;
            }


            if(!Validate.IsValidAction(_action))
            {
                Console.WriteLine("You have made an Invalid Selection");
                Prodecure(count + 1, int.MaxValue);
            }

            switch(_action)
            {
                case "help":
                    PrintMaual(Manual);
                    break;
                case "add":
                    AddCourseDetails();
                    break;
                case "exit":
                    return;
                default:
                Prodecure(count + 1, int.MaxValue);
                    break;
            }

            Prodecure(count + 1, int.MaxValue);
        }

        public void Init()
        {
            PrintWelcomeMessage("GPA CALCULATOR");
            PrintMaual(Manual);
        }

        public int TotalCourseUnit => GetCourseUnitTotal();
        public int TotalWeightPoint => GetWeightPointTotal();
        public decimal GPA => Decimal.Round(TotalWeightPoint / TotalCourseUnit, 2);
    }
}
