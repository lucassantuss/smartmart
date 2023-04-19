-- HELPER PROCEDURES

-- Procedure capaz de deletar um registro da tabela
create procedure spDelete (@id int, @tabela varchar(max))
as
begin
 declare @sql varchar(max);
 set @sql = 'delete ' + @tabela + ' where Id = ' + cast(@id as varchar(max))
 exec(@sql)
end

-- Procedure capaz de consultar um registro da tabela
GO
create procedure spConsulta (@id int, @tabela varchar(max))
as
begin
 declare @sql varchar(max);
 set @sql = 'select * from ' + @tabela + ' where Id = ' + cast(@id as varchar(max))
 exec(@sql)
end

-- Procedure capaz de listar todos os dados ordenados da tabela
GO
create procedure spListagem (@tabela varchar(max), @ordem varchar(max))
as
begin
 exec('select * from ' + @tabela + ' order by ' + @ordem)
end

-- Procedure capaz de verificar o próximo Id disponível da tabela
GO
create procedure spProximoId (@tabela varchar(max))
as
begin
	exec('select isnull(max(Id) +1, 1) as MAIOR from ' + @tabela)
end