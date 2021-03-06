﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
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
            else if (rank <= 3)
            {
                return 'C';
            }
            else if (rank <= 4)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
