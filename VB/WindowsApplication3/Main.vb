Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors


Namespace DXSample
	Partial Public Class Main
		Inherits XtraForm

		Public Sub New()
			InitializeComponent()
		End Sub
		Public Sub InitData()
			Dim dataSet11 As New DataSet()
			dataSet11.Tables.Add(GetCustomerDataTable())
			dataSet11.Tables.Add(GetPersonDataTable())
			Dim keyColumn As DataColumn = dataSet11.Tables("Customers").Columns("ID")
			Dim foreignKeyColumn As DataColumn = dataSet11.Tables("Persons").Columns("ID")
			dataSet11.Relations.Add("CustomersPersons", keyColumn, foreignKeyColumn)
			gridControl1.DataSource = dataSet11.Tables("Customers")
		End Sub

		Private Function GetCustomerDataTable() As DataTable
			Dim table As New DataTable()
			table.TableName = "Customers"
			table.Columns.Add(New DataColumn("Items", GetType(String)))
			table.Columns.Add(New DataColumn("Money", GetType(Double)))
			table.Columns.Add(New DataColumn("ID", GetType(Integer)))
			For i As Integer = 0 To 9
				table.Rows.Add("Product " & i, 3000 + i * 298.55D, i)
			Next i
			Return table
		End Function
		Private Function GetPersonDataTable() As DataTable
			Dim table As New DataTable()
			table.TableName = "Persons"
			table.Columns.Add(New DataColumn("FirstName", GetType(String)))
			table.Columns.Add(New DataColumn("SecondName", GetType(String)))
			table.Columns.Add(New DataColumn("Age", GetType(Integer)))
			table.Columns.Add(New DataColumn("ID", GetType(Integer)))
			For i As Integer = 0 To 49
'INSTANT VB NOTE: The variable name was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim name_Renamed As String = "Adam"
				Dim secondName As String = "Smith"
				If i Mod 2 = 0 Then
					name_Renamed = "Ben"
					secondName = "Black"
				End If
				table.Rows.Add(name_Renamed, secondName, 20 + i \ 2, i Mod 10)
			Next i
			Return table
		End Function

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			InitData()
		End Sub

		Private Sub OnEmbeddedNavigaotrButtonClick(ByVal sender As Object, ByVal e As NavigatorButtonClickEventArgs) Handles gridControl1.EmbeddedNavigator.ButtonClick
			If e.Button.ButtonType = NavigatorButtonType.Remove Then
				If MessageBox.Show("Do you want to delete the current row?", "Confirm deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> DialogResult.Yes Then
					e.Handled = True
				End If
			End If

		End Sub
	End Class
End Namespace
