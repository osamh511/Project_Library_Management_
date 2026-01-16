<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoans
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
        btnLoan = New Button()
        btnReturn = New Button()
        lblMemberID = New Label()
        lblBookID = New Label()
        lblDueDate = New Label()
        txtMemberID = New TextBox()
        txtBookID = New TextBox()
        dtpDueDate = New DateTimePicker()
        btnRefresh = New Button()
        dgvLoans = New DataGridView()
        lblLoanID = New Label()
        txtLoanID = New TextBox()
        CType(dgvLoans, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnLoan
        ' 
        btnLoan.Location = New Point(169, 346)
        btnLoan.Name = "btnLoan"
        btnLoan.Size = New Size(75, 23)
        btnLoan.TabIndex = 0
        btnLoan.Text = "اعارة كتاب"
        btnLoan.UseVisualStyleBackColor = True
        ' 
        ' btnReturn
        ' 
        btnReturn.Location = New Point(294, 346)
        btnReturn.Name = "btnReturn"
        btnReturn.Size = New Size(75, 23)
        btnReturn.TabIndex = 1
        btnReturn.Text = "ارجاع كتاب"
        btnReturn.UseVisualStyleBackColor = True
        ' 
        ' lblMemberID
        ' 
        lblMemberID.AutoSize = True
        lblMemberID.Location = New Point(343, 99)
        lblMemberID.Name = "lblMemberID"
        lblMemberID.Size = New Size(59, 15)
        lblMemberID.TabIndex = 2
        lblMemberID.Text = "رقم العضو"
        ' 
        ' lblBookID
        ' 
        lblBookID.AutoSize = True
        lblBookID.Location = New Point(351, 148)
        lblBookID.Name = "lblBookID"
        lblBookID.Size = New Size(58, 15)
        lblBookID.TabIndex = 3
        lblBookID.Text = "رقم الكتاب"
        ' 
        ' lblDueDate
        ' 
        lblDueDate.AutoSize = True
        lblDueDate.Location = New Point(395, 225)
        lblDueDate.Name = "lblDueDate"
        lblDueDate.Size = New Size(83, 15)
        lblDueDate.TabIndex = 4
        lblDueDate.Text = "تاريخ الاستحقاق"
        ' 
        ' txtMemberID
        ' 
        txtMemberID.Location = New Point(205, 91)
        txtMemberID.Name = "txtMemberID"
        txtMemberID.Size = New Size(100, 23)
        txtMemberID.TabIndex = 5
        ' 
        ' txtBookID
        ' 
        txtBookID.Location = New Point(205, 140)
        txtBookID.Name = "txtBookID"
        txtBookID.Size = New Size(100, 23)
        txtBookID.TabIndex = 6
        ' 
        ' dtpDueDate
        ' 
        dtpDueDate.Location = New Point(169, 219)
        dtpDueDate.Name = "dtpDueDate"
        dtpDueDate.Size = New Size(200, 23)
        dtpDueDate.TabIndex = 7
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(412, 346)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(75, 23)
        btnRefresh.TabIndex = 8
        btnRefresh.Text = "تحديث قائمة"
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' dgvLoans
        ' 
        dgvLoans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLoans.Location = New Point(0, 397)
        dgvLoans.Name = "dgvLoans"
        dgvLoans.Size = New Size(865, 149)
        dgvLoans.TabIndex = 9
        ' 
        ' lblLoanID
        ' 
        lblLoanID.AutoSize = True
        lblLoanID.Location = New Point(427, 286)
        lblLoanID.Name = "lblLoanID"
        lblLoanID.Size = New Size(57, 15)
        lblLoanID.TabIndex = 10
        lblLoanID.Text = "رقم الاعارة"
        ' 
        ' txtLoanID
        ' 
        txtLoanID.Location = New Point(218, 286)
        txtLoanID.Name = "txtLoanID"
        txtLoanID.Size = New Size(100, 23)
        txtLoanID.TabIndex = 11
        ' 
        ' frmLoans
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(861, 548)
        Controls.Add(txtLoanID)
        Controls.Add(lblLoanID)
        Controls.Add(dgvLoans)
        Controls.Add(btnRefresh)
        Controls.Add(dtpDueDate)
        Controls.Add(txtBookID)
        Controls.Add(txtMemberID)
        Controls.Add(lblDueDate)
        Controls.Add(lblBookID)
        Controls.Add(lblMemberID)
        Controls.Add(btnReturn)
        Controls.Add(btnLoan)
        Name = "frmLoans"
        Text = "frmLoans"
        CType(dgvLoans, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnLoan As Button
    Friend WithEvents btnReturn As Button
    Friend WithEvents lblMemberID As Label
    Friend WithEvents lblBookID As Label
    Friend WithEvents lblDueDate As Label
    Friend WithEvents txtMemberID As TextBox
    Friend WithEvents txtBookID As TextBox
    Friend WithEvents dtpDueDate As DateTimePicker
    Friend WithEvents btnRefresh As Button
    Friend WithEvents dgvLoans As DataGridView
    Friend WithEvents lblLoanID As Label
    Friend WithEvents txtLoanID As TextBox
End Class
