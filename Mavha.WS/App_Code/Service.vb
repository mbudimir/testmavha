Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Mavha.Data

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Service
    Inherits System.Web.Services.WebService

    Private personaRepo As New PersonaRepositorio()

    <WebMethod()> _
    Public Function Listado() As List(Of Persona)
        Return personaRepo.Listado()
    End Function

    <WebMethod()> _
    Public Function Guardar(persona As Persona) As Boolean
        Return personaRepo.Guardar(persona)
    End Function

    <WebMethod()> _
    Public Function Editar(id As Integer, persona As Persona) As Boolean
        Return personaRepo.Editar(id, persona)
    End Function

    <WebMethod()> _
    Public Function Anular(id As Integer) As Boolean
        Return personaRepo.Anular(id)
    End Function
End Class