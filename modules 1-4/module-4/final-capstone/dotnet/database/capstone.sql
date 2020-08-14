USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE Students (
	Id int IDENTITY(1,1) NOT NULL,
	FirstName nvarchar(128) NOT NULL,
	LastName nvarchar(128) NOT NULL,
	Email nvarchar(255),
	Phone nvarchar(22),
	Notes nvarchar(max),
	GPA decimal(3, 2) NOT NULL DEFAULT 1.0,
	CONSTRAINT PK_Students PRIMARY KEY (Id)
)

--populate default users: 'password'
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

INSERT INTO Students (FirstName, LastName, Email, Phone, GPA, Notes) VALUES ('Dave', 'Miller', 'BoringDave@Scumm.org', null, 3.47, 'Likeable guy. Dating a cheerleader.');
INSERT INTO Students (FirstName, LastName, Email, Phone, GPA, Notes) VALUES ('Syd', 'Tunes', null, null, 1.23, 'Does not appear to ever be fully awake or alert');
INSERT INTO Students (FirstName, LastName, Email, Phone, GPA, Notes) VALUES ('Michael', 'Durst', 'MichaelNews@ScummNews.org', '1-614-555-9863', 3.81, 'Caught stealing photography materials from the school');
INSERT INTO Students (FirstName, LastName, Email, Phone, GPA, Notes) VALUES ('Wendy', 'King', 'WendyWrites@scumm.org', null, 3.92, 'Given detention for using gym time to study');
INSERT INTO Students (FirstName, LastName, Email, Phone, GPA, Notes) VALUES ('Bernard', 'Bernuoulli', 'GeekPhysics@scumm.org', '1-614-555-3594', 4.00, 'Exhibits nearly irrational terror of even the smallest sources of fear');
INSERT INTO Students (FirstName, LastName, Email, Phone, GPA, Notes) VALUES ('Razor', 'Goth', null, null, 2.35, 'Only seems to be interested in musical classes');

GO

-- TODO: Add any further tables, seed values etc.

--select * from Students