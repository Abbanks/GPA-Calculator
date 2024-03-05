using ConsoleTables;
using System;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GPA_Calculator
{
    internal class GPACalculator
    {
        List<Course> courses = [];

        public void InputCourseData()
        {
            Console.Write("Enter the number of courses: ");
            int numberOfCourses;
            while (!int.TryParse(Console.ReadLine(), out numberOfCourses) || numberOfCourses <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive integer for the number of courses.");
                Console.Write("Enter the number of courses: ");
            }

            for (int i = 1; i <= numberOfCourses; i++)
            {
                Console.WriteLine("\n");
                string name = GetValidCourseName();

                Console.Write("Enter the course unit: ");
                int courseUnit;
                while (!int.TryParse(Console.ReadLine(), out courseUnit) || courseUnit <= 0 && courseUnit > 10)
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive integer for the course unit.");
                    Console.Write("Enter the course unit: ");
                }

                Console.Write("Enter your score: ");
                int score;
                while (!int.TryParse(Console.ReadLine(), out score) || score < 0 || score > 100)
                {
                    Console.WriteLine("Invalid input. Please enter a valid score between 0 and 100.");
                    Console.Write("Enter your score: ");
                }

                char grade = GetGrade(score);

                int gradeUnit = GetGradeUnit(grade);

                int qualityPoint = CalcQualityPoint(courseUnit, gradeUnit);

                courses.Add(new Course(name, courseUnit, score, grade, gradeUnit, qualityPoint));
            }

            Console.Clear();
        }

        public string GetValidCourseName()
        {
            string name;
            bool isValid = false;

            string pattern = @"^[A-Z]{3}\s\d{3}$";

            do
            {
                Console.Write("Enter the name of the course (e.g., CSC 111): ");
                name = Console.ReadLine();

                // Perform validation using regular expression
                isValid = Regex.IsMatch(name, pattern);

                if (!isValid)
                {
                    Console.WriteLine("Invalid course name. Please enter a name in the format 'XXX 000'.");
                }
            } while (!isValid);

            return name;
        }
    

    public char GetGrade(int score)
        {
            char grade = 'A';
            if (score >= 70)
            {
                grade = 'A';
            }
            else if (score >= 60)
            {
                grade = 'B';
            }
            else if (score >= 50)
            {
                grade = 'C';
            }
            else if (score >= 45)
            {
                grade = 'D';
            }
            else if (score >= 40)
            {
                grade = 'E';
            }
            else if (score >= 0)
            {
                grade = 'F';
            }
            return grade;
        }

        public int GetGradeUnit(char grade)
        {
            int gradeUnit = 0;
            switch (grade)
            {
                case 'A':
                    gradeUnit = 5;
                    break;
                case 'B':
                    gradeUnit = 4;
                    break;
                case 'C':
                    gradeUnit = 3;
                    break;
                case 'D':
                    gradeUnit = 2;
                    break;
                case 'E':
                    gradeUnit = 1;
                    break;
                case 'F':
                    gradeUnit = 0;
                    break;
                default:
                    Console.WriteLine("Unknown grade. Please enter a valid letter grade (A-F).");
                    break;
            }
            return gradeUnit;
        }

        public int CalcQualityPoint(int courseUnit, int gradeUnit)
        {
            return courseUnit * gradeUnit;
        }

        public double CalculateGPA()
        {
            double totalQualityPoint = 0;
            double totalCourseUnit = 0;
            foreach (var course in courses)
            {
                totalQualityPoint += course.QualityPoint;
                totalCourseUnit += course.CourseUnit;
            }
            return totalQualityPoint / totalCourseUnit;
        }

        public void PrintResult()
        {
             
            var newTable = new ConsoleTable("Course", "Course Unit", "Grade", "Grade Unit");    
           
            foreach (var course in courses)
            {
                newTable.AddRow(course.Name, course.CourseUnit, course.Grade, course.GradeUnit);
            }   
            newTable.Write();

            Console.WriteLine("Your GPA is {0:N2}", CalculateGPA());
        } 
    }

}

