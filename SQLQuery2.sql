Create Database Library;

create Table BookCategories( CategoryId int Primary Key Identity(1,1
) Not null, CategoryName VarChar(100) Not Null, UpdatedOn DateTime not null,IsDeleted bit Not null);

INSERT INTO BookCategories (CategoryName, UpdatedOn, IsDeleted)
VALUES 
    ( 'IT', '2019-11-27', 'false'),
    ( 'Electronics', '2019-11-23', 'false'),
    ('Mechanical', '2019-11-22', 'false'),
    ( 'Civil', '2019-11-21', 'false'),
    ('Electricals', '2019-11-20', 'false'),
    ('Economics', '2019-11-02', 'true');

create Table Books (BookId int Primary Key Identity(1,1) Not null,BookName Varchar(100) Not null, AuthorName varchar(100),
PublishedYear int, Price decimal(6,2),UpdatedOn DATETIME NOT NULL,IsDeleted BIT NOT NULL, BookCategoryId INT NOT NULL,
CONSTRAINT FK_BookCategory FOREIGN KEY (BookCategoryId) REFERENCES BookCategories(CategoryId)) 

INSERT INTO Books (BookName, AuthorName, PublishedYear, Price, BookCategoryId, UpdatedOn, IsDeleted)
VALUES 
    ('C++', 'Balaguruswamy', 2001, 500, 1, '2019-11-27', 0),
    ('Microcontrollers', 'Mazidi', 2002, 550, 2, '2019-11-28', 0),
    ('Robotics', 'Sebastian', 2003, 600, 3, '2019-11-29', 0),
    ('Structural Engineering', 'Jacques Heyman', 2004, 800, 4, '2019-11-21', 0),
    ('DC Motors', 'Michael Faraday', 2004, 400, 5, '2019-11-01', 0),
    ('Economics', 'Nassim Nicholas', 2005, 300, 6, '2019-11-02', 1),
    ('Data Structure', NULL, NULL, 430, 1, '2019-11-03', 0),
    ('Operating Systems', 'Abraham Silberschatz', 2007, NULL, 1, '2019-11-04', 1),
    ('Digital Electronics', 'William Gothmann', NULL, NULL, 2, '2017-11-02', 0);
