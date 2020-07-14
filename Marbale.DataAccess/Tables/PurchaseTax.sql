 
CREATE TABLE [dbo].[PurchaseTax](
	[TaxId] [int] IDENTITY(1,1) primary key,
	[TaxName] [nvarchar](50) NULL,
	[TaxPercentage] [decimal](5, 2) NOT NULL,
	IsActive bit  ,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastupdatedBy] [nvarchar](100) NULL,
	[LastupdatedDate] [datetime] NULL
 )
