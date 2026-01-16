Imports Library_Management_.Library_Management.Model

Namespace Library_Management.Interface
    Public Interface ILoansRepository
        Sub LoanBook(memberID As Integer, bookID As Integer, dueDate As Date) 'تفعيل "العقد" المبرم بين الطبقات
        Sub ReturnBook(loanID As Integer)
        Function GetActiveLoans() As List(Of Loan)
    End Interface

End Namespace

