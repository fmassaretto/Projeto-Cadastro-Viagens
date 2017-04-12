USE [ViagensInterplanetarias]
GO
/****** Object:  StoredProcedure [dbo].[planetas_spi]    Script Date: 2017-04-10 6:12:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[planetas_spi] @Nome VARCHAR(50),
		@Descricao VARCHAR(500),
		@PossuiOxigenio BIT
AS
BEGIN
		INSERT INTO Planetas VALUES(@Nome, @Descricao, @PossuiOxigenio)

		SELECT 'Planeta Inserido com Sucesso' AS msgSucesso
END

CREATE PROCEDURE clientes_spi @Nome VARCHAR(200), 
	@Especie VARCHAR(100), 
	@Documento VARCHAR(100), 
	@Cor VARCHAR(100), 
	@QtdBracos INT, 
	@QtdPernas INT, 
	@QtdCabeca INT, 
	@Respira BIT
AS
BEGIN
	INSERT INTO Clientes VALUES(@Nome, @Especie, @Documento, @Cor, @QtdBracos, @QtdPernas, @QtdCabeca, @Respira)

	SELECT 'Cliente Inserido com Sucesso!' AS msgSucesso
END
EXEC clientes_spi 'Et', 'Varginha', 'fayf65', 'Verde', 2, 2, 1, 0

CREATE PROCEDURE viagemCliente_spi @IdCliente INT, @IdViagemDispo INT
AS
BEGIN
	INSERT INTO ViagensClientes VALUES(@IdCliente, @IdViagemDispo)

	SELECT 'Reserva Realizada com sucesso!' AS msgSucesso
END

GO

CREATE PROCEDURE viagemDispo_spi @PlanetaOrigem VARCHAR(50), 
	@PlanetaDestino VARCHAR(50),
	@Valor INT,
	@Tempo INT
AS
BEGIN
	INSERT INTO ViagensDisponiveis VALUES(@PlanetaOrigem, @PlanetaDestino, @Valor, @Tempo)

	SELECT 'Vioagem Inserida com sucesso!' AS msgSucesso
END

select * from ViagensDisponiveis