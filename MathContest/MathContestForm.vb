'Christopher Pickens
'RCET0265
'Spring 2023
'Math Contest
'https://github.com/Pickchr2/MathContest.git

Option Explicit On
Option Strict On

Public Class MathContestForm
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click, ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click, ClearToolStripMenuItem.Click
        NameTextBox.Clear()
        AgeTextBox.Clear()
        GradeTextBox.Clear()
        FirstNumberTextBox.Clear()
        SecondNumberTextBox.Clear()
        AnswerTextBox.Clear()
        NameTextBox.Focus()
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
    End Sub
End Class
