
Imports Library_Management_.LibraryManagement.Model

Public NotInheritable Class MemberValidator ' للتحقق من صحة البيانات المدخلة للكتب والأعضاء (مثل التأكد من وجود عنوان للكتاب أو صحة البريد الإلكتروني)
    Public Shared Sub Validate(m As Member)
        If String.IsNullOrWhiteSpace(m.FullName) Then Throw New AppException("اسم العضو مطلوب")
        If Not String.IsNullOrWhiteSpace(m.Email) AndAlso Not m.Email.Contains("@") Then
            Throw New AppException("البريد الإلكتروني غير صالح")
        End If
    End Sub
End Class
