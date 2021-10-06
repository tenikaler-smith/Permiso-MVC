CREATE TABLE [dbo].[CatCorregimientos] (
    [IdCorregimiento]     INT           IDENTITY (1, 1) NOT NULL,
    [NombreCorregimiento] VARCHAR (150) NOT NULL,
    [IdDistrito]          INT           NOT NULL,
    CONSTRAINT [PK_CatCorregimientos] PRIMARY KEY CLUSTERED ([IdCorregimiento] ASC),
    CONSTRAINT [FK_CatCorregimientosCatDistritos] FOREIGN KEY ([IdDistrito]) REFERENCES [dbo].[CatDistritos] ([IdDistrito])
);

