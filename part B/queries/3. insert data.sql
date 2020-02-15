SET IDENTITY_INSERT [dbo].[Student] ON
INSERT INTO [dbo].[Student] ([studentid], [firstname], [lastname], [dateofbirth], [tuitionfees]) VALUES (1, N'Panagiotis', N'Grigoriou', N'1987-03-04 00:00:00', 3000)
INSERT INTO [dbo].[Student] ([studentid], [firstname], [lastname], [dateofbirth], [tuitionfees]) VALUES (2, N'Konstantinos', N'Pantelidis', N'1991-06-02 00:00:00', 4000)
INSERT INTO [dbo].[Student] ([studentid], [firstname], [lastname], [dateofbirth], [tuitionfees]) VALUES (3, N'Spiros', N'Aggelatos', N'1996-04-07 00:00:00', 3500)
INSERT INTO [dbo].[Student] ([studentid], [firstname], [lastname], [dateofbirth], [tuitionfees]) VALUES (4, N'Dimitris', N'Pantelopoulos', N'2000-05-02 00:00:00', 6200)
INSERT INTO [dbo].[Student] ([studentid], [firstname], [lastname], [dateofbirth], [tuitionfees]) VALUES (5, N'Antonis', N'Mixelakakis', N'1989-10-03 00:00:00', 5800)
INSERT INTO [dbo].[Student] ([studentid], [firstname], [lastname], [dateofbirth], [tuitionfees]) VALUES (6, N'Basilis', N'Karantonis', N'1995-11-20 00:00:00', 1000)
SET IDENTITY_INSERT [dbo].[Student] OFF

GO

SET IDENTITY_INSERT [dbo].[Assignment] ON
INSERT INTO [dbo].[Assignment] ([assignmentid], [titleassi], [description], [subdatetime], [oralmark], [totalmark]) VALUES (1, N'Project Bank', N'Banking app', N'2020-04-24 00:00:00', 40, 200)
INSERT INTO [dbo].[Assignment] ([assignmentid], [titleassi], [description], [subdatetime], [oralmark], [totalmark]) VALUES (2, N'Project E-shop', N'Shopping website', N'2020-06-11 00:00:00', 20, 100)
INSERT INTO [dbo].[Assignment] ([assignmentid], [titleassi], [description], [subdatetime], [oralmark], [totalmark]) VALUES (3, N'Project Library', N'Book rental', N'2020-04-15 00:00:00', 35, 200)
INSERT INTO [dbo].[Assignment] ([assignmentid], [titleassi], [description], [subdatetime], [oralmark], [totalmark]) VALUES (4, N'Project Cinema', N'Movie distribution', N'2020-01-02 00:00:00', 73, 100)
INSERT INTO [dbo].[Assignment] ([assignmentid], [titleassi], [description], [subdatetime], [oralmark], [totalmark]) VALUES (5, N'Project Stocks', N'Stock notifications', N'2020-03-27 00:00:00', 110, 200)
INSERT INTO [dbo].[Assignment] ([assignmentid], [titleassi], [description], [subdatetime], [oralmark], [totalmark]) VALUES (6, N'Project Architecture', N'Blueprint software', N'2020-03-24 00:00:00', 40, 150)
INSERT INTO [dbo].[Assignment] ([assignmentid], [titleassi], [description], [subdatetime], [oralmark], [totalmark]) VALUES (7, N'Project Chat', N'Online messaging system', N'2020-10-04 00:00:00', 10, 100)
SET IDENTITY_INSERT [dbo].[Assignment] OFF

GO

SET IDENTITY_INSERT [dbo].[Course] ON
INSERT INTO [dbo].[Course] ([courseid], [title], [stream], [type], [startdate], [enddate]) VALUES (1, N'HTML', N'Web Development', N'Practical Subject', N'2020-05-10 00:00:00', N'2020-11-22 00:00:00')
INSERT INTO [dbo].[Course] ([courseid], [title], [stream], [type], [startdate], [enddate]) VALUES (2, N'Javascript', N'Web Development', N'Practical Subject', N'2020-01-10 00:00:00', N'2020-03-11 00:00:00')
INSERT INTO [dbo].[Course] ([courseid], [title], [stream], [type], [startdate], [enddate]) VALUES (3, N'C++', N'Object-Oriented Programming', N'Practical Subject', N'2020-01-18 00:00:00', N'2020-04-02 00:00:00')
INSERT INTO [dbo].[Course] ([courseid], [title], [stream], [type], [startdate], [enddate]) VALUES (4, N'Pascal', N'Procedural Programming', N'Theoretical Subject', N'2020-02-15 00:00:00', N'2020-05-20 00:00:00')
INSERT INTO [dbo].[Course] ([courseid], [title], [stream], [type], [startdate], [enddate]) VALUES (5, N'Visual Basic', N'Windows Application Development', N'Practical Subject', N'2020-03-20 00:00:00', N'2020-06-01 00:00:00')
SET IDENTITY_INSERT [dbo].[Course] OFF

GO

SET IDENTITY_INSERT [dbo].[Trainer] ON
INSERT INTO [dbo].[Trainer] ([trainerid], [firstname], [lastname], [subject]) VALUES (1, N'Giannis', N'Aggelopoulos', N'Object-Oriented Programming')
INSERT INTO [dbo].[Trainer] ([trainerid], [firstname], [lastname], [subject]) VALUES (2, N'Manolis', N'Daskalakis', N'Procedural Programming')
INSERT INTO [dbo].[Trainer] ([trainerid], [firstname], [lastname], [subject]) VALUES (3, N'Giorgos', N'Mpatzoglou', N'Procedural Programming')
INSERT INTO [dbo].[Trainer] ([trainerid], [firstname], [lastname], [subject]) VALUES (4, N'Thanassis', N'Giorgakopoulos', N'Object-Oriented Programming')
INSERT INTO [dbo].[Trainer] ([trainerid], [firstname], [lastname], [subject]) VALUES (5, N'Xaralampos', N'Lampropoulos', N'UNIX Systems')
SET IDENTITY_INSERT [dbo].[Trainer] OFF

