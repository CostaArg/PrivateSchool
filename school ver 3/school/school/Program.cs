using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();

            data.PrintAllStudents();
            //data.PrintAllProjects();
            data.PrintAllAssignments();
            //data.PrintProjectsPerStudent();
            data.PrintAssignmentsPerStudent();
        }
    }

    class Data
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Project> Projects { get; set; } = new List<Project>();
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();
        public List<Trainer> Trainers { get; set; } = new List<Trainer>();
        public List<ProjectPerStudent> ProjectsPerStudent { get; set; } = new List<ProjectPerStudent>();
        public List<AssignmentPerStudent> AssignmentsPerStudent { get; set; } = new List<AssignmentPerStudent>();

        public Data()
        {
            MakeStudents();
            //MakeProjects();
            //CoursesPerStu();
            MakeAssignments();
            AssignmentsPerStu();
        }

        public void AssignmentsPerStu()
        {
            foreach (var mathitis in Students)
            {
                List<Assignment> stuAssign = new List<Assignment>();

                string flag;

                do
                {
                    PrintAllAssignments();

                    Console.WriteLine("Enter the number of your assignment for " + mathitis.Name + ":");
                    int option = Convert.ToInt32(Console.ReadLine());
                    stuAssign.Add(Assignments[option - 1]);

                    do
                    {
                        Console.WriteLine("Do you want to enroll in another assignment? Y/N");
                        flag = Console.ReadLine();
                    } while (flag != "Y" && flag != "N");

                } while (flag == "Y");

                AssignmentPerStudent AssiPerStu = new AssignmentPerStudent(mathitis, stuAssign);
                AssignmentsPerStudent.Add(AssiPerStu);
            }
        }

        //8a to xreiastoume gia to more than one courses
        public void CoursesPerStu()
        {
            foreach (var mathitis in Students)
            {
                List<Project> stuProj = new List<Project>();

                string flag;

                do
                {
                    PrintAllProjects();

                    Console.WriteLine("Enter the number of your project for " + mathitis.Name + ":");
                    int option = Convert.ToInt32(Console.ReadLine());
                    stuProj.Add(Projects[option - 1]);

                    do
                    {
                        Console.WriteLine("Do you want to enroll in another project? Y/N");
                        flag = Console.ReadLine();
                    } while (flag != "Y" && flag != "N");

                } while (flag == "Y");

                ProjectPerStudent proPerStu = new ProjectPerStudent(mathitis, stuProj);
                ProjectsPerStudent.Add(proPerStu);
            }
        }

        public void MakeStudents()
        {
            string flag;

            do
            {
                do
                {
                    Console.WriteLine("Do you want to enter a new student? Y/N");
                    flag = Console.ReadLine();
                } while (flag != "Y" && flag != "N");

                if (flag == "Y")
                {
                    MakeStudent();
                }

            } while (flag == "Y");
        }
        public void MakeStudent()
        {
            Student newStu = new Student();
            Students.Add(newStu);

            Console.WriteLine("Enter your first name: ");
            newStu.Name = Console.ReadLine();
        }

        public void MakeProjects()
        {
            string flag;

            do
            {

                do
                {
                    Console.WriteLine("Do you want to enter a new project? Y/N");
                    flag = Console.ReadLine();
                } while (flag != "Y" && flag != "N");

                if (flag == "Y")
                {
                    MakeProject();
                }

            } while (flag == "Y");
        }

        public void MakeProject()
        {
            Project newProj = new Project();
            Projects.Add(newProj);

            Console.WriteLine("Enter course's title: ");
            newProj.Title = Console.ReadLine();
        }

        public void MakeAssignments()
        {
            string flag;

            do
            {

                do
                {
                    Console.WriteLine("Do you want to enter a new assignment? Y/N");
                    flag = Console.ReadLine();
                } while (flag != "Y" && flag != "N");

                if (flag == "Y")
                {
                    MakeAssignment();
                }

            } while (flag == "Y");
        }

        public void MakeAssignment()
        {
            Assignment newAssign = new Assignment();
            Assignments.Add(newAssign);

            Console.WriteLine("Enter assignment's title: ");
            newAssign.Title = Console.ReadLine();
        }

        public void MakeTrainers()
        {
            string flag;

            do
            {

                do
                {
                    Console.WriteLine("Do you want to enter a new trainer? Y/N");
                    flag = Console.ReadLine();
                } while (flag != "Y" && flag != "N");

                if (flag == "Y")
                {
                    MakeTrainer();
                }

            } while (flag == "Y");
        }

        public void MakeTrainer()
        {
            Trainer newTrain = new Trainer();
            Trainers.Add(newTrain);

            Console.WriteLine("Enter trainer's name: ");
            newTrain.Name = Console.ReadLine();
        }

        public void PrintAllAssignments()
        {
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ALL ASSIGNMENTS");
            foreach (var item in Assignments)
            {
                Console.Write(counter + ". ");
                item.Output();
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------");
        }

        public void PrintAllTrainers()
        {
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ALL TRAINERS");
            foreach (var item in Trainers)
            {
                Console.Write(counter + ". ");
                item.Output();
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------");
        }

        public void PrintAllStudents()
        {
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ALL STUDENTS");
            foreach (var item in Students)
            {
                Console.Write(counter + ". ");
                item.Output();
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------");
        }

        public void PrintAllProjects()
        {
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ALL Projects");
            foreach (var item in Projects)
            {
                Console.Write(counter + ". ");
                item.Output();
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------");
        }

        //8a to xreiastoume gia ta more than one courses
        public void PrintProjectsPerStudent()
        {
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Projects per Student");
            foreach (var item in ProjectsPerStudent)
            {
                Console.Write(counter + ". ");
                item.Output();
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintAssignmentsPerStudent()
        {
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Assignments per Student");
            foreach (var item in AssignmentsPerStudent)
            {
                Console.Write(counter + ". ");
                item.Output();
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
    class Student
    {
        public string Name { get; set; }
        public List<Project> Projects { get; set; }
        public List<Assignment> Assignments { get; set; }

        public Student()
        {

        }

        public Student(string name)
        {
            Name = name;
        }
        public void Output()
        {
            Console.WriteLine(Name);
        }
    }

    class Project
    {
        public string Title { get; set; }

        public Project()
        {

        }

        public Project(string title)
        {
            Title = title;
        }

        public void Output()
        {
            Console.WriteLine(Title);
        }
    }

    class Assignment
    {
        public string Title { get; set; }

        public Assignment()
        {

        }

        public Assignment(string title)
        {
            Title = title;
        }

        public void Output()
        {
            Console.WriteLine(Title);
        }
    }

    class Trainer
    {
        public string Name { get; set; }

        public Trainer()
        {

        }

        public Trainer(string name)
        {
            Name = name;
        }

        public void Output()
        {
            Console.WriteLine(Name);
        }
    }


    class ProjectPerStudent
    {
        Student Student { get; set; }


        public ProjectPerStudent(Student student, List<Project> projects)
        {
            Student = student;

            student.Projects = projects;
        }

        public void Output()
        {
            int counter = 1;
            Console.WriteLine(Student.Name);
            foreach (var item in Student.Projects)
            {
                Console.Write("   " + counter + ". ");
                item.Output();
                counter++;
            }
        }
    }

    class AssignmentPerStudent
    {
        Student Student { get; set; }


        public AssignmentPerStudent(Student student, List<Assignment> assignments)
        {
            Student = student;

            student.Assignments = assignments;
        }

        public void Output()
        {
            int counter = 1;
            Console.WriteLine(Student.Name);
            foreach (var item in Student.Assignments)
            {
                Console.Write("   " + counter + ". ");
                item.Output();
                counter++;
            }
        }
    }
}
