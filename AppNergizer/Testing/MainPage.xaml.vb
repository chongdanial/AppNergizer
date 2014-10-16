Imports System.Threading
' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    ''' <summary>
    ''' Invoked when this page is about to be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how this page was reached.  The Parameter
    ''' property is typically used to configure the page.</param>
    Dim Rn As New Random
    Dim list As New List(Of Integer)
    Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)
        RandomNumber.Text = Rn.Next(1, 21)
        Dim realnumber As Integer = Convert.ToInt32(RandomNumber.Text)
        If (realnumber = 1 Or realnumber = 2 Or realnumber = 17 Or realnumber = 19) Then
            RandomNumber.Text = Rn.Next(1, 21)
        End If
        countdownbattery()
        countdowntimer()
    End Sub
    Public Async Sub countdownbattery()
        For value As Integer = 10 To 0 Step -1
            progress.Value = value - 1
            Await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(0.2))
        Next
    End Sub
    Public Async Sub countdowntimer()   ''Intermediate Level
        Timer.Text = 6
        For value As Integer = Timer.Text To 0 Step -1
            Timer.Text = value - 1
            Await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1))
            If (Timer.Text = 0) Then
                Timer.Text = "GAME OVER"
                ErrorSound.IsMuted = False
                ErrorSound.Play()
                btnGameOver.Visibility = Windows.UI.Xaml.Visibility.Visible
            End If
        Next
    End Sub
    Public Sub refresh()
        Dim newtimer As Integer
        CorrectSound.IsMuted = True
        txt1.IsChecked = False
        txt2.IsChecked = False
        txt3.IsChecked = False
        txt4.IsChecked = False
        txt5.IsChecked = False
        txt6.IsChecked = False
        txt7.IsChecked = False
        txt8.IsChecked = False
        txt9.IsChecked = False
        RandomNumber.Text = Rn.Next(1, 21)
        newtimer = Convert.ToInt32(Timer.Text)
        progress.Value = progress.Value + 3
        Timer.Text = newtimer + 6
        countdowntimer()
        countdownbattery()
        ''add the validation for the random generator
    End Sub
    Public Function Calculation1(Buttontriggered As Integer) As Integer
        Dim number1 As Integer
        Select Case Buttontriggered
            Case 1
                number1 = 1
            Case 2
                number1 = 2
            Case 3
                number1 = 3
            Case 4
                number1 = 4
            Case 5
                number1 = 5
            Case 6
                number1 = 6
            Case 7
                number1 = 7
            Case 8
                number1 = 8
            Case 9
                number1 = 9
        End Select

        Return number1
    End Function
    Public Function Calculation2(Buttontriggered As Integer) As Integer
        Dim number2 As Integer
        Select Case Buttontriggered
            Case 1
                number2 = 1
            Case 2
                number2 = 2
            Case 3
                number2 = 3
            Case 4
                number2 = 4
            Case 5
                number2 = 5
            Case 6
                number2 = 6
            Case 7
                number2 = 7
            Case 8
                number2 = 8
            Case 9
                number2 = 9
        End Select

        Return number2
    End Function
    Public Function Operation(Buttontriggered As Integer) As Integer
        Dim operation1 As Integer
        Select Case Buttontriggered
            Case 1
                operation1 = 1
            Case 2
                operation1 = 2
            Case 3
                operation1 = 3
            Case 4
                operation1 = 4
        End Select

        Return operation1
    End Function
    Public Sub getusercalculation(number As Integer)
        list.Add(number)
        If list.Count < 1 Then
        Else : maincalc()
        End If
    End Sub
    Public Sub maincalc()
        Dim result As Integer
        If (btnPlus.IsPressed) = True Then
            result = Calculation1(List(1)) + Calculation2(List(2))
            realresult(result)
        ElseIf (btnMinus.IsPressed) = True Then
            result = Calculation1(List(1)) - Calculation2(List(2))
            realresult(result)
        ElseIf (btnMultiply.IsPressed) = True Then
            result = Calculation1(List(1)) * Calculation2(List(2))
            realresult(result)
        ElseIf (btnDivide.IsPressed) = True Then
            result = Calculation1(List(1)) / Calculation2(List(2))
            realresult(result)
        End If
    End Sub
    Public Sub realresult(result1 As Integer)
        If result1 = RandomNumber.Text Then
            CorrectSound.IsMuted = False
            CorrectSound.Play()
            refresh()
        Else
            ErrorSound.IsMuted = False
            ErrorSound.Play()
            btnGameOver.Visibility = Windows.UI.Xaml.Visibility.Visible
        End If
    End Sub
    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        progress.Value = progress.Value + 3
        countdownbattery()
    End Sub
    Private Sub txt1_Checked(sender As Object, e As RoutedEventArgs) Handles txt1.Checked
        getusercalculation(1)
    End Sub
    Private Sub txt2_Checked(sender As Object, e As RoutedEventArgs) Handles txt2.Checked
        getusercalculation(2)
    End Sub

    Private Sub txt3_Checked(sender As Object, e As RoutedEventArgs) Handles txt3.Checked
        getusercalculation(3)
    End Sub

    Private Sub txt4_Checked(sender As Object, e As RoutedEventArgs) Handles txt4.Checked
        getusercalculation(4)
    End Sub

    Private Sub txt5_Checked(sender As Object, e As RoutedEventArgs) Handles txt5.Checked
        getusercalculation(5)
    End Sub

    Private Sub txt6_Checked(sender As Object, e As RoutedEventArgs) Handles txt6.Checked
        getusercalculation(6)
    End Sub
    Private Sub txt9_Checked(sender As Object, e As RoutedEventArgs) Handles txt9.Checked
        getusercalculation(9)
    End Sub

    Private Sub txt7_Checked(sender As Object, e As RoutedEventArgs) Handles txt7.Checked
        getusercalculation(7)
    End Sub

    Private Sub txt8_Checked(sender As Object, e As RoutedEventArgs) Handles txt8.Checked
        getusercalculation(8)
    End Sub

    Private Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
        progress.Value = progress.Value + 3
        countdownbattery()
    End Sub

    Private Sub Button_Click_3(sender As Object, e As RoutedEventArgs)
        Timer.Text = Timer.Text + 6
        countdowntimer()
    End Sub
End Class
