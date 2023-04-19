-- Procedures utilizadas no UsuarioDAO

-- Procedure para incluir novos usuários
create procedure spIncluiUsuario (@IDUsuario int, @FotoUsuario varbinary(max),
 @LoginUsuario varchar(50), @SenhaUsuario varchar(50), @IDCliente int)
as
begin
	insert into Usuarios
	(IDUsuario, FotoUsuario, LoginUsuario, SenhaUsuario, IDCliente)
	values
	(@IDUsuario, @FotoUsuario, @LoginUsuario, @SenhaUsuario, @IDCliente)
end

-- Procedure para alterar um usuário existente
GO
create procedure spAlteraUsuario (@IDUsuario int, @FotoUsuario varbinary(max),
 @LoginUsuario varchar(50), @SenhaUsuario varchar(50), @IDCliente int)
as
begin
	update Usuarios set
	FotoUsuario = @FotoUsuario,
	LoginUsuario = @LoginUsuario,
	SenhaUsuario = @SenhaUsuario,
	IDCliente = @IDCliente
	where IDUsuario = @IDUsuario
end

-- Procedure para excluir um usuário
GO
create procedure spExcluiUsuario (@IDUsuario int)
as
begin
	delete Usuarios where IDUsuario = @IDUsuario
end

-- Procedure para consultar um usuário
GO
create procedure spConsultaUsuario (@IDUsuario int)
as
begin
	select * from Usuarios where IDUsuario = @IDUsuario
end

-- Procedure para listar todos os usuários existentes no sistema
GO
create procedure spListagemUsuarios
as
begin
	select * from Usuarios
end