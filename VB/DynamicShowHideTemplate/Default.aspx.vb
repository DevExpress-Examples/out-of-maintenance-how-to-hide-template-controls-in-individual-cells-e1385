Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace DynamicShowHideTemplate
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Private Function CreateGridData() As DataTable
			Dim table As New DataTable()
			table.Columns.Add("id", GetType(Integer))
			table.Columns.Add("Status", GetType(String))
			table.Rows.Add(1, "im")
			table.Rows.Add(2, "fr")
			Return table
		End Function
		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			gvTrackingNumbers.DataSource = CreateGridData()
		End Sub
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			gvTrackingNumbers.DataBind()
		End Sub

		' hide custom command button
		Protected Sub gvTrackingNumbers_HtmlCommandCellPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewTableCommandCellEventArgs)
			If e.CommandCellType = DevExpress.Web.ASPxGridView.GridViewTableCommandCellType.Data AndAlso e.CommandColumn.Name = "colManage" Then
				Dim isVisible As Boolean = GetManageButtonVisible(e.VisibleIndex)
				e.Cell.Controls(0).Visible = isVisible
			End If
		End Sub

		' hide template controls
		Protected Function GetIssueLinkVisible(ByVal rowVisibleIndex As Integer) As Boolean
			Dim status As String = GetStatus(rowVisibleIndex)
			If status.Contains("i") Then ' some logic for visibility calculation
				Return True
			Else
				Return False
			End If
		End Function
		Protected Function GetReturnLinkVisible(ByVal rowVisibleIndex As Integer) As Boolean
			Dim status As String = GetStatus(rowVisibleIndex)
			If status.Contains("r") Then
				Return True
			Else
				Return False
			End If
		End Function
		Protected Function GetManageButtonVisible(ByVal rowVisibleIndex As Integer) As Boolean
			Dim status As String = GetStatus(rowVisibleIndex)
			If status.Contains("m") Then
				Return True
			Else
				Return False
			End If
		End Function

		' get cell value
		Private Function GetStatus(ByVal rowVisibleIndex As Integer) As String
			Dim row As DataRow = gvTrackingNumbers.GetDataRow(rowVisibleIndex)
			Return CStr(row("Status"))
		End Function
	End Class
End Namespace
