
Public Class AppException ' نظام مخصص لإدارة الاستثناءات وعرض رسائل خطأ واضحة للمستخدم
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
    Public Sub New(message As String, inner As Exception)
        MyBase.New(message, inner)
    End Sub
End Class
