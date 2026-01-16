Imports Library_Management_.Library_Management.Interface
Imports Library_Management_.LibraryManagement.Model
Imports Microsoft.Data.SqlClient
Namespace Library_Management.DLL
    Public Class MembersRepositorySql ' للتعامل مع بيانات الأعضاء والإعارات في قاعدة البيانات
        Inherits RepositoryBase
        Implements IMembersRepository

        Public Sub Add(member As Member) Implements IMembersRepository.Add
            MemberValidator.Validate(member)
            Using conn As New SqlConnection(ConnString)
                Using cmd As New SqlCommand("INSERT INTO dbo.Members (FullName, Phone, Email) VALUES (@FullName, @Phone, @Email)", conn)
                    cmd.Parameters.AddWithValue("@FullName", member.FullName)
                    cmd.Parameters.AddWithValue("@Phone", If(String.IsNullOrWhiteSpace(member.Phone), CType(DBNull.Value, Object), member.Phone))
                    cmd.Parameters.AddWithValue("@Email", If(String.IsNullOrWhiteSpace(member.Email), CType(DBNull.Value, Object), member.Email))
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub Update(member As Member) Implements IMembersRepository.Update
            MemberValidator.Validate(member)
            Using conn As New SqlConnection(ConnString)
                Using cmd As New SqlCommand("UPDATE dbo.Members SET FullName=@FullName, Phone=@Phone, Email=@Email WHERE MemberID=@MemberID", conn)
                    cmd.Parameters.AddWithValue("@MemberID", member.MemberID)
                    cmd.Parameters.AddWithValue("@FullName", member.FullName)
                    cmd.Parameters.AddWithValue("@Phone", If(String.IsNullOrWhiteSpace(member.Phone), CType(DBNull.Value, Object), member.Phone))
                    cmd.Parameters.AddWithValue("@Email", If(String.IsNullOrWhiteSpace(member.Email), CType(DBNull.Value, Object), member.Email))
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub Delete(memberID As Integer) Implements IMembersRepository.Delete
            Using conn As New SqlConnection(ConnString)
                Using cmd As New SqlCommand("DELETE FROM dbo.Members WHERE MemberID=@MemberID", conn)
                    cmd.Parameters.AddWithValue("@MemberID", memberID)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Function GetAll() As List(Of Member) Implements IMembersRepository.GetAll
            Dim list As New List(Of Member)
            Using conn As New SqlConnection(ConnString)
                Using cmd As New SqlCommand("SELECT MemberID, FullName, Phone, Email, CreatedAt FROM dbo.Members", conn)
                    conn.Open()
                    Using r = cmd.ExecuteReader()
                        While r.Read()
                            list.Add(New Member With {
                                .MemberID = CInt(r("MemberID")),
                                .FullName = r("FullName").ToString(),
                                .Phone = If(TryCast(r("Phone"), String), Nothing),
                                .Email = If(TryCast(r("Email"), String), Nothing),
                                .CreatedAt = CDate(r("CreatedAt"))
                            })
                        End While
                    End Using
                End Using
            End Using
            Return list
        End Function
    End Class
End Namespace

