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
Partial Class login
    Inherits System.Web.UI.Page
    Dim msg, mTitle, mTypes, smsReport As String
    Dim conpl As New ConnPool2
    Dim constr As String = conpl.connectionString
    Dim con As New SqlConnection(constr)
    Dim temp As String

    'Sub getOtherDetails(ByVal user As String)
    '    Dim obj As New Operations2
    '    Session("fname") = obj.dynGet1("First_Name",)
    '    obj = Nothing
    'End Sub
    Protected Sub butSignin_Click(sender As Object, e As EventArgs) Handles butSignIn.Click

        If txtPass.Text = "" Or txtPass.Text = "" Then
            msg = "Mobile or password missing. Please check and try again. Thank you."
            mTitle = "Login Failed"
            mTypes = "info"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub
        Else
            Dim obj As New Operations2
            temp = obj.dynGet1_2param("USERS", "account_Type", "mobile", txtMobile.Text, "password", txtPass.Text)
            obj = Nothing

            If temp = "None" Or temp = "" Then
                msg = "Invalid mobile /password. Please check and try again. Thank you."
                mTitle = "Login Failed"
                mTypes = "error"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
                Exit Sub
            Else
                Session("mobile") = txtMobile.Text

                'getOtherDetails(txtMobile.Text)
                If temp = "Personal" Then
                    Response.Redirect("pers_stage1.aspx")
                ElseIf temp = "Joint" Then
                    Response.Redirect("pers_stage1.aspx")
                ElseIf temp = "Corporate" Then
                    Response.Redirect("coy_stage1.aspx")
                End If
            End If

        End If



        'Response.Redirect("account_sucess.aspx")

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("newaccount") = "yes" Then
            newUser.InnerText = "Please sign in to continue with your account opening process."
        Else
            newUser.InnerText = "Please sign in if you already have an account with us."
        End If

    End Sub
End Class
