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

            //data.PrintAllStudents();
            data.PrintAllTrainers();
            data.PrintAllCourses();
            //data.PrintAllAssignments();
            //data.PrintCoursesPerStudent();
            //data.PrintAssignmentsPerStudent();
            //data.PrintAssignmentsPerCourse();
            //data.PrintStudentsPerCourse();
            data.PrintTrainersPerCourse();
        }
    }

    class Data
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();
        public List<Trainer> Trainers { get; set; } = new List<Trainer>();
        public List<CoursePerStudent> CoursesPerStudent { get; set; } = new List<CoursePerStudent>();
        public List<AssignmentPerStudent> AssignmentsPerStudent { get; set; } = new List<AssignmentPerStudent>();
        public List<AssignmentPerCourse> AssignmentsPerCourse { get; set; } = new List<AssignmentPerCourse>();
        public List<StudentPerCourse> StudentsPerCourse { get; set; } = new List<StudentPerCourse>();
        public List<TrainerPerCourse> TrainersPerCourse { get; set; } = new List<TrainerPerCourse>();

        public Data()
        {
            //MakeStudents();
            MakeTrainers();
            MakeCourses();
            //CoursesPerStu();
            //MakeAssignments();
            //AssignmentsPerStu();
            //AssignmentsPerCour();
            //StudentsPerCour();
            TrainersPerCour();
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

        public void AssignmentsPerCour()
        {
            foreach (var mathima in Courses)
            {
                List<Assignment> courAssign = new List<Assignment>();

                string flag;

                do
                {
                    PrintAllAssignments();

                    Console.WriteLine("Enter the number of your assignment for " + mathima.Title + ":");
                    int option = Convert.ToInt32(Console.ReadLine());
                    courAssign.Add(Assignments[option - 1]);

                    do
                    {
                        Console.WriteLine("Do you want to enroll in another assignment? Y/N");
                        flag = Console.ReadLine();
                    } while (flag != "Y" && flag != "N");

                } while (flag == "Y");

                AssignmentPerCourse AssiPerCour = new AssignmentPerCourse(mathima, courAssign);
                AssignmentsPerCourse.Add(AssiPerCour);
            }
        }

        public void StudentsPerCour()
        {
            foreach (var mathima in Courses)
            {
                List<Student> courStu = new List<Student>();

                string flag;

                do
                {
                    PrintAllStudents();

                    Console.WriteLine("Enter the number of your student for " + mathima.Title + ":");
                    int option = Convert.ToInt32(Console.ReadLine());
                    courStu.Add(Students[option - 1]);

                    do
                    {
                        Console.WriteLine("Do you want to enter another student? Y/N");
                        flag = Console.ReadLine();
                    } while (flag != "Y" && flag != "N");

                } while (flag == "Y");

                StudentPerCourse StuPerCour = new StudentPerCourse(mathima, courStu);
                StudentsPerCourse.Add(StuPerCour);
            }
        }

        public void TrainersPerCour()
        {
            foreach (var mathima in Courses)
            {
                List<Trainer> courTrain = new List<Trainer>();

                string flag;

                do
                {
                    PrintAllTrainers();

                    Console.WriteLine("Enter the number of your trainer for " + mathima.Title + ":");
                    int option = Convert.ToInt32(Console.ReadLine());
                    courTrain.Add(Trainers[option - 1]);

                    do
                    {
                        Console.WriteLine("Do you want to enter another trainer? Y/N");
                        flag = Console.ReadLine();
                    } while (flag != "Y" && flag != "N");

                } while (flag == "Y");

                TrainerPerCourse TrainPerCour = new TrainerPerCourse(mathima, courTrain);
                TrainersPerCourse.Add(TrainPerCour);
            }
        }

        //8a to xreiastoume gia to more than one courses
        public void CoursesPerStu()
        {
            foreach (var mathitis in Students)
            {
                List<Course> stuCour = new List<Course>();

                string flag;

                do
                {
                    PrintAllCourses();

                    Console.WriteLine("Enter the number of your course for " + mathitis.Name + ":");
                    int option = Convert.ToInt32(Console.ReadLine());
                    stuCour.Add(Courses[option - 1]);

                    do
                    {
                        Console.WriteLine("Do you want to enroll in another course? Y/N");
                        flag = Console.ReadLine();
                    } while (flag != "Y" && flag != "N");

                } while (flag == "Y");

                CoursePerStudent courPerStu = new CoursePerStudent(mathitis, stuCour);
                CoursesPerStudent.Add(courPerStu);
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

        public void MakeCourses()
        {
            string flag;

            do
            {

                do
                {
                    Console.WriteLine("Do you want to enter a new course? Y/N");
                    flag = Console.ReadLine();
                } while (flag != "Y" && flag != "N");

                if (flag == "Y")
                {
                    MakeCourse();
                }

            } while (flag == "Y");
        }

        public void MakeCourse()
        {
            Course newCour = new Course();
            Courses.Add(newCour);

            Console.WriteLine("Enter course's title: ");
            newCour.Title = Console.ReadLine();
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

        public void PrintAllCourses()
        {
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ALL Courses");
            foreach (var item in Courses)
            {
                Console.Write(counter + ". ");
                item.Output();
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------");
        }

        //8a to xreiastoume gia ta more than one courses
        public void PrintCoursesPerStudent()
        {
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Courses per Student");
            foreach (var item in CoursesPerStudent)
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

        public void PrintAssignmentsPerCourse()
        {
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Assignments per Course");
            foreach (var item in AssignmentsPerCourse)
            {
                Console.Write(counter + ". ");
                item.Output();
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintStudentsPerCourse()
        {
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Students per Course");
            foreach (var item in StudentsPerCourse)
            {
                Console.Write(counter + ". ");
                item.Output();
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintTrainersPerCourse()
        {
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Trainers per Course");
            foreach (var item in TrainersPerCourse)
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
        public List<Course> Courses { get; set; }
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

    class Course
    {
        public string Title { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Student> Students { get; set; }
        public List<Trainer> Trainers { get; set; }


        public Course()
        {

        }

        public Course(string title)
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


    class CoursePerStudent
    {
        Student Student { get; set; }


        public CoursePerStudent(Student student, List<Course> courses)
        {
            Student = student;

            student.Courses = courses;
        }

        public void Output()
        {
            int counter = 1;
            Console.WriteLine(Student.Name);
            foreach (var item in Student.Courses)
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

    class AssignmentPerCourse
    {
        Course Course { get; set; }


        public AssignmentPerCourse(Course course, List<Assignment> assignments)
        {
            Course = course;

            course.Assignments = assignments;
        }

        public void Output()
        {
            int counter = 1;
            Console.WriteLine(Course.Title);
            foreach (var item in Course.Assignments)
            {
                Console.Write("   " + counter + ". ");
                item.Output();
                counter++;
            }
        }
    }

    class StudentPerCourse
    {
        Course Course { get; set; }


        public StudentPerCourse(Course course, List<Student> students)
        {
            Course = course;

            course.Students = students;
        }

        public void Output()
        {
            int counter = 1;
            Console.WriteLine(Course.Title);
            foreach (var item in Course.Students)
            {
                Console.Write("   " + counter + ". ");
                item.Output();
                counter++;
            }
        }
    }

    class TrainerPerCourse
    {
        Course Course { get; set; }


        public TrainerPerCourse(Course course, List<Trainer> trainers)
        {
            Course = course;

            course.Trainers = trainers;
        }

        public void Output()
        {
            int counter = 1;
            Console.WriteLine(Course.Title);
            foreach (var item in Course.Trainers)
            {
                Console.Write("   " + counter + ". ");
                item.Output();
                counter++;
            }
        }
    }


}
