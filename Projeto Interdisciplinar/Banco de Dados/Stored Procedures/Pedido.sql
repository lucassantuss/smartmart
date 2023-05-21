-- Procedures utilizadas no PedidoDAO

-- Procedure para incluir novos pedidos
create procedure spInsert_Pedidos (@Id int, @IDCliente int, @IDCarrinho int,
 @DataPedido date, @ValorTotal decimal(10,2))
as
begin
	insert into Pedidos
	(IDCliente, IDCarrinho, DataPedido, ValorTotal)
	values
	(@IDCliente, @IDCarrinho, @DataPedido, @ValorTotal)
end

-- Procedure para alterar um pedido existente
GO
create procedure spUpdate_Pedidos (@Id int, @IDCliente int, @IDCarrinho int,
 @DataPedido date, @ValorTotal decimal(10,2))
as
begin
	update Pedidos set
	IDCliente = @IDCliente,
	IDCarrinho = @IDCarrinho,
	DataPedido = @DataPedido,
	ValorTotal = @ValorTotal
	where Id = @Id
end

-- Procedure para pesquisar um produto pelo Id do Carrinho
create procedure [dbo].[spConsultaPedido] (@id int, @tabela varchar(max))
as
begin
 declare @sql varchar(max);
 set @sql = 'select * from ' + @tabela + ' where IDCarrinho = ' + cast(@id as varchar(max))
 exec(@sql)
end

-- Procedure para pesquisar a quantidade de produtos pelo Id do Carrinho
create procedure [dbo].[spQuantidadeProdutosNoPedido] (@id int)
as
begin
 declare @sql varchar(max);
 set @sql = 'select COUNT(*) from ItensPedido ip 
 inner join Pedidos p ON p.Id = ip.IDPedido
 where p.IDCarrinho = ' + cast(@id as varchar(max))
 exec(@sql)
end

-- Procedure para pesquisar os produtos pelo Id do Carrinho
create procedure [dbo].[spProdutosNoPedido] (@id int)
as
begin
 declare @sql varchar(max);
 set @sql = 'select * from ItensPedido ip 
 inner join Pedidos p ON p.Id = ip.IDPedido
 where p.IDCarrinho = ' + cast(@id as varchar(max))
 exec(@sql)
end