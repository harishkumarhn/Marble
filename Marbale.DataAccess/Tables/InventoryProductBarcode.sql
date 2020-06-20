---   drop table InventoryProductBarcode
CREATE TABLE  InventoryProductBarcode (
	 ID   int  IDENTITY(1,1) NOT NULL,
	 BarCode   nvarchar (50) NOT NULL,
	 ProductId   int  NOT NULL references InventoryProduct(ProductId),
	 isActive   bit NOT NULL,
	CreatedBy   varchar (200) NULL,
	CreatedDate   datetime  NULL,
	LastUpdatedBy   varchar (200) NULL,
	LastUpdatedDate   datetime  NULL
) 


