all students
SELECT * FROM [Student]

all trainers
SELECT * FROM [Trainer]

all assignments
SELECT * FROM [Assignment]

all courses
SELECT * FROM [Course]

students per course
SELECT student.studentid, course.courseid, student.firstname, student.lastname, student.dateofbirth,
student.tuitionfees, course.title, course.stream, course.type, course.startdate, course.enddate
FROM ((studentPerCourse
INNER JOIN Student ON studentPerCourse.studentid = Student.studentid)
INNER JOIN Course ON studentPerCourse.courseid = Course.courseid);

trainers per course

assignments per course

assignments per course per student

students with more than one course
SELECT * FROM [Student]
WHERE  count(courseid) > 1 FROM studentPerCourse
