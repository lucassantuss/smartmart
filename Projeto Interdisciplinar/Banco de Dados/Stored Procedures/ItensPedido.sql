-- Procedures utilizadas no ItensPedidoDAO

-- Procedure para incluir novos itens no pedido
create procedure spInsert_ItensPedido (@Id int, @IDPedido int,
 @IDProduto int, @Quantidade int, @ValorUnitario decimal(10,2))
as
begin
	insert into ItensPedido
	(Id, IDPedido, IDProduto, Quantidade, ValorUnitario)
	values
	(@Id, @IDPedido, @IDProduto, @Quantidade, @ValorUnitario)
end

-- Procedure para alterar um item no pedido existente
GO
create procedure spUpdate_ItensPedido (@Id int, @IDPedido int,
 @IDProduto int, @Quantidade int, @ValorUnitario decimal(10,2))
as
begin
	update ItensPedido set
	IDPedido = @IDPedido,
	IDProduto = @IDProduto,
	Quantidade = @Quantidade,
	ValorUnitario = @ValorUnitario
	where Id = @Id
end