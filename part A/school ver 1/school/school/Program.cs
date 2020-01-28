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
            data.PrintAllProjects();
            data.PrintProjectsPerStudent();
        }
    }

    class Data
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Project> Projects { get; set; } = new List<Project>();
        public List<ProjectPerStudent> ProjectsPerStudent { get; set; } = new List<ProjectPerStudent>();

        public Data()
        {
            //Dimiourgia mathiton + tous rixno stin megali lista me tous mathites

            void MakeStudents()
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

            void MakeStudent()
            {
                Student newStu = new Student();
                Students.Add(newStu);

                Console.WriteLine("Enter your first name: ");
                newStu.Name = Console.ReadLine();
            }

            //Dimiourgia projects + ta rixno stin megali lista me ta projects

            void MakeProjects()
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

            void MakeProject()
            {
                Project newProj = new Project();
                Projects.Add(newProj);

                Console.WriteLine("Enter course's title: ");
                newProj.Title = Console.ReadLine();
            }

            MakeStudents();
            MakeProjects();



            //Dimiourgo mikres listes gia ta projects tou kathe mathiti + bazo stis listes ta projects 

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

                // Kai tora antistoixo ton kathe mathiti me tis listes ton project tou xrisimopoiontas tin endiamesi klassi + kai ola ta parapano stin lista ProjectsPerStudent

                ProjectPerStudent SPP = new ProjectPerStudent(mathitis, stuProj);
                ProjectsPerStudent.Add(SPP);
            }




        }


        public void PrintAllStudents()
        {
            int counter = 1;
            // All students
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
            // All Projects
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
        public void PrintProjectsPerStudent()
        {
            int counter = 1;
            //Projects per student
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

    }

    class Student
    {
        public string Name { get; set; }
        public List<Project> Projects { get; set; }

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
}
