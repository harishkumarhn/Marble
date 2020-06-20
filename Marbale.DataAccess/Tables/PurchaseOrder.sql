USE [MarbleMg]
GO


--drop table PurchaseOrder
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 4/17/2020 9:21:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PurchaseOrder](
	[PurchaseOrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderStatus] [nvarchar](50) NOT NULL,
	[OrderNumber] [nvarchar](20) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[VendorId] [int] NOT NULL,
	[ContactName] [nvarchar](200) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[VendorAddress1] [nvarchar](200) NOT NULL,
	[VendorAddress2] [nvarchar](200) NULL,
	[VendorCity] [nvarchar](100) NOT NULL,
	[VendorState] [nvarchar](50) NOT NULL,
	[VendorCountry] [nvarchar](50) NOT NULL,
	[VendorPostalCode] [nvarchar](20) NOT NULL,
	[ShipToAddress1] [nvarchar](200) NULL,
	[ShipToAddress2] [nvarchar](200) NULL,
	[ShipToCity] [nvarchar](100) NULL,
	[ShipToState] [nvarchar](50) NULL,
	[ShipToCountry] [nvarchar](200) NULL,
	[ShipToPostalCode] [nvarchar](20) NULL,
	[ShipToAddressRemarks] [nvarchar](max) NULL,
	[RequestShipDate] [datetime] NULL,
	[OrderTotal] [decimal](18, 2) NOT NULL,
	[OrderRemarks] [nvarchar](max) NULL,
	[ReceiveRemarks] [nvarchar](200) NULL,
	[CancelledDate] [datetime] NULL,
	[IsActive] bit  not NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastupdatedBy] [nvarchar](50) NULL,
	[LastupdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PurchaseOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendor] ([VendorId])
GO


