
CREATE DATABASE LojaVirtual;
GO

USE LojaVirtual;
GO

CREATE TABLE Clientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    CPF VARCHAR(14) NOT NULL UNIQUE,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Telefone VARCHAR(20) NOT NULL,
    Endereco VARCHAR(150) NOT NULL,
    Cidade VARCHAR(60) NOT NULL,
    DataCadastro DATETIME NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    CPF VARCHAR(14) NOT NULL UNIQUE,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Senha VARCHAR(255) NOT NULL,
    Perfil VARCHAR(30) NOT NULL,
    Telefone VARCHAR(20),
    DataCadastro DATETIME NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE Categorias (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    NomeCategoria VARCHAR(50) NOT NULL,
    Descricao VARCHAR(200),
    Departamento VARCHAR(50),
    Localizacao VARCHAR(50),
    DataCadastro DATETIME NOT NULL DEFAULT GETDATE(),
    Responsavel VARCHAR(100),
    Ordem INT NOT NULL DEFAULT 0
);
GO

CREATE TABLE Produtos (
    IdProduto INT IDENTITY(1,1) PRIMARY KEY,
    NomeProduto VARCHAR(100) NOT NULL,
    Descricao VARCHAR(300),
    Preco DECIMAL(10,2) NOT NULL,
    Estoque INT NOT NULL DEFAULT 0,
    Marca VARCHAR(50),
    IdCategoria INT NOT NULL,
    Peso DECIMAL(8,2),

    CONSTRAINT FK_Produtos_Categorias
        FOREIGN KEY (IdCategoria)
        REFERENCES Categorias(IdCategoria),

    CONSTRAINT CK_Produtos_Preco
        CHECK (Preco >= 0),

    CONSTRAINT CK_Produtos_Estoque
        CHECK (Estoque >= 0)
);
GO

CREATE TABLE Pedidos (
    IdPedido INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    IdUsuario INT NOT NULL,
    DataPedido DATETIME NOT NULL DEFAULT GETDATE(),
    ValorTotal DECIMAL(10,2) NOT NULL DEFAULT 0,
    FormaPagamento VARCHAR(30) NOT NULL,
    EnderecoEntrega VARCHAR(150) NOT NULL,
    CidadeEntrega VARCHAR(60) NOT NULL,

    CONSTRAINT FK_Pedidos_Clientes
        FOREIGN KEY (IdCliente)
        REFERENCES Clientes(IdCliente),

    CONSTRAINT FK_Pedidos_Usuarios
        FOREIGN KEY (IdUsuario)
        REFERENCES Usuarios(IdUsuario),

    CONSTRAINT CK_Pedidos_ValorTotal
        CHECK (ValorTotal >= 0)
);
GO
