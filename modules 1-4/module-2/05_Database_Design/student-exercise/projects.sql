-- Sets the current database to the master database
USE master;
GO

--Drop database if it exists
IF EXISTS(select * from sys.databases where name='ProjectOrganizer')
DROP DATABASE ProjectOrganizer;
GO

--Creates database
CREATE DATABASE ProjectOrganizer;
GO

--swaps the current database to the one that was just made
USE ProjectOrganizer;
GO

--starts transaction to set up the first table
BEGIN TRANSACTION

CREATE TABLE employee (
employee_ID int IDENTITY PRIMARY KEY NOT NULL,
job_title varchar(50) NOT NULL,
last_name varchar(50) NOT NULL,
first_name varchar(50) NOT NULL,
gender varchar(50) NOT NULL,
date_of_birth date NOT NULL,
date_of_hire date NOT NULL,
department_number int NOT NULL);

INSERT INTO employee (job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_number)
VALUES ('Cleric', 'Anskuld', 'Selena', 'Female', '1465-05-13', '1491-07-27', 2), 
('Bard', 'Nemetsk', 'Kasmeen', 'Female', '1468-07-21', '1491-5-30', 2),
('Monk', ' ', 'Methusula', 'Male', '1460-08-19', '1491-05-30', 2), 
('Rogue', 'Dei Librei', 'Gabriel', 'Male', '1458-09-3', '1491-07-25', 1),
('Warlock', 'Nemetsk', 'Chloe', 'Female', '1468-05-24', '1491-05-30', 1),
('Wizard', 'Dre''ali', 'Anastriana', 'Female', '1221-02-1', '1491-12-30', 1),
('Necromancer', 'Orieth', 'Lord', 'Male', '1455-09-7', '1491-05-30', 3),
('Patron', 'Howard', 'Diedre', 'Female', '1116-01-30', '1491-12-30', 3),
('Devil', 'Mavros', 'Zariel', 'Female', '0001-01-01', '1492-05-30', 3);

COMMIT TRANSACTION

BEGIN TRANSACTION

CREATE TABLE department (
department_number int IDENTITY PRIMARY KEY NOT NULL,
name varchar(50) NOT NULL);

INSERT INTO department (name)
VALUES ('Party'),
('Former Party'),
('NPC');

COMMIT TRANSACTION

BEGIN TRANSACTION

CREATE TABLE project (
project_number int IDENTITY PRIMARY KEY NOT NULL,
name varchar(50) NOT NULL,
start_date date NOT NULL);

INSERT INTO project (name, start_date)
VALUES ('Overthrow Earth Cult', '1491-05-30'),
('Overthrow Air Cult', '1491-07-23'),
('Overthrow Water Cult', '1491-09-1'),
('Overthrow Fire Cult', '1491-09-20'),
('Overthrow Zariel', '1492-05-30');

COMMIT TRANSACTION

ALTER TABLE employee
ADD FOREIGN KEY (department_number) REFERENCES department(department_number);

-- I know that right now project is not linked to employee, but I can't quite wrap my brain around it. so I left it out and will ask later.