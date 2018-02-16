Imports Mavha.Desktop.PersonasSvc

Public Class Home
    Private personaServices As New PersonasSvc.ServiceSoapClient
    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizaGrilla()
    End Sub

    Private Sub ActualizaGrilla()
        dgvPersonas.DataSource = personaServices.Listado()
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Dim dr As DialogResult = frmNuevaPersona.ShowDialog()

        If dr = DialogResult.OK Then
            ActualizaGrilla()
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim persona As New Persona With {
            .PersonaId = dgvPersonas.CurrentRow.Cells.Item(0).Value,
            .Apellido = dgvPersonas.CurrentRow.Cells.Item(1).Value,
            .Nombres = dgvPersonas.CurrentRow.Cells.Item(2).Value,
            .FechaNacimiento = dgvPersonas.CurrentRow.Cells.Item(3).Value,
            .Sexo = dgvPersonas.CurrentRow.Cells.Item(4).Value
        }
        Dim frmNewPerson As New frmNuevaPersona(persona)

        Dim dr As DialogResult = frmNewPerson.ShowDialog()

        If dr = DialogResult.OK Then
            ActualizaGrilla()
        End If
    End Sub

    Private Sub dgvPersonas_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPersonas.SelectionChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim mensaje As String = String.Format(" Seguro desea eliminar a {0} {1}?", dgvPersonas.CurrentRow.Cells.Item(1).Value, dgvPersonas.CurrentRow.Cells.Item(2).Value)
        If MessageBox.Show(mensaje, "Eliminar Persona", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            personaServices.Anular(dgvPersonas.CurrentRow.Cells.Item(0).Value)
            ActualizaGrilla()
        End If
    End Sub
End Class