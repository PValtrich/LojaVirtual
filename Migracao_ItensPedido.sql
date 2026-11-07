-- Use este arquivo somente em um banco LojaVirtual que já foi criado com o script anterior.
-- Ele cria apenas a tabela ItensPedido e não apaga nenhum dado existente.

USE LojaVirtual;
GO

CREATE TABLE ItensPedido (
    IdItemPedido INT IDENTITY(1,1) PRIMARY KEY,
    IdPedido INT NOT NULL,
    IdProduto INT NOT NULL,
    Quantidade INT NOT NULL,
    PrecoUnitario DECIMAL(10,2) NOT NULL,

    CONSTRAINT FK_ItensPedido_Pedidos
        FOREIGN KEY (IdPedido)
        REFERENCES Pedidos(IdPedido)
        ON DELETE CASCADE,

    CONSTRAINT FK_ItensPedido_Produtos
        FOREIGN KEY (IdProduto)
        REFERENCES Produtos(IdProduto),

    CONSTRAINT CK_ItensPedido_Quantidade
        CHECK (Quantidade > 0),

    CONSTRAINT CK_ItensPedido_PrecoUnitario
        CHECK (PrecoUnitario >= 0)
);
GO
