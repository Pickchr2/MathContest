'Christopher Pickens
'RCET0265
'Spring 2023
'Math Contest
'https://github.com/Pickchr2/MathContest.git

Option Explicit On
Option Strict On

Public Class MathContestForm
    Private Sub ValidateInput()
        Dim invalidData As String = ""

        If GradeTextBox.Text <> "" And GradeTextBox.Text <> "1" And GradeTextBox.Text <> "2" And GradeTextBox.Text <> "3" And GradeTextBox.Text <> "4" Then
            invalidData &= "Student Grade Must be between 1-4." & vbCrLf
            GradeTextBox.Focus()
            GradeTextBox.SelectAll()
        End If

        If AgeTextBox.Text <> "" And AgeTextBox.Text <> "7" And AgeTextBox.Text <> "8" And AgeTextBox.Text <> "9" And AgeTextBox.Text <> "10" And AgeTextBox.Text <> "11" Then
            invalidData &= "Student Age Must be between 7-11." & vbCrLf
            AgeTextBox.Focus()
            AgeTextBox.SelectAll()
        End If

        If invalidData <> "" And NameTextBox.Enabled = True Then
            MessageBox.Show(invalidData)
        Else
            NameTextBox.Enabled = False
            AgeTextBox.Enabled = False
            GradeTextBox.Enabled = False
            ProblemTypeGroupBox.Enabled = True
            AddRadioButton.Focus()
            GenerateRandomNumbers()
        End If
    End Sub

    Private Sub GenerateRandomNumbers()
        Dim randomNumber As New Random()
        Dim firstRandomNumber As Integer
        Dim secondRandomNumber As Integer

        firstRandomNumber = CInt(randomNumber.Next(1, 10))
        secondRandomNumber = CInt(randomNumber.Next(1, 10))

        FirstNumberTextBox.Text = firstRandomNumber.ToString()
        SecondNumberTextBox.Text = secondRandomNumber.ToString()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click, ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click, ClearToolStripMenuItem.Click
        AddRadioButton.Checked = True
        SubtractRadioButton.Checked = False
        MultiplyRadioButton.Checked = False
        DivideRadioButton.Checked = False
        ProblemTypeGroupBox.Enabled = False
        FirstNumberTextBox.Enabled = False
        SecondNumberTextBox.Enabled = False
        AnswerTextBox.Enabled = False
        SubmitButton.Enabled = False
        SummaryButton.Enabled = False
        SubmitToolStripMenuItem.Enabled = False
        SummaryToolStripMenuItem.Enabled = False
        NameTextBox.Clear()
        AgeTextBox.Clear()
        GradeTextBox.Clear()
        FirstNumberTextBox.Clear()
        SecondNumberTextBox.Clear()
        AnswerTextBox.Clear()
        NameTextBox.Enabled = True
        AgeTextBox.Enabled = True
        GradeTextBox.Enabled = True
        NameTextBox.Focus()
    End Sub

    Private Sub NameTextBox_TextChanged(sender As Object, e As EventArgs) Handles NameTextBox.TextChanged
        If GradeTextBox.Text <> "" And AgeTextBox.Text <> "" Then
            ValidateInput()
        End If
    End Sub

    Private Sub AgeTextBox_TextChanged(sender As Object, e As EventArgs) Handles AgeTextBox.TextChanged
        If NameTextBox.Text <> "" And GradeTextBox.Text <> "" Then
            ValidateInput()
        End If
    End Sub

    Private Sub GradeTextBox_TextChanged(sender As Object, e As EventArgs) Handles GradeTextBox.TextChanged
        If NameTextBox.Text <> "" And AgeTextBox.Text <> "" Then
            ValidateInput()
        End If
    End Sub
End Class
