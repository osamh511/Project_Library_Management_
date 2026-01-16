Imports Library_Management_.Library_Management.DLL
Imports Library_Management_.Library_Management.Interface

'مـــــلاحظة مهمة جدا
'عندما نقول "Constructor Injection"، نحن نقصد النمط كاملاً: تعريف المنشئ في الفورم لاستقبال التبعيات،
'وتمرير هذه التبعيات عند إنشاء الفورم في. هذا ما يسمى بـ "فك الارتباط" (Decoupling)،
'حيث لا يقوم الفورم بإنشاء مستودعه بنفسه، بل ينتظر أن يأتيه من الخارج

'''frmLogin: هو الذي يمتلك المنشئ الذي يقبل الحقن (The Receiver)
Public Class frmLogin ' شاشة تسجيل الدخول التي تتحقق من هوية المستخدم قبل فتح النظام
    Private ReadOnly _usersRepo As IUsersRepository
    Public Sub New(usersRepo As IUsersRepository) '    'هذا الفورم يعلن رسمياً: "أنا لا أستطيع العمل بدون كائن يحقق واجهةIUsersRepository

        InitializeComponent()
        _usersRepo = usersRepo
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            If _usersRepo.ValidateLogin(txtUser.Text, txtPass.Text) Then
                Me.Hide()
                Dim booksForm As New frmBooks(New BooksRepositorySql())
                booksForm.ShowDialog()
                Me.Close()
            Else
                MsgBox("اسم المستخدم أو كلمة المرور غير صحيحة", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            ErrorHandler.Handle(ex)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
