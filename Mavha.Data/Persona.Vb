Public Class Persona

#Region "Variables"
    Private _personaId As Integer
    Private _apellido As String
    Private _nombres As String
    Private _fechaNacimiento As DateTime
    Private _sexo As SexoEnum
    Private _anulado As Boolean
#End Region

    Public Sub New()

    End Sub

    Public Sub New(apellido As String, nombres As String, fechaNacimiento As DateTime, sexo As SexoEnum, personaId As Integer?)
        Me._apellido = apellido
        Me._nombres = nombres
        Me._fechaNacimiento = fechaNacimiento
        Me._sexo = sexo
        If personaId IsNot Nothing Then
            Me._personaId = personaId
        End If
    End Sub

#Region "Propiedades"
    Public Property PersonaId() As String
        Get
            Return _personaId
        End Get
        Set(ByVal value As String)
            _personaId = value
        End Set
    End Property

    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Public Property Nombres() As String
        Get
            Return _nombres
        End Get
        Set(ByVal value As String)
            _nombres = value
        End Set
    End Property

    Public Property FechaNacimiento() As String
        Get
            Return _fechaNacimiento
        End Get
        Set(ByVal value As String)
            _fechaNacimiento = value
        End Set
    End Property


    Public ReadOnly Property Edad() As Integer
        Get
            Return CalcularEdad()
        End Get
    End Property


    Public Property Sexo() As SexoEnum
        Get
            Return _sexo
        End Get
        Set(ByVal value As SexoEnum)
            _sexo = value
        End Set
    End Property


    Public Property Anulado() As Boolean
        Get
            Return _anulado
        End Get
        Set(ByVal value As Boolean)
            _anulado = value
        End Set
    End Property
#End Region

#Region "Metodos"
    Private Function CalcularEdad() As Integer
        Dim anios = DateDiff(DateInterval.Year, _fechaNacimiento, DateTime.Now.Date)
        If (_fechaNacimiento.Month > DateTime.Now.Date.Month) Or (_fechaNacimiento.Month = DateTime.Now.Date.Month And _fechaNacimiento.Day >= DateTime.Now.Date.Day) Then
            anios -= 1
        End If
        Return anios
    End Function
#End Region

End Class
