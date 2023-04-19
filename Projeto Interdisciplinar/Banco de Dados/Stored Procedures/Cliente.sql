-- Procedures utilizadas no ClienteDAO

-- Procedure para incluir novos clientes
create procedure spIncluiCliente (@IDCliente int, @NomeCliente varchar(100),
 @EnderecoCliente varchar(200), @EmailCliente varchar(100), @TelefoneCliente varchar(20))
as
begin
	insert into Clientes
	(IDCliente, NomeCliente, EnderecoCliente, EmailCliente, TelefoneCliente)
	values
	(@IDCliente, @NomeCliente, @EnderecoCliente, @EmailCliente, @TelefoneCliente)
end

-- Procedure para alterar um cliente existente
GO
create procedure spAlteraCliente (@IDCliente int, @NomeCliente varchar(100),
 @EnderecoCliente varchar(200), @EmailCliente varchar(100), @TelefoneCliente varchar(20))
as
begin
	update Clientes set
	NomeCliente = @NomeCliente,
	EnderecoCliente = @EnderecoCliente,
	EmailCliente = @EmailCliente,
	TelefoneCliente = @TelefoneCliente
	where IDCliente = @IDCliente
end

-- Procedure para excluir um cliente
GO
create procedure spExcluiCliente (@IDCliente int)
as
begin
	delete Clientes where IDCliente = @IDCliente
end

-- Procedure para consultar um cliente
GO
create procedure spConsultaCliente (@IDCliente int)
as
begin
	select * from Clientes where IDCliente = @IDCliente
end

-- Procedure para listar todos os clientes existentes no sistema
GO
create procedure spListagemClientes
as
begin
	select * from Clientes
end