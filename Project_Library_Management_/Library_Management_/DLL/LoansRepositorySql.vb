Imports Library_Management_.Library_Management.Interface
Imports Library_Management_.Library_Management.Model
Imports Microsoft.Data.SqlClient
Namespace Library_Management.DLL
    Public Class LoansRepositorySql ' للتعامل مع بيانات الأعضاء والإعارات في قاعدة البيانات
        Inherits RepositoryBase
        Implements ILoansRepository
        ' تقوم هذه الدالة بجلب الإعارات التي لم تُرجع بعد (ReturnDate IS NULL)
        'تستخدم الدالة أسلوب "إعادة الإحياء" (Object Mapping)؛ حيث تحول الصفوف القادمة من SQL إلى قائمة كائنات من نوع Loan
        Public Sub LoanBook(memberID As Integer, bookID As Integer, dueDate As Date) Implements ILoansRepository.LoanBook
            Using conn As New SqlConnection(ConnString)
                Using cmd As New SqlCommand("sp_LoanBook", conn) ' تنفيذ الإجراء المخزن وفتح اتصال مباشر بالسيرف
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@MemberID", memberID)
                    cmd.Parameters.AddWithValue("@BookID", bookID)
                    cmd.Parameters.AddWithValue("@DueDate", dueDate)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub ReturnBook(loanID As Integer) Implements ILoansRepository.ReturnBook
            Using conn As New SqlConnection(ConnString)
                Using cmd As New SqlCommand("sp_ReturnBook", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@LoanID", loanID)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Function GetActiveLoans() As List(Of Loan) Implements ILoansRepository.GetActiveLoans ' سحب الإعارات النشطة ككائنات (Connected Mode)
            Dim list As New List(Of Loan)
            Using conn As New SqlConnection(ConnString)
                Using cmd As New SqlCommand("
            SELECT LoanID, MemberID, BookID, LoanDate, DueDate, ReturnDate
            FROM dbo.Loans
            WHERE ReturnDate IS NULL", conn)
                    conn.Open()
                    Using r = cmd.ExecuteReader()
                        While r.Read()
                            list.Add(New Loan With {
                                .LoanID = CInt(r("LoanID")),
                                .MemberID = CInt(r("MemberID")),
                                .BookID = CInt(r("BookID")),
                                .LoanDate = CDate(r("LoanDate")),
                                .DueDate = CDate(r("DueDate")),
                                .ReturnDate = If(IsDBNull(r("ReturnDate")), Nothing, CType(r("ReturnDate"), Date))
                            })
                        End While
                    End Using
                End Using
            End Using
            Return list
        End Function

    End Class
End Namespace

