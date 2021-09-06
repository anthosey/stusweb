Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class ConnPool2
    'Dim connectionString As String = " initial catalog=anthos20_myPA_SERVER; Data Source=204.93.178.45; Connection Timeout=30; User Id=anthos20_anthos1; Password=password123; Min Pool Size=10; Max Pool Size=300;" 'Incr Pool Size=10; Decr Pool Size=5;"
    'Public connectionString As String = " initial catalog=STUS; Data Source=localhost\sql; Connection Timeout=120; Integrated Security =True;"
    Dim connectionString As String = " initial catalog=anthos20_stus; Data Source=198.38.83.200; Connection Timeout=120; User Id=anthos20_anthos; Password=@nth0s>p@ss; Min Pool Size=10; Max Pool Size=300;" 'Incr Pool Size=10; Decr Pool Size=5;"
    'Dim connectionString As String = " initial catalog=Viko_Elearning; Data Source=204.93.160.230; Connection Timeout=30; User Id=anthos; Password=anth0s.pass; Min Pool Size=10; Max Pool Size=300;" 'Incr Pool Size=10; Decr Pool Size=5;"
    'Dim connectionString As String = " initial catalog=Viko2; Data Source=204.93.160.230; Connection Timeout=30; User Id=anthos; Password=anth0s.pass; Min Pool Size=10; Max Pool Size=300;" 'Incr Pool Size=10; Decr Pool Size=5;"

    Dim connString As String = connectionString
    Dim connString2 As String = connectionString
    'Dim connString3 As String = strConnectionString
    Dim conn As New SqlConnection
    Dim conn2 As New SqlConnection
    Function getConnection() As SqlConnection
        conn.ConnectionString = connectionString
        Return conn
    End Function

    'Function getConnection2() As SqlConnection
    '    conn2.ConnectionString = strConnectionString
    '    Return conn2
    'End Function

    Public Function LoadUser(ByVal userName As String, ByVal password As String) As SqlDataReader
        Dim command1 As SqlCommand = New SqlCommand("LoadUser", getConnection())
        command1.CommandType = CommandType.StoredProcedure
        command1.Parameters.Add(New SqlParameter("@v_userName", userName))
        command1.Parameters.Add(New SqlParameter("@v_password", password))
        command1.Connection.Open()
        Return command1.ExecuteReader(CommandBehavior.CloseConnection)
    End Function

    Public Function ChangePass(ByVal userName As String, ByVal password As String) As SqlDataReader
        'Dim UserName As Integer
        Dim command1 As SqlCommand = New SqlCommand("changePass", getConnection())
        command1.CommandType = CommandType.StoredProcedure
        command1.Parameters.Add(New SqlParameter("@v_userName", userName))
        command1.Parameters.Add(New SqlParameter("@v_newPass", password))
        command1.Connection.Open()
        Return command1.ExecuteReader(CommandBehavior.CloseConnection)
    End Function

    Function getConnectionString() As String

        Return connString
    End Function

    'Function getConnectionString3() As String

    '    Return connString3
    'End Function

End Class
