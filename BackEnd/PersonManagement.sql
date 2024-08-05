--create database BaiTapLayDiem;

CREATE TABLE Address (
    AddressID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Number INT NOT NULL
);

CREATE TABLE Person (
    PersonID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(20),
    EmailAddress NVARCHAR(255),
    AddressID INT,
    FOREIGN KEY (AddressID) REFERENCES Address(AddressID)
);

CREATE TABLE Student (
    StudentID INT PRIMARY KEY,
    StudentNumber NVARCHAR(50) NOT NULL,
    AverageMark DECIMAL(4, 2),
    FOREIGN KEY (StudentID) REFERENCES Person(PersonID)
);

CREATE TABLE Professor (
    ProfessorID INT PRIMARY KEY,
    Salary DECIMAL(10, 2),
    FOREIGN KEY (ProfessorID) REFERENCES Person(PersonID)
);

INSERT INTO Address (Name, Number) VALUES ('Hà Nội', 30);
INSERT INTO Address (Name, Number) VALUES ('TP HCM', 45);
INSERT INTO Address (Name, Number) VALUES ('Đà Nẵng', 12);

INSERT INTO Person (Name, PhoneNumber, EmailAddress, AddressID) VALUES ('Nuyễn Văn Khanh', '0123456789', 'nguyenvana@example.com', 1);
INSERT INTO Person (Name, PhoneNumber, EmailAddress, AddressID) VALUES ('Lew Thị Cẩm Tú', '0987654321', 'lethib@example.com', 2);
INSERT INTO Person (Name, PhoneNumber, EmailAddress, AddressID) VALUES ('Trần Văn Cường', '0912345678', 'tranvanc@example.com', 3);

INSERT INTO Student (StudentID, StudentNumber, AverageMark) VALUES (1, '000001', 8.5);
INSERT INTO Student (StudentID, StudentNumber, AverageMark) VALUES (2, '000002', 7.3);
INSERT INTO Student (StudentID, StudentNumber, AverageMark) VALUES (3, '000003', 9.0);

INSERT INTO Professor (ProfessorID, Salary) VALUES (1, 15000000.00);
INSERT INTO Professor (ProfessorID, Salary) VALUES (2, 20000000.00);
INSERT INTO Professor (ProfessorID, Salary) VALUES (3, 18000000.00);
