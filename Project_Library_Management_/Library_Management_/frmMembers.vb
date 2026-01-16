Imports Library_Management_.Library_Management.Interface
Imports Library_Management_.LibraryManagement.Model
Imports System.Linq

Public Class frmMembers ' شاشة إدارة أعضاء المكتبة
    Private ReadOnly _repo As IMembersRepository

    Public Sub New(repo As IMembersRepository)
        InitializeComponent()
        _repo = repo
    End Sub

    Private Sub frmMembers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshGrid()
    End Sub

    Private Sub RefreshGrid()
        Try
            Dim members = _repo.GetAll()
            dgvMembers.DataSource = members.Select(Function(m) New With {
                .رقم = m.MemberID,
                .الاسم = m.FullName,
                .الهاتف = m.Phone,
                .البريد = m.Email,
                .تاريخ_الإنشاء = m.CreatedAt
            }).ToList()
        Catch ex As Exception
            ErrorHandler.Handle(ex)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim m As New Member With {
                .FullName = txtFullName.Text,
                .Phone = txtPhone.Text,
                .Email = txtEmail.Text
            }
            MemberValidator.Validate(m)
            _repo.Add(m)
            RefreshGrid()
        Catch ex As Exception
            ErrorHandler.Handle(ex)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If dgvMembers.CurrentRow Is Nothing Then Exit Sub ' التأكد من اختيار صف
            Dim id As Integer = CInt(dgvMembers.CurrentRow.Cells("رقم").Value) '  سحب المعرف (ID) من الشبكة، وتعبئة الكائن بالبيانات الجديدة.

            Dim m As New Member With {
                .MemberID = id,
                .FullName = txtFullName.Text,
                .Phone = txtPhone.Text,
                .Email = txtEmail.Text
            }
            MemberValidator.Validate(m)
            _repo.Update(m) 'تنفيذ أمر UPDATE في قاعدة البيانات عبر المستودع 
            RefreshGrid()
        Catch ex As Exception
            ErrorHandler.Handle(ex)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If dgvMembers.CurrentRow Is Nothing Then Exit Sub
            Dim id As Integer = CInt(dgvMembers.CurrentRow.Cells("رقم").Value)
            _repo.Delete(id)
            RefreshGrid()
        Catch ex As Exception
            ErrorHandler.Handle(ex)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshGrid()
    End Sub
End Class
