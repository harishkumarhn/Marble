
--drop table InventoryPhysicalCount
CREATE TABLE InventoryPhysicalCount(
	Id int IDENTITY(1,1)  PRIMARY KEY ,
	Description varchar(400) NOT NULL,
	Status varchar(10) NOT NULL,
	InitaitedDate datetime NOT NULL,
	ClosedDate datetime NULL,
	InitiatedBy nvarchar(50) NULL,
	ClosedBy nvarchar(50) NULL ,
	IsActive bit not null
) 

GO


