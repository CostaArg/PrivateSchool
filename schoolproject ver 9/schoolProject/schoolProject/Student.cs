using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject
{
    class Student
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string tuitionFees;

        public static List<Student> studentList = new List<Student>();

        public static List<List<Student>> studentsPerCourseList = new List<List<Student>>();

        public Student() { }

        public Student(string firstName, string lastName, DateTime dateOfBirth, string tuitionFees)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.tuitionFees = tuitionFees;
        }

        public void SetFirstName()
        {
            Console.WriteLine("Please enter your first name: ");
            firstName = Console.ReadLine();
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public void SetLastName()
        {
            Console.WriteLine("Please enter your last name: ");
            lastName = Console.ReadLine();
        }

        public string GetLastName()
        {
            return lastName;
        }

        public void SetDateOfBirth()
        {
            Console.WriteLine("Please enter your date of birth: ");
            dateOfBirth = Convert.ToDateTime(Console.ReadLine());
        }

        public DateTime GetDateOfBirth()
        {
            return dateOfBirth;
        }

        public void SetFees()
        {
            Console.WriteLine("Please enter your tuition fees: ");
            tuitionFees = Console.ReadLine();
        }

        public string GetFees()
        {
            return tuitionFees;
        }

        public void PrintStudent()
        {
            Console.WriteLine("Your Student's first name is: " + GetFirstName());
            Console.WriteLine("Your Student's last name is: " + GetLastName());
            Console.WriteLine("Your Student's date of birth is: " + GetDateOfBirth());
            Console.WriteLine("Your Student's tuition fees are: " + GetFees());
        }

        public void PrintStudentName()
        {
            Console.WriteLine(GetFirstName() + " " + GetLastName());
        }

        public string GetFullName()
        {
            string fullName = GetFirstName() + " " + GetLastName();
            return fullName;
        }

        public static void SelectCourse()
        {
            string yesOrNo;

            do
            {

                Console.WriteLine("  --Course Titles--  ");

                for (int i = 0; i < Course.courseList.Count; i++)
                {
                    Console.Write((i + 1) + ". ");
                    Course.courseList[i].PrintCourseName();
                }

                Console.WriteLine("Select the course you want to enroll a student: ");
                int optionCourse = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < Course.courseList.Count; i++)
                {
                    if ((optionCourse - 1) == i)
                    {
                        Console.WriteLine("  --Name and Surname--  ");

                        for (int k = 0; k < Student.studentList.Count; k++)
                        {
                            Console.Write((k + 1) + ". ");
                            Student.studentList[k].PrintStudentName();
                        }

                        Console.WriteLine("Select the student you want to enroll: ");
                        int optionStudent = Convert.ToInt32(Console.ReadLine());

                        List<Student> sublist = new List<Student>();

                        for (int j = 0; j < Student.studentList.Count; j++)
                        {
                            if ((optionStudent - 1) == j)
                            {
                                sublist.Add(Student.studentList[j]);
                                Console.WriteLine("Successfully added " + Student.studentList[j].GetFullName() + " to " + Course.courseList[i].GetTitle());
                            }
                        }

                        studentsPerCourseList.Add(sublist);
                    }
                }

                do
                {
                    Console.WriteLine("Do you want to enroll another student? Y/N");
                    yesOrNo = Console.ReadLine();
                } while (yesOrNo != "Y" && yesOrNo != "N");

            } while (yesOrNo == "Y");
        }

        public static void PrintStudentsPerCourseList()
        {

            string yesOrNo;

            do
            {
                Console.WriteLine("Do you want to print all the enrolled students? Y/N");
                yesOrNo = Console.ReadLine();
            } while (yesOrNo != "Y" && yesOrNo != "N");

            if (yesOrNo == "Y")
            {
                int counter = 0;

                foreach (var sublist in studentsPerCourseList)
                {
                    //Console.WriteLine("---" + Course.courseList[counter].GetTitle() + "---");
                    Console.WriteLine("MATHIMA");
                    counter++;

                    foreach (var value in sublist)
                    {
                        Console.WriteLine(value.GetFullName());
                    }
                    Console.WriteLine();
                }

            }
        }

        public static void MakeStudent()
        {

            int counter = 0;
            string yesOrNo;

            do
            {

                do
                {
                    Console.WriteLine("Do you want to enter a new student? Y/N");
                    yesOrNo = Console.ReadLine();
                } while (yesOrNo != "Y" && yesOrNo != "N");

                if (yesOrNo == "Y")
                {
                    studentList.Add(new Student());

                    studentList[counter].SetFirstName();
                    studentList[counter].SetLastName();
                    //studentList[counter].SetDateOfBirth();
                    //studentList[counter].SetFees();
                }

                counter++;

            } while (yesOrNo == "Y");

        }

        public static void PrintAllStudents()
        {
            string yesOrNo;
            int counter = 1;

            do
            {
                Console.WriteLine("Do you want to print all students? Y/N");
                yesOrNo = Console.ReadLine();
            } while (yesOrNo != "Y" && yesOrNo != "N");

            if (yesOrNo == "Y")
            {
                Console.WriteLine("  --Name and Surname--  ");

                foreach (Student onoma in studentList)
                {
                    Console.Write(counter + ". ");
                    onoma.PrintStudentName();
                }

            }


        }




    }
}
