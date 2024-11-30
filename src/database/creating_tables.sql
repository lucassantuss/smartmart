-- Projeto Interdisciplinar

-- Integrantes do Grupo:
-- Nome: Danilo Rodrigues Dantas -> RA: 081210027
-- Nome: Lucas Ara�jo dos Santos -> RA: 081210009 
-- Nome: Maik Soares Luiz        -> RA: 081210040
-- Nome: Renan C�sar de Araujo   -> RA: 081210033

create database Projeto_Interdisciplinar
use Projeto_Interdisciplinar

-- Cria��o da tabela Fornecedores
CREATE TABLE Fornecedores (
  Id INT PRIMARY KEY NOT NULL IDENTITY,
  NomeFornecedor VARCHAR(100) NOT NULL,
  EnderecoFornecedor VARCHAR(200),
  EmailFornecedor VARCHAR(100),
  TelefoneFornecedor VARCHAR(20)
);

-- Cria��o da tabela Clientes
CREATE TABLE Clientes (
  Id INT PRIMARY KEY NOT NULL IDENTITY,
  NomeCliente VARCHAR(100) NOT NULL,
  EnderecoCliente VARCHAR(200),
  EmailCliente VARCHAR(100),
  TelefoneCliente VARCHAR(20)
);

-- Cria��o da tabela Produtos
CREATE TABLE Produtos (
  Id INT PRIMARY KEY NOT NULL IDENTITY,
  IDFornecedor INT NOT NULL,
  NomeProduto VARCHAR(100) NOT NULL,
  FotoProduto VARBINARY(MAX),
  DescricaoProduto VARCHAR(200),
  PrecoProduto DECIMAL(10, 2) NOT NULL,
  EstoqueProduto INT,
  FOREIGN KEY (IDFornecedor) REFERENCES Fornecedores(Id)
);

-- Cria��o da tabela Pedidos
CREATE TABLE Pedidos (
  Id INT PRIMARY KEY NOT NULL IDENTITY,
  IDCliente INT NULL,  
  IDCarrinho INT NULL,
  DataPedido DATE,
  ValorTotal DECIMAL(10, 2),
  FOREIGN KEY (IDCliente) REFERENCES Clientes(Id)
);

-- Cria��o da tabela Itens do Pedido
CREATE TABLE ItensPedido (
  Id INT PRIMARY KEY NOT NULL IDENTITY,
  IDPedido INT NOT NULL,
  IDProduto INT NOT NULL,
  Quantidade INT,
  FOREIGN KEY (IDPedido) REFERENCES Pedidos(Id),
  FOREIGN KEY (IDProduto) REFERENCES Produtos(Id)
);

-- Cria��o da tabela Usu�rios
CREATE TABLE Usuarios (
  Id INT PRIMARY KEY NOT NULL IDENTITY,
  FotoUsuario VARBINARY(MAX),
  LoginUsuario VARCHAR(50) NOT NULL,
  SenhaUsuario VARCHAR(50) NOT NULL,
  Perfil VARCHAR(50) NOT NULL,
  IDCliente INT NOT NULL, -- Se o usu�rio estiver associado a um cliente espec�fico
  FOREIGN KEY (IDCliente) REFERENCES Clientes(Id)
);