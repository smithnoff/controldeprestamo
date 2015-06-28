
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/25/2015 01:59:47
-- Generated from EDMX file: C:\Users\JoanYanitA\Source\Repos\controldeprestamo\SistemaControlDeCobranzas\CapaModelo\ModeloDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dbControlCobranzas];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_usuarios_personas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[usuarios] DROP CONSTRAINT [FK_usuarios_personas];
GO
IF OBJECT_ID(N'[dbo].[FK_usuarios_rolUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[usuarios] DROP CONSTRAINT [FK_usuarios_rolUsuario];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[personas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[personas];
GO
IF OBJECT_ID(N'[dbo].[rolUsuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[rolUsuario];
GO
IF OBJECT_ID(N'[dbo].[usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[usuarios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'personas'
CREATE TABLE [dbo].[personas] (
    [pkPersonaID] int  NOT NULL,
    [asNombre] nvarchar(50)  NULL,
    [asApellido] nvarchar(50)  NULL
);
GO

-- Creating table 'rolUsuarios'
CREATE TABLE [dbo].[rolUsuarios] (
    [pkRolUsuarioID] int IDENTITY(1,1) NOT NULL,
    [asDescripcion] nvarchar(50)  NULL
);
GO

-- Creating table 'usuarios'
CREATE TABLE [dbo].[usuarios] (
    [pkUsuariosID] int IDENTITY(1,1) NOT NULL,
    [asUsername] nvarchar(50)  NULL,
    [asPassword] nvarchar(50)  NULL,
    [fkPersonaID] int  NULL,
    [fkRolUsuarioID] int  NULL
);
GO

-- Creating table 'Bancos'
CREATE TABLE [dbo].[Bancos] (
    [pkBancosID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [pkClientesID] int IDENTITY(1,1) NOT NULL,
    [Contrato_pkContratosID] int  NOT NULL,
    [Banco_pkBancosID] int  NOT NULL,
    [usuario_pkUsuariosID] int  NOT NULL
);
GO

-- Creating table 'Contratos'
CREATE TABLE [dbo].[Contratos] (
    [pkContratosID] int IDENTITY(1,1) NOT NULL,
    [DetallesContrato_pkDetallesContratosID] int  NOT NULL
);
GO

-- Creating table 'DetallesContratos'
CREATE TABLE [dbo].[DetallesContratos] (
    [pkDetallesContratosID] int IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [pkPersonaID] in table 'personas'
ALTER TABLE [dbo].[personas]
ADD CONSTRAINT [PK_personas]
    PRIMARY KEY CLUSTERED ([pkPersonaID] ASC);
GO

-- Creating primary key on [pkRolUsuarioID] in table 'rolUsuarios'
ALTER TABLE [dbo].[rolUsuarios]
ADD CONSTRAINT [PK_rolUsuarios]
    PRIMARY KEY CLUSTERED ([pkRolUsuarioID] ASC);
GO

-- Creating primary key on [pkUsuariosID] in table 'usuarios'
ALTER TABLE [dbo].[usuarios]
ADD CONSTRAINT [PK_usuarios]
    PRIMARY KEY CLUSTERED ([pkUsuariosID] ASC);
GO

-- Creating primary key on [pkBancosID] in table 'Bancos'
ALTER TABLE [dbo].[Bancos]
ADD CONSTRAINT [PK_Bancos]
    PRIMARY KEY CLUSTERED ([pkBancosID] ASC);
GO

-- Creating primary key on [pkClientesID] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([pkClientesID] ASC);
GO

-- Creating primary key on [pkContratosID] in table 'Contratos'
ALTER TABLE [dbo].[Contratos]
ADD CONSTRAINT [PK_Contratos]
    PRIMARY KEY CLUSTERED ([pkContratosID] ASC);
GO

-- Creating primary key on [pkDetallesContratosID] in table 'DetallesContratos'
ALTER TABLE [dbo].[DetallesContratos]
ADD CONSTRAINT [PK_DetallesContratos]
    PRIMARY KEY CLUSTERED ([pkDetallesContratosID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [fkPersonaID] in table 'usuarios'
ALTER TABLE [dbo].[usuarios]
ADD CONSTRAINT [FK_usuarios_personas]
    FOREIGN KEY ([fkPersonaID])
    REFERENCES [dbo].[personas]
        ([pkPersonaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_usuarios_personas'
CREATE INDEX [IX_FK_usuarios_personas]
ON [dbo].[usuarios]
    ([fkPersonaID]);
GO

-- Creating foreign key on [fkRolUsuarioID] in table 'usuarios'
ALTER TABLE [dbo].[usuarios]
ADD CONSTRAINT [FK_usuarios_rolUsuario]
    FOREIGN KEY ([fkRolUsuarioID])
    REFERENCES [dbo].[rolUsuarios]
        ([pkRolUsuarioID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_usuarios_rolUsuario'
CREATE INDEX [IX_FK_usuarios_rolUsuario]
ON [dbo].[usuarios]
    ([fkRolUsuarioID]);
GO

-- Creating foreign key on [Contrato_pkContratosID] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [FK_ContratosClientes]
    FOREIGN KEY ([Contrato_pkContratosID])
    REFERENCES [dbo].[Contratos]
        ([pkContratosID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContratosClientes'
CREATE INDEX [IX_FK_ContratosClientes]
ON [dbo].[Clientes]
    ([Contrato_pkContratosID]);
GO

-- Creating foreign key on [Banco_pkBancosID] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [FK_BancosClientes]
    FOREIGN KEY ([Banco_pkBancosID])
    REFERENCES [dbo].[Bancos]
        ([pkBancosID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BancosClientes'
CREATE INDEX [IX_FK_BancosClientes]
ON [dbo].[Clientes]
    ([Banco_pkBancosID]);
GO

-- Creating foreign key on [usuario_pkUsuariosID] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [FK_usuarioClientes]
    FOREIGN KEY ([usuario_pkUsuariosID])
    REFERENCES [dbo].[usuarios]
        ([pkUsuariosID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_usuarioClientes'
CREATE INDEX [IX_FK_usuarioClientes]
ON [dbo].[Clientes]
    ([usuario_pkUsuariosID]);
GO

-- Creating foreign key on [DetallesContrato_pkDetallesContratosID] in table 'Contratos'
ALTER TABLE [dbo].[Contratos]
ADD CONSTRAINT [FK_DetallesContratosContratos]
    FOREIGN KEY ([DetallesContrato_pkDetallesContratosID])
    REFERENCES [dbo].[DetallesContratos]
        ([pkDetallesContratosID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallesContratosContratos'
CREATE INDEX [IX_FK_DetallesContratosContratos]
ON [dbo].[Contratos]
    ([DetallesContrato_pkDetallesContratosID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------