CREATE TABLE [dbo].[operaciones] (
    [id]       INT          IDENTITY (1, 1) NOT NULL,
    [nombre]   VARCHAR (50) NULL,
    [idModulo] INT          NULL,
    CONSTRAINT [PK_operaciones] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_operaciones_modulo] FOREIGN KEY ([idModulo]) REFERENCES [dbo].[modulo] ([id])
);

