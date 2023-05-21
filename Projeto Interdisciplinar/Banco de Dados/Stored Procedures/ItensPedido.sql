-- Procedures utilizadas no ItensPedidoDAO

-- Procedure para incluir novos itens no pedido
create procedure spInsert_ItensPedido (@Id int, @IDPedido int,
 @IDProduto int, @Quantidade int)
as
begin
	insert into ItensPedido
	(IDPedido, IDProduto, Quantidade)
	values
	(@IDPedido, @IDProduto, @Quantidade)
end

-- Procedure para alterar um item no pedido existente
GO
create procedure spUpdate_ItensPedido (@Id int, @IDPedido int,
 @IDProduto int, @Quantidade int)
as
begin
	update ItensPedido set
	IDPedido = @IDPedido,
	IDProduto = @IDProduto,
	Quantidade = @Quantidade
	where Id = @Id
end