<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        btnLogin = New Button()
        btnExit = New Button()
        lblUser = New Label()
        lblPass = New Label()
        txtUser = New TextBox()
        txtPass = New TextBox()
        SuspendLayout()
        ' 
        ' btnLogin
        ' 
        btnLogin.Location = New Point(435, 279)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(142, 65)
        btnLogin.TabIndex = 0
        btnLogin.Text = "btnLogin"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' btnExit
        ' 
        btnExit.Location = New Point(269, 279)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(131, 59)
        btnExit.TabIndex = 1
        btnExit.Text = "btnExit"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' lblUser
        ' 
        lblUser.AutoSize = True
        lblUser.Location = New Point(519, 134)
        lblUser.Name = "lblUser"
        lblUser.Size = New Size(78, 15)
        lblUser.TabIndex = 2
        lblUser.Text = "اسم المستخدم"
        ' 
        ' lblPass
        ' 
        lblPass.AutoSize = True
        lblPass.Location = New Point(519, 204)
        lblPass.Name = "lblPass"
        lblPass.Size = New Size(62, 15)
        lblPass.TabIndex = 3
        lblPass.Text = "كلمة المرور"
        ' 
        ' txtUser
        ' 
        txtUser.Location = New Point(361, 121)
        txtUser.Multiline = True
        txtUser.Name = "txtUser"
        txtUser.Size = New Size(126, 46)
        txtUser.TabIndex = 4
        ' 
        ' txtPass
        ' 
        txtPass.Location = New Point(361, 183)
        txtPass.Multiline = True
        txtPass.Name = "txtPass"
        txtPass.Size = New Size(126, 36)
        txtPass.TabIndex = 5
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(txtPass)
        Controls.Add(txtUser)
        Controls.Add(lblPass)
        Controls.Add(lblUser)
        Controls.Add(btnExit)
        Controls.Add(btnLogin)
        Name = "frmLogin"
        Text = "frmLogin"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnLogin As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents lblUser As Label
    Friend WithEvents lblPass As Label
    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtPass As TextBox
End Class
