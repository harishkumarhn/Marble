
CREATE TABLE [dbo].[InventoryProduct](
	[ProductId] [int] IDENTITY(1,1) primary key,
	[Code] [nvarchar](50) NOT NULL,
	[ProductName] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[Remarks] [nvarchar](max) NULL,
	[BarCode] [nvarchar](50) NULL,
	[CategoryId] [int] NULL references Category(CategoryId),
	[UomId] [int] NULL references UnitOfMeasure (UomId),
	[DefaultVendorId] [int] NULL  references Vendor(VendorId),
	[DefaultLocationId] [int] NULL  references Location(LocationId),
	[TaxId] [int] NULL references PurchaseTax (TaxId),
	[OutboundLocationId] [int] NULL references Location(LocationId),
	[ReorderPoint] [decimal](18, 4) NULL,
	[ReorderQuantity] [decimal](18, 4) NULL,
	[PriceInTickets] [decimal](18, 5) NULL,
	[MasterPackQty] [decimal](18, 4) NULL,
	[TaxInclusiveCost] [bit] NULL,
	[IsPurchaseable] [bit] NULL,
	[IsSellable] [bit] NULL,
	 
	[IsActive] [bit] NOT NULL,
	[IsRedeemable] [bit] NULL,
	 
	[InnerPackQty] [decimal](18, 4) NULL,
	[LowerLimitCost] [decimal](18, 4) NULL,
	[CostVariancePercentage] [decimal](6, 2) NULL,
	[SalePrice] [numeric](18, 2) NULL,
	[Cost] [decimal](18, 4) NULL,
	[UpperLimitCost] [decimal](18, 4) NULL,
	[LastPurchasePrice] [decimal](18, 4) NULL,
	[TurnInPriceInTickets] [int] NULL,
 
	[CreatedBy] [varchar](200) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [varchar](200) NULL,
	[LastUpdatedDate] [datetime] NULL
)  