using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA_Calculator
{
    internal interface IGPACalculator
    {
        void InputCourseData();
        string GetValidCourseName();
        char GetGrade(int score);
        int GetGradeUnit(char grade);
        int CalcQualityPoint(int courseUnit, int gradeUnit);
        void PrintResult();   
    }
}
