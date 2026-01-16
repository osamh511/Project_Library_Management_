Imports Library_Management_.Library_Management.Model

Namespace Library_Management.BLL
    Public NotInheritable Class BookValidator 'هي نقطة الانطلاق في حال وجود خطأ في قواعد البيانات المنطقية (مثل ترك حقل فارغ)
        Public Shared Sub Validate(b As Book) ' تم فحص البيانات وإطلاق الاستثناء يدوياً
            ' الهدف: منع وصول أي بيانات "غير منطقية" (مثل عنوان فارغ أو عدد نسخ سالب)  إلى المستودع أو قاعدة البيانات
            If String.IsNullOrWhiteSpace(b.Title) Then Throw New AppException("العنوان مطلوب") ' الحالة: هنا الاستثناء "وُلد" في هذه الطبقة 
            If String.IsNullOrWhiteSpace(b.Author) Then Throw New AppException("المؤلف مطلوب")
            If b.Copies < 0 Then Throw New AppException("عدد النسخ لا يمكن أن يكون سالباً")
        End Sub
    End Class
End Namespace


