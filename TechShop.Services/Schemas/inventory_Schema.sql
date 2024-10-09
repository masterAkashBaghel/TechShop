-- Create Inventory table

USE TechShopDB;

CREATE TABLE Inventory
(
    InventoryID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    QuantityInStock INT NOT NULL,
    LastStockUpdate DATETIME NOT NULL,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
); 
 