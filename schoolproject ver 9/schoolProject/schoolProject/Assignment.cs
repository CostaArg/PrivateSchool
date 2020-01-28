using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject
{
    class Assignment
    {
        private string title;
        private string description;
        private DateTime subDateTime;
        private string oralMark;
        private string totalMark;

        public static List<Assignment> assignmentList = new List<Assignment>();

        public static List<List<Course>> assignmentsPerCourseList = new List<List<Course>>();


        public Assignment() { }

        public Assignment(string title, string description, DateTime subDateTime, string oralMark, string totalMark)
        {
            this.title = title;
            this.description = description;
            this.subDateTime = subDateTime;
            this.oralMark = oralMark;
            this.totalMark = totalMark;
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

        public void SetDescription()
        {
            Console.WriteLine("Please enter your description: ");
            description = Console.ReadLine();
        }

        public string GetDescription()
        {
            return description;
        }

        public void SetSubDateTime()
        {
            Console.WriteLine("Please enter your sub date time: ");
            subDateTime = Convert.ToDateTime(Console.ReadLine());
        }

        public DateTime GetSubDateTime()
        {
            return subDateTime;
        }

        public void SetOralMark()
        {
            Console.WriteLine("Please enter your oral mark: ");
            oralMark = Console.ReadLine();
        }

        public string GetOralMark()
        {
            return oralMark;
        }

        public void SetTotalMark()
        {
            Console.WriteLine("Please enter your total mark: ");
            totalMark = Console.ReadLine();
        }

        public string GetTotalMark()
        {
            return totalMark;
        }

        public void printAssignment()
        {
            Console.WriteLine("Your Assignment's title is: " + GetTitle());
            Console.WriteLine("Your Assignment's description is: " + GetDescription());
            Console.WriteLine("Your Assignment's subDateTime is: " + GetSubDateTime());
            Console.WriteLine("Your Assignment's oralMark is: " + GetOralMark());
            Console.WriteLine("Your Assignment's totalMark is: " + GetTotalMark());
        }

        public void PrintAssignmentName()
        {
            Console.WriteLine("Assignment name: " + GetTitle());
        }

        public static void SelectCourse()
        {
            string yesOrNo;

            do
            {
                Console.WriteLine("Do you want to select a course? Y/N");
                yesOrNo = Console.ReadLine();
            } while (yesOrNo != "Y" && yesOrNo != "N");

            if (yesOrNo == "Y")
            {
                Console.WriteLine("  --Course Titles--  ");

                for (int i = 0; i < Course.courseList.Count; i++)
                {
                    Console.Write((i + 1) + ". ");
                    Course.courseList[i].PrintCourseName();
                }

                int option;

                List<Course> sublist = new List<Course>();

                do
                {

                    Console.WriteLine("Enter your option: ");
                    option = Convert.ToInt32(Console.ReadLine());


                    for (int i = 0; i < Course.courseList.Count; i++)
                    {
                        if ((option - 1) == i)
                        {
                            sublist.Add(Course.courseList[i]);
                        }
                    }

                    do
                    {
                        Console.WriteLine("Do you want to select another course? Y/N");
                        yesOrNo = Console.ReadLine();
                    } while (yesOrNo != "Y" && yesOrNo != "N");

                } while (yesOrNo == "Y");

                assignmentsPerCourseList.Add(sublist);

            }
        }

        public static void PrintAssignmentsPerCourseList()
        {

            string yesOrNo;

            do
            {
                Console.WriteLine("Do you want to print all the assignments per course? Y/N");
                yesOrNo = Console.ReadLine();
            } while (yesOrNo != "Y" && yesOrNo != "N");

            if (yesOrNo == "Y")
            {
                int i = 0;

                foreach (var sublist in assignmentsPerCourseList)
                {
                    Console.WriteLine("---" + assignmentList[i].GetTitle() + "---");
                    i++;

                    foreach (var value in sublist)
                    {
                        Console.WriteLine(value.GetTitle());
                    }
                    Console.WriteLine();
                }

            }
        }

        public static void MakeAssignment()
        {

            int i = 0;
            string yesOrNo;

            do
            {

                do
                {
                    Console.WriteLine("Do you want to enter a new assignment? Y/N");
                    yesOrNo = Console.ReadLine();
                } while (yesOrNo != "Y" && yesOrNo != "N");

                if (yesOrNo == "Y")
                {
                    assignmentList.Add(new Assignment());

                    assignmentList[i].SetTitle();
                    //assignmentList[i].SetDescription();
                    //assignmentList[i].SetSubDateTime();
                    //assignmentList[i].SetOralMark();
                    //assignmentList[i].SetTotalMark();

                    SelectCourse();
                    PrintAssignmentsPerCourseList();
                }

                i++;

            } while (yesOrNo == "Y");

        }

        public static void PrintAllAssignments()
        {
            string yesOrNo;
            int counter = 1;

            do
            {
                Console.WriteLine("Do you want to print all the assignments? Y/N");
                yesOrNo = Console.ReadLine();
            } while (yesOrNo != "Y" && yesOrNo != "N");

            if (yesOrNo == "Y")
            {
                Console.WriteLine("  --Assignment Names--  ");

                foreach (Assignment askisi in assignmentList)
                {
                    Console.Write(counter + ". ");
                    askisi.PrintAssignmentName();
                }

            }


        }
    }

}

