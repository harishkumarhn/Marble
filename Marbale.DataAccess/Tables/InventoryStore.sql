 --drop table InventoryStore

CREATE TABLE dbo.InventoryStore(
	Id int Identity(1,1) Primary key,
	ProductId int NOT NULL  references InventoryProduct(ProductId),
	LocationId int NULL references Location(LocationId),
	Quantity decimal(18, 4) NOT NULL,
	AllocatedQuantity decimal(18, 4) NULL,
	Remarks nvarchar(100) NULL,
	IsActive bit not null ,
	CreatedBy   varchar (200) NULL,
	CreatedDate   datetime  NULL,
	LastUpdatedBy   varchar (200) NULL,
	LastUpdatedDate   datetime  NULL
	
	)
 
GO
 

 
 


