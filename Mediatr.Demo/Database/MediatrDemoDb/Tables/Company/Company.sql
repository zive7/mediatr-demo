﻿CREATE TABLE [dbo].[Company]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR(150) NOT NULL, 
    [Number] NVARCHAR(100) NOT NULL,
	CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([Id] ASC),
)
