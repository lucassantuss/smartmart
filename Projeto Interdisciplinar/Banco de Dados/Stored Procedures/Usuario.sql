-- Procedures utilizadas no UsuarioDAO

-- Procedure para incluir novos usuários
create procedure spInsert_Usuarios (@Id int, @FotoUsuario varbinary(max),
 @LoginUsuario varchar(50), @SenhaUsuario varchar(50), @Perfil varchar(50), @IDCliente int)
as
begin
	insert into Usuarios
	(FotoUsuario, LoginUsuario, SenhaUsuario, Perfil, IDCliente)
	values
	(@FotoUsuario, @LoginUsuario, @SenhaUsuario, @Perfil, @IDCliente)
end

-- Procedure para alterar um usuário existente
GO
create procedure spUpdate_Usuarios (@Id int, @FotoUsuario varbinary(max),
 @LoginUsuario varchar(50), @SenhaUsuario varchar(50), @Perfil varchar(50), @IDCliente int)
as
begin
	update Usuarios set
	FotoUsuario = @FotoUsuario,
	LoginUsuario = @LoginUsuario,
	SenhaUsuario = @SenhaUsuario,
	Perfil = @Perfil,
	IDCliente = @IDCliente
	where Id = @Id
end