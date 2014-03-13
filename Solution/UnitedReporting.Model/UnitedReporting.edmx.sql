
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/12/2014 22:15:19
-- Generated from EDMX file: C:\TFS\UnitedReporting\Solution\UnitedReporting.Model\UnitedReporting.edmx
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


IF OBJECT_ID(N'[UnitedReportingStoreContainer].[TranscriptOrders]', 'U') IS NOT NULL
    DROP TABLE [UnitedReportingStoreContainer].[TranscriptOrders];
GO



-- Creating table 'TranscriptOrders'
CREATE TABLE [dbo].[TranscriptOrders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderingAttorney] nvarchar(100)  NULL,
    [FirmName] nvarchar(100)  NULL,
    [Address1] nvarchar(100)  NULL,
    [Address2] nvarchar(100)  NULL,
    [City] nvarchar(100)  NULL,
    [State] nvarchar(50)  NULL,
    [Email] nvarchar(100)  NULL,
    [Phone] nvarchar(100)  NULL,
    [CaseStyle] nvarchar(255)  NULL,
    [DateTaken] nvarchar(100)  NULL,
    [DeponentsOrJudge] nvarchar(100)  NULL,
    [DateNeeded] nvarchar(100)  NULL,
    [Excerpt] nvarchar(255)  NULL,
    [CreatedOn] datetime  NOT NULL DEFAULT (getdate()) 
);
GO

-- Creating primary key on [Id] in table 'TranscriptOrders'
ALTER TABLE [dbo].[TranscriptOrders]
ADD CONSTRAINT [PK_TranscriptOrders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

