Imports Mavha.Desktop.PersonasSvc

Public Class frmNuevaPersona
    Private personaServices As New PersonasSvc.ServiceSoapClient
    Private personaId As Integer = 0
    Private persona As Persona

    Public Sub New(persona As Persona)
        Me.InitializeComponent()
        Me.Text = "Editar Persona"
        btnGuardar.Text = "Editar"
        personaId = persona.PersonaId
        Cargar_Combo()
        Cargar_DatosPersona(persona)
    End Sub

    Public Sub New()
        Me.InitializeComponent()
        Cargar_Combo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If String.IsNullOrEmpty(txtApellido.Text) And String.IsNullOrEmpty(txtNombres.Text) Then
            MessageBox.Show("Debe ingresar todos los campos", "Error al guardar persona", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim persona As New Persona()
            persona.Apellido = txtApellido.Text
            persona.Nombres = txtNombres.Text
            persona.FechaNacimiento = dtpFechaNacimiento.Value
            persona.Sexo = cbSexo.SelectedValue
            If personaId <> 0 Then
                'Editar
                If personaServices.Editar(personaId, persona) Then
                    MessageBox.Show("Se ha guardado correctamente", "Nueva Persona", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()

                Else
                    MessageBox.Show("No se ha podido guardar", "Error al guardar persona", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If
            Else 'Crear
                If personaServices.Guardar(persona) Then
                    MessageBox.Show("Se ha guardado correctamente", "Nueva Persona", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    MessageBox.Show("No se ha podido guardar", "Error al guardar persona", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmNuevaPersona_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Cargar_Combo()
        Dim sexos As Type = GetType(SexoEnum)

        Dim query = From n As Object In [Enum].GetValues(sexos)
                    Select New With {n, .Valor = [Enum].GetName(sexos, n)}

        cbSexo.DataSource = query.ToList()
        cbSexo.DisplayMember = "Valor"
        cbSexo.ValueMember = "n"
    End Sub



    Private Sub Cargar_DatosPersona(persona As Persona)
        txtApellido.Text = persona.Apellido
        txtNombres.Text = persona.Nombres
        dtpFechaNacimiento.Value = persona.FechaNacimiento
        cbSexo.SelectedValue = persona.Sexo
    End Sub
End Class