ALTER PROCEDURE planetas_upd @id INT, 
	@Nome VARCHAR(200), 
	@Descricao VARCHAR(500), 
	@PossuiOxigenio BIT
AS
BEGIN
	UPDATE Planetas 
	SET Nome = @Nome, Descricao = @Descricao, PossuiOxigenio = @PossuiOxigenio
	WHERE Id = @Id

	SELECT 'Campo(s) Atualizado com Sucesso!' AS msgSucesso
END
EXEC planetas_upd 13, 'Planeta TZ564', 'Maior Planeta da galaxia T32, possui condições de vida.', 1

SELECT * FROM Planetas