'Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail
Imports System.Math
Public Class Operations2
    'Dim myConn As New ConnPool2
    Dim mystr As New StringArrayConverter
    Dim tempTimeNow, emailaddress As String
    Dim timeNow As Date
    Dim mail As New MailMessage()
    Dim i, j, count, page, status As Integer
    'Dim arrContact(10000000) As String
    Dim arrContact() As String
    Dim myString As New StringArrayConverter
    Dim state As String

    Public Function Query(ByVal sql As String) As SqlDataReader
        Dim myconn As New ConnPool2
        Dim command1 As SqlCommand = New SqlCommand(sql, myconn.getConnection())
        command1.CommandType = CommandType.Text

        command1.Connection.Open()
        Return command1.ExecuteReader(CommandBehavior.CloseConnection)
        myconn = Nothing
    End Function

    Public Function ValidateCredit(ByVal credit As String) As SqlDataReader
        Dim sql As String
        sql = "Select * from ACCESS_CODES where credit ='" & credit & "'"
        Dim myconn As New ConnPool2
        Dim command1 As SqlCommand = New SqlCommand(sql, myconn.getConnection())
        command1.CommandType = CommandType.Text

        command1.Connection.Open()
        Return command1.ExecuteReader(CommandBehavior.CloseConnection)
        myconn = Nothing
    End Function


    Public Function loadQuestion2(ByVal qn As String) As SqlDataReader
        Dim sql As String
        sql = "Select Course_Title,Question,Option_A,Option_B,Option_C,Option_D,Answer,Q_Image from QnA where Question_Number='" & qn & "' and status=0"
        Dim myconn As New ConnPool2
        Dim command1 As SqlCommand = New SqlCommand(sql, myconn.getConnection())
        command1.CommandType = CommandType.Text

        command1.Connection.Open()
        Return command1.ExecuteReader(CommandBehavior.CloseConnection)
        myconn = Nothing
    End Function

    Public Function SavePersonal(ByVal fname As String, ByVal Sname As String, ByVal sex As String, ByVal mobile As String, ByVal email As String, ByVal password As String, ByVal accountType As String, ByVal accountID As String, ByVal privilege As String) As Boolean
        Dim sql As String
        Dim status As Integer = 0

        sql = "INSERT INTO USERS(First_Name,Surname,Sex,Mobile,Email,Password,Account_Type,Account_ID,privilege,status) values('" & fname & "','" & Sname & "','" & sex & "','" & mobile & "','" & email & "','" & password & "','" & accountType & "','" & accountID & "','" & privilege & "','" & status & "')"
        'Try
        ' Get All Customers ID
        Dim reader As SqlDataReader = Me.Query(sql)
        reader.Close()
        'Catch ex As Exception
        '    Return False
        '    Exit Function
        'End Try
        Return True
    End Function


    Public Function SavePersonal2(ByVal fname As String, ByVal Sname As String, ByVal sex As String, ByVal mobile As String, ByVal email As String, ByVal password As String, ByVal accountType As String, ByVal accountID As String, ByVal privilege As String, ByVal state As String) As Boolean
        Dim sql As String
        Dim status As Integer = 0

        sql = "INSERT INTO USERS(First_Name,Surname,Sex,Mobile,Email,Password,Account_Type,Account_ID,privilege,status,state) values('" & fname & "','" & Sname & "','" & sex & "','" & mobile & "','" & email & "','" & password & "','" & accountType & "','" & accountID & "','" & privilege & "','" & status & "','" & state & "')"
        'Try
        ' Get All Customers ID
        Dim reader As SqlDataReader = Me.Query(sql)
        reader.Close()
        'Catch ex As Exception
        '    Return False
        '    Exit Function
        'End Try
        Return True
    End Function
    Public Function SaveCorporate(ByVal Company As String, ByVal Address As String, ByVal reg As String, ByVal fname As String, ByVal Sname As String, ByVal sex As String, ByVal mobile As String, ByVal email As String, ByVal password As String, ByVal accountType As String, ByVal accountID As String, ByVal privilege As String, ByVal state As String) As Boolean
        Dim sql As String
        Dim status As Integer = 0

        sql = "INSERT INTO USERS(Company_Name, Address,Company_RC,First_Name,Surname,Sex,Mobile,Email,Password,Account_Type,Account_ID,privilege,status,State) values('" & Company & "','" & Address & "','" & reg & "','" & fname & "','" & Sname & "','" & sex & "','" & mobile & "','" & email & "','" & password & "','" & accountType & "','" & accountID & "','" & privilege & "','" & status & "','" & state & "')"
        Try
            ' Get All Customers ID
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Return True
    End Function

    Public Function CountPersonal(ByVal acType As String) As Integer
        Dim sql As String
        Dim id As Integer
        sql = "Select count(id) as 'count' from users where account_Type='" & acType & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then
                id = reader("count")
                reader.Close()
                Return id
            Else
                reader.Close()
                Return 0
            End If

        Catch ex As Exception
            Return 0
        End Try
    End Function


    Public Function CountSub(ByVal acctID As String) As Integer
        Dim sql As String
        Dim id As Integer
        sql = "Select count(id) as 'count' from users where account_ID like'" & acctID & "%'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then
                id = reader("count")
                reader.Close()
                Return id
            Else
                reader.Close()
                Return 0
            End If

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function validateExistence(ByVal mobile As String, ByVal email As String) As Integer
        Dim sql As String
        Dim id As Integer
        sql = "Select count(*) as 'count' from users where mobile='" & mobile & "' or email ='" & email & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then
                id = reader("count")
                reader.Close()
                Return id
            Else
                reader.Close()
                Return 0
            End If

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function validateExistenceByType(ByVal mobile As String, ByVal email As String, ByVal acctType As String) As Integer
        Dim sql As String
        Dim id As Integer
        sql = "Select count(*) as 'count' from users where (mobile='" & mobile & "' or email ='" & email & "') and account_Type='" & acctType & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then
                id = reader("count")
                reader.Close()
                Return id
            Else
                reader.Close()
                Return 0
            End If

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function validateLogin(ByVal uName As String, ByVal pass As String) As String
        Dim sql, status As String
        'Dim id As Integer
        sql = "Select status from users where (mobile='" & uName & "' or email ='" & uName & "')" & " and password='" & pass & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then
                status = reader("status")
                reader.Close()
                Return status
            Else
                reader.Close()
                Return "None"
            End If

        Catch ex As Exception
            Return "None2"
        End Try
    End Function


    Public Function validateUser(ByVal uName As String) As String
        Dim sql, status As String
        'Dim id As Integer
        sql = "Select mobile from users where (mobile='" & uName & "' or email ='" & uName & "')"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then
                status = reader("mobile")
                reader.Close()
                Return status
            Else
                reader.Close()
                Return "None"
            End If

        Catch ex As Exception
            Return "None2"
        End Try
    End Function

    Public Function loadUser(ByVal uName As String) As String
        Dim sql, details, fname, sname, email, mobile, acctID, acctType, privilege As String
        'Dim id As Integer
        sql = "Select First_Name,Surname,mobile,Email,Account_ID,account_Type,privilege from users where mobile='" & uName & "' or email ='" & uName & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then
                fname = reader("First_Name")
                sname = reader("Surname")
                mobile = reader("mobile")
                email = reader("email")
                acctID = reader("account_ID")
                acctType = reader("Account_Type")
                privilege = reader("Privilege")
                'company = reader("Company_Name")
                'address = reader("Address")
                'companyRc = reader("Company_RC")


                details = fname & "," & sname & "," & mobile & "," & email & "," & acctID & "," & acctType & "," & privilege
                reader.Close()
                Return details
            Else
                reader.Close()
                Return "None"
            End If

        Catch ex As Exception
            Return "None2"
        End Try
    End Function

    Public Function loadCoyInfo(ByVal uName As String) As String
        Dim sql, details, company, RC As String
        'Dim id As Integer
        sql = "Select Company_Name,Company_RC from users where mobile='" & uName & "' or email ='" & uName & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then

                company = reader("Company_Name")
                'Address = reader("Address")
                RC = reader("Company_RC")

                details = company & "," & RC
                reader.Close()
                Return details
            Else
                reader.Close()
                Return "None"
            End If

        Catch ex As Exception
            Return "None2"
        End Try
    End Function

    Public Function loadCoyAddress(ByVal uName As String) As String
        Dim sql, address As String
        'Dim id As Integer
        sql = "Select Address from users where mobile='" & uName & "' or email ='" & uName & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then

                address = reader("Address")
                reader.Close()
                Return address
            Else
                reader.Close()
                Return "None"
            End If

        Catch ex As Exception
            Return "None2"
        End Try
    End Function

    Public Function UpdatePersonal(ByVal fname As String, ByVal sname As String, ByVal mobile As String, ByVal email As String, ByVal acctID As String) As Boolean
        Dim sql As String
        Dim status As Integer = 0

        sql = "UPDATE USERS set First_Name='" & fname & "', Surname='" & sname & "', mobile='" & mobile & "',Email='" & email & "' WHERE account_ID='" & acctID & "'"
        Try
            ' Get All Customers ID
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Return True
    End Function

    Public Function UpdateCorporate(ByVal fname As String, ByVal sname As String, ByVal mobile As String, ByVal email As String, ByVal acctID As String, ByVal company As String, ByVal address As String, ByVal rc As String) As Boolean
        Dim sql As String
        Dim status As Integer = 0

        sql = "UPDATE USERS set First_Name='" & fname & "', Surname='" & sname & "', mobile='" & mobile & "',Email='" & email & "', Company_Name='" & company & "',Address='" & address & "', Company_RC='" & rc & "' WHERE account_ID='" & acctID & "'"
        Try
            ' Get All Customers ID
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Return True
    End Function


    Public Function changePass(ByVal pass As String, ByVal acctID As String) As Boolean
        Dim sql As String
        Dim status As Integer = 0

        sql = "UPDATE USERS set password='" & pass & "' WHERE account_ID='" & acctID & "'"
        Try
            ' Get All Customers ID
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Return True
    End Function

    Public Function resetPass(ByVal pass As String, ByVal mobile As String) As Boolean
        Dim sql As String
        Dim status As Integer = 0

        sql = "UPDATE USERS set password='" & pass & "' WHERE mobile='" & mobile & "'"
        Try
            ' Get All Customers ID
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Return True
    End Function

    Public Function CountQuestion(ByVal mDule As String) As Integer
        Dim sql As String
        Dim id As Integer
        sql = "Select count(id) as 'count' from QnA where Module ='" & mDule & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then
                id = reader("count")
                reader.Close()
                Return id
            Else
                reader.Close()
                Return 0
            End If

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function SaveQuestion(ByVal mDule As String, ByVal Ctitle As String, ByVal QN As String, ByVal Question As String, ByVal A As String, ByVal B As String, ByVal C As String, ByVal D As String, ByVal ans As String, ByVal img As String) As Boolean
        Dim sql As String
        Dim status As Integer = 0

        sql = "INSERT INTO QnA(Module,Course_Title,Question_Number,Question,Option_A,Option_B,Option_C,Option_D,answer,Q_Image,status) values('" & mDule & "','" & Ctitle & "','" & QN & "','" & Question & "','" & A & "','" & B & "','" & C & "','" & D & "','" & ans & "','" & img & "'," & status & ")"
        Try
            ' Get All Customers ID
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Return True
    End Function


    Public Function dynDelete(ByVal iTable As String, ByVal ifield As String, ByVal iparam As String) As Boolean
        Dim sql As String

        sql = "DELETE FROM " & iTable & " Where " & ifield & " ='" & iparam & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function dynDeleteNoparam(ByVal iTable As String) As String
        Dim sql As String
        sql = "DELETE FROM " & iTable
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function dynDelete_2param(ByVal iTable As String, ByVal ifield As String, ByVal iparam As String, ByVal ifield2 As String, ByVal iparam2 As String) As Boolean
        Dim sql As String

        sql = "DELETE FROM " & iTable & " Where " & ifield & " ='" & iparam & "' AND " & ifield2 & " = '" & iparam2 & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function dynGet1(ByVal iTable As String, ByVal ifieldSelect As String, ByVal ifieldparam As String, ByVal iparam As String) As String
        Dim sql, result As String

        sql = "SELECT " & ifieldSelect & " FROM " & iTable & " Where " & ifieldparam & " ='" & iparam & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then
                result = reader(ifieldSelect)
            Else
                result = "None"
            End If
            reader.Close()
            Return result
        Catch ex As Exception
            Return "None"
        End Try
    End Function

    Public Function dynGet1_2param(ByVal iTable As String, ByVal ifieldSelect As String, ByVal ifieldparam As String, ByVal iparam As String, ByVal ifieldparam2 As String, ByVal iparam2 As String) As String
        Dim sql, result As String

        sql = "SELECT " & ifieldSelect & " FROM " & iTable & " Where " & ifieldparam & " ='" & iparam & "' AND " & ifieldparam2 & " ='" & iparam2 & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then
                result = reader(ifieldSelect)
            Else
                result = "None"
            End If
            reader.Close()
            Return result
        Catch ex As Exception
            Return "None"
        End Try
    End Function

    Public Function dynGet1noParam(ByVal iTable As String, ByVal ifieldSelect As String) As String
        Dim sql, result As String

        sql = "SELECT " & ifieldSelect & " FROM " & iTable
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then
                result = reader(ifieldSelect)
            Else
                result = "None"
            End If
            reader.Close()
            Return result
        Catch ex As Exception
            Return "None"
        End Try
    End Function

    Public Function dynGetMax(ByVal iTable As String, ByVal ifieldSelect As String) As Integer
        Dim sql As String
        Dim result As Integer
        sql = "SELECT Max(" & ifieldSelect & ") as 'Max' FROM " & iTable
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then
                result = reader("Max")
            Else
                result = 0
            End If
            reader.Close()
            Return result
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function dynUpdate1(ByVal iTable As String, ByVal ifieldUpdate As String, ByVal ifieldparam As String, ByVal iparam As String, ByVal value As String) As Boolean
        Dim sql As String

        sql = "UPDATE " & iTable & " SET " & ifieldUpdate & " ='" & value & "' WHERE " & ifieldparam & " ='" & iparam & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function dynUpdate1_2param(ByVal iTable As String, ByVal ifieldUpdate As String, ByVal ifieldparam As String, ByVal iparam As String, ByVal ifieldparam2 As String, ByVal iparam2 As String, ByVal value As String) As Boolean
        Dim sql As String

        sql = "UPDATE " & iTable & " SET " & ifieldUpdate & " ='" & value & "' WHERE " & ifieldparam & " ='" & iparam & "' AND " & ifieldparam2 & " ='" & iparam2 & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function loadQuestion(ByVal qn As String) As String
        Dim sql, details, cTitle, Question, A, B, C, D, img, ans As String
        'Dim id As Integer
        sql = "Select Course_Title,Question,Option_A,Option_B,Option_C,Option_D,Answer,Q_Image from QnA where Question_Number='" & qn & "' and status=0"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then
                cTitle = reader("Course_Title")
                Question = reader("Question")
                A = reader("Option_A")
                B = reader("option_B")
                C = reader("option_c")
                D = reader("option_d")
                ans = reader("Answer")
                img = reader("Q_Image")

                details = cTitle & "," & Question & "," & A & "," & B & "," & C & "," & D & "," & ans & "," & img
                reader.Close()
                Return details
            Else
                reader.Close()
                Return "None"
            End If

        Catch ex As Exception
            Return "None2"
        End Try
    End Function



    Public Function loadQN(ByVal mdule As String) As String
        Dim sql, details, QN As String
        'Dim id As Integer
        sql = "Select Question_Number from QnA where Module='" & mdule & "' and status=0"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            While reader.Read
                QN = reader("Question_Number")

                details = details & QN & ","


            End While
            reader.Close()
            Return details
        Catch ex As Exception
            'reader.Close()
            Return "None"
        End Try
    End Function

    Public Function SaveResult(ByVal mdule As String, ByVal Score As String, ByVal fname As String, ByVal Sname As String, ByVal acctID As String, ByVal status As String, ByVal timeSpent As String) As Boolean
        Dim sql As String


        sql = "INSERT INTO RESULTS(module,Score,First_Name,Surname,Account_ID,Status,time_Spent) values('" & mdule & "','" & Score & "','" & fname & "','" & Sname & "','" & acctID & "','" & status & "','" & timeSpent & "')"
        'Try

        Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
        'Catch ex As Exception
        '    Return False
        '    Exit Function
        'End Try
        Return True
    End Function


    'VALIDATE SEARCH INPUT
    Function ValidateSearchInput(ByVal msg As String) As String
        count = msg.Length
        Dim newMsg As String
        For i = 0 To count - 1
            If msg(i) = "'" Then
                If i > 1 Then
                    For j = 0 To i - 1
                        newMsg = newMsg & msg(j).ToString
                    Next
                    Return newMsg
                    Exit Function
                Else
                    newMsg = ""
                    Return newMsg
                    Exit Function
                End If
            End If
        Next
        Return msg
        Exit Function
    End Function


    Public Function LoadCredit(ByVal Credit As String, ByVal acctID As String, ByVal mdule As String) As Boolean
        Dim sql As String
        sql = "update ACCESS_CODES set used_Date=GetDate(), Status = 1,Used_By='" & acctID & "' , used_for='" & mdule & "' where credit='" & Credit & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function CountQuery(ByVal sql As String) As Integer
        Dim maxi As Integer
        Try

            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then
                maxi = reader("Count")
            Else
                maxi = 0
            End If
            reader.Close()
        Catch ex As Exception
            Return False
        End Try
        Return maxi
    End Function

    Public Function SaveHack(ByVal name As String, ByVal desc As String) As Boolean
        Dim sql As String


        sql = "INSERT INTO FRAUD_ALERT(name,description) values('" & name & "','" & desc & "')"
        Try

            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Return True
    End Function


    Public Function loadQuestionbyID(ByVal id As String) As SqlDataReader
        Dim sql As String
        sql = "Select Question_Number,Course_Title,Question,Option_A,Option_B,Option_C,Option_D,Answer,Q_Image from QnA where id='" & id & "' and status=0"
        Dim myconn As New ConnPool2
        Dim command1 As SqlCommand = New SqlCommand(sql, myconn.getConnection())
        command1.CommandType = CommandType.Text

        command1.Connection.Open()
        Return command1.ExecuteReader(CommandBehavior.CloseConnection)
        myconn = Nothing
    End Function

    Public Function UpdateQuestion(ByVal qes As String, ByVal ans As String, ByVal A As String, ByVal b As String, ByVal c As String, ByVal d As String, ByVal id As String) As Boolean
        Dim sql As String
        sql = "update QnA set Question='" & qes & "', Answer='" & ans & "', Option_A='" & A & "', Option_B='" & b & "', Option_C='" & c & "', Option_D='" & d & "' WHERE ID='" & id & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdatePicLink(ByVal img As String, ByVal id As String) As Boolean
        Dim sql As String
        sql = "update QnA set Q_Image='" & img & "' WHERE ID='" & id & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function loadStates() As String
        Dim sql, tempState, details As String
        'Dim id As Integer
        sql = "Select State from STATES"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            While reader.Read
                tempState = reader("State")

                details = details & tempState & ","


            End While
            reader.Close()
            Return details
        Catch ex As Exception
            'reader.Close()
            Return "None"
        End Try
    End Function

    Public Function Contactus(ByVal fname As String, ByVal surname As String, ByVal mobile As String, ByVal Email As String, ByVal msg As String) As Boolean
        Dim sql As String

        Dim status As String = "0"
        sql = "INSERT INTO CONTACTUS(first_Name,Surname,Mobile,Email,Message,status) values('" & fname & "','" & surname & "','" & mobile & "','" & Email & "','" & msg & "','" & status & "')"
        Try

            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Return True
    End Function

    'Public Function SendEmail(ByVal recipient As String, ByVal subject As String, ByVal Message As String, ByVal cc As String) As Boolean
    '    'Try
    '    'mail.From = New MailAddress("mypasms@gmail.com")
    '    mail.From = New MailAddress("seye@photizotechnologies.com")
    '    mail.To.Add(recipient)
    '    mail.Bcc.Add(cc)

    '    'set the content
    '    mail.Subject = subject
    '    mail.Body = Message

    '    mail.IsBodyHtml = True

    '    'Port 587 is another SMTP port
    '    Dim smtp As New SmtpClient("smtp.gmail.com", 25)
    '    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
    '    smtp.Credentials = New System.Net.NetworkCredential("seye@photizotechnologies.com", "anthos.pass")
    '    smtp.EnableSsl = False
    '    smtp.Send(mail)
    '    Return True
    '    'Catch ex2 As Exception
    '    '   Return False
    '    'End Try

    '    'End Try
    'End Function



    Public Function SendEmail(ByVal recipient As String, ByVal subject As String, ByVal Message As String, ByVal cc As String) As Boolean
        'Try
        'mail.From = New MailAddress("mypasms@gmail.com")
        mail.From = New MailAddress("bizconnect@photizotechnologies.com")
            mail.To.Add(recipient)
            mail.Bcc.Add(cc)

            'set the content
            mail.Subject = subject
            mail.Body = Message

            mail.IsBodyHtml = True

            'Port 587 is another SMTP port
            Dim smtp As New SmtpClient("smtp.gmail.com", 25)
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network
            smtp.Credentials = New System.Net.NetworkCredential("bizconnect@photizotechnologies.com", "passw0rd@bizconnect")
            smtp.EnableSsl = True
            smtp.Send(mail)
            Return True
            'Catch ex2 As Exception
        '   Return False
        'End Try
    End Function
    Public Function UpdateCountCredit(ByVal credit As String) As Boolean
        Dim sql As String
        sql = "update ACCESS_CODES set used_count= used_count + 1 Where credit='" & credit & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateRemoveCreditCount(ByVal credit As String) As Boolean
        Dim sql As String
        sql = "update ACCESS_CODES set used_count= used_count - 1 Where credit='" & credit & "'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function PreloadQuestions(ByVal mdule As String) As SqlDataReader
        Dim sql As String
        sql = "Select Question_Number,Course_Title,Question,Option_A,Option_B,Option_C,Option_D,Answer,Q_Image from QnA where module='" & mdule & "'"
        Dim myconn As New ConnPool2
        Dim command1 As SqlCommand = New SqlCommand(sql, myconn.getConnection())
        command1.CommandType = CommandType.Text

        command1.Connection.Open()
        Return command1.ExecuteReader(CommandBehavior.CloseConnection)
        myconn = Nothing
    End Function

    Public Function loadOtherImages(ByVal mdule As String) As String
        Dim sql, details, QN As String
        'Dim id As Integer
        sql = "Select Q_Image from QnA where Module='" & mdule & "' and status=0"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            While reader.Read
                QN = reader("Q_Image")

                details = details & QN & ","

            End While
            reader.Close()
            Return details
        Catch ex As Exception
            'reader.Close()
            Return "None"
        End Try
    End Function

    Public Function SaveCredit(ByVal serial As String, ByVal codes As String) As Boolean
        Dim sql As String
        Dim status As String = "0"
        sql = "INSERT INTO ACCESS_CODES(Serial,Credit,Used_Count,status) values('" & serial & "','" & codes & "','" & status & "','" & status & "')" ' & msg & "','" & status & "')"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Return True
    End Function


    Public Function CountPayment() As Integer
        Dim sql As String
        Dim id As Integer
        sql = "Select count(id) as 'count' from PAYMENTS"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            If reader.Read Then
                id = reader("count")
                reader.Close()
                Return id
            Else
                reader.Close()
                Return 0
            End If

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function SavePaymentTr(ByVal ref As String, ByVal email As String, ByVal mobile As String, ByVal amount As Double, ByVal status As String, ByVal credit As String, ByVal acctID As String, ByVal payStatus As String) As Boolean
        Dim sql As String

        sql = "INSERT INTO PAYMENTS(ref,Email,mobile,amount,txn_status,credit,account_ID,payment_Status) values('" & ref & "','" & email & "','" & mobile & "'," & amount & ",'" & status & "','" & credit & "','" & acctID & "','" & payStatus & "')"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Return True
    End Function

    Public Function SaveGenPIN(ByVal serial As String, ByVal credit As String, ByVal status As String, ByVal usedCount As Integer) As Boolean
        Dim sql As String

        sql = "INSERT INTO ACCESS_CODES(serial,credit,status,used_count) values('" & serial & "','" & credit & "','" & status & "'," & usedCount & ")"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Return True
    End Function

    Public Function dynDeleteLike(ByVal iTable As String, ByVal ifield As String, ByVal iparam As String) As Boolean
        Dim sql As String

        sql = "DELETE FROM " & iTable & " Where " & ifield & " like'%" & iparam & "%'"
        Try
            Dim reader As SqlDataReader = Me.Query(sql)
            reader.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
