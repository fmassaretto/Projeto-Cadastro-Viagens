ALTER PROCEDURE planetas_upd @id INT, 
	@Nome VARCHAR(200), 
	@Descricao VARCHAR(500), 
	@PossuiOxigenio BIT
AS
BEGIN
	UPDATE Planetas 
	SET Nome = @Nome, Descricao = @Descricao, PossuiOxigenio = @PossuiOxigenio
	WHERE Id = @Id

	SELECT 'Campo(s) de PLanetas Atualizado com Sucesso!' AS msgSucesso
END



CREATE PROCEDURE clientes_upd @id INT, 
	@Nome VARCHAR(200), 
	@Especie VARCHAR(100), 
	@Documento VARCHAR(100), 
	@Cor VARCHAR(100), 
	@QtdBracos INT, 
	@QtdPernas INT, 
	@QtdCabeca INT, 
	@Respira BIT
AS
BEGIN
	UPDATE Clientes 
	SET Nome = @Nome, Especie = @Especie, Documento = Documento, Cor = @Cor, 
	QtdBracos = @QtdBracos, QtdPernas = @QtdPernas, QtdCabeca =	@QtdCabeca, Respira = @Respira
	WHERE Id = @Id

	SELECT 'Campo(s) de Clientes Atualizado com Sucesso!' AS msgSucesso
END


EXEC planetas_upd 13, 'Planeta TZ564', 'Maior Planeta da galaxia T32, possui condições de vida.', 1

SELECT * FROM Planetas