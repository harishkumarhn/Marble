USE [Marbale]
GO

/****** Object:  Table [dbo].[Discounts]    Script Date: 14/09/2019 19:31:44 ******/
DROP TABLE [dbo].[Discounts]
GO

/****** Object:  Table [dbo].[Discounts]    Script Date: 14/09/2019 19:31:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Discounts](
	[discount_id] [int] IDENTITY(1,1) NOT NULL,
	[discount_name] [nvarchar](50) NOT NULL,
	[discount_percentage] [numeric](18, 3) NULL,
	[automatic_apply] [bit] NULL,
	[minimum_sale_amount] [float] NULL,
	[minimum_credits] [numeric](18, 0) NULL,
	[display_in_POS] [bit] NULL,
	[active_flag] [bit] NULL,
	[sort_order] [numeric](8, 0) NULL,
	[manager_approval_required] [bit] NULL,
	[last_updated_date] [datetime] NULL,
	[last_updated_user] [nvarchar](50) NULL,
	[InternetKey] [int] NULL,
	[discount_type] [char](1) NULL,
	[Guid] [uniqueidentifier] NULL CONSTRAINT [DF_discounts_Guid]  DEFAULT (newid()),
	[site_id] [int] NULL,
	[CouponMandatory] [bit] NULL,
	[SynchStatus] [bit] NULL,
	[DiscountAmount] [numeric](18, 4) NULL,
	[MasterEntityId] [int] NULL,
	[RemarksMandatory] [bit] NULL,
 CONSTRAINT [PK_Discounts] PRIMARY KEY CLUSTERED 
(
	[discount_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


