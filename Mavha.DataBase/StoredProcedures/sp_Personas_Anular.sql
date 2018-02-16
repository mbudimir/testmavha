IF OBJECT_ID('[dbo].[sp_Personas_Anular]', 'P') IS NOT NULL
DROP PROC [dbo].[sp_Personas_Anular]
GO
-- =============================================
-- Author:		Marcos
-- Create date: 2018-02-15
-- Description:	Baja Logica en regitro 
-- =============================================
CREATE PROCEDURE [dbo].[sp_Personas_Anular]
@pPersonaId INT

AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Personas SET
	  Anulado = 1
	WHERE PersonaId = @pPersonaId
END