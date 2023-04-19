-- Procedures utilizadas no FornecedorDAO

-- Procedure para incluir novos fornecedores
create procedure spIncluiFornecedor (@IDFornecedor int, @NomeFornecedor varchar(100),
 @EnderecoFornecedor varchar(200), @EmailFornecedor varchar(100), @TelefoneFornecedor varchar(20))
as
begin
	insert into Fornecedores
	(IDFornecedor, NomeFornecedor, EnderecoFornecedor, EmailFornecedor, TelefoneFornecedor)
	values
	(@IDFornecedor, @NomeFornecedor, @EnderecoFornecedor, @EmailFornecedor, @TelefoneFornecedor)
end

-- Procedure para alterar um fornecedor existente
GO
create procedure spAlteraFornecedor (@IDFornecedor int, @NomeFornecedor varchar(100),
 @EnderecoFornecedor varchar(200), @EmailFornecedor varchar(100), @TelefoneFornecedor varchar(20))
as
begin
	update Fornecedores set
	NomeFornecedor = @NomeFornecedor,
	EnderecoFornecedor = @EnderecoFornecedor,
	EmailFornecedor = @EmailFornecedor,
	TelefoneFornecedor = @TelefoneFornecedor
	where IDFornecedor = @IDFornecedor
end

-- Procedure para excluir um fornecedor
GO
create procedure spExcluiFornecedor (@IDFornecedor int)
as
begin
	delete Fornecedores where IDFornecedor = @IDFornecedor
end

-- Procedure para consultar um fornecedor
GO
create procedure spConsultaFornecedor (@IDFornecedor int)
as
begin
	select * from Fornecedores where IDFornecedor = @IDFornecedor
end

-- Procedure para listar todos os fornecedores existentes no sistema
GO
create procedure spListagemFornecedores
as
begin
	select * from Fornecedores
end