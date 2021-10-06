CREATE TABLE [dbo].[CatDistritos] (
    [IdDistrito]     INT           IDENTITY (1, 1) NOT NULL,
    [NombreDistrito] VARCHAR (150) NOT NULL,
    [IdProvincia]    INT           NOT NULL,
    CONSTRAINT [PK_CatDistritos] PRIMARY KEY CLUSTERED ([IdDistrito] ASC),
    CONSTRAINT [FK_CatDistritosCatProvincia] FOREIGN KEY ([IdProvincia]) REFERENCES [dbo].[CatProvincia] ([IdProvincia])
);

