-- Procedures utilizadas no ProdutoDAO

-- Procedure para incluir novos produtos
create procedure spIncluiProduto (@IDProduto int, @NomeProduto varchar(100),
 @FotoProduto varbinary(max), @DescricaoProduto varchar(200), @PrecoProduto decimal(10,2),
 @EstoqueProduto int)
as
begin
	insert into Produtos
	(IDProduto, NomeProduto, FotoProduto, DescricaoProduto, PrecoProduto, EstoqueProduto)
	values
	(@IDProduto, @NomeProduto, @FotoProduto, @DescricaoProduto, @PrecoProduto, @EstoqueProduto)
end

-- Procedure para alterar um produto existente
GO
create procedure spAlteraProduto (@IDProduto int, @NomeProduto varchar(100),
 @FotoProduto varbinary(max), @DescricaoProduto varchar(200), @PrecoProduto decimal(10,2),
 @EstoqueProduto int)
as
begin
	update Produtos set
	NomeProduto = @NomeProduto,
	FotoProduto = @FotoProduto,
	DescricaoProduto = @DescricaoProduto,
	PrecoProduto = @PrecoProduto,
	EstoqueProduto = @EstoqueProduto
	where IDProduto = @IDProduto
end

-- Procedure para excluir um produto
GO
create procedure spExcluiProduto (@IDProduto int)
as
begin
	delete Produtos where IDProduto = @IDProduto
end

-- Procedure para consultar um produto
GO
create procedure spConsultaProduto (@IDProduto int)
as
begin
	select * from Produtos where IDProduto = @IDProduto
end

-- Procedure para listar todos os produtos existentes no sistema
GO
create procedure spListagemProdutos
as
begin
	select * from Produtos
end