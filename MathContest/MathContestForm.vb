'Christopher Pickens
'RCET0265
'Spring 2023
'Math Contest
'https://github.com/Pickchr2/MathContest.git

Option Explicit On
Option Strict On

Public Class MathContestForm
    Dim totalAnswersCorrect As Integer
    Dim totalAnswersAttempted As Integer

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

        If invalidData <> "" Then
            MessageBox.Show(invalidData)
        Else
            NameTextBox.Enabled = False
            AgeTextBox.Enabled = False
            GradeTextBox.Enabled = False
            ProblemTypeGroupBox.Enabled = True
            AnswerTextBox.Enabled = True
            SubmitButton.Enabled = True
            SummaryButton.Enabled = True
            SubmitToolStripMenuItem.Enabled = True
            SummaryToolStripMenuItem.Enabled = True
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
        totalAnswersCorrect = 0
        totalAnswersAttempted = 0
    End Sub

    Private Sub NameTextBox_TextChanged(sender As Object, e As EventArgs) Handles NameTextBox.TextChanged
        If GradeTextBox.Text <> "" And AgeTextBox.Text <> "" And NameTextBox.Enabled = True Then
            ValidateInput()
        End If
    End Sub

    Private Sub AgeTextBox_TextChanged(sender As Object, e As EventArgs) Handles AgeTextBox.TextChanged
        If NameTextBox.Text <> "" And GradeTextBox.Text <> "" And AgeTextBox.Enabled = True Then
            ValidateInput()
        End If
    End Sub

    Private Sub GradeTextBox_TextChanged(sender As Object, e As EventArgs) Handles GradeTextBox.TextChanged
        If NameTextBox.Text <> "" And AgeTextBox.Text <> "" And GradeTextBox.Enabled = True Then
            ValidateInput()
        End If
    End Sub

    Private Sub AddRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles AddRadioButton.CheckedChanged, SubtractRadioButton.CheckedChanged, MultiplyRadioButton.CheckedChanged, DivideRadioButton.CheckedChanged
        GenerateRandomNumbers()
    End Sub

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click, SubmitToolStripMenuItem.Click
        Dim correctAnswer As Decimal
        Dim studentAnswer As Decimal

        Try
            studentAnswer = CDec(AnswerTextBox.Text)

            If AddRadioButton.Checked = True Then
                correctAnswer = CDec(FirstNumberTextBox.Text) + CDec(SecondNumberTextBox.Text)
            ElseIf SubtractRadioButton.Checked = True Then
                correctAnswer = CDec(FirstNumberTextBox.Text) - CDec(SecondNumberTextBox.Text)
            ElseIf MultiplyRadioButton.Checked = True Then
                correctAnswer = CDec(FirstNumberTextBox.Text) * CDec(SecondNumberTextBox.Text)
            ElseIf DivideRadioButton.Checked = True Then
                correctAnswer = Math.Round(CDec(FirstNumberTextBox.Text) / CDec(SecondNumberTextBox.Text), 1)
            End If

            If studentAnswer = correctAnswer Then
                totalAnswersAttempted += 1
                totalAnswersCorrect += 1
                MessageBox.Show("Congratulations! " & studentAnswer & " is correct!")
            Else
                totalAnswersAttempted += 1
                MessageBox.Show("Sorry, " & studentAnswer & " is incorrect. The correct answer is " & correctAnswer & ".")
            End If

            GenerateRandomNumbers()

            AnswerTextBox.Clear()
            AnswerTextBox.Focus()
        Catch ex As Exception
            MessageBox.Show("The answer entered must be a valid number, please try again.")
            AnswerTextBox.Focus()
            AnswerTextBox.SelectAll()
        End Try
    End Sub

    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click, SummaryToolStripMenuItem.Click
        MessageBox.Show(NameTextBox.Text & " Has answered " & totalAnswersCorrect & " question(s) correct out of " & totalAnswersAttempted & " question(s) attempted.")
    End Sub

    Private Sub InstructionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstructionsToolStripMenuItem.Click
        MessageBox.Show("Enter the student's information and choose desired operation to generate random numbers. Then, Submit your answer. Click summary to see how many correct answers so far.")
    End Sub
End Class
