all students
SELECT * FROM [Student]

all trainers
SELECT * FROM [Trainer]

all assignments
SELECT * FROM [Assignment]

all courses
SELECT * FROM [Course]

students per course
SELECT * FROM [Student]
WHERE (courseid == givenCourseId) FROM studentPerCourse

trainers per course

assignments per course

assignments per course per student

students with more than one course
SELECT * FROM [Student]
WHERE  count(courseid) > 1 FROM studentPerCourse
