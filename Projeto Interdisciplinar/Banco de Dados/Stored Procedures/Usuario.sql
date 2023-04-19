-- Procedures utilizadas no UsuarioDAO

-- Procedure para incluir novos usuários
create procedure spInsert_Usuarios (@Id int, @FotoUsuario varbinary(max),
 @LoginUsuario varchar(50), @SenhaUsuario varchar(50), @IDCliente int)
as
begin
	insert into Usuarios
	(Id, FotoUsuario, LoginUsuario, SenhaUsuario, IDCliente)
	values
	(@Id, @FotoUsuario, @LoginUsuario, @SenhaUsuario, @IDCliente)
end

-- Procedure para alterar um usuário existente
GO
create procedure spUpdate_Usuarios (@Id int, @FotoUsuario varbinary(max),
 @LoginUsuario varchar(50), @SenhaUsuario varchar(50), @IDCliente int)
as
begin
	update Usuarios set
	FotoUsuario = @FotoUsuario,
	LoginUsuario = @LoginUsuario,
	SenhaUsuario = @SenhaUsuario,
	IDCliente = @IDCliente
	where Id = @Id
end