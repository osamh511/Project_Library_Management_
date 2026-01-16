Namespace LibraryManagement.Model
    Public Class Member
        Public Property MemberID As Integer
        Public Property FullName As String
        Public Property Phone As String
        Public Property Email As String
        Public Property CreatedAt As DateTime ' سجل تاريخ الانتساب تلقائياً عبر SYSUTCDATETIME()
    End Class
End Namespace
