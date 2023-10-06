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
    [Cep] nvarchar(8) NOT NULL,
    [Logradouro] nvarchar(25) NOT NULL,
    [Endereço] nvarchar(60) NOT NULL,
    [Bairro] nvarchar(35) NOT NULL,
    [Cidade] nvarchar(35) NOT NULL,
    [UF] CHAR(2) NOT NULL,
    [latitude] nvarchar(25) NOT NULL,
    [longitude] nvarchar(25) NOT NULL,
    CONSTRAINT [PK_CEP] PRIMARY KEY ([Cep])
);
GO

CREATE TABLE [Empresa] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(40) NOT NULL,
    [Dc_Empresa] nvarchar(18) NOT NULL,
    [St_empresa] int NOT NULL,
    [Di_empresa] datetime2 NOT NULL,
    [Da_empresa] datetime2 NOT NULL,
    CONSTRAINT [PK_Empresa] PRIMARY KEY ([Id])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'CNPJ';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Empresa', 'COLUMN', N'Dc_Empresa';
SET @description = N'SITUAÇÃO DA EMPRESA';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Empresa', 'COLUMN', N'St_empresa';
SET @description = N'DATA DE INCLUSÃO';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Empresa', 'COLUMN', N'Di_empresa';
SET @description = N'DATA DA ULTIMA ALTERAÇÃO';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Empresa', 'COLUMN', N'Da_empresa';
GO

CREATE TABLE [Frota] (
    [Id] int NOT NULL IDENTITY,
    [P_Veiculo] nvarchar(max) NOT NULL,
    [Tmn_Veiculo] float NOT NULL,
    [Di_Veiculo] datetime2 NOT NULL,
    [St_Veiculo] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Frota] PRIMARY KEY ([Id])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Tamanho do veículo';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Frota', 'COLUMN', N'Tmn_Veiculo';
GO

CREATE TABLE [Motorista] (
    [Id] int NOT NULL IDENTITY,
    [Nm_Motorista] nvarchar(max) NOT NULL,
    [Dc_Motorista] datetime2 NOT NULL,
    [St_Motorista] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Motorista] PRIMARY KEY ([Id])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Nome do motorista';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Motorista', 'COLUMN', N'Nm_Motorista';
SET @description = N'Data de criação do Motorista';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Motorista', 'COLUMN', N'Dc_Motorista';
GO

CREATE TABLE [Periodo] (
    [Id] int NOT NULL IDENTITY,
    [Ds_Periodo] nvarchar(max) NOT NULL,
    [Mi_Periodo] nvarchar(max) NOT NULL,
    [Mf_Periodo] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Periodo] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Colaborador] (
    [Id] int NOT NULL IDENTITY,
    [EmpresaId] int NOT NULL,
    [Nome] nvarchar(60) NOT NULL,
    [DcColaborador] nvarchar(14) NOT NULL,
    [StColaborador] nvarchar(1) NOT NULL,
    CONSTRAINT [PK_Colaborador] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Colaborador_Empresa_EmpresaId] FOREIGN KEY ([EmpresaId]) REFERENCES [Empresa] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Kilometragem] (
    [Id_Veiculo] int NOT NULL IDENTITY,
    [FrotaId_Veiculo] int NOT NULL,
    [Km] int NOT NULL,
    [Se_Kilometragem] nvarchar(max) NOT NULL,
    [Di_Kilometragem] datetime2 NOT NULL,
    CONSTRAINT [PK_Kilometragem] PRIMARY KEY ([Id_Veiculo]),
    CONSTRAINT [FK_Kilometragem_Frota_FrotaId_Veiculo] FOREIGN KEY ([FrotaId_Veiculo]) REFERENCES [Frota] ([Id]) ON DELETE CASCADE
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Kilometragem do veículo';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Kilometragem', 'COLUMN', N'Km';
SET @description = N'Sentido da Marcação';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Kilometragem', 'COLUMN', N'Se_Kilometragem';
SET @description = N'Data de início marcação';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Kilometragem', 'COLUMN', N'Di_Kilometragem';
GO

CREATE TABLE [Setor] (
    [Id] int NOT NULL IDENTITY,
    [ColaboradorId] int NOT NULL,
    [IdEmpresa] int NOT NULL,
    [TipoServico] int NOT NULL,
    [Di_Setor] datetime2 NOT NULL,
    [Da_Setor] datetime2 NOT NULL,
    [St_Setor] nvarchar(max) NOT NULL,
    [EmpresaId] int NULL,
    CONSTRAINT [PK_Setor] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Setor_Colaborador_ColaboradorId] FOREIGN KEY ([ColaboradorId]) REFERENCES [Colaborador] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Setor_Empresa_EmpresaId] FOREIGN KEY ([EmpresaId]) REFERENCES [Empresa] ([Id])
);
GO

