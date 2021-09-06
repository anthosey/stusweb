Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail
Imports System.Math

Imports System
Imports System.IO
Imports System.Text

Partial Class pers_stage1
    Inherits System.Web.UI.Page
    Dim temp, msg, mTitle, mTypes, smsReport, stateCode As String
    Dim conpl As New ConnPool2
    Dim constr As String = conpl.connectionString
    Dim con As New SqlConnection(constr)
    Dim citi, email, phone, midName As String
    Protected Sub loadData()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand("Select first_name,Surname,middle_Name,Date_Of_Birth,Gender,Marital_Status,Mothers_Maiden,Phone_Number,Email,Country, State,LGA,Nig_Resident,Citizenship,title,mobile From Users Where Mobile='" & Session("user") & "'", con)
        con.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        'Dim country, state, lga As String
        If dr.HasRows Then
            While dr.Read
                If IsDBNull(dr(0)) Then

                Else
                    txtfName.Value = dr.GetString(0)
                End If

                If Not IsDBNull(dr(1)) Then
                    txtSurname.Value = dr.GetString(1)

                End If

                If Not IsDBNull(dr(2)) Then
                    txtmName.Value = dr.GetString(2)
                End If

                If Not IsDBNull(dr(3)) Then
                    txtDOB.Text = CDate(dr.GetDateTime(3)).ToString("yyyy/MM/dd")
                End If

                If Not IsDBNull(dr(4)) Then
                    drpGender.SelectedValue = dr.GetString(4)
                End If

                If Not IsDBNull(dr(5)) Then
                    drpMarriageStatus.SelectedValue = dr.GetString(5)
                End If

                If Not IsDBNull(dr(6)) Then
                    txtmother.Value = dr.GetString(6)
                End If

                If Not IsDBNull(dr(7)) Then
                    txtMobile2.Value = dr.GetString(7)
                End If

                If Not IsDBNull(dr(8)) Then
                    txtEmail.Value = dr.GetString(8)
                End If

                If Not IsDBNull(dr(9)) Then
                    drpCountry.Text = dr.GetString(9)
                End If

                If Not IsDBNull(dr(10)) Then
                    drpState.Text = dr.GetString(10)
                End If

                If Not IsDBNull(dr(11)) Then
                    drpLga.SelectedValue = dr.GetString(11)

                End If

                If Not IsDBNull(dr(12)) Then
                    drpResident.SelectedValue = dr.GetString(12)

                End If

                If Not IsDBNull(dr(13)) Then
                    txtciti.Text = dr.GetString(13)

                End If

                If Not IsDBNull(dr(14)) Then
                    txtTitle.Value = dr.GetString(14)
                End If

                If Not IsDBNull(dr(15)) Then
                    txtmobile.Value = dr.GetString(15)
                End If
            End While

        End If
    End Sub


    Protected Sub butSave_Click(sender As Object, e As EventArgs) Handles butSave.Click

        If txtfName.Value = "" Then
            msg = "Please supply first name. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            txtfName.Focus()
            Exit Sub
        ElseIf txtSurname.Value = "" Then
            msg = "Please supply surname. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            txtSurname.Focus()
            Exit Sub
        ElseIf txtmobile.Value = "" Then
            msg = "Please supply mobile number. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            txtmobile.Focus()
            Exit Sub

        ElseIf txtDOB.Text = "" Then
            msg = "Please supply date of birth. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            txtDOB.Focus()
            Exit Sub

        ElseIf txtmother.Value = "" Then
            msg = "Please supply mother's maiden name. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            txtmother.Focus()
            Exit Sub
        End If


        If txtmName.Value = "" Then
            midName = "None"
        Else
            midName = txtmName.Value
        End If

        If txtMobile2.Value = "" Then
            phone = "None"
        Else
            phone = txtMobile2.Value
        End If

        If txtEmail.Value = "" Then
            Email = "None"
        Else
            Email = txtEmail.Value
        End If

        If txtciti.Text = "" Then
            citi = "None"
        Else
            citi = txtciti.Text
        End If


        'Update Data
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "UPDATE USERS Set first_Name=@first_Name,Surname=@Surname,Mobile=@Mobile,Phone_Number=@Phone_Number,email=@email,title=@title,middle_Name=@middle_Name,Gender=@Gender,Date_Of_Birth=@Date_Of_Birth,Country=@Country,State=@State,Lga=@Lga,Mothers_maiden=@Mothers_maiden,Marital_Status=@Marital_Status,Nig_Resident=@Nig_Resident,Citizenship=@Citizenship Where Mobile='" & Session("user") & "'"
        With cmd1.Parameters

            .AddWithValue("@first_Name", txtfName.Value)
            .AddWithValue("@Surname", txtSurname.Value)
            .AddWithValue("@Mobile", txtmobile.Value)
            .AddWithValue("@Phone_Number", phone)
            .AddWithValue("@email", email)
            .AddWithValue("@title", txtTitle.Value)

            .AddWithValue("@middle_Name", midName)
            .AddWithValue("@Gender", drpGender.Text)
            .AddWithValue("@Date_Of_Birth", txtDOB.Text)
            .AddWithValue("@Country", drpCountry.Text)
            .AddWithValue("@State", drpState.Text)
            .AddWithValue("@Lga", drpLga.Text)
            .AddWithValue("@Mothers_maiden", txtmother.Value)
            .AddWithValue("@Marital_Status", drpMarriageStatus.Text)
            .AddWithValue("@Nig_Resident", drpResident.Text)
            .AddWithValue("@Citizenship", citi)
        End With
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()

        'Session("newaccount") = "yes"
        'If drpAccount.Text = "Personal" Then
        '    Response.Redirect("login.aspx")
        'ElseIf drpAccount.Text = "Joint" Then
        '    Response.Redirect("login.aspx")
        'ElseIf drpAccount.Text = "Corporate" Then
        '    Response.Redirect("login.aspx")
        'End If
        Response.Redirect("pers_stage_2.aspx")
    End Sub

    Private Sub loadLga(ByVal stateCode As String)
        drpLga.Items.Clear()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand("Select [LGA] From LGA Where [State_Code]='" & stateCode & "'", con)
        con.Open()
        Dim dr1 As SqlDataReader = cmd.ExecuteReader
        'Dim country, state, lga As String
        If dr1.HasRows Then
            While dr1.Read
                If IsDBNull(dr1(0)) Then

                Else
                    drpLga.Items.Add(dr1.GetString(0))
                End If
            End While
        End If

    End Sub

    Private Sub pers_stage1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("mobile") = "" Then
            Response.Redirect("login.aspx")
        Else
            butLogin.Visible = False
            butLogout.Visible = True
        End If
        Session("user") = Session("mobile")

        If Not Me.IsPostBack Then

            Dim country, state As String
            country = Request.QueryString("country")
            state = Request.QueryString("state")


            If country = "" Then
                Dim obj As New Operations2
                temp = obj.dynGet1("USERS", "Country", "mobile", Session("user"))
                obj = Nothing

                If temp = "None" Or temp = "" Then
                    Response.Redirect("country_select.aspx")
                Else
                    drpCountry.Text = temp
                End If
            Else
                drpCountry.Text = country
            End If

            If state = "" Then
                Dim obj As New Operations2
                temp = obj.dynGet1("USERS", "State", "mobile", Session("user"))
                obj = Nothing

                If temp = "None" Or temp = "" Then
                    Response.Redirect("country_select.aspx")
                Else
                    drpState.Text = temp
                End If
            Else
                drpState.Text = state
            End If

            If drpCountry.Text = "Nigeria" Then
                'Load Lg of the State selected in Nigeria

                'Get State Code
                Dim ob1 As New Operations2
                stateCode = ob1.dynGet1("STATES", "id", "State", drpState.Text)

                If drpState.Text = "Abuja Federal Capital Territory" Then
                    stateCode = "0"
                End If
                'Load Lg by code
                loadLga(stateCode)
            End If

            loadData()

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
End Class
