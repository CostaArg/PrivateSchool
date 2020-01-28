-- ************************************** [Assignment]

CREATE TABLE [Assignment]
(
 [assignmentid] varchar(50) NOT NULL ,
 [title]        varchar(50) NOT NULL ,
 [description]  text NOT NULL ,
 [subdatetime]  datetime NOT NULL ,
 [oralmark]     float NOT NULL ,
 [totalmark]    float NOT NULL ,

 CONSTRAINT [PK_Assignment] PRIMARY KEY CLUSTERED ([assignmentid] ASC)
);
GO

-- ************************************** [assignmentPerCourse]

CREATE TABLE [assignmentPerCourse]
(
 [assignmentid] varchar(50) NOT NULL ,
 [courseid]     varchar(50) NOT NULL ,

 CONSTRAINT [PK_assignmentPerCourse] PRIMARY KEY CLUSTERED ([assignmentid] ASC, [courseid] ASC),
 CONSTRAINT [FK_63] FOREIGN KEY ([assignmentid])  REFERENCES [Assignment]([assignmentid]),
 CONSTRAINT [FK_66] FOREIGN KEY ([courseid])  REFERENCES [Course]([courseid])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_63] ON [assignmentPerCourse]
 (
  [assignmentid] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_66] ON [assignmentPerCourse]
 (
  [courseid] ASC
 )

GO

-- ************************************** [Course]

CREATE TABLE [Course]
(
 [courseid]  varchar(50) NOT NULL ,
 [title]     varchar(50) NOT NULL ,
 [stream]    varchar(50) NOT NULL ,
 [type]      varchar(50) NOT NULL ,
 [startdate] datetime NOT NULL ,
 [enddate]   datetime NOT NULL ,

 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED ([courseid] ASC)
);
GO

-- ************************************** [assignmentPerCoursePerStudent]

CREATE TABLE [assignmentPerCoursePerStudent]
(
 [studentid]    varchar(50) NOT NULL ,
 [courseid]     varchar(50) NOT NULL ,
 [assignmentid] varchar(50) NOT NULL ,

 CONSTRAINT [PK_assignmentPerCoursePerStudent] PRIMARY KEY CLUSTERED ([studentid] ASC, [courseid] ASC, [assignmentid] ASC),
 CONSTRAINT [FK_69] FOREIGN KEY ([assignmentid])  REFERENCES [Assignment]([assignmentid]),
 CONSTRAINT [FK_72] FOREIGN KEY ([courseid])  REFERENCES [Course]([courseid]),
 CONSTRAINT [FK_75] FOREIGN KEY ([studentid])  REFERENCES [Student]([studentid])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_69] ON [assignmentPerCoursePerStudent]
 (
  [assignmentid] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_72] ON [assignmentPerCoursePerStudent]
 (
  [courseid] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_75] ON [assignmentPerCoursePerStudent]
 (
  [studentid] ASC
 )

GO

-- ************************************** [Student]

CREATE TABLE [Student]
(
 [studentid]   varchar(50) NOT NULL ,
 [firstname]   varchar(50) NOT NULL ,
 [lastname]    varchar(50) NOT NULL ,
 [dateofbirth] datetime NOT NULL ,
 [tuitionfees] int NOT NULL ,

 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED ([studentid] ASC)
);
GO

-- ************************************** [studentPerCourse]

CREATE TABLE [studentPerCourse]
(
 [studentid] varchar(50) NOT NULL ,
 [courseid]  varchar(50) NOT NULL ,

 CONSTRAINT [PK_studentsPerCourse] PRIMARY KEY CLUSTERED ([studentid] ASC, [courseid] ASC),
 CONSTRAINT [FK_51] FOREIGN KEY ([courseid])  REFERENCES [Course]([courseid]),
 CONSTRAINT [FK_54] FOREIGN KEY ([studentid])  REFERENCES [Student]([studentid])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_51] ON [studentPerCourse]
 (
  [courseid] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_54] ON [studentPerCourse]
 (
  [studentid] ASC
 )

GO

-- ************************************** [Trainer]

CREATE TABLE [Trainer]
(
 [trainerid] varchar(50) NOT NULL ,
 [firstname] varchar(50) NOT NULL ,
 [lastname]  varchar(50) NOT NULL ,
 [subject]   varchar(50) NOT NULL ,

 CONSTRAINT [PK_Trainer] PRIMARY KEY CLUSTERED ([trainerid] ASC)
);
GO

-- ************************************** [trainerPerCourse]

CREATE TABLE [trainerPerCourse]
(
 [courseid]  varchar(50) NOT NULL ,
 [trainerid] varchar(50) NOT NULL ,

 CONSTRAINT [PK_trainerPerCourse] PRIMARY KEY CLUSTERED ([courseid] ASC, [trainerid] ASC),
 CONSTRAINT [FK_57] FOREIGN KEY ([trainerid])  REFERENCES [Trainer]([trainerid]),
 CONSTRAINT [FK_60] FOREIGN KEY ([courseid])  REFERENCES [Course]([courseid])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_57] ON [trainerPerCourse]
 (
  [trainerid] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_60] ON [trainerPerCourse]
 (
  [courseid] ASC
 )

GO
