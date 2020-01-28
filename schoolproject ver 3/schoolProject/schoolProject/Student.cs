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

        public static string[,] enrolledStudentsList = new string[50, 50];

        public Student() { }

        public Student(string firstName, string lastName, DateTime dateOfBirth, string tuitionFees)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.tuitionFees = tuitionFees;
        }

        public void setFirstName()
        {
            Console.WriteLine("Please enter your first name: ");
            firstName = Console.ReadLine();
        }

        public string getFirstName()
        {
            return firstName;
        }

        public void setLastName()
        {
            Console.WriteLine("Please enter your last name: ");
            lastName = Console.ReadLine();
        }

        public string getLastName()
        {
            return lastName;
        }

        public void setDateOfBirth()
        {
            Console.WriteLine("Please enter your date of birth: ");
            dateOfBirth = Convert.ToDateTime(Console.ReadLine());
        }

        public DateTime getDateOfBirth()
        {
            return dateOfBirth;
        }

        public void setFees()
        {
            Console.WriteLine("Please enter your tuition fees: ");
            tuitionFees = Console.ReadLine();
        }

        public string getFees()
        {
            return tuitionFees;
        }

        public void printStudent()
        {
            Console.WriteLine("Your Student's first name is: " + getFirstName());
            Console.WriteLine("Your Student's last name is: " + getLastName());
            Console.WriteLine("Your Student's date of birth is: " + getDateOfBirth());
            Console.WriteLine("Your Student's tuition fees are: " + getFees());
        }

        public void printStudentName()
        {
            Console.WriteLine(getFirstName() + " " + getLastName());
        }

        public string getStudentName()
        {
            string studentFullName = getFirstName() + " " + getLastName();
            return studentFullName;
        }

        public static void selectCourse ()
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
                    Console.Write( (i + 1) + ". ");
                    Course.courseList[i].printCourseName();
                }

                int? option = null;
                int studentCounter = 0;
                int courseCounter = 0;

                do
                {

                    Console.WriteLine("Enter your option: ");
                    option = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < 50; i++)
                    {

                        if (studentCounter < studentList.Count)
                        {
                            enrolledStudentsList[0, i] = Student.studentList[studentCounter].getStudentName();
                            studentCounter++;
                        }


                        for (int j = 1; j < 50; j++)
                        {

                            if (option == j)
                            {
                                if (courseCounter < Course.courseList.Count)
                                {
                                    enrolledStudentsList[i, j] = Course.courseList[courseCounter].getTitle();
                                    courseCounter++;
                                }
                                
                            }


                        }

                    }

                    do
                    {
                        Console.WriteLine("Do you want to select another course? Y/N");
                        yesOrNo = Console.ReadLine();
                    } while (yesOrNo != "Y" && yesOrNo != "N");

                } while (yesOrNo == "Y");

            }
        }

        public static void printStudentsPerCourseList()
        {

            string yesOrNo;

            do
            {
                Console.WriteLine("Do you want to print all the enrolled students? Y/N");
                yesOrNo = Console.ReadLine();
            } while (yesOrNo != "Y" && yesOrNo != "N");

            if (yesOrNo == "Y")
            {

                for (int i = 0; i < 50; i++)
                {
                    for (int j = 0; j < 50; j++)
                    {
                        Console.Write(enrolledStudentsList[i, j] + "   ");
                    }

                    Console.WriteLine();

                }

            }
        }

        public static void makeStudent()
        {
            int i = 0;
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

                    studentList[i].setFirstName();
                    studentList[i].setLastName();
                    //studentList[i].setDateOfBirth();
                    //studentList[i].setFees();

                    selectCourse();
                    printStudentsPerCourseList();

                }

                i++;

            } while (yesOrNo == "Y");

        }

        public static void printAllStudents()
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
                    onoma.printStudentName();
                }

            }


        }




}
}
