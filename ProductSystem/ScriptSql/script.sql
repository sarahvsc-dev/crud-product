CREATE DATABASE ProductSystem;
GO

USE ProductSystem;
GO

CREATE TABLE Products
(
    Id INT IDENTITY(1,1) PRIMARY KEY,

    RegistrationDate DATETIME NOT NULL,

    RegisteredBy NVARCHAR(100) NOT NULL,

    Description NVARCHAR(255) NOT NULL,

    Quantity INT NOT NULL,

    Value DECIMAL(18,2) NOT NULL
);
GO