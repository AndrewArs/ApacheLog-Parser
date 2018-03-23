CREATE DATABASE [Logs];

USE [Logs]
GO

/****** Object: Table [dbo].[Logs] Script Date: 23/03/2018 13:18:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Logs] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [Date]               DATETIME2 (7)  NOT NULL,
    [Geolocation]        NVARCHAR (MAX) NULL,
    [Host]               NVARCHAR (MAX) NULL,
    [Length]             INT            NULL,
    [Method]             NVARCHAR (MAX) NULL,
    [Route]              NVARCHAR (MAX) NULL,
    [StatusCode]         INT            NOT NULL,
    [UrlQueryParameters] NVARCHAR (MAX) NULL
);


