CREATE TABLE [dbo].[Cliente] (
    [IdCliente]       BIGINT        IDENTITY (1, 1) NOT NULL,
    [Nombre]          VARCHAR (250) NULL,
    [Apellido]        VARCHAR (250) NULL,
    [Sexo]            BIT           NULL,
    [Email]           VARCHAR (100) NULL,
    [IdDirrecion]     INT           NULL,
    [IdProvincia]     INT           NULL,
    [IdDistrito]      INT           NULL,
    [IdCorregimiento] INT           NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([IdCliente] ASC),
    CONSTRAINT [FK_ClienteCatCorregimientos] FOREIGN KEY ([IdCorregimiento]) REFERENCES [dbo].[CatCorregimientos] ([IdCorregimiento]),
    CONSTRAINT [FK_ClienteCatDistrito] FOREIGN KEY ([IdDistrito]) REFERENCES [dbo].[CatDistritos] ([IdDistrito]),
    CONSTRAINT [FK_ClienteCatProvincia] FOREIGN KEY ([IdProvincia]) REFERENCES [dbo].[CatProvincia] ([IdProvincia])
);

