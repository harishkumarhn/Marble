 --drop table InventoryAdjustments
CREATE TABLE  dbo . InventoryAdjustments (
	 Id   int IDENTITY(1,1)  PRIMARY KEY ,
	 AdjustmentType   nvarchar (50) NULL,
	 ProductId   int  NOT NULL references InventoryProduct(ProductId),
	 AdjustmentQuantity   numeric (18, 4) NULL,
	 FromLocationId   int  NULL references Location(LocationId),
	 ToLocationId   int  NULL references Location(LocationId),
	 Remarks   nvarchar (200) NULL,
	 CreatedBy   varchar (200) NULL,
	 CreatedDate   datetime  NULL,
	 LastUpdatedBy   varchar (200) NULL,
	 LastUpdatedDate   datetime  NULL,
	 IsActive bit not null
)
GO

 
  
    

