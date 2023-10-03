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

CREATE TABLE [CEP] (
    [Cep] nvarchar(450) NOT NULL,
    [Logradouro] nvarchar(max) NOT NULL,
    [Endereco] nvarchar(max) NOT NULL,
    [Bairro] nvarchar(max) NOT NULL,
    [Cidade] nvarchar(max) NOT NULL,
    [UF] nvarchar(max) NOT NULL,
    [Latitude] nvarchar(max) NOT NULL,
    [Longitude] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_CEP] PRIMARY KEY ([Cep])
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

CREATE TABLE [Frotas] (
    [Id_Veiculo] int NOT NULL IDENTITY,
    [P_Veiculo] nvarchar(max) NOT NULL,
    [Tmn_Veiculo] real NOT NULL,
    [Di_Veiculo] datetime2 NOT NULL,
    [St_Veiculo] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Frotas] PRIMARY KEY ([Id_Veiculo])
);
GO

CREATE TABLE [Motoristas] (
    [Id_Motorista] int NOT NULL IDENTITY,
    [Nm_Motorista] nvarchar(max) NOT NULL,
    [Dc_Motorista] datetime2 NOT NULL,
    [St_Motorista] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Motoristas] PRIMARY KEY ([Id_Motorista])
);
GO

CREATE TABLE [Periodos] (
    [Id] int NOT NULL IDENTITY,
    [Ds_Periodo] nvarchar(max) NOT NULL,
    [Mi_Periodo] nvarchar(max) NOT NULL,
    [Mf_Periodo] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Periodos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Ruas] (
    [Id] int NOT NULL IDENTITY,
    [Cep] nvarchar(max) NOT NULL,
    [Cep1] nvarchar(450) NULL,
    CONSTRAINT [PK_Ruas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Ruas_CEP_Cep1] FOREIGN KEY ([Cep1]) REFERENCES [CEP] ([Cep])
);
GO

CREATE TABLE [Colaboradores] (
    [Id] int NOT NULL IDENTITY,
    [Empresa_Id] int NOT NULL,
    [Nome] nvarchar(60) NOT NULL,
    [dbColaborador] nvarchar(14) NOT NULL,
    [stColaborador] nvarchar(1) NOT NULL,
    [EmpresaId] int NULL,
    CONSTRAINT [PK_Colaboradores] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Colaboradores_Empresas_EmpresaId] FOREIGN KEY ([EmpresaId]) REFERENCES [Empresas] ([Id]),
    CONSTRAINT [FK_Colaboradores_Empresas_Empresa_Id] FOREIGN KEY ([Empresa_Id]) REFERENCES [Empresas] ([Id])
);
GO

CREATE TABLE [Kilometragens] (
    [Id_Veiculo] int NOT NULL IDENTITY,
    [FrotaId_Veiculo] int NOT NULL,
    [Kilometragem] int NOT NULL,
    [seKilometragem] nvarchar(max) NOT NULL,
    [diKilometragem] datetime2 NOT NULL,
    CONSTRAINT [PK_Kilometragens] PRIMARY KEY ([Id_Veiculo]),
    CONSTRAINT [FK_Kilometragens_Frotas_FrotaId_Veiculo] FOREIGN KEY ([FrotaId_Veiculo]) REFERENCES [Frotas] ([Id_Veiculo]) ON DELETE CASCADE
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Sentido da Marcação';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Kilometragens', 'COLUMN', N'seKilometragem';
SET @description = N'Data de início marcação';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Kilometragens', 'COLUMN', N'diKilometragem';
GO

CREATE TABLE [Setores] (
    [Id] int NOT NULL IDENTITY,
    [Id_Colaborador] int NOT NULL,
    [Id_Empresa] int NOT NULL,
    [TipoServico] int NOT NULL,
    [Di_Setor] datetime2 NOT NULL,
    [Da_Setor] datetime2 NOT NULL,
    [St_Setor] nvarchar(max) NOT NULL,
    [EmpresaId] int NULL,
    CONSTRAINT [PK_Setores] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Setores_Colaboradores_Id_Colaborador] FOREIGN KEY ([Id_Colaborador]) REFERENCES [Colaboradores] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Setores_Empresas_EmpresaId] FOREIGN KEY ([EmpresaId]) REFERENCES [Empresas] ([Id]),
    CONSTRAINT [FK_Setores_Empresas_Id_Empresa] FOREIGN KEY ([Id_Empresa]) REFERENCES [Empresas] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Rotas] (
    [IdRota] int NOT NULL IDENTITY,
    [Id_Colaborador] int NOT NULL,
    [Id_Periodo] int NOT NULL,
    [Id_Setor] int NOT NULL,
    [dtRota] int NOT NULL,
    [tmRota] int NOT NULL,
    [SetorId] int NULL,
    CONSTRAINT [PK_Rotas] PRIMARY KEY ([IdRota]),
    CONSTRAINT [FK_Rotas_Colaboradores_Id_Colaborador] FOREIGN KEY ([Id_Colaborador]) REFERENCES [Colaboradores] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Rotas_Periodos_Id_Periodo] FOREIGN KEY ([Id_Periodo]) REFERENCES [Periodos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Rotas_Setores_SetorId] FOREIGN KEY ([SetorId]) REFERENCES [Setores] ([Id])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Distancia da Rota';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Rotas', 'COLUMN', N'dtRota';
SET @description = N'Tempo médio da Rota';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Rotas', 'COLUMN', N'tmRota';
GO

