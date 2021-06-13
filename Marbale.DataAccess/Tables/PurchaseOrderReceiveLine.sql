USE [Marbale]
GO
--drop table  [PurchaseOrderReceiveLine] 
/****** Object:  Table [dbo].[PurchaseOrderReceive_Line]    Script Date: 4/17/2020 9:21:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PurchaseOrderReceiveLine](
	[PurchaseOrderReceiveLineId] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseOrderId] [int] NULL,
	[ProductId] [int] NULL,
	[Description] [nvarchar](200) NOT NULL,
	[VendorItemCode] [nvarchar](100) NULL,
	[Quantity] [decimal](18, 4) NOT NULL,
	[LocationId] [int] NULL,
	[IsReceived] bit NOT NULL,
	[PurchaseOrderLineId] [int] NULL,
	[Price] [decimal](18, 4) NULL,
	[TaxPercentage] [decimal](8, 4) NULL,
	[Amount] [decimal](18, 4) NULL,
	[TaxInclusive] bit NULL,
	[TaxId] [int] NULL,
	[ReceiptId] [int] NOT NULL,
	[VendorBillNumber] [nvarchar](50) NULL,
	[ReceivedBy] [nvarchar](50) NULL,
	[IsActive] bit  not NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastupdatedBy] [nvarchar](50) NULL,
	[LastupdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PurchaseOrderReceiveLineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PurchaseOrderReceiveLine]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
GO

ALTER TABLE [dbo].[PurchaseOrderReceiveLine]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[InventoryProduct] ([ProductId])
GO

ALTER TABLE [dbo].[PurchaseOrderReceiveLine]  WITH CHECK ADD FOREIGN KEY([PurchaseOrderLineId])
REFERENCES [dbo].[PurchaseOrderLine] ([PurchaseOrderLineId])
GO

ALTER TABLE [dbo].[PurchaseOrderReceiveLine]  WITH CHECK ADD FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[InventoryReceipt] ([InventoryReceiptID])
GO


