-- HELPER PROCEDURES

-- Procedure capaz de verificar o próximo Id disponível da tabela
GO
create procedure spProximoId (@tabela varchar(max))
as
begin
	exec('select isnull(max(id) +1, 1) as MAIOR from ' + @tabela)
end