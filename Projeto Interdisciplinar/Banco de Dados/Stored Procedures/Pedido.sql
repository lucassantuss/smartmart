-- Procedures utilizadas no PedidoDAO

-- Procedure para incluir novos pedidos
create procedure spIncluiPedido (@IDPedido int, @IDCliente int,
 @DataPedido date, @ValorTotal decimal(10,2))
as
begin
	insert into Pedidos
	(IDPedido, IDCliente, DataPedido, ValorTotal)
	values
	(@IDPedido, @IDCliente, @DataPedido, @ValorTotal)
end

-- Procedure para alterar um pedido existente
GO
create procedure spAlteraPedido (@IDPedido int, @IDCliente int,
 @DataPedido date, @ValorTotal decimal(10,2))
as
begin
	update Pedidos set
	IDCliente = @IDCliente,
	DataPedido = @DataPedido,
	ValorTotal = @ValorTotal
	where IDPedido = @IDPedido
end

-- Procedure para excluir um pedido
GO
create procedure spExcluiPedido (@IDPedido int)
as
begin
	delete Pedidos where IDPedido = @IDPedido
end

-- Procedure para consultar um pedido
GO
create procedure spConsultaPedido (@IDPedido int)
as
begin
	select * from Pedidos where IDPedido = @IDPedido
end

-- Procedure para listar todos os pedidos existentes no sistema
GO
create procedure spListagemPedidos
as
begin
	select * from Pedidos
end