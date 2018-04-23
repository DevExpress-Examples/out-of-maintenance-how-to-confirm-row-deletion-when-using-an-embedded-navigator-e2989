Imports Microsoft.VisualBasic
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
			For i As Integer = 0 To 4
				dataSet11.Tables(0).Rows.Add(New Object() { i, String.Format("FirstName {0}", i), i, Nothing, DateTime.Today.AddDays(i), True })
				dataSet11.Tables(1).Rows.Add(New Object() { i, i, i })
			Next i
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			InitData()
		End Sub

		Private Sub OnEmbeddedNavigaotrButtonClick(ByVal sender As Object, ByVal e As NavigatorButtonClickEventArgs) Handles gridControl1.EmbeddedNavigator.ButtonClick
			If e.Button.ButtonType = NavigatorButtonType.Remove Then
				If MessageBox.Show("Do you want to delete the current row?", "Confirm deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
					e.Handled = True
				End If
			End If

		End Sub
	End Class
End Namespace
