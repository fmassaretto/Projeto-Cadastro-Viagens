CREATE PROCEDURE planetas_del @Id INT
AS
BEGIN
	DELETE FROM Planetas WHERE Id = @Id

	SELECT 'Planeta Excluido com Sucesso!' AS msgSucesso
END
EXEC planetas_del 16

select * from Planetas