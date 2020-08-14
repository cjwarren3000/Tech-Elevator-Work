
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the World Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='PetInfo')
DROP DATABASE PetInfo;
GO

-- Create a new World Database
CREATE DATABASE PetInfo;
GO

-- Switch to the World Database
USE PetInfo
GO

-- Begin a TRANSACTION that must complete with no errors
BEGIN TRANSACTION;

CREATE TABLE pet (
    id INT IDENTITY PRIMARY KEY,
    petname NVARCHAR(30) NOT NULL,
    familyname NVARCHAR(30) NOT NULL,
    pettype NVARCHAR(30) NOT NULL
   );


INSERT INTO pet (petname, familyname, pettype) VALUES ('Bella', 'Fulton', 'Dog');
INSERT INTO pet (petname, familyname, pettype) VALUES ('Primrose', 'Fulton', 'Cat');
INSERT INTO pet (petname, familyname, pettype) VALUES ('Penny', 'Fulton', 'Cat');
INSERT INTO pet (petname, familyname, pettype) VALUES ('Gabriel', 'Fulton', 'Cat');


COMMIT TRANSACTION;