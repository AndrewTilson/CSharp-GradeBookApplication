using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5)
                throw new InvalidOperationException("At least 5 students required for ranked grading");

            var divisible = Students.Count / 5;

            var sort = Students.OrderByDescending(x => x.AverageGrade).ToList();
            var rank = sort.FindIndex(x => x.AverageGrade == averageGrade) + 1 / divisible;


            if (rank <= 1)
            {
                return 'A';
            }
            else if(rank <= 2)
            {
                return 'B';
            }
            if (rank <= 3)
            {
                return 'C';
            }
            if (rank <= 4)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
