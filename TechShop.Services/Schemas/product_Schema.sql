-- Create Product table


USE TechShopDB;USE TechShopDB;
GO

SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';
CREATE TABLE Product
(
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100),
    Description NVARCHAR(255),
    Price DECIMAL(10, 2) NOT NULL,
    InStock BIT NOT NULL,
    Category NVARCHAR(50),
    InventoryID INT,
    FOREIGN KEY (InventoryID) REFERENCES Inventory(InventoryID)
);
GO

 