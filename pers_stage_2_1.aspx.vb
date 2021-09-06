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
Partial Class pers_stage_2_1
    Inherits System.Web.UI.Page
    Dim msg, mTitle, mTypes, smsReport As String
    Dim conpl As New ConnPool2
    Dim constr As String = conpl.connectionString
    Dim con As New SqlConnection(constr)
    Dim temp, temp2 As String

    Protected Sub loadData()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand("Select passport_1_Link, Sign_Link, Address_Verification, Identification, Kyc_1_Link, Kyc_2_Link,Birth_link From Users Where Mobile='" & Session("user") & "'", con)
        con.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        'Dim country, state, lga As String
        If dr.HasRows Then
            While dr.Read
                If IsDBNull(dr(0)) Then

                Else
                    impPrev.ImageUrl = dr.GetString(0)
                End If

                If Not IsDBNull(dr(1)) Then
                    imgSign.ImageUrl = dr.GetString(1)

                End If

                If Not IsDBNull(dr(2)) Then
                    spnConfirm.InnerHtml = dr.GetString(2)
                End If

                If Not IsDBNull(dr(3)) Then
                    spnID.InnerHtml = dr.GetString(3)
                End If

                If Not IsDBNull(dr(4)) Then
                    imgId.ImageUrl = dr.GetString(4)
                    'spnConfirm.InnerHtml = spnConfirm.InnerHtml & dr.GetString(5)
                End If

                If Not IsDBNull(dr(5)) Then
                    imgAddy.ImageUrl = dr.GetString(5)

                End If

                If Not IsDBNull(dr(6)) Then
                    imgBirth.ImageUrl = dr.GetString(6)
                End If

            End While

        End If
    End Sub

    Private Sub pers_stage_2_1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("mobile") = "" Then
            Response.Redirect("login.aspx")
        Else
            butLogin.Visible = False
            butLogout.Visible = True
        End If

        'If Not Me.IsPostBack Then
        loadData()
        'End If
    End Sub

    Protected Sub butCreate_Click(sender As Object, e As EventArgs) Handles butCreate.Click

        Response.Redirect("pers_stage_3.aspx")
    End Sub
    Protected Sub butBack_Click(sender As Object, e As EventArgs) Handles butBack.Click
        Response.Redirect("pers_stage_2.aspx")
    End Sub
    Protected Sub butPassport_Click(sender As Object, e As EventArgs) Handles butPassport.Click
        Dim fileExtension As String
        If FileUpload1.HasFile Then
            fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower()
            Dim allowedExtensions As String() = {".jpg", ".jpeg", ".png", ".gif"}
            For i As Integer = 0 To allowedExtensions.Length - 1
                If fileExtension = allowedExtensions(i) Then
                    'fileOk = True
                    Exit For
                Else
                    msg = "You have selected an unrecognise file. Thank you."
                    mTitle = "Data Expected"
                    mTypes = "error"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
                    Exit Sub
                End If
            Next

            If File.Exists(Server.MapPath("~/Uploads/Passport/" & Session("user") & fileExtension)) Then

                File.Delete(Server.MapPath("~/Uploads/Passport/" & Session("user") & fileExtension))

            End If

            FileUpload1.SaveAs(Server.MapPath("~/Uploads/Passport/" + FileUpload1.FileName))
            My.Computer.FileSystem.RenameFile(Server.MapPath("~/Uploads/Passport/" + FileUpload1.FileName), Session("user") & fileExtension)
            'txtpic.Text = "Profile/" & Session("user") & fileExtension
        Else

            msg = "You have Not selected any picture"
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub
        End If

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "Update Users set Passport_1_Link=@Link Where mobile='" & Session("user") & "'"
        With cmd.Parameters
            .AddWithValue("@Link", "Uploads/Passport/" & Session("user") & fileExtension)

        End With
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        msg = "Passport uploaded successfully."
        mTitle = "Data Updated"
        mTypes = "success"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)

    End Sub

    Protected Sub btnId_Click(sender As Object, e As EventArgs) Handles btnId.Click
        Dim fileExtension As String
        If FileUpload2.HasFile Then
            fileExtension = Path.GetExtension(FileUpload2.PostedFile.FileName).ToLower()
            Dim allowedExtensions As String() = {".jpg", ".jpeg", ".png", ".gif"}
            For i As Integer = 0 To allowedExtensions.Length - 1
                If fileExtension = allowedExtensions(i) Then
                    'fileOk = True
                    Exit For
                Else
                    msg = "You have selected an unrecognise file. Thank you."
                    mTitle = "Data Expected"
                    mTypes = "error"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
                    Exit Sub
                End If
            Next

            If File.Exists(Server.MapPath("~/Uploads/Sign/" & Session("user") & fileExtension)) Then

                File.Delete(Server.MapPath("~/Uploads/Sign/" & Session("user") & fileExtension))

            End If

            FileUpload2.SaveAs(Server.MapPath("~/Uploads/Sign/" + FileUpload2.FileName))
            My.Computer.FileSystem.RenameFile(Server.MapPath("~/Uploads/Sign/" + FileUpload2.FileName), Session("user") & fileExtension)
            temp2 = "Uploads/Sign/" & Session("user") & fileExtension
            'txtpic.Text = "Profile/" & Session("user") & fileExtension
        Else

            msg = "You have Not selected any picture file"
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub
        End If

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "Update Users set Sign_Link=@Link Where mobile='" & Session("user") & "'"
        With cmd.Parameters
            .AddWithValue("@Link", temp2)

        End With
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        msg = "Signature uploaded successfully."
        mTitle = "Data Updated"
        mTypes = "success"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)

    End Sub
    Protected Sub butAddyConfirm_Click(sender As Object, e As EventArgs) Handles butAddyConfirm.Click
        Dim fileExtension As String
        If FileUpload3.HasFile Then
            fileExtension = Path.GetExtension(FileUpload3.PostedFile.FileName).ToLower()
            Dim allowedExtensions As String() = {".jpg", ".jpeg", ".png", ".gif"}
            For i As Integer = 0 To allowedExtensions.Length - 1
                If fileExtension = allowedExtensions(i) Then
                    'fileOk = True
                    Exit For
                Else
                    msg = "You have selected an unrecognise file. Thank you."
                    mTitle = "Data Expected"
                    mTypes = "error"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
                    Exit Sub
                End If
            Next

            If File.Exists(Server.MapPath("~/Uploads/Address/" & Session("user") & fileExtension)) Then

                File.Delete(Server.MapPath("~/Uploads/Address/" & Session("user") & fileExtension))

            End If

            FileUpload3.SaveAs(Server.MapPath("~/Uploads/Address/" + FileUpload3.FileName))
            My.Computer.FileSystem.RenameFile(Server.MapPath("~/Uploads/Address/" + FileUpload3.FileName), Session("user") & fileExtension)
            temp2 = "Uploads/Address/" & Session("user") & fileExtension
            'txtpic.Text = "Profile/" & Session("user") & fileExtension
        Else

            msg = "You have Not selected any picture file"
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub
        End If

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "Update Users set Kyc_2_Link=@Link Where mobile='" & Session("user") & "'"
        With cmd.Parameters
            .AddWithValue("@Link", temp2)

        End With
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        msg = "Address confirmation document uploaded successfully."
        mTitle = "Data Updated"
        mTypes = "success"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)

    End Sub
    Protected Sub butID_Click(sender As Object, e As EventArgs) Handles butID.Click
        Dim fileExtension As String
        If FileUpload4.HasFile Then
            fileExtension = Path.GetExtension(FileUpload4.PostedFile.FileName).ToLower()
            Dim allowedExtensions As String() = {".jpg", ".jpeg", ".png", ".gif"}
            For i As Integer = 0 To allowedExtensions.Length - 1
                If fileExtension = allowedExtensions(i) Then
                    'fileOk = True
                    Exit For
                Else
                    msg = "You have selected an unrecognise file. Thank you."
                    mTitle = "Data Expected"
                    mTypes = "error"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
                    Exit Sub
                End If
            Next

            If File.Exists(Server.MapPath("~/Uploads/Ids/" & Session("user") & fileExtension)) Then

                File.Delete(Server.MapPath("~/Uploads/Ids/" & Session("user") & fileExtension))

            End If

            FileUpload4.SaveAs(Server.MapPath("~/Uploads/Ids/" + FileUpload4.FileName))
            My.Computer.FileSystem.RenameFile(Server.MapPath("~/Uploads/Ids/" + FileUpload4.FileName), Session("user") & fileExtension)
            temp2 = "Uploads/Ids/" & Session("user") & fileExtension
            'txtpic.Text = "Profile/" & Session("user") & fileExtension
        Else

            msg = "You have Not selected any picture file"
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub
        End If

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "Update Users set Kyc_1_Link=@Link Where mobile='" & Session("user") & "'"
        With cmd.Parameters
            .AddWithValue("@Link", temp2)

        End With
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        msg = "Id uploaded successfully."
        mTitle = "Data Updated"
        mTypes = "success"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)

    End Sub
    Protected Sub butBirth_Click(sender As Object, e As EventArgs) Handles butBirth.Click
        Dim fileExtension As String
        If FileUpload5.HasFile Then
            fileExtension = Path.GetExtension(FileUpload5.PostedFile.FileName).ToLower()
            Dim allowedExtensions As String() = {".jpg", ".jpeg", ".png", ".gif"}
            For i As Integer = 0 To allowedExtensions.Length - 1
                If fileExtension = allowedExtensions(i) Then
                    'fileOk = True
                    Exit For
                Else
                    msg = "You have selected an unrecognise file. Thank you."
                    mTitle = "Data Expected"
                    mTypes = "error"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
                    Exit Sub
                End If
            Next

            If File.Exists(Server.MapPath("~/Uploads/Birth/" & Session("user") & fileExtension)) Then

                File.Delete(Server.MapPath("~/Uploads/Birth/" & Session("user") & fileExtension))

            End If

            FileUpload5.SaveAs(Server.MapPath("~/Uploads/Birth/" + FileUpload5.FileName))
            My.Computer.FileSystem.RenameFile(Server.MapPath("~/Uploads/Birth/" + FileUpload5.FileName), Session("user") & fileExtension)
            temp2 = "Uploads/Birth/" & Session("user") & fileExtension
            'txtpic.Text = "Profile/" & Session("user") & fileExtension
        Else

            msg = "You have Not selected any picture file"
            mTitle = "Data Expected"
            mTypes = "error"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)
            Exit Sub
        End If

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "Update Users set Birth_Link=@Link Where mobile='" & Session("user") & "'"
        With cmd.Parameters
            .AddWithValue("@Link", temp2)

        End With
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        msg = "Birth Certificate uploaded successfully."
        mTitle = "Data Updated"
        mTypes = "success"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "feedback", "feedback('" & mTitle & "', '" & msg & "','" & mTypes & "' );", True)

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
