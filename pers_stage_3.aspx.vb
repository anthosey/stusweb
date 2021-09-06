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
Partial Class pers_stage_3
    Inherits System.Web.UI.Page
    Dim msg, mTitle, mTypes, smsReport As String
    Dim conpl As New ConnPool2
    Dim constr As String = conpl.connectionString
    Dim con As New SqlConnection(constr)
    Dim acctDate, sort, complete As String
    Dim pport, Sign, kyc1, kyc2, ids, bank, address, dob As String
    Dim flag, flag1 As Boolean
    Protected Sub loadData()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand("Select Bank_Name,Bank_Address,Account_Name,Account_Number,Date_Of_Creation,Bank_Sort_Code,BVN From Users Where Mobile='" & Session("user") & "'", con)
        con.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        'Dim country, state, lga As String
        If dr.HasRows Then
            While dr.Read
                If IsDBNull(dr(0)) Then

                Else
                    txtBankName.Value = dr.GetString(0)
                End If

                If Not IsDBNull(dr(1)) Then
                    txtBranch.Value = dr.GetString(1)

                End If

                If Not IsDBNull(dr(2)) Then
                    txtAccountName.Text = dr.GetString(2)
                End If

                If Not IsDBNull(dr(3)) Then
                    txtAccountNo.Text = dr.GetString(3)
                End If

                If Not IsDBNull(dr(4)) Then
                    txtAccountDate.Text = dr.GetString(4)
                    'spnConfirm.InnerHtml = spnConfirm.InnerHtml & dr.GetString(5)
                End If

                If Not IsDBNull(dr(5)) Then
                    txtSortCode.Value = dr.GetString(5)

                End If

                If Not IsDBNull(dr(6)) Then
                    txtBVN.Value = dr.GetString(6)
                End If

            End While

        End If
    End Sub

    Protected Sub loadRequiredData()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand("Select Date_Of_Birth, Residential_Address, Bank_Name, Identification, Kyc_1_Link,Kyc_2_Link,Sign_Link,Passport_1_Link From Users Where Mobile='" & Session("user") & "'", con)
        con.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        'Dim country, state, lga As String
        If dr.HasRows Then
            While dr.Read
                If IsDBNull(dr(0)) Then

                Else
                    dob = dr.GetString(0)
                End If

                If Not IsDBNull(dr(1)) Then
                    address = dr.GetString(1)

                End If

                If Not IsDBNull(dr(2)) Then
                    bank = dr.GetString(2)
                End If

                If Not IsDBNull(dr(3)) Then
                    ids = dr.GetString(3)
                End If


                If Not IsDBNull(dr(4)) Then
                    kyc1 = dr.GetString(4)
                    'spnConfirm.InnerHtml = spnConfirm.InnerHtml & dr.GetString(5)
                End If

                If Not IsDBNull(dr(5)) Then
                    kyc2 = dr.GetString(5)

                End If

                If Not IsDBNull(dr(6)) Then
                    Sign = dr.GetString(6)
                End If

                If Not IsDBNull(dr(6)) Then
                    pport = dr.GetString(7)
                End If
            End While

        End If
    End Sub

    Protected Sub butCreate_Click(sender As Object, e As EventArgs) Handles butCreate.Click

        If txtBankName.Value = "" Then
            msg = "Please supply bank name. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub
        ElseIf txtBranch.Value = "" Then
            msg = "Please supply bank branch. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)

            Exit Sub
        ElseIf txtAccountName.Text = "" Then
            msg = "Please supply your account name. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub

        ElseIf txtAccountNo.Text = "" Then
            msg = "Please supply your account number. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub

        ElseIf txtBVN.Value = "" Then
            msg = "Please supply your BVN. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)

            Exit Sub
        End If


        If txtSortCode.Value = "" Then
            sort = "None"
        Else
            sort = txtSortCode.Value
        End If

        If txtAccountDate.Text = "" Then
            acctDate = "None"
        Else
            acctDate = txtAccountDate.Text
        End If

        'Update Bank Account Info
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "UPDATE USERS Set Bank_Name=@BankName, Bank_Address=@BankAddress,Account_Name=@AccountName,Account_Number=@AccountNumber,Date_Of_Creation=@DateCreated,Bank_Sort_Code=@SortCode,BVN=@Bvn Where Mobile='" & Session("user") & "'"
        With cmd1.Parameters

            .AddWithValue("@BankName", txtBankName.Value)
            .AddWithValue("@BankAddress", txtBranch.Value)
            .AddWithValue("@AccountName", txtAccountName.Text)
            .AddWithValue("@AccountNumber", txtAccountNo.Text)
            .AddWithValue("@DateCreated", acctDate)

            .AddWithValue("@SortCode", sort)
            .AddWithValue("@BVN", txtBVN.Value)
        End With
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()

        msg = "Bank details updated successfully."
        mTitle = "Data Updated"
        mTypes = "success"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)


        msg = "Bank details updated successfully."
        mTitle = "Data Updated"
        mTypes = "info"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)

        'Response.Redirect("pers_stage_3.aspx")
    End Sub

    Protected Sub butBack_Click(sender As Object, e As EventArgs) Handles butBack.Click
        Response.Redirect("pers_stage_2_1.aspx")
    End Sub

    Private Sub pers_stage_3_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("mobile") = "" Then
            Response.Redirect("login.aspx")
        Else
            butLogin.Visible = False
            butLogout.Visible = True
        End If

        If Not IsPostBack Then
            loadData()
        End If

        Dim obj As New Operations2
        complete = obj.dynGet1("USERS", "Bank_Name", "mobile", Session("user"))
        obj = Nothing

        If (complete = "None" Or complete = "") Then
            spnMsg.Visible = False
            spnTitle.Visible = False
            butSubmit.Visible = False
        Else
            spnMsg.Visible = True
            spnTitle.Visible = True
            butSubmit.Visible = True
        End If
    End Sub

    Protected Sub butLogout_Click(sender As Object, e As EventArgs) Handles butLogout.Click
        FormsAuthentication.SignOut()
        Session("UserName") = ""
        Session("Max") = 0
        'Session("listStart") = 0
        'Session("listStop") = 0
        'Session("TransactionCode") = ""
        Session.Abandon()
        Session.Clear()
        Response.Redirect("Login.aspx")
    End Sub
    Protected Sub butSubmit_Click(sender As Object, e As EventArgs) Handles butSubmit.Click
        'Verify all required fields
        If pport = "" Or pport = "None" _
        Or Sign = "" Or Sign = "None" _
        Or kyc1 = "" Or kyc1 = "None" _
        Or kyc2 = "" Or kyc2 = "None" _
        Or ids = "" Or ids = "None" _
        Or bank = "" Or bank = "None" _
        Or address = "" Or address = "None" _
        Or dob = "" Or dob = "None" Then
            flag = False
        Else
            flag = True
        End If


        If flag = False Then
            msg = "Sorry, you are yet to complete all required fields. Please go through all the pages and provide all the required information before final submission."
            mTitle = "Data required"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub
        Else
            'Mark Record Submitted
            Dim obj As New Operations2
            flag1 = obj.dynUpdate1("USERS", "Submit_Status", "Mobile", Session("user"), "Submitted")
            obj = Nothing

            msg = "Final data submitted successfully."
            mTitle = "Forms submited"
            mTypes = "success"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
        End If

    End Sub
End Class
