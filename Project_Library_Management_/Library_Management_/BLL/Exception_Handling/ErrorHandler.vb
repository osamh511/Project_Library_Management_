Public Class ErrorHandler ' هاذى الكلاس : هو نظام مخصص لإدارة الاستثناءات وعرض رسائل خطأ واضحة للمستخدم بحيث يعتبر المحرك المركزي يعني كانة وحدة معالجة مركزية بحيث بحيث يتم توجيهة الاستثناء الية ليقرر كيف راح يظهر للمستخدم  
    Public Shared Sub Handle(ex As Exception) ' هاذى الكلاس يعتبر 4. المحرك المركزي (ErrorHandler)

        Logger.Log(ex) '• الخطوة الأولى (التوثيق): يستدعي المحرك دالة التدوين: Logger.Log(ex)
        'الحالة:
        'هنا يتم التعرف على أن الاستثناء من نوع AppException
        '(الذي أطلقناه في BLL)، فيسمح النظام بمرور رسالته النصية الواضحة للمستخدم

        'ملخص مسار الانتقال
        '(Trace Path) تسلسل
        'BLL(إطلاق AppException) -> DLL (تمرير الاستثناء) -> UI (التقاط عبر Catch) -> ErrorHandler (عرض الرسالة للمستخدم)

        If TypeOf ex Is AppException Then
            MsgBox(ex.Message, MsgBoxStyle.Critical, "خطأ")
        Else
            MsgBox("حدث خطأ غير متوقع، يرجى مراجعة الدعم", MsgBoxStyle.Critical, "خطأ")
        End If
    End Sub

End Class
