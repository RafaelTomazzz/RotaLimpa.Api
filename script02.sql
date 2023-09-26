IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Colaboradores] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(60) NOT NULL,
    [dbColaborador] nvarchar(14) NOT NULL,
    [stColaborador] nvarchar(1) NOT NULL,
    CONSTRAINT [PK_Colaboradores] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Empresas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(40) NOT NULL,
    [dc_empresa] nvarchar(18) NOT NULL,
    [st_empresa] int NOT NULL,
    [di_empresa] datetime2 NOT NULL,
    [da_empresa] datetime2 NOT NULL,
    CONSTRAINT [PK_Empresas] PRIMARY KEY ([Id])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'CNPJ';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Empresas', 'COLUMN', N'dc_empresa';
SET @description = N'SITUAÇÃO DA EMPRESA';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Empresas', 'COLUMN', N'st_empresa';
SET @description = N'DATA DE INCLUSÃO';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Empresas', 'COLUMN', N'di_empresa';
SET @description = N'DATA DA ULTIMA ALTERAÇÃO';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Empresas', 'COLUMN', N'da_empresa';
GO

CREATE UNIQUE INDEX [IX_Colaboradores_Id] ON [Colaboradores] ([Id]);
GO

CREATE UNIQUE INDEX [IX_Empresas_dc_empresa] ON [Empresas] ([dc_empresa]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230912002333_InicialMigracion', N'7.0.10');
GO

COMMIT;
GO

