Imports Library_Management_.Library_Management.BLL
Imports Library_Management_.Library_Management.Interface
Imports Library_Management_.Library_Management.Model
Imports Microsoft.Data.SqlClient

Namespace Library_Management.DLL
    'هذا الكلاس هو المسؤول عن التعامل المباشر مع قاعدة البيانات؛ فهو يفتح الاتصال
    '(SqlConnection) وينفذ أوامر SQL (Select, INSERT) ويقوم بتحويل الصفوف إلى كائنات

    'كلاس BooksRepositorySql
    'هو "أداة تنفيذ" وليس "منطق قرار"
    Public Class BooksRepositorySql ' تنفيذ عمليات الـ CRUD للكتب باستخدام SQL وتدعم وضع الاتصال المنفصل (Disconnected Mode) عبر DataSet
        Inherits RepositoryBase
        Implements IBooksRepository

        Public Sub Add(book As Book) Implements IBooksRepository.Add
            BookValidator.Validate(book) ' تستلم هذه الطبقة الكائن، وتقوم باستدعاء الـ Validator قبل إرساله لقاعدة البيانا
            Using conn As New SqlConnection(ConnString)
                Using cmd As New SqlCommand("sp_AddBook", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Title", book.Title) ' هنا السيرفر مثل SQLserver  يقوم باارسال الخصائص تبع الكتاب مثل(الموجودة بكلاس الكتاب )   بـــاستلام البيانات: يأخذ الإجراء القيم المرسلة (@Title, @Author, @ISBN, @Copies) 
                    cmd.Parameters.AddWithValue("@Author", book.Author)
                    cmd.Parameters.AddWithValue("@ISBN", If(String.IsNullOrWhiteSpace(book.ISBN), CType(DBNull.Value, Object), book.ISBN))
                    cmd.Parameters.AddWithValue("@Copies", book.Copies)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub Update(book As Book) Implements IBooksRepository.Update
            BookValidator.Validate(book)
            Using conn As New SqlConnection(ConnString)
                Using cmd As New SqlCommand("sp_UpdateBook", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@BookID", book.BookID)
                    cmd.Parameters.AddWithValue("@Title", book.Title)
                    cmd.Parameters.AddWithValue("@Author", book.Author)
                    cmd.Parameters.AddWithValue("@ISBN", If(String.IsNullOrWhiteSpace(book.ISBN), CType(DBNull.Value, Object), book.ISBN))
                    cmd.Parameters.AddWithValue("@Copies", book.Copies)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub Delete(bookID As Integer) Implements IBooksRepository.Delete
            Using conn As New SqlConnection(ConnString)
                Using cmd As New SqlCommand("DELETE FROM dbo.Books WHERE BookID=@BookID", conn)
                    cmd.Parameters.AddWithValue("@BookID", bookID)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        '🧩 خلاصة التسلسل
        'RepositoryBase → BooksRepositorySql → GetAll() → SQL مباشر → List(Of Book) → Business Logic (Add, Update, Delete)
        ''' <summary>
        ''' Function GetAll() As List(Of Book)
        '''ترجع قائمة(List) من الكائنات Book.
        '''كل عنصر يمثل كتاب واحد من قاعدة البيانات.
        '''هذه الطريقة هي الأكثر شيوعًا لأنها تعطيك كائنات strongly-typed (يعني كل كتاب له خصائص واضحة: BookID, Title, Author...).
        '''تستخدم عادة لعرض البيانات في الـ DataGridView أو التعامل البرمجي مع الكتب.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetAll() As List(Of Book) Implements IBooksRepository.GetAll ' List(Of Book)	للتعامل البرمجي مع الكائنات بشكل قوي ومرن
            Dim list As New List(Of Book)
            Using conn As New SqlConnection(ConnString)
                Using cmd As New SqlCommand("SELECT BookID, Title, Author, ISBN, Copies, CreatedAt FROM dbo.Books", conn) ' هنا يتم تفكيك خصائص هذا الكائن لتحويلها إلى بارامترات SQL:
                    conn.Open()
                    '  Using r = cmd.ExecuteReader()  =  بحيث يبدأ الـ Reader في سحب البيانات مباشرة من السيرفر. هذا الوضع يسمى "متصل" لأن القارئ يحتاج للاتصال بالخادم طوال فترة قراءته للبيانات
                    Using r = cmd.ExecuteReader() 'التنفيذ (ExecuteReader): هذه الأداة هي الأسرع لقراءة البيانات بشكل متسلسل (صفاً تلو الآخر) في النمط المتصل
                        ' وهنا يتم
                        ' = ي كل دورة (Loop)، يتم إنشاء كائن جديد من نوع Book وتعبئة خصائصه من أعمدة قاعدة البيانات. هذا ما يجعل البيانات "قوية النوع" (Strongly Typed)؛
                        ' لأنك تتعامل مع خصائص مثل .Title بدلاً من أسماء أعمدة نصية
                        While r.Read()
                            list.Add(New Book With {
                                .BookID = CInt(r("BookID")),
                                .Title = r("Title").ToString(),
                                .Author = r("Author").ToString(),
                                .ISBN = If(TryCast(r("ISBN"), String), Nothing),
                                .Copies = CInt(r("Copies")),
                                .CreatedAt = CDate(r("CreatedAt"))
                            })
                        End While
                    End Using 'بمجرد خروج الكود من بلوك الـ Using يتم إغلاق الاتصال فوراً وتعود القائمة List(Of Book) إلى منطق الأعمال.
                End Using
            End Using
            Return list
        End Function

        ''' <summary>
        ''' Function SearchByTitle(keyword As String) As List(Of Book)
        '''تبحث في قاعدة البيانات عن الكتب التي تحتوي عناوين مشابهة للكلمة المدخلة.
        '''ترجع أيضًا قائمة من الكائنات Book.
        '''فائدتها: تصفية البيانات بدلًا من جلب كل الكتب.
        '''مثال عملي: المستخدم يكتب "C#" → الدالة ترجع كل الكتب التي عنوانها يحتوي "C#".
        ''' </summary>
        ''' <param name="keyword"></param>
        ''' <returns></returns>
        Public Function SearchByTitle(keyword As String) As List(Of Book) Implements IBooksRepository.SearchByTitle 'List(Of Book)	للبحث والتصفية حسب العنوا
            Dim list As New List(Of Book)
            Using conn As New SqlConnection(ConnString)
                Using cmd As New SqlCommand("SELECT BookID, Title, Author, ISBN, Copies, CreatedAt FROM dbo.Books WHERE Title LIKE @kw", conn)
                    cmd.Parameters.AddWithValue("@kw", "%" & keyword & "%")
                    conn.Open()
                    Using r = cmd.ExecuteReader()
                        While r.Read()
                            list.Add(New Book With {
                                .BookID = CInt(r("BookID")),
                                .Title = r("Title").ToString(),
                                .Author = r("Author").ToString(),
                                .ISBN = If(TryCast(r("ISBN"), String), Nothing),
                                .Copies = CInt(r("Copies")),
                                .CreatedAt = CDate(r("CreatedAt"))
                            })
                        End While
                    End Using
                End Using
            End Using
            Return list
        End Function
        '🧩 خلاصة التسلسل
        'Disconnected Mode
        'RepositoryBase → BooksRepositorySql → GetAllDataSet() → SqlDataAdapter → DataSet → DataGridView → تعديل المستخدم → BulkUpdate → SQL جماعي

        ' Disconnected Mode

        '''        Function GetAllDataSet() As DataSet
        '''            هذه نسخة أخرى من GetAll لكنها ترجع DataSet بدلًا من قائمة كائنات.
        '''الـ DataSet هو بنية بيانات قديمة في .NET تُستخدم مع Disconnected Mode (يعني العمل مع البيانات بدون اتصال مباشر بقاعدة البيانات).
        '''فائدتها:    تسمح لك بتحميل جدول كامل من قاعدة البيانات إلى الذاكرة، ثم التعامل معه كـ DataTable.
        '''هذا مفيد إذا أردت تعديل البيانات بشكل جماعي أو ربطها مباشرة بـ DataGridView بدون تحويلها إلى كائنات.

        '' مهـــــــــــــم جداء الاطلاع على هاذى وهاذى لتحقيق Disconnected Mode
        'اهمية Dim adapter As New SqlDataAdapter
        'هنا SqlDataAdapter يلعب دور الوسيط بحيث يتم تحظير المحقن بهاذى الكود 
        'لا يحتاج منك فتح الاتصال يدوياً بـ conn.Open()؛ فهو "ذكي" بما يكفي ليقوم بفتح الاتصال، جلب البيانات، وإغلاقه فوراً بمجرد انتهاء المهمة 

        'الخـــلاصة:
        'في هذه الجزئية، الـ
        'SqlDataAdapter هو "الموظف" الذي يذهب للمخزن (SQL)، يملأ الشاحنة (DataSet) بالبضاعة (Rows)،
        'ثم يغادر المخزن ويغلقه، لتصبح البضاعة تحت تصرفك في "المتجر" (الذاكرة) بعيداً عن المخزن الرئيسي
        Public Function GetAllDataSet() As DataSet Implements IBooksRepository.GetAllDataSet ' DataSet	للعرض السريع وربط مباشر مع واجهة المستخدم (Disconnected Mode)
            Using conn As New SqlConnection(ConnString)
                '• يعمل SqlDataAdapter كجسر بين قاعدة البيانات والذاكرة؛ حيث يقوم بتحميل البيانات من قاعدة البيانات وصبّها في الـ DataSet
                'لا يقتصر دوره على الجلب فقط، بل هو المسؤول لاحقاً عن عملية BulkUpdate، حيث يستخدم أدوات مثل SqlCommandBuilder لتوليد أوامر SQL (الإضافة، التعديل، الحذف) تلقائياً لتنفيذ التغييرات دفعة واحدة
                Dim adapter As New SqlDataAdapter("SELECT BookID, Title, Author, ISBN, Copies FROM dbo.Books", conn) 'هنا SqlDataAdapter يلعب دور الوسيط بحيث يتم تحظير المحقن بهاذى الكود 
                ', بحيث هنا  يتم سحب البيانات من SQL إلى الذاكرة 
                'عن طريق +  Dim ds As New DataSet() &    adapter.Fill(ds, "Books")

                Dim ds As New DataSet() '1. إنشاء الحاوية:
                adapter.Fill(ds, "Books") ' 2.  هنا يتم كلاء من :فتح الاتصال + سحب البيانات + إغلاق الاتصال  
                Return ds
            End Using
        End Function
        '🧩 خلاصة التسلسل
        'Disconnected Mode
        'RepositoryBase → BooksRepositorySql → GetAllDataSet() → SqlDataAdapter → DataSet → DataGridView → تعديل المستخدم → BulkUpdate → SQL جماعي


        ''' <summary>
        ''' SqlDataAdapter يقرأ الجدول من قاعدة البيانات.
        '''SqlCommandBuilder يولّد أوامر SQL (INSERT, UPDATE, DELETE) تلقائيًا بناءً على التغييرات في DataSet.
        '''adapter.Update(ds, "Books") ينفذ كل التغييرات مرة واحدة على قاعدة البيانات.
        '''BulkUpdate: حفظ كل التغييرات مرة واحدة إلى قاعدة البيانات باستخدام أوامر SQL التي يولدها SqlCommandBuilder.
        ''' </summary>
        ''' <param name="ds"></param>
        Public Sub BulkUpdate(ds As DataSet) Implements IBooksRepository.BulkUpdate '  لا ترجع شيء)	لحفظ التعديلات الجماعية من DataSet إلى قاعدة البيانات
            Using conn As New SqlConnection(ConnString)
                '• يعمل SqlDataAdapter كجسر بين قاعدة البيانات والذاكرة؛ حيث يقوم بتحميل البيانات من قاعدة البيانات وصبّها في الـ DataSet
                'لا يقتصر دوره على الجلب فقط، بل هو المسؤول لاحقاً عن عملية BulkUpdate، حيث يستخدم أدوات مثل SqlCommandBuilder لتوليد أوامر SQL (الإضافة، التعديل، الحذف) تلقائياً لتنفيذ التغييرات دفعة واحدة
                Dim adapter As New SqlDataAdapter("SELECT BookID, Title, Author, ISBN, Copies FROM dbo.Books", conn)
                Dim builder As New SqlCommandBuilder(adapter) ' BulkUpdate: حفظ كل التغييرات مرة واحدة إلى قاعدة البيانات باستخدام أوامر SQL التي يولدها SqlCommandBuilder.
                adapter.Update(ds, "Books")
            End Using
        End Sub
    End Class
End Namespace

