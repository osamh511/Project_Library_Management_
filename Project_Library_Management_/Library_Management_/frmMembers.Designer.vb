<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMembers
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
        btnAdd = New Button()
        btnUpdate = New Button()
        lblFullName = New Label()
        lblPhone = New Label()
        lblEmail = New Label()
        txtFullName = New TextBox()
        txtPhone = New TextBox()
        txtEmail = New TextBox()
        btnDelete = New Button()
        btnRefresh = New Button()
        dgvMembers = New DataGridView()
        CType(dgvMembers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(40, 292)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(75, 23)
        btnAdd.TabIndex = 0
        btnAdd.Text = "اضافة"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(146, 292)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(75, 23)
        btnUpdate.TabIndex = 1
        btnUpdate.Text = "تعديل"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' lblFullName
        ' 
        lblFullName.AutoSize = True
        lblFullName.Location = New Point(201, 77)
        lblFullName.Name = "lblFullName"
        lblFullName.Size = New Size(61, 15)
        lblFullName.TabIndex = 2
        lblFullName.Text = "الاسم كامل"
        ' 
        ' lblPhone
        ' 
        lblPhone.AutoSize = True
        lblPhone.Location = New Point(201, 126)
        lblPhone.Name = "lblPhone"
        lblPhone.Size = New Size(39, 15)
        lblPhone.TabIndex = 3
        lblPhone.Text = "الهاتف"
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Location = New Point(201, 199)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(85, 15)
        lblEmail.TabIndex = 4
        lblEmail.Text = "البريد الالكتروني"
        ' 
        ' txtFullName
        ' 
        txtFullName.Location = New Point(59, 69)
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(100, 23)
        txtFullName.TabIndex = 5
        ' 
        ' txtPhone
        ' 
        txtPhone.Location = New Point(59, 118)
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(100, 23)
        txtPhone.TabIndex = 6
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(59, 191)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(100, 23)
        txtEmail.TabIndex = 7
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(255, 292)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(75, 23)
        btnDelete.TabIndex = 8
        btnDelete.Text = "حذف"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(371, 292)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(124, 23)
        btnRefresh.TabIndex = 9
        btnRefresh.Text = "تحديث القائمة"
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' dgvMembers
        ' 
        dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMembers.Location = New Point(461, 39)
        dgvMembers.Name = "dgvMembers"
        dgvMembers.Size = New Size(327, 189)
        dgvMembers.TabIndex = 10
        ' 
        ' frmMembers
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(dgvMembers)
        Controls.Add(btnRefresh)
        Controls.Add(btnDelete)
        Controls.Add(txtEmail)
        Controls.Add(txtPhone)
        Controls.Add(txtFullName)
        Controls.Add(lblEmail)
        Controls.Add(lblPhone)
        Controls.Add(lblFullName)
        Controls.Add(btnUpdate)
        Controls.Add(btnAdd)
        Name = "frmMembers"
        Text = "frmMembers"
        CType(dgvMembers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents lblFullName As Label
    Friend WithEvents lblPhone As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents dgvMembers As DataGridView
End Class
