using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    /*
     * If I want to derive from a specific class in addition to
     * implementing an inteface, the class that I'm inheriting from
     * has to come first in the list.
     * i.e. public abstract class GradeTracker : object, IGradeTracker
     */
    public abstract class GradeTracker : IGradeTracker
    {
        /*
         * "An abstract method is implicitly an virtual method, so
         * the derived method should 'override' the parent method."
         */
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                if (_name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }

                _name = value;
            }
        }

        public event NameChangedDelegate NameChanged;

        protected string _name;
    }
}
