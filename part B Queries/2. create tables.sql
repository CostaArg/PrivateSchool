CREATE TABLE [dbo].[Trainer] (
    [trainerid] INT          IDENTITY (1, 1) NOT NULL,
    [firstname] VARCHAR (50) NOT NULL,
    [lastname]  VARCHAR (50) NOT NULL,
    [subject]   VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Trainer] PRIMARY KEY CLUSTERED ([trainerid] ASC)
);

CREATE TABLE [dbo].[Course] (
    [courseid]  INT          IDENTITY (1, 1) NOT NULL,
    [title]     VARCHAR (50) NOT NULL,
    [stream]    VARCHAR (50) NOT NULL,
    [type]      VARCHAR (50) NOT NULL,
    [startdate] DATETIME     NOT NULL,
    [enddate]   DATETIME     NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED ([courseid] ASC)
);

CREATE TABLE [dbo].[Student] (
    [studentid]   INT          IDENTITY (1, 1) NOT NULL,
    [firstname]   VARCHAR (50) NOT NULL,
    [lastname]    VARCHAR (50) NOT NULL,
    [dateofbirth] DATETIME     NOT NULL,
    [tuitionfees] INT          NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED ([studentid] ASC)
);

CREATE TABLE [dbo].[Assignment] (
    [assignmentid] INT          IDENTITY (1, 1) NOT NULL,
    [titleassi]    VARCHAR (50) NOT NULL,
    [description]  VARCHAR (50) NOT NULL,
    [subdatetime]  DATETIME     NOT NULL,
    [oralmark]     FLOAT (53)   NOT NULL,
    [totalmark]    FLOAT (53)   NOT NULL,
    CONSTRAINT [PK_Assignment] PRIMARY KEY CLUSTERED ([assignmentid] ASC)
);

CREATE TABLE [dbo].[assignmentPerCourse] (
    [assignmentid] INT NOT NULL,
    [courseid]     INT NOT NULL,
    CONSTRAINT [PK_assignmentPerCourse] PRIMARY KEY CLUSTERED ([assignmentid] ASC, [courseid] ASC),
    CONSTRAINT [FK_66] FOREIGN KEY ([courseid]) REFERENCES [dbo].[Course] ([courseid]),
    CONSTRAINT [FK_63] FOREIGN KEY ([assignmentid]) REFERENCES [dbo].[Assignment] ([assignmentid])
);


GO

CREATE TABLE [dbo].[assignmentPerCoursePerStudent] (
    [studentid]    INT NOT NULL,
    [courseid]     INT NOT NULL,
    [assignmentid] INT NOT NULL,
    CONSTRAINT [PK_assignmentPerCoursePerStudent] PRIMARY KEY CLUSTERED ([studentid] ASC, [courseid] ASC, [assignmentid] ASC),
    CONSTRAINT [FK_90] FOREIGN KEY ([courseid]) REFERENCES [dbo].[Course] ([courseid]),
    CONSTRAINT [FK_91] FOREIGN KEY ([studentid]) REFERENCES [dbo].[Student] ([studentid]),
    CONSTRAINT [FK_92] FOREIGN KEY ([assignmentid]) REFERENCES [dbo].[Assignment] ([assignmentid])
);


GO


CREATE TABLE [dbo].[assignmentPerStudentPerCourse] (
    [studentid]    INT NOT NULL,
    [courseid]     INT NOT NULL,
    [assignmentid] INT NOT NULL,
    CONSTRAINT [PK_assignmentPerStudentPerCourse] PRIMARY KEY CLUSTERED ([studentid] ASC, [courseid] ASC, [assignmentid] ASC),
    CONSTRAINT [FK_72] FOREIGN KEY ([courseid]) REFERENCES [dbo].[Course] ([courseid]),
    CONSTRAINT [FK_75] FOREIGN KEY ([studentid]) REFERENCES [dbo].[Student] ([studentid]),
    CONSTRAINT [FK_69] FOREIGN KEY ([assignmentid]) REFERENCES [dbo].[Assignment] ([assignmentid])
);


GO

CREATE TABLE [dbo].[studentPerCourse] (
    [studentid] INT NOT NULL,
    [courseid]  INT NOT NULL,
    CONSTRAINT [PK_studentsPerCourse] PRIMARY KEY CLUSTERED ([studentid] ASC, [courseid] ASC),
    CONSTRAINT [FK_51] FOREIGN KEY ([courseid]) REFERENCES [dbo].[Course] ([courseid]),
    CONSTRAINT [FK_54] FOREIGN KEY ([studentid]) REFERENCES [dbo].[Student] ([studentid])
);


GO

CREATE TABLE [dbo].[trainerPerCourse] (
    [courseid]  INT NOT NULL,
    [trainerid] INT NOT NULL,
    CONSTRAINT [PK_trainerPerCourse] PRIMARY KEY CLUSTERED ([courseid] ASC, [trainerid] ASC),
    CONSTRAINT [FK_60] FOREIGN KEY ([courseid]) REFERENCES [dbo].[Course] ([courseid]),
    CONSTRAINT [FK_57] FOREIGN KEY ([trainerid]) REFERENCES [dbo].[Trainer] ([trainerid])
);


GO