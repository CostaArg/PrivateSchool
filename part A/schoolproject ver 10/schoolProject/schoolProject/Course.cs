using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject
{
    class Course
    {
        private string title;
        private string stream;
        private string type;
        private DateTime startDate;
        private DateTime endDate;

        public static List<Course> courseList = new List<Course>();

        public Course() { }

        public Course(string title, string stream, string type, DateTime startDate, DateTime endDate)
        {
            this.title = title;
            this.stream = stream;
            this.type = type;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public void SetTitle()
        {
            Console.WriteLine("Please enter your title: ");
            title = Console.ReadLine();
        }

        public string GetTitle()
        {
            return title;
        }

        public void SetStream()
        {
            Console.WriteLine("Please enter your stream: ");
            stream = Console.ReadLine();
        }

        public string GetStream()
        {
            return stream;
        }

        public void SetType()
        {
            Console.WriteLine("Please enter your type: ");
            type = Console.ReadLine();
        }

        public string GetType()
        {
            return type;
        }

        public void SetStartDate()
        {
            Console.WriteLine("Please enter your start date: ");
            startDate = Convert.ToDateTime(Console.ReadLine());
        }

        public DateTime GetStartDate()
        {
            return startDate;
        }

        public void SetEndDate()
        {
            Console.WriteLine("Please enter your end date: ");
            endDate = Convert.ToDateTime(Console.ReadLine());
        }

        public DateTime GetEndDate()
        {
            return endDate;
        }

        public void PrintCourse()
        {
            Console.WriteLine("Your Course's title is: " + GetTitle());
            Console.WriteLine("Your Course's stream is: " + GetStream());
            Console.WriteLine("Your Course's type is: " + GetType());
            Console.WriteLine("Your Course's start date is: " + GetStartDate());
            Console.WriteLine("Your Course's end date is: " + GetEndDate());
        }

        public void PrintCourseName()
        {
            Console.WriteLine(GetTitle());
        }

        public static void PrintAllCourses()
        {
            string yesOrNo;

            do
            {
                Console.WriteLine("Do you want to print all the courses? Y/N");
                yesOrNo = Console.ReadLine();
            } while (yesOrNo != "Y" && yesOrNo != "N");

            if (yesOrNo == "Y")
            {
                Console.WriteLine("  --Course Titles--  ");

                foreach (Course mathima in courseList)
                {
                    mathima.PrintCourseName();
                }
            }
        }

        static void MakeCourse()
        {
            int i = 0;
            string yesOrNo;


            do
            {

                do
                {
                    Console.WriteLine("Do you want to enter a new course? Y/N");
                    yesOrNo = Console.ReadLine();
                } while (yesOrNo != "Y" && yesOrNo != "N");

                if (yesOrNo == "Y")
                {
                    courseList.Add(new Course());

                    courseList[i].SetTitle();
                    //courseList[i].SetStream();
                    //courseList[i].SetType();
                    //courseList[i].SetStartDate();
                    //courseList[i].SetEndDate();

                }

                i++;

            } while (yesOrNo == "Y");
        }

        static void Main(string[] args)
        {
            Course.MakeCourse();
            Student.MakeStudent();

            Student.SelectCourse();
            Student.PrintStudentsPerCourseList();



        }
    }
}
