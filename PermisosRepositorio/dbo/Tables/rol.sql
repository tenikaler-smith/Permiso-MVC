CREATE TABLE [dbo].[rol] (
    [id]     INT          IDENTITY (1, 1) NOT NULL,
    [nombre] VARCHAR (50) NULL,
    CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED ([id] ASC)
);

