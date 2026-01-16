Imports Library_Management_.Library_Management.Interface

'هاذي الواجهة تستخدم الوضع  فهي تستخدم Connected Mode 
'لضمان التعامل بالكائنات (OOP) في الواجهة
'، وتعتمد على Stored Procedures في قاعدة البيانات لضمان دقة العمليات الحسابية (مثل خصم النسخ) وحماية البيانات من التضارب
Public Class frmLoans '  شاشة إدارة عمليات إعارة الكتب وإرجاعها
    Private ReadOnly _repo As ILoansRepository

    Public Sub New(repo As ILoansRepository)
        InitializeComponent()
        _repo = repo
    End Sub

    Private Sub frmLoans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshGrid()
    End Sub
    'تعود السيطرة لـ RefreshGrid() لتحديث ما يراه المستخدم
    '    جلب البيانات النشطة: تستدعي الدالة GetActiveLoans() التي تستخدم Select مع شرط ReturnDate Is NULL.
    '• تحويل الصفوف لكائنات: يتم استخدام SqlDataReader لقراءة النتائج صفاً بصف وتحويلها إلى قائمة كائنات من نوع Loan
    Private Sub RefreshGrid()
        Try
            Dim loans = _repo.GetActiveLoans()
            dgvLoans.DataSource = loans.Select(Function(l) New With {
                .رقم_الإعارة = l.LoanID,
                .رقم_العضو = l.MemberID,
                .رقم_الكتاب = l.BookID,
                .تاريخ_الإعارة = l.LoanDate,
                .تاريخ_الاستحقاق = l.DueDate,
                .تاريخ_الإرجاع = l.ReturnDate
            }).ToList()
        Catch ex As Exception
            ErrorHandler.Handle(ex)
        End Try
    End Sub

    Private Sub btnLoan_Click(sender As Object, e As EventArgs) Handles btnLoan.Click ' تجميع المدخلات واستدعاء المستودع
        Try
            Dim memberID As Integer = CInt(txtMemberID.Text)
            Dim bookID As Integer = CInt(txtBookID.Text)
            Dim dueDate As Date = dtpDueDate.Value
            _repo.LoanBook(memberID, bookID, dueDate)
            RefreshGrid()
        Catch ex As Exception
            ErrorHandler.Handle(ex)
        End Try
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Try
            Dim loanID As Integer = CInt(txtMemberID.Text)
            _repo.ReturnBook(loanID)
            RefreshGrid()
        Catch ex As Exception
            ErrorHandler.Handle(ex)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshGrid() ' عرض الإعارات الجديدة للمستخدم في الشبكة
    End Sub
End Class
