create database FLEXNU1;

use FLEXNU1;


CREATE TABLE AcademicOffice (
    AcademicOfficeID INT PRIMARY KEY,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL
);

CREATE TABLE Faculty (
    FacultyID INT PRIMARY KEY,
    Fname VARCHAR(255) NOT NULL,
    Lname VARCHAR(255) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    CurEdu VARCHAR(255) NOT NULL,
    Experience INT NOT NULL,
    Position VARCHAR(255) NOT NULL,
    DateOfEmployement VARCHAR(255) NOT NULL
);

CREATE TABLE Student (
    StudentID INT PRIMARY KEY,
    RollNo INT UNIQUE NOT NULL,
    Fname VARCHAR(255) NOT NULL,
    Lname VARCHAR(255) NOT NULL,
    DOB VARCHAR(255) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    PhoneNo VARCHAR(255) NOT NULL,
    DateOfAdmission VARCHAR(255),
    CGPA DECIMAL(3, 2) NOT NULL,
    CreditHours INT NOT NULL,
    Address VARCHAR(255) NOT NULL
);

CREATE TABLE Course (
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(255) NOT NULL,
    CreditHours INT NOT NULL,
    MaxEnrollement INT NOT NULL,
    PreReq  VARCHAR(255),
    CoordinatorID INT,
	FOREIGN KEY (CoordinatorID) REFERENCES Faculty(FacultyID)
);

CREATE TABLE Semester (
    SemesterID INT PRIMARY KEY,
    SemesterName VARCHAR(255) NOT NULL,
    StartDate VARCHAR(255),
    EndDate VARCHAR(255)
);

CREATE TABLE CourseSemester (
    CourseSemesterID INT PRIMARY KEY,
    CourseID INT NOT NULL,
    SemesterID INT NOT NULL,
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    FOREIGN KEY (SemesterID) REFERENCES Semester(SemesterID)
);

CREATE TABLE Section (
    SectionID INT PRIMARY KEY,
    SectionName VARCHAR(255) NOT NULL,
    MaxEnrollement INT NOT NULL
);

CREATE TABLE StudentSection (
    StudentID INT NOT NULL,
    SectionID INT NOT NULL,
    SemesterID INT NOT NULL,
    PRIMARY KEY (StudentID, SectionID, SemesterID),
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (SectionID) REFERENCES Section(SectionID),
    FOREIGN KEY (SemesterID) REFERENCES Semester(SemesterID)
);

CREATE TABLE StudentMarks (
    StudentMarksID INT PRIMARY KEY,
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    SectionID INT NOT NULL,
    Assignment INT,
    Quiz INT,
    Sessional_I INT,
    Sessional_II INT,
    Project INT,
    Final INT,
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    FOREIGN KEY (SectionID) REFERENCES Section(SectionID)
);

CREATE TABLE FacultyCourse (
    FacultyID INT,
    CourseID INT,
    PRIMARY KEY (FacultyID, CourseID),
    FOREIGN KEY (FacultyID) REFERENCES Faculty(FacultyID),
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);

CREATE TABLE FacultyFeedback (
    FeedbackID INT PRIMARY KEY,
    StudentID INT NOT NULL,
    RollNo INT NOT NULL,
    FacultyID INT NOT NULL,
    CourseName VARCHAR(255) NOT NULL,
    FeedbackText VARCHAR(MAX),
    TeacherArrivesOnTime VARCHAR(50),
    TeachersPace VARCHAR(50),
    TeacherEngagement VARCHAR(50),
    TeacherDedication VARCHAR(50),
    TeacherRespect VARCHAR(50),
    TeacherAssignments VARCHAR(50),
    TeacherRules VARCHAR(50),
    TeacherResponsiveness VARCHAR(50),
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (FacultyID) REFERENCES Faculty(FacultyID)
);

CREATE TABLE CourseFeedback (
    CourseFeedbackID INT PRIMARY KEY,
    CourseID INT NOT NULL,
    StudentID INT NOT NULL,
    SemesterID INT NOT NULL,
    FeedbackID INT NOT NULL,
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (SemesterID) REFERENCES Semester(SemesterID),
    FOREIGN KEY (FeedbackID) REFERENCES FacultyFeedback(FeedbackID)
);

CREATE TABLE CourseOutline (
    CourseOutlineID INT PRIMARY KEY,
    CourseID INT NOT NULL,
    Assignment INT NOT NULL,
    Quiz INT NOT NULL,
    Sessional_I INT NOT NULL,
    Sessional_II INT NOT NULL,
    Project INT NOT NULL,
    Final INT NOT NULL,
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);

