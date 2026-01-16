Imports Library_Management_.Library_Management.Interface
Imports Microsoft.Data.SqlClient
Namespace Library_Management.DLL
    Public Class UsersRepositorySql ' للتحقق من بيانات تسجيل الدخول
        Inherits RepositoryBase
        Implements IUsersRepository

        Public Function ValidateLogin(username As String, password As String) As Boolean Implements IUsersRepository.ValidateLogin
            Using conn As New SqlConnection(ConnString)
                Using cmd As New SqlCommand("sp_CheckLogin", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@User", username)
                    cmd.Parameters.AddWithValue("@Pass", password)
                    conn.Open()
                    Dim count As Integer = CInt(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        End Function
    End Class

End Namespace
