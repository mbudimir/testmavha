
Imports Mavha.Data

Partial Class wfNuevaPersona
    Inherits System.Web.UI.Page
    Private personaRepo As New PersonaRepositorio()
    Dim personaId As Integer = 0

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ''If String.IsNullOrEmpty(txtApellido.Text) Or String.IsNullOrEmpty(txtNombre.Text) Or String.IsNullOrEmpty(txtFechaNacimiento.Text) Then

        ''End If
        If Session("personaId") Is Nothing Then
            If personaRepo.Guardar(New Persona(txtApellido.Text, txtNombre.Text, txtFechaNacimiento.Text, ddlSexo.SelectedValue, 0)) Then
                Response.Redirect("Home.aspx")
            Else
                'Error
            End If
        Else
            personaId = Session("personaId")
            If personaRepo.Editar(personaId, New Persona(txtApellido.Text, txtNombre.Text, txtFechaNacimiento.Text, ddlSexo.SelectedValue, personaId)) Then
                Response.Redirect("Home.aspx")
            Else
                'Error
            End If
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            personaId = Request.QueryString("id")
            Session("personaId") = personaId
            CargarPersona(personaId)
        End If

    End Sub

    Private Sub CargarPersona(id As Integer)
        Dim persona As Persona = personaRepo.Listado().Single(Function(s) s.PersonaId = id)
        txtApellido.Text = persona.Apellido
        txtNombre.Text = persona.Nombres
        txtFechaNacimiento.Text = persona.FechaNacimiento
        ddlSexo.SelectedValue = CType(persona.Sexo, Integer)

    End Sub
End Class