CREATE TABLE FacultySection(
    FacultySectionID INT NOT NULL IDENTITY(1,1),
    SectionID INT NOT NULL,
    CourseID INT NOT NULL,
    FacultyID INT NOT NULL,
    CONSTRAINT PK_FacultySection PRIMARY KEY (FacultySectionID),
    FOREIGN KEY (SectionID) REFERENCES Section(SectionID),
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    FOREIGN KEY (FacultyID) REFERENCES Faculty(FacultyID)
);

CREATE TABLE SectionCourse (
    SectionCourseID INT PRIMARY KEY,
    SectionID INT NOT NULL,
    CourseID INT NOT NULL,
    FOREIGN KEY (SectionID) REFERENCES Section(SectionID),
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);

CREATE TABLE StudentAttendance (
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    FacultyID INT NOT NULL,
    AttendanceID INT IDENTITY(1,1) PRIMARY KEY,
    SectionID INT NOT NULL,
    Status VARCHAR(255) NOT NULL,
    AttendanceDate DATE,
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    FOREIGN KEY (FacultyID) REFERENCES Faculty(FacultyID),
    FOREIGN KEY (SectionID) REFERENCES Section(SectionID)
);

CREATE TABLE StudentSemester(
    StudentID INT,
    SemesterID INT,
    PRIMARY KEY (StudentID, SemesterID),
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (SemesterID) REFERENCES Semester(SemesterID)
);

CREATE TABLE StudentGrades(
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    SectionID INT NOT NULL,
    Grade VARCHAR(3) NOT NULL,
    PRIMARY KEY (StudentID, CourseID, SectionID),
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    FOREIGN KEY (SectionID) REFERENCES Section(SectionID)
);

CREATE TABLE AuditLog (
    AuditLogID INT IDENTITY(1,1) PRIMARY KEY,
    OperationType VARCHAR(255) NOT NULL,
    TableName VARCHAR(255) NOT NULL,
    UserID NVARCHAR(255) NOT NULL,
    DateTime DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Userr (
    UserID INT PRIMARY KEY,
    Email NVARCHAR(255)  NOT NULL,
    Password VARCHAR(255) NOT NULL
);

CREATE TABLE Role (
    RoleID INT PRIMARY KEY,
    RoleName VARCHAR(255) NOT NULL
);


CREATE TABLE UserRole (
    UserRoleID INT PRIMARY KEY,
    RoleID INT NOT NULL,
    UserID INT NOT NULL,
    FOREIGN KEY (RoleID) REFERENCES Role(RoleID),
    FOREIGN KEY (UserID) REFERENCES Userr(UserID)
);




CREATE TRIGGER StudentAuditTrigger
ON Student
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @OperationType VARCHAR(255)
    DECLARE @TableName VARCHAR(255)
    DECLARE @UserID NVARCHAR(255)
    IF EXISTS(SELECT * FROM inserted)
    BEGIN
        IF EXISTS(SELECT * FROM deleted)
            SET @OperationType = 'UPDATE'
        ELSE
            SET @OperationType = 'INSERT'
    END
    ELSE
    BEGIN
        SET @OperationType = 'DELETE'
    END

    SET @TableName = 'Student' 
    SET @UserID = SYSTEM_USER 
    INSERT INTO AuditLog (OperationType, TableName, UserID)
    VALUES (@OperationType, @TableName, @UserID)
END;





CREATE TRIGGER Faculty_AuditTrigger
ON Faculty
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @OperationType VARCHAR(255);
    IF EXISTS(SELECT * FROM inserted)
    BEGIN
        IF EXISTS(SELECT * FROM deleted)
            SET @OperationType = 'UPDATE';
        ELSE
            SET @OperationType = 'INSERT';
    END
    ELSE
    BEGIN
        SET @OperationType = 'DELETE';
    END;

    INSERT INTO AuditLog (OperationType, TableName, UserID, DateTime)
    SELECT @OperationType, 'Faculty', SUSER_SNAME(), GETDATE();

END;



BULK INSERT AcademicOffice
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/AcademicOffice.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);

BULK INSERT Attendance
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/Attendance.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);
select * from Attendance

BULK INSERT Course
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/Course.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);



BULK INSERT CourseFeedback
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/CourseFeedback.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);

BULK INSERT CourseOutline
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/CourseOutline.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);
select * from CourseOutline


BULK INSERT CourseSemester
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/CourseSemester.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);


