using System.IO;

namespace Grades
{
    /*
     * "There's one huge difference between an abstract class
     * and an interface, when I define a class I can only inherit
     * from a single base class, but I can implement as many 
     * interfaces as I like."
     * e.g. I can inherit from a base class and implement ten
     * interfaces.
     *
     * "Any class or struct can inherit from any interface"
     */
    internal interface IGradeTracker
    {
        /*
         * "Inside of an interface I cannot use access modifiers"
         * "The methods are also implicitly virtual"
         */
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter destination);
        string Name { get; set; }
    }
}