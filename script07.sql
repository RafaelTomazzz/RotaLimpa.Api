BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231108232937_Teste', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Kilometragem] DROP CONSTRAINT [FK_Kilometragem_Frota_FrotaId_Veiculo];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Setor]') AND [c].[name] = N'Da_Setor');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Setor] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Setor] ALTER COLUMN [Da_Setor] datetime2 NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kilometragem]') AND [c].[name] = N'FrotaId_Veiculo');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Kilometragem] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Kilometragem] ALTER COLUMN [FrotaId_Veiculo] int NULL;
GO

ALTER TABLE [Kilometragem] ADD CONSTRAINT [FK_Kilometragem_Frota_FrotaId_Veiculo] FOREIGN KEY ([FrotaId_Veiculo]) REFERENCES [Frota] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231108234856_TesteData', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231108235257_TesteStSetor', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231109004945_AjusteColaboradorEmpresa', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231109005248_Ajuste', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231109005450_SlaMn', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
EXEC sp_dropextendedproperty 'MS_Description', 'SCHEMA', @defaultSchema, 'TABLE', N'Motorista', 'COLUMN', N'Dc_Motorista';
SET @description = N'Data de cria��o do Motorista';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Motorista', 'COLUMN', N'Dc_Motorista';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231110010538_MigracaoMotorista', N'7.0.10');
GO

COMMIT;
GO