BULK INSERT Faculty
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/Faculty.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);


BULK INSERT Feedback
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/Feedback.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);



BULK INSERT Role
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/Role.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);
select * from Role




BULK INSERT Section
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/Section.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);
select * from Section 

INSERT INTO Section (SectionID, SectionName, MaxEnrollement)
VALUES (1, 'A', 50),
       (2, 'B', 50),
       (3, 'C', 50),
       (4, 'D', 50),
       (5, 'E', 50),
       (6, 'F', 50),
       (7, 'G', 50),
       (8, 'H', 50),
       (9, 'I', 50),
       (10, 'J', 50);

drop table Section

BULK INSERT SectionCourse
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/SectionCourse.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);
select * from SectionCourse

BULK INSERT Semester
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/Semester.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);
select * from Semester

INSERT INTO StudentSemester (StudentID, SemesterID)
VALUES 
  (1, 1), (2, 1), (3, 1), (4, 1), (5, 1), (6, 1), (7, 1), (8, 1), (9, 1), (10, 1),
  (11, 1), (12, 1), (13, 1), (14, 1), (15, 1), (16, 1), (17, 1), (18, 1), (19, 1), (20, 1),
  (21, 1), (22, 1), (23, 1), (24, 1), (25, 1), (26, 1), (27, 1), (28, 1), (29, 1), (30, 1),
  (31, 1), (32, 1), (33, 1), (34, 1), (35, 1), (36, 1), (37, 1), (38, 1), (39, 1), (40, 1),
  (41, 1), (42, 1), (43, 1), (44, 1), (45, 1), (46, 1), (47, 1), (48, 1), (49, 1), (50, 1),
  (51, 1), (52, 1), (53, 1), (54, 1), (55, 1), (56, 1), (57, 1), (58, 1), (59, 1), (60, 1);


BULK INSERT Student
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/Student.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);

INSERT INTO Student (StudentID, RollNo, Fname, Lname, DOB, Email, Password, PhoneNo, DateOfAdmission, CGPA, CreditHours, Address) VALUES 
(51, 21051, 'aliza', 'noman', '07-12-1999', '21051@nu.edu.pk', '51U6x', '3001-25-4567', '14-06-2018', 0.0, 12, 'House No. 1032, Street No. 32, F-5/3, Islamabad'),
(53, 21053, 'ayeza', 'Ahmed', '07-12-1999', '21053@nu.edu.pk', '9s53x', '3031-33-4567', '14-06-2018',  0.0, 12, 'House No. 120, Street No. 32, E-4/5, Islamabad'),
(54, 21054, 'irfan', 'khan', '07-12-1999', '21054@nu.edu.pk', '54U6x', '3301-23-5467', '14-06-2018',  0.0, 12, 'House No. 2710, Street No. 13, G-4/4, Islamabad'),
(55, 21055, 'asma', 'makil', '07-12-1999', '21055@nu.edu.pk', '9sU6x', '3021-23-4557', '14-06-2018',  0.0, 12, 'House No. 1620, Street No. 35, I-5/1, Islamabad'),
(56, 21056, 'faisal', 'Ahmed', '07-12-1999', '21056@nu.edu.pk', '956U6x', '3001-23-4567', '14-06-2018',  0.0, 12, 'House No. 13220, Street No.63, E-5/2, Islamabad'),
(57, 21057, 'waleed', 'Ahmed', '07-12-1999', '21057@nu.edu.pk', '57U6x', '3001-57-4567', '14-06-2018',  0.0, 12, 'House No. 1320, Street No. 53, I-5/3, Islamabad'),
(58, 21058, 'Ayesha', 'bhati', '03-12-1999', '21058@nu.edu.pk', '9586x', '3001-23-4567', '14-06-2018',  0.0, 12, 'House No. 1320, Street No. 73, H-4/3, Islamabad'),
(59, 21059, 'umsan', 'Ahmed', '07-12-1999', '21059@nu.edu.pk', '9596x', '3001-23-4567', '14-06-2018',  0.0, 12, 'House No. 132, Street No. 53, I-4/1, Islamabad'),
(60, 21060, 'omama', 'khan', '07-12-1999', '21060@nu.edu.pk', '9sU6x', '3001-23-4560', '14-06-2018',  0.0, 12, 'House No. 110, Street No. 33, G-5/2, Islamabad');

BULK INSERT StudentAttendance
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/StudentAttendance.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);


BULK INSERT StudentSection
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/StudentSection.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);



BULK INSERT Userr
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/User.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);




