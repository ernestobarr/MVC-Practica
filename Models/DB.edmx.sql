
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/19/2023 15:25:49
-- Generated from EDMX file: C:\Users\ernes\OneDrive\Escritorio\MVCPractica\MVC1\Models\DB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Clasifica];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_user_status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[users] DROP CONSTRAINT [FK_user_status];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[status];
GO
IF OBJECT_ID(N'[dbo].[users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'status'
CREATE TABLE [dbo].[status] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NULL
);
GO

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [id] int IDENTITY(1,1) NOT NULL,
    [email] nvarchar(50)  NULL,
    [password] nvarchar(255)  NULL,
    [idStatus] int  NULL,
    [edad] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'status'
ALTER TABLE [dbo].[status]
ADD CONSTRAINT [PK_status]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [PK_users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idStatus] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [FK_user_status]
    FOREIGN KEY ([idStatus])
    REFERENCES [dbo].[status]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_user_status'
CREATE INDEX [IX_FK_user_status]
ON [dbo].[users]
    ([idStatus]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------