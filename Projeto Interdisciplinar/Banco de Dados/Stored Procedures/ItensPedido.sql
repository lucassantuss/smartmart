-- Procedures utilizadas no ItensPedidoDAO

-- Procedure para incluir novos itens no pedido
create procedure spIncluiItensPedido (@IDItemPedido int, @IDPedido int,
 @IDProduto int, @Quantidade int, @ValorUnitario decimal(10,2))
as
begin
	insert into ItensPedido
	(IDItemPedido, IDPedido, IDProduto, Quantidade, ValorUnitario)
	values
	(@IDItemPedido, @IDPedido, @IDProduto, @Quantidade, @ValorUnitario)
end

-- Procedure para alterar um item no pedido existente
GO
create procedure spAlteraItensPedido (@IDItemPedido int, @IDPedido int,
 @IDProduto int, @Quantidade int, @ValorUnitario decimal(10,2))
as
begin
	update ItensPedido set
	IDPedido = @IDPedido,
	IDProduto = @IDProduto,
	Quantidade = @Quantidade,
	ValorUnitario = @ValorUnitario
	where IDItemPedido = @IDItemPedido
end

-- Procedure para excluir um item no pedido
GO
create procedure spExcluiItensPedido (@IDItemPedido int)
as
begin
	delete ItensPedido where IDItemPedido = @IDItemPedido
end

-- Procedure para consultar um item no pedido
GO
create procedure spConsultaItensPedido (@IDItemPedido int)
as
begin
	select * from ItensPedido where IDItemPedido = @IDItemPedido
end

-- Procedure para listar todos os itens do pedido existentes no sistema
GO
create procedure spListagemItensPedidos
as
begin
	select * from ItensPedido
end