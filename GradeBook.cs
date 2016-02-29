using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }

        /*
         * "With the 'virtual' keyword, when the C# compiler sees me invoke
         * ComputeStatistics() through a variable type GradeBook() it will no
         * longer use the type of the variable to figure out which method to
         * call, instead it is going to use the type of object, the type it
         * sees at runtime. So, if it sees that GradeBook() is a 
         * ThrowAwayGradeBook() it will look to see if the ThrowAwayGradeBook()
         * 'overrides' ComputeStatistics()."
         *
         * Also:
         * "An abstract method is implicitly a virtual method, so
         * the derived method should 'override' the base method"
         */
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook::ComputeStatistics");

            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum = sum + grade;
            }
            stats.AverageGrade = sum / grades.Count;
            return stats;
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i - 1]);
            }
        }

        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        protected List<float> grades;
        /*
         * public methods: anyone can access
         * private methods: only code inside the same class can access
         * protected field/event/method: code inside this class or code
         * that is inside a derived class can access
         */
    }
}
