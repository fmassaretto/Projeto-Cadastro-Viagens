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



ALTER PROCEDURE clientes_upd @Id INT, 
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


GO

CREATE PROCEDURE transprte_upd @Id INT,
	@Nome VARCHAR(50),
	@Terreno VARCHAR(50)
AS
BEGIN
	UPDATE Transportes
	SET Nome = @Nome, Terreno = @Terreno
	WHERE Id = @Id

	SELECT 'Campo(s) de Transporte Atualizado com Sucesso!' AS msgSucesso
END

GO


ALTER PROCEDURE viagensDispo_upd @Id INT,
	@PlanetaOrigem VARCHAR(50),
	@PlanetaDestino VARCHAR(50),
	@Valor INT,
	@Tempo INT
AS
BEGIN
	UPDATE ViagensDisponiveis
	SET PlanetaOrigem = @PlanetaOrigem, PlanetaDestino = @PlanetaDestino, Valor = @Valor, Tempo = @Tempo
	WHERE Id = @Id

	SELECT 'Campo(s) de Viagens Disponíveis Atualizado com Sucesso!' AS msgSucesso
END

SELECT * FROM Planetas