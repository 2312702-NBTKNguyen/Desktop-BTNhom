-- Library.sql
IF DB_ID('Library') IS NULL
    CREATE DATABASE Library;
GO

USE Library;
GO

IF OBJECT_ID('Books', 'U') IS NOT NULL
    DROP TABLE Books;
GO

CREATE TABLE Books (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(500) NOT NULL,
    Author NVARCHAR(255),
    Topic NVARCHAR(100),
    Publisher NVARCHAR(255),
    PublishDate DATE,
    DateAdded DATETIME DEFAULT GETDATE(),
    FileSizeMB DECIMAL(6,2),
    PageCount INT,
    FilePath NVARCHAR(1000),
    CoverImagePath NVARCHAR(1000),
    Description NVARCHAR(MAX),
    IsRead BIT DEFAULT 0,
    Rating TINYINT CHECK (Rating BETWEEN 0 AND 5) DEFAULT 0,
    Notes NVARCHAR(MAX)
);
GO

-- 📚 5 SÁCH MẪU — đầy đủ dữ liệu demo
INSERT INTO Books (Title, Author, Topic, Publisher, PublishDate, FileSizeMB, PageCount, 
                   FilePath, CoverImagePath, Description, IsRead, Rating, Notes)
VALUES
-- 1. Sách lập trình — đã đọc, có file PDF, ảnh bìa
(N'Lập trình C# từ cơ bản đến nâng cao', 
 N'Nguyễn Tiến Đạt', 
 N'Programming', 
 N'Nhà xuất bản Giáo dục', 
 '2023-08-15', 
 4.32, 328, 
 N'AppData\Books\book_a1b2c3.pdf', 
 N'AppData\Covers\cover_x1y2z3.jpg', 
 N'Cuốn sách toàn diện về C# 10 và .NET 6, phù hợp sinh viên và người mới.', 
 1, 5, 
 N'Rất hay, giải thích rõ ràng.'),

-- 2. Sách fiction — chưa đọc
(N'Harry Potter và Chiếc Cốc Lửa', 
 N'J.K. Rowling', 
 N'Fiction', 
 N'NXB Trẻ', 
 '2001-07-08', 
 3.85, 636, 
 N'AppData\Books\hp_goblet.pdf', 
 N'AppData\Covers\hp_goblet.jpg', 
 N'Phần 4 trong loạt Harry Potter — gay cấn, hồi hộp.', 
 0, 4, 
 N'Chưa đọc, để dành cuối tuần.'),

-- 3. Self-help — đã đọc
(N'Đắc Nhân Tâm', 
 N'Dale Carnegie', 
 N'Self-Help', 
 N'Tổng hợp', 
 '1936-10-01', 
 2.15, 288, 
 N'AppData\Books\dcnt.pdf', 
 N'AppData\Covers\dcnt.jpg', 
 N'Kinh điển về kỹ năng giao tiếp và ứng xử.', 
 1, 5, 
 N'Đọc 3 lần, mỗi lần thấy điều mới.'),

-- 4. Khoa học — chưa đọc
(N'Vũ trụ trong vỏ hạt dẻ', 
 N'Stephen Hawking', 
 N'Science', 
 N'Nhà xuất bản Trẻ', 
 '2001-03-12', 
 5.67, 224, 
 N'AppData\Books\universe.pdf', 
 N'AppData\Covers\universe.jpg', 
 N'Giải thích vũ trụ học hiện đại một cách dễ hiểu.', 
 0, 4, 
 N'Khó, cần đọc từ từ.'),

-- 5. Kinh doanh — đã đọc
(N'Tư duy nhanh và chậm', 
 N'Daniel Kahneman', 
 N'Business', 
 N'NXB Lao Động', 
 '2011-10-25', 
 6.89, 499, 
 N'AppData\Books\thinking.pdf', 
 N'AppData\Covers\thinking.jpg', 
 N'Phân tích hai hệ thống tư duy: trực giác và lý trí.', 
 1, 5, 
 N'Ứng dụng vào công việc rất hiệu quả.');
GO