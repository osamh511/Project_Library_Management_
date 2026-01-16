<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBooks
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
        lblTitle = New Label()
        lblAuthor = New Label()
        lblISBN = New Label()
        lblCopies = New Label()
        lblSearch = New Label()
        txtTitle = New TextBox()
        txtAuthor = New TextBox()
        txtISBN = New TextBox()
        txtCopies = New TextBox()
        txtSearch = New TextBox()
        dgvBooks = New DataGridView()
        btnAdd = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnSearch = New Button()
        btnLoadDataSet = New Button()
        btnSaveDataSet = New Button()
        txtBookID = New TextBox()
        Label1 = New Label()
        btnMembers = New Button()
        btnLoans = New Button()
        CType(dgvBooks, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(173, 28)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(42, 15)
        lblTitle.TabIndex = 0
        lblTitle.Text = "العنوان"
        ' 
        ' lblAuthor
        ' 
        lblAuthor.AutoSize = True
        lblAuthor.Location = New Point(173, 61)
        lblAuthor.Name = "lblAuthor"
        lblAuthor.Size = New Size(43, 15)
        lblAuthor.TabIndex = 1
        lblAuthor.Text = "المؤلف"
        ' 
        ' lblISBN
        ' 
        lblISBN.AutoSize = True
        lblISBN.Location = New Point(183, 104)
        lblISBN.Name = "lblISBN"
        lblISBN.Size = New Size(32, 15)
        lblISBN.TabIndex = 2
        lblISBN.Text = "ISBN"
        ' 
        ' lblCopies
        ' 
        lblCopies.AutoSize = True
        lblCopies.Location = New Point(173, 133)
        lblCopies.Name = "lblCopies"
        lblCopies.Size = New Size(57, 15)
        lblCopies.TabIndex = 3
        lblCopies.Text = "عدد النسخ"
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(173, 169)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(67, 15)
        lblSearch.TabIndex = 4
        lblSearch.Text = "بحث العنوان"
        ' 
        ' txtTitle
        ' 
        txtTitle.Location = New Point(33, 25)
        txtTitle.Name = "txtTitle"
        txtTitle.Size = New Size(100, 23)
        txtTitle.TabIndex = 5
        ' 
        ' txtAuthor
        ' 
        txtAuthor.Location = New Point(33, 58)
        txtAuthor.Name = "txtAuthor"
        txtAuthor.Size = New Size(100, 23)
        txtAuthor.TabIndex = 6
        ' 
        ' txtISBN
        ' 
        txtISBN.Location = New Point(33, 98)
        txtISBN.Name = "txtISBN"
        txtISBN.Size = New Size(100, 23)
        txtISBN.TabIndex = 7
        ' 
        ' txtCopies
        ' 
        txtCopies.Location = New Point(33, 133)
        txtCopies.Name = "txtCopies"
        txtCopies.Size = New Size(100, 23)
        txtCopies.TabIndex = 8
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(33, 169)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(100, 23)
        txtSearch.TabIndex = 9
        ' 
        ' dgvBooks
        ' 
        dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBooks.Location = New Point(0, 303)
        dgvBooks.Name = "dgvBooks"
        dgvBooks.Size = New Size(808, 146)
        dgvBooks.TabIndex = 10
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(33, 221)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(75, 23)
        btnAdd.TabIndex = 11
        btnAdd.Text = "اضافة"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(140, 221)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(75, 23)
        btnUpdate.TabIndex = 12
        btnUpdate.Text = "تعديل"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(255, 221)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(75, 23)
        btnDelete.TabIndex = 13
        btnDelete.Text = "حذف"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(33, 274)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(75, 23)
        btnSearch.TabIndex = 14
        btnSearch.Text = "بحث"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' btnLoadDataSet
        ' 
        btnLoadDataSet.Location = New Point(124, 274)
        btnLoadDataSet.Name = "btnLoadDataSet"
        btnLoadDataSet.Size = New Size(106, 23)
        btnLoadDataSet.TabIndex = 15
        btnLoadDataSet.Text = "تحميل DataSet"
        btnLoadDataSet.UseVisualStyleBackColor = True
        ' 
        ' btnSaveDataSet
        ' 
        btnSaveDataSet.Location = New Point(255, 274)
        btnSaveDataSet.Name = "btnSaveDataSet"
        btnSaveDataSet.Size = New Size(99, 23)
        btnSaveDataSet.TabIndex = 16
        btnSaveDataSet.Text = "حفظ التعديلات"
        btnSaveDataSet.UseVisualStyleBackColor = True
        ' 
        ' txtBookID
        ' 
        txtBookID.Location = New Point(275, 28)
        txtBookID.Name = "txtBookID"
        txtBookID.Size = New Size(100, 23)
        txtBookID.TabIndex = 17
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(409, 36)
        Label1.Name = "Label1"
        Label1.Size = New Size(289, 15)
        Label1.TabIndex = 18
        Label1.Text = "لإدخال أو عرض رقم الكتاب (يُستخدم عند التعديل أو الحذف)"
        ' 
        ' btnMembers
        ' 
        btnMembers.Location = New Point(400, 221)
        btnMembers.Name = "btnMembers"
        btnMembers.Size = New Size(107, 23)
        btnMembers.TabIndex = 19
        btnMembers.Text = "ادارة الاعضاء "
        btnMembers.UseVisualStyleBackColor = True
        ' 
        ' btnLoans
        ' 
        btnLoans.Location = New Point(400, 274)
        btnLoans.Name = "btnLoans"
        btnLoans.Size = New Size(96, 23)
        btnLoans.TabIndex = 20
        btnLoans.Text = "ادارة الاعارات"
        btnLoans.UseVisualStyleBackColor = True
        ' 
        ' frmBooks
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnLoans)
        Controls.Add(btnMembers)
        Controls.Add(Label1)
        Controls.Add(txtBookID)
        Controls.Add(btnSaveDataSet)
        Controls.Add(btnLoadDataSet)
        Controls.Add(btnSearch)
        Controls.Add(btnDelete)
        Controls.Add(btnUpdate)
        Controls.Add(btnAdd)
        Controls.Add(dgvBooks)
        Controls.Add(txtSearch)
        Controls.Add(txtCopies)
        Controls.Add(txtISBN)
        Controls.Add(txtAuthor)
        Controls.Add(txtTitle)
        Controls.Add(lblSearch)
        Controls.Add(lblCopies)
        Controls.Add(lblISBN)
        Controls.Add(lblAuthor)
        Controls.Add(lblTitle)
        Name = "frmBooks"
        Text = "frmBooks"
        CType(dgvBooks, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblAuthor As Label
    Friend WithEvents lblISBN As Label
    Friend WithEvents lblCopies As Label
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents txtAuthor As TextBox
    Friend WithEvents txtISBN As TextBox
    Friend WithEvents txtCopies As TextBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents dgvBooks As DataGridView
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnLoadDataSet As Button
    Friend WithEvents btnSaveDataSet As Button
    Friend WithEvents txtBookID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnMembers As Button
    Friend WithEvents btnLoans As Button
End Class
