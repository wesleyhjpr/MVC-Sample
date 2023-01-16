USE [mvc]
GO

/****** Object: Table [dbo].[Cliente] Script Date: 1/15/2023 7:55:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Nome]         VARCHAR (30)     NOT NULL,
    [Email]        VARCHAR (30)     NOT NULL,
    [DataCadastro] DATETIME         NOT NULL,
    [Ativo]        BIT              NULL
);


