USE [Logs]
GO

/****** Object: Table [dbo].[Logs] Script Date: 22/03/2018 19:54:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Logs] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [Date]               DATETIME2 (7)  NOT NULL,
    [GeolocationId]      INT            NULL,
    [Host]               NVARCHAR (MAX) NULL,
    [Length]             INT            NULL,
    [Method]             NVARCHAR (MAX) NULL,
    [Route]              NVARCHAR (MAX) NULL,
    [StatusCode]         INT            NOT NULL,
    [UrlQueryParameters] NVARCHAR (MAX) NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_Logs_GeolocationId]
    ON [dbo].[Logs]([GeolocationId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Logs_Id]
    ON [dbo].[Logs]([Id] ASC);


GO
ALTER TABLE [dbo].[Logs]
    ADD CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([Id] ASC);


GO
ALTER TABLE [dbo].[Logs]
    ADD CONSTRAINT [FK_Logs_Geolocations_GeolocationId] FOREIGN KEY ([GeolocationId]) REFERENCES [dbo].[Geolocations] ([Id]);


