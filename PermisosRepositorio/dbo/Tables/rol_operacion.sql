CREATE TABLE [dbo].[rol_operacion] (
    [id]          INT IDENTITY (1, 1) NOT NULL,
    [idRol]       INT NULL,
    [idOperacion] INT NULL,
    CONSTRAINT [PK_perfil_operacion] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_rol_operacion_operaciones] FOREIGN KEY ([idOperacion]) REFERENCES [dbo].[operaciones] ([id]),
    CONSTRAINT [FK_rol_operacion_rol] FOREIGN KEY ([idRol]) REFERENCES [dbo].[rol] ([id])
);