CREATE TABLE [SetorVeiculos] (
    [Id_Setor] int NOT NULL IDENTITY,
    [SetorId] int NOT NULL,
    [Id_Veiculo] int NOT NULL,
    [FrotaId_Veiculo] int NOT NULL,
    CONSTRAINT [PK_SetorVeiculos] PRIMARY KEY ([Id_Setor]),
    CONSTRAINT [FK_SetorVeiculos_Frotas_FrotaId_Veiculo] FOREIGN KEY ([FrotaId_Veiculo]) REFERENCES [Frotas] ([Id_Veiculo]) ON DELETE CASCADE,
    CONSTRAINT [FK_SetorVeiculos_Setores_SetorId] FOREIGN KEY ([SetorId]) REFERENCES [Setores] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Trajetos] (
    [idTrajeto] int NOT NULL IDENTITY,
    [Id_Motorista1] int NOT NULL,
    [Id_RotaId] int NOT NULL,
    [Id_Veiculo1] int NOT NULL,
    [Mi_Trajeto] datetime2 NOT NULL,
    [Mj_Trajeto] datetime2 NOT NULL,
    CONSTRAINT [PK_Trajetos] PRIMARY KEY ([idTrajeto]),
    CONSTRAINT [FK_Trajetos_Frotas_Id_Veiculo1] FOREIGN KEY ([Id_Veiculo1]) REFERENCES [Frotas] ([Id_Veiculo]) ON DELETE CASCADE,
    CONSTRAINT [FK_Trajetos_Motoristas_Id_Motorista1] FOREIGN KEY ([Id_Motorista1]) REFERENCES [Motoristas] ([Id_Motorista]) ON DELETE CASCADE,
    CONSTRAINT [FK_Trajetos_Rotas_Id_RotaId] FOREIGN KEY ([Id_RotaId]) REFERENCES [Rotas] ([IdRota]) ON DELETE CASCADE
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Momento de início do trajeto';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Trajetos', 'COLUMN', N'Mi_Trajeto';
SET @description = N'Momento do fim do trajeto';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Trajetos', 'COLUMN', N'Mj_Trajeto';
GO

CREATE TABLE [Ocorrencias] (
    [IdOcorrencia] int NOT NULL IDENTITY,
    [Id_TrajetoId] int NOT NULL,
    [Tipo_Ocorrencia] int NOT NULL,
    [mtOcorrencia] datetime2 NOT NULL,
    CONSTRAINT [PK_Ocorrencias] PRIMARY KEY ([IdOcorrencia]),
    CONSTRAINT [FK_Ocorrencias_Trajetos_Id_TrajetoId] FOREIGN KEY ([Id_TrajetoId]) REFERENCES [Trajetos] ([idTrajeto]) ON DELETE CASCADE
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Momento da ocorrencia';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ocorrencias', 'COLUMN', N'mtOcorrencia';
GO

CREATE INDEX [IX_Colaboradores_Empresa_Id] ON [Colaboradores] ([Empresa_Id]);
GO

CREATE INDEX [IX_Colaboradores_EmpresaId] ON [Colaboradores] ([EmpresaId]);
GO

CREATE UNIQUE INDEX [IX_Colaboradores_Id] ON [Colaboradores] ([Id]);
GO

CREATE UNIQUE INDEX [IX_Empresas_dc_empresa] ON [Empresas] ([dc_empresa]);
GO

CREATE INDEX [IX_Kilometragens_FrotaId_Veiculo] ON [Kilometragens] ([FrotaId_Veiculo]);
GO

CREATE INDEX [IX_Ocorrencias_Id_TrajetoId] ON [Ocorrencias] ([Id_TrajetoId]);
GO

CREATE UNIQUE INDEX [IX_Ocorrencias_IdOcorrencia] ON [Ocorrencias] ([IdOcorrencia]);
GO

CREATE INDEX [IX_Rotas_Id_Colaborador] ON [Rotas] ([Id_Colaborador]);
GO

CREATE INDEX [IX_Rotas_Id_Periodo] ON [Rotas] ([Id_Periodo]);
GO

CREATE INDEX [IX_Rotas_SetorId] ON [Rotas] ([SetorId]);
GO

CREATE INDEX [IX_Ruas_Cep1] ON [Ruas] ([Cep1]);
GO

CREATE INDEX [IX_Setores_EmpresaId] ON [Setores] ([EmpresaId]);
GO

CREATE INDEX [IX_Setores_Id_Colaborador] ON [Setores] ([Id_Colaborador]);
GO

CREATE INDEX [IX_Setores_Id_Empresa] ON [Setores] ([Id_Empresa]);
GO

CREATE INDEX [IX_SetorVeiculos_FrotaId_Veiculo] ON [SetorVeiculos] ([FrotaId_Veiculo]);
GO

CREATE INDEX [IX_SetorVeiculos_SetorId] ON [SetorVeiculos] ([SetorId]);
GO

CREATE INDEX [IX_Trajetos_Id_Motorista1] ON [Trajetos] ([Id_Motorista1]);
GO

CREATE INDEX [IX_Trajetos_Id_RotaId] ON [Trajetos] ([Id_RotaId]);
GO

CREATE INDEX [IX_Trajetos_Id_Veiculo1] ON [Trajetos] ([Id_Veiculo1]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230926002135_InitialMigrationRuaCepFK', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230926005222_RuaRotaFK', N'7.0.10');
GO

COMMIT;
GO

