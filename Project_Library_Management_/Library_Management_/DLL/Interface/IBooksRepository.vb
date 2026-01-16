Imports Library_Management_.Library_Management.Model

Namespace Library_Management.Interface
    Public Interface IBooksRepository
        Sub Add(book As Book)
        Sub Update(book As Book)
        Sub Delete(bookID As Integer)
        ' أضف هذه الدوال

        ''' <summary>
        ''' Function GetAllDataSet() As DataSet
        '''هذه نسخة أخرى من GetAll لكنها ترجع DataSet بدلًا من قائمة كائنات.
        '''الـ DataSet هو بنية بيانات قديمة في .NET تُستخدم مع Disconnected Mode (يعني العمل مع البيانات بدون اتصال مباشر بقاعدة البيانات).
        '''فائدتها: تسمح لك بتحميل جدول كامل من قاعدة البيانات إلى الذاكرة، ثم التعامل معه كـ DataTable.
        '''هذا مفيد إذا أردت تعديل البيانات بشكل جماعي أو ربطها مباشرة بـ DataGridView بدون تحويلها إلى كائنات.
        ''' </summary>
        ''' <returns></returns>
        Function GetAllDataSet() As DataSet ' تستخدم لالعمل مع البيانات بدون اتصال مباشر بقاعدة البيانات بحيث تسمح لنا ببتحميل جدول كامل من قاعدة البيانات إلى الذاكرة، ثم التعامل معه كـ DataTable
        ''' <summary>
        ''' Sub BulkUpdate(ds As DataSet)
        '''تستخدم مع GetAllDataSet.
        '''بعد أن يقوم المستخدم بتعديل البيانات داخل الـ DataGridView (المربوطة بالـ DataSet)، يمكنه حفظ كل التغييرات مرة واحدة إلى قاعدة البيانات.
        '''هذه الطريقة تعتمد على SqlDataAdapter + SqlCommandBuilder لتوليد أوامر SQL (INSERT, UPDATE, DELETE) تلقائيًا وتنفيذها دفعة واحدة.
        '''فائدتها: تحديث جماعي للبيانات بدلًا من استدعاء دوال الإضافة/التعديل/الحذف لكل سجل على حدة.
        ''' </summary>
        ''' <param name="ds"></param>
        Sub BulkUpdate(ds As DataSet)
        ''' <summary>
        ''' شرح كل دالة
        '''1. Function GetAll() As List(Of Book)
        '''ترجع قائمة(List) من الكائنات Book.
        '''كل عنصر يمثل كتاب واحد من قاعدة البيانات.
        '''هذه الطريقة هي الأكثر شيوعًا لأنها تعطيك كائنات strongly-typed (يعني كل كتاب له خصائص واضحة: BookID, Title, Author...).
        '''تستخدم عادة لعرض البيانات في الـ DataGridView أو التعامل البرمجي مع الكتب
        ''' </summary>
        ''' <returns></returns>
        Function GetAll() As List(Of Book) '       +   ترجع قائمة بحيث كل عنصر يمثل كتاب واحد من قاعدة البيانات. (List) من الكائنات Book.
        ''' <summary>
        ''' 2. Function SearchByTitle(keyword As String) As List(Of Book)
        '''تبحث في قاعدة البيانات عن الكتب التي تحتوي عناوين مشابهة للكلمة المدخلة.
        '''ترجع أيضًا قائمة من الكائنات Book.
        '''فائدتها: تصفية البيانات بدلًا من جلب كل الكتب.
        '''مثال عملي: المستخدم يكتب "C#" → الدالة ترجع كل الكتب التي عنوانها يحتوي "C#".
        ''' </summary>
        ''' <param name="keyword"> تخزين بيانات المصفة</param>
        ''' <returns></returns>
        Function SearchByTitle(keyword As String) As List(Of Book) ' تبحث في قاعدة البيانات عن الكتب التي تحتوي عناوين مشابهة للكلمة المدخلة  +  فائدتها: تصفية البيانات بدلًا من جلب كل الكتب.
    End Interface

End Namespace

