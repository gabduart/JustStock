CREATE DATABASE juststock;
USE juststock;

CREATE TABLE usuarios (
	id_usuario		INT PRIMARY KEY IDENTITY,
	nome			VARCHAR(100),
	email			VARCHAR(100),
	senha			VARCHAR(255),
	tipo_usuario	INT
);

CREATE TABLE fornecedores (
	id_fornecedor	INT PRIMARY KEY IDENTITY,
	nome			VARCHAR(100),
	cnpj_cpf		VARCHAR(20),
	contato			VARCHAR(50),
	endereco		TEXT
);

CREATE TABLE produtos (
	id_produto		INT PRIMARY KEY IDENTITY,
	nome			VARCHAR(100),
	codigo_barras	VARCHAR(50),
	categoria		VARCHAR(50),
	descricao		TEXT,
	preco_compra	DECIMAL(10,2),
	preco_venda		DECIMAL(10,2),
	unidade_medida	VARCHAR(20),
	quantidade		INT,
	fk_fornecedor	INT CONSTRAINT fk_fornecedorProduto REFERENCES fornecedores(id_fornecedor)
);

CREATE TABLE movimentacoes (
	id_movimentacao		INT PRIMARY KEY IDENTITY,
	id_produto			INT CONSTRAINT fk_produtoMovimentacao REFERENCES produtos(id_produto),
	tipo				INT, -- 1: entrada, 2: saída, 3: perda
	quantidade			INT,
	data_hora			DATETIME,
	id_usuario			INT CONSTRAINT fk_usuarioMovimentacao REFERENCES usuarios(id_usuario)
);

CREATE TABLE alerta (
	id_alerta		INT PRIMARY KEY IDENTITY,
	id_produto		INT CONSTRAINT fk_produtoAlerta REFERENCES produtos(id_produto),
	tipo_alerta		INT, -- 1: estoque baixo, 2: reabastecimento
	data_criacao	DATETIME
);

ALTER TABLE usuarios
ADD CONSTRAINT DF_tipo_usuario DEFAULT 1 FOR tipo_usuario;

Select * From usuarios;