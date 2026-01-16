Imports System.Linq
Imports Library_Management_.Library_Management.BLL
Imports Library_Management_.Library_Management.DLL
Imports Library_Management_.Library_Management.Interface
Imports Library_Management_.Library_Management.Model

Public Class frmBooks ' شاشة إدارة الكتب (إضافة، تعديل، حذف، بحث، وعرض في الجدول)
    Private ReadOnly _repo As IBooksRepository

    Public Sub New(repo As IBooksRepository)
        InitializeComponent()
        _repo = repo
    End Sub

    Private Sub frmBooks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshGrid()
    End Sub
    ''' <summary>
    ''' هي بالفعل تستخدم Connected Mode، والسبب هو أنها تستدعي الدالة GetAll() من المستودع BooksRepositorySql، والتي ترجع قائمة من الكائنات List(Of Book).
    '''    كيف ترتبط هذه الدالة بالعمليات الدقيقة؟
    '''بعد تنفيذ عملية مثل إضافة كتاب جديد (btnAdd_Click) أو تعديل كتاب (btnUpdate_Click) أو حذف كتاب (btnDelete_Click)، يتم استدعاء RefreshGrid() لتحديث البيانات المعروضة.
    '''هذا يعني أن كل عملية دقيقة (Add, Update, Delete) تعتمد على الكائنات Book وتتم عبر اتصال مباشر بقاعدة البيانات.
    '''ثم يتم عرض النتيجة في DataGridView باستخدام List(Of Book) وليس DataSet.
    ''' </summary>
    Private Sub RefreshGrid() ' تتبع الكود في RefreshGrid
        Try
            Dim books = _repo.GetAll() ' يتم استلام القائمة: Dim books = _repo.GetAll()
            'الفائدة:
            'هنا منطق الأعمال يقرر "ماذا" يظهر للمستخدم و"كيف" يظهر، دون التأثير على البيانات الأصلية في الكائن
            ' بحيث هاذى يعتبر افضل عند  استخدام  Connected Mode؟

            'مـــلاحظة مهمة
            'Linq والدوال المخصصة هي التي تصفّي البيانات وتختار ما يظهر منها للخروج للمستخدم 
            dgvBooks.DataSource = books.Select(Function(b) New With {
                .رقم = b.BookID,
                .العنوان = b.Title,
                .المؤلف = b.Author,
                .ISBN = b.ISBN,
                .النسخ = b.Copies
            }).ToList()
        Catch ex As Exception
            ErrorHandler.Handle(ex)
        End Try

    End Sub
    ''' <summary>
    '''  
    ''' تجميع البيانات في كائن: بدلاً من إرسال "نصوص" للمستودع، نقوم بإنشاء "كائن طالب" كامل:
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'هنا يأتي دور "منطق الأعمال" الحقيقي؛
        'حيث لا يتم إرسال البيانات إلى قاعدة البيانات إلا بعد التأكد من مطابقتها للقوانين البرمجية
        Try
            Dim b As New Book With {
                .Title = txtTitle.Text,
                .Author = txtAuthor.Text,
                .ISBN = txtISBN.Text,
                .Copies = CInt(txtCopies.Text)
            }
            BookValidator.Validate(b) '  استدعاء منطق التحقق:
            'بدلاً من إرسال "العنوان" و"المؤلف" كمتغيرات منفصلة، نرسل الكائن: _repo.Add(b).
            '•  بحيث  داخل المستودع: يتم تفكيك خصائص هذا الكائن لتحويلها إلى بارامترات SQL
            _repo.Add(b)

            RefreshGrid()
        Catch ex As Exception
            ErrorHandler.Handle(ex)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim b As New Book With {
                .BookID = CInt(txtBookID.Text),
                .Title = txtTitle.Text,
                .Author = txtAuthor.Text,
                .ISBN = txtISBN.Text,
                .Copies = CInt(txtCopies.Text)
            }
            BookValidator.Validate(b)
            _repo.Update(b)
            RefreshGrid()
        Catch ex As Exception
            ErrorHandler.Handle(ex)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim id As Integer = CInt(txtBookID.Text)
            _repo.Delete(id)
            RefreshGrid()
        Catch ex As Exception
            ErrorHandler.Handle(ex)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim list = _repo.SearchByTitle(txtSearch.Text)
            dgvBooks.DataSource = list.Select(Function(b) New With {
                .رقم = b.BookID,
                .العنوان = b.Title,
                .المؤلف = b.Author,
                .ISBN = b.ISBN,
                .النسخ = b.Copies
            }).ToList()
        Catch ex As Exception
            ErrorHandler.Handle(ex)
        End Try
    End Sub
    ''' <summary>
    ''' هنا يتم استدعاء GetAllDataSet() من المستودع (BooksRepositorySql).
    '''الدالة ترجع DataSet يحتوي جدول "Books".
    '''يتم ربط الجدول مباشرة بـ DataGridView.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ' مثال Disconnected Mode
    Private Sub btnLoadDataSet_Click(sender As Object, e As EventArgs) Handles btnLoadDataSet.Click
        Try
            Dim ds = _repo.GetAllDataSet()
            ' يتم ربط الـ DataSet مباشرة بـ DataGridView عبر خاصية DataSource (مثل: dgvBooks.DataSource = ds.Tables("Books"))،.
            '• تكمن الفائدة هنا في الربط المباشر والسريع مع واجهة المستخدم، مما يتيح للمستخدم رؤية البيانات وتعديلها مباشرة داخل الجدول
            dgvBooks.DataSource = ds.Tables("Books")
        Catch ex As Exception
            ErrorHandler.Handle(ex)
        End Try
    End Sub

    ''' <summary>
    ''' يأخذ البيانات المعدلة من DataGridView (المربوطة بـ DataTable).
    '''يضعها داخل DataSet جديد.
    '''يستدعي BulkUpdate(ds) في المستودع.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSaveDataSet_Click(sender As Object, e As EventArgs) Handles btnSaveDataSet.Click
        Try
            Dim dt = TryCast(dgvBooks.DataSource, DataTable)
            If dt Is Nothing Then Exit Sub
            Dim ds As New DataSet()
            ds.Tables.Add(dt.Copy())
            ds.Tables(0).TableName = "Books"
            _repo.BulkUpdate(ds)
            RefreshGrid()
        Catch ex As Exception
            ErrorHandler.Handle(ex)
        End Try
    End Sub

    Private Sub btnMembers_Click(sender As Object, e As EventArgs) Handles btnMembers.Click
        Dim membersForm As New frmMembers(New MembersRepositorySql())
        membersForm.ShowDialog()
    End Sub

    Private Sub btnLoans_Click(sender As Object, e As EventArgs) Handles btnLoans.Click
        Dim loansForm As New frmLoans(New LoansRepositorySql())
        loansForm.ShowDialog()
    End Sub
End Class
