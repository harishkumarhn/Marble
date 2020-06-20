USE [MarbleMg]
GO

--drop table PurchaseOrderLine

/****** Object:  Table [dbo].[PurchaseOrder_Line]    Script Date: 4/17/2020 9:21:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PurchaseOrderLine](
	[PurchaseOrderLineId] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseOrderId] [int] NOT NULL,
	[ItemCode] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Quantity] [decimal](18, 4) NOT NULL,
	[UnitPrice] [decimal](18, 5) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[TaxAmount] [decimal](18, 5) NULL,
	[DiscountPercentage] [numeric](8, 2) NULL,
	[RequiredByDate] [datetime] NULL,
	[ProductId] [int] NOT NULL,
	[IsActive] bit  not NULL,
	[CancelledDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastupdatedBy] [nvarchar](50) NULL,
	[LastupdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PurchaseOrderLineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PurchaseOrderLine]  WITH CHECK ADD FOREIGN KEY([PurchaseOrderId])
REFERENCES [dbo].[PurchaseOrder] ([PurchaseOrderId])
GO


