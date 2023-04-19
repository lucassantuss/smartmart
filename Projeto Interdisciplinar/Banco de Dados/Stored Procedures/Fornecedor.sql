-- Procedures utilizadas no FornecedorDAO

-- Procedure para incluir novos fornecedores
create procedure spInsert_Fornecedores (@Id int, @NomeFornecedor varchar(100),
 @EnderecoFornecedor varchar(200), @EmailFornecedor varchar(100), @TelefoneFornecedor varchar(20))
as
begin
	insert into Fornecedores
	(Id, NomeFornecedor, EnderecoFornecedor, EmailFornecedor, TelefoneFornecedor)
	values
	(@Id, @NomeFornecedor, @EnderecoFornecedor, @EmailFornecedor, @TelefoneFornecedor)
end

-- Procedure para alterar um fornecedor existente
GO
create procedure spUpdate_Fornecedores (@Id int, @NomeFornecedor varchar(100),
 @EnderecoFornecedor varchar(200), @EmailFornecedor varchar(100), @TelefoneFornecedor varchar(20))
as
begin
	update Fornecedores set
	NomeFornecedor = @NomeFornecedor,
	EnderecoFornecedor = @EnderecoFornecedor,
	EmailFornecedor = @EmailFornecedor,
	TelefoneFornecedor = @TelefoneFornecedor
	where Id = @Id
end