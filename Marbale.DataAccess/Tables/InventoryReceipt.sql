USE [MarbleMg]
GO


--drop table [InventoryReceipt]
 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--drop table InventoryReceipt

CREATE TABLE [dbo].[InventoryReceipt](
	[InventoryReceiptID] [int] IDENTITY(1,1) NOT NULL,
	[VendorBillNumber] [nvarchar](50) NULL,
	[GatePassNumber] [nvarchar](50) NULL,
	[GRN] [nvarchar](50) NULL,
	[PurchaseOrderId] [int] NOT NULL,
	[Remarks] [nvarchar](100) NULL,
	[ReceiveDate] [datetime] NOT NULL,
	[ReceivedBy] [nvarchar](50) NULL,
	[IsActive] bit  not NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastupdatedBy] [nvarchar](50) NULL,
	[LastupdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[InventoryReceiptID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[InventoryReceipt]  WITH CHECK ADD FOREIGN KEY([PurchaseOrderId])
REFERENCES [dbo].[PurchaseOrder] ([PurchaseOrderId])
GO


