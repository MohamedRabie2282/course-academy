create database CourseAcademyDB 
create table course
(
course_Pid int primary key ,
course_end_date date,
course_stdate date,
course_name varchar(50)
);

create table Instructor
(
CO_ID int,
inst_Pid int primary key ,
inst_name varchar(50),
inst_ssn int unique,
inst_gender varchar(50),
inst_salary int check(inst_salary > 0),
inst_mail varchar(50) unique
foreign key (CO_ID) references course(course_Pid)
);

create table Student
(
CO_ID int,
st_Pid int primary key,
st_address varchar(50),
st_number int unique,
st_age int check(st_age > 0),
st_name varchar(50),
st_mail varchar(50) unique,
st_ssn int unique
foreign key (CO_ID) references course(course_Pid)
);

create table solve
(
CO_ID int unique,
ST_iD  int unique,
foreign key (ST_iD) references student(st_Pid),
foreign key (CO_ID) references course(course_Pid)
);

create table assignment
(
CO_ID int ,
INST_ID int,
assign_deadline date,
assign_description varchar(100) primary key ,
assign_name varchar(50),
foreign key (CO_ID) references course(course_Pid),
foreign key(INST_ID) references Instructor(inst_Pid)
);

create table ac_admin
(
Co_ID int ,
adm_Pid int Primary key ,
adm_mail varchar(50),
adm_salary int check(adm_salary > 0),
adm_name varchar(50),
foreign key (Co_ID) references course(course_Pid)
);


--INSERT INTO course (course_Pid, course_end_date, course_stdate, course_name) VALUES
--(201,'2024-12-15', '2024-01-10', 'Computer Science 101');

--INSERT INTO Instructor (CO_ID, inst_Pid, inst_name, inst_ssn, inst_gender, inst_salary, inst_mail) VALUES
--(201, 401, 'John Doe', 123456789, 'Male', 70000, 'john.doe@example.com');

--INSERT INTO Student (CO_id,st_Pid, st_address, st_number, st_age, st_name, st_mail, st_ssn) VALUES
--(201, 2001, 'matai',01050180720, 21, 'Jane Smith', 'jane.smith@example.com', 987654321);
--INSERT INTO solve (CO_ID, ST_ID) VALUES
--(201, 2001);

--INSERT INTO assignment (CO_ID, INST_ID, assign_deadline, assign_description, assign_name) VALUES
--(201, 401, '2024-05-01', 'Midterm Exam', 'Midterm');

--INSERT INTO ac_admin (CO_ID, adm_Pid, adm_mail, adm_salary, adm_name) VALUES
--(201, 900, 'admin@example.com', 50000, 'Alice Johnson');

select* from Student
select* from Instructor
select* from course
select* from ac_admin
select* from solve
select* from assignment
--Third input
--INSERT INTO course (course_Pid, course_end_date, course_stdate, course_name) VALUES
--(301,'2024-1-15', '2023-01-10', 'IT 101');

--INSERT INTO Instructor (CO_ID, inst_Pid, inst_name, inst_ssn, inst_gender, inst_salary, inst_mail) VALUES
--(301, 301, 'Mark', 10234567, 'Male', 70000, 'mark@example.com');

--INSERT INTO Student (CO_id,st_Pid, st_address, st_number, st_age, st_name, st_mail, st_ssn) VALUES
--(301, 3001, 'Malawi',01025460720, 20, 'emila Smith', 'emila.smith@example.com',522288482);
--INSERT INTO solve (CO_ID, ST_ID) VALUES
--(301,3001);

--INSERT INTO assignment (CO_ID, INST_ID, assign_deadline, assign_description, assign_name) VALUES
--(301, 301, '2024-12-01', 'Section Exam', 'Section');

--INSERT INTO ac_admin (CO_ID, adm_Pid, adm_mail, adm_salary, adm_name) VALUES
--(301, 300, 'admins@example.com', 80000, 'Belal');