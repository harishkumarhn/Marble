USE [Marbale]
GO
/****** Object:  Table [dbo].[ValuesButtons]    Script Date: 7/7/2019 3:19:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ValuesButtons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ButtonId] [varchar](max) NULL,
	[Class] [varchar](max) NULL,
	[Tittle] [varchar](max) NULL,
	[MethodName] [varchar](max) NULL,
	[Text] [varchar](max) NULL,
	[Active] [bit] NULL,
	[BRTag] [nvarchar](100) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ValuesButtons] ON 
GO
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (1, N'postab', N'tablinks', N'get pos info', N'getposdetails()', N'POS', 1, N'')
GO
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (2, N'cardtab', N'tablinks', N'get card info', N'getCardDetails()', N'Card', 1, N'')
GO
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (3, N'limittab', N'tablinks', N'get Limit Info', N'getLimitDetails()', N'Limits', 1, N'')
GO
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (4, N'Transactiontab', N'tablinks', N'get Transaction Info', N'getTransactionDetails()', N'Transaction', 1, N'')
GO
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (12, N'Inventorytab', N'tablinks', N'Get Inventory Info', N'getInventoryInfo()', N'Inventory', 1, N'')
GO
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (13, N'redemptiontab', N'tablinks', N'Get Redumptions info', N'getRedInfo()', N'Redemptions', 1, N'')
GO
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (14, N'paymenttab', N'tablinks', N'Get Payment Info', N'getPaymentInfo()', N'Payment', 1, N'')
GO
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (5, N'Emailtab', N'tablinks', N'get Email Info', N'getEmailDetails()', N'Email', 1, N'')
GO
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (6, N'Signagetab', N'tablinks', N'get Signage Info', N'getSignageDetails()', N'Signage', 1, N'')
GO
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (7, N'Servertab', N'tablinks', N'get Server Info', N'getServerDetails()', N'Server', 1, N'')
GO
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (8, N'backuptab', N'tablinks', N'Get Backup Info', N'getBackupDetails()', N'Backup and Restore', 1, N'')
GO
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (9, N'pricetab', N'tablinks', N'Get Price Info', N'getPriceDetails()', N'Price', 1, N'')
GO
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (10, N'printtab', N'tablinks', N'Get Print Info', N'getPrintDetails()', N'Print', 1, N'')
GO
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (11, N'formatstab', N'tablinks', N'Get Formats info', N'getFormatsInfo()', N'Formats', 1, N'')
GO
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (15, N'customertab', N'tablinks', N'Get Customer Info', N'getCustomerDetails()', N'Customer', 1, N'')
GO
SET IDENTITY_INSERT [dbo].[ValuesButtons] OFF
GO