BULK INSERT UserRole
FROM 'C:/Users/Wiz tech/Desktop/DB lab/project/data/UserRole.csv'
WITH (
   FIELDTERMINATOR = ',',
   ROWTERMINATOR = '\n',
   FIRSTROW = 2
);



ALTER TABLE Course
ADD CoordinatorID INT;

INSERT INTO FacultyCourse (FacultyID, CourseID)
VALUES 
(1, 2),
(1, 4),
(1, 6),
(2, 3),
(2, 6),
(2, 7),
(3, 1),
(3, 4),
(3, 9),
(4, 2),
(4, 5),
(4, 8),
(5, 1),
(5, 7),
(5, 9),
(6, 3),
(6, 6),
(6, 8),
(7, 2),
(7, 5),
(7, 10),
(8, 1),
(8, 7),
(8, 11),
(9, 3),
(9, 6),
(9, 12),
(10, 2),
(10, 5),
(10, 13),
(11, 1),
(11, 7),
(11, 14),
(12, 3),
(12, 6),
(12, 15),
(13, 2),
(13, 4),
(13, 16),
(14, 1),
(14, 7),
(14, 17),
(15, 3),
(15, 6),
(15, 18),
(16, 2),
(16, 5),
(16, 19),
(17, 1),
(17, 7),
(17, 20),
(18, 3),
(18, 6),
(18, 21),
(19, 2),
(19, 4),
(19, 22),
(20, 1),
(20, 7),
(20, 23),
(21, 3),
(21, 6),
(21, 24),
(22, 2),
(22, 5),
(22, 25),
(23, 1),
(23, 7),
(23, 26),
(24, 3),
(24, 6),
(24, 27),
(25, 2),
(25, 4),
(25, 28),
(26, 1),
(26, 7),
(26, 29),
(27, 3),
(27, 6),
(27, 30),
(28, 2),
(28, 5),
(28, 31),
(29, 1),
(29, 7),
(29, 32),
(30, 3),
(30, 6),
(30, 33),
(31, 2),
(31, 4),
(31, 34),
(32, 1),
(32, 7),
(32, 35),
(33, 3),
(33, 6),
(33, 36),
(34, 2),
(34, 5),
(34, 37),
(35, 1),
(35, 7),
(35, 38),
(36, 3),
(36, 6),
(36, 39),
(37, 2),
(37, 4),
(37, 40),
(38, 1),
(38, 7),
(38, 3),
(39, 3),
(39, 4),
(39, 2),
(40, 2),
(40, 1),
(40, 7),
(41, 6),
(41, 9),
(41, 10),
(41, 11),
(42, 12),
(42, 13),
(42, 14),
(43, 15),
(43, 16),
(43, 17),
(44, 18),
(44, 19),
(44, 20),
(45, 21),
(45, 22),
(45, 23),
(46, 24),
(46, 25),
(46, 26),
(47, 27),
(47, 28),
(47, 29),
(48, 30),
(48, 31),
(48, 32),
(49, 33),
(49, 34),
(49, 35),
(50, 36),
(50, 37),
(50, 18),
(50, 19),
(50, 20);

INSERT INTO StudentGrades (StudentID, CourseID, SectionID, Grade)
VALUES
    (1, 1, 1, 'A+'),
    (2, 1, 1, 'B'),
    (3, 1, 1, 'C'),
    (4, 1, 1, 'B'),
    (5, 1, 1, 'A+'),
    (6, 1, 1, 'C'),
    (7, 1, 1, 'D');

INSERT INTO AuditLog (OperationType, TableName, UserID)
VALUES ('Insert', 'Table1', 'admin1'),
       ('Update', 'Table2', 'admin2'),
       ('Delete', 'Table3', 'User3'),
       ('Insert', 'Table1', 'User4'),
       ('Update', 'Table2', 'User5');

INSERT INTO Student (StudentID, RollNo, Fname, Lname, DOB, Email, Password, PhoneNo, DateOfAdmission, CGPA, CreditHours, Address) VALUES 
(61, 21061, 'noman', 'Ahmed', '07-4-1999', '21061@nu.edu.pk', '9596x', '3001-23-4567', '14-06-2018',  0.0, 12, 'House No. 132, Street No. 53, I-4/1, Islamabad'),
(62, 21062, 'osama', 'ali', '07-2-1999', '21062@nu.edu.pk', '9sU6x', '3001-23-4560', '14-06-2018',  0.0, 12, 'House No. 110, Street No. 33, G-5/2, Islamabad');

