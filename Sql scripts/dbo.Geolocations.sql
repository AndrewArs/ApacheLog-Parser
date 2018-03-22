USE [Logs]
GO

/****** Object: Table [dbo].[Geolocations] Script Date: 22/03/2018 19:55:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Geolocations] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [CountryCode] NVARCHAR (MAX) NULL,
    [CountryName] NVARCHAR (MAX) NULL,
    [Ip]          NVARCHAR (MAX) NULL,
    [Latitude]    FLOAT (53)     NOT NULL,
    [Longitude]   FLOAT (53)     NOT NULL,
    [MetroCode]   INT            NOT NULL,
    [RegionCode]  NVARCHAR (MAX) NULL,
    [RegionName]  NVARCHAR (MAX) NULL,
    [TimeZone]    NVARCHAR (MAX) NULL,
    [ZipCode]     NVARCHAR (MAX) NULL
);


