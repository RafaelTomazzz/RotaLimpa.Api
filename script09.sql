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
    [Id] int NOT NULL IDENTITY,
    [Cep] nvarchar(8) NOT NULL,
    [Logradouro] nvarchar(25) NOT NULL,
    [Endereço] nvarchar(60) NOT NULL,
    [Bairro] nvarchar(35) NOT NULL,
    [Cidade] nvarchar(35) NOT NULL,
    [UF] CHAR(2) NOT NULL,
    [latitude] nvarchar(25) NOT NULL,
    [longitude] nvarchar(25) NOT NULL,
    CONSTRAINT [PK_CEP] PRIMARY KEY ([Id])
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
SET @description = N'Tamanho do ve�culo';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Frota', 'COLUMN', N'Tmn_Veiculo';
GO

CREATE TABLE [Motorista] (
    [Id] int NOT NULL IDENTITY,
    [Primeiro_Nome] nvarchar(20) NOT NULL,
    [Sobre_Nome] nvarchar(20) NOT NULL,
    [Di_Motorista] datetime2 NOT NULL,
    [St_Motorista] nvarchar(1) NOT NULL,
    [CPF] nvarchar(15) NOT NULL,
    [RG] nvarchar(15) NOT NULL,
    [Login] nvarchar(20) NOT NULL,
    [Senha] nvarchar(12) NOT NULL,
    CONSTRAINT [PK_Motorista] PRIMARY KEY ([Id])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Data de cria��o do Motorista';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Motorista', 'COLUMN', N'Di_Motorista';
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
    [IdEmpresa] int NOT NULL,
    [EmpresaId] int NULL,
    [Primeiro_Nome] nvarchar(20) NOT NULL,
    [Sobre_Nome] nvarchar(20) NOT NULL,
    [Di_Colaborador] datetime2 NOT NULL,
    [St_Colaborador] nvarchar(1) NOT NULL,
    [CPF] nvarchar(15) NOT NULL,
    [RG] nvarchar(15) NOT NULL,
    [Login] nvarchar(7) NOT NULL,
    [Senha] nvarchar(12) NOT NULL,
    CONSTRAINT [PK_Colaborador] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Colaborador_Empresa_EmpresaId] FOREIGN KEY ([EmpresaId]) REFERENCES [Empresa] ([Id]) ON DELETE CASCADE
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Data de inserção do Colaborador';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Colaborador', 'COLUMN', N'Di_Colaborador';
GO

CREATE TABLE [Kilometragem] (
    [Id] int NOT NULL,
    [Km] int NOT NULL,
    [Di_Kilometragem] datetime2 NOT NULL,
    CONSTRAINT [PK_Kilometragem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Kilometragem_Frota_Id] FOREIGN KEY ([Id]) REFERENCES [Frota] ([Id]) ON DELETE CASCADE
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Kilometragem do veículo';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Kilometragem', 'COLUMN', N'Km';
SET @description = N'Data de início marcação';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Kilometragem', 'COLUMN', N'Di_Kilometragem';
GO

CREATE TABLE [HistoLonginMotorista] (
    [Historico_Login] nvarchar(450) NOT NULL,
    [IdMotorista] int NOT NULL,
    [DataHora] datetime2 NOT NULL,
    CONSTRAINT [PK_HistoLonginMotorista] PRIMARY KEY ([Historico_Login]),
    CONSTRAINT [FK_HistoLonginMotorista_Motorista_IdMotorista] FOREIGN KEY ([IdMotorista]) REFERENCES [Motorista] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [HistoLonginColaborador] (
    [Historico_Login] nvarchar(450) NOT NULL,
    [IdColaborador] int NOT NULL,
    [DataHora] datetime2 NOT NULL,
    CONSTRAINT [PK_HistoLonginColaborador] PRIMARY KEY ([Historico_Login]),
    CONSTRAINT [FK_HistoLonginColaborador_Colaborador_IdColaborador] FOREIGN KEY ([IdColaborador]) REFERENCES [Colaborador] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Setor] (
    [Id] int NOT NULL IDENTITY,
    [IdColaborador] int NOT NULL,
    [IdEmpresa] int NOT NULL,
    [TipoServico] int NOT NULL,
    [Di_Setor] datetime2 NOT NULL,
    [Da_Setor] datetime2 NULL,
    [St_Setor] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Setor] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Setor_Colaborador_IdColaborador] FOREIGN KEY ([IdColaborador]) REFERENCES [Colaborador] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Setor_Empresa_IdEmpresa] FOREIGN KEY ([IdEmpresa]) REFERENCES [Empresa] ([Id])
);
GO

