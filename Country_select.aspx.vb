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
Partial Class Country_Select
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

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class
