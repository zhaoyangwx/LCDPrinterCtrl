Public Class Display
    Private DForm As Form
    Private PBox As PictureBox
    Property IsOpened As Boolean
    Public DisplayRegion As Rectangle
    Public LastRefreshTime As Date
    Public Event FormStatusChanged(ByVal b As Boolean)
    Public Event ContentChanged(ByVal Img As Bitmap, ByVal Black As Boolean)
    Public Sub New()
        DisplayRegion = New Rectangle(0, 0, 320, 240)
    End Sub
    Public Sub ChangeRegion(ByVal r As Rectangle)
        DisplayRegion = r
        If IsOpened Then DForm.Invoke(
            Sub()
                DForm.DesktopBounds = DisplayRegion
            End Sub)
    End Sub
    Public Sub CreateForm()
        If DForm IsNot Nothing Then DForm.Dispose()
        DForm = New Form With {
            .StartPosition = FormStartPosition.Manual,
            .TopMost = True,
            .ShowInTaskbar = False,
            .FormBorderStyle = FormBorderStyle.None,
            .WindowState = FormWindowState.Normal,
            .DesktopBounds = DisplayRegion,
            .BackColor = Color.Black}
        PBox = New PictureBox With {.Parent = DForm,
            .Anchor = AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Right And AnchorStyles.Top,
            .Location = New Point,
            .Size = DisplayRegion.Size,
            .Visible = False,
            .SizeMode = PictureBoxSizeMode.CenterImage
            }
        AddHandler DForm.KeyPress,
            Sub(sender As Object, e As KeyPressEventArgs)
                Select Case e.KeyChar.ToString.ToLower
                    Case "c"
                        If MessageBox.Show("Press C to Close?", "Warning", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                            Close()
                        End If
                    Case "h"
                        If MessageBox.Show("Press H to Hide?", "Warning", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                            DForm.Visible = False
                        End If
                End Select
            End Sub

        IsOpened = True
        RaiseEvent FormStatusChanged(IsOpened)
        DForm.Show()

    End Sub
    Public Sub Resize()
        If DForm IsNot Nothing Then
            DForm.Invoke(
                Sub()
                    DForm.Size = DisplayRegion.Size
                    DForm.Location = DisplayRegion.Location
                End Sub)
        End If
    End Sub
    Public Sub ShowImage(ByVal Img As Bitmap)
        If DForm IsNot Nothing Then
            DForm.Invoke(
                Sub()
                    PBox.Image = Img
                    PBox.Visible = True
                    PBox.Refresh()
                End Sub)
            RaiseEvent ContentChanged(Img, False)
        End If
    End Sub
    Public Sub ImageOff()
        DForm.Invoke(
            Sub()
                PBox.Visible = False
            End Sub)
        RaiseEvent ContentChanged(Nothing, True)
    End Sub
    Public Sub Close()
        If DForm IsNot Nothing Then
            DForm.Close()
            PBox.Dispose()
            DForm.Dispose()
            IsOpened = False
            RaiseEvent FormStatusChanged(IsOpened)
        End If
    End Sub

End Class
