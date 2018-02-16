Imports System.Data.SqlClient

Public Class PersonaRepositorio
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private sqlReader As SqlDataReader
    Private results As String

    Private strConn As String = "Data Source=.;Initial Catalog=Mavha;Integrated Security=True"
    Private sqlCon As SqlConnection

    Public Sub New()
    End Sub

    Public Function Listado() As List(Of Persona)
        Dim personas As New List(Of Persona)

        sqlCon = New SqlConnection(strConn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            Try
                sqlComm.Connection = sqlCon

                sqlComm.CommandText = "sp_Personas_Listado"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlCon.Open()

                sqlReader = sqlComm.ExecuteReader()

                While sqlReader.Read()
                    personas.Add(New Persona(
                                               sqlReader("Apellido"),
                                               sqlReader("Nombres"),
                                               sqlReader("FechaNacimiento"),
                                               CType(sqlReader("Sexo"), SexoEnum),
                                               sqlReader("PersonaId")
                                            )
                                 )
                End While

                sqlReader.Close()

            Catch ex As Exception

            Finally
                If sqlCon.State <> ConnectionState.Closed Then
                    sqlCon.Close()
                End If
            End Try
            Return personas
        End Using

    End Function

    Public Function Guardar(persona As Persona) As Boolean
        sqlCon = New SqlConnection(strConn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            Try
                sqlComm.Connection = sqlCon

                sqlComm.CommandText = "sp_Personas_Crear"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("pApellido", persona.Apellido)
                sqlComm.Parameters.AddWithValue("pNombres", persona.Nombres)
                sqlComm.Parameters.AddWithValue("pFechaNacimiento", persona.FechaNacimiento)
                sqlComm.Parameters.AddWithValue("pSexo", CType(persona.Sexo, Integer))

                sqlCon.Open()

                sqlComm.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                Return False
            Finally
                If sqlCon.State <> ConnectionState.Closed Then
                    sqlCon.Close()
                End If
            End Try
        End Using

    End Function

    Public Function Editar(id As Integer, persona As Persona) As Boolean
        sqlCon = New SqlConnection(strConn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            Try
                sqlComm.Connection = sqlCon

                sqlComm.CommandText = "sp_Personas_Editar"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("pPersonaId", id)
                sqlComm.Parameters.AddWithValue("pApellido", persona.Apellido)
                sqlComm.Parameters.AddWithValue("pNombres", persona.Nombres)
                sqlComm.Parameters.AddWithValue("pFechaNacimiento", persona.FechaNacimiento)
                sqlComm.Parameters.AddWithValue("pSexo", CType(persona.Sexo, Integer))

                sqlCon.Open()

                sqlComm.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                Return False
            Finally
                If sqlCon.State <> ConnectionState.Closed Then
                    sqlCon.Close()
                End If
            End Try
        End Using
    End Function

    Public Function Anular(id As Integer) As Boolean
        sqlCon = New SqlConnection(strConn)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()
            Try
                sqlComm.Connection = sqlCon

                sqlComm.CommandText = "sp_Personas_Anular"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("pPersonaId", id)

                sqlCon.Open()

                sqlComm.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                Return False
            Finally
                If sqlCon.State <> ConnectionState.Closed Then
                    sqlCon.Close()
                End If
            End Try
        End Using
    End Function

End Class
