Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Math

Public Class Gateway
    Dim flag As Boolean
    Dim resp, supportEmail, adminEmail, mobile, operation, details As String
    Dim dateNow, deliveryDate As Date
    Dim timeDiff, contacts, billperContact, cost, pages, i As Integer
    Dim sql, sql2, sql3, sql4, ids, msg, senders, destination As String
    Dim recipient, Message, subject, cc, supportLines, tempdata, adminPhone, ans As String
    Dim userName, password As String
    Dim flag2 As Boolean

    Function GatewayBroadcast(ByVal senders As String, ByVal destination As String, ByVal msg As String, ByVal userName As String, ByVal password As String) As String
        Dim URI As String
        Dim responseFromServer As String
        'Create a request using a URL that can receive a post.    
        Dim postdata As String
        postdata = "username=" & userName & "&password=" & password & "&appId=AP80017&message=" & HttpUtility.UrlEncode(msg) & "&sender=" & HttpUtility.UrlEncode(senders) & "&recipient=" & HttpUtility.UrlEncode(destination)
        URI = "http://www.mypasms.com/api.aspx?"
        URI = URI & postdata
        Dim request As HttpWebRequest = WebRequest.Create(URI)
        ' Set the Method property of the request to POST.   
        request.Method = "POST"

        'if you want to post variables do "var1=value1&var2=value2"   
        Dim byteArray() As Byte
        Try
            byteArray = Encoding.UTF8.GetBytes(postdata)
            ' Set the ContentType property of the WebRequest.   
            request.ContentType = "application/x-www-form-urlencoded"
            ' Set the ContentLength property of the WebRequest.   
            request.ContentLength = byteArray.Length
            'Get the request stream.   
            Dim datastream As Stream
            datastream = request.GetRequestStream()
            ' Write the data to the request stream.   
            datastream.Write(byteArray, 0, byteArray.Length)
            ' Close the Stream object.   
            datastream.Close()
            ' Get the response.   
            Dim response As WebResponse
            response = request.GetResponse
            'Display the status.   
            ' Get the stream containing content returned by the server.   
            datastream = response.GetResponseStream()
            ' Open the stream using a StreamReader for easy access.   
            Dim reader As StreamReader = New StreamReader(datastream)
            ' Read the content.   

            responseFromServer = reader.ReadToEnd
            tempdata = ""
            i = 0
            While i <= 4
                If responseFromServer(i) = "<" Then
                    Exit While
                Else
                    tempdata = tempdata & responseFromServer(i).ToString
                    i = i + 1
                End If
            End While

            responseFromServer = tempdata
            'Display the content.   
            'label1.text = responseFromServer
            Return responseFromServer
            ' Clean up the streams.   
            reader.Close()
            datastream.Close()
            response.Close()
        Catch ex As Exception
            Return "None"
            Exit Function
        End Try
    End Function

    Function GatewayBalance(ByVal userName As String, ByVal password As String) As Integer
        Dim URI As String
        Dim bal As Integer
        Dim responseFromServer As String
        'Create a request using a URL that can receive a post.    
        Dim postdata As String
        postdata = "username=" & userName & "&password=" & password & "&appId=AP80017&balance=true"
        URI = "http://www.mypasms.com/API.aspx?"
        URI = URI & postdata

        Dim request As HttpWebRequest = WebRequest.Create(URI)
        ' Set the Method property of the request to POST.   

        request.Method = "POST"
        Dim byteArray() As Byte
        Try
            byteArray = Encoding.UTF8.GetBytes(postdata)
            ' Set the ContentType property of the WebRequest.   
            request.ContentType = "application/x-www-form-urlencoded"
            ' Set the ContentLength property of the WebRequest.   
            request.ContentLength = byteArray.Length
            'Get the request stream.   
            Dim datastream As Stream
            datastream = request.GetRequestStream()
            ' Write the data to the request stream.   
            datastream.Write(byteArray, 0, byteArray.Length)
            ' Close the Stream object.   
            datastream.Close()
            ' Get the response.   
            Dim response As WebResponse
            response = request.GetResponse
            'Display the status.   
            ' Get the stream containing content returned by the server.   
            datastream = response.GetResponseStream()

            ' Open the stream using a StreamReader for easy access.   
            Dim reader As StreamReader = New StreamReader(datastream)
            ' Read the content.   

            responseFromServer = reader.ReadToEnd
            'Display the content.   
            'label1.text = responseFromServer
            tempdata = ""
            i = 0
            While i <= 10
                If responseFromServer(i) = "<" Then
                    Exit While
                Else
                    tempdata = tempdata & responseFromServer(i).ToString
                    i = i + 1
                End If
            End While

            bal = CInt(tempdata)
            Return bal
            ' Clean up the streams.   
            reader.Close()
            datastream.Close()
            response.Close()
        Catch ex As Exception
            Return -1
            Exit Function
        End Try
    End Function

    Function LoadCredit(ByVal userName As String, ByVal password As String, ByVal creditCode As String) As String
        Dim URI As String
        Dim bal As Integer
        Dim responseFromServer As String
        'Create a request using a URL that can receive a post.    
        Dim postdata As String
        postdata = "username=" & userName & "&password=" & password & "&appId=PutyourAPPIDhere&load=true" & "&CreditCode=" & creditCode
        URI = "http://www.mypasms.com/API.aspx?"
        URI = URI & postdata

        Dim request As HttpWebRequest = WebRequest.Create(URI)
        ' Set the Method property of the request to POST.   
        request.Method = "POST"
        Dim byteArray() As Byte
        Try
            byteArray = Encoding.UTF8.GetBytes(postdata)
            ' Set the ContentType property of the WebRequest.   
            request.ContentType = "application/x-www-form-urlencoded"
            ' Set the ContentLength property of the WebRequest.   
            request.ContentLength = byteArray.Length
            'Get the request stream.   
            Dim datastream As Stream
            datastream = request.GetRequestStream()
            ' Write the data to the request stream.   
            datastream.Write(byteArray, 0, byteArray.Length)
            ' Close the Stream object.   
            datastream.Close()
            ' Get the response.   
            Dim response As WebResponse
            response = request.GetResponse
            'Display the status.   
            ' Get the stream containing content returned by the server.   
            datastream = response.GetResponseStream()

            ' Open the stream using a StreamReader for easy access.   
            Dim reader As StreamReader = New StreamReader(datastream)
            ' Read the content.   

            responseFromServer = reader.ReadToEnd
            'Display the content.   
            'label1.text = responseFromServer
            tempdata = ""
            i = 0
            While i <= 10
                If responseFromServer(i) = "<" Then
                    Exit While
                Else
                    tempdata = tempdata & responseFromServer(i).ToString
                    i = i + 1
                End If
            End While


            Return tempdata
            ' Clean up the streams.   
            reader.Close()
            datastream.Close()
            response.Close()
        Catch ex As Exception
            Return "None"
            Exit Function
        End Try
    End Function

End Class
