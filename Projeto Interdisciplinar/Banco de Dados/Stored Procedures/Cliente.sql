-- Procedures utilizadas no ClienteDAO

-- Procedure para incluir novos clientes
create procedure spInsert_Clientes (@Id int, @NomeCliente varchar(100),
 @EnderecoCliente varchar(200), @EmailCliente varchar(100), @TelefoneCliente varchar(20))
as
begin
	insert into Clientes
	(NomeCliente, EnderecoCliente, EmailCliente, TelefoneCliente)
	values
	(@NomeCliente, @EnderecoCliente, @EmailCliente, @TelefoneCliente)
end

-- Procedure para alterar um cliente existente
GO
create procedure spUpdate_Clientes (@Id int, @NomeCliente varchar(100),
 @EnderecoCliente varchar(200), @EmailCliente varchar(100), @TelefoneCliente varchar(20))
as
begin
	update Clientes set
	NomeCliente = @NomeCliente,
	EnderecoCliente = @EnderecoCliente,
	EmailCliente = @EmailCliente,
	TelefoneCliente = @TelefoneCliente
	where Id = @Id
end