using System.Diagnostics.Metrics;

namespace GPA_Calculator
{
    internal class Course(string name, int courseUnit, int score, char grade, int gradeUnit, int qualityPoint)
    {
        public string Name { get; } = name;
        public int CourseUnit { get; } = courseUnit;
        public int Score { get; } = score;
        public char Grade { get; } = grade;
        public int GradeUnit { get; } = gradeUnit;

        public int QualityPoint { get; } = qualityPoint;

        public override string ToString()
        {
            return $"|{Name,-10}|{CourseUnit,-10}|{Grade,-10}|{GradeUnit,-10}|";
        }

    }


}
