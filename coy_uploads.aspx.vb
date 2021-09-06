Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail
Imports System.Math

Imports System
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Partial Class coy_uploads
    Inherits System.Web.UI.Page
    Dim msg, mTitle, mTypes, smsReport As String
    Dim conpl As New ConnPool2
    Dim constr As String = conpl.connectionString
    Dim con As New SqlConnection(constr)
    Protected Sub butCreate_Click(sender As Object, e As EventArgs) Handles butCreate.Click

        'If txtFname.Text = "" Then
        '    msg = "Please supply first name. Thank you."
        '    mTitle = "Data Expected"
        '    mTypes = "error"
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
        '    txtFname.Focus()
        '    Exit Sub
        'ElseIf txtSurname.Text = "" Then
        '    msg = "Please supply surname. Thank you."
        '    mTitle = "Data Expected"
        '    mTypes = "error"
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
        '    txtSurname.Focus()
        '    Exit Sub
        'ElseIf txtMobile.Text = "" Then
        '    msg = "Please supply mobile number. Thank you."
        '    mTitle = "Data Expected"
        '    mTypes = "error"
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
        '    txtMobile.Focus()
        '    Exit Sub
        'ElseIf txtPass1.Text = "" Or txtPass2.Text = "" Then
        '    msg = "Please create a password and confirm it. Thank you."
        '    mTitle = "Data Expected"
        '    mTypes = "error"
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
        '    txtPass1.Focus()
        '    Exit Sub

        'ElseIf txtPass1.Text <> txtPass2.Text Then
        '    msg = "Password does not match, please enter same characters for password confirmation. Thank you."
        '    mTitle = "Password mismatch"
        '    mTypes = "error"
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
        '    txtPass1.Focus()
        '    Exit Sub

        'ElseIf drpAccount.Text = "Select Account Type:" Then
        '    msg = "Please select an account type. Thank you."
        '    mTitle = "Data Expected"
        '    mTypes = "error"
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)

        '    Exit Sub
        'End If

        ''Create Account
        'If con.State = ConnectionState.Open Then con.Close()
        'Dim cmd1 As New SqlCommand
        'cmd1.Connection = con
        'cmd1.CommandText = "INSERT INTO USERS (first_Name,Surname,Mobile,Password,Account_Type) values (@first_Name,@Surname,@Mobile,@Password,@Account_Type)"
        'With cmd1.Parameters

        '    .AddWithValue("@first_Name", txtFname.Text)
        '    .AddWithValue("@Surname", txtSurname.Text)
        '    .AddWithValue("@Mobile", txtMobile.Text)
        '    .AddWithValue("@Password", txtPass1.Text)
        '    .AddWithValue("@Account_Type", drpAccount.Text)

        'End With
        'con.Open()
        'cmd1.ExecuteNonQuery()
        'con.Close()

        ''Send SMS
        'msg = "Dear " & txtFname.Text & ", your login account has been created on standardun.com (userName :" & txtMobile.Text & ", Password: " & txtPass1.Text & "), you may login to continue your account openning process. Thank you."
        ''action = 0
        'sender = "StandardUn"

        'Try
        '    Dim obj2 As New Gateway
        '    smsReport = obj2.GatewayBroadcast(sender, txtMobile.Text, msg, "08098079407", "admin")
        '    obj2 = Nothing
        'Catch ex As Exception
        'End Try
        'Session("newaccount") = "yes"
        'If drpAccount.Text = "Personal" Then
        '    Response.Redirect("login.aspx")
        'ElseIf drpAccount.Text = "Joint" Then
        '    Response.Redirect("login.aspx")
        'ElseIf drpAccount.Text = "Corporate" Then
        '    Response.Redirect("login.aspx")
        'End If

        Response.Redirect("pers_stage_3.aspx")
    End Sub
    Protected Sub butBack_Click(sender As Object, e As EventArgs) Handles butBack.Click
        Response.Redirect("pers_stage1.aspx")
    End Sub
End Class
