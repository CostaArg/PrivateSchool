using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Data data = new Data();

            while (true)
            {

                string option = SelectOption();

                if (option == "1")
                {
                    data.PrintDbInfo();
                }
                else if (option == "2")
                {
                    data.MakeStudents();

                    foreach (var item in data.Students)
                    {
                        Services.InsertStudent(item);
                    }

                }
                else if (option == "3")
                {
                    data.MakeCourses();

                    foreach (var item in data.Courses)
                    {
                        Services.InsertCourse(item);
                    }

                }
                else if (option == "4")
                {
                    data.MakeTrainers();

                    foreach (var item in data.Trainers)
                    {
                        Services.InsertTrainer(item);
                    }

                }
                else if (option == "5")
                {
                    data.MakeAssignments();

                    foreach (var item in data.Assignments)
                    {
                        Services.InsertAssignment(item);
                    }

                }
                else if (option == "6")
                {
                    data.PutStudentsInCourses();

                    foreach (var item in data.StuCourIdList)
                    {
                        Services.InsertStudentPerCourse(item);
                    }
                }
                else if (option == "7")
                {
                    data.PutTrainersInCourses();

                    foreach (var item in data.TrainCourIdList)
                    {
                        Services.InsertTrainerPerCourse(item);
                    }
                }
                else if (option == "8")
                {
                    data.PutAssignmentsInStudentsInCourses();

                    foreach (var item in data.AssiStuCourIdList)
                    {
                        Services.InsertAssignmentPerStudentPerCourse(item);
                    }
                }
                else if (option == "STOP")
                {
                    Environment.Exit(0);
                }
            }
        }

        public static string SelectOption()
        {
            Console.WriteLine("Select an option or enter STOP to exit:");
            Console.WriteLine("1. Print Information");
            Console.WriteLine("2. Insert Student");
            Console.WriteLine("3. Insert Course");
            Console.WriteLine("4. Insert Trainer");
            Console.WriteLine("5. Insert Assignment");
            Console.WriteLine("6. Insert Student Per Course");
            Console.WriteLine("7. Insert Trainer Per Course");
            Console.WriteLine("8. Insert Assignment Per Student Per Course");

            string option = Console.ReadLine();
            return option;
        }
    }

    class Data
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();
        public List<Trainer> Trainers { get; set; } = new List<Trainer>();

        public List<StuCourId> StuCourIdList { get; set; } = new List<StuCourId>();
        public List<TrainCourId> TrainCourIdList { get; set; } = new List<TrainCourId>();
        public List<AssiStuCourId> AssiStuCourIdList { get; set; } = new List<AssiStuCourId>();

        public Data()
        {

        }

        public void PrintDbInfo()
        {
            //A list of all the students
            var stuList = Services.GetAllStudents();

            foreach (var item in stuList)
            {
                item.Output();
            }

            //A list of all the trainers
            var trainList = Services.GetAllTrainers();

            foreach (var item in trainList)
            {
                item.Output();
            }

            //A list of all the assignments
            var assignList = Services.GetAllAssignments();

            foreach (var item in assignList)
            {
                item.Output();
            }

            //A list of all the courses
            var courList = Services.GetAllCourses();

            foreach (var item in courList)
            {
                item.Output();
            }

            //A list of all the students per course
            var stuPerCourList = Services.GetAllStuPerCour();

            foreach (var item in stuPerCourList)
            {
                Console.WriteLine("===========================================================");
                Console.WriteLine("Student ID: " + item.Student.StudentId + "  Course ID: " + item.Course.CourseId);
                Console.WriteLine();
                item.OutputStudent();
                item.OutputCourse();
                Console.WriteLine("===========================================================");
            }

            //A list of all the trainers per course
            var trainPerCourList = Services.GetAllTrainPerCour();

            foreach (var item in trainPerCourList)
            {
                Console.WriteLine("===========================================================");
                Console.WriteLine("Trainer ID: " + item.Trainer.TrainerId + "  Course ID: " + item.Course.CourseId);
                Console.WriteLine();
                item.OutputTrainer();
                item.OutputCourse();
                Console.WriteLine("===========================================================");
            }

            //A list of all the assignments per course
            var assiPerCourList = Services.GetAllAssiPerCour();

            foreach (var item in assiPerCourList)
            {
                Console.WriteLine("===========================================================");
                Console.WriteLine("Assignment ID: " + item.Assignment.AssignmentId + "  Course ID: " + item.Course.CourseId);
                Console.WriteLine();
                item.OutputAssignment();
                item.OutputCourse();
                Console.WriteLine("===========================================================");

            }

            //A list of all the assignments per course per student
            var assiPerCourPerStu = Services.GetAllAssiPerCourPerStu();

            foreach (var item in assiPerCourPerStu)
            {
                Console.WriteLine("===========================================================");
                Console.WriteLine("Assignment ID: " + item.Assignment.AssignmentId + " Course ID: " + item.Course.CourseId +
                    " Student ID: " + item.Student.StudentId);
                Console.WriteLine();
                item.OutputAssignment();
                item.OutputCourse();
                item.OutputStudent();
                Console.WriteLine("===========================================================");
            }

            //Console.WriteLine("Enter date yyyy-mm-dd : ");
            //string givenDate = Console.ReadLine();

            //if (DateTime.TryParse(givenDate, out DateTime correctDate))
            //{

            //}
            //else
            //{
            //    Console.WriteLine("Error: Date could not be parsed");
            //    Console.WriteLine("Will put synthetic data");
            //    correctDate = new DateTime(2020, 3, 25);
            //}

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

            Console.WriteLine("Enter student's first name: ");
            newStu.FirstName = Console.ReadLine();

            if (newStu.FirstName.Length < 1)
            {
                Console.WriteLine("First name was left empty");
                Console.WriteLine("Will put synthetic data");
                newStu.FirstName = "Basilis";
            }

            Console.WriteLine("Enter student's last name: ");
            newStu.LastName = Console.ReadLine();

            if (newStu.LastName.Length < 1)
            {
                Console.WriteLine("Last name was left empty");
                Console.WriteLine("Will put synthetic data");
                newStu.LastName = "Karantonis";
            }

            try
            {
                Console.WriteLine("Enter student's date of birth yyyy-mm-dd : ");
                newStu.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Will put synthetic data");
                newStu.DateOfBirth = new DateTime(1995, 11, 20);
            }

            try
            {
                Console.WriteLine("Enter student's tuition fees: ");
                newStu.TuitionFees = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Will put synthetic data");
                newStu.TuitionFees = 1000;
            }
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

            Console.WriteLine("Enter trainer's first name: ");
            newTrain.FirstName = Console.ReadLine();

            if (newTrain.FirstName.Length < 1)
            {
                Console.WriteLine("First name was left empty");
                Console.WriteLine("Will put synthetic data");
                newTrain.FirstName = "Xaralampos";
            }

            Console.WriteLine("Enter trainer's last name: ");
            newTrain.LastName = Console.ReadLine();

            if (newTrain.LastName.Length < 1)
            {
                Console.WriteLine("Last name was left empty");
                Console.WriteLine("Will put synthetic data");
                newTrain.LastName = "Lampropoulos";
            }

            Console.WriteLine("Enter trainer's subject: ");
            newTrain.Subject = Console.ReadLine();

            if (newTrain.Subject.Length < 1)
            {
                Console.WriteLine("Subject was left empty");
                Console.WriteLine("Will put synthetic data");
                newTrain.Subject = "UNIX Systems";
            }
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

            if (newAssign.Title.Length < 1)
            {
                Console.WriteLine("Title was left empty");
                Console.WriteLine("Will put synthetic data");
                newAssign.Title = "Project Chat";
            }

            Console.WriteLine("Enter assignment's description: ");
            newAssign.Description = Console.ReadLine();

            if (newAssign.Description.Length < 1)
            {
                Console.WriteLine("Description was left empty");
                Console.WriteLine("Will put synthetic data");
                newAssign.Description = "Online messaging system";
            }

            try
            {
                Console.WriteLine("Enter assignment's sub date time: ");
                newAssign.SubDateTime = Convert.ToDateTime(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Will put synthetic data");
                newAssign.SubDateTime = new DateTime(2020, 10, 4);
            }

            try
            {
                Console.WriteLine("Enter assignment's oral mark: ");
                newAssign.OralMark = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Will put synthetic data");
                newAssign.OralMark = 10;
            }

            try
            {
                Console.WriteLine("Enter assignment's total mark: ");
                newAssign.TotalMark = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Will put synthetic data");
                newAssign.TotalMark = 100;
            }
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

            if (newCour.Title.Length < 1)
            {
                Console.WriteLine("Title was left empty");
                Console.WriteLine("Will put synthetic data");
                newCour.Title = "HTML";
            }

            Console.WriteLine("Enter course's stream: ");
            newCour.Stream = Console.ReadLine();

            if (newCour.Stream.Length < 1)
            {
                Console.WriteLine("Stream was left empty");
                Console.WriteLine("Will put synthetic data");
                newCour.Stream = "Web Development";
            }

            Console.WriteLine("Enter course's type: ");
            newCour.Type = Console.ReadLine();

            if (newCour.Type.Length < 1)
            {
                Console.WriteLine("Type was left empty");
                Console.WriteLine("Will put synthetic data");
                newCour.Type = "Practical Subject";
            }

            try
            {
                Console.WriteLine("Enter course's start date: ");
                newCour.StartDate = Convert.ToDateTime(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Will put synthetic data");
                newCour.StartDate = new DateTime(2020, 5, 10);
            }

            try
            {
                Console.WriteLine("Enter course's end date: ");
                newCour.EndDate = Convert.ToDateTime(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Will put synthetic data");
                newCour.EndDate = new DateTime(2020, 11, 22);
            }
        }


        public void PutStudentsInCourses()
        {
            Console.WriteLine("Enter student id: ");
            int stuId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter course id: ");
            int courId = Convert.ToInt32(Console.ReadLine());

            Student newStu = new Student();
            Course newCour = new Course();

            newStu.StudentId = stuId;
            newCour.CourseId = courId;

            StuCourId scid = new StuCourId(newStu.StudentId, newCour.CourseId);

            StuCourIdList.Add(scid);
        }

        public void PutTrainersInCourses()
        {
            Console.WriteLine("Enter trainer id: ");
            int trainId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter course id: ");
            int courId = Convert.ToInt32(Console.ReadLine());

            Trainer newTrain = new Trainer();
            Course newCour = new Course();

            newTrain.TrainerId = trainId;
            newCour.CourseId = courId;

            TrainCourId tcid = new TrainCourId(newTrain.TrainerId, newCour.CourseId);

            TrainCourIdList.Add(tcid);
        }

        public void PutAssignmentsInStudentsInCourses()
        {
            Console.WriteLine("Enter assignment id: ");
            int assiId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter student id: ");
            int stuId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter course id: ");
            int courId = Convert.ToInt32(Console.ReadLine());

            Assignment newAssi = new Assignment();
            Student newStu = new Student();
            Course newCour = new Course();

            newAssi.AssignmentId = assiId;
            newStu.StudentId = stuId;
            newCour.CourseId = courId;

            AssiStuCourId ascid = new AssiStuCourId(newAssi.AssignmentId, newStu.StudentId, newCour.CourseId);

            AssiStuCourIdList.Add(ascid);
        }

    }

    class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int TuitionFees { get; set; }

        public Student()
        {

        }

        public Student(int studentid, string firstname, string lastname, DateTime dateofbirth, int tuitionfees)
        {
            StudentId = studentid;
            FirstName = firstname;
            LastName = lastname;
            DateOfBirth = dateofbirth;
            TuitionFees = tuitionfees;
        }

        public void Output()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("First Name:    " + FirstName);
            Console.WriteLine("Last Name:     " + LastName);
            Console.WriteLine("Date of Birth: " + DateOfBirth.ToShortDateString());
            Console.WriteLine("Tuition Fees:  " + TuitionFees);
            Console.WriteLine("--------------");
        }
    }

    class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Stream { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Course()
        {

        }

        public Course(int courseid, string title, string stream, string type, DateTime startdate, DateTime enddate)
        {
            CourseId = courseid;
            Title = title;
            Stream = stream;
            Type = type;
            StartDate = startdate;
            EndDate = enddate;
        }

        public void Output()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("Title:         " + Title);
            Console.WriteLine("Stream:        " + Stream);
            Console.WriteLine("Type:          " + Type);
            Console.WriteLine("Start Date:    " + StartDate.ToShortDateString());
            Console.WriteLine("End Date:      " + EndDate.ToShortDateString());
            Console.WriteLine("--------------");
        }
    }

    class Trainer
    {
        public int TrainerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public Trainer()
        {

        }

        public Trainer(int trainerid, string firstname, string lastname, string subject)
        {
            TrainerId = trainerid;
            FirstName = firstname;
            LastName = lastname;
            Subject = subject;
        }

        public void Output()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("First Name:    " + FirstName);
            Console.WriteLine("Last Name:     " + LastName);
            Console.WriteLine("Subject:       " + Subject);
            Console.WriteLine("--------------");
        }
    }

    class Assignment
    {
        public int AssignmentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubDateTime { get; set; }
        public double OralMark { get; set; }
        public double TotalMark { get; set; }

        public Assignment()
        {

        }

        public Assignment(int assignmentid, string title, string description, DateTime subdatetime, double oralmark, double totalmark)
        {
            AssignmentId = assignmentid;
            Title = title;
            Description = description;
            SubDateTime = subdatetime;
            OralMark = oralmark;
            TotalMark = totalmark;
        }

        public void Output()
        {
            Console.WriteLine("-------------");
            Console.WriteLine("Title:       " + Title);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("SubDateTime: " + SubDateTime.ToShortDateString());
            Console.WriteLine("OralMark:    " + OralMark);
            Console.WriteLine("TotalMark:   " + TotalMark);
            Console.WriteLine("-------------");
        }

        public void OutputTitle()
        {
            Console.WriteLine(Title);
        }
    }


    class StuCourId
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public StuCourId(int studentId, int courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
        }

    }

    class AssiStuCourId
    {
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public AssiStuCourId(int assignmentId, int studentId, int courseId)
        {
            AssignmentId = assignmentId;
            StudentId = studentId;
            CourseId = courseId;
        }

    }

    class TrainCourId
    {
        public int TrainerId { get; set; }
        public int CourseId { get; set; }

        public TrainCourId(int trainerId, int courseId)
        {
            TrainerId = trainerId;
            CourseId = courseId;
        }

    }

    class StuCour
    {
        public Student Student { get; set; }
        public Course Course { get; set; }

        public StuCour(Student student, Course course)
        {
            Student = student;
            Course = course;
        }

        public void OutputCourse()
        {
            Course.Output();
        }

        public void OutputStudent()
        {
            Student.Output();
        }

    }

    class AssiStuCour
    {
        public Assignment Assignment { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }

        public AssiStuCour(Assignment assignment, Student student, Course course)
        {
            Assignment = assignment;
            Student = student;
            Course = course;
        }

        public void OutputAssignment()
        {
            Assignment.Output();
        }

        public void OutputCourse()
        {
            Course.Output();
        }

        public void OutputStudent()
        {
            Student.Output();
        }

    }

    class TrainCour
    {
        public Trainer Trainer { get; set; }
        public Course Course { get; set; }

        public TrainCour(Trainer trainer, Course course)
        {
            Trainer = trainer;
            Course = course;
        }

        public void OutputCourse()
        {
            Course.Output();
        }

        public void OutputTrainer()
        {
            Trainer.Output();
        }

    }

    class AssiCour
    {
        public Assignment Assignment { get; set; }
        public Course Course { get; set; }

        public AssiCour(Assignment assignment, Course course)
        {
            Assignment = assignment;
            Course = course;
        }

        public void OutputAssignment()
        {
            Assignment.Output();
        }

        public void OutputCourse()
        {
            Course.Output();
        }

    }

    class AssiCourStu
    {
        public Assignment Assignment { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }

        public AssiCourStu(Assignment assignment, Course course, Student student)
        {
            Assignment = assignment;
            Course = course;
            Student = student;
        }

        public void OutputAssignment()
        {
            Assignment.Output();
        }

        public void OutputCourse()
        {
            Course.Output();
        }

        public void OutputStudent()
        {
            Student.Output();
        }

    }


    class Services
    {
        public static string conString = ConfigurationManager.ConnectionStrings["schoolConnection"].ConnectionString;

        public static List<Student> GetAllStudents()
        {
            List<Student> tempStus = new List<Student>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string querystring = "Select * from Student";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(querystring, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student stu = new Student(
                        Convert.ToInt32(reader["StudentId"]),
                        reader["FirstName"].ToString(),
                        reader["LastName"].ToString(),
                        Convert.ToDateTime(reader["DateOfBirth"]),
                        Convert.ToInt32(reader["TuitionFees"])
                        );
                        tempStus.Add(stu);
                    }

                    Console.WriteLine("Reading students from database was successful!");
                    Console.WriteLine();
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("Error in the database " + ex.Message);
            }
            finally
            {

            }

            return tempStus;

        }

        public static List<Trainer> GetAllTrainers()
        {
            List<Trainer> tempTrains = new List<Trainer>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string querystring = "Select * from Trainer";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(querystring, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Trainer train = new Trainer(
                        Convert.ToInt32(reader["TrainerId"]),
                        reader["FirstName"].ToString(),
                        reader["LastName"].ToString(),
                        reader["Subject"].ToString()
                        );
                        tempTrains.Add(train);
                    }

                    Console.WriteLine("Reading trainers from database was successful!");
                    Console.WriteLine();
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("Error in the database " + ex.Message);
            }
            finally
            {

            }

            return tempTrains;

        }

        public static List<Assignment> GetAllAssignments()
        {
            List<Assignment> tempAssi = new List<Assignment>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string querystring = "Select * from Assignment";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(querystring, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Assignment assi = new Assignment(
                        Convert.ToInt32(reader["AssignmentId"]),
                        reader["Title"].ToString(),
                        reader["Description"].ToString(),
                        Convert.ToDateTime(reader["SubDateTime"]),
                        Convert.ToDouble(reader["OralMark"]),
                        Convert.ToDouble(reader["TotalMark"])
                        );
                        tempAssi.Add(assi);
                    }

                    Console.WriteLine("Reading assignments from database was successful");
                    Console.WriteLine();
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("Error in the database " + ex.Message);
            }
            finally
            {

            }

            return tempAssi;

        }

        public static List<Course> GetAllCourses()
        {
            List<Course> tempCours = new List<Course>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string querystring = "Select * from Course";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(querystring, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Course cour = new Course(
                        Convert.ToInt32(reader["CourseId"]),
                        reader["Title"].ToString(),
                        reader["Stream"].ToString(),
                        reader["Type"].ToString(),
                        Convert.ToDateTime(reader["StartDate"]),
                        Convert.ToDateTime(reader["EndDate"])
                        );
                        tempCours.Add(cour);
                    }

                    Console.WriteLine("Reading courses from database was successful!");
                    Console.WriteLine();
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("Error in the database " + ex.Message);
            }
            finally
            {

            }

            return tempCours;

        }

        public static List<StuCour> GetAllStuPerCour()
        {
            List<StuCour> tempSPC = new List<StuCour>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string querystring = "SELECT student.studentid, course.courseid, student.firstname," +
                        " student.lastname, student.dateofbirth, student.tuitionfees, course.title," +
                        " course.stream, course.type, course.startdate, course.enddate" +
                        " FROM((studentPerCourse INNER JOIN Student ON studentPerCourse.studentid = Student.studentid)" +
                        " INNER JOIN Course ON studentPerCourse.courseid = Course.courseid)";

                    con.Open();
                    SqlCommand cmd = new SqlCommand(querystring, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student stu = new Student(
                        Convert.ToInt32(reader["StudentId"]),
                        reader["FirstName"].ToString(),
                        reader["LastName"].ToString(),
                        Convert.ToDateTime(reader["DateOfBirth"]),
                        Convert.ToInt32(reader["TuitionFees"])
                        );
                        Course cour = new Course(
                        Convert.ToInt32(reader["CourseId"]),
                        reader["Title"].ToString(),
                        reader["Stream"].ToString(),
                        reader["Type"].ToString(),
                        Convert.ToDateTime(reader["StartDate"]),
                        Convert.ToDateTime(reader["EndDate"])
                        );
                        StuCour stucour = new StuCour(stu, cour);
                        tempSPC.Add(stucour);
                    }

                    Console.WriteLine("Reading students per course from database was successful!");
                    Console.WriteLine();
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("Error in the database " + ex.Message);
            }
            finally
            {

            }

            return tempSPC;

        }

        public static List<TrainCour> GetAllTrainPerCour()
        {
            List<TrainCour> tempTPC = new List<TrainCour>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string querystring = "SELECT trainer.trainerid, course.courseid, trainer.firstname, trainer.lastname, " +
                        "trainer.subject, course.title, course.stream, course.type, course.startdate, course.enddate " +
                        "FROM((trainerPerCourse INNER JOIN Trainer ON trainerPerCourse.trainerid = Trainer.trainerid) " +
                        "INNER JOIN Course ON trainerPerCourse.courseid = Course.courseid); ";

                    con.Open();
                    SqlCommand cmd = new SqlCommand(querystring, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Trainer train = new Trainer(
                        Convert.ToInt32(reader["TrainerId"]),
                        reader["FirstName"].ToString(),
                        reader["LastName"].ToString(),
                        reader["Subject"].ToString()
                        );
                        Course cour = new Course(
                        Convert.ToInt32(reader["CourseId"]),
                        reader["Title"].ToString(),
                        reader["Stream"].ToString(),
                        reader["Type"].ToString(),
                        Convert.ToDateTime(reader["StartDate"]),
                        Convert.ToDateTime(reader["EndDate"])
                        );
                        TrainCour traincour = new TrainCour(train, cour);
                        tempTPC.Add(traincour);
                    }

                    Console.WriteLine("Reading trainer per course from database was successful!");
                    Console.WriteLine();
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("Error in the database " + ex.Message);
            }
            finally
            {

            }

            return tempTPC;

        }

        public static List<AssiCour> GetAllAssiPerCour()
        {
            List<AssiCour> tempAPC = new List<AssiCour>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string querystring = "";

                    con.Open();
                    SqlCommand cmd = new SqlCommand(querystring, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Assignment assi = new Assignment(
                        Convert.ToInt32(reader["AssignmentId"]),
                        reader["Title"].ToString(),
                        reader["Description"].ToString(),
                        Convert.ToDateTime(reader["SubDateTime"]),
                        Convert.ToDouble(reader["OralMark"]),
                        Convert.ToDouble(reader["TotalMark"])
                        );
                        Course cour = new Course(
                        Convert.ToInt32(reader["CourseId"]),
                        reader["Title"].ToString(),
                        reader["Stream"].ToString(),
                        reader["Type"].ToString(),
                        Convert.ToDateTime(reader["StartDate"]),
                        Convert.ToDateTime(reader["EndDate"])
                        );
                        AssiCour assicour = new AssiCour(assi, cour);
                        tempAPC.Add(assicour);
                    }

                    Console.WriteLine("Reading assignment per course from database was successful!");
                    Console.WriteLine();
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("Error in the database " + ex.Message);
            }
            finally
            {

            }

            return tempAPC;

        }

        public static List<AssiCourStu> GetAllAssiPerCourPerStu()
        {
            List<AssiCourStu> tempACS = new List<AssiCourStu>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string querystring = "";

                    con.Open();
                    SqlCommand cmd = new SqlCommand(querystring, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Assignment assi = new Assignment(
                        Convert.ToInt32(reader["AssignmentId"]),
                        reader["Title"].ToString(),
                        reader["Description"].ToString(),
                        Convert.ToDateTime(reader["SubDateTime"]),
                        Convert.ToDouble(reader["OralMark"]),
                        Convert.ToDouble(reader["TotalMark"])
                        );
                        Course cour = new Course(
                        Convert.ToInt32(reader["CourseId"]),
                        reader["Title"].ToString(),
                        reader["Stream"].ToString(),
                        reader["Type"].ToString(),
                        Convert.ToDateTime(reader["StartDate"]),
                        Convert.ToDateTime(reader["EndDate"])
                        );
                        Student stu = new Student(
                        Convert.ToInt32(reader["StudentId"]),
                        reader["FirstName"].ToString(),
                        reader["LastName"].ToString(),
                        Convert.ToDateTime(reader["DateOfBirth"]),
                        Convert.ToInt32(reader["TuitionFees"])
                        );
                        AssiCourStu assicourstu = new AssiCourStu(assi, cour, stu);
                        tempACS.Add(assicourstu);
                    }

                    Console.WriteLine("Reading assignments per course per student from database was successful");
                    Console.WriteLine();
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("Error in the database " + ex.Message);
            }
            finally
            {

            }

            return tempACS;

        }

        public static void InsertStudent(Student stu)
        {
            SqlConnection con = new SqlConnection(conString);

            string query = "INSERT INTO Student (firstname, lastname, dateofbirth, tuitionfees) VALUES(@firstname, @lastname, @dateofbirth, @tuitionfees)";

            SqlCommand sqlCommand = new SqlCommand(query, con);

            sqlCommand.Parameters.AddWithValue("@firstname", stu.FirstName);
            sqlCommand.Parameters.AddWithValue("@lastname", stu.LastName);
            sqlCommand.Parameters.AddWithValue("@dateofbirth", stu.DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@tuitionfees", stu.TuitionFees);


            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Students inserted successfully");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Generated. Details: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public static void InsertTrainer(Trainer train)
        {
            SqlConnection con = new SqlConnection(conString);

            string query = "INSERT INTO Trainer (firstname, lastname, subject) VALUES(@firstname, @lastname, @subject)";

            SqlCommand sqlCommand = new SqlCommand(query, con);

            sqlCommand.Parameters.AddWithValue("@firstname", train.FirstName);
            sqlCommand.Parameters.AddWithValue("@lastname", train.LastName);
            sqlCommand.Parameters.AddWithValue("@subject", train.Subject);


            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Trainers inserted successfully");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Generated. Details: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public static void InsertAssignment(Assignment assi)
        {
            SqlConnection con = new SqlConnection(conString);

            string query = "INSERT INTO Assignment (title, description, subdatetime, oralmark, totalmark) VALUES(@title, @description, @subdatetime, @oralmark, @totalmark)";

            SqlCommand sqlCommand = new SqlCommand(query, con);

            sqlCommand.Parameters.AddWithValue("@title", assi.Title);
            sqlCommand.Parameters.AddWithValue("@description", assi.Description);
            sqlCommand.Parameters.AddWithValue("@subdatetime", assi.SubDateTime);
            sqlCommand.Parameters.AddWithValue("@oralmark", assi.OralMark);
            sqlCommand.Parameters.AddWithValue("@totalmark", assi.TotalMark);


            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Assignments inserted successfully");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Generated. Details: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public static void InsertCourse(Course cour)
        {
            SqlConnection con = new SqlConnection(conString);

            string query = "INSERT INTO Course (title, stream, type, startdate, enddate) VALUES(@title, @stream, @type, @startdate, @enddate)";

            SqlCommand sqlCommand = new SqlCommand(query, con);

            sqlCommand.Parameters.AddWithValue("@title", cour.Title);
            sqlCommand.Parameters.AddWithValue("@stream", cour.Stream);
            sqlCommand.Parameters.AddWithValue("@type", cour.Type);
            sqlCommand.Parameters.AddWithValue("@startDate", cour.StartDate);
            sqlCommand.Parameters.AddWithValue("@endDate", cour.EndDate);


            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Courses inserted successfully");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Generated. Details: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public static void InsertStudentPerCourse(StuCourId scid)
        {
            SqlConnection con = new SqlConnection(conString);

            string query = "INSERT INTO studentPerCourse (studentid, courseid) VALUES(@studentid, @courseid)";

            SqlCommand sqlCommand = new SqlCommand(query, con);

            sqlCommand.Parameters.AddWithValue("@studentid", scid.StudentId);
            sqlCommand.Parameters.AddWithValue("@courseid", scid.CourseId);

            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Students per course inserted successfully");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Generated. Details: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public static void InsertTrainerPerCourse(TrainCourId tcid)
        {
            SqlConnection con = new SqlConnection(conString);

            string query = "INSERT INTO trainerPerCourse (trainerid, courseid) VALUES(@trainerid, @courseid)";

            SqlCommand sqlCommand = new SqlCommand(query, con);

            sqlCommand.Parameters.AddWithValue("@trainerid", tcid.TrainerId);
            sqlCommand.Parameters.AddWithValue("@courseid", tcid.CourseId);

            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Trainers per course inserted successfully");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Generated. Details: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public static void InsertAssignmentPerStudentPerCourse(AssiStuCourId ascid)
        {
            SqlConnection con = new SqlConnection(conString);

            string query = "INSERT INTO assignmentPerStudentPerCourse (assignmentid, studentid, courseid) VALUES(@assignmentid, @studentid, @courseid)";

            SqlCommand sqlCommand = new SqlCommand(query, con);

            sqlCommand.Parameters.AddWithValue("@assignmentid", ascid.AssignmentId);
            sqlCommand.Parameters.AddWithValue("@studentid", ascid.StudentId);
            sqlCommand.Parameters.AddWithValue("@courseid", ascid.CourseId);

            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Assignments per student per course inserted successfully");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Generated. Details: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

    }

}
