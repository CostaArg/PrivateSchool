--all students
SELECT * FROM [Student]

--all trainers
SELECT * FROM [Trainer]

--all assignments
SELECT * FROM [Assignment]

--all courses
SELECT * FROM [Course]

--students per course
SELECT student.studentid, course.courseid, student.firstname, student.lastname, student.dateofbirth,
student.tuitionfees, course.title, course.stream, course.type, course.startdate, course.enddate
FROM ((studentPerCourse
INNER JOIN Student ON studentPerCourse.studentid = Student.studentid)
INNER JOIN Course ON studentPerCourse.courseid = Course.courseid);

--trainers per course
SELECT trainer.trainerid, course.courseid, trainer.firstname, trainer.lastname, trainer.subject,
course.title, course.stream, course.type, course.startdate, course.enddate
FROM ((trainerPerCourse
INNER JOIN Trainer ON trainerPerCourse.trainerid = Trainer.trainerid)
INNER JOIN Course ON trainerPerCourse.courseid = Course.courseid);

--assignments per course
SELECT assignment.assignmentid, course.courseid, assignment.titleassi, assignment.description, assignment.subdatetime, assignment.oralmark,
assignment.totalmark, course.title, course.stream, course.type, course.startdate, course.enddate
FROM ((assignmentPerCourse
INNER JOIN Assignment ON assignmentPerCourse.assignmentid = Assignment.assignmentid)
INNER JOIN Course ON assignmentPerCourse.courseid = Course.courseid);

--assignments per course per student
SELECT assignment.assignmentid, course.courseid, student.studentid, assignment.description, assignment.subdatetime, assignment.oralmark,
assignment.totalmark, course.title, course.stream, course.type, course.startdate, course.enddate, student.firstname, student.lastname, Student.dateofbirth, student.tuitionfees
FROM (((assignmentPerCoursePerStudent
INNER JOIN Assignment ON assignmentPerCoursePerStudent.assignmentid = Assignment.assignmentid)
INNER JOIN Course ON assignmentPerCoursePerStudent.courseid = Course.courseid)
INNER JOIN Student ON assignmentPerCoursePerStudent.studentid = Student.studentid);

--assignments per student per course
SELECT assignment.assignmentid, student.studentid, course.courseid, assignment.titleassi, assignment.description, assignment.subdatetime, assignment.oralmark,
assignment.totalmark, student.firstname, student.lastname, Student.dateofbirth, student.tuitionfees, course.title, course.stream, course.type, course.startdate, course.enddate
FROM (((assignmentPerStudentPerCourse
INNER JOIN Assignment ON assignmentPerStudentPerCourse.assignmentid = Assignment.assignmentid)
INNER JOIN Student ON assignmentPerStudentPerCourse.studentid = Student.studentid)
INNER JOIN Course ON assignmentPerStudentPerCourse.courseid = Course.courseid);

--students with more than one course
SELECT s.firstname, s.lastname,
COUNT(sperc.studentid) AS courseamount
FROM Student s , studentPerCourse sperc
WHERE sperc.studentid = s.studentid
GROUP BY s.firstname, s.lastname
HAVING COUNT(sperc.studentid) > 1;