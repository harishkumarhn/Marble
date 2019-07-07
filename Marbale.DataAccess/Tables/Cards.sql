USE [Marbale]
GO

/****** Object:  Table [dbo].[Cards]    Script Date: 6/23/2019 12:07:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[Cards](
[CardId] [int] IDENTITY(1,1) NOT NULL,
[CardNumber] [varchar](50) NOT NULL,
[IssueDate] [datetime] NOT NULL,
[FaceValue] [float] NULL,
[RefundFlag] [bit] NULL,
[RefundAmount]  [decimal](18, 4) NULL,
[RefundDate] [datetime] NULL,
[ValidFlag] [bit] NULL,
[TicketCount] [int] NULL,
[Notes] [nvarchar](500) NULL,
[LastUpdated] [datetime] NULL,
[Credits] [decimal](18, 4) NULL,
[Courtesy] [decimal](18, 4) NULL,
[Bonus] [decimal](18, 4) NULL,
[CustomerId] [int] NULL,
[CreditsPlayed] [decimal](18, 4) NULL,
[TicketAllowed] [bit] NULL,
[RealTicketMode] [bit] NULL,
[VipCustomer] [bit] NULL,
[SiteId] [int] NULL,
[StartDateTtime] [datetime] NULL,
[LastTimePlayed] [datetime] NULL,
[TechnicianCard] [bit] NULL,
[TechGames] [int] NULL,
[TimerResetCard] [bit] NULL,
[LoyaltyPoints] [numeric](18, 4) NULL,
[LastUpdatedBy] [nvarchar](50) NULL,
[CardTypeId] [int] NULL,
[Guid] [uniqueidentifier] NULL,
[UploadSiteId] [int] NULL,
[UploadTime] [datetime] NULL,
[SynchStatus] [bit] NULL,
[ExpiryDate] [datetime] NULL,
[DownloadBatchId] [int] NULL,
[RefreshFromHQTime] [datetime] NULL,
 CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED 
(
[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cards] ADD  CONSTRAINT [DF_Cards_Guid]  DEFAULT (newid()) FOR [Guid]
GO

ALTER TABLE [dbo].[Cards]  WITH CHECK ADD  CONSTRAINT [FK_Cards_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO

ALTER TABLE [dbo].[Cards] CHECK CONSTRAINT [FK_Cards_Customers]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cards Master Table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cards'
GO