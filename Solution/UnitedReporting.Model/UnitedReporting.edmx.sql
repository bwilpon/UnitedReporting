
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/08/2014 14:53:41
-- Generated from EDMX file: C:\TFS\United Reporting\Solution\UnitedReporting.Model\UnitedReporting.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [UnitedReporting];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PageContentCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PageContents] DROP CONSTRAINT [FK_PageContentCategory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[PageContents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PageContents];
GO
IF OBJECT_ID(N'[UnitedReportingStoreContainer].[Contacts]', 'U') IS NOT NULL
    DROP TABLE [UnitedReportingStoreContainer].[Contacts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [ImageUrl] nvarchar(500)  NULL,
    [Sequence] int  NULL
);
GO

-- Creating table 'PageContents'
CREATE TABLE [dbo].[PageContents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [SubTitle] nvarchar(100)  NULL,
    [Body] nvarchar(max)  NOT NULL,
    [ImageUrl] nvarchar(500)  NULL,
    [DisplayImage] bit  NOT NULL,
    [Active] bit  NOT NULL,
    [PublishedDate] datetime  NULL,
    [FriendlyUrl] nvarchar(100)  NULL,
    [CategoryId] int  NOT NULL
);
GO

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(100)  NOT NULL,
    [LastName] varchar(100)  NOT NULL,
    [Phone] varchar(100)  NOT NULL,
    [Email] varchar(100)  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [Message] varchar(max)  NULL,
    [AttorneyFirstName] varchar(100)  NULL,
    [AttorneyLastName] varchar(100)  NULL,
    [FirmName] varchar(100)  NULL,
    [CaseNumber] varchar(50)  NULL,
    [CaseName] varchar(100)  NULL,
    [PreceedingDate] varchar(100)  NULL,
    [RequestedServices] varchar(255)  NULL,
    [NoticeFilePath] varchar(255)  NULL
);
GO

-- Creating table 'TranscriptOrders'
CREATE TABLE [dbo].[TranscriptOrders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderingAttorney] nvarchar(100)  NOT NULL,
    [FirmName] nvarchar(100)  NOT NULL,
    [Address1] nvarchar(100)  NOT NULL,
    [Address2] nvarchar(100)  NOT NULL,
    [City] nvarchar(100)  NOT NULL,
    [State] nvarchar(50)  NOT NULL,
    [Email] nvarchar(100)  NOT NULL,
    [Phone] nvarchar(100)  NOT NULL,
    [CaseStyle] nvarchar(255)  NOT NULL,
    [DateTaken] nvarchar(100)  NOT NULL,
    [DeponentsOrJudge] nvarchar(100)  NOT NULL,
    [DateNeeded] nvarchar(100)  NOT NULL,
    [Excerpt] nvarchar(255)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PageContents'
ALTER TABLE [dbo].[PageContents]
ADD CONSTRAINT [PK_PageContents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TranscriptOrders'
ALTER TABLE [dbo].[TranscriptOrders]
ADD CONSTRAINT [PK_TranscriptOrders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoryId] in table 'PageContents'
ALTER TABLE [dbo].[PageContents]
ADD CONSTRAINT [FK_PageContentCategory]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PageContentCategory'
CREATE INDEX [IX_FK_PageContentCategory]
ON [dbo].[PageContents]
    ([CategoryId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------