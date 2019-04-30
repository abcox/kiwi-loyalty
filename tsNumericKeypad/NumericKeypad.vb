Public Class tsNumericKeypad

    Private vData As String = ""
    Public Property Data As String
        Get
            Return vData
        End Get
        Set(ByVal value As String)
            vData = value
            If value = "" Then
                buDisplay.Text = "0"
            Else
                buDisplay.Text = value
            End If
        End Set
    End Property

    Private vAllowNegatives As Boolean = False
    Public Property AllowNegatives As Boolean
        Get
            Return vAllowNegatives
        End Get
        Set(ByVal value As Boolean)
            vAllowNegatives = value
            buNegative.Visible = value
            If Data.Substring(0, 1) = "-" And value = False Then
                Data = Data.Substring(1, Data.Length - 1)
            End If
        End Set
    End Property

    Private vAllowDecimals As Boolean = False
    Public Property AllowDecimals As Boolean
        Get
            Return vAllowDecimals
        End Get
        Set(ByVal value As Boolean)
            vAllowDecimals = value
            buDecimal.Visible = value
            If Data.Contains(".") And value = False Then
                Data = Math.Round(Val(Data), 0).ToString
            End If
        End Set
    End Property

    Public Sub NumericMouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles Button0.MouseUp, Button1.MouseUp, Button2.MouseUp, Button3.MouseUp, Button4.MouseUp, Button5.MouseUp, Button6.MouseUp, Button7.MouseUp, Button8.MouseUp, Button9.MouseUp
        If sender Is Button0 And vData = "0" Then
            Exit Sub
        End If
        Data += sender.text
    End Sub

    Private Sub buAccept_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles buAccept.MouseUp
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub buCancel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles buCancel.MouseUp
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub buClear_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles buClear.MouseUp
        Data = ""
    End Sub

    Private Sub buBksp_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles buBksp.MouseUp
        If Data.Length = 0 Then
            Data = ""
        Else
            Data = Data.Substring(0, Data.Length - 1)
        End If
    End Sub

    Private Sub buDecimal_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles buDecimal.MouseUp
        If Data.Contains(".") = False Then
            Data += "."
        End If
    End Sub

    Private Sub buNegative_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles buNegative.MouseUp
        If Data.Contains("-") = False Then
            Data = "-" + Data
        Else
            Data = Data.Substring(1, Data.Length - 1)
        End If
    End Sub
End Class
