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

        public string getFullName()
        {
            string fullName = getFirstName() + " " + getLastName();
            return fullName;
        }

        public static void selectCourse()
        {
            string yesOrNo;

            do
            {
                Console.WriteLine("Do you want to select a course? Y/N");
                yesOrNo = Console.ReadLine();
            } while (yesOrNo != "Y" && yesOrNo != "N");

            if (yesOrNo == "Y")
            {

                do
                {

                    Console.WriteLine("  --Course Titles--  ");

                    for (int i = 0; i < Course.courseList.Count; i++)
                    {
                        Console.Write((i + 1) + ". ");
                        Course.courseList[i].printCourseName();
                    }

                    Console.WriteLine("Select the course you want to enroll a student: ");
                    int optionCourse = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < Course.courseList.Count; i++)
                    {
                        if ((optionCourse - 1) == i)
                        {

                            List<Student> sublist = new List<Student>();

                       

                                Console.WriteLine("  --Name and Surname--  ");

                                for (int k = 0; k < Student.studentList.Count; k++)
                                {
                                    Console.Write((k + 1) + ". ");
                                    Student.studentList[k].printStudentName();
                                }

                                Console.WriteLine("Select the student you want to enroll: ");
                                int optionStudent = Convert.ToInt32(Console.ReadLine());

                                for (int j = 0; j < Student.studentList.Count; j++)
                                {
                                    if ((optionStudent - 1) == j)
                                    {
                                        sublist.Add(Student.studentList[j]);
                                        Console.WriteLine("Successfully added " + Student.studentList[j].getFullName() + " to " + Course.courseList[i].getTitle());
                                    }
                                }

                            studentsPerCourseList.Add(sublist);

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
                int i = 0;

                foreach (var sublist in studentsPerCourseList)
                {
                    Console.WriteLine("---" + Course.courseList[i].getTitle() + "---");
                    i++;

                    foreach (var value in sublist)
                    {
                        Console.WriteLine(value.getFullName());
                    }
                    Console.WriteLine();
                }

            }
        }

        public static void makeStudent()
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

                    studentList[counter].setFirstName();
                    studentList[counter].setLastName();
                    //studentList[counter].setDateOfBirth();
                    //studentList[counter].setFees();

                    selectCourse();
                    printStudentsPerCourseList();

                }

                counter++;

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
