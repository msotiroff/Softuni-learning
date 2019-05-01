namespace BashSoft.App.Repositories
{
    using Core;
    using IO;
    using System;
    using System.Collections.Generic;

    public class RepositoryFilter
    {
        public void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter.Equals("excellent"))
            {
                FilterAndTake(studentsWithMarks, x => x >= 5.00, studentsToTake);
            }
            else if (wantedFilter.Equals("average"))
            {
                FilterAndTake(studentsWithMarks, x => 3.5 <= x && x < 5.00, studentsToTake);
            }
            else if (wantedFilter.Equals("poor"))
            {
                FilterAndTake(studentsWithMarks, x => x < 3.50, studentsToTake);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private void FilterAndTake(Dictionary<string, double> studentsWithMarks, Predicate<double> givenFilter, int studentsToTake)
        {
            int countOfPrinted = 0;
            foreach (var studentMark in studentsWithMarks)
            {
                if (countOfPrinted == studentsToTake)
                {
                    break;
                }
                
                if (givenFilter(studentMark.Value))
                {
                    OutputWriter.PrintStudent(new KeyValuePair<string, double>(studentMark.Key, studentMark.Value));
                    countOfPrinted++;
                }
            }
        }


        private double Average(List<int> scoresOnTasks)
        {
            double totalScore = 0;
            foreach (int score in scoresOnTasks)
            {
                totalScore += score;
            }

            double percentageOfAll = totalScore / (scoresOnTasks.Count * 100);
            double mark = percentageOfAll * 4 + 2;

            return mark;
        }
    }
}
