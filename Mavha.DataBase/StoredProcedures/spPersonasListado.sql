USE Mavha
IF OBJECT_ID('[dbo].[sp_Personas_Listado]', 'P') IS NOT NULL
DROP PROC [dbo].[sp_Personas_Listado]
GO
-- =============================================
-- Author:		Marcos
-- Create date: 2018-02-15
-- Description:	Listado de todas las personas no anuladas
-- =============================================
CREATE PROCEDURE [dbo].[sp_Personas_Listado]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		P.PersonaId,
		P.Apellido,
		P.Nombres,
		P.FechaNacimiento,
		P.Sexo,
		P.Anulado
	FROM Personas P
	WHERE P.Anulado = 0
END