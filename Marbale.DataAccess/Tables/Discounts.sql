USE [Marbale]
GO

/****** Object:  Table [dbo].[discounts]    Script Date: 1/13/2019 12:19:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[discounts](
	[discount_id] [int] IDENTITY(1,1) NOT NULL,
	[discount_name] [nvarchar](50) NOT NULL,
	[discount_percentage] [int] NULL,
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
	[Guid] [uniqueidentifier] NULL,
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

ALTER TABLE [dbo].[discounts] ADD  CONSTRAINT [DF_discounts_Guid]  DEFAULT (newid()) FOR [Guid]
GO


