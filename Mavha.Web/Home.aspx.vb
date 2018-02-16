
Imports Mavha.Data

Partial Class Home
    Inherits System.Web.UI.Page

    Private personaRepo As New PersonaRepositorio()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        gvPersonas.DataSource = personaRepo.Listado()
        gvPersonas.DataBind()
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Response.Redirect("wfNuevaPersona.aspx?id=0")
    End Sub
    Protected Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If gvPersonas.SelectedRow IsNot Nothing Then
            Dim id As String = gvPersonas.SelectedRow.Cells.Item(1).Text
            Response.Redirect("wfNuevaPersona.aspx?id=" + id)
        End If

    End Sub
    Protected Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If gvPersonas.SelectedRow IsNot Nothing Then
            Dim id As String = gvPersonas.SelectedRow.Cells.Item(1).Text
            If personaRepo.Anular(id) Then
                gvPersonas.DataSource = personaRepo.Listado()
                gvPersonas.DataBind()
            End If

        End If
    End Sub
End Class
