USE master;
GO

DROP DATABASE IF EXISTS [user-manager];
GO

CREATE DATABASE [user-manager];
GO

USE [user-manager];
GO

DROP TABLE IF EXISTS users;

CREATE TABLE users (
  id INT IDENTITY PRIMARY KEY,
  username VARCHAR(255) NOT NULL UNIQUE, -- Username
  password VARCHAR(48) NOT NULL, -- Hashed Password
  salt VARCHAR(256) NOT NULL -- Password Salt
);

GO
