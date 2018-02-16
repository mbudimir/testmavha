IF OBJECT_ID('[dbo].[sp_Personas_Crear]', 'P') IS NOT NULL
DROP PROC [dbo].[sp_Personas_Crear]
GO
-- =============================================
-- Author:		Marcos
-- Create date: 2018-02-15
-- Description:	Nuevo Registro en la tabla Persona
-- =============================================
CREATE PROCEDURE [dbo].[sp_Personas_Crear]

@pApellido VARCHAR(50),
@pNombres VARCHAR(50),
@pFechaNacimiento DATETIME,
@pSexo INT

AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Personas (Apellido, Nombres, FechaNacimiento, Sexo, Anulado) VALUES
	(
		@pApellido, @pNombres, @pFechaNacimiento, @pSexo, 0
	)
END