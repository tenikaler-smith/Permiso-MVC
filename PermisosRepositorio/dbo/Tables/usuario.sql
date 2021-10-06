CREATE TABLE [dbo].[usuario] (
    [id]       INT           IDENTITY (1, 1) NOT NULL,
    [nombre]   VARCHAR (50)  NULL,
    [email]    VARCHAR (50)  NULL,
    [password] VARCHAR (200) NULL,
    [fecha]    DATETIME      NULL,
    [idRol]    INT           NULL,
    CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_usuario_rol] FOREIGN KEY ([idRol]) REFERENCES [dbo].[rol] ([id])
);