GO

INSERT INTO [dbo].[assignmentPerCourse] ([assignmentid], [courseid]) VALUES (3, 1)
INSERT INTO [dbo].[assignmentPerCourse] ([assignmentid], [courseid]) VALUES (4, 1)
INSERT INTO [dbo].[assignmentPerCourse] ([assignmentid], [courseid]) VALUES (5, 1)
INSERT INTO [dbo].[assignmentPerCourse] ([assignmentid], [courseid]) VALUES (6, 1)
INSERT INTO [dbo].[assignmentPerCourse] ([assignmentid], [courseid]) VALUES (1, 2)
INSERT INTO [dbo].[assignmentPerCourse] ([assignmentid], [courseid]) VALUES (2, 3)
INSERT INTO [dbo].[assignmentPerCourse] ([assignmentid], [courseid]) VALUES (7, 3)
INSERT INTO [dbo].[assignmentPerCourse] ([assignmentid], [courseid]) VALUES (1, 5)
INSERT INTO [dbo].[assignmentPerCourse] ([assignmentid], [courseid]) VALUES (7, 5)

GO

INSERT INTO [dbo].[studentPerCourse] ([studentid], [courseid]) VALUES (1, 1)
INSERT INTO [dbo].[studentPerCourse] ([studentid], [courseid]) VALUES (1, 3)
INSERT INTO [dbo].[studentPerCourse] ([studentid], [courseid]) VALUES (2, 5)
INSERT INTO [dbo].[studentPerCourse] ([studentid], [courseid]) VALUES (3, 1)
INSERT INTO [dbo].[studentPerCourse] ([studentid], [courseid]) VALUES (4, 3)
INSERT INTO [dbo].[studentPerCourse] ([studentid], [courseid]) VALUES (5, 1)
INSERT INTO [dbo].[studentPerCourse] ([studentid], [courseid]) VALUES (5, 2)
INSERT INTO [dbo].[studentPerCourse] ([studentid], [courseid]) VALUES (6, 5)

GO

INSERT INTO [dbo].[trainerPerCourse] ([courseid], [trainerid]) VALUES (1, 1)
INSERT INTO [dbo].[trainerPerCourse] ([courseid], [trainerid]) VALUES (2, 3)
INSERT INTO [dbo].[trainerPerCourse] ([courseid], [trainerid]) VALUES (2, 4)
INSERT INTO [dbo].[trainerPerCourse] ([courseid], [trainerid]) VALUES (3, 2)
INSERT INTO [dbo].[trainerPerCourse] ([courseid], [trainerid]) VALUES (3, 3)
INSERT INTO [dbo].[trainerPerCourse] ([courseid], [trainerid]) VALUES (4, 4)

GO

INSERT INTO [dbo].[assignmentPerCoursePerStudent] ([studentid], [courseid], [assignmentid]) VALUES (1, 1, 6)
INSERT INTO [dbo].[assignmentPerCoursePerStudent] ([studentid], [courseid], [assignmentid]) VALUES (1, 3, 2)
INSERT INTO [dbo].[assignmentPerCoursePerStudent] ([studentid], [courseid], [assignmentid]) VALUES (2, 5, 1)
INSERT INTO [dbo].[assignmentPerCoursePerStudent] ([studentid], [courseid], [assignmentid]) VALUES (3, 1, 3)
INSERT INTO [dbo].[assignmentPerCoursePerStudent] ([studentid], [courseid], [assignmentid]) VALUES (4, 3, 2)
INSERT INTO [dbo].[assignmentPerCoursePerStudent] ([studentid], [courseid], [assignmentid]) VALUES (5, 1, 4)
INSERT INTO [dbo].[assignmentPerCoursePerStudent] ([studentid], [courseid], [assignmentid]) VALUES (5, 2, 1)
INSERT INTO [dbo].[assignmentPerCoursePerStudent] ([studentid], [courseid], [assignmentid]) VALUES (6, 5, 7)

GO

INSERT INTO [dbo].[assignmentPerStudentPerCourse] ([studentid], [courseid], [assignmentid]) VALUES (1, 1, 6)
INSERT INTO [dbo].[assignmentPerStudentPerCourse] ([studentid], [courseid], [assignmentid]) VALUES (1, 3, 2)
INSERT INTO [dbo].[assignmentPerStudentPerCourse] ([studentid], [courseid], [assignmentid]) VALUES (2, 5, 1)
INSERT INTO [dbo].[assignmentPerStudentPerCourse] ([studentid], [courseid], [assignmentid]) VALUES (3, 1, 3)
INSERT INTO [dbo].[assignmentPerStudentPerCourse] ([studentid], [courseid], [assignmentid]) VALUES (4, 3, 2)
INSERT INTO [dbo].[assignmentPerStudentPerCourse] ([studentid], [courseid], [assignmentid]) VALUES (5, 1, 4)
INSERT INTO [dbo].[assignmentPerStudentPerCourse] ([studentid], [courseid], [assignmentid]) VALUES (5, 2, 1)
INSERT INTO [dbo].[assignmentPerStudentPerCourse] ([studentid], [courseid], [assignmentid]) VALUES (6, 5, 7)

GO