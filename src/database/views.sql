-- Views

-- View para relacionar os produtos ao fornecedor
GO
create view vw_ProdutosPorFornecedor
as
select p.Id as 'CodigoProduto',
f.Id as 'CodigoFornecedor',
f.NomeFornecedor,
p.NomeProduto,
p.DescricaoProduto,
p.PrecoProduto,
p.FotoProduto,
p.EstoqueProduto
from Produtos p
inner join Fornecedores f
on p.IDFornecedor = f.Id
GO

-- View para relacionar os pedidos de um cliente
GO
create view vw_PedidosPorCliente
as
select p.Id as 'CodigoPedido',
p.DataPedido,
p.ValorTotal,
c.Id as 'CodigoCliente',
c.NomeCliente
from Pedidos p
inner join Clientes c
on p.IDCliente = c.Id
GO