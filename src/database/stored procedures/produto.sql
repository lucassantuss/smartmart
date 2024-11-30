-- Procedures utilizadas no ProdutoDAO

-- Procedure para incluir novos produtos
create procedure spInsert_Produtos (@Id int, @IDFornecedor int, @NomeProduto varchar(100),
 @FotoProduto varbinary(max), @DescricaoProduto varchar(200), @PrecoProduto decimal(10,2),
 @EstoqueProduto int)
as
begin
	insert into Produtos
	(NomeProduto, FotoProduto, DescricaoProduto, PrecoProduto, EstoqueProduto, IDFornecedor)
	values
	(@NomeProduto, @FotoProduto, @DescricaoProduto, @PrecoProduto, @EstoqueProduto, @IDFornecedor)
end

-- Procedure para alterar um produto existente
GO
create procedure spUpdate_Produtos (@Id int, @IDFornecedor int, @NomeProduto varchar(100),
 @FotoProduto varbinary(max), @DescricaoProduto varchar(200), @PrecoProduto decimal(10,2),
 @EstoqueProduto int)
as
begin
	update Produtos set
	NomeProduto = @NomeProduto,
	FotoProduto = @FotoProduto,
	DescricaoProduto = @DescricaoProduto,
	PrecoProduto = @PrecoProduto,
	EstoqueProduto = @EstoqueProduto,
	IDFornecedor = @IDFornecedor
	where Id = @Id
end