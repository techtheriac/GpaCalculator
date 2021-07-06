using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTables;

namespace GPACalculator
{
    public static class PrintTable
    {
        private static string Caps(string text)
        {
            return text.ToUpper();
        }
        public static void Print(List<Course> courses)
        {
            var table = new ConsoleTable("COURSE & CODE", 
                                         "COURSE UNIT", 
                                         "GRADE", 
                                         "GRADE UNIT", 
                                         "WEIGHT PT.", 
                                         "REMARK");

            foreach (var item in courses)
            {
                table.AddRow(Caps(item.CourseNameAndCode), 
                                  item.CourseUnit, 
                                  Caps(item.Grade), 
                                  item.GradeUnit,
                                  item.WeightPoint, 
                                  Caps(item.Remark));
            }

            table.Write();
        }

    }
}
