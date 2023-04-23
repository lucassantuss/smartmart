-- Procedures utilizadas no PedidoDAO

-- Procedure para incluir novos pedidos
create procedure spInsert_Pedidos (@Id int, @IDCliente int,
 @DataPedido date, @ValorTotal decimal(10,2))
as
begin
	insert into Pedidos
	(IDCliente, DataPedido, ValorTotal)
	values
	(@IDCliente, @DataPedido, @ValorTotal)
end

-- Procedure para alterar um pedido existente
GO
create procedure spUpdate_Pedidos (@Id int, @IDCliente int,
 @DataPedido date, @ValorTotal decimal(10,2))
as
begin
	update Pedidos set
	IDCliente = @IDCliente,
	DataPedido = @DataPedido,
	ValorTotal = @ValorTotal
	where Id = @Id
end