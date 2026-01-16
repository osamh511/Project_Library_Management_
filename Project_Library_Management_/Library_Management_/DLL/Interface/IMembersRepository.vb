
Imports Library_Management_.LibraryManagement.Model

Namespace Library_Management.Interface

    Public Interface IMembersRepository
        Sub Add(member As Member)
        Sub Update(member As Member)
        Sub Delete(memberID As Integer)
        Function GetAll() As List(Of Member)
    End Interface

End Namespace

