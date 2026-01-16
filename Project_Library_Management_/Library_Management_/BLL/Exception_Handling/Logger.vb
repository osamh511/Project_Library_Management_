
Imports System.IO
'هاذى الكلاس هو الصندوق الاسود للنظام كامل 
Public Class Logger '  كلاس مسؤول عن تسجيل تفاصيل الأخطاء في ملفات نصية خارجية للرجوع إليها لاحقاً
    Private Shared ReadOnly LogPath As String =
    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")
    Public Shared Sub Log(ex As Exception) ' دالة التدوين الي يتم استدعائها من كلاس معالج الاخطاء ErrorHandler
        If Not Directory.Exists(LogPath) Then Directory.CreateDirectory(LogPath) ' يقوم الكود تلقائياً بإنشاء مجلد يسمى "Logs" في مسار تشغيل البرنامج إذا لم يكن موجوداً
        Dim filePath = Path.Combine(LogPath, $"log_{DateTime.Now:yyyy_MM_dd}.txt")
        Using writer As New StreamWriter(filePath, True) ' يفتح الكود القناة للملف بوضع Append (إضافة للنهاية) عبر New StreamWriter(filePath, True)
            writer.WriteLine("=================================")
            writer.WriteLine(DateTime.Now.ToString("u"))
            writer.WriteLine(ex.Message)
            writer.WriteLine(ex.StackTrace)
        End Using
    End Sub

End Class
