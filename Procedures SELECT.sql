USE [ViagensInterplanetarias]
GO
/****** Object:  StoredProcedure [dbo].[clientesPorNome_sps]    Script Date: 2017-04-10 5:36:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[clientesPorNome_sps] @NOME VARCHAR(200)
AS
BEGIN
	SELECT Id, Nome, Especie, Documento, Cor, QtdBracos, QtdPernas, QtdCabeca, Respira FROM Clientes WHERE Nome = @Nome
END

GO

ALTER PROCEDURE [dbo].[clientesTodos_sps]
AS
BEGIN
	SELECT Nome, Especie, Documento, Cor, QtdBracos, QtdPernas, QtdCabeca, Respira FROM Clientes
END


select * from ViagensClientes
select * from Planetas
