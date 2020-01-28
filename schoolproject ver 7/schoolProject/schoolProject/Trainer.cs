using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject
{
    class Trainer
    {
        private string firstName;
        private string lastName;
        private string subject;

        public static List<Trainer> trainerList = new List<Trainer>();

        public static List<List<Course>> trainersPerCourseList = new List<List<Course>>();

        public Trainer() { }

        public Trainer(string firstName, string lastName, string subject)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.subject = subject;
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

        public void setSubject()
        {
            Console.WriteLine("Please enter your subject: ");
            subject = Console.ReadLine();
        }

        public string getSubject()
        {
            return subject;
        }

        public void printTrainer()
        {
            Console.WriteLine("Your Trainer's first name is: " + getFirstName());
            Console.WriteLine("Your Trainer's last name is: " + getLastName());
            Console.WriteLine("Your Trainer's subject is: " + getSubject());
        }

        public void printTrainerName()
        {
            Console.WriteLine("Your Trainer's name is: " + getFirstName() + " " + getLastName());
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
                Console.WriteLine("  --Course Titles--  ");

                for (int i = 0; i < Course.courseList.Count; i++)
                {
                    Console.Write((i + 1) + ". ");
                    Course.courseList[i].printCourseName();
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

                trainersPerCourseList.Add(sublist);

            }
        }

        public static void printTrainersPerCourseList()
        {

            string yesOrNo;

            do
            {
                Console.WriteLine("Do you want to print all the assigned trainers? Y/N");
                yesOrNo = Console.ReadLine();
            } while (yesOrNo != "Y" && yesOrNo != "N");

            if (yesOrNo == "Y")
            {
                int i = 0;

                foreach (var sublist in trainersPerCourseList)
                {
                    Console.WriteLine("---" + trainerList[i].getFullName() + "---");
                    i++;

                    foreach (var value in sublist)
                    {
                        Console.WriteLine(value.getTitle());
                    }
                    Console.WriteLine();
                }

            }
        }

        public static void makeTrainer()
        {

            int i = 0;
            string yesOrNo;

            do
            {

                do
                {
                    Console.WriteLine("Do you want to enter a new trainer? Y/N");
                    yesOrNo = Console.ReadLine();
                } while (yesOrNo != "Y" && yesOrNo != "N");

                if (yesOrNo == "Y")
                {
                    trainerList.Add(new Trainer());

                    trainerList[i].setFirstName();
                    trainerList[i].setLastName();
                    //trainerList[i].setSubject();

                    selectCourse();
                    printTrainersPerCourseList();
                }

                i++;

            } while (yesOrNo == "Y");

        }

        public static void printAllTrainers()
        {
            string yesOrNo;
            int counter = 1;

            do
            {
                Console.WriteLine("Do you want to print all the trainers? Y/N");
                yesOrNo = Console.ReadLine();
            } while (yesOrNo != "Y" && yesOrNo != "N");

            if (yesOrNo == "Y")
            {
                Console.WriteLine("  --Trainer Names--  ");

                foreach (Trainer onoma in trainerList)
                {
                    Console.Write(counter + ". ");
                    onoma.printTrainerName();
                }

            }


        }
    

    }
}