CREATE TABLE [Rota] (
    [Id] int NOT NULL IDENTITY,
    [IdColaborador] int NOT NULL,
    [IdSetor] int NOT NULL,
    [Dt_Rota] int NOT NULL,
    [Tm_Rota] int NOT NULL,
    CONSTRAINT [PK_Rota] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Rota_Colaborador_IdColaborador] FOREIGN KEY ([IdColaborador]) REFERENCES [Colaborador] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Rota_Setor_IdSetor] FOREIGN KEY ([IdSetor]) REFERENCES [Setor] ([Id])
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
    [IdSetor] int NOT NULL,
    [IdFrota] int NOT NULL,
    CONSTRAINT [PK_SetorVeiculo] PRIMARY KEY ([IdSetor], [IdFrota]),
    CONSTRAINT [FK_SetorVeiculo_Frota_IdFrota] FOREIGN KEY ([IdFrota]) REFERENCES [Frota] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_SetorVeiculo_Setor_IdSetor] FOREIGN KEY ([IdSetor]) REFERENCES [Setor] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Rua] (
    [Id] int NOT NULL IDENTITY,
    [IdCep] int NOT NULL,
    [IdRota] int NOT NULL,
    CONSTRAINT [PK_Rua] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Rua_CEP_IdCep] FOREIGN KEY ([IdCep]) REFERENCES [CEP] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Rua_Rota_IdRota] FOREIGN KEY ([IdRota]) REFERENCES [Rota] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Trajeto] (
    [Id] int NOT NULL IDENTITY,
    [IdMotorista] int NOT NULL,
    [IdRota] int NOT NULL,
    [IdPeriodo] int NOT NULL,
    [IdFrota] int NOT NULL,
    [Mi_Trajeto] datetime2 NOT NULL,
    [Mj_Trajeto] datetime2 NOT NULL,
    CONSTRAINT [PK_Trajeto] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Trajeto_Frota_IdFrota] FOREIGN KEY ([IdFrota]) REFERENCES [Frota] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Trajeto_Motorista_IdMotorista] FOREIGN KEY ([IdMotorista]) REFERENCES [Motorista] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Trajeto_Periodo_IdPeriodo] FOREIGN KEY ([IdPeriodo]) REFERENCES [Periodo] ([Id]) ON DELETE CASCADE,
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

CREATE TABLE [RelatorioFinal] (
    [Id_Relatorio] int NOT NULL IDENTITY,
    [IdSetor] int NOT NULL,
    [IdOcorrencia] int NOT NULL,
    CONSTRAINT [PK_RelatorioFinal] PRIMARY KEY ([Id_Relatorio]),
    CONSTRAINT [FK_RelatorioFinal_Ocorrencia_IdOcorrencia] FOREIGN KEY ([IdOcorrencia]) REFERENCES [Ocorrencia] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RelatorioFinal_Setor_IdSetor] FOREIGN KEY ([IdSetor]) REFERENCES [Setor] ([Id])
);
GO

CREATE INDEX [IX_Colaborador_EmpresaId] ON [Colaborador] ([EmpresaId]);
GO

CREATE UNIQUE INDEX [IX_Colaborador_Id] ON [Colaborador] ([Id]);
GO

CREATE UNIQUE INDEX [IX_Empresa_Dc_Empresa] ON [Empresa] ([Dc_Empresa]);
GO

CREATE INDEX [IX_HistoLonginColaborador_IdColaborador] ON [HistoLonginColaborador] ([IdColaborador]);
GO

CREATE INDEX [IX_HistoLonginMotorista_IdMotorista] ON [HistoLonginMotorista] ([IdMotorista]);
GO

CREATE UNIQUE INDEX [IX_Ocorrencia_Id] ON [Ocorrencia] ([Id]);
GO

CREATE INDEX [IX_Ocorrencia_Id_Trajeto] ON [Ocorrencia] ([Id_Trajeto]);
GO

CREATE INDEX [IX_RelatorioFinal_IdOcorrencia] ON [RelatorioFinal] ([IdOcorrencia]);
GO

CREATE INDEX [IX_RelatorioFinal_IdSetor] ON [RelatorioFinal] ([IdSetor]);
GO

CREATE INDEX [IX_Rota_IdColaborador] ON [Rota] ([IdColaborador]);
GO

CREATE INDEX [IX_Rota_IdSetor] ON [Rota] ([IdSetor]);
GO

CREATE INDEX [IX_Rua_IdCep] ON [Rua] ([IdCep]);
GO

CREATE INDEX [IX_Rua_IdRota] ON [Rua] ([IdRota]);
GO

CREATE INDEX [IX_Setor_IdColaborador] ON [Setor] ([IdColaborador]);
GO

CREATE INDEX [IX_Setor_IdEmpresa] ON [Setor] ([IdEmpresa]);
GO

CREATE INDEX [IX_SetorVeiculo_IdFrota] ON [SetorVeiculo] ([IdFrota]);
GO

CREATE INDEX [IX_Trajeto_IdFrota] ON [Trajeto] ([IdFrota]);
GO

CREATE INDEX [IX_Trajeto_IdMotorista] ON [Trajeto] ([IdMotorista]);
GO

CREATE INDEX [IX_Trajeto_IdPeriodo] ON [Trajeto] ([IdPeriodo]);
GO

CREATE INDEX [IX_Trajeto_IdRota] ON [Trajeto] ([IdRota]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231115145152_InitalMigration', N'7.0.10');
GO

COMMIT;
GO