CREATE TABLE [Rota] (
    [Id] int NOT NULL IDENTITY,
    [ColaboradorId] int NOT NULL,
    [IdPeriodo] int NOT NULL,
    [SetorId] int NOT NULL,
    [Dt_Rota] int NOT NULL,
    [Tm_Rota] int NOT NULL,
    CONSTRAINT [PK_Rota] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Rota_Colaborador_ColaboradorId] FOREIGN KEY ([ColaboradorId]) REFERENCES [Colaborador] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Rota_Periodo_IdPeriodo] FOREIGN KEY ([IdPeriodo]) REFERENCES [Periodo] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Rota_Setor_SetorId] FOREIGN KEY ([SetorId]) REFERENCES [Setor] ([Id]) ON DELETE NO ACTION
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Distancia da Rota';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Rota', 'COLUMN', N'Dt_Rota';
SET @description = N'Tempo médio da Rota';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Rota', 'COLUMN', N'Tm_Rota';
GO

CREATE TABLE [SetorVeiculo] (
    [Id] int NOT NULL,
    [IdFrota] int NOT NULL,
    [FrotaId_Veiculo] int NOT NULL,
    CONSTRAINT [PK_SetorVeiculo] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SetorVeiculo_Frota_FrotaId_Veiculo] FOREIGN KEY ([FrotaId_Veiculo]) REFERENCES [Frota] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_SetorVeiculo_Setor_Id] FOREIGN KEY ([Id]) REFERENCES [Setor] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Rua] (
    [Id] int NOT NULL IDENTITY,
    [Cep] nvarchar(8) NOT NULL,
    [RotaId] int NOT NULL,
    CONSTRAINT [PK_Rua] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Rua_CEP_Cep] FOREIGN KEY ([Cep]) REFERENCES [CEP] ([Cep]) ON DELETE CASCADE,
    CONSTRAINT [FK_Rua_Rota_RotaId] FOREIGN KEY ([RotaId]) REFERENCES [Rota] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Trajeto] (
    [Id] int NOT NULL,
    [IdMotorista] int NOT NULL,
    [IdRota] int NOT NULL,
    [IdFrota] int NOT NULL,
    [Mi_Trajeto] datetime2 NOT NULL,
    [Mj_Trajeto] datetime2 NOT NULL,
    CONSTRAINT [PK_Trajeto] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Trajeto_Frota_Id] FOREIGN KEY ([Id]) REFERENCES [Frota] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Trajeto_Motorista_IdMotorista] FOREIGN KEY ([IdMotorista]) REFERENCES [Motorista] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Trajeto_Rota_IdRota] FOREIGN KEY ([IdRota]) REFERENCES [Rota] ([Id]) ON DELETE CASCADE
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Momento de início do trajeto';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Trajeto', 'COLUMN', N'Mi_Trajeto';
SET @description = N'Momento do fim do trajeto';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Trajeto', 'COLUMN', N'Mj_Trajeto';
GO

CREATE TABLE [Ocorrencia] (
    [Id] int NOT NULL IDENTITY,
    [Id_Trajeto] int NOT NULL,
    [TipoOcorrencia] int NOT NULL,
    [MtOcorrencia] datetime2 NOT NULL,
    CONSTRAINT [PK_Ocorrencia] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Ocorrencia_Trajeto_Id_Trajeto] FOREIGN KEY ([Id_Trajeto]) REFERENCES [Trajeto] ([Id]) ON DELETE CASCADE
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Data domento da ocorr�ncia';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ocorrencia', 'COLUMN', N'MtOcorrencia';
GO

CREATE INDEX [IX_Colaborador_EmpresaId] ON [Colaborador] ([EmpresaId]);
GO

CREATE UNIQUE INDEX [IX_Colaborador_Id] ON [Colaborador] ([Id]);
GO

CREATE UNIQUE INDEX [IX_Empresa_Dc_Empresa] ON [Empresa] ([Dc_Empresa]);
GO

CREATE INDEX [IX_Kilometragem_FrotaId_Veiculo] ON [Kilometragem] ([FrotaId_Veiculo]);
GO

CREATE UNIQUE INDEX [IX_Ocorrencia_Id] ON [Ocorrencia] ([Id]);
GO

CREATE INDEX [IX_Ocorrencia_Id_Trajeto] ON [Ocorrencia] ([Id_Trajeto]);
GO

CREATE INDEX [IX_Rota_ColaboradorId] ON [Rota] ([ColaboradorId]);
GO

CREATE INDEX [IX_Rota_IdPeriodo] ON [Rota] ([IdPeriodo]);
GO

CREATE INDEX [IX_Rota_SetorId] ON [Rota] ([SetorId]);
GO

CREATE INDEX [IX_Rua_Cep] ON [Rua] ([Cep]);
GO

CREATE INDEX [IX_Rua_RotaId] ON [Rua] ([RotaId]);
GO

CREATE INDEX [IX_Setor_ColaboradorId] ON [Setor] ([ColaboradorId]);
GO

CREATE INDEX [IX_Setor_EmpresaId] ON [Setor] ([EmpresaId]);
GO

CREATE INDEX [IX_SetorVeiculo_FrotaId_Veiculo] ON [SetorVeiculo] ([FrotaId_Veiculo]);
GO

CREATE INDEX [IX_Trajeto_IdMotorista] ON [Trajeto] ([IdMotorista]);
GO

CREATE INDEX [IX_Trajeto_IdRota] ON [Trajeto] ([IdRota]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231006193129_InitialMigration', N'7.0.10');
GO

COMMIT;
GO

