Imports tsNumericKeypad

Public Class NumericKeypadLaunch

    Private vData As String = ""
    Public Property Data As String
        Get
            Return vData
        End Get
        Set(ByVal value As String)
            If value = "" Then
                value = "0"
            End If
            vData = value
            Text = "Current data = " + vData
            RaiseEvent DataChanged(Me, New EventArgs)
        End Set
    End Property
    Public Event DataChanged(ByVal sender As Object, ByVal e As EventArgs)

    Private Sub Button1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseUp
        Dim f As New tsNumericKeypad.tsNumericKeypad
        Dim dr As DialogResult = f.ShowDialog
        If dr = DialogResult.OK Then
            Data = f.Data
        End If
    End Sub
End Class
