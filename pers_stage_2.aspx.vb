Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail
Imports System.Math

Imports System
Imports System.IO
Imports System.Text

Partial Class pers_stage_2
    Inherits System.Web.UI.Page
    Dim msg, mTitle, mTypes, smsReport As String
    Dim conpl As New ConnPool2
    Dim constr As String = conpl.connectionString
    Dim con As New SqlConnection(constr)
    Dim ma As String
    Dim flagHideOthers As Boolean

    Protected Sub loadData()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand("Select Residential_Address,Mailing_Address,Next_Of_Kin,Relationship, NOK_Address,NOK_Number,Employer_Name,Employer_Address,Occupation,source_Of_Fund,Annual_Income,identification,address_verification From Users Where Mobile='" & Session("user") & "'", con)
        con.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        'Dim country, state, lga As String
        If dr.HasRows Then
            While dr.Read
                If IsDBNull(dr(0)) Then

                Else
                    txtResidence.Text = dr.GetString(0)
                End If

                If Not IsDBNull(dr(1)) Then
                    txtMA.Text = dr.GetString(1)

                End If

                If Not IsDBNull(dr(2)) Then
                    txtKinName.Text = dr.GetString(2)
                End If

                If Not IsDBNull(dr(3)) Then
                    txtRelationship.Text = dr.GetString(3)
                End If

                If Not IsDBNull(dr(4)) Then
                    txtKinContact.Value = dr.GetString(4)
                End If

                If Not IsDBNull(dr(5)) Then
                    txtKinPhone.Text = dr.GetString(5)
                End If

                If Not IsDBNull(dr(6)) Then
                    txtEmployer.Text = dr.GetString(6)
                End If

                If Not IsDBNull(dr(7)) Then
                    txtCoyAddress.Text = dr.GetString(7)
                End If

                If Not IsDBNull(dr(8)) Then
                    txtProfession.Text = dr.GetString(8)
                End If

                If Not IsDBNull(dr(9)) Then
                    lblFunds.InnerText = dr.GetString(9)
                End If

                If Not IsDBNull(dr(10)) Then
                    txtIncome.Text = dr.GetDecimal(10)
                End If

                If Not IsDBNull(dr(11)) Then
                    drpID.SelectedValue = dr.GetString(11)

                End If

                If Not IsDBNull(dr(12)) Then
                    drpConfirmAddy .SelectedValue  = dr.GetString(12)

                End If

            End While

        End If
    End Sub


    Protected Sub butCreate_Click(sender As Object, e As EventArgs) Handles butCreate.Click

        If txtResidence.Text = "" Then
            msg = "Please supply your residence address. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            'txtresicence.Focus()
            Exit Sub


        ElseIf txtKinName.Text = "" Then
            msg = "Please supply the name of your next of kin. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub
        ElseIf txtRelationship.Text = "" Then
            msg = "Please supply your relationship with the next of kin. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub

        ElseIf txtKinContact.Value = "" Then
            msg = "Please supply contact address of your next of kin. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub

        ElseIf txtKinPhone.Text = "" Then
            msg = "Please supply the phone number of your next of kin. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub
        ElseIf txtProfession.Text = "" Then
            msg = "Please supply your occupation / profession . Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)

            Exit Sub
        ElseIf txtEmployer.Text = "" Then
            msg = "Please supply the name of your employer / the company you work for. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub
        ElseIf txtCoyAddress.Text = "" Then
            msg = "Please supply the company / workplace address. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub

        End If

        If txtIncome.Text = "" Then
            msg = "Please supply your annual income. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub
        ElseIf IsNumeric(txtIncome.Text) = False Then
            msg = "Please supply a numeric value for your annual income. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub
        End If


        If txtMA.Text = "" Then
            ma = "None"
        Else
            ma = txtMA.Text
        End If

        lblFunds.InnerText = "" 'Reset already selected fund sources
        If (chkSalary.Checked = False) And (chkBusinessIncome.Checked = False) And (chkDividends.Checked = False) _
            And (chkInvestments.Checked = False) And (chkProperty.Checked = False) And (chkRelating.Checked = False) _
            And (chkSalary.Checked = False) And (chkTrading.Checked = False) And (chkOthers.Checked = False) Then

            msg = "Please check at least one of the sources of fund as listed below. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            'txtresicence.Focus()
            Exit Sub
        Else

            If chkBusinessIncome.Checked = True Then
                lblFunds.InnerText = lblFunds.InnerText & "," & chkBusinessIncome.Text
            End If

            If chkDividends.Checked = True Then
                lblFunds.InnerText = lblFunds.InnerText & "," & chkDividends.Text
            End If

            If chkInvestments.Checked = True Then
                lblFunds.InnerText = lblFunds.InnerText & "," & chkInvestments.Text
            End If

            If chkProperty.Checked = True Then
                lblFunds.InnerText = lblFunds.InnerText & "," & chkProperty.Text
            End If

            If chkRelating.Checked = True Then
                lblFunds.InnerText = lblFunds.InnerText & "," & chkRelating.Text
            End If

            If chkSalary.Checked = True Then
                lblFunds.InnerText = lblFunds.InnerText & "," & chkSalary.Text
            End If

            If chkTrading.Checked = True Then
                lblFunds.InnerText = lblFunds.InnerText & "," & chkTrading.Text
            End If
        End If

        If chkOthers.Checked = True Then
            If txtOthers.Text = "" Then
                msg = "Please supply your source of fund. Thank you."
                mTitle = "Data Expected"
                mTypes = "error"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
                'txtresicence.Focus()
                Exit Sub
            Else
                lblFunds.InnerText = lblFunds.InnerText & "," & txtOthers.Text
            End If
        End If

        If drpID.Text = "Select One:" Then
            msg = "Please select a means of identification. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            'txtresicence.Focus()
            Exit Sub
        End If


        If drpConfirmAddy.Text = "Select One:" Then
            msg = "Please select a method of address confirmation. Thank you."
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            'txtresicence.Focus()
            Exit Sub

        End If

        'Update data
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "UPDATE USERS Set Residential_Address=@Residential_Address,Mailing_Address=@Mailing_Address,Next_Of_Kin=@Next_Of_Kin,Relationship=@Relationship, NOK_Address=@NOK_Address,NOK_Number=@NOK_Number,Employer_Name=@Employer_Name,Employer_Address=@Employer_Address,Occupation=@Occupation,source_Of_Fund=@Source_Of_Fund,Annual_Income=@Annual_Income,identification=@Identification,address_verification=@address_verification Where Mobile='" & Session("user") & "'"
        With cmd1.Parameters

            .AddWithValue("@Residential_Address", txtResidence.Text)
            .AddWithValue("@Mailing_Address", txtMA.Text)
            .AddWithValue("@Next_Of_Kin", txtKinName.Text)
            .AddWithValue("@Relationship", txtRelationship.Text)
            .AddWithValue("@NOK_Address", txtKinContact.Value)
            .AddWithValue("@NOK_Number", txtKinPhone.Text)
            .AddWithValue("@Employer_Name", txtEmployer.Text)

            .AddWithValue("@Employer_Address", txtCoyAddress.Text)
            .AddWithValue("@Occupation", txtProfession.Text)
            .AddWithValue("@Source_Of_Fund", lblFunds.InnerText)
            .AddWithValue("@Annual_Income", txtIncome.Text)
            .AddWithValue("@Identification", drpID.Text)
            .AddWithValue("@address_verification", drpConfirmAddy.Text)

        End With
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()

        Response.Redirect("pers_stage_2_1.aspx")
    End Sub
    Protected Sub butBack_Click(sender As Object, e As EventArgs) Handles butBack.Click
        Response.Redirect("pers_stage1.aspx")
    End Sub
    Protected Sub drpID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpID.SelectedIndexChanged

    End Sub

    Protected Sub chkOthers_CheckedChanged(sender As Object, e As EventArgs) Handles chkOthers.CheckedChanged
        If chkOthers.Checked = True Then
            txtOthers.Visible = True
            flagHideOthers = False
        Else
            flagHideOthers = True
            txtOthers.Visible = False
        End If
    End Sub

    Private Sub pers_stage_2_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("mobile") = "" Then
            Response.Redirect("login.aspx")
        Else
            butLogin.Visible = False
            butLogout.Visible = True
        End If


        If flagHideOthers = True Then
            txtOthers.Visible = True
        Else
            txtOthers.Visible = False
        End If


        If Not Me.IsPostBack Then
            Dim temp As String
            Dim obj As New Operations2
            temp = obj.dynGet1("USERS", "Residential_Address", "mobile", Session("mobile"))
            obj = Nothing

            If temp = "" Then
            Else
                loadData()
            End If

        End If


    End Sub
    Protected Sub chkSalary_CheckedChanged(sender As Object, e As EventArgs) Handles chkSalary.CheckedChanged

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
