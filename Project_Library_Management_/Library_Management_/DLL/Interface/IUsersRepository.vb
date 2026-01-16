Namespace Library_Management.Interface
    Public Interface IUsersRepository
        Function ValidateLogin(username As String, password As String) As Boolean
    End Interface

End Namespace

