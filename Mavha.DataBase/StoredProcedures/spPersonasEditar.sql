IF OBJECT_ID('[dbo].[sp_Personas_Editar]', 'P') IS NOT NULL
DROP PROC [dbo].[sp_Personas_Editar]
GO
-- =============================================
-- Author:		Marcos
-- Create date: 2018-02-15
-- Description:	Edita registro de persona
-- =============================================
CREATE PROCEDURE [dbo].[sp_Personas_Editar]
@pPersonaId INT,
@pApellido VARCHAR(50),
@pNombres VARCHAR(50),
@pFechaNacimiento DATETIME,
@pSexo INT

AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Personas SET
	  Apellido = @pApellido,
	  Nombres = @pNombres, 
	  FechaNacimiento = @pFechaNacimiento, 
	  Sexo = @pSexo
	WHERE PersonaId = @pPersonaId
END