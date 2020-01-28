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

        public static List<List<Trainer>> trainersPerCourseList = new List<List<Trainer>>();

        public Trainer() { }

        public Trainer(string firstName, string lastName, string subject)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.subject = subject;
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

        public void SetSubject()
        {
            Console.WriteLine("Please enter your subject: ");
            subject = Console.ReadLine();
        }

        public string GetSubject()
        {
            return subject;
        }

        public void PrintTrainer()
        {
            Console.WriteLine("Your Trainer's first name is: " + GetFirstName());
            Console.WriteLine("Your Trainer's last name is: " + GetLastName());
            Console.WriteLine("Your Trainer's subject is: " + GetSubject());
        }

        public void PrintTrainerName()
        {
            Console.WriteLine("Your Trainer's name is: " + GetFirstName() + " " + GetLastName());
        }

        public string GetFullName()
        {
            string fullName = GetFirstName() + " " + GetLastName();
            return fullName;
        }

        public void PrintTrainerFullName()
        {
            Console.WriteLine(GetFirstName() + " " + GetLastName());
        }

        public static void SelectCourse()
        {
            string yesOrNo;

            do
            {
                Console.WriteLine("Do you want to select a trainer? Y/N");
                yesOrNo = Console.ReadLine();
            } while (yesOrNo != "Y" && yesOrNo != "N");

            if (yesOrNo == "Y")
            {
                Console.WriteLine("  --Trainer Names--  ");

                for (int i = 0; i < Trainer.trainerList.Count; i++)
                {
                    Console.Write((i + 1) + ". ");
                    Trainer.trainerList[i].PrintTrainerFullName();
                }

                int option;

                List<Trainer> sublist = new List<Trainer>();

                do
                {

                    Console.WriteLine("Enter your option: ");
                    option = Convert.ToInt32(Console.ReadLine());


                    for (int i = 0; i < Trainer.trainerList.Count; i++)
                    {
                        if ((option - 1) == i)
                        {
                            sublist.Add(Trainer.trainerList[i]);
                        }
                    }

                    do
                    {
                        Console.WriteLine("Do you want to select another trainer? Y/N");
                        yesOrNo = Console.ReadLine();
                    } while (yesOrNo != "Y" && yesOrNo != "N");

                } while (yesOrNo == "Y");

                trainersPerCourseList.Add(sublist);

            }
        }

        public static void PrintTrainersPerCourseList()
        {

            string yesOrNo;

            do
            {
                Console.WriteLine("Do you want to print all the courses with trainers? Y/N");
                yesOrNo = Console.ReadLine();
            } while (yesOrNo != "Y" && yesOrNo != "N");

            if (yesOrNo == "Y")
            {
                int i = 0;

                foreach (var sublist in trainersPerCourseList)
                {
                    Console.WriteLine("---" + Course.courseList[i].GetTitle() + "---");
                    i++;

                    foreach (var value in sublist)
                    {
                        Console.WriteLine(value.GetFullName());
                    }
                    Console.WriteLine();
                }

            }
        }

        public static void MakeTrainer()
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

                    trainerList[i].SetFirstName();
                    trainerList[i].SetLastName();
                    //trainerList[i].SetSubject();
                }

                i++;

            } while (yesOrNo == "Y");

        }

        public static void PrintAllTrainers()
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
                    onoma.PrintTrainerName();
                }

            }


        }
    

    }
}
