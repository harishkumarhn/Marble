 
CREATE TABLE dbo.InventoryPhysicalCountLog
(
ID int IDENTITY(1,1) PRIMARY KEY,
ProductId int NOT NULL,
LocationId int NULL,
PhysicalCountId int NOT NULL,
Quantity decimal(18, 4) NOT NULL,
AllocatedQuantity decimal(18, 4) NULL,
CreatedBy varchar (200) NULL,
CreatedDate datetime  NULL,
LastUpdatedBy varchar (200) NULL,
LastUpdatedDate datetime  NULL
)
