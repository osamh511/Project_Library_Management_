Imports System.Configuration
Namespace Library_Management.DLL
    'ملاحظات:

    'MustInherit تعني أن هذا الكلاس لا يُستخدم مباشرة، بل يُورّث منه.

    'ConnString متغير محمي (Protected) بحيث يمكن للمستودعات المشتقة استخدامه.
    ' قاعدة المستودع العامة

    'ملاحظات
    'هذا الكلاس مُعرَّف بكلمة MustInherit أي أنه كلاس أساسي لا يمكن استخدامه مباشرة،
    'ووظيفته الوحيدة
    'هي قراءة إعدادات الاتصال من ملف App.config

    Public MustInherit Class RepositoryBase ' : كلاس أساسي (Abstract) يهدف لتوفير سلسلة الاتصال بقاعدة البيانات لجميع المستودعات الأخرى
        'يحتوي على متغير محمي   Protected ReadOnly ConnString As String  ليتمكن الأبناء فقط من رؤيته
        Protected ReadOnly ConnString As String        'هذا المتغير يحمل نص الاتصال بقاعدة البيانات (Connection String)، ويكون متاح فقط للكلاسات التي ترث منه.


        Public Sub New()
            ' قراءة الاتصال مرة واحدة من App.config
            ConnString = ConfigurationManager.ConnectionStrings("LibraryDB").ConnectionString
        End Sub
    End Class
End Namespace


