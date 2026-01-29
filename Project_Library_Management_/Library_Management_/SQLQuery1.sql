CREATE DATABASE LibraryDB;
GO -- GO: فاصل بين الأوامر (يستخدم في SSMS لتنفيذ مجموعة أوامر).
USE LibraryDB;
GO 

--2️⃣ جدول المستخدمين (Users)
CREATE TABLE dbo.Users (
  UserID INT IDENTITY(1,1) PRIMARY KEY,
  UserName NVARCHAR(50) NOT NULL UNIQUE,
  PasswordHash NVARCHAR(200) NOT NULL,
  Role NVARCHAR(30) NOT NULL DEFAULT 'User'
);
GO
--3️⃣ جدول الأعضاء (Members)
CREATE TABLE dbo.Members (
  MemberID INT IDENTITY(1,1) PRIMARY KEY,
  FullName NVARCHAR(100) NOT NULL,
  Phone NVARCHAR(30) NULL,
  Email NVARCHAR(100) NULL,
  CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);

GO   -- 👈 فاصل Batch

--4️⃣ جدول الكتب (Books)
CREATE TABLE dbo.Books (
  BookID INT IDENTITY(1,1) PRIMARY KEY,
  Title NVARCHAR(200) NOT NULL,
  Author NVARCHAR(100) NOT NULL,
  ISBN NVARCHAR(20) NULL UNIQUE,
  Copies INT NOT NULL DEFAULT 1,
  CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
GO   -- 👈 فاصل Batch

--5️⃣ جدول الإعارات (Loans)
CREATE TABLE dbo.Loans (
  LoanID INT IDENTITY(1,1) PRIMARY KEY,
  MemberID INT NOT NULL,
  BookID INT NOT NULL,
  LoanDate DATE NOT NULL DEFAULT GETDATE(),
  DueDate DATE NOT NULL,
  ReturnDate DATE NULL,
  CONSTRAINT FK_Loans_Members FOREIGN KEY (MemberID) REFERENCES dbo.Members(MemberID),
  CONSTRAINT FK_Loans_Books FOREIGN KEY (BookID) REFERENCES dbo.Books(BookID)
);
GO   -- 👈 فاصل Batch

--6️⃣ الفهارس (Indexes)
CREATE INDEX IX_Books_Title ON dbo.Books(Title);
CREATE INDEX IX_Books_Author ON dbo.Books(Author);
CREATE INDEX IX_Loans_MemberID ON dbo.Loans(MemberID);
CREATE INDEX IX_Loans_BookID ON dbo.Loans(BookID);

GO   -- 👈 فاصل Batch
--

--7️⃣ الإجراءات المخزنة (Stored Procedures)
-- إضافة كتاب
CREATE OR ALTER PROCEDURE dbo.sp_AddBook
  @Title NVARCHAR(200), @Author NVARCHAR(100), @ISBN NVARCHAR(20) = NULL, @Copies INT = 1
AS
BEGIN-- تمثل بداية ونهاية كتلة برمجية
-- هنا يتم تفعيل ( SET NOCOUNT O)
--بحيث تمنع السيرفر من إرسال رسائل "عدد الصفوف المتأثرة" للتطبيق، مما يوفر في استهلاك الشبكة ويرفع الأداء
  SET NOCOUNT ON; 
  INSERT INTO dbo.Books (Title, Author, ISBN, Copies)
  VALUES (@Title, @Author, @ISBN, @Copies);
END;
GO   -- 👈 فاصل Batch

-- تحديث كتاب
CREATE OR ALTER PROCEDURE dbo.sp_UpdateBook
  @BookID INT, @Title NVARCHAR(200), @Author NVARCHAR(100), @ISBN NVARCHAR(20), @Copies INT
AS
BEGIN-- تمثل بداية ونهاية كتلة برمجية
  SET NOCOUNT ON;
  UPDATE dbo.Books
    SET Title=@Title, Author=@Author, ISBN=@ISBN, Copies=@Copies
  WHERE BookID=@BookID;
END;
GO   -- 👈 فاصل Batch

-- إعارة كتاب
--2. إجراء الإعارة الذكي (sp_LoanBook) - المعالجة المعقدة
CREATE OR ALTER PROCEDURE dbo.sp_LoanBook -- 
  @MemberID INT, @BookID INT, @DueDate DATE
AS
BEGIN-- تمثل بداية ونهاية كتلة برمجية
  SET NOCOUNT ON;
  BEGIN TRAN; --  تعــني فتح السيرفر "معاملة" لضمان أن جميع الخطوات ستتم بنجاح أو تفشل جميعاً؛ لحماية سلامة البيانات BEGIN TRAN
  --فحص المخزون: يقوم الإجراء بفحص عدد النسخ المتاحة (IF Copies <= 0). إذا لم توجد نسخ، يتم إيقاف العملية وإرسال خطأ "لا توجد نسخ متاحة
    IF (SELECT Copies FROM dbo.Books WHERE BookID=@BookID) <= 0
    BEGIN-- تمثل بداية ونهاية كتلة برمجية
      RAISERROR(N'لا توجد نسخ متاحة', 16, 1);
      ROLLBACK TRAN;
      RETURN;
    END
    -- إذا نجح الفحص، يقوم السيرفر بـ:    IF (SELECT Copies FROM dbo.Books WHERE BookID=@BookID) <= 0
    --  1. يتم تسجيل سجل جديد في جدول Loans
    INSERT INTO dbo.Loans (MemberID, BookID, DueDate) --. إضافة سجل في جدول Loans.
    VALUES (@MemberID, @BookID, @DueDate);
    --    2. يتم خصم نسخة واحدة من جدول Books تلقائياً عبر أمر UPDATE
    -- كذالك هنا ()نضمن أن عدد النسخ لن يقل إلا إذا تم تسجيل الإعارة فعلياً، وهذا ما يسمى بـ "الذرية" (Atomicity) في المعاملات
    UPDATE dbo.Books SET Copies = Copies - 1 WHERE BookID=@BookID; -- تحديث جدول Books فوراً لخصم نسخة واحدة: UPDATE Books SET Copies = Copies - 1
    --• تثبيت العملية: يتم إنهاء المعاملة بـ COMMIT TRAN
  COMMIT TRAN; -- Loans + Bookهنا يتم اعتماد التثبيت للتغيرات الاتية للجداول مثل +++  تعني تثبيت المعاملة؛ أي حفظ جميع التغييرات التي تمت منذ BEGIN TRAN بشكل نهائي في قاعدة البيانات دون هذا الأمر، لن يتم اعتماد أي تغيير دائم في الجداول حتى لو نُفذت الأوامر برمجياً تُستخدم: في نهاية الكتلة البرمجية الناجحة داخل المعاملة
END;
GO   -- 👈 فاصل Batch

-- إرجاع كتاب
CREATE OR ALTER PROCEDURE dbo.sp_ReturnBook
  @LoanID INT
AS
BEGIN-- تمثل بداية ونهاية كتلة برمجية
  SET NOCOUNT ON;
  BEGIN TRAN;--الوظيفة: تعني بدء معاملة، وهي تضمن أن جميع الخطوات التالية ستُعامل كعملية واحدة لا تتجزأ بحيث  تحمي سلامة البيانات؛ فإما أن تنجح جميع الأوامر معاً أو تفشل معاً وتستخدم في العمليات الي توثر على اكثر من جدول مثل جدول الاعارات لضمان تسجيل الاعارة 
    DECLARE @BookID INT;
    SELECT @BookID = BookID FROM dbo.Loans WHERE LoanID=@LoanID;

    UPDATE dbo.Loans SET ReturnDate = GETDATE() WHERE LoanID=@LoanID;
    UPDATE dbo.Books SET Copies = Copies + 1 WHERE BookID=@BookID;
  COMMIT TRAN; --  تعني تثبيت المعاملة؛ أي حفظ جميع التغييرات التي تمت منذ BEGIN TRAN بشكل نهائي في قاعدة البيانات دون هذا الأمر، لن يتم اعتماد أي تغيير دائم في الجداول حتى لو نُفذت الأوامر برمجياً تُستخدم: في نهاية الكتلة البرمجية الناجحة داخل المعاملة
END;
GO   -- 👈 فاصل Batch

-- إجراء التحقق من الدخول (sp_CheckLogin) 
CREATE OR ALTER PROCEDURE dbo.sp_CheckLogin
  @User NVARCHAR(50), @Pass NVARCHAR(200)
AS
BEGIN-- تمثل بداية ونهاية كتلة برمجية
  SET NOCOUNT ON;
  SELECT COUNT(1) FROM dbo.Users WHERE UserName=@User AND PasswordHash=@Pass;--عيد السيرفر الرقم (1) في حال النجاح أو (0) في حال الفشل، وهي القيمة التي يستلمها الكود عبر
END;
GO   -- 👈 فاصل Batch


--

--

