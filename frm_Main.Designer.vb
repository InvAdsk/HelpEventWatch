Imports Microsoft.VisualBasic
Imports System

Partial Public Class frm_Main
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button()
        Me.listBox = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(12, 12)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 0
        Me.button1.Text = "Start"
        Me.button1.UseVisualStyleBackColor = True
        '
        'listBox
        '
        Me.listBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.listBox.FormattingEnabled = True
        Me.listBox.Location = New System.Drawing.Point(12, 44)
        Me.listBox.Name = "listBox"
        Me.listBox.Size = New System.Drawing.Size(576, 498)
        Me.listBox.TabIndex = 1
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 566)
        Me.Controls.Add(Me.listBox)
        Me.Controls.Add(Me.button1)
        Me.Name = "frm_Main"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents button1 As System.Windows.Forms.Button
		Private listBox As System.Windows.Forms.ListBox
	End Class


