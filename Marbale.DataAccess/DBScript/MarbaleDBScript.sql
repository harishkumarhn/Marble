USE [master]
GO
/****** Object:  Database [Marbale]    Script Date: 12/4/2019 11:46:29 AM ******/
CREATE DATABASE [Marbale]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Marble', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Marble.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Marble_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Marble_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Marbale] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Marbale].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Marbale] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Marbale] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Marbale] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Marbale] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Marbale] SET ARITHABORT OFF 
GO
ALTER DATABASE [Marbale] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Marbale] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Marbale] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Marbale] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Marbale] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Marbale] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Marbale] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Marbale] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Marbale] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Marbale] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Marbale] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Marbale] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Marbale] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Marbale] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Marbale] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Marbale] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Marbale] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Marbale] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Marbale] SET  MULTI_USER 
GO
ALTER DATABASE [Marbale] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Marbale] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Marbale] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Marbale] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Marbale] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Marbale]
GO
/****** Object:  User [Marbale]    Script Date: 12/4/2019 11:46:31 AM ******/
CREATE USER [Marbale] FOR LOGIN [Marbale] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\DefaultAppPool]    Script Date: 12/4/2019 11:46:31 AM ******/
CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Marbale]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [Marbale]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [Marbale]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [Marbale]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [Marbale]
GO
ALTER ROLE [db_datareader] ADD MEMBER [Marbale]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [Marbale]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [Marbale]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [Marbale]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_datareader] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
/****** Object:  UserDefinedFunction [dbo].[SplitString]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SplitString]
(    
      @Input NVARCHAR(MAX),
      @Character CHAR(1)
)
RETURNS @Output TABLE (
      Item NVARCHAR(1000)
)
AS
BEGIN
      DECLARE @StartIndex INT, @EndIndex INT
 
      SET @StartIndex = 1
      IF SUBSTRING(@Input, LEN(@Input) - 1, LEN(@Input)) <> @Character
      BEGIN
            SET @Input = @Input + @Character
      END
 
      WHILE CHARINDEX(@Character, @Input) > 0
      BEGIN
            SET @EndIndex = CHARINDEX(@Character, @Input)
           
            INSERT INTO @Output(Item)
            SELECT SUBSTRING(@Input, @StartIndex, @EndIndex - 1)
           
            SET @Input = SUBSTRING(@Input, @EndIndex + 1, LEN(@Input))
      END
 
      RETURN
END
GO
/****** Object:  Table [dbo].[AppModule]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppModule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Module] [varchar](50) NULL,
	[Root] [varchar](50) NULL,
	[Page] [varchar](50) NULL,
	[URL] [varchar](500) NULL,
	[Active] [bit] NULL,
	[DisplayOrder] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Card]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Card](
	[CardId] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [varchar](50) NOT NULL,
	[IssueDate] [datetime] NOT NULL,
	[FaceValue] [float] NULL,
	[RefundFlag] [bit] NULL,
	[RefundAmount] [decimal](18, 4) NULL,
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
	[TechnicianCard] [int] NULL,
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
	[LastUpdatedTime] [datetime] NULL,
	[Custemer] [varchar](100) NULL,
	[Note] [varchar](100) NULL,
	[CreditPlus] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED 
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[Address1] [nvarchar](50) NULL,
	[Address2] [nvarchar](50) NULL,
	[Address3] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Pin] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[Gender] [char](1) NULL,
	[Anniversary] [datetime] NULL,
	[ContactPhone1] [nvarchar](50) NULL,
	[ContactPhone2] [nvarchar](50) NULL,
	[Notes] [nvarchar](max) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[LastUpdatedUser] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[CustomDataSetId] [int] NULL,
	[Company] [nvarchar](200) NULL,
	[Designation] [nvarchar](200) NULL,
	[PhotoFileName] [nvarchar](100) NULL,
	[Guid] [uniqueidentifier] NULL,
	[SiteId] [int] NULL,
	[UniqueID] [varchar](100) NULL,
	[Username] [nvarchar](50) NULL,
	[FBUserId] [nvarchar](20) NULL,
	[FBAccessToken] [nvarchar](20) NULL,
	[TWAccessToken] [nvarchar](20) NULL,
	[TWAccessSecret] [nvarchar](20) NULL,
	[RightHanded] [bit] NULL,
	[TeamUser] [bit] NULL,
	[SynchStatus] [bit] NULL,
	[Verified] [char](1) NULL,
	[Password] [nvarchar](100) NULL,
	[LastLoginTime] [datetime] NULL,
	[ExternalSystemRef] [nvarchar](50) NULL,
	[IsValid] [bit] NULL,
	[DownloadBatchId] [int] NULL,
	[IDProofFileName] [nvarchar](100) NULL,
	[Title] [nvarchar](20) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discounts]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discounts](
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
/****** Object:  Table [dbo].[DisplayGroup]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DisplayGroup](
	[DisplayGroupId] [int] IDENTITY(1,1) NOT NULL,
	[DisplayGroup] [nvarchar](300) NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
	[SortOrder] [int] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_DisplayGroup] PRIMARY KEY CLUSTERED 
(
	[DisplayGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](max) NULL,
	[GameProfile] [int] NULL,
	[NormalPrice] [int] NULL,
	[VIPPrice] [int] NULL,
	[RepeatPlayDiscountPercentage] [int] NULL,
	[GameCompanyName] [varchar](max) NULL,
	[Notes] [varchar](max) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[LastUpdatedBy] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameProfile]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameProfile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[NormalPrice] [int] NULL,
	[VIPPrice] [int] NULL,
	[CreditAllowed] [bit] NULL,
	[BonusAllowed] [bit] NULL,
	[CourtesyAllowed] [bit] NULL,
	[TimeAllowed] [bit] NULL,
	[TiketAllowedOnCredit] [bit] NULL,
	[TiketAllowedOnBonus] [bit] NULL,
	[TiketAllowedOnCourtesy] [bit] NULL,
	[TiketAllowedOnTime] [bit] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[LastUpdatedBy] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hub]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hub](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](500) NULL,
	[Frequency] [int] NULL,
	[Note] [varchar](max) NULL,
	[Active] [bit] NULL,
	[MacAddress] [varchar](50) NULL,
	[IPAddress] [varchar](50) NULL,
	[TCPPort] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NumberOfCards] [int] NULL,
	[Action] [varchar](10) NULL,
	[ActionDate] [datetime] NULL,
	[ActionBy] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListItem]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Machine]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Machine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[GameName] [varchar](50) NULL,
	[MachineAddress] [varchar](50) NULL,
	[EffectiveMachineAddress] [varchar](50) NULL,
	[Active] [bit] NULL,
	[ReaderType] [varchar](50) NULL,
	[SoftwareVersion] [varchar](50) NULL,
	[TicketMode] [varchar](50) NULL,
	[VIPPrice] [int] NULL,
	[TicketAllowed] [bit] NULL,
	[PurchasePrice] [int] NULL,
	[Notes] [varchar](max) NULL,
	[Theme] [varchar](100) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[LastUpdatedBy] [varchar](50) NULL,
	[HubName] [varchar](100) NULL,
	[HubAddress] [varchar](100) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageNo] [int] IDENTITY(1,1) NOT NULL,
	[MessageName] [nvarchar](max) NULL,
	[MessageDescription] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Printers]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Printers](
	[PrinterId] [int] IDENTITY(1,1) NOT NULL,
	[PrinterName] [nvarchar](500) NULL,
	[PrinterLocation] [nvarchar](100) NULL,
	[IPAddress] [nvarchar](50) NULL,
	[Remarks] [nvarchar](100) NULL,
	[Guid] [uniqueidentifier] NULL,
	[site_id] [int] NULL,
	[SynchStatus] [bit] NULL,
	[KDSTerminal] [bit] NULL,
	[MasterEntityId] [int] NULL,
 CONSTRAINT [PK_Printers] PRIMARY KEY CLUSTERED 
(
	[PrinterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
	[Type] [int] NULL,
	[POSCounter] [varchar](50) NULL,
	[Active] [bit] NULL,
	[DisplayInPOS] [bit] NULL,
	[DisplayGroupId] [int] NULL,
	[Category] [int] NULL,
	[AutoGenerateCardNumber] [bit] NULL,
	[OnlyVIP] [bit] NULL,
	[Price] [decimal](18, 3) NULL,
	[FaceValue] [decimal](18, 3) NULL,
	[TaxInclusive] [bit] NULL,
	[TaxPercentage] [decimal](18, 3) NULL,
	[FinalPrice] [decimal](18, 3) NULL,
	[EffectivePrice] [decimal](18, 3) NULL,
	[LastUpdatedBy] [varchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[Bonus] [decimal](18, 3) NULL,
	[LastUpdatedUser] [varchar](max) NULL,
	[TaxName] [varchar](max) NULL,
	[StartDate] [datetime] NULL,
	[Games] [decimal](18, 3) NULL,
	[CreditsPlus] [decimal](18, 3) NULL,
	[Credits] [decimal](18, 3) NULL,
	[CardValidFor] [int] NULL,
	[ExpiryDate] [datetime] NULL,
	[Courtesy] [bigint] NULL,
	[TaxId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Active] [bit] NULL,
	[ParentCategory] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductKey]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductKey](
	[SiteKey] [image] NULL,
	[LicenseKey] [image] NOT NULL,
	[FeatureKey] [image] NULL,
	[Guid] [uniqueidentifier] NULL,
	[site_id] [int] NULL,
	[SynchStatus] [bit] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ProductKey] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NULL,
	[Description] [varchar](500) NULL,
	[ReportGroup] [varchar](50) NULL,
	[CardSale] [bit] NULL,
	[Active] [bit] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[LastUpdatedBy] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiptPrintTemplate]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiptPrintTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Section] [nvarchar](50) NULL,
	[Sequence] [int] NOT NULL,
	[Col1Data] [nvarchar](100) NULL,
	[Col1Alignment] [nvarchar](1) NULL,
	[Col2Data] [nvarchar](100) NULL,
	[Col2Alignment] [nvarchar](1) NULL,
	[Col3Data] [nvarchar](100) NULL,
	[Col3Alignment] [nvarchar](1) NULL,
	[Col4Data] [nvarchar](100) NULL,
	[Col4Alignment] [nvarchar](1) NULL,
	[Col5Data] [nvarchar](100) NULL,
	[Col5Alignment] [nvarchar](1) NULL,
	[TemplateId] [int] NOT NULL,
	[Guid] [uniqueidentifier] NULL,
	[site_id] [int] NULL,
	[FontName] [nvarchar](50) NULL,
	[FontSize] [numeric](4, 2) NULL,
	[SynchStatus] [bit] NULL,
	[MasterEntityId] [int] NULL,
 CONSTRAINT [PK_ReceiptPrintTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiptPrintTemplateHeader]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiptPrintTemplateHeader](
	[TemplateId] [int] IDENTITY(1,1) NOT NULL,
	[TemplateName] [varchar](50) NOT NULL,
	[FontName] [nvarchar](50) NULL,
	[FontSize] [numeric](4, 2) NULL,
	[Guid] [uniqueidentifier] NULL,
	[site_id] [int] NULL,
	[SynchStatus] [bit] NULL,
	[MasterEntityId] [int] NULL,
 CONSTRAINT [PK_ReceiptPrintTemplateHeader] PRIMARY KEY CLUSTERED 
(
	[TemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleModuleAction]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleModuleAction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[PageId] [int] NULL,
	[Page] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[DefaultValue] [varchar](200) NULL,
	[Type] [varchar](100) NULL,
	[ScreenGroup] [varchar](50) NULL,
	[Active] [bit] NULL,
	[UserLevel] [bit] NULL,
	[PosLevel] [bit] NULL,
	[Protected] [bit] NULL,
	[LastUpdatedBy] [varchar](100) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[Caption] [varchar](250) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Site]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Site](
	[SiteId] [int] IDENTITY(1,1) NOT NULL,
	[SiteName] [nvarchar](50) NOT NULL,
	[SiteCode] [int] NULL,
	[SiteAddress] [nvarchar](500) NULL,
	[SiteGUID] [uniqueidentifier] NULL,
	[Notes] [nvarchar](500) NULL,
	[Logo] [varbinary](max) NULL,
	[Guid] [uniqueidentifier] NULL,
	[CompanyId] [int] NULL,
	[MaxCards] [nvarchar](100) NULL,
	[CustomerKey] [nvarchar](50) NULL,
	[Version] [nvarchar](50) NULL,
	[LastUpdatedTime] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskType]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskType](
	[TaskTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TaskType] [nvarchar](50) NULL,
	[TaskTypeName] [char](200) NULL,
	[RequiresManagerApproval] [bit] NULL,
	[DisplayInPOS] [bit] NULL,
 CONSTRAINT [PK_task_type] PRIMARY KEY CLUSTERED 
(
	[TaskTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tax]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tax](
	[TaxId] [int] IDENTITY(1,1) NOT NULL,
	[TaxName] [varchar](100) NULL,
	[TaxPercent] [decimal](18, 0) NULL,
	[ActiveFlag] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaxStructure]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxStructure](
	[TaxStructureId] [int] IDENTITY(1,1) NOT NULL,
	[TaxId] [int] NULL,
	[StructureName] [varchar](max) NULL,
	[TaxStructurePercentage] [decimal](18, 0) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TechCardType]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TechCardType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Active] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionDiscountLines]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionDiscountLines](
	[TrxDiscountId] [int] IDENTITY(1,1) NOT NULL,
	[TrxId] [int] NOT NULL,
	[LineId] [int] NOT NULL,
	[DiscountId] [int] NOT NULL,
	[DiscountPercentage] [decimal](18, 4) NULL,
	[DiscountAmount] [decimal](18, 4) NOT NULL,
	[Remarks] [nvarchar](100) NULL,
	[ApprovedBy] [int] NULL,
 CONSTRAINT [PK_TransactionDiscountLines] PRIMARY KEY CLUSTERED 
(
	[TrxDiscountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionHeader]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionHeader](
	[TrxId] [int] IDENTITY(1,1) NOT NULL,
	[TrxDate] [datetime] NOT NULL,
	[TrxAmount] [float] NULL,
	[TrxDiscountPercentage] [float] NULL,
	[TaxAmount] [float] NULL,
	[TrxNetAmount] [float] NULL,
	[POSMachine] [nvarchar](50) NULL,
	[UserId] [int] NULL,
	[PaymentMode] [int] NULL,
	[CashAmount] [float] NULL,
	[CreditCardAmount] [float] NULL,
	[GameCardAmount] [float] NULL,
	[PaymentReference] [nvarchar](100) NULL,
	[PrimaryCardId] [int] NULL,
	[OrderId] [int] NULL,
	[POSTypeId] [int] NULL,
	[Guid] [uniqueidentifier] NULL,
	[SiteId] [int] NULL,
	[TrxNummber] [nvarchar](20) NULL,
	[Remarks] [nvarchar](100) NULL,
	[POSMachineId] [int] NULL,
	[SynchStatus] [bit] NULL,
	[OtherPaymentModeAmount] [numeric](18, 4) NULL,
	[Status] [nvarchar](20) NULL,
	[TrxProfileId] [int] NULL,
	[LastUpdateTime] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[TokenNumber] [int] NULL,
	[Original_System_Reference] [nvarchar](100) NULL,
	[CustomerId] [int] NULL,
	[ExternalSystemReference] [nvarchar](200) NULL,
	[ReprintCount] [int] NULL,
	[OriginalTrxID] [int] NULL,
	[MasterEntityId] [int] NULL,
 CONSTRAINT [PK_TransactionHeader] PRIMARY KEY CLUSTERED 
(
	[TrxId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionLines]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionLines](
	[TrxId] [int] NOT NULL,
	[LineId] [int] NOT NULL,
	[ProductId] [int] NULL,
	[Price] [float] NULL,
	[Quantity] [numeric](10, 4) NULL,
	[Amount] [float] NULL,
	[CardId] [int] NULL,
	[CardNumber] [nvarchar](50) NULL,
	[Credits] [decimal](18, 4) NULL,
	[Courtesy] [decimal](18, 4) NULL,
	[TaxPercentage] [float] NULL,
	[TaxId] [int] NULL,
	[Time] [decimal](18, 4) NULL,
	[Bonus] [decimal](18, 4) NULL,
	[Tickets] [numeric](8, 0) NULL,
	[LoyaltyPoints] [decimal](18, 4) NULL,
	[Guid] [uniqueidentifier] NULL,
	[SiteId] [int] NULL,
	[Remarks] [nvarchar](100) NULL,
	[PromotionId] [int] NULL,
	[SynchStatus] [bit] NULL,
	[ReceiptPrinted] [bit] NULL,
	[ParentLineId] [int] NULL,
	[UserPrice] [bit] NULL,
	[KOTPrintCount] [int] NULL,
	[GameplayId] [int] NULL,
	[KDSSent] [bit] NULL,
	[CreditPlusConsumptionId] [int] NULL,
	[CancelledTime] [datetime] NULL,
	[CancelledBy] [nvarchar](50) NULL,
	[ProductDescription] [nvarchar](200) NULL,
	[IsWaiverSignRequired] [char](1) NULL,
	[OriginalLineID] [int] NULL,
	[MasterEntityId] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TransactionLines] SET (LOCK_ESCALATION = DISABLE)
GO
/****** Object:  Table [dbo].[TransactionTaxLines]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionTaxLines](
	[TrxId] [int] NOT NULL,
	[LineId] [int] NOT NULL,
	[TaxId] [int] NOT NULL,
	[TaxStructureId] [int] NULL,
	[Percentage] [numeric](18, 4) NOT NULL,
	[Amount] [numeric](18, 4) NOT NULL,
	[ProductSplitAmount] [numeric](18, 4) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[LoginId] [varchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[Role] [varchar](200) NULL,
	[Status] [varchar](max) NULL,
	[POSCounter] [varchar](500) NULL,
	[PasswordChangeDate] [datetime] NULL,
	[InvalidAttempts] [int] NULL,
	[Email] [varchar](200) NULL,
	[CompanyAdmin] [bit] NULL,
	[Department] [varchar](200) NULL,
	[Manager] [varchar](200) NULL,
	[EmpStartDate] [datetime] NULL,
	[EmpEndDate] [datetime] NULL,
	[EmpEndReason] [varchar](200) NULL,
	[LastLogInTime] [datetime] NULL,
	[LastLogOutTime] [datetime] NULL,
	[CreatationDate] [datetime] NULL,
	[CreatedBy] [varchar](500) NULL,
	[LastUpdatedBy] [varchar](500) NULL,
	[LastUpdatedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 12/4/2019 11:46:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](500) NULL,
	[Description] [varchar](max) NULL,
	[ManagerFlag] [bit] NULL,
	[AllowPOSAccess] [bit] NULL,
	[POSClockInOut] [bit] NULL,
	[AllowShiftOpenClose] [bit] NULL,
	[LastUpdatedBy] [varchar](500) NULL,
	[LastUpdatedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ValuesButtons]    Script Date: 12/4/2019 11:46:33 AM ******/
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
SET IDENTITY_INSERT [dbo].[AppModule] ON 

INSERT [dbo].[AppModule] ([Id], [Module], [Root], [Page], [URL], [Active], [DisplayOrder]) VALUES (5, N'Management Studio', N'Site Setup', N'Configuration', N'', 1, 2)
INSERT [dbo].[AppModule] ([Id], [Module], [Root], [Page], [URL], [Active], [DisplayOrder]) VALUES (2, N'Management Studio', N'Product', N'ProductSetup', N'', 1, 1)
INSERT [dbo].[AppModule] ([Id], [Module], [Root], [Page], [URL], [Active], [DisplayOrder]) VALUES (3, N'Management Studio', N'Product', N'Discount', N'', 1, 1)
INSERT [dbo].[AppModule] ([Id], [Module], [Root], [Page], [URL], [Active], [DisplayOrder]) VALUES (6, N'Management Studio', N'Site Setup', N'User', N'', 1, 2)
INSERT [dbo].[AppModule] ([Id], [Module], [Root], [Page], [URL], [Active], [DisplayOrder]) VALUES (7, N'Management Studio', N'Site Setup', N'User Role', N'', 1, 2)
INSERT [dbo].[AppModule] ([Id], [Module], [Root], [Page], [URL], [Active], [DisplayOrder]) VALUES (8, N'Reports', N'Manage Reports', N'Management', NULL, 1, 3)
INSERT [dbo].[AppModule] ([Id], [Module], [Root], [Page], [URL], [Active], [DisplayOrder]) VALUES (9, N'Reports', N'Manage Reports', N'Schedule', NULL, 1, 3)
INSERT [dbo].[AppModule] ([Id], [Module], [Root], [Page], [URL], [Active], [DisplayOrder]) VALUES (10, N'Reports', N'Run Report', N'CheckIn Detail', NULL, 1, 3)
SET IDENTITY_INSERT [dbo].[AppModule] OFF
SET IDENTITY_INSERT [dbo].[Card] ON 

INSERT [dbo].[Card] ([CardId], [CardNumber], [IssueDate], [FaceValue], [RefundFlag], [RefundAmount], [RefundDate], [ValidFlag], [TicketCount], [Notes], [LastUpdated], [Credits], [Courtesy], [Bonus], [CustomerId], [CreditsPlayed], [TicketAllowed], [RealTicketMode], [VipCustomer], [SiteId], [StartDateTtime], [LastTimePlayed], [TechnicianCard], [TechGames], [TimerResetCard], [LoyaltyPoints], [LastUpdatedBy], [CardTypeId], [Guid], [UploadSiteId], [UploadTime], [SynchStatus], [ExpiryDate], [DownloadBatchId], [RefreshFromHQTime], [LastUpdatedTime], [Custemer], [Note], [CreditPlus]) VALUES (1, N'100', CAST(N'2019-11-12T00:00:00.000' AS DateTime), 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), 1, 0, 0, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, NULL, N'7c1688e6-87d0-46fb-9ed2-65ae433b4f11', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2019-11-12T16:36:01.047' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Card] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerId], [CustomerName], [Address1], [Address2], [Address3], [City], [State], [Country], [Pin], [Email], [DateOfBirth], [Gender], [Anniversary], [ContactPhone1], [ContactPhone2], [Notes], [LastUpdatedDate], [LastUpdatedUser], [MiddleName], [LastName], [CustomDataSetId], [Company], [Designation], [PhotoFileName], [Guid], [SiteId], [UniqueID], [Username], [FBUserId], [FBAccessToken], [TWAccessToken], [TWAccessSecret], [RightHanded], [TeamUser], [SynchStatus], [Verified], [Password], [LastLoginTime], [ExternalSystemRef], [IsValid], [DownloadBatchId], [IDProofFileName], [Title]) VALUES (1, N'Harish', N'Address1', NULL, NULL, N'Bangalore', N'karnataka', N'india', NULL, N'harish@gmail.com', NULL, N'M', NULL, N'5555566666', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, N'a4ec20b4-b4f9-4880-b1d5-135ef61730b7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, N'N', NULL, NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[Customer] ([CustomerId], [CustomerName], [Address1], [Address2], [Address3], [City], [State], [Country], [Pin], [Email], [DateOfBirth], [Gender], [Anniversary], [ContactPhone1], [ContactPhone2], [Notes], [LastUpdatedDate], [LastUpdatedUser], [MiddleName], [LastName], [CustomDataSetId], [Company], [Designation], [PhotoFileName], [Guid], [SiteId], [UniqueID], [Username], [FBUserId], [FBAccessToken], [TWAccessToken], [TWAccessSecret], [RightHanded], [TeamUser], [SynchStatus], [Verified], [Password], [LastLoginTime], [ExternalSystemRef], [IsValid], [DownloadBatchId], [IDProofFileName], [Title]) VALUES (2, N'Raghu', N'ervf', NULL, NULL, N'df d', N'fvdf', N'fv ', NULL, N'dfv', NULL, N'M', NULL, N'9999999999', NULL, NULL, NULL, NULL, NULL, N'dfv df', 0, NULL, NULL, NULL, N'50dde730-237c-41ae-b395-96295bebd0a0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, N'N', NULL, NULL, NULL, 0, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Discounts] ON 

INSERT [dbo].[Discounts] ([discount_id], [discount_name], [discount_percentage], [automatic_apply], [minimum_sale_amount], [minimum_credits], [display_in_POS], [active_flag], [sort_order], [manager_approval_required], [last_updated_date], [last_updated_user], [InternetKey], [discount_type], [Guid], [site_id], [CouponMandatory], [SynchStatus], [DiscountAmount], [MasterEntityId], [RemarksMandatory]) VALUES (1, N'5% Discount', 5, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, N'T', N'ac46e795-c99a-4991-a128-c7e79d71aeda', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Discounts] ([discount_id], [discount_name], [discount_percentage], [automatic_apply], [minimum_sale_amount], [minimum_credits], [display_in_POS], [active_flag], [sort_order], [manager_approval_required], [last_updated_date], [last_updated_user], [InternetKey], [discount_type], [Guid], [site_id], [CouponMandatory], [SynchStatus], [DiscountAmount], [MasterEntityId], [RemarksMandatory]) VALUES (2, N'10% Discount', 10, 1, 0, CAST(0 AS Numeric(18, 0)), 1, 1, CAST(10 AS Numeric(8, 0)), 0, CAST(N'2019-09-22T22:53:58.473' AS DateTime), N'Shridhar Naik', NULL, N'T', NULL, NULL, 1, NULL, CAST(200.0000 AS Numeric(18, 4)), NULL, 0)
INSERT [dbo].[Discounts] ([discount_id], [discount_name], [discount_percentage], [automatic_apply], [minimum_sale_amount], [minimum_credits], [display_in_POS], [active_flag], [sort_order], [manager_approval_required], [last_updated_date], [last_updated_user], [InternetKey], [discount_type], [Guid], [site_id], [CouponMandatory], [SynchStatus], [DiscountAmount], [MasterEntityId], [RemarksMandatory]) VALUES (3, N'15% Discount', 15, 1, 0, CAST(0 AS Numeric(18, 0)), 1, 1, CAST(10 AS Numeric(8, 0)), 0, CAST(N'2019-09-22T22:55:32.090' AS DateTime), N'Shridhar Naik', NULL, N'T', NULL, NULL, 1, NULL, CAST(200.0000 AS Numeric(18, 4)), NULL, 0)
INSERT [dbo].[Discounts] ([discount_id], [discount_name], [discount_percentage], [automatic_apply], [minimum_sale_amount], [minimum_credits], [display_in_POS], [active_flag], [sort_order], [manager_approval_required], [last_updated_date], [last_updated_user], [InternetKey], [discount_type], [Guid], [site_id], [CouponMandatory], [SynchStatus], [DiscountAmount], [MasterEntityId], [RemarksMandatory]) VALUES (4, N'20% Discount', 20, 1, 0, CAST(0 AS Numeric(18, 0)), 1, 1, NULL, NULL, NULL, NULL, NULL, N'T', N'aa194ae6-fedc-4ee7-bf43-bfa2e45a81ea', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Discounts] ([discount_id], [discount_name], [discount_percentage], [automatic_apply], [minimum_sale_amount], [minimum_credits], [display_in_POS], [active_flag], [sort_order], [manager_approval_required], [last_updated_date], [last_updated_user], [InternetKey], [discount_type], [Guid], [site_id], [CouponMandatory], [SynchStatus], [DiscountAmount], [MasterEntityId], [RemarksMandatory]) VALUES (5, N'25% Discount', 25, 1, 0, CAST(0 AS Numeric(18, 0)), 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, N'a561179f-e43f-4335-b274-04bc979fb015', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Discounts] OFF
SET IDENTITY_INSERT [dbo].[Game] ON 

INSERT [dbo].[Game] ([Id], [Name], [Description], [GameProfile], [NormalPrice], [VIPPrice], [RepeatPlayDiscountPercentage], [GameCompanyName], [Notes], [LastUpdatedDate], [LastUpdatedBy]) VALUES (1, N'Test game', N'desc', 2, 100, 500, 0, N'cm', N'npt', CAST(N'2019-09-08T01:10:38.330' AS DateTime), N'Sep  8 2019  1:10AM')
INSERT [dbo].[Game] ([Id], [Name], [Description], [GameProfile], [NormalPrice], [VIPPrice], [RepeatPlayDiscountPercentage], [GameCompanyName], [Notes], [LastUpdatedDate], [LastUpdatedBy]) VALUES (2, N't2', N'jndj', 1, 0, 0, 0, N'', N'', CAST(N'2019-09-08T01:16:24.037' AS DateTime), N'')
SET IDENTITY_INSERT [dbo].[Game] OFF
SET IDENTITY_INSERT [dbo].[GameProfile] ON 

INSERT [dbo].[GameProfile] ([Id], [Name], [NormalPrice], [VIPPrice], [CreditAllowed], [BonusAllowed], [CourtesyAllowed], [TimeAllowed], [TiketAllowedOnCredit], [TiketAllowedOnBonus], [TiketAllowedOnCourtesy], [TiketAllowedOnTime], [LastUpdatedDate], [LastUpdatedBy]) VALUES (1, N'Test0', 200, 500, 0, 1, 0, 0, 0, 0, 0, 0, CAST(N'2019-04-18T21:18:05.120' AS DateTime), N'Apr 18 2019  9:18PM')
INSERT [dbo].[GameProfile] ([Id], [Name], [NormalPrice], [VIPPrice], [CreditAllowed], [BonusAllowed], [CourtesyAllowed], [TimeAllowed], [TiketAllowedOnCredit], [TiketAllowedOnBonus], [TiketAllowedOnCourtesy], [TiketAllowedOnTime], [LastUpdatedDate], [LastUpdatedBy]) VALUES (2, N'Test1', 40, 50, 1, 1, 1, 1, 1, 1, 1, 1, CAST(N'2019-04-18T21:18:21.620' AS DateTime), N'Apr 18 2019  9:18PM')
INSERT [dbo].[GameProfile] ([Id], [Name], [NormalPrice], [VIPPrice], [CreditAllowed], [BonusAllowed], [CourtesyAllowed], [TimeAllowed], [TiketAllowedOnCredit], [TiketAllowedOnBonus], [TiketAllowedOnCourtesy], [TiketAllowedOnTime], [LastUpdatedDate], [LastUpdatedBy]) VALUES (3, N'Test0', 12345689, 50, 1, 1, 1, 1, 1, 1, 1, 1, CAST(N'2019-10-26T16:01:20.710' AS DateTime), N'')
INSERT [dbo].[GameProfile] ([Id], [Name], [NormalPrice], [VIPPrice], [CreditAllowed], [BonusAllowed], [CourtesyAllowed], [TimeAllowed], [TiketAllowedOnCredit], [TiketAllowedOnBonus], [TiketAllowedOnCourtesy], [TiketAllowedOnTime], [LastUpdatedDate], [LastUpdatedBy]) VALUES (4, N'Test1', 2, 4, 1, 1, 1, 1, 1, 1, 1, 1, CAST(N'2019-10-26T16:01:20.770' AS DateTime), N'')
INSERT [dbo].[GameProfile] ([Id], [Name], [NormalPrice], [VIPPrice], [CreditAllowed], [BonusAllowed], [CourtesyAllowed], [TimeAllowed], [TiketAllowedOnCredit], [TiketAllowedOnBonus], [TiketAllowedOnCourtesy], [TiketAllowedOnTime], [LastUpdatedDate], [LastUpdatedBy]) VALUES (5, N't2', 2, 3, 1, 1, 1, 0, 0, 0, 0, 0, CAST(N'2019-10-26T16:03:37.093' AS DateTime), N'')
SET IDENTITY_INSERT [dbo].[GameProfile] OFF
SET IDENTITY_INSERT [dbo].[Hub] ON 

INSERT [dbo].[Hub] ([Id], [Name], [Address], [Frequency], [Note], [Active], [MacAddress], [IPAddress], [TCPPort]) VALUES (1, N'Hub 1', N'1st Floor', 800, N'1st Floor', 1, N'0', N'', 0)
INSERT [dbo].[Hub] ([Id], [Name], [Address], [Frequency], [Note], [Active], [MacAddress], [IPAddress], [TCPPort]) VALUES (2, N'Hub 2', N'2nd Floor', 999, N'2nd Floor', 1, N'mac', N'ip', 0)
INSERT [dbo].[Hub] ([Id], [Name], [Address], [Frequency], [Note], [Active], [MacAddress], [IPAddress], [TCPPort]) VALUES (3, N'Hub 3', N'3rd Floor', 666, N'3rd Floor', 1, N'192.2.3.3', N'0.0.0.0', 8080)
INSERT [dbo].[Hub] ([Id], [Name], [Address], [Frequency], [Note], [Active], [MacAddress], [IPAddress], [TCPPort]) VALUES (4, N'Hub 4', N'4th floor', 434, N'4th floor', 1, N'2', N'1.1', 8080)
SET IDENTITY_INSERT [dbo].[Hub] OFF
SET IDENTITY_INSERT [dbo].[ListItem] ON 

INSERT [dbo].[ListItem] ([Id], [GroupId], [Name]) VALUES (3, 1, N'POS')
INSERT [dbo].[ListItem] ([Id], [GroupId], [Name]) VALUES (4, 1, N'Inventory')
INSERT [dbo].[ListItem] ([Id], [GroupId], [Name]) VALUES (5, 1, N'Admin')
SET IDENTITY_INSERT [dbo].[ListItem] OFF
SET IDENTITY_INSERT [dbo].[Machine] ON 

INSERT [dbo].[Machine] ([Id], [Name], [GameName], [MachineAddress], [EffectiveMachineAddress], [Active], [ReaderType], [SoftwareVersion], [TicketMode], [VIPPrice], [TicketAllowed], [PurchasePrice], [Notes], [Theme], [LastUpdatedDate], [LastUpdatedBy], [HubName], [HubAddress]) VALUES (18, N'MCH-Hockey', N'Hockey', N'M1', N'E1', 1, N'Reader2', N'1.0', N'i', 90, 1, 10, N'note', N'Theme1', CAST(N'2019-09-07T16:42:35.797' AS DateTime), N'', N'Hub 1', N'H1')
INSERT [dbo].[Machine] ([Id], [Name], [GameName], [MachineAddress], [EffectiveMachineAddress], [Active], [ReaderType], [SoftwareVersion], [TicketMode], [VIPPrice], [TicketAllowed], [PurchasePrice], [Notes], [Theme], [LastUpdatedDate], [LastUpdatedBy], [HubName], [HubAddress]) VALUES (19, N'MCH-FGame', N'FGame', N'', N'', 0, N'Select', N'', N'', 0, 0, 0, N'', N'Select', CAST(N'2019-09-07T17:00:54.567' AS DateTime), N'', N'Hub 2', N'k')
SET IDENTITY_INSERT [dbo].[Machine] OFF
SET IDENTITY_INSERT [dbo].[Printers] ON 

INSERT [dbo].[Printers] ([PrinterId], [PrinterName], [PrinterLocation], [IPAddress], [Remarks], [Guid], [site_id], [SynchStatus], [KDSTerminal], [MasterEntityId]) VALUES (5, N'New', N'bangalore', N'1.99', N'remarks', NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Printers] ([PrinterId], [PrinterName], [PrinterLocation], [IPAddress], [Remarks], [Guid], [site_id], [SynchStatus], [KDSTerminal], [MasterEntityId]) VALUES (6, N'Test1', N'location', N'ip', N'r1', NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Printers] ([PrinterId], [PrinterName], [PrinterLocation], [IPAddress], [Remarks], [Guid], [site_id], [SynchStatus], [KDSTerminal], [MasterEntityId]) VALUES (7, N'Test123', N'location', N'ip', N'r1', NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Printers] ([PrinterId], [PrinterName], [PrinterLocation], [IPAddress], [Remarks], [Guid], [site_id], [SynchStatus], [KDSTerminal], [MasterEntityId]) VALUES (8, N'Test111', N'location', N'ip', N'r1', NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Printers] ([PrinterId], [PrinterName], [PrinterLocation], [IPAddress], [Remarks], [Guid], [site_id], [SynchStatus], [KDSTerminal], [MasterEntityId]) VALUES (9, N'Test111222', N'location', N'ip', N'r1', NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Printers] ([PrinterId], [PrinterName], [PrinterLocation], [IPAddress], [Remarks], [Guid], [site_id], [SynchStatus], [KDSTerminal], [MasterEntityId]) VALUES (10, N'Test123456', N'location', N'ip', N'r1', NULL, NULL, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Printers] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Type], [POSCounter], [Active], [DisplayInPOS], [DisplayGroupId], [Category], [AutoGenerateCardNumber], [OnlyVIP], [Price], [FaceValue], [TaxInclusive], [TaxPercentage], [FinalPrice], [EffectivePrice], [LastUpdatedBy], [LastUpdatedDate], [Bonus], [LastUpdatedUser], [TaxName], [StartDate], [Games], [CreditsPlus], [Credits], [CardValidFor], [ExpiryDate], [Courtesy], [TaxId]) VALUES (1, N'Pizza', 18, N'1', 1, 1, 0, 1, 1, 1, CAST(1.000 AS Decimal(18, 3)), CAST(1.000 AS Decimal(18, 3)), 1, CAST(15.000 AS Decimal(18, 3)), CAST(1.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, CAST(N'2019-10-20T23:45:56.490' AS DateTime), NULL, N'', N'2', CAST(N'2019-10-20T23:45:56.490' AS DateTime), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, 0, CAST(N'2020-10-10T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[Product] ([Id], [Name], [Type], [POSCounter], [Active], [DisplayInPOS], [DisplayGroupId], [Category], [AutoGenerateCardNumber], [OnlyVIP], [Price], [FaceValue], [TaxInclusive], [TaxPercentage], [FinalPrice], [EffectivePrice], [LastUpdatedBy], [LastUpdatedDate], [Bonus], [LastUpdatedUser], [TaxName], [StartDate], [Games], [CreditsPlus], [Credits], [CardValidFor], [ExpiryDate], [Courtesy], [TaxId]) VALUES (2, N'Burger', 15, N'1', 1, 1, 0, 1, 1, 1, CAST(2000.000 AS Decimal(18, 3)), CAST(3000.000 AS Decimal(18, 3)), 1, CAST(13000.000 AS Decimal(18, 3)), CAST(100.000 AS Decimal(18, 3)), CAST(2000.000 AS Decimal(18, 3)), NULL, CAST(N'2019-11-16T18:08:11.767' AS DateTime), NULL, N'', N'1', CAST(N'2019-11-16T18:08:11.767' AS DateTime), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, 0, CAST(N'2020-10-10T00:00:00.000' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([Id], [Name], [Active], [ParentCategory]) VALUES (1, N'Software Game', 1, N'Software Game')
INSERT [dbo].[ProductCategory] ([Id], [Name], [Active], [ParentCategory]) VALUES (2, N'Harware Game', 1, N'Harware Game')
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
SET IDENTITY_INSERT [dbo].[ProductKey] ON 

INSERT [dbo].[ProductKey] ([SiteKey], [LicenseKey], [FeatureKey], [Guid], [site_id], [SynchStatus], [Id]) VALUES (0x475253, 0x4442686D316770696A7248716A334E646730484F657A726654505379435A6A4B4D2F65363036457247556B3D, NULL, N'e8742033-3676-4bed-b26d-5c53ce018b9d', 1, NULL, 1)
SET IDENTITY_INSERT [dbo].[ProductKey] OFF
SET IDENTITY_INSERT [dbo].[ProductType] ON 

INSERT [dbo].[ProductType] ([Id], [Type], [Description], [ReportGroup], [CardSale], [Active], [LastUpdatedDate], [LastUpdatedBy]) VALUES (15, N'Video Game', N'mobile friendly games', N'POS', 1, 1, CAST(N'2019-10-02T16:32:59.877' AS DateTime), N'Harish')
INSERT [dbo].[ProductType] ([Id], [Type], [Description], [ReportGroup], [CardSale], [Active], [LastUpdatedDate], [LastUpdatedBy]) VALUES (16, N'Out door Game', N'Basket Ball', N'POS', 1, 1, CAST(N'2019-10-02T16:33:39.250' AS DateTime), N'Harish')
INSERT [dbo].[ProductType] ([Id], [Type], [Description], [ReportGroup], [CardSale], [Active], [LastUpdatedDate], [LastUpdatedBy]) VALUES (17, N'Manual', N'non card product', N'POS', 1, 1, CAST(N'2019-10-06T16:16:40.187' AS DateTime), N'Harish')
INSERT [dbo].[ProductType] ([Id], [Type], [Description], [ReportGroup], [CardSale], [Active], [LastUpdatedDate], [LastUpdatedBy]) VALUES (18, N'NEW', N'new Card Product', N'new Card Product', 1, 1, CAST(N'2019-10-20T17:13:39.797' AS DateTime), N'Harish')
SET IDENTITY_INSERT [dbo].[ProductType] OFF
SET IDENTITY_INSERT [dbo].[ReceiptPrintTemplate] ON 

INSERT [dbo].[ReceiptPrintTemplate] ([Id], [Section], [Sequence], [Col1Data], [Col1Alignment], [Col2Data], [Col2Alignment], [Col3Data], [Col3Alignment], [Col4Data], [Col4Alignment], [Col5Data], [Col5Alignment], [TemplateId], [Guid], [site_id], [FontName], [FontSize], [SynchStatus], [MasterEntityId]) VALUES (20, N'a', 0, N'', N'H', N'', N'H', N'', N'H', N'', N'H', N'', N'H', 37, N'33963b42-3124-43e6-b601-47c8579b11f0', NULL, N'auto', CAST(0.00 AS Numeric(4, 2)), NULL, NULL)
SET IDENTITY_INSERT [dbo].[ReceiptPrintTemplate] OFF
SET IDENTITY_INSERT [dbo].[ReceiptPrintTemplateHeader] ON 

INSERT [dbo].[ReceiptPrintTemplateHeader] ([TemplateId], [TemplateName], [FontName], [FontSize], [Guid], [site_id], [SynchStatus], [MasterEntityId]) VALUES (37, N'aa', N'auto', CAST(8.00 AS Numeric(4, 2)), N'25bc8bb5-e4dc-4c86-a70c-a3e1c21c56c6', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ReceiptPrintTemplateHeader] OFF
SET IDENTITY_INSERT [dbo].[RoleModuleAction] ON 

INSERT [dbo].[RoleModuleAction] ([Id], [RoleId], [PageId], [Page]) VALUES (14, 1, 5, N'Configuration')
INSERT [dbo].[RoleModuleAction] ([Id], [RoleId], [PageId], [Page]) VALUES (15, 1, 6, N'User')
INSERT [dbo].[RoleModuleAction] ([Id], [RoleId], [PageId], [Page]) VALUES (16, 1, 7, N'User Role')
INSERT [dbo].[RoleModuleAction] ([Id], [RoleId], [PageId], [Page]) VALUES (17, 3, 2, N'ProductSetup')
INSERT [dbo].[RoleModuleAction] ([Id], [RoleId], [PageId], [Page]) VALUES (18, 3, 3, N'Discount')
SET IDENTITY_INSERT [dbo].[RoleModuleAction] OFF
SET IDENTITY_INSERT [dbo].[Settings] ON 

INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (571, N'Card_Reader_VID', N'Card Reader VID', N'FFF', N'string', N'POS', 1, 1, 1, 1, NULL, NULL, N'Card Reader VID')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (148, N'PREFERRED_NON-CASH_PAYMENT_MODE', N'Preferred non-cash payment mode in POS', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Preferred non-cash payment mode in POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (264, N'CRM_SMS_USERNAME', N'CRM SMS Login Username', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'CRM SMS Login Username')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (312, N'KDS_DELIVERY_ALERT_INTERVALS', N'Delivery alert intervals in minutes. Separate each interval by | character.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (364, N'RELAY_BOARD_INTERFACE', N'Interface used to control relay board (used to switch on/off pool table lights)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (469, N'AMEeZkAkpNmZaWcBX7UuQhvr2eHUjkqNe8GER', N'Decides if physical count process can be initiated only by manager', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (520, N'ONDEMAND_REMOTING_SERVER_URL', N'URL for On-Demand roaming server', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (278, N'CUT_PAPER_PRINTER_COMMAND', N'Command string to send to printer to cut paper', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Command string to send to printer to cut paper')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (323, N'CLOCK_IN_MANDATORY_FOR_TRX', N'Clock-in mandatory for POS transactions', N'True', N'bool', N'Transaction', 1, NULL, NULL, NULL, NULL, NULL, N'Clock-in mandatory for POS transactions')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (326, N'AUTO_SHOW_TENDERED_AMOUNT_KEY_PAD', N'Automatically show number pad form in POS for cash tendered', N'true', N'bool', N'Payment', 1, NULL, NULL, NULL, NULL, NULL, N'Automatically show number pad form in POS for cash tendered')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (327, N'HIDE_REFUND_IN_PRODUCT_TAB', N'Hide Refund button in Products tab in POS', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Hide Refund button in Products tab in POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (329, N'AUTO_REFRESH_POS_PRODUCTS', N'Automatically refresh Products and Discounts in POS', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Automatically refresh Products and Discounts in POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (331, N'ALLOW_NEW_CARDS_FOR_CHILDCARDS', N'Allow NEW cards while linking child cards to a parent card', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Allow NEW cards while linking child cards to a parent card')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (332, N'AMEeZkAkpNmZaWcBX7UuQhvr2eHUjkqNe8GRD', N'Allow payment by parent cards to top-up child cards without the physical parent card', N'true', N'bool', N'Payment', 1, NULL, NULL, NULL, NULL, NULL, N'Allow payment by parent cards to top-up child cards without the physical parent card')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (333, N'IGNORE_CUSTOMER_BIRTH_YEAR', N'Ignore year part in customer date of birth', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Ignore year part in customer date of birth')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (334, N'PLAY_KIOSK_AUDIO', N'Play audio in Kiosk', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Play audio in Kiosk')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (335, N'ALLOW_MANUAL_CARD_IN_POS', N'Allow manual entry of card in POS', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Allow manual entry of card in POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (336, N'PRINT_COMBO_DETAILS_QUANTITY', N'Print product quantity for combo details', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Print product quantity for combo details')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (337, N'ALLOW_KIOSK_LANGUAGE_CHANGE', N'Allow users to change kiosk language', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Allow users to change kiosk language')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (280, N'RELOGIN_USER_AFTER_INACTIVE_TIMEOUT', N'Relogin or just authenticate after POS inactivity timeout', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Relogin or just authenticate after POS inactivity timeout')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (281, N'SHUTDOWN_SERVERS_DURING_MAINTENANCE', N'Shutdown child servers during maintenance window', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Shutdown child servers during maintenance window')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (284, N'LOG_INACTIVE_TERMINALS', N'Log non-communicating readers in EventLog', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Log non-communicating readers in EventLog')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (285, N'COMBO_PRODUCT_BUTTON_SIZE', N'COMBO Product Button size in POS (% of standard size)', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'COMBO Product Button size in POS (% of standard size)')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (286, N'ALLOW_TECH_CARD_UPDATE', N'Allow technician card update in Management Studio', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Allow technician card update in Management Studio')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (287, N'FISCAL_PRINTER', N'Fiscal Printer Interface', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Fiscal Printer Interface')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (288, N'FISCAL_PRINTER_FILE_FOLDER', N'Folder name for Fiscal printer files', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Folder name for Fiscal printer files')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (289, N'LOAD_PRODUCT_ON_REGISTRATION', N'Reward customer with entitlements on registration', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Reward customer with entitlements on registration')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (290, N'MIFARE_READONLY', N'Card type is Mi-Fare read-only card', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Card type is Mi-Fare read-only card')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (292, N'DISABLE_TRX_COMPLETE', N'Disable Complete button in POS', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Disable Complete button in POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (293, N'DISABLE_ORDER_SUSPEND', N'Disable Order/Suspend button in POS', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Disable Order/Suspend button in POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (298, N'ENABLE_ORDER_SHARE_ACROSS_POS', N'Enable viewing of Orders across POS terminals', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Enable viewing of Orders across POS terminals')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (300, N'READER_TYPE', N'Type of Reader used', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Type of Reader used')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (304, N'KIOSK_CREDITCARD_PAYMENT_MODE', N'Credit Card Payment Mode for Kiosks', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Credit Card Payment Mode for Kiosks')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (305, N'REGISTER_CUSTOMER_WITHOUT_CARD', N'Allow customer registration without card', N'true', N'bool', N'customer', 1, NULL, NULL, NULL, NULL, NULL, N'Allow customer registration without card')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (308, N'LASTLOGINTIME', N'Show LASTLOGINTIME', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Show LASTLOGINTIME')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (309, N'EXTERNALSYSTEMREF', N'Show EXTERNALSYSTEMREF', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Show EXTERNALSYSTEMREF')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (313, N'PARAFAIT_HOME', N'Parafait Home Folder', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Parafait Home Folder')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (314, N'CONCURRENT_MANAGER_ENABLED', N'Enable Concurrent Manager', N'', N'string', N'server', 1, NULL, NULL, NULL, NULL, NULL, N'Enable Concurrent Manager')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (315, N'REDEMPTION_GRACE_TICKETS', N'Number of grace tickets to add during redemption', N'true', N'string', N'Redemption', 1, NULL, NULL, NULL, NULL, NULL, N'Number of grace tickets to add during redemption')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (318, N'KDS_ORDER_DISPLAY_PANEL_WIDTH', N'Width of KDS Order display area', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Width of KDS Order display area')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (338, N'DOWNLOADBATCHID', N'Show DOWNLOADBATCHID', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Show DOWNLOADBATCHID')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (340, N'POS_QUANTITY_DECIMALS', N'Number of decimals to show for POS quanity', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Number of decimals to show for POS quanity')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (342, N'CARD_DISPENSER_READER_PID', N'Card Dispenser USB Reader PID', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Card Dispenser USB Reader PID')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (344, N'ENABLE_CLOSE_IN_READ_CARD_SCREEN', N'Allow user to Close card read screen', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Allow user to Close card read screen')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (347, N'READER_PING_TIMEOUT', N'Ping time-out during network scan of readers', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Ping time-out during network scan of readers')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (351, N'KIOSK_VARIABLE_TOPUP_PRODUCT', N'Generic variable top-up product to use for additional amounts inserted in kiosk', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Generic variable top-up product to use for additional amounts inserted in kiosk')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (353, N'AUTO_PRINT_KOT', N'Automatically print KOT on save of an Order', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Automatically print KOT on save of an Order')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (355, N'IS_ALOHA_ENV', N'Indicates Aloha environment', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Indicates Aloha environment')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (356, N'ALOHA_TERM_ID', N'Aloha Terminal ID', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Aloha Terminal ID')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (360, N'ALOHA_USER_PASSWORD', N'Aloha User Password', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Aloha User Password')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (361, N'CARD_ACCEPTOR_BAUDRATE', N'Card Acceptor serial port baud rate', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Card Acceptor serial port baud rate')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (366, N'HIDE_CHECK-IN_DETAILS', N'Hide Check-In details screen in POS', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Hide Check-In details screen in POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (368, N'REPORTS_VERSION', N'Reports version', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Reports version')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (372, N'TICKET_VOUCHER_CHECK_DIGIT', N'Ticket voucher printed by ticket stations use check digit', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Ticket voucher printed by ticket stations use check digit')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (375, N'AUTO_PRINT_REDEMPTION_RECEIPT', N'Print redemption receipt automatically', N'true', N'bool', N'Redemption', 1, NULL, NULL, NULL, NULL, NULL, N'Print redemption receipt automatically')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (376, N'IMAGE_ALIGNMENT', N'Image Alignment', N'left', N'string', N'signage', 1, NULL, NULL, NULL, NULL, CAST(N'2019-05-05T10:02:29.687' AS DateTime), N'Image Alignment')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (377, N'VIDEO_REPEAT', N'Video Repeat', N'test', N'string', N'signage', 1, NULL, NULL, NULL, NULL, CAST(N'2019-05-05T10:02:29.493' AS DateTime), N'Video Repeat')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (380, N'VIDEO_BACK_COLOR', N'Video Back Color', N'#617f1a', N'color', N'signage', 1, NULL, NULL, NULL, NULL, CAST(N'2019-05-05T10:04:06.740' AS DateTime), N'Video Back Color')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (382, N'TICKER_TEXT_COLOR', N'Ticker Text Color', N'#621c13', N'color', N'signage', 1, NULL, NULL, NULL, NULL, CAST(N'2019-05-05T10:04:06.780' AS DateTime), N'Ticker Text Color')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (383, N'TICKER_BACK_COLOR', N'Ticker Back Color', N'#3f1173', N'color', N'signage', 1, NULL, NULL, NULL, NULL, CAST(N'2019-05-05T10:04:06.873' AS DateTime), N'Ticker Back Color')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (388, N'VIDEO_BORDER_SIZE', N'Video Border Size', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Video Border Size')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (389, N'IMAGE_REFRESH_IN_SECS', N'Image Refresh Secs', N'test', N'string', N'signage', 1, NULL, NULL, NULL, NULL, CAST(N'2019-05-05T10:02:29.343' AS DateTime), N'Image Refresh Secs')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (390, N'TICKER_REFRESH_IN_SECS', N'Ticker Refresh in secs', N'test', N'string', N'signage', 1, NULL, NULL, NULL, NULL, CAST(N'2019-05-04T10:15:08.190' AS DateTime), N'Ticker Refresh in secs')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (393, N'TICKER_BORDER_SIZE', N'Ticker Border Size', N'test', N'string', N'signage', 1, NULL, NULL, NULL, NULL, CAST(N'2019-05-04T10:15:08.337' AS DateTime), N'Ticker Border Size')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (394, N'IMAGE_BORDER_SIZE', N'Image Border Size', N'test', N'string', N'signage', 1, NULL, NULL, NULL, NULL, CAST(N'2019-05-04T10:15:08.370' AS DateTime), N'Image Border Size')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (396, N'CREATE_FF_GAMEPLAY_IF_CARD_NOT_FOUND', N'Create gameplay against FF card if card not found during mifare game play', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Create gameplay against FF card if card not found during mifare game play')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (397, N'CSV_REPORTNAME_TIMESTAMP_FORMAT', N'Timestamp format in reportname for a CSV report', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Timestamp format in reportname for a CSV report')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (398, N'REPORT_FIELD_DELIMITER', N'Delimiter between fields of a report when output format is CSV', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Delimiter between fields of a report when output format is CSV')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (399, N'POLE_DISPLAY_DATA_ENCODING', N'Encoding method for Pole display data', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Encoding method for Pole display data')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (401, N'ENABMEeZkAkpNmZaWcBX7UuQhvr2eHUjkqNe8G', N'Enable viewing of Orders across counters', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Enable viewing of Orders across counters')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (402, N'DEFAULT_USER_SECURITY_POLICY', N'Default User Security Policy', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Default User Security Policy')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (403, N'CUSTOMER_PHONE_NUMBER_WIDTH', N'Specify non-zero width to enforce fixed width for customer phone number', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Specify non-zero width to enforce fixed width for customer phone number')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (405, N'ENABLE_AVERAGE_COST_METHOD', N'Average cost in product', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Average cost in product')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (407, N'MAINTENANCE_UPLOAD_DIRECTORY', N'Upload Directory', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Upload Directory')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (409, N'LOCKER_LOCK_MAKE', N'Locker lock manufacturer', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Locker lock manufacturer')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (410, N'CARD_DISPENSER_ADDRESS', N'Card Dispenser Address', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Card Dispenser Address')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (411, N'ALLOW_VARIABLE_NEW_CARD_ISSUE', N'Allow purchase of NEW cards with variable amount in Kiosk', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Allow purchase of NEW cards with variable amount in Kiosk')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (412, N'ELEMENT_EXPRESS_ACCOUNT_ID', N'Element Express Account ID', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Element Express Account ID')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (414, N'ELEMENT_EXPRESS_APPLICATION_ID', N'Element Express Application ID', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Element Express Application ID')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (416, N'ELEMENT_TERMINAL_ID', N'Element Express Terminal ID', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Element Express Terminal ID')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (420, N'CREDITCALL_SERVER_ADDRESS', N'Server Address for creditcall payment integration', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Server Address for creditcall payment integration')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (421, N'CREDITCALL_SERVER_PORT', N'Server Port for Creditcall payment integration', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Server Port for Creditcall payment integration')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (426, N'ENABLE_KIOSK_CUSTOMER_VERIFICATION', N'Send verification code during customer registration', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Send verification code during customer registration')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (427, N'MANUAL_CARD_UPDATE_ENT_LIMIT', N'Maximum value for entitlements that can be set manually on a card', N'2000', N'int', N'Limit', 1, NULL, NULL, NULL, NULL, NULL, N'Maximum value for entitlements that can be set manually on a card')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (429, N'LOAD_BONUS_REMARKS_MANDATORY', N'Load bonus remarks are mandatory', N'True', N'bool', N'Transaction', 1, NULL, NULL, NULL, NULL, NULL, N'Load bonus remarks are mandatory')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (431, N'ENABLE_LOAD_BONUS_IN_ADMIN_SCREEN', N'Enable load bonus function in admin screen', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Enable load bonus function in admin screen')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (433, N'ALLOW_CUSTOMER_INFO_EDIT', N'Allow editing of customer info', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Allow editing of customer info')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (435, N'MEeZkAkpNmZaWcBX7UuQhvr2eHUjkqNe8G', N'Show minimal details in card activity screen', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Show minimal details in card activity screen')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (438, N'SHOW_REGISTRATION_TERMS_AND_CONDITIONS', N'Display registration terms and conditions before registration', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Display registration terms and conditions before registration')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (439, N'KIOSK_ACTIVITY_DISPLAY_DURATION', N'Kiosk Activity display duration in minutes', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Kiosk Activity display duration in minutes')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (440, N'LOG_CHECK_BALANCE_EVENT', N'Log balance check event on check balance reader', N'true', N'bool', N'server', 1, NULL, NULL, NULL, NULL, NULL, N'Log balance check event on check balance reader')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (441, N'ENABLE_MIX_MODE_PAYMENT_IN_KIOSK', N'Enable Mix mode payment in Kiosk', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Enable Mix mode payment in Kiosk')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (444, N'SITE_FILE_FORMAT', N'Site file format', N'', N'string', N'Inventory', 1, NULL, NULL, NULL, NULL, NULL, N'Site file format')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (447, N'PO_FILE_FORMAT', N'Purchase Order file format', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Purchase Order file format')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (448, N'RECEIPT_FILE_FORMAT', N'Receipt file format', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Receipt file format')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (449, N'INVENTORY_UPLOAD_SERVICE_URL', N'Inventory Upload service URL', N'true', N'bool', N'Inventory', 1, NULL, NULL, NULL, NULL, NULL, N'Inventory Upload service URL')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (450, N'SUCCESS_EMAIL_LIST', N'List of email IDs separated with comma for sending summary after file load to HQ', N'true', N'bool', N'Inventory', 1, NULL, NULL, NULL, NULL, NULL, N'List of email IDs separated with comma for sending summary after file load to HQ')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (452, N'FTP_URL', N'FTP URL to pick Inventory files', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'FTP URL to pick Inventory files')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (456, N'FTP_VENDOR_FOLDER', N'Vendor file folder in FTP location', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Vendor file folder in FTP location')
GO
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (458, N'FTP_PO_FOLDER', N'PO file folder in FTP location', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'PO file folder in FTP location')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (459, N'FTP_RECEIPT_FOLDER', N'Receipt file folder in FTP location', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Receipt file folder in FTP location')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (460, N'SITE_TEMPLATE_FILE_PATH', N'Template csv for Site file comparison', N'true', N'bool', N'Inventory', 1, NULL, NULL, NULL, NULL, NULL, N'Template csv for Site file comparison')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (461, N'VENDOR_TEMPLATE_FILE_PATH', N'Template csv for Supplier file comparison', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Template csv for Supplier file comparison')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (462, N'PRODUCT_TEMPLATE_FILE_PATH', N'Template csv for Items file comparison', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Template csv for Items file comparison')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (466, N'INVENTORY_FILE_ARCHIVE_DIRECTORY', N'Archive folder for inventory files that are downloaded from FTP folder', N'true', N'bool', N'Inventory', 1, NULL, NULL, NULL, NULL, NULL, N'Archive folder for inventory files that are downloaded from FTP folder')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (468, N'INVENTORY_FILE_UPLOAD_DIRECTORY', N'Folder from where Receipt file should be uploaded', N'true', N'bool', N'Inventory', 1, NULL, NULL, NULL, NULL, NULL, N'Folder from where Receipt file should be uploaded')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (470, N'MEeZkAkpNmZaWcBX7UuQhvr2eHUjkqNe8GGE', N'Missing records threshold percentage', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Missing records threshold percentage')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (471, N'MASTER_FILES_UPLOAD_HOUR', N'Hour at which master files will be uploaded to FTP site', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Hour at which master files will be uploaded to FTP site')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (472, N'MAX_VARIABLE_RECHARGE_AMOUNT', N'Maximum limit for variable recharge', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Maximum limit for variable recharge')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (475, N'CARD_EXPIRY_ALERT_GAP', N'Defines gap in number of days between multiple Card Expiry notifications', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Defines gap in number of days between multiple Card Expiry notifications')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (476, N'CARD_EXPIRY_MESSAGE_FREQUENCY', N'Number of times card expiry notification should be sent', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Number of times card expiry notification should be sent')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (479, N'PROMO_SMS_PASSWORD', N'PROMO SMS Login Password', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'PROMO SMS Login Password')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (480, N'PROMO_SMS_START_TIME', N'Start time for sending Promotional SMS based on regulatory rules', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Start time for sending Promotional SMS based on regulatory rules')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (482, N'ENABLE_SALESFORCE_MARKETING_INTERFACE', N'Enable interface to Salesforce Marketing Cloud (ExactTarget) system', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Enable interface to Salesforce Marketing Cloud (ExactTarget) system')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (484, N'SALESFORCE_OPT-OUT_SUBSCRIBER_LISTNAME', N'Subscriber list name for opt-out customers in Salesforce Marketing Cloud (ExactTarget) system', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Subscriber list name for opt-out customers in Salesforce Marketing Cloud (ExactTarget) system')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (486, N'FIRST_DATA_TERMINAL_ID', N'First Data Terminal ID', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'First Data Terminal ID')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (487, N'FIRST_DATA_MERCHANT_ID', N'First Data Merchant Id', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'First Data Merchant Id')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (488, N'FIRST_DATA_GROUP_ID', N'First Data Group Id', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'First Data Group Id')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (489, N'FIRST_DATA_DID', N'First Data DID retrived after registration process.', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'First Data DID retrived after registration process.')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (491, N'FIRST_DATA_VERSION', N'First Data Version', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'First Data Version')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (493, N'GATEWAY_CURRENCY_CODE', N'Currency code used in Credit Card Gateway', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Currency code used in Credit Card Gateway')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (494, N'FIRST_DATA_SRS_APP', N'First Data SRS APP', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'First Data SRS APP')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (495, N'FIRST_DATA_TRANSACTION_APP', N'First Data TRANSACTION APP', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'First Data TRANSACTION APP')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (500, N'FIRST_DATA_BRAND', N'First Data Brand', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'First Data Brand')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (502, N'MERCURY_URL', N'URL for Mercury Gateway', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'URL for Mercury Gateway')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (503, N'MERCURY_MERCHANT_ID', N'Merchant ID for Mercury Gateway', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Merchant ID for Mercury Gateway')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (505, N'PRINT_MERCHANT_RECEIPT', N'Option to disable printing of Merchant receipt for Credit Card Payment Gateway', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Option to disable printing of Merchant receipt for Credit Card Payment Gateway')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (509, N'SALES_REPORT_FTP_USERNAME', N'FTP User Name for Third Party', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'FTP User Name for Third Party')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (510, N'SALES_REPORT_FTP_PASSWORD', N'FTP password for Third Party', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'FTP password for Third Party')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (514, N'ALLOW_PARTIAL_APPROVAL', N'Allow partial approval for Credit Card Payments', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Allow partial approval for Credit Card Payments')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (517, N'CANCEMEeZkAkpNmZaWcBX7UuQhvr2eHUjkqNe8GR_APPROVAL', N'Manager approval required for cancelling unsaved transaction line', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Manager approval required for cancelling unsaved transaction line')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (519, N'MAINTENANCE_JOB_CREATION_TIME', N'Maintenance job creation time', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Maintenance job creation time')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (521, N'FREE_PLAY_MODE', N'Sets the game play mode to Free Play mode in Server', N'', N'string', N'server', 1, NULL, NULL, NULL, NULL, NULL, N'Sets the game play mode to Free Play mode in Server')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (523, N'PATCH_DOWNLOAD_PATH', N'Patch download path from Server', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Patch download path from Server')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (524, N'WRAPPER_INSTALLER_RUN_FREQUENCY', N'Wrapper installer frequency in seconds', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Wrapper installer frequency in seconds')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (526, N'REVERSE_KIOSK_TOPUP_CARD_NUMBER', N'Reverse Top Up card number in Kiosk', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Reverse Top Up card number in Kiosk')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (527, N'UPC_TYPE', N'UPC TYPE Digit', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'UPC TYPE Digit')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (528, N'AUTO_LOAD_CARD_ENTITLEMENT_SCREEN', N'Show Card Validation and Entitlement deduction Screen for Entry or Exit', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Show Card Validation and Entitlement deduction Screen for Entry or Exit')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (529, N'SHOW_GAME_ACTIVITY', N'Show game play activity in customer dashboard screen', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Show game play activity in customer dashboard screen')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (530, N'FISCAL_DEVICE_SERIAL_NUMBER', N'Fiscal device serial no', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Fiscal device serial no')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (533, N'WAIVER_CONFIRMATION_REQUIRED', N'Cashier Waiver verification required in POS', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Cashier Waiver verification required in POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (534, N'SALES_REPORT_DATA_UPLOAD_URL', N'Sales Report Web Upload Transaction Data URL', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Sales Report Web Upload Transaction Data URL')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (535, N'DEFAULT_SALES_REPORT_FORMAT', N'Default SalesReport Format (0-MiNET,1-Xtreme Integra,2-ECM,3-XINTIANDI)', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Default SalesReport Format (0-MiNET,1-Xtreme Integra,2-ECM,3-XINTIANDI)')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (536, N'IS_SALES_REPORT_ENVIRONMENT', N'Indicates Sales report environment', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Indicates Sales report environment')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (538, N'CARD_READER_SERIAL_NUMBER', N'Serial Number of the card reader device', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Serial Number of the card reader device')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (541, N'ERP_EXTERNAL_URL', N'ERP External System URL', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'ERP External System URL')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (544, N'AUTO_POPUP_TRX_PROFILE_OPTIONS', N'Automatically pop-up trx profiles selection for each transaction', N'True', N'bool', N'Transaction', 1, NULL, NULL, NULL, NULL, NULL, N'Automatically pop-up trx profiles selection for each transaction')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (546, N'FOREFIET_BALANCE_RETURN_AMOUNT', N'Forefiet balance return amount during Sales Exchange process', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Forefiet balance return amount during Sales Exchange process')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (549, N'EXCMEeZkAkpNmZaWcBX7UuQhvr2eHUjkqNe8GX_REPORT', N'Exclude display group breakdown section in transaction report', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Exclude display group breakdown section in transaction report')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (550, N'ENABLE_CAPILLARY_INTEGRATION', N'Enable Capillary Integration for CRM', N'true', N'bool', N'', 1, 0, 0, NULL, NULL, CAST(N'2019-02-05T22:03:30.037' AS DateTime), N'Enable Capillary Integration for CRM')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (551, N'CAPILLARY_INTEGRATION_URL', N'Capillary Integration URL', N'true', N'bool', N'', 1, 0, 0, NULL, NULL, CAST(N'2019-02-05T22:03:39.717' AS DateTime), N'Capillary Integration URL')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (555, NULL, NULL, N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (556, N'Show_POS_Shift_Collection', N'Show POS Shift Collection', N'True', N'bool', N'pos', 1, NULL, NULL, NULL, NULL, CAST(N'2019-03-03T01:08:45.790' AS DateTime), N'Show POS Shift Collection')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (557, N'Return_Within_Days', N'Return Within Days', N'300', N'int', N'pos', 1, NULL, NULL, NULL, NULL, CAST(N'2019-03-03T01:08:53.830' AS DateTime), N'Return Within Days')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (559, N'Enale_Product_In_POS', N'Enale Product In POS', N'True', N'bool', N'pos', 1, NULL, NULL, NULL, NULL, CAST(N'2019-03-03T01:03:57.060' AS DateTime), N'Enale Product In POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (560, N'Enale_Discount_In_POS', N'Enale Discount In POS', N'True', N'bool', N'pos', 1, NULL, NULL, NULL, NULL, CAST(N'2019-03-03T01:03:57.123' AS DateTime), N'Enale Discount In POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (561, N'Enale_Task_In_POS', N'Enale Task In POS', N'True', N'bool', N'pos', 1, NULL, NULL, NULL, NULL, CAST(N'2019-03-03T01:03:57.160' AS DateTime), N'Enale Task In POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (562, N'Enale_CardDetails_In_POS', N'Enale Card Details In POS', N'True', N'bool', N'pos', 1, NULL, NULL, NULL, NULL, CAST(N'2019-03-03T01:03:57.207' AS DateTime), N'Enale Card Details In POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (563, N'Enale_Refund_In_POS', N'Enale Refund In POS', N'True', N'bool', N'pos', 1, NULL, NULL, NULL, NULL, CAST(N'2019-03-03T01:03:57.253' AS DateTime), N'Enale Refund In POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (564, N'Allow_Refund_of_CardDetails', N'Allow Refund of CardDetails', N'3', N'int', N'card', 1, NULL, NULL, NULL, NULL, CAST(N'2019-03-03T01:04:19.540' AS DateTime), N'Allow Refund of CardDetails')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (565, N'Allow_PartialRefund', N'Allow Partial Refund of CardDetails', N'True', N'bool', N'card', 1, NULL, NULL, NULL, NULL, CAST(N'2019-03-03T01:04:19.600' AS DateTime), N'Allow Partial Refund of CardDetails')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (566, N'Allow_Refund_Of_CardDeposit', N'Allow  Refund of Card Deposit', N'True', N'bool', N'card', 1, NULL, NULL, NULL, NULL, CAST(N'2019-03-03T01:04:19.653' AS DateTime), N'Allow  Refund of Card Deposit')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (567, N'Card_Number_Lenght', N'Card Number Lenght', N'5', N'int', N'card', 1, NULL, NULL, NULL, NULL, CAST(N'2019-03-03T01:04:35.050' AS DateTime), N'Card Number Lenght')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (568, N'Reverse_Desktop_CardNumber', N'Reverse Desktop CardNumber', N'True', N'bool', N'card', 1, NULL, NULL, NULL, NULL, CAST(N'2019-03-03T01:04:35.093' AS DateTime), N'Reverse Desktop CardNumber')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (569, N'Reactivate_Expired_Card', N'Reactivate Expired Card', N'True', N'bool', N'card', 1, NULL, NULL, NULL, NULL, CAST(N'2019-03-03T01:04:35.157' AS DateTime), N'Reactivate Expired Card')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (570, N'Allow_Manual_Card_INPOS', N'Allow_Manual_Card In POS', N'True', N'bool', N'card', 1, NULL, NULL, NULL, NULL, CAST(N'2019-03-03T01:04:35.213' AS DateTime), N'Allow_Manual_Card In POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (572, N'Card_Reader_PID', N'Card Reader PID', N'FFF', N'string', N'POS', 1, 1, 1, 1, NULL, NULL, N'Card Reader PID')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (75, N'TRX_AUTO_PRINT_AFTER_SAVE', N'Automatically Print Transaction after saving', N'true', N'bool', N'print', 1, NULL, NULL, NULL, NULL, NULL, N'Automatically Print Transaction after saving')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (78, N'PRINT_TICKET_FOR_PRODUCT_TYPES', N'Print Tickets for these product types', N'true', N'bool', N'print', 1, NULL, NULL, NULL, NULL, NULL, N'Print Tickets for these product types')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (80, N'ALLOW_ONLY_GAMECARD_PAYMENT_IN_POS', N'Forces game card payment in POS for non-card transactions', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Forces game card payment in POS for non-card transactions')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (81, N'ALLOW_PRICE_UPDATE_IN_PO', N'Allow update of price of items in PO', N'true', N'bool', N'Inventory', 1, NULL, NULL, NULL, NULL, NULL, N'Allow update of price of items in PO')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (83, N'USB_READER_PID', N'USB Reader PID', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'USB Reader PID')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (86, N'CARD_ISSUE_MANDATORY_FOR_CHECKIN', N'Card issue mandatory for Check-In products', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Card issue mandatory for Check-In products')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (88, N'PHOTO_MANDATORY_FOR_CHECKIN', N'Photo mandatory for Check-In products', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Photo mandatory for Check-In products')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (89, N'REFUND_REMARKS_MANDATORY', N'Remarks mandatory during card refund', N'False', N'bool', N'Transaction', 1, NULL, NULL, NULL, NULL, CAST(N'2019-04-26T11:54:12.777' AS DateTime), N'Remarks mandatory during card refund')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (92, N'CHECKIN_DETAILS_RFID_TAG', N'RFID Tag for Check In details', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'RFID Tag for Check In details')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (94, N'PURGE_BEFORE_YEAR_OR_DAYS', N'Purge data before fiscal year or days', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Purge data before fiscal year or days')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (95, N'DAYS_TO_KEEP_PHOTOS_FOR', N'Number of days to keep check-in photos before purging', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Number of days to keep check-in photos before purging')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (96, N'USB_BARCODE_READER_VID', N'USB Bar Code Reader VID', N'', N'string', N'Inventory', 1, NULL, NULL, NULL, NULL, NULL, N'USB Bar Code Reader VID')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (98, N'USB_BARCODE_READER_OPT_STRING', N'USB Bar Code Reader Optional String', N'true', N'bool', N'Inventory', 1, NULL, NULL, NULL, NULL, NULL, N'USB Bar Code Reader Optional String')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (100, N'MAX_TOKEN_NUMBER', N'Maximum POS Token number, after which it is restarted from 1', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Maximum POS Token number, after which it is restarted from 1')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (102, N'ENABLE_DISCOUNTS_IN_POS', N'Enable Discounts Tab in POS', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Enable Discounts Tab in POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (104, N'ENABLE_MY_TRANSACTIONS_IN_POS', N'Enable My Transactions Tab in POS', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Enable My Transactions Tab in POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (107, N'TOKEN_MACHINE_GAMEPLAY_CARD', N'Default Card Number to record game play on Physical Token Machine', N'', N'string', N'server', 1, NULL, NULL, NULL, NULL, NULL, N'Default Card Number to record game play on Physical Token Machine')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (108, N'TICKETS_TO_REDEEM_PER_BONUS', N'Number of Tickets required for one Bonus value', N'', N'string', N'price', 1, NULL, NULL, NULL, NULL, NULL, N'Number of Tickets required for one Bonus value')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (110, N'MAX_TICKETS_PER_GAMEPLAY', N'Maximum tickets allowed per game play, in order to avoid erroneous ticket reporting.', N'', N'string', N'server', 1, NULL, NULL, NULL, NULL, NULL, N'Maximum tickets allowed per game play, in order to avoid erroneous ticket reporting.')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (112, N'LEFT_TRIM_CARD_NUMBER', N'Number of characters to trim at the beginning in card number', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Number of characters to trim at the beginning in card number')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (113, N'RIGHT_TRIM_CARD_NUMBER', N'Number of characters to trim at the end in card number', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Number of characters to trim at the end in card number')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (117, N'ALLOW_REFUND_OF_CARD_DEPOSIT', N'Allow refund of card deposit amount', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Allow refund of card deposit amount')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (118, N'CARD_NUMBER_LENGTH', N'Number of characters in Card Number', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Number of characters in Card Number')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (122, N'AD_PUBLISH_WINDOW_END', N'Time at which Ad publishing ends', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Time at which Ad publishing ends')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (124, N'AD_SHOW_WINDOW_END', N'Time at which Ad show ends', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Time at which Ad show ends')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (128, N'AUTOMATIC_ON_DEMAND_ROAMING', N'Automatically get card details from sites which are not in auto-roam zone', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Automatically get card details from sites which are not in auto-roam zone')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (132, N'REGISTRATION_MANDATORY_FOR_VIP', N'Customer registration mandatory for VIP status', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Customer registration mandatory for VIP status')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (134, N'ENABLE_SMTP_SSL', N'Enable SSL for SMTP Client', N'False', N'bool', N'Email', 1, NULL, NULL, NULL, NULL, CAST(N'2019-04-27T01:09:19.437' AS DateTime), N'Enable SSL for SMTP Client')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (135, N'ENABLE_FINGER_PRINT_ATTENDANCE', N'Enable Finger Print Attendance recording in POS', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Enable Finger Print Attendance recording in POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (136, N'OPEN_CASH_DRAWER', N'Auto open cash drawer on transaction save or receipt print', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Auto open cash drawer on transaction save or receipt print')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (137, N'CASH_DRAWER_INTERFACE', N'Cash Drawer Interface', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Cash Drawer Interface')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (139, N'CASH_DRAWER_SERIAL_PORT', N'Serial Port number for cash drawer interface', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Serial Port number for cash drawer interface')
GO
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (141, N'CASH_DRAWER_SERIALPORT_STRING', N'Print string to open cash drawer through serial port', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Print string to open cash drawer through serial port')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (144, N'PRINT_TICKET_BORDER', N'Print border for Tickets', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Print border for Tickets')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (146, N'ALLOW_REFUND_OF_CREDITPLUS', N'Allow refund of card creditplus', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Allow refund of card creditplus')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (147, N'CREDITCARD_DETAILS_MANDATORY', N'Credit Card details in payment screen mandatory', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Credit Card details in payment screen mandatory')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (150, N'COMMUNICATION_RETRY_DELAY', N'Delay between each communication retry attempts in ms', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Delay between each communication retry attempts in ms')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (152, N'COMMUNICATION_SEND_DELAY', N'Delay between each send to readers in ms', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Delay between each send to readers in ms')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (153, N'SOCKET_SEND_RECEIVE_TIMEOUT', N'Timeout in ms for socket send and receive', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Timeout in ms for socket send and receive')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (155, N'SHOW_POLLING_INDICATOR', N'Show polling status indicator', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Show polling status indicator')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (156, N'SHOW_DETAILED_POLL_STATUS', N'Show detailed polling status', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Show detailed polling status')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (158, N'PRINTER_PAGE_RIGHT_MARGIN', N'Receipt Printer right side margin in 100ths of an inch', N'true', N'bool', N'print', 1, NULL, NULL, NULL, NULL, NULL, N'Receipt Printer right side margin in 100ths of an inch')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (161, N'MINIMUM_RECHARGE_FOR_VIP_STATUS', N'Minimum total recharge amount to get VIP status', N'', N'string', N'price', 1, NULL, NULL, NULL, NULL, NULL, N'Minimum total recharge amount to get VIP status')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (162, N'REGISTRATION_MANDATORY_FOR_MEMBERSHIP', N'Customer registration mandatory for Membership status', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Customer registration mandatory for Membership status')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (165, N'AUTO_EXTEND_GAMEPLAY_TICKETS_ON_RELOAD', N'Automatically extend expiry date of game play tickets on reload', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Automatically extend expiry date of game play tickets on reload')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (166, N'LOAD_BONUS_EXPIRY_DAYS', N'Number of days for loaded bonus to expire', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Number of days for loaded bonus to expire')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (169, N'DISPLAY_VIP_PRICE_ONLY_IF_DIFFERENT', N'Display VIP Price only if it is different from Normal Price', N'true', N'bool', N'server', 1, NULL, NULL, NULL, NULL, NULL, N'Display VIP Price only if it is different from Normal Price')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (171, N'CARD_ISSUE_MANDATORY_FOR_CHECKOUT', N'Card issue mandatory for Check-Out products', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Card issue mandatory for Check-Out products')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (173, N'EXCMEeZkAkpNmZaWcBX7UuQhvr2eHUjkqNe8G', N'Exclude product sales with zero price in transaction report', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Exclude product sales with zero price in transaction report')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (175, N'ALLOW_MANUAL_CARD_UPDATE', N'Allow manual card update in Management Studio', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Allow manual card update in Management Studio')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (176, N'ALLOW_REDEMPTION_WITHOUT_CARD', N'Allow redemption without customer card', N'true', N'bool', N'Redemption', 1, NULL, NULL, NULL, NULL, NULL, N'Allow redemption without customer card')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (178, N'BILL_ACCEPTOR', N'Kiosk Bill Acceptor', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Kiosk Bill Acceptor')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (181, N'VIP_POS_ALERT_SPEND_THRESHOLD', N'Spend threshold amount to alert for VIP upgrade in POS', N'', N'string', N'price', 1, NULL, NULL, NULL, NULL, NULL, N'Spend threshold amount to alert for VIP upgrade in POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (184, N'UNIQUE_ID_MANDATORY_FOR_VIP', N'Unique Id mandatory for VIP status', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Unique Id mandatory for VIP status')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (185, N'FISCAL_PRINTER_PORT_NUMBER', N'Fiscal Printer COM Port Number', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Fiscal Printer COM Port Number')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (188, N'USE_FISCAL_PRINTER', N'Use Fiscal Printer instead of Regular Receipt Printer', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Use Fiscal Printer instead of Regular Receipt Printer')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (191, N'QUEUE_ENTRY_ADVANCE_TIME', N'Advance time to look to make an entry in queue', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Advance time to look to make an entry in queue')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (193, N'GAMEPLAY_END_WAIT_TIME', N'Wait time before removing customer from queue after play end', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Wait time before removing customer from queue after play end')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (194, N'QUEUE_SETUP_TIME', N'Queue setup time between game plays', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Queue setup time between game plays')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (196, N'END_OF_PLAY_WARNING_TIME', N'Time when warning be shown before game is coming to end', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Time when warning be shown before game is coming to end')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (197, N'END_OF_PLAY_ERROR_TIME', N'Time when error be shown before game is coming to end', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Time when error be shown before game is coming to end')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (200, N'THIRD_PARTY_SYSTEM_SYNCH_FREQUENCY', N'External system synchrnoize Frequency in Seconds', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'External system synchrnoize Frequency in Seconds')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (203, N'TRANSACTION_AMOUNT_LIMIT', N'Max transaction amount', N'4000', N'int', N'Limit', 1, NULL, NULL, NULL, NULL, CAST(N'2019-05-03T23:25:26.450' AS DateTime), N'Max transaction amount')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (204, N'MONEY_SCREEN_TIMEOUT', N'Time out in money screen if money not inserted', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Time out in money screen if money not inserted')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (206, N'INVALIDATE_SRC_CARD_ON_CONSOLIDATE', N'Invalidate source cards on Consolidate', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Invalidate source cards on Consolidate')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (208, N'ADDRESS2', N'Show ADDRESS2', N'2', N'dropdown', N'customer', 1, NULL, NULL, NULL, NULL, CAST(N'2019-09-29T22:30:49.090' AS DateTime), N'Show ADDRESS2')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (210, N'CITY', N'Show CITY', N'2', N'dropdown', N'customer', 1, NULL, NULL, NULL, NULL, CAST(N'2019-09-29T22:30:49.130' AS DateTime), N'Show CITY')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (211, N'STATE', N'Show STATE', N'1', N'dropdown', N'customer', 1, NULL, NULL, NULL, NULL, CAST(N'2019-09-29T22:32:31.720' AS DateTime), N'Show STATE')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (212, N'COUNTRY', N'Show COUNTRY', N'2', N'dropdown', N'customer', 1, NULL, NULL, NULL, NULL, CAST(N'2019-09-29T22:33:33.087' AS DateTime), N'Show COUNTRY')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (217, N'ANNIVERSARY', N'Show ANNIVERSARY', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Show ANNIVERSARY')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (218, N'CONTACT_PHONE1', N'Show CONTACT_PHONE1', N'2', N'dropdown', N'customer', 1, NULL, NULL, NULL, NULL, CAST(N'2019-09-29T22:33:33.087' AS DateTime), N'Show CONTACT_PHONE1')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (222, N'DESIGNATION', N'Show DESIGNATION', N'2', N'dropdown', N'customer', 1, NULL, NULL, NULL, NULL, CAST(N'2019-09-29T22:33:33.090' AS DateTime), N'Show DESIGNATION')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (224, N'USERNAME', N'Show USERNAME', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Show USERNAME')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (226, N'FBACCESSTOKEN', N'Show FBACCESSTOKEN', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Show FBACCESSTOKEN')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (227, N'TWACCESSTOKEN', N'Show TWACCESSTOKEN', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Show TWACCESSTOKEN')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (230, N'TEAMUSER', N'Show TEAMUSER', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Show TEAMUSER')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (231, N'ADD_CREDITPLUS_IN_CARD_INFO', N'Add CreditPlus to Credits/Bonus in card info in POS', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Add CreditPlus to Credits/Bonus in card info in POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (232, N'REDEMPTION_TICKET_NAME_VARIANT', N'A variant name for Redemption Tickets in Redemption screen', N'true', N'string', N'Redemption', 1, NULL, NULL, NULL, NULL, NULL, N'A variant name for Redemption Tickets in Redemption screen')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (236, N'AUTO_CHECK_IN_PRODUCT', N'Check-in product for automatically checking-in on card tap', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Check-in product for automatically checking-in on card tap')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (239, N'NON-CARD_PRODUCT_BUTTON_SIZE', N'Non-card Product Button size in POS (% of standard size)', N'', N'string', N'Formats', 1, NULL, NULL, NULL, NULL, NULL, N'Non-card Product Button size in POS (% of standard size)')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (242, N'CUSTOMER_EMAIL_OR_PHONE_MANDATORY', N'Ensure customer email or phone is entered mandatorily', N'true', N'bool', N'customer', 1, NULL, NULL, NULL, NULL, NULL, N'Ensure customer email or phone is entered mandatorily')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (243, N'AUTO_DEBITCARD_PAYMENT_POS', N'POS is designated as auto-debit card payment POS', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'POS is designated as auto-debit card payment POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (246, N'ENABLE_PHYSICAL_TICKET_RECEIPT_SCAN', N'Enable scan of physical ticket receipts during Redemption', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Enable scan of physical ticket receipts during Redemption')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (249, N'ZERO_PRICE_CARDGAME_PLAY', N'Consider price of Card Games play to be 0', N'true', N'bool', N'price', 1, NULL, NULL, NULL, NULL, NULL, N'Consider price of Card Games play to be 0')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (251, N'RETAIN_BACKUP_FILES_FOR_DAYS', N'Days to retain backup files for in backup folder', N'', N'string', N'BackUp', 1, NULL, NULL, NULL, NULL, NULL, N'Days to retain backup files for in backup folder')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (253, N'ROUND_OFF_AMOUNT_TO', N'Round off amount to...', N'0.01', N'string', N'Transaction', 1, NULL, NULL, NULL, NULL, CAST(N'2019-04-26T11:57:35.707' AS DateTime), N'Round off amount to...')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (255, N'DEFAULT_LANGUAGE', N'Default language', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Default language')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (256, N'ENABLE_AUTO_PURGE', N'Enable automatic purge of old data by system', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Enable automatic purge of old data by system')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (257, N'CRM_SMTP_HOST', N'CRM SMTP Hostname or IP Address', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'CRM SMTP Hostname or IP Address')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (259, N'CRM_SMTP_NETWORK_USERNAME', N'CRM SMTP Login Username', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'CRM SMTP Login Username')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (265, N'CRM_SMS_PASSWORD', N'CRM SMS Login Password', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'CRM SMS Login Password')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (266, N'POLE_DISPLAY_BAUDRATE', N'Pole Display Baud Rate', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Pole Display Baud Rate')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (1, N'CARD_FACE_VALUE', N'Price of a Card', N'80', N'int', N'card', 1, 1, 1, NULL, N'Harish', CAST(N'2019-08-31T14:41:41.093' AS DateTime), N'Price of a Card')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (2, N'TicketPulseWidth', N'Price of 1 Token', N'0', N'int', N'Configuration', 1, 1, 1, NULL, N'Harish', CAST(N'2019-05-26T17:27:10.033' AS DateTime), N'')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (3, N'POS_CARD_READER_BAUDRATE', N'Card Reader COM Port Baudrate', N'', N'int', NULL, 1, 1, 1, NULL, N'Harish', CAST(N'2018-12-22T23:38:06.140' AS DateTime), N'')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (4, N'DEFAULT_FONT', N'Default Font', N'test1', N'string', N'POS', 1, 1, 1, NULL, N'Harish', CAST(N'2019-03-02T23:22:45.187' AS DateTime), N'')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (6, N'DATE_FORMAT', N'Date Format', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (7, N'NUMBER_FORMAT', N'Number Format', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (9, N'CURRENCY_CODE', N'Currency', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (10, N'TICKET_PRICE', N'Price of a Ticket, from customer perspective (used if customer could buy tickets or fill-in shortfall by paying while redeeming)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (15, N'CREDIT_PRICE', N'Credit Price', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (16, N'BONUS_PRICE', N'Bonus Price', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (18, N'WEBSERVICE_UPLOAD_FREQUENCY', N'Frequency of Internet Upload in Minutes', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (22, N'DEFAULT_GRID_FONT', N'Default Font for Grid data', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (25, N'PURGE_DATA_BEFORE_YEARS', N'Number of Fiscal years to keep data before purging', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (29, N'PDF_WRITER_PRINTER', N'Printer Name for PDF Writer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (30, N'PDF_CONFIG_EXE', N'Executable Name for changing PDF Writer configuration', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (32, N'SMTP_HOST', N'SMTP Host Name or ip address', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (34, N'SMTP_NETWORK_CREDENTIAL_USERNAME', N'SMTP Login Username', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (37, N'POS_FINGER_PRINT_AUTHENTICATION', N'Use Finger Print Reader for POS Authentication', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (39, N'BACKUP_INTERVAL', N'Database Backup Interval in Minutes', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (42, N'MAINTENANCE_END_HOUR', N'System Maintenance Window End Hour', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (43, N'MAIN_SERVER_HEARTBEAT_INTERVAL', N'Heartbeat Interval to restart closed servers in seconds', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (47, N'ENABLE_REDEMPTION_IN_POS', N'Enables Redemption Module in POS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (50, N'HUB_HEARTBEAT_INTERVAL', N'Heartbeat Interval to check on HUB Communication in Milli Seconds', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (51, N'MIN_SECONDS_BETWEEN_REPEAT_PLAY', N'Minimum Seconds between repeat play by same card on same machine', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (2, N'TOKEN_PRICE', N'Price of 1 Token', N'10', N'string', N'price', 1, 0, 0, NULL, N'Harish', CAST(N'2019-06-09T09:34:30.840' AS DateTime), N'Price of 1 Token')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (5, N'DATETIME_FORMAT', N'Date Time Format', N'', N'string', N'Formats', 0, 1, 1, NULL, NULL, CAST(N'2019-02-17T20:55:55.207' AS DateTime), N'Date Time Format')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (8, N'AMOUNT_FORMAT', N'Amount Format', N'', N'string', N'Formats', 1, NULL, NULL, NULL, NULL, NULL, N'Amount Format')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (11, N'MINIMUM_SPEND_FOR_VIP_STATUS', N'Minimum total spend amount to get VIP status', N'', N'string', N'price', 1, NULL, NULL, NULL, NULL, NULL, N'Minimum total spend amount to get VIP status')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (12, N'DEFAULT_FONT_SIZE', N'Default Font Size', N'', N'string', N'Formats', 1, NULL, NULL, NULL, NULL, NULL, N'Default Font Size')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (13, N'POS_SKIN_COLOR', N'POS Screen Skin Color', N'blue', N'string', N'pos', 1, 1, 1, NULL, N'Harish', CAST(N'2019-03-03T01:03:37.060' AS DateTime), N'POS Screen Skin Color')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (14, N'CURRENCY_SYMBOL', N'Currency Symbol', N'', N'string', N'Formats', 1, NULL, NULL, NULL, NULL, NULL, N'Currency Symbol')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (17, N'COURTESY_PRICE', N'Courtesy Price', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Courtesy Price')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (19, N'WEBSERVICE_UPLOAD_URL', N'Web Service URL', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Web Service URL')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (20, N'TICKET_COST', N'Cost of a Ticket (from Owner perspective. used to calcualte payout % of a machine)', N'.5', N'string', N'price', 1, NULL, NULL, NULL, NULL, CAST(N'2019-06-08T03:51:47.087' AS DateTime), N'Cost of a Ticket (from Owner perspective. used to calcualte payout % of a machine)')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (21, N'REAL_TICKET_MODE', N'Decides if at site level tickets are issued as real tickets or e-tickets. Can be overridden at Card level.', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Decides if at site level tickets are issued as real tickets or e-tickets. Can be overridden at Card level.')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (23, N'DEFAULT_GRID_FONT_SIZE', N'Default Font Size for Grid data', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Default Font Size for Grid data')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (24, N'FISCAL_YEAR_END_MONTH', N'Month number of Fiscal Year end', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Month number of Fiscal Year end')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (26, N'MIN_SECONDS_BETWEEN_GAMETIME_PLAY', N'Minimum required timespan in seconds between two plays in case of GameTime Play', N'', N'string', N'server', 1, NULL, NULL, NULL, NULL, NULL, N'Minimum required timespan in seconds between two plays in case of GameTime Play')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (27, N'CARD_VALIDITY', N'Card Validity in number of Months', N'2', N'int', N'card', 1, NULL, NULL, NULL, NULL, CAST(N'2019-03-03T01:04:19.453' AS DateTime), N'Card Validity in number of Months')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (28, N'DEFAULT_PAY_MODE', N'Default Pay Mode in POS (0-None, 1-Cash, 2-Credit Card)', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Default Pay Mode in POS (0-None, 1-Cash, 2-Credit Card)')
GO
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (31, N'PDF_OUTPUT_DIR', N'Directory Name for PDF Report Creation', N'122', N'string', N'Email', 1, NULL, NULL, NULL, NULL, CAST(N'2019-05-04T07:14:30.270' AS DateTime), N'Directory Name for PDF Report Creation')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (33, N'SMTP_PORT', N'Port Number of SMTP Host', N'587', N'string', N'Email', 1, NULL, NULL, NULL, NULL, NULL, N'Port Number of SMTP Host')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (35, N'SMTP_NETWORK_CREDENTIAL_PASSWORD', N'SMTP Login Password', N'4cb13ec100', N'string', N'Email', 1, NULL, NULL, NULL, NULL, NULL, N'SMTP Login Password')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (36, N'SMTP_FROM_DISPLAY_NAME', N'Display Name for From Address', N'shridharg100@gmail.com', N'string', N'Email', 1, NULL, NULL, NULL, NULL, CAST(N'2019-05-05T10:17:54.327' AS DateTime), N'Display Name for From Address')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (38, N'ALLOW_REFUND_OF_CARD_CREDITS', N'Allow Full Refund of Card or only face value', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Allow Full Refund of Card or only face value')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (40, N'BACKUP_DIRECTORY', N'Database Backup Directory', N'', N'string', N'BackUp', 1, NULL, NULL, NULL, NULL, NULL, N'Database Backup Directory')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (41, N'MAINTENANCE_START_HOUR', N'System Maintenance Window Start Hour', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'System Maintenance Window Start Hour')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (55, N'CONSECUTIVE_TRX_FAIL_COUNT_BEFORE_HUB_REBOOT', N'Number of consective transmission failures before hub is rebooted by server', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (57, N'PRINT_TRANSACTION_ITEM_SLIPS', N'Prints Transaction Line Items in Slips while printing on Bill printer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (58, N'LOG_TRANSMISSION_FAILURES', N'Log Transmission Failures', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (59, N'LOG_RECEIVE_FAILURES', N'Log Receive Failures', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (60, N'ENABLE_POS_FILTER_IN_TRX_REPORT', N'Enable POS Filter in Transaction Report', N'True', N'bool', N'POS', 1, 1, 1, NULL, N'Harish', CAST(N'2019-09-29T22:33:19.390' AS DateTime), NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (61, N'ALLOW_TRANSACTION_ON_ZERO_STOCK', N'Allow Transaction in case of stock is less than or equal to zero', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (62, N'TRANSACTION_ITEM_SLIPS_GAP', N'Spacing between transaction slips in number of lines', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (65, N'GROUP_TIMER_EXTEND_AFTER_INTERVAL_PERCENT', N'Percent of remaining timer interval in which card swipe on a group timer will extend time', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (67, N'SHOW_PRINT_DIALOG_IN_POS', N'Show print setup dialog on transaction print in POS or print directly to default printer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (68, N'ALLOW_CASH_IN_PAYMENT_GATEWAY', N'Allow cash payment in External Payment Gateway', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (73, N'HIDE_SHIFT_OPEN_CLOSE', N'Hide Shift Open-Close screen while Login', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (74, N'READER_HARDWARE_VERSION', N'Reader Hardware Version', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (76, N'CLEAR_TRX_AFTER_PRINT', N'Clear Transaction after printing to avid reprinting', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (77, N'READER_PRICE_DISPLAY_FORMAT', N'Display Format for game price on reader (6 Chars)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (79, N'PRINT_TICKET_FOR_EACH_QUANTITY', N'Prints a Ticket for each quantity of transaction line', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (82, N'USB_READER_VID', N'USB Reader VID', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (84, N'USB_READER_OPT_STRING', N'USB Reader Optional String', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (85, N'ALLOW_TRX_PRINT_BEFORE_SAVING', N'Allow printing of transaction before saving it', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (87, N'CHECKIN_PHOTO_DIRECTORY', N'Check-In photo folder name', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (90, N'WRIST_BAND_FACE_VALUE', N'Face value for Wrist Band issue', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (91, N'CARD_ISSUE_MANDATORY_FOR_CHECKIN_DETAILS', N'Card issue mandatory for Check-In details', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (93, N'PURGE_DATA_BEFORE_DAYS', N'Number of days to keep data before purging', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (97, N'USB_BARCODE_READER_PID', N'USB Bar Code Reader PID', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (99, N'TAX_IDENTIFICATION_NUMBER', N'Tax Identification Number for the Organization / Legal Entity', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (101, N'ENABLE_PRODUCTS_IN_POS', N'Enable Products Tab in POS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (103, N'ENABLE_TASKS_IN_POS', N'Enable Tasks Tab in POS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (105, N'ENABLE_REFUND_IN_POS', N'Enable Refund Card Button in POS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (106, N'RECEIPT_PRINT_TEMPLATE', N'POS Receipt Print Template', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (109, N'LOG_FREQUENCY_IN_POLLS', N'Frequency in number of polls to log communication errors', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (111, N'ENABLE_CARD_DETAILS_IN_POS', N'Enable Card Details Tab and Card Info section in POS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (114, N'LEFT_TRIM_BARCODE', N'Number of characters to trim at the beginning in Bar Code', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (115, N'RIGHT_TRIM_BARCODE', N'Number of characters to trim at the end in Bar Code', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (116, N'ALLOW_PARTIAL_REFUND', N'Allow Partial refund of cards', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (119, N'AD_IMAGE_DIRECTORY', N'Ad Images folder name', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (120, N'CONSUME_CREDITS_BEFORE_BONUS', N'Consume card credits before bonus', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (121, N'AD_PUBLISH_WINDOW_START', N'Time at which Ad publishing starts', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (123, N'AD_SHOW_WINDOW_START', N'Time at which Ad show starts', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (125, N'IMAGE_DIRECTORY', N'Images folder name', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (126, N'AUTO_POPUP_CARD_PROMOTIONS_IN_POS', N'Atomatically pop up card promotions screen on card swipe', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (127, N'ENABLE_ON_DEMAND_ROAMING', N'Enable on-demand roaming from sites which are not in auto-roam zone', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (129, N'DEBUG_MODE', N'Debug Mode', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (130, N'ALLOW_PRINT_IN_SHIFT_OPEN_CLOSE', N'Allow Printing of shift open-close', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (131, N'DEFAULT_TCP_PORT', N'Default TCP Port to connect to Access Points / Readers', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (133, N'AUTO_UPDATE_PHYSICAL_TICKETS_ON_CARD', N'Load physical tickets to card automatically', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (138, N'CASH_DRAWER_PRINT_STRING', N'Print string to open cash drawer through receipt printer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (140, N'CASH_DRAWER_SERIAL_PORT_BAUD', N'Serial Port baud rate for cash drawer interface', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (143, N'COMMUNICATION_FAILURE_RETRIES', N'Retry attempts on communciation failure', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (145, N'MIFARE_CARD', N'Card type is Mi-Fare read-write card', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (149, N'AUTO_PRINT_SHIFT_CLOSE_RECEIPT', N'Automatically Print shift close receipt on shift close', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (151, N'IP_MASK_FOR_NETWORK_SCAN', N'IP Mask of network to be scanned to find MAC addresses', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (154, N'ALLOW_CONCURRENT_USER_LOGIN', N'Allow concurrent POS login by same user', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (157, N'PRINTER_PAGE_LEFT_MARGIN', N'Receipt Printer left side margin in 100ths of an inch', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (159, N'INVENTORY_QUANTITY_FORMAT', N'Display format for Inventory Quantity', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (160, N'INVENTORY_COST_FORMAT', N'Display format for Inventory Cost', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (163, N'ALLOW_DUPLICATE_UNIQUE_ID', N'Allow duplication of Unique Id in customer registration', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (164, N'GAMEPLAY_TICKETS_EXPIRY_DAYS', N'Number of days for game play tickets to expire', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (167, N'AUTO_EXTEND_BONUS_ON_RELOAD', N'Automatically extend expiry date of bonus on reload', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (168, N'ALLOW_MANUAL_CARD_IN_REDEMPTION', N'Allow entering card number manually in Redemption', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (170, N'CARD_MANDATORY_FOR_TRANSACTION', N'Card Mandatory for Transaction', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (172, N'USE_ORIGINAL_TRXNO_FOR_REFUND', N'Use the original card deposit transaction number for refund transaction', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (177, N'COIN_ACCEPTOR', N'Kiosk Coin Acceptor', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (179, N'CARD_DISPENSER', N'Kiosk Card Dispenser', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (180, N'VIP_POS_ALERT_RECHARGE_THRESHOLD', N'Recharge threshold amount to alert for VIP upgrade in POS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (182, N'LOG_TICKET_UPDATE_EVENT', N'Log ticket updates from game machines', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (183, N'CARD_DISPENSER_READER_OPT_STRING', N'Optional string of Card Dispenser USB card reader', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (186, N'FISCAL_PRINTER_BAUD_RATE', N'Fiscal Printer COM Port Baud Rate', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (187, N'FISCAL_PRINTER_PASSWORD', N'Fiscal Printer Password', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (189, N'RESET_TRXNO_AT_POS_LEVEL', N'Reset Trx No at POS level every business day', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (190, N'ALLOW_MANUAL_OVERRIDE', N'Allow manual override of queue system', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (192, N'QUEUE_MAX_ENTRIES', N'Maximum entries allowed in queue', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (195, N'QUEUE_BUFFER_TIME', N'Buffer to keep between game plays (excluding queue setup time)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (198, N'PLAY_START_ALERT_TIME', N'When the user should be highlighted to be called in', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (199, N'THIRD_PARTY_SYSTEM_SYNCH_URL', N'External game play management system web service URL', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (201, N'LOAD_BONUS_LIMIT', N'Max Load Bonus amount', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (202, N'LOAD_TICKETS_LIMIT', N'Max Load Tickets count', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (205, N'LOAD_FULL_VAR_AMOUNT_AS_CREDITS', N'Load the entire variable amount as credits, without considering tax amount in case of tax inclusive var. product', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (209, N'ADDRESS3', N'Show ADDRESS3', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (213, N'PIN', N'Show PIN', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (214, N'EMAIL', N'Show EMAIL', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (215, N'BIRTH_DATE', N'Show BIRTH_DATE', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (216, N'GENDER', N'Show GENDER', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (219, N'CONTACT_PHONE2', N'Show CONTACT_PHONE2', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (220, N'NOTES', N'Show NOTES', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (221, N'COMPANY', N'Show COMPANY', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (223, N'UNIQUE_ID', N'Show UNIQUE_ID', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (225, N'FBUSERID', N'Show FBUSERID', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (228, N'TWACCESSSECRET', N'Show TWACCESSSECRET', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (229, N'RIGHTHANDED', N'Show RIGHTHANDED', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (233, N'REVERSE_DESKTOP_CARD_NUMBER', N'Reverse the card number read by desktop card reader', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (234, N'QUEUE_VIEW_REFRESH', N'Refresh The Queue Management App', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (235, N'CUSTOMER_USERNAME_LENGTH', N'Customer Username length (0 for variable)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (237, N'AUTO_CHECK_IN_POS', N'Indicates whether a POS automatically checks-in a customer on card tap', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (238, N'CARD_PRODUCT_BUTTON_SIZE', N'Card Product Button size in POS (% of standard size)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (240, N'ENABLE_DIGITAL_TOKEN', N'Enable Digital Token - to verify valid gameplay as per queue entry', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (241, N'DIGITAL_TOKEN_ENABLE_COUNT', N'Number of queue positions that can be accepted as valid digital tokens', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (244, N'AUTO_SAVE_CHECKIN-CHECKOUT', N'Automatically save transaction after CheckIn-CheckOut', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (245, N'ADDITIONAL_BACKUP_PATH', N'Additonal Backup Path (For e.g., Pen Drive)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (247, N'KIOSK_PRODUCT_SCREEN_GREETING', N'Custom customer greeting in kiosk product screen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (248, N'ZERO_PRICE_GAMETIME_PLAY', N'Consider price of Game Time play to be 0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (250, N'UNIQUE_PRODUCT_REMARKS', N'Make transaction product remarks unique', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (252, N'RETAIN_REMOTE_BACKUP_FILES_FOR_DAYS', N'Days to retain backup files for in remote backup folder', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (254, N'ROUNDING_TYPE', N'Rounding algorithm to use for trx cash payments', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (258, N'CRM_SMTP_PORT', N'CRM SMTP Port number (default 587, -1 to ignore)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (260, N'CRM_SMTP_NETWORK_PASSWORD', N'CRM SMTP Login Password', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (261, N'CRM_SMTP_FROM_NAME', N'CRM Display Name for From Address', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (262, N'CRM_ENABLE_SMTP_SSL', N'Enable SSL for SMTP Client for CRM', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (263, N'CRM_SMS_PROVIDER_URL', N'CRM SMS Provider URL', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (271, N'POS_INACTIVE_TIMEOUT', N'Inactivity time (mins) after which re-authentication required by user', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (273, N'BUSINESS_DAY_START_TIME', N'Business day start hour', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (274, N'ENABLE_POS_ATTENDANCE', N'Log attendance on POS login / tech card tap', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (275, N'ATTRACTION_BOOKING_GRACE_PERIOD', N'Grace Period in minutes while booking past attraction schedules', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (276, N'CUT_RECEIPT_PAPER', N'Cut receipt paper or not', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (279, N'SIGNAGE_FOLDER', N'Server Folder for Signage files', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (282, N'REGISTRATION_MANDATORY_FOR_REDEMPTION', N'Redemption allowed only on registered cards', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (283, N'VERIFIED', N'Show VERIFIED', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (291, N'ENABLE_POS_DEBUG', N'Enable POS Debug', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (295, N'MAKE_CARD_NEW_ON_FULL_REFUND', N'By default, make the card NEW after refunding fully', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (296, N'INITLOAD_BATCH_SIZE', N'Number of records to upload in each batch during initial upload', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (297, N'ENABLE_BOOKINGS_IN_POS', N'Enable Bookings Tab in POS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (299, N'ENABLE_MANUAL_TICKET_IN_REDEMPTION', N'Enable manual ticket entry in Redemption', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (301, N'bowlertype', N'bowlertype', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (302, N'External System Identifier', N'External System Identifier', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (303, N'POS_MAC_ADDRESS', N'POS / Signage MAC Address', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (306, N'CARD_EXPIRY_RULE', N'Method used to calculate card expiry date', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (307, N'PASSWORD', N'Show PASSWORD', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (310, N'IS_VALID', N'Show IS_VALID', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (311, N'KDS_TERMINAL_REFRESH_INTERVAL', N'KDS Terminal refresh rate in seconds', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (316, N'REDEMPTION_GRACE_TICKETS_PERCENTAGE', N'% of grace tickets to add during redemption', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (317, N'DOWNGRADE_MEMBERSHIP_IF_INACTIVE_FOR', N'Downgrade membership if customer inactive for a period. (in months)', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (319, N'FULL_SCREEN_POS', N'Show POS in full screen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (320, N'MINIMUM_BREAK_TIME', N'Minimum break time', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (321, N'MAXIMUM_BREAK_TIME', N'Maximum break time', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (322, N'SHOW_DISPLAY_GROUP_BUTTONS', N'Display product display groups as buttons in POS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (324, N'ALLOW_MANUAL_CARD_IN_LOAD_BONUS', N'Allow manual card number in Load Bonus task', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (325, N'SHOW_HOME_SCREEN', N'Show Home Screen in POS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (328, N'HIDE_CC_DETAILS_IN_PAYMENT_SCREEN', N'Hide credit card details in payment screen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (330, N'OPEN_CASH_DRAWER_REQUIRES_MANAGER_APPROVAL', N'Manager approval required to open cash drawer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (339, N'POPUP_FAKE_NOTE_DETECTION_ALERT', N'Pop up an alert for fake note detection on transaction save in POS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (341, N'CARD_DISPENSER_READER_VID', N'Card Dispenser USB Reader VID', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (343, N'LAST_NAME', N'Show LAST_NAME', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (345, N'STATE_LOOKUP_FOR_COUNTRY', N'Country of whose States to be displayed in State lookups', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (346, N'KIOSK_CARD_VALUE_FORMAT', N'Number Format to display card values in Kiosk', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (348, N'NETWORK_SCAN_FREQUENCY', N'Frequency in seconds for network scan of readers', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (349, N'SHOW_REGISTRATION_AGE_GATE', N'Show age gate before registering customer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (350, N'REGISTRATION_AGE_LIMIT', N'Age limit for registering in kiosk', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (352, N'CANCEL_PRINTED_TRX_LINE', N'Allow canceling of printed trx line in POS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (354, N'PAYMENT_DENOMINATIONS', N'Denominations to show for tendered amount', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (357, N'ALOHA_JOB_CODE', N'Aloha Job Code', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (358, N'ALLOW_ONLY_CC_PAYMENT_IN_POS', N'Allow only Credit Card Payment in POS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (359, N'ALOHA_USER_ID', N'Aloha User Id', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (362, N'PRINT_THRID_PARTY_RECEIPT', N'Third party receipt prints receipt or not', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (363, N'DISABLE_PURCHASE_ON_CARD_LOW_LEVEL', N'Disable New Card purchase on card low level', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (365, N'IDPROOFFILENAME', N'Show IDPROOFFILENAME', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (367, N'ENABLE_GAME_READER_ATTENDANCE', N'Enable recording of attendance of tech cards at game readers', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (369, N'ENFORCE_PARENT_ACCOUNT_FOR_GAMEPLAY', N'Use parent card for game play when child card is tapped', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (370, N'AUTO_LOAD_BALANCE_TICKETS_TO_CARD', N'Balance physical tickets after redemption should be loaded to card automatically', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (371, N'AUTO_PRINT_BALANCE_TICKETS', N'Balance physical tickets after redemption should be printed as voucher automatically', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (373, N'ENABLE_MULTI_SCREEN_REDEMPTION', N'Enable multi-screen redemption', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (374, N'MAX_MANUAL_TICKETS_PER_REDEMPTION', N'Maximum allowed manual tickets per redemption', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (378, N'VIDEO_BORDER_COLOR', N'Video Border Color', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (379, N'IMAGE_BORDER_COLOR', N'Image Border Color', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (381, N'TICKER_FONT', N'Font for the ticker', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (384, N'TICKER_BORDER_COLOR', N'Ticker Border Color', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (385, N'UPLOAD_DIRECTORY', N'Upload Directory', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (386, N'REFRESH_FREQUENCY_FOR_PANEL_DATA', N'Refresh frequency for display panel', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (387, N'VIDEO_REFRESH_IN_SECS', N'Video Refresh In Secs', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (391, N'IMAGE_SIZE', N'Size of the Image', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (392, N'TICKER_SPEED', N'Ticker Speed', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (395, N'AUTO_CREATE_MISSING_MIFARE_CARD', N'Auto create a valid mifare card in DB if not found', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (400, N'ENABLE_ORDER_SHARE_ACROSS_USERS', N'Enable viewing of Orders across users', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (404, N'CUSTOMER_NAME_VALIDATION', N'Customer Name can contain only Alphabets', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (406, N'MEeZkAkpNmZaWcBX7UuQhvr2eHUjkqNe8GCE', N'Load credits to card instead Card Balance credit plus in Load Bonus task', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (408, N'LOCKER_SELECTION_MODE', N'Locker selection mode', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (413, N'ELEMENT_EXPRESS_ACCOUNT_TOKEN', N'Element Express Account Token', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (415, N'ELEMENT_EXPRESS_ACCEPTOR_ID', N'Element Express Acceptor ID', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (417, N'ELEMENT_EXPRESS_URL', N'Element Express URL', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (418, N'CREDIT_CARD_TERMINAL_PORT_NO', N'Credit Card Terminal Port number', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (419, N'CREDITCALL_TERMINAL_ID', N'Terminal ID defined for Creditcall payment integration', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (422, N'IS_HAWKEYE_ENVIRONMENT', N'Denotes if Hawkeye system integration is needed', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (423, N'READ_LOCKER_INFO_ON_CARD_READ', N'Read Locker details from card / wristband when tapped', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (424, N'IGNORE_THIRD_PARTY_SYNCH_ERROR', N'Ignore error during third party system synchronization', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (425, N'SPLIT_AND_MAP_VARIABLE_PRODUCT', N'Split and map variable product to actual products', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (428, N'MANUAL_CARD_UPDATE_GAMES_LIMIT', N'Maximum value for card games that can be set manually on a card', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (430, N'LOAD_BONUS_DEFAULT_ENT_TYPE', N'Default load bonus entitlement type', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (432, N'VIP_TERM_VARIANT', N'Term used for VIP', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (434, N'BALANCE_SCREEN_TIMEOUT', N'Time out duration in seconds for Balance check screen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (436, N'ALLOW_OVERPAY_IN_KIOSK', N'Allow over-payment in kiosk', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (437, N'REGISTER_BEFORE_PURCHASE', N'Show Registration screen before purchase if not yet registered', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (442, N'AUTO_PRINT_LOAD_BONUS', N'Automatically print load bonus details when OK is clicked', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (443, N'MEeZkAkpNmZaWcBX7UuQhvr2eHUjkqNe8GKET', N'Manager approval is required for adding manual tickets in redemption', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (445, N'VENDOR_FILE_FORMAT', N'Vendor file format', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (446, N'PRODUCT_FILE_FORMAT', N'Product file format', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (451, N'FAILURE_EMAIL_LIST', N'List of email IDs to which email should be sent upon failure in any stage', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (453, N'FTP_USERNAME', N'FTP username to pick Inventory files', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (454, N'FTP_PASSSWORD', N'FTP password to pick Inventory files', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (455, N'FTP_SITE_FOLDER', N'Site file folder in FTP location', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (457, N'FTP_PRODUCT_FOLDER', N'Product file folder in FTP location', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (463, N'PO_TEMPLATE_FILE_PATH', N'Template csv for PO file comparison', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (464, N'INVENTORY_FILE_DOWNLOAD_DIRECTORY', N'Folder to which FTP file should be downloaded', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (465, N'SEND_SUMMARY_EMAIL', N'Flag to decide if Summary email is to be sent after load process', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (467, N'DELETE_ALERT_EMAIL_LIST', N'List of email Ids separated with comma for mass delete files', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (473, N'HIDE_DENOMINATION_GRID', N'Hide denomination grid in kiosk money screen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (474, N'CARD_EXPIRY_GRACE_PERIOD', N'Grace period in days after card expiry', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (477, N'PROMO_SMS_PROVIDER_URL', N'Promotional SMS Provider URL', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (478, N'PROMO_SMS_USERNAME', N'Promotional SMS Login Username', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (481, N'PROMO_SMS_END_TIME', N'End time for sending Promotional SMS based on regulatory rules', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (483, N'SALESFORCE_OPT-IN_SUBSCRIBER_LISTNAME', N'Subscriber list name for opt-in customers in Salesforce Marketing Cloud (ExactTarget) system', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (485, N'TITLE', N'Show TITLE', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (490, N'FIRST_DATA_CLIENT_TIMEOUT', N'First Data Client Timeout in seconds', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (492, N'FIRST_DATA_SERVICE_ID', N'First Data Service ID', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (496, N'FIRST_DATA_SRS_URL', N'First Data SRS URL', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (497, N'FIRST_DATA_TRANSACTION_URL', N'First Data TRANSACTION URL', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (498, N'FIRST_DATA_TOKEN_TYPE', N'First Data token type', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (499, N'FIRST_DATA_DOMAIN', N'First Data Domain', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (501, N'FIRST_DATA_MCC', N'First Data Merchant Category Code', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (504, N'MERCURY_MERCHANTID_PASSWORD', N'Merchant ID password for Mercury Gateway', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (506, N'PRINT_CUSTOMER_RECEIPT', N'Option to disable printing of Customer receipt for Credit Card Payment Gateway', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (507, N'PERFORM_DIRECT_ALOHA_SYNC', N'Perform Aloha sync directly from POS instead of Exsys Server', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (508, N'SALES_REPORT_FTP_URL', N'FTP URL for the Third Party', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (511, N'SALES_REPORT_FAILURE_MAIL_IDS', N'Sales Report Failure Mail Ids', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (512, N'SITE_IMAGE_FILENAME', N'File name of Site logo to be used as splash screen in Tablet', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (513, N'SHOW_TIP_AMOUNT_KEYPAD', N'Show keypad for entering Tip Amount', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (515, N'APPMEeZkAkpNmZaWcBX7UuQhvr2eHUjkqNe8GEPORT', N'Apply GST Percentage in Game Metric', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (516, N'PRINT_COMBO_DETAILS', N'Print Child Lines for combo details', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (518, N'TRANSACTION_REPRINT_REQUIRES_MANAGER_APPROVAL', N'Manager approval required for reprint transaction', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (44, N'REMOTE_BACKUP_PATH', N'Share Directory for Backup Files to be copied on Remote (Backup) Server', N'', N'string', N'BackUp', 1, NULL, NULL, NULL, NULL, NULL, N'Share Directory for Backup Files to be copied on Remote (Backup) Server')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (45, N'REPORT_SERVER_ENABLED', N'Enables Reports Server for the Site', N'true', N'bool', N'server', 1, NULL, NULL, NULL, NULL, NULL, N'Enables Reports Server for the Site')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (46, N'WEB_UPLOAD_SERVER_ENABLED', N'Enables Web Upload Server for the Site', N'true', N'bool', N'server', 1, NULL, NULL, NULL, NULL, NULL, N'Enables Web Upload Server for the Site')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (48, N'MAIN_SERVER_RESTART_ATTEMPTS', N'Restart attempts in Wireless Server in case of no response from HUB', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Restart attempts in Wireless Server in case of no response from HUB')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (52, N'ALLOW_ROAMING_CARDS', N'Allow Other Site Cards to Play / Recharge at this center', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Allow Other Site Cards to Play / Recharge at this center')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (53, N'CHECK_FOR_CARD_EXCEPTIONS', N'Check if there are exceptions defined on specific cards to restrict game play on any machines and vice versa', N'true', N'bool', N'server', 1, NULL, NULL, NULL, NULL, NULL, N'Check if there are exceptions defined on specific cards to restrict game play on any machines and vice versa')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (54, N'MIN_TIME_BETWEEN_POLLS', N'Minimum Time required between two polls in milliseconds', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Minimum Time required between two polls in milliseconds')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (56, N'READER_DISPLAY_SITENAME', N'Site Name to be displayed on Card Readers', N'', N'string', N'server', 1, NULL, NULL, NULL, NULL, NULL, N'Site Name to be displayed on Card Readers')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (63, N'SECONDS_BEFORE_TIMER_BLINK', N'Number of seconds before reader should start blinking before timer expiry', N'', N'string', N'server', 1, NULL, NULL, NULL, NULL, NULL, N'Number of seconds before reader should start blinking before timer expiry')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (64, N'ENABLE_MANUAL_PRODUCT_SEARCH_IN_POS', N'Enable Manual Product Search in POS', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Enable Manual Product Search in POS')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (66, N'WEB_UPLOAD_BATCH_DAYS', N'Max number of days to upload data for in 1 batch', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Max number of days to upload data for in 1 batch')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (69, N'AMEeZkAkpNmZaWcBX7UuQhvr2eHUjkqNe8G', N'Allow credit card payment in External Payment Gateway', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Allow credit card payment in External Payment Gateway')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (70, N'ALLOW_LOYALTY_ON_GAMEPLAY', N'Allow Loyalty Transaction on Game Play', N'true', N'bool', N'server', 1, NULL, NULL, NULL, NULL, NULL, N'Allow Loyalty Transaction on Game Play')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (71, N'PRINT_TRANSACTION_ITEM_TICKETS', N'Print Transaction Line Items as Tickets', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Print Transaction Line Items as Tickets')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (72, N'PRINT_RECEIPT_ON_BILL_PRINTER', N'Allow Printing of Transaction Receipt on bill printer', N'true', N'bool', N'print', 1, NULL, NULL, NULL, NULL, NULL, N'Allow Printing of Transaction Receipt on bill printer')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (522, N'FREE_PLAY_CARD_MAGIC_COUNTER', N'Magic number to store in free play activation cards', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (525, N'MAIN_INSTALLER_RUN_FREQUENCY', N'Main installer frequency in seconds', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (531, N'FISCAL_DEVICE_TCP/IP_ADDRESS', N'Fiscal device Tcp/ip address', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (532, N'FISCAL_CASH_REGISTER_ID', N'Cash register id', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (537, N'TENANT_ID', N'Tenant ID', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (539, N'DISPENSER_READER_SERIAL_NUMBER', N'Serial Number of the Kiosk Dispenser card reader device', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (540, N'ENABLE_ERP_INTEGRATION', N'Enable ERP Integration', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (542, N'ERP_SENDERCODE', N'Erp XML Sender Code for YonYou Integration', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (543, N'ENABLE_SINGLE_USER_MULTI_SCREEN', N'Enable single user mult-screen redemption', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (545, N'POLE_DISPLAY_CHARACTER_SET_CODE', N'Define Character set code for Pole Display. Default is GB18030', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (548, N'EXCMEeZkAkpNmZaWcBX7UuQhvr2eHUjkqNe8GRT', N'Exclude product breakdown section in transaction report', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (552, N'CAPILLARY_INTEGRATION_USERNAME', N'Capillary Integration Username', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (553, N'CAPILLARY_INTEGRATION_PASSWORD', N'Capillary Integration Password', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (554, N'ENABLE_KIOSK_DIRECT_CASH', N'Enable direct cash feature in kiosks', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (267, N'ATTENDANCE_TYPE_DETERMINATION_METHOD', N'Attendance Type Determination Method', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Attendance Type Determination Method')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (268, N'DEFAULT_WORKSHIFT_STARTTIME', N'Default Time for shift start', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Default Time for shift start')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (269, N'CUSTOMER_PHOTO', N'Customer Photo', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Customer Photo')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (270, N'REQUIRE_LOGIN_FOR_EACH_TRX', N'Requires user authentication for each transaction', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Requires user authentication for each transaction')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (272, N'INCLUDE_TAXAMOUNT_FOR_LOYALTY_CALC', N'Loyalty is calculated on the total amount including tax', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Loyalty is calculated on the total amount including tax')
INSERT [dbo].[Settings] ([ID], [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [LastUpdatedBy], [LastUpdatedDate], [Caption]) VALUES (277, N'CUT_TICKET_PAPER', N'Cut attraction ticket paper or not', N'true', N'bool', N'', 1, NULL, NULL, NULL, NULL, NULL, N'Cut attraction ticket paper or not')
SET IDENTITY_INSERT [dbo].[Settings] OFF
SET IDENTITY_INSERT [dbo].[Site] ON 

INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteCode], [SiteAddress], [SiteGUID], [Notes], [Logo], [Guid], [CompanyId], [MaxCards], [CustomerKey], [Version], [LastUpdatedTime]) VALUES (1, N'Site1', 1, N'Bangalore', N'e39bf5d7-4298-4b1c-9bfc-9fea30cfc430', N'', NULL, N'5677f898-c320-42ed-b739-67ba6faa9675', NULL, NULL, N'', N'', CAST(N'2019-08-24T22:35:35.100' AS DateTime))
SET IDENTITY_INSERT [dbo].[Site] OFF
SET IDENTITY_INSERT [dbo].[Tax] ON 

INSERT [dbo].[Tax] ([TaxId], [TaxName], [TaxPercent], [ActiveFlag]) VALUES (1, N'GST', CAST(10 AS Decimal(18, 0)), 1)
INSERT [dbo].[Tax] ([TaxId], [TaxName], [TaxPercent], [ActiveFlag]) VALUES (2, N'SGST', CAST(15 AS Decimal(18, 0)), 1)
INSERT [dbo].[Tax] ([TaxId], [TaxName], [TaxPercent], [ActiveFlag]) VALUES (3, N'TAX', CAST(17 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[Tax] OFF
SET IDENTITY_INSERT [dbo].[TaxStructure] ON 

INSERT [dbo].[TaxStructure] ([TaxStructureId], [TaxId], [StructureName], [TaxStructurePercentage]) VALUES (1, 2, N'M-GST', CAST(10 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[TaxStructure] OFF
SET IDENTITY_INSERT [dbo].[TransactionDiscountLines] ON 

INSERT [dbo].[TransactionDiscountLines] ([TrxDiscountId], [TrxId], [LineId], [DiscountId], [DiscountPercentage], [DiscountAmount], [Remarks], [ApprovedBy]) VALUES (1, 2, 0, 2, CAST(10.0000 AS Decimal(18, 4)), CAST(11.0000 AS Decimal(18, 4)), N'', 0)
INSERT [dbo].[TransactionDiscountLines] ([TrxDiscountId], [TrxId], [LineId], [DiscountId], [DiscountPercentage], [DiscountAmount], [Remarks], [ApprovedBy]) VALUES (2, 2, 0, 1, CAST(5.0000 AS Decimal(18, 4)), CAST(5.5000 AS Decimal(18, 4)), N'', 0)
INSERT [dbo].[TransactionDiscountLines] ([TrxDiscountId], [TrxId], [LineId], [DiscountId], [DiscountPercentage], [DiscountAmount], [Remarks], [ApprovedBy]) VALUES (3, 2, 2, 2, CAST(10.0000 AS Decimal(18, 4)), CAST(5.7500 AS Decimal(18, 4)), N'', 0)
INSERT [dbo].[TransactionDiscountLines] ([TrxDiscountId], [TrxId], [LineId], [DiscountId], [DiscountPercentage], [DiscountAmount], [Remarks], [ApprovedBy]) VALUES (4, 2, 2, 1, CAST(5.0000 AS Decimal(18, 4)), CAST(2.8750 AS Decimal(18, 4)), N'', 0)
INSERT [dbo].[TransactionDiscountLines] ([TrxDiscountId], [TrxId], [LineId], [DiscountId], [DiscountPercentage], [DiscountAmount], [Remarks], [ApprovedBy]) VALUES (5, 2, 3, 2, CAST(10.0000 AS Decimal(18, 4)), CAST(11.5000 AS Decimal(18, 4)), N'', 0)
INSERT [dbo].[TransactionDiscountLines] ([TrxDiscountId], [TrxId], [LineId], [DiscountId], [DiscountPercentage], [DiscountAmount], [Remarks], [ApprovedBy]) VALUES (6, 2, 3, 1, CAST(5.0000 AS Decimal(18, 4)), CAST(5.7500 AS Decimal(18, 4)), N'', 0)
INSERT [dbo].[TransactionDiscountLines] ([TrxDiscountId], [TrxId], [LineId], [DiscountId], [DiscountPercentage], [DiscountAmount], [Remarks], [ApprovedBy]) VALUES (7, 3, 0, 3, CAST(15.0000 AS Decimal(18, 4)), CAST(13.1625 AS Decimal(18, 4)), N'', 0)
INSERT [dbo].[TransactionDiscountLines] ([TrxDiscountId], [TrxId], [LineId], [DiscountId], [DiscountPercentage], [DiscountAmount], [Remarks], [ApprovedBy]) VALUES (8, 3, 1, 3, CAST(15.0000 AS Decimal(18, 4)), CAST(17.2500 AS Decimal(18, 4)), N'', 0)
INSERT [dbo].[TransactionDiscountLines] ([TrxDiscountId], [TrxId], [LineId], [DiscountId], [DiscountPercentage], [DiscountAmount], [Remarks], [ApprovedBy]) VALUES (9, 3, 2, 3, CAST(15.0000 AS Decimal(18, 4)), CAST(8.6250 AS Decimal(18, 4)), N'', 0)
INSERT [dbo].[TransactionDiscountLines] ([TrxDiscountId], [TrxId], [LineId], [DiscountId], [DiscountPercentage], [DiscountAmount], [Remarks], [ApprovedBy]) VALUES (10, 4, 0, 2, CAST(10.0000 AS Decimal(18, 4)), CAST(11.0000 AS Decimal(18, 4)), N'', 0)
SET IDENTITY_INSERT [dbo].[TransactionDiscountLines] OFF
SET IDENTITY_INSERT [dbo].[TransactionHeader] ON 

INSERT [dbo].[TransactionHeader] ([TrxId], [TrxDate], [TrxAmount], [TrxDiscountPercentage], [TaxAmount], [TrxNetAmount], [POSMachine], [UserId], [PaymentMode], [CashAmount], [CreditCardAmount], [GameCardAmount], [PaymentReference], [PrimaryCardId], [OrderId], [POSTypeId], [Guid], [SiteId], [TrxNummber], [Remarks], [POSMachineId], [SynchStatus], [OtherPaymentModeAmount], [Status], [TrxProfileId], [LastUpdateTime], [LastUpdatedBy], [TokenNumber], [Original_System_Reference], [CustomerId], [ExternalSystemReference], [ReprintCount], [OriginalTrxID], [MasterEntityId]) VALUES (1, CAST(N'2019-10-20T00:00:00.000' AS DateTime), 110, 0, 10, 110, NULL, 0, 0, 0, 0, 0, NULL, 0, 0, 0, N'62605f51-f129-4b4b-86fb-fa091db5515f', NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Numeric(18, 4)), NULL, 0, CAST(N'2019-10-20T18:03:33.950' AS DateTime), NULL, 0, NULL, 0, NULL, 0, 0, NULL)
INSERT [dbo].[TransactionHeader] ([TrxId], [TrxDate], [TrxAmount], [TrxDiscountPercentage], [TaxAmount], [TrxNetAmount], [POSMachine], [UserId], [PaymentMode], [CashAmount], [CreditCardAmount], [GameCardAmount], [PaymentReference], [PrimaryCardId], [OrderId], [POSTypeId], [Guid], [SiteId], [TrxNummber], [Remarks], [POSMachineId], [SynchStatus], [OtherPaymentModeAmount], [Status], [TrxProfileId], [LastUpdateTime], [LastUpdatedBy], [TokenNumber], [Original_System_Reference], [CustomerId], [ExternalSystemReference], [ReprintCount], [OriginalTrxID], [MasterEntityId]) VALUES (2, CAST(N'2019-10-20T00:00:00.000' AS DateTime), 282.5, 15, 32.5, 240.13, NULL, 0, 0, 0, 0, 0, NULL, 0, 0, 0, N'13e0b879-8479-45b2-ad4e-f252c5c680ee', NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Numeric(18, 4)), NULL, 0, CAST(N'2019-10-20T18:11:22.257' AS DateTime), NULL, 0, NULL, 0, NULL, 0, 0, NULL)
INSERT [dbo].[TransactionHeader] ([TrxId], [TrxDate], [TrxAmount], [TrxDiscountPercentage], [TaxAmount], [TrxNetAmount], [POSMachine], [UserId], [PaymentMode], [CashAmount], [CreditCardAmount], [GameCardAmount], [PaymentReference], [PrimaryCardId], [OrderId], [POSTypeId], [Guid], [SiteId], [TrxNummber], [Remarks], [POSMachineId], [SynchStatus], [OtherPaymentModeAmount], [Status], [TrxProfileId], [LastUpdateTime], [LastUpdatedBy], [TokenNumber], [Original_System_Reference], [CustomerId], [ExternalSystemReference], [ReprintCount], [OriginalTrxID], [MasterEntityId]) VALUES (3, CAST(N'2019-10-20T00:00:00.000' AS DateTime), 202.75, 15, 27.75, 172.34, NULL, 0, 0, 0, 0, 0, NULL, 0, 0, 0, N'6f25630d-b18b-41aa-ad9f-089d2de60590', NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Numeric(18, 4)), NULL, 0, CAST(N'2019-10-20T18:14:03.593' AS DateTime), NULL, 0, NULL, 0, NULL, 0, 0, NULL)
INSERT [dbo].[TransactionHeader] ([TrxId], [TrxDate], [TrxAmount], [TrxDiscountPercentage], [TaxAmount], [TrxNetAmount], [POSMachine], [UserId], [PaymentMode], [CashAmount], [CreditCardAmount], [GameCardAmount], [PaymentReference], [PrimaryCardId], [OrderId], [POSTypeId], [Guid], [SiteId], [TrxNummber], [Remarks], [POSMachineId], [SynchStatus], [OtherPaymentModeAmount], [Status], [TrxProfileId], [LastUpdateTime], [LastUpdatedBy], [TokenNumber], [Original_System_Reference], [CustomerId], [ExternalSystemReference], [ReprintCount], [OriginalTrxID], [MasterEntityId]) VALUES (4, CAST(N'2019-10-20T00:00:00.000' AS DateTime), 110, 10, 10, 99, NULL, 0, 0, 0, 0, 0, NULL, 0, 0, 0, N'cda10507-b920-440b-8351-9b68ff9cc6f3', NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Numeric(18, 4)), NULL, 0, CAST(N'2019-10-20T19:03:29.643' AS DateTime), NULL, 0, NULL, 0, NULL, 0, 0, NULL)
INSERT [dbo].[TransactionHeader] ([TrxId], [TrxDate], [TrxAmount], [TrxDiscountPercentage], [TaxAmount], [TrxNetAmount], [POSMachine], [UserId], [PaymentMode], [CashAmount], [CreditCardAmount], [GameCardAmount], [PaymentReference], [PrimaryCardId], [OrderId], [POSTypeId], [Guid], [SiteId], [TrxNummber], [Remarks], [POSMachineId], [SynchStatus], [OtherPaymentModeAmount], [Status], [TrxProfileId], [LastUpdateTime], [LastUpdatedBy], [TokenNumber], [Original_System_Reference], [CustomerId], [ExternalSystemReference], [ReprintCount], [OriginalTrxID], [MasterEntityId]) VALUES (5, CAST(N'2019-10-20T00:00:00.000' AS DateTime), 55, 0, 5, 55, NULL, 0, 0, 0, 0, 0, NULL, 0, 0, 0, N'1e5dc7ce-5bb3-4fbc-a5cc-977506227259', NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Numeric(18, 4)), NULL, 0, CAST(N'2019-10-20T19:04:46.990' AS DateTime), NULL, 0, NULL, 1, NULL, 0, 0, NULL)
INSERT [dbo].[TransactionHeader] ([TrxId], [TrxDate], [TrxAmount], [TrxDiscountPercentage], [TaxAmount], [TrxNetAmount], [POSMachine], [UserId], [PaymentMode], [CashAmount], [CreditCardAmount], [GameCardAmount], [PaymentReference], [PrimaryCardId], [OrderId], [POSTypeId], [Guid], [SiteId], [TrxNummber], [Remarks], [POSMachineId], [SynchStatus], [OtherPaymentModeAmount], [Status], [TrxProfileId], [LastUpdateTime], [LastUpdatedBy], [TokenNumber], [Original_System_Reference], [CustomerId], [ExternalSystemReference], [ReprintCount], [OriginalTrxID], [MasterEntityId]) VALUES (6, CAST(N'2019-10-20T00:00:00.000' AS DateTime), 46.8, 0, 6.8, 46.8, NULL, 0, 0, 0, 0, 0, NULL, 1, 0, 0, N'decb1027-efd3-43f6-8307-6f420f4607dd', NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Numeric(18, 4)), NULL, 0, CAST(N'2019-10-20T19:07:27.347' AS DateTime), NULL, 0, NULL, 2, NULL, 0, 0, NULL)
INSERT [dbo].[TransactionHeader] ([TrxId], [TrxDate], [TrxAmount], [TrxDiscountPercentage], [TaxAmount], [TrxNetAmount], [POSMachine], [UserId], [PaymentMode], [CashAmount], [CreditCardAmount], [GameCardAmount], [PaymentReference], [PrimaryCardId], [OrderId], [POSTypeId], [Guid], [SiteId], [TrxNummber], [Remarks], [POSMachineId], [SynchStatus], [OtherPaymentModeAmount], [Status], [TrxProfileId], [LastUpdateTime], [LastUpdatedBy], [TokenNumber], [Original_System_Reference], [CustomerId], [ExternalSystemReference], [ReprintCount], [OriginalTrxID], [MasterEntityId]) VALUES (7, CAST(N'2019-10-20T00:00:00.000' AS DateTime), 56.8, 0, 6.8, 56.8, NULL, 0, 0, 0, 0, 0, NULL, 2, 0, 0, N'72b0ead1-5b85-4e3d-b89e-af3bc2bfd58e', NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Numeric(18, 4)), NULL, 0, CAST(N'2019-10-20T19:10:38.527' AS DateTime), NULL, 0, NULL, 0, NULL, 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[TransactionHeader] OFF
INSERT [dbo].[TransactionLines] ([TrxId], [LineId], [ProductId], [Price], [Quantity], [Amount], [CardId], [CardNumber], [Credits], [Courtesy], [TaxPercentage], [TaxId], [Time], [Bonus], [Tickets], [LoyaltyPoints], [Guid], [SiteId], [Remarks], [PromotionId], [SynchStatus], [ReceiptPrinted], [ParentLineId], [UserPrice], [KOTPrintCount], [GameplayId], [KDSSent], [CreditPlusConsumptionId], [CancelledTime], [CancelledBy], [ProductDescription], [IsWaiverSignRequired], [OriginalLineID], [MasterEntityId]) VALUES (1, 0, 3, 100, CAST(2.0000 AS Numeric(10, 4)), 110, 0, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 10, 1, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0 AS Numeric(8, 0)), CAST(0.0000 AS Decimal(18, 4)), N'5943e18b-1c53-4f10-8362-65b5c4a2f503', NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TransactionLines] ([TrxId], [LineId], [ProductId], [Price], [Quantity], [Amount], [CardId], [CardNumber], [Credits], [Courtesy], [TaxPercentage], [TaxId], [Time], [Bonus], [Tickets], [LoyaltyPoints], [Guid], [SiteId], [Remarks], [PromotionId], [SynchStatus], [ReceiptPrinted], [ParentLineId], [UserPrice], [KOTPrintCount], [GameplayId], [KDSSent], [CreditPlusConsumptionId], [CancelledTime], [CancelledBy], [ProductDescription], [IsWaiverSignRequired], [OriginalLineID], [MasterEntityId]) VALUES (2, 0, 3, 100, CAST(2.0000 AS Numeric(10, 4)), 110, 0, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 10, 1, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0 AS Numeric(8, 0)), CAST(0.0000 AS Decimal(18, 4)), N'a32b265d-821d-400e-b46f-46e8c4548d5e', NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TransactionLines] ([TrxId], [LineId], [ProductId], [Price], [Quantity], [Amount], [CardId], [CardNumber], [Credits], [Courtesy], [TaxPercentage], [TaxId], [Time], [Bonus], [Tickets], [LoyaltyPoints], [Guid], [SiteId], [Remarks], [PromotionId], [SynchStatus], [ReceiptPrinted], [ParentLineId], [UserPrice], [KOTPrintCount], [GameplayId], [KDSSent], [CreditPlusConsumptionId], [CancelledTime], [CancelledBy], [ProductDescription], [IsWaiverSignRequired], [OriginalLineID], [MasterEntityId]) VALUES (2, 2, 4, 50, CAST(1.0000 AS Numeric(10, 4)), 57.5, 0, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 15, 2, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0 AS Numeric(8, 0)), CAST(0.0000 AS Decimal(18, 4)), N'6c12f288-7d92-403f-b9b5-f7263fa52ad5', NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TransactionLines] ([TrxId], [LineId], [ProductId], [Price], [Quantity], [Amount], [CardId], [CardNumber], [Credits], [Courtesy], [TaxPercentage], [TaxId], [Time], [Bonus], [Tickets], [LoyaltyPoints], [Guid], [SiteId], [Remarks], [PromotionId], [SynchStatus], [ReceiptPrinted], [ParentLineId], [UserPrice], [KOTPrintCount], [GameplayId], [KDSSent], [CreditPlusConsumptionId], [CancelledTime], [CancelledBy], [ProductDescription], [IsWaiverSignRequired], [OriginalLineID], [MasterEntityId]) VALUES (2, 3, 6, 100, CAST(1.0000 AS Numeric(10, 4)), 115, 0, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 15, 2, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0 AS Numeric(8, 0)), CAST(0.0000 AS Decimal(18, 4)), N'4fe143b1-9aa5-442a-9375-1e092ff49086', NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TransactionLines] ([TrxId], [LineId], [ProductId], [Price], [Quantity], [Amount], [CardId], [CardNumber], [Credits], [Courtesy], [TaxPercentage], [TaxId], [Time], [Bonus], [Tickets], [LoyaltyPoints], [Guid], [SiteId], [Remarks], [PromotionId], [SynchStatus], [ReceiptPrinted], [ParentLineId], [UserPrice], [KOTPrintCount], [GameplayId], [KDSSent], [CreditPlusConsumptionId], [CancelledTime], [CancelledBy], [ProductDescription], [IsWaiverSignRequired], [OriginalLineID], [MasterEntityId]) VALUES (3, 0, 5, 75, CAST(1.0000 AS Numeric(10, 4)), 87.75, 0, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 17, 3, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0 AS Numeric(8, 0)), CAST(0.0000 AS Decimal(18, 4)), N'4377633a-766d-4293-a4d1-082644ab2e46', NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TransactionLines] ([TrxId], [LineId], [ProductId], [Price], [Quantity], [Amount], [CardId], [CardNumber], [Credits], [Courtesy], [TaxPercentage], [TaxId], [Time], [Bonus], [Tickets], [LoyaltyPoints], [Guid], [SiteId], [Remarks], [PromotionId], [SynchStatus], [ReceiptPrinted], [ParentLineId], [UserPrice], [KOTPrintCount], [GameplayId], [KDSSent], [CreditPlusConsumptionId], [CancelledTime], [CancelledBy], [ProductDescription], [IsWaiverSignRequired], [OriginalLineID], [MasterEntityId]) VALUES (3, 1, 6, 100, CAST(1.0000 AS Numeric(10, 4)), 115, 0, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 15, 2, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0 AS Numeric(8, 0)), CAST(0.0000 AS Decimal(18, 4)), N'01dbb151-f9c2-4af7-906c-50f1437614e8', NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TransactionLines] ([TrxId], [LineId], [ProductId], [Price], [Quantity], [Amount], [CardId], [CardNumber], [Credits], [Courtesy], [TaxPercentage], [TaxId], [Time], [Bonus], [Tickets], [LoyaltyPoints], [Guid], [SiteId], [Remarks], [PromotionId], [SynchStatus], [ReceiptPrinted], [ParentLineId], [UserPrice], [KOTPrintCount], [GameplayId], [KDSSent], [CreditPlusConsumptionId], [CancelledTime], [CancelledBy], [ProductDescription], [IsWaiverSignRequired], [OriginalLineID], [MasterEntityId]) VALUES (3, 2, 4, 50, CAST(1.0000 AS Numeric(10, 4)), 57.5, 0, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 15, 2, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0 AS Numeric(8, 0)), CAST(0.0000 AS Decimal(18, 4)), N'710820e0-067b-455d-8790-f69316d8bebf', NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TransactionLines] ([TrxId], [LineId], [ProductId], [Price], [Quantity], [Amount], [CardId], [CardNumber], [Credits], [Courtesy], [TaxPercentage], [TaxId], [Time], [Bonus], [Tickets], [LoyaltyPoints], [Guid], [SiteId], [Remarks], [PromotionId], [SynchStatus], [ReceiptPrinted], [ParentLineId], [UserPrice], [KOTPrintCount], [GameplayId], [KDSSent], [CreditPlusConsumptionId], [CancelledTime], [CancelledBy], [ProductDescription], [IsWaiverSignRequired], [OriginalLineID], [MasterEntityId]) VALUES (5, 0, 3, 50, CAST(1.0000 AS Numeric(10, 4)), 55, 0, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 10, 1, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0 AS Numeric(8, 0)), CAST(0.0000 AS Decimal(18, 4)), N'52ab9fc7-bb4f-4fec-a640-a1ed2878e3f0', NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TransactionLines] ([TrxId], [LineId], [ProductId], [Price], [Quantity], [Amount], [CardId], [CardNumber], [Credits], [Courtesy], [TaxPercentage], [TaxId], [Time], [Bonus], [Tickets], [LoyaltyPoints], [Guid], [SiteId], [Remarks], [PromotionId], [SynchStatus], [ReceiptPrinted], [ParentLineId], [UserPrice], [KOTPrintCount], [GameplayId], [KDSSent], [CreditPlusConsumptionId], [CancelledTime], [CancelledBy], [ProductDescription], [IsWaiverSignRequired], [OriginalLineID], [MasterEntityId]) VALUES (4, 0, 3, 100, CAST(2.0000 AS Numeric(10, 4)), 110, 0, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 10, 1, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0 AS Numeric(8, 0)), CAST(0.0000 AS Decimal(18, 4)), N'242d3f0b-1baa-474b-8799-65c830f1e75b', NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TransactionLines] ([TrxId], [LineId], [ProductId], [Price], [Quantity], [Amount], [CardId], [CardNumber], [Credits], [Courtesy], [TaxPercentage], [TaxId], [Time], [Bonus], [Tickets], [LoyaltyPoints], [Guid], [SiteId], [Remarks], [PromotionId], [SynchStatus], [ReceiptPrinted], [ParentLineId], [UserPrice], [KOTPrintCount], [GameplayId], [KDSSent], [CreditPlusConsumptionId], [CancelledTime], [CancelledBy], [ProductDescription], [IsWaiverSignRequired], [OriginalLineID], [MasterEntityId]) VALUES (6, 0, 7, 40, CAST(1.0000 AS Numeric(10, 4)), 46.8, -1, NULL, CAST(60.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 17, 3, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0 AS Numeric(8, 0)), CAST(0.0000 AS Decimal(18, 4)), N'e948b107-0261-4ba5-bdd9-996ac7bd25c9', NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TransactionLines] ([TrxId], [LineId], [ProductId], [Price], [Quantity], [Amount], [CardId], [CardNumber], [Credits], [Courtesy], [TaxPercentage], [TaxId], [Time], [Bonus], [Tickets], [LoyaltyPoints], [Guid], [SiteId], [Remarks], [PromotionId], [SynchStatus], [ReceiptPrinted], [ParentLineId], [UserPrice], [KOTPrintCount], [GameplayId], [KDSSent], [CreditPlusConsumptionId], [CancelledTime], [CancelledBy], [ProductDescription], [IsWaiverSignRequired], [OriginalLineID], [MasterEntityId]) VALUES (7, 0, 0, 10, CAST(1.0000 AS Numeric(10, 4)), 10, -1, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 0, 0, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0 AS Numeric(8, 0)), CAST(0.0000 AS Decimal(18, 4)), N'f11f5bad-e299-4dbc-ae8b-9f7712c33b15', NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TransactionLines] ([TrxId], [LineId], [ProductId], [Price], [Quantity], [Amount], [CardId], [CardNumber], [Credits], [Courtesy], [TaxPercentage], [TaxId], [Time], [Bonus], [Tickets], [LoyaltyPoints], [Guid], [SiteId], [Remarks], [PromotionId], [SynchStatus], [ReceiptPrinted], [ParentLineId], [UserPrice], [KOTPrintCount], [GameplayId], [KDSSent], [CreditPlusConsumptionId], [CancelledTime], [CancelledBy], [ProductDescription], [IsWaiverSignRequired], [OriginalLineID], [MasterEntityId]) VALUES (7, 1, 7, 40, CAST(1.0000 AS Numeric(10, 4)), 46.8, -1, NULL, CAST(60.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 17, 3, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0 AS Numeric(8, 0)), CAST(0.0000 AS Decimal(18, 4)), N'ab3d3663-b1bc-4705-b7eb-9763836c96aa', NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TransactionTaxLines] ([TrxId], [LineId], [TaxId], [TaxStructureId], [Percentage], [Amount], [ProductSplitAmount]) VALUES (1, 0, 1, 0, CAST(10.0000 AS Numeric(18, 4)), CAST(10.0000 AS Numeric(18, 4)), CAST(0.0000 AS Numeric(18, 4)))
INSERT [dbo].[TransactionTaxLines] ([TrxId], [LineId], [TaxId], [TaxStructureId], [Percentage], [Amount], [ProductSplitAmount]) VALUES (2, 0, 1, 0, CAST(10.0000 AS Numeric(18, 4)), CAST(10.0000 AS Numeric(18, 4)), CAST(0.0000 AS Numeric(18, 4)))
INSERT [dbo].[TransactionTaxLines] ([TrxId], [LineId], [TaxId], [TaxStructureId], [Percentage], [Amount], [ProductSplitAmount]) VALUES (2, 2, 2, 0, CAST(15.0000 AS Numeric(18, 4)), CAST(7.5000 AS Numeric(18, 4)), CAST(0.0000 AS Numeric(18, 4)))
INSERT [dbo].[TransactionTaxLines] ([TrxId], [LineId], [TaxId], [TaxStructureId], [Percentage], [Amount], [ProductSplitAmount]) VALUES (2, 3, 2, 0, CAST(15.0000 AS Numeric(18, 4)), CAST(15.0000 AS Numeric(18, 4)), CAST(0.0000 AS Numeric(18, 4)))
INSERT [dbo].[TransactionTaxLines] ([TrxId], [LineId], [TaxId], [TaxStructureId], [Percentage], [Amount], [ProductSplitAmount]) VALUES (3, 0, 3, 0, CAST(17.0000 AS Numeric(18, 4)), CAST(12.7500 AS Numeric(18, 4)), CAST(0.0000 AS Numeric(18, 4)))
INSERT [dbo].[TransactionTaxLines] ([TrxId], [LineId], [TaxId], [TaxStructureId], [Percentage], [Amount], [ProductSplitAmount]) VALUES (3, 1, 2, 0, CAST(15.0000 AS Numeric(18, 4)), CAST(15.0000 AS Numeric(18, 4)), CAST(0.0000 AS Numeric(18, 4)))
INSERT [dbo].[TransactionTaxLines] ([TrxId], [LineId], [TaxId], [TaxStructureId], [Percentage], [Amount], [ProductSplitAmount]) VALUES (3, 2, 2, 0, CAST(15.0000 AS Numeric(18, 4)), CAST(7.5000 AS Numeric(18, 4)), CAST(0.0000 AS Numeric(18, 4)))
INSERT [dbo].[TransactionTaxLines] ([TrxId], [LineId], [TaxId], [TaxStructureId], [Percentage], [Amount], [ProductSplitAmount]) VALUES (5, 0, 1, 0, CAST(10.0000 AS Numeric(18, 4)), CAST(5.0000 AS Numeric(18, 4)), CAST(0.0000 AS Numeric(18, 4)))
INSERT [dbo].[TransactionTaxLines] ([TrxId], [LineId], [TaxId], [TaxStructureId], [Percentage], [Amount], [ProductSplitAmount]) VALUES (4, 0, 1, 0, CAST(10.0000 AS Numeric(18, 4)), CAST(10.0000 AS Numeric(18, 4)), CAST(0.0000 AS Numeric(18, 4)))
INSERT [dbo].[TransactionTaxLines] ([TrxId], [LineId], [TaxId], [TaxStructureId], [Percentage], [Amount], [ProductSplitAmount]) VALUES (6, 0, 3, 0, CAST(17.0000 AS Numeric(18, 4)), CAST(6.8000 AS Numeric(18, 4)), CAST(0.0000 AS Numeric(18, 4)))
INSERT [dbo].[TransactionTaxLines] ([TrxId], [LineId], [TaxId], [TaxStructureId], [Percentage], [Amount], [ProductSplitAmount]) VALUES (7, 1, 3, 0, CAST(17.0000 AS Numeric(18, 4)), CAST(6.8000 AS Numeric(18, 4)), CAST(0.0000 AS Numeric(18, 4)))
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [LoginId], [Password], [Role], [Status], [POSCounter], [PasswordChangeDate], [InvalidAttempts], [Email], [CompanyAdmin], [Department], [Manager], [EmpStartDate], [EmpEndDate], [EmpEndReason], [LastLogInTime], [LastLogOutTime], [CreatationDate], [CreatedBy], [LastUpdatedBy], [LastUpdatedDate]) VALUES (1, N'Harish', N'harish', N'111', N'Admin', N'Active', N'', NULL, NULL, N'', 0, N'', N'', CAST(N'2019-09-08T18:48:07.023' AS DateTime), CAST(N'2019-09-08T18:48:07.023' AS DateTime), N'', NULL, NULL, CAST(N'2019-09-08T18:48:07.027' AS DateTime), N'Harish', N'Harish', CAST(N'2019-09-08T18:48:07.027' AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [Role], [Description], [ManagerFlag], [AllowPOSAccess], [POSClockInOut], [AllowShiftOpenClose], [LastUpdatedBy], [LastUpdatedDate]) VALUES (1, N'Admin', N'desc', 1, 1, 0, 0, N'Harish', CAST(N'2019-03-24T00:40:23.797' AS DateTime))
INSERT [dbo].[UserRole] ([Id], [Role], [Description], [ManagerFlag], [AllowPOSAccess], [POSClockInOut], [AllowShiftOpenClose], [LastUpdatedBy], [LastUpdatedDate]) VALUES (2, N'New', N'a', 1, 1, 0, 0, N'Harish', CAST(N'2019-09-22T19:59:30.940' AS DateTime))
INSERT [dbo].[UserRole] ([Id], [Role], [Description], [ManagerFlag], [AllowPOSAccess], [POSClockInOut], [AllowShiftOpenClose], [LastUpdatedBy], [LastUpdatedDate]) VALUES (3, N'TestRole', N'test data', 0, 1, 0, 0, N'Harish', CAST(N'2019-03-23T15:52:17.233' AS DateTime))
INSERT [dbo].[UserRole] ([Id], [Role], [Description], [ManagerFlag], [AllowPOSAccess], [POSClockInOut], [AllowShiftOpenClose], [LastUpdatedBy], [LastUpdatedDate]) VALUES (4, N'New role', N'tt', 0, 1, 1, 0, N'Harish', CAST(N'2019-03-23T15:53:43.357' AS DateTime))
INSERT [dbo].[UserRole] ([Id], [Role], [Description], [ManagerFlag], [AllowPOSAccess], [POSClockInOut], [AllowShiftOpenClose], [LastUpdatedBy], [LastUpdatedDate]) VALUES (5, N'test', N'testing', 1, 1, 0, 0, N'Harish', CAST(N'2019-03-24T16:05:00.560' AS DateTime))
INSERT [dbo].[UserRole] ([Id], [Role], [Description], [ManagerFlag], [AllowPOSAccess], [POSClockInOut], [AllowShiftOpenClose], [LastUpdatedBy], [LastUpdatedDate]) VALUES (6, N'T2', N'tt', 1, 1, 1, 1, N'Harish', CAST(N'2019-09-22T19:59:49.800' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserRole] OFF
SET IDENTITY_INSERT [dbo].[ValuesButtons] ON 

INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (1, N'postab', N'tablinks', N'get pos info', N'getposdetails()', N'POS', 1, N'')
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (2, N'cardtab', N'tablinks', N'get card info', N'getCardDetails()', N'Card', 1, N'')
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (3, N'limittab', N'tablinks', N'get Limit Info', N'getLimitDetails()', N'Limits', 1, N'')
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (4, N'Transactiontab', N'tablinks', N'get Transaction Info', N'getTransactionDetails()', N'Transaction', 1, N'')
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (12, N'Inventorytab', N'tablinks', N'Get Inventory Info', N'getInventoryInfo()', N'Inventory', 1, N'')
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (13, N'redemptiontab', N'tablinks', N'Get Redumptions info', N'getRedInfo()', N'Redemptions', 1, N'')
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (14, N'paymenttab', N'tablinks', N'Get Payment Info', N'getPaymentInfo()', N'Payment', 1, N'')
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (5, N'Emailtab', N'tablinks', N'get Email Info', N'getEmailDetails()', N'Email', 1, N'')
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (6, N'Signagetab', N'tablinks', N'get Signage Info', N'getSignageDetails()', N'Signage', 1, N'')
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (7, N'Servertab', N'tablinks', N'get Server Info', N'getServerDetails()', N'Server', 1, N'')
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (8, N'backuptab', N'tablinks', N'Get Backup Info', N'getBackupDetails()', N'Backup and Restore', 1, N'')
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (9, N'pricetab', N'tablinks', N'Get Price Info', N'getPriceDetails()', N'Price', 1, N'')
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (10, N'printtab', N'tablinks', N'Get Print Info', N'getPrintDetails()', N'Print', 1, N'')
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (11, N'formatstab', N'tablinks', N'Get Formats info', N'getFormatsInfo()', N'Formats', 1, N'')
INSERT [dbo].[ValuesButtons] ([Id], [ButtonId], [Class], [Tittle], [MethodName], [Text], [Active], [BRTag]) VALUES (15, N'customertab', N'tablinks', N'Get Customer Info', N'getCustomerDetails()', N'Customer', 1, N'')
SET IDENTITY_INSERT [dbo].[ValuesButtons] OFF
/****** Object:  Index [UC_Person]    Script Date: 12/4/2019 11:46:34 AM ******/
ALTER TABLE [dbo].[Site] ADD  CONSTRAINT [UC_Person] UNIQUE NONCLUSTERED 
(
	[SiteCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Card] ADD  CONSTRAINT [DF_Card_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ((1)) FOR [IsValid]
GO
ALTER TABLE [dbo].[Discounts] ADD  CONSTRAINT [DF_discounts_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[ProductKey] ADD  CONSTRAINT [DF_ProductKey_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[ReceiptPrintTemplate] ADD  CONSTRAINT [DF_ReceiptPrintTemplate_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[ReceiptPrintTemplateHeader] ADD  CONSTRAINT [DF_ReceiptPrintTemplateHeader_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[TransactionHeader] ADD  CONSTRAINT [DF_TransactionHeader_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[TransactionHeader] ADD  DEFAULT ((0)) FOR [ReprintCount]
GO
ALTER TABLE [dbo].[TransactionLines] ADD  CONSTRAINT [DF_TransactionLines_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[Card]  WITH CHECK ADD  CONSTRAINT [FK_Card_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Card] CHECK CONSTRAINT [FK_Card_Customer]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([Category])
REFERENCES [dbo].[ProductCategory] ([Id])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([Type])
REFERENCES [dbo].[ProductType] ([Id])
GO
ALTER TABLE [dbo].[TransactionLines]  WITH CHECK ADD  CONSTRAINT [FK_TransactionLines_TransactionHeader] FOREIGN KEY([TrxId])
REFERENCES [dbo].[TransactionHeader] ([TrxId])
GO
ALTER TABLE [dbo].[TransactionLines] CHECK CONSTRAINT [FK_TransactionLines_TransactionHeader]
GO
/****** Object:  StoredProcedure [dbo].[GetInventory]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetInventory]    
@From datetime=null,
@To datetime=null

as begin     

declare @TotalNumberOfCards int  

if (isnull(@From,'')='' and isnull(@To,'')='')
begin

  select @TotalNumberOfCards =sum(NumberOfCards) from Inventory  
select @TotalNumberOfCards'TotalNumberOfCards',null'User',* from inventory

 end
 else begin 

  select @TotalNumberOfCards =sum(NumberOfCards) from Inventory  
select @TotalNumberOfCards'TotalNumberOfCards',null'User',* from inventory    where ActionDate between @From and @To
    end
end



GO
/****** Object:  StoredProcedure [dbo].[GetTechCardType]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[GetTechCardType]
as
begin 

    select distinct Id,[Name] from TechCardType where Active = 1 
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_ChangeUserPassword]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_ChangeUserPassword]   
@userId int,
@currentPassword NVARCHAR(100),
@password NVARCHAR(100)

AS   
 BEGIN   
  
  IF EXISTS(SELECT 'X' FROM [User] WHERE id = @userId)
  BEGIN
		UPDATE [User]
				set Password = @password 
		WHERE 
				id = @userId
			AND 
				Password = @currentPassword
		
  END
 
 END  
  
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteProductById]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_DeleteProductById]  
@Id int  
as begin   
  
Delete from product where id =@id  
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetActiveHubMachines]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetActiveHubMachines]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	select mch.Name Machine,mch.Id Id,hub.Name HubName from Machine mch join Hub hub 
	on hub.Name = mch.HubName where mch.Active = 1 and hub.Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllCards]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_GetAllCards]        
@TechnicianCard int=null,        
@CardNumber varchar(20)=null,        
@Custemer varchar(100)=null,        
@VIPCustomer bit=null,        
@IssueDate datetime=null,        
@ToDate datetime=null        
as begin         
  if (@TechnicianCard =1)    
   begin     
  set  @TechnicianCard=2    
    end    
select *,cu.CustomerName as Customer from Card c left join Customer cu on c.CustomerId = cu.CustomerId   
 where  (c.CardNumber=@CardNumber or @CardNumber is null)   
 and (c.VIPCustomer =@VIPCustomer or @VIPCustomer=0 )  
 and (cast(c.IssueDate as date)=cast(@IssueDate as date) or @IssueDate is null)  
 and (cast(c.ExpiryDate as date)=cast( @ToDate as date) or @ToDate is null)  
      and (c.TechnicianCard =@TechnicianCard or @TechnicianCard=0 )    
end        
  
  
  
  


  
        
  
 --  sp_helptext sp_GetAllCards  
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllValuesButtons]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetAllValuesButtons]  
as begin   
  
select * from ValuesButtons where Active =1  
  
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAppModuleActions]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAppModuleActions]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * from AppModule
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAppModules]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Harish>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAppModules] 
@module varchar(100)
AS
BEGIN
	SET NOCOUNT ON;
    select APM.Root, APM.Page from AppModule APM
	where APM.Active = 1 and APM.Module = @module
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAppSettings]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Harish>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAppSettings] 
@screen varchar(100)
AS
BEGIN
	SET NOCOUNT ON;
    select [Name], Caption,DefaultValue, [Type], ScreenGroup from Settings where Active = 1 and ScreenGroup = @screen
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCard]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP PROCEDURE sp_GetCard
CREATE proc [dbo].[sp_GetCard] 
(
@cardId INT = NULL,
@cardNumber NVARCHAR(50) = NULL
)
as 
begin 

SELECT
	*
		FROM 
		Card

	WHERE 
		(@cardId IS NULL OR CardId = @cardId)
	AND
		(@cardNumber IS NULL OR CardNumber = LTRIM(RTRIM(@cardNumber)))
end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetCardById]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[sp_GetCardById]
@CardId int
as begin 

select *,cu.CustomerName as Customer from Card c left join Customer cu on cu.CustomerId=c.CustomerId where CardId=@CardId
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCustomer]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP PROCEDURE sp_GetCustomer
CREATE proc [dbo].[sp_GetCustomer] 
(
@customerId INT = NULL,
@phoneNumber NVARCHAR(50) = NULL
)
as 
begin 

SELECT
	CustomerId,
	CustomerName,
	Address1,
	Address2,
	Address3,
	City,
	State,
	Country,
	Pin,
	Email,
	DateOfBirth,
	Gender,
	Anniversary,
	ContactPhone1,
	ContactPhone2,
	Notes,
	LastUpdatedDate,
	LastUpdatedUser,
	MiddleName,
	LastName,
	CustomDataSetId,
	Company,
	Designation,
	PhotoFileName,
	Guid,
	SiteId,
	UniqueID,
	Username,
	FBUserId,
	FBAccessToken,
	TWAccessToken,
	TWAccessSecret,
	RightHanded,
	TeamUser,
	SynchStatus,
	Verified,
	Password,
	LastLoginTime,
	ExternalSystemRef,
	IsValid,
	DownloadBatchId,
	IDProofFileName,
	Title
	FROM 
		Customer

	WHERE 
		(@customerId IS NULL OR CustomerId = @customerId)
	AND
		(@phoneNumber IS NULL OR ContactPhone1 = LTRIM(RTRIM(@phoneNumber)))
end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetDataTypes]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_GetDataTypes]   
as begin   
select distinct identity(int,1,1) Id, Type into #ProductDatatypes from Settings where Type is not null  
select * from #ProductDatatypes  
drop table #ProductDatatypes  
end  
  
  
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDiscountById]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP PROC sp_GetDiscountById

CREATE PROCEDURE [dbo].[sp_GetDiscountById]     
 @id int    
AS    
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    

 SELECT     
		* FROM 
			Discounts	
		WHERE discount_id = @id    
END 




GO
/****** Object:  StoredProcedure [dbo].[sp_GetDiscounts]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_GetDiscounts]
as 
begin 
select * from discounts
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDisplayGroup]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROC [sp_GetDisplayGroup]
CREATE PROCEDURE [dbo].[sp_GetDisplayGroup]
	@displayGroupId int = 0
AS

BEGIN
	SELECT * from displaygroup 
		where @displayGroupId = 0 OR DisplayGroup = @displayGroupId 
		ORDER BY SortOrder
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetGameProfiles]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetGameProfiles]
	
AS
BEGIN
	SET NOCOUNT ON;
	select * from GameProfile
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetGames]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetGames]
	
AS
BEGIN
	SET NOCOUNT ON;
	select * from Game
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetHubs]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetHubs]
	
AS
BEGIN
	SET NOCOUNT ON;
	select * from Hub
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetListItems]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetListItems]
	@groupId int
AS
BEGIN
	if(@groupId = 1)
	Begin
		SELECT * from DisplayGroup
	end
	else
	begin
		SELECT * from ListItem where GroupId = @groupId		
	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMachines]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetMachines]
	
AS
BEGIN
	SET NOCOUNT ON;
	select * from Machine
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMessages]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_GetMessages]
as begin
select * from Messages
 end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPrinters]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sp_GetPrinters]
	
AS
BEGIN
	SET NOCOUNT ON;
	select * from Printers
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPrintTemplateHeaders]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetPrintTemplateHeaders]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from ReceiptPrintTemplateHeader
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPrintTemplatesById]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[sp_GetPrintTemplatesById]
	@TemplateId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from ReceiptPrintTemplate where TemplateId = @TemplateId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductById]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP PROC sp_GetProductById

CREATE PROCEDURE [dbo].[sp_GetProductById]     
 @id int    
AS    
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
  declare @expiredate datetime  
  declare @withoutExpireDate datetime 
  declare @cardvalidFor int
  declare @startDate datetime
  select @cardvalidFor= DefaultValue  from Settings where name ='CARD_VALIDITY'
   select @expiredate = ExpiryDate from Product where id=@id
   select @startDate = startDate from Product where id=@id
  select @withoutExpireDate =DATEADD(DAY,@cardvalidFor,@startDate)  
 
 SELECT     
 Courtesy,  
 p.Id ,Name ,PT.Type ,POSCounter, P.Active, DisplayInPOS ,DG.DisplayGroupId ,Category ,
 AutoGenerateCardNumber ,OnlyVIP, Price, FaceValue, TaxInclusive, T.TaxPercent TaxPercentage, FinalPrice, EffectivePrice,    
  P.LastUpdatedBy, P.LastUpdatedDate, Bonus, LastUpdatedUser ,T.TaxName, StartDate as 'StartDate', Games ,    
  CreditsPlus, Credits ,CardValidFor,case when isnull(@expiredate,'') ='' then @withoutExpireDate else ExpiryDate end as 'ExpiryDate',
  --ExpiryDate 'ExpiryDate'    
    T.TaxId
  from Product P
  JOIN Tax T ON T.TaxId = p.TaxId
  LEFT JOIN ProductType PT on P.Type = PT.Id
  LEFT JOIN DisplayGroup DG on P.DisplayGroupId = DG.DisplayGroupId
  where P.Id = @id    
END 




GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductCategory]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_GetProductCategory]  
as begin   
select * from productCategory order by id 
end 


GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductCategoryLookUp]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Harish>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetProductCategoryLookUp]
AS
BEGIN
	SET NOCOUNT ON;
    select distinct Id,[Name] from ProductCategory where Active = 1
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProducts]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- DROP PROC sp_GetProducts
Create proc [dbo].[sp_GetProducts]
as 
begin 

select 
		p.Id,
		Name,
		PT.Id as Type,
		POSCounter,
		P.Active,
		DisplayInPOS,
		P.DisplayGroupId,
		Category,
		AutoGenerateCardNumber,
		OnlyVIP,
		Price,
		FaceValue,
		TaxInclusive,
		TaxPercentage,
		FinalPrice,
		EffectivePrice,
		p.LastUpdatedBy,
		p.LastUpdatedDate,
		Bonus,
		LastUpdatedUser,
		TaxName,
		StartDate,
		Games,
		CreditsPlus,
		Credits,
		CardValidFor,
		ExpiryDate,
		Courtesy,
		TaxId ,
		PT.Type as TypeName
				FROM Product P
		LEFT JOIN ProductType PT ON P.Type = PT.Id
end


GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductsByScreenGroup]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- EXEC sp_GetProductsByScreenGroup
 -- DROP PROC [sp_GetProductsByScreenGroup]
-- =============================================
-- Author:		Harish
-- Create date: <Create Date,,>
-- Description:	get products by screen
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetProductsByScreenGroup] 
	-- Add the parameters for the stored procedure here
	@displayGroupId INT = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 SELECT     
 Courtesy,  
 p.Id ,Name  ,POSCounter, P.Active, DisplayInPOS, P.Type, DG.DisplayGroup ,Category ,
 AutoGenerateCardNumber ,OnlyVIP, Price, FaceValue, TaxInclusive, TaxPercentage, FinalPrice, EffectivePrice,    
  P.LastUpdatedBy, P.LastUpdatedDate, Bonus, LastUpdatedUser ,TaxName, StartDate as 'StartDate', Games ,    
  CreditsPlus, Credits ,CardValidFor   
  from Product P

  LEFT JOIN DisplayGroup DG on P.DisplayGroupId = DG.DisplayGroupId 
 
	  where @displayGroupId = 0 OR dg.DisplayGroupId = @displayGroupId
	 ORDER BY DG.sortorder
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductTaxLookUp]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_GetProductTaxLookUp]  
as begin   
  
select distinct   TaxId as Id,TaxName as Name, TaxPercent from tax  
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductTypeLookUp]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Harish>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetProductTypeLookUp]
AS
BEGIN
	SET NOCOUNT ON;
    select distinct Id,[Type] from ProductType where Active = 1
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductTypes]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sp_GetProductTypes]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from ProductType
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProducyKey]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetProducyKey]
@SiteKey int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select * from productKey where site_id = @SiteKey
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRoleModuleActions]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetRoleModuleActions]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	select AM.Id,AM.Module,AM.[Root],AM.[URL],AM.Active,AM.[Page],AM.DisplayOrder,
	CASE WHEN RMA.[Page] IS NULL THEN 'false' ELSE 'true' END AS IsChecked from AppModule AM 
	left join RoleModuleAction RMA on AM.Id = RMA.PageId AND RMA.RoleId = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSettings]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSettings]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Settings
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSites]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSites]
	
AS
BEGIN
	SET NOCOUNT ON;
	select * from [Site]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTaskType]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[sp_GetTaskType]
as begin
select * from TaskType
 end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTaxSet]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_GetTaxSet]
as begin 
select * from Tax
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTaxStructure]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_GetTaxStructure]  
as begin   
select TaxStructureId,StructureName'TaxStructureName',TaxStructurePercentage,TaxId from TaxStructure 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTrxHeaderLines]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetTrxHeaderLines] 
	@userId int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
			* 
				FROM 
				TransactionHeader

	SELECT 
			ln.*, p.Name 
				FROM 
				TransactionLines ln
				left join Product p on ln.ProductId = p.Id
	 
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserById]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Harish
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUserById] 
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from [User] where Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserRoles]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Harish
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUserRoles]
AS
BEGIN
	Select * from UserRole
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUsers]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Harish
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUsers]
AS
BEGIN
	Select * from [User]
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_insert_discount]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_insert_discount]      
      
       
 @AutomaticApply bit=null,      
   @CouponMendatory bit=null,       
  @DiscountAmount float=null,       
   @DiscountID int=null,      
    @DiscountName varchar(100)=null,       
  @ActiveFlag bit=null,       
    @DiscountPercentage float=null,      
     @DiscountType varchar(100)=null,      
   @DisplayInPOS bit=null,      
    @DisplayOrder int=null,       
    @LastUpdatedDate DateTime=null,      
     @LastUpdatedUser varchar(100)=null,      
      @ManagerApproval bit=null,      
    @MinimumSaleAmount float=null,       
    @MinimumUsedCredits float=null,       
    @RemarkMendatory bit=null,      
    @Type bit=null      
    as begin   
 if not exists(select discount_id from discounts where discount_id=@DiscountID)   
 begin     
    insert into discounts      
    --(discount_id,discount_name,discount_percentage,automatic_apply,minimum_sale_amount,      
    --minimum_credits,display_in_POS,active_flag,sort_order,manager_approval_required,last_updated_date,      
    --last_updated_user,discount_type,CouponMandatory,DiscountAmount,RemarksMandatory)      
    values(@DiscountName,      
    @DiscountPercentage,@AutomaticApply,@MinimumSaleAmount,@MinimumUsedCredits,@DisplayInPOS,1,      
    @DisplayOrder,@ManagerApproval,GETDATE(),'Shridhar Naik',null,@DiscountType,null,null,@CouponMendatory,null,@DiscountAmount,null,      
    @RemarkMendatory      
    )  end  
 else   
 begin  
 update discounts set discount_name=@DiscountName,discount_percentage=@DiscountPercentage,automatic_apply=@AutomaticApply,  
 minimum_sale_amount=@MinimumSaleAmount,minimum_credits=@MinimumUsedCredits,display_in_POS=@DisplayInPOS,  
 active_flag=@ActiveFlag,sort_order=@DisplayOrder,manager_approval_required=@ManagerApproval,last_updated_date=@LastUpdatedDate,  
 last_updated_user=@LastUpdatedUser,discount_type=@DiscountType,CouponMandatory=@CouponMendatory,DiscountAmount=@DiscountAmount,  
RemarksMandatory=@RemarkMendatory where discount_id=@DiscountID  
 end  
   
     
    end 
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateAppSetting]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateAppSetting]
@name varchar(255),
@value varchar(255),
@screen varchar(100)
AS
BEGIN
DECLARE @settingId int = (select id from Settings where [Name] = @name);
  UPDATE Settings set [DefaultValue] = @value,[LastUpdatedDate] = GETDATE() where ID = @settingId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateCard]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================= 
-- Author:    @Author,,Name 
-- Create date: @Create Date,, 
-- Description:  @Description,, 
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateCard]  
											   @CardId            INT,
											   @CardNumber        VARCHAR(50), 
                                               @IssueDate         DATETIME = NULL, 
                                               @FaceValue         INT = NULL,
											   @RefundDate        DATETIME = NULL,
                                               @RefundFlag        BIT = 0,
                                               @RefundAmount      NUMERIC(18,8) = NULL,
                                               @ValidFlag         BIT = 1,
                                               @TicketCount       INT = 0,
                                               @LastUpdated       DATETIME = NULL,
                                               @Credits           DECIMAL = 0, 
                                               @Courtesy          DECIMAL= 0, 
                                               @Bonus             INT = 0, 
                                               @CustomerId        INT = 0, 
                                               @CreditsPlayed     DECIMAL = 0, 
                                               @TicketAllowed     BIT = 0, 
                                               @RealTicketMode    BIT = 0, 
                                               @VipCustomer       BIT = 0, 
                                               @Notes             VARCHAR(200) = NULL, 
                                               @StartDateTime    DATETIME = NULL, 
                                               @LastTimePlayed    DATETIME = NULL,
                                               @LastUpdatedBy     VARCHAR(50) = NULL, 
                                               @TechnicianCard    BIT = 0, 
                                               @TechGames         INT = 0, 
                                               @TimerResetCard    BIT = 0, 
                                               @LoyaltyPoints     INT = 0, 
                                               @CardTypeId        INT = 0, 
                                               @ExpiryDate        DATETIME = NULL, 
											   @CrdId				INT OUT
AS 
  BEGIN 
      -- SET NOCOUNT ON added to prevent extra result sets from 
      -- interfering with SELECT statements. 
      SET nocount ON; 

      IF EXISTS (SELECT 1 
                 FROM   card WITH (updlock, serializable) 
                 WHERE  Cardid = @CardId) 
        BEGIN 
            -- Insert statements for procedure here 
            UPDATE dbo.cards 
            SET    cardnumber = @CardNumber, 
                   issuedate = ISNULL(@IssueDate, GETDATE()), 
                   facevalue = @FaceValue, 
                   refundflag = @RefundFlag, 
                   refundamount = @RefundAmount, 
                   refunddate = @RefundDate, 
                   validflag = @ValidFlag, 
                   ticketcount = @TicketCount, 
                   notes = @Notes, 
                   lastupdated = @LastUpdated, 
                   credits = @Credits, 
                   courtesy = @Courtesy, 
                   bonus = @Bonus, 
                   customerid = @CustomerId, 
                   creditsplayed = @CreditsPlayed, 
                   ticketallowed = @TicketAllowed, 
                   realticketmode = @RealTicketMode, 
                   vipcustomer = @VipCustomer, 
                   startdatettime = @StartDateTime, 
                   lasttimeplayed = @LastTimePlayed, 
                   techniciancard = @TechnicianCard, 
                   techgames = @TechGames, 
                   timerresetcard = @TimerResetCard, 
                   loyaltypoints = @LoyaltyPoints, 
                   lastupdatedby = @LastUpdatedBy, 
                   cardtypeid = @CardTypeId, 
                   expirydate = @ExpiryDate
            WHERE  Cardid = @CardId 

			SET @CrdId = @CardId
        END 
      ELSE 
        BEGIN 
            -- Insert statements for procedure here 
            INSERT INTO [dbo].[card] 
                        ([cardnumber], 
                         [issuedate], 
                         [facevalue], 
                         [refundflag], 
                         [refundamount], 
                         [refunddate], 
                         [validflag], 
                         [ticketcount], 
                         [notes], 
                         [lastupdated], 
                         [credits], 
                         [courtesy], 
                         [bonus], 
                         [customerid], 
                         [creditsplayed], 
                         [ticketallowed], 
                         [realticketmode], 
                         [vipcustomer], 
                         [startdatettime], 
                         [lasttimeplayed], 
                         [techniciancard], 
                         [techgames], 
                         [timerresetcard], 
                         [loyaltypoints], 
                         [lastupdatedby], 
                         [cardtypeid], 
                         [guid], 
                         [expirydate]
						 ) 
            VALUES      (@CardNumber, 
                         ISNULL(@IssueDate, GETDATE()), 
                         @FaceValue, 
                         @RefundFlag, 
                         @RefundAmount, 
                         @RefundDate, 
                         @ValidFlag, 
                         @TicketCount, 
                         @Notes, 
                         @LastUpdated, 
                         @Credits, 
                         @Courtesy, 
                         @Bonus, 
                         @CustomerId, 
                         @CreditsPlayed, 
                         @TicketAllowed, 
                         @RealTicketMode, 
                         @VipCustomer, 
                         @StartDateTime, 
                         @LastTimePlayed, 
                         @TechnicianCard, 
                         @TechGames, 
                         @TimerResetCard, 
                         @LoyaltyPoints, 
                         @LastUpdatedBy, 
                         @CardTypeId, 
                         NEWID(), 
                         @ExpiryDate
						 ) 

	     SET @CrdId = (SELECT SCOPE_IDENTITY())

        END 

  END 
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateCards]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_InsertOrUpdateCards]   
@CardId int=null ,  
@CardNumber varchar(20)=null,  
@Custemer varchar(100)=null,  
@FaceValue float =null,  
@IssueDate datetime=null,  
@LastPlayTime datetime=null,  
@LastUpdatedBy varchar(100)=null,  
@LastUpdatedTime datetime =null,  
@Note varchar(max) =null,  
@RealTicketMode bit =null,  
@RefundDate datetime =null,  
@StartTime datetime =null,  
@TechGames varchar(max) =null,  
@TicketAllowed bit =null,  
@TicketCount int =null,  
@TimerResetCard bit =null,  
@VIPCustomer bit =null,  
@RefundAmount float=null,  
@TechCardType varchar(100)=null  ,
@Credits float =null,
@CreditPlus float=null,
@Courtesy float =null,
@CreditsPlayed float=null,
@Bonus float =null,
@ExpiryDate  datetime=null
as   
 begin   
  
  alter table card alter column Custemer varchar(100)

    if exists(select 1 from Card where Cardid=@CardId)  
 begin   
 update Card set CardNumber=@CardNumber,Custemer=@Custemer,FaceValue=@FaceValue,IssueDate=@IssueDate,  
 LastTimePlayed=@LastPlayTime,LastUpdatedBy=@LastUpdatedBy,LastUpdatedTime=@LastUpdatedTime,  
 Note=@Note,RealTicketMode=@RealTicketMode,RefundDate=@RefundDate,StartDateTtime=@StartTime,  
 TechGames=@TechGames,TicketAllowed=@TicketAllowed,TicketCount=@TicketCount,TimerResetCard=@TimerResetCard,  
 VIPCustomer=@VIPCustomer,TechnicianCard=@TechCardType,RefundAmount=@RefundAmount,Credits= @Credits,
 CreditPlus=@CreditPlus,Courtesy=@Courtesy,CreditsPlayed=@CreditsPlayed,Bonus=@Bonus,ExpiryDate=@ExpiryDate 
 
  where CardId=@CardId  
 end  
 else   
 begin   
 insert into Card(CardNumber,Custemer,FaceValue,IssueDate,LastTimePlayed,LastUpdatedBy,LastUpdatedTime,Note,  
 RealTicketMode,RefundDate,StartDateTtime,TechGames,TicketAllowed,TicketCount,TimerResetCard,VIPCustomer,TechnicianCard,RefundAmount ,
 Credits,CreditPlus,CreditsPlayed,Bonus,Courtesy ,ExpiryDate
 )values(@CardNumber,@Custemer,@FaceValue,@IssueDate,@LastPlayTime,@LastUpdatedBy,@LastUpdatedTime,  
 @Note,@RealTicketMode,@RefundDate,@StartTime,@TechGames,@TicketAllowed,@TicketCount,@TimerResetCard,@VIPCustomer,  
 @TechCardType,@RefundAmount ,@Credits,@CreditPlus,@CreditsPlayed,@Bonus ,@Courtesy,@ExpiryDate 
 )  
 end  
 end  
  
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateCustomer]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- DROP PROC sp_InsertOrUpdateCustomer
-- ============================================= 
-- Author:    @Author,,Name 
-- Create date: @Create Date,, 
-- Description:  @Description,, 
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateCustomer] @CustomerId        INT, 
                                               @CustomerName      NVARCHAR(50) = NULL, 
                                               @Address1          NVARCHAR(50) = NULL, 
                                               @Address2          NVARCHAR(50) = NULL,  
                                               @Address3          NVARCHAR(50)= NULL, 
                                               @City              NVARCHAR(50)= NULL, 
                                               @State             NVARCHAR(50)= NULL, 
                                               @Pin               NVARCHAR(50)= NULL,  
                                               @Country           NVARCHAR(50) = NULL, 
                                               @Email             NVARCHAR(50)= NULL, 
                                               @Gender            CHAR(1), 
                                               @DateOfBirth       DATETIME = NULL, 
                                               @Anniversary       DATETIME= NULL,
                                               @ContactPhone1     NVARCHAR(50) = NULL, 
                                               @ContactPhone2     NVARCHAR(50) = NULL, 
                                               @Notes             NVARCHAR(max) = NULL, 
                                               @LastUpdatedDate   DATETIME = NULL, 
                                               @LastUpdatedUser   NVARCHAR(50) = NULL, 
                                               @MiddleName        NVARCHAR(50) = NULL,  
                                               @LastName          NVARCHAR(50) = NULL,
                                               @CustomDataSetId   INT = 0,
                                               @Company           NVARCHAR(200) = NULL, 
                                               @Designation       NVARCHAR(200) = NULL, 
                                               @PhotoFileName     NVARCHAR(100) = NULL, 
                                               @UniqueID          VARCHAR(100) = NULL, 
                                               @Username          NVARCHAR(50) = NULL, 
                                               @FBUserId          NVARCHAR(20) = NULL, 
                                               @FBAccessToken     NVARCHAR(20) = NULL, 
                                               @TWAccessToken     NVARCHAR(20) = NULL, 
                                               @TWAccessSecret    NVARCHAR(20) = NULL, 
                                               @RightHanded       BIT = false,
                                               @TeamUser          BIT = false, 
                                               @Verified          CHAR(1) = 'N', 
                                               @Password          NVARCHAR(100) = NULL, 
                                               @LastLoginTime     DATETIME = NULL, 
                                               @ExternalSystemRef NVARCHAR(50) = NULL, 
                                               @IsValid           BIT = 0, 
                                               @DownloadBatchId   INT = 0, 
                                               @IDProofFileName   NVARCHAR(100) = NULL, 
                                               @Title             NVARCHAR(20) = NULL, 
											   @custId  INT OUT
AS 
  BEGIN 
      -- SET NOCOUNT ON added to prevent extra result sets from 
      -- interfering with SELECT statements. 
      SET nocount ON; 

      BEGIN TRAN 

      IF EXISTS (SELECT customerid 
                 FROM   customer WITH (updlock, serializable) 
                 WHERE  customerid = @CustomerId) 
        BEGIN 
            -- update statements for procedure here 
            UPDATE dbo.customer
            SET    customername = @CustomerName, 
                   address1 = @Address1, 
                   address2 = @Address2, 
                   address3 = @Address3, 
                   city = @City, 
                   [state] = @State, 
                   country = @Country, 
                   pin = @Pin, 
                   email = @Email, 
                   dateofbirth = @DateOfBirth, 
                   gender = @Gender, 
                   anniversary = @Anniversary, 
                   contactphone1 = @ContactPhone1, 
                   contactphone2 = @ContactPhone2, 
                   notes = @Notes, 
                   lastupdateddate = @LastUpdatedDate, 
                   lastupdateduser = @LastUpdatedUser, 
                   middlename = @MiddleName, 
                   lastname = @LastName, 
                   customdatasetid = @CustomDataSetId, 
                   company = @Company, 
                   designation = @Designation, 
                   photofilename = @PhotoFileName, 
                   uniqueid = @UniqueID, 
                   username = @Username, 
                   fbuserid = @FBUserId, 
                   fbaccesstoken = @FBAccessToken, 
                   twaccesstoken = @TWAccessToken, 
                   twaccesssecret = @TWAccessSecret, 
                   righthanded = @RightHanded, 
                   teamuser = @TeamUser, 
                   verified = @Verified, 
                   [password] = @Password, 
                   lastlogintime = @LastLoginTime, 
                   externalsystemref = @ExternalSystemRef, 
                   isvalid = @IsValid, 
                   downloadbatchid = @DownloadBatchId, 
                   idprooffilename = @IDProofFileName, 
                   title = @Title 
            WHERE  customerid = @CustomerId 

			set @custId = @CustomerId
        END 
      ELSE 
        BEGIN 
            -- Insert statements for procedure here 
            INSERT INTO [dbo].[customer] 
                        ([customername], 
                         [address1], 
                         [address2], 
                         [address3], 
                         [city], 
                         [state], 
                         [country], 
                         [pin], 
                         [email], 
                         [dateofbirth], 
                         [gender], 
                         [anniversary], 
                         [contactphone1], 
                         [contactphone2], 
                         [notes], 
                         [lastupdateddate], 
                         [lastupdateduser], 
                         [middlename], 
                         [lastname], 
                         [customdatasetid], 
                         [company], 
                         [designation], 
                         [photofilename], 
                         [guid], 
                         [uniqueid], 
                         [username], 
                         [fbuserid], 
                         [fbaccesstoken], 
                         [twaccesstoken], 
                         [twaccesssecret], 
                         [righthanded], 
                         [teamuser], 
                         [verified], 
                         [password], 
                         [lastlogintime], 
                         [externalsystemref], 
                         [isvalid], 
                         [downloadbatchid], 
                         [idprooffilename], 
                         [title]) 

            VALUES      (@CustomerName, 
                         @Address1, 
                         @Address2, 
                         @Address3, 
                         @City, 
                         @State, 
                         @Country, 
                         @Pin, 
                         @Email, 
                         @DateOfBirth, 
                         @Gender, 
                         @Anniversary, 
                         @ContactPhone1, 
                         @ContactPhone2, 
                         @Notes, 
                         @LastUpdatedDate, 
                         @LastUpdatedUser, 
                         @MiddleName, 
                         @LastName, 
                         @CustomDataSetId, 
                         @Company, 
                         @Designation, 
                         @PhotoFileName, 
                         NEWID(), 
                         @UniqueID, 
                         @Username, 
                         @FBUserId, 
                         @FBAccessToken, 
                         @TWAccessToken, 
                         @TWAccessSecret, 
                         @RightHanded, 
                         @TeamUser, 
                         @Verified, 
                         @Password, 
                         @LastLoginTime, 
                         @ExternalSystemRef, 
                         @IsValid, 
                         @DownloadBatchId, 
                         @IDProofFileName, 
                         @Title) 

						 SET @custId = (SELECT SCOPE_IDENTITY())

				
        END 

				 select @custId

      COMMIT TRAN 
  END 


GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateGame]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateGame] 
    @id int,
	@name varchar(50),
	@description varchar(max),
	@gameProfile int,
	@normalPrice int,
	@vipPrice int,
	@repeatPlayDiscountPercentage int,
	@gameCompanyName varchar(500),
	@notes varchar(max),
	@lastUpdatedDate datetime,
	@lastUpdatedBy varchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select id from Game with (updlock,serializable) where Id = @id)
   begin
   -- Insert statements for procedure here
	Update [Game] set [Name] = @name,
	NormalPrice = @normalPrice,
	VIPPrice = @vipPrice,
	RepeatPlayDiscountPercentage = @repeatPlayDiscountPercentage,
	[Description] = @Description,
	Notes = @notes,
	GameProfile = @gameProfile,
	GameCompanyName = @gameCompanyName,
	[LastUpdatedDate] = @lastUpdatedDate,
	[LastUpdatedBy] = @lastUpdatedDate where Id = @Id
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Game]
           ([Name]
		   ,[Description]
           ,[NormalPrice]
           ,[VIPPrice]
		   ,RepeatPlayDiscountPercentage
		   ,GameProfile
		   ,GameCompanyName
		   ,Notes
           ,[LastUpdatedDate]
           ,[LastUpdatedBy])
     VALUES
           (@name ,
		   @description,
	@normalPrice ,
	@vipPrice ,
	@repeatPlayDiscountPercentage,
	@gameProfile,
	@gameCompanyName,
	@notes,
	@lastUpdatedDate ,
	@lastUpdatedBy)
end
commit tran
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateGameProfile]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sp_InsertOrUpdateGameProfile] 
    @id int,
	@name varchar(50),
	@normalPrice int,
	@vipPrice int,
	@creditAllowed bit,
	@bonusAllowed bit,
	@courtesyAllowed bit,
	@timeAllowed bit,
	@tiketAllowedOnCredit bit,
	@tiketAllowedOnBonus bit,
	@tiketAllowedOnCourtesy bit,
	@tiketAllowedOnTime bit,
	@lastUpdatedDate datetime,
	@lastUpdatedBy varchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select id from GameProfile with (updlock,serializable) where Id = @id)
   begin
   -- Insert statements for procedure here
	Update [GameProfile] set [Name] = @name,NormalPrice = @normalPrice,VIPPrice = @vipPrice,
							[CreditAllowed] = @creditAllowed ,
							[BonusAllowed] = @bonusAllowed,
							 [CourtesyAllowed] = @courtesyAllowed,
							 [TimeAllowed] = @timeAllowed,
							 [TiketAllowedOnCredit] = @tiketAllowedOnCredit,
							 [TiketAllowedOnBonus] = @tiketAllowedOnBonus,
							 [TiketAllowedOnCourtesy] = @tiketAllowedOnCourtesy,
							 [TiketAllowedOnTime] = @tiketAllowedOnTime,
							 [LastUpdatedDate] = @lastUpdatedDate,
							 [LastUpdatedBy] = @lastUpdatedDate where Id = @Id
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[GameProfile]
           ([Name]
           ,[NormalPrice]
           ,[VIPPrice]
           ,[CreditAllowed]
           ,[BonusAllowed]
           ,[CourtesyAllowed]
           ,[TimeAllowed]
           ,[TiketAllowedOnCredit]
           ,[TiketAllowedOnBonus]
           ,[TiketAllowedOnCourtesy]
           ,[TiketAllowedOnTime]
           ,[LastUpdatedDate]
           ,[LastUpdatedBy])
     VALUES
           (@name ,
	@normalPrice ,
	@vipPrice ,
	@creditAllowed ,
	@bonusAllowed ,
	@courtesyAllowed ,
	@timeAllowed,
	@tiketAllowedOnCredit ,
	@tiketAllowedOnBonus ,
	@tiketAllowedOnCourtesy ,
	@tiketAllowedOnTime ,
	@lastUpdatedDate ,
	@lastUpdatedBy)
end
commit tran
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateHub]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateHub] 
    @id int,
	@name varchar(50),
	@note varchar(50),
	@frequency int,
	@address varchar(500),
	@macaddress varchar(500),
	@ipaddress varchar(500),
	@tcpport int,
	@active bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select id from Hub with (updlock,serializable) where Id = @id)
   begin
   -- Insert statements for procedure here
	Update [Hub] set [Name] = @name,[Address] = @address,
							IPAddress = @ipaddress,Active= @active,MacAddress = @macaddress,
							Note = @note,Frequency = @frequency,TCPPort = @tcpport
							where Id = @Id
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Hub]
           ([Name]
           ,[Address]
           ,[Note]
           ,[Frequency]
           ,[Active]
           ,[IPAddress]
           ,[MacAddress]
		   ,[TCPPort])
     VALUES
           (@name
           ,@address
           ,@note
           ,@frequency
           ,@active
		   ,@ipaddress
           ,@macaddress
		   ,@tcpport
           )
end
commit tran
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateMachine]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateMachine] 
    @id int,
	@name varchar(50),
	@gameName varchar(50),
	@hubName varchar(50),
	@hubAddress varchar(50),
	@machineAddress varchar(50),
	@effectiveMachineAddress varchar(50),
	@active bit,
	@readerType varchar(50),
	@vipPrice int,
	@softwareVersion varchar(50),
	@ticketMode varchar(50),
	@ticketAllowed bit,
	@purchasePrice int,
	@notes varchar(max),
	@theme varchar(50),
	@lastUpdatedDate datetime,
	@lastUpdatedBy varchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select id from Machine with (updlock,serializable) where Id = @id)
   begin
   -- Insert statements for procedure here
	Update [Machine] set [Name] = @name,
	GameName = @gameName,
	HubName = @hubName,
	HubAddress = @hubAddress,
	MachineAddress = @machineAddress,
	EffectiveMachineAddress = @effectiveMachineAddress,
	Active = @active,
	ReaderType = @readerType,
	SoftwareVersion = @softwareVersion,
	TicketMode = @ticketMode,
	TicketAllowed = @ticketAllowed, 
	VIPPrice = @vipPrice,
	PurchasePrice = @purchasePrice,
	Notes = @notes,
	Theme = @theme,
	[LastUpdatedDate] = @lastUpdatedDate,
	[LastUpdatedBy] = @lastUpdatedDate where Id = @Id
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Machine]
           ([Name]
		   ,[GameName]
           ,[HubName]
		   ,HubAddress
		   ,MachineAddress
		   ,EffectiveMachineAddress
		   ,Active
		   ,SoftwareVersion
		   ,ReaderType
		   ,TicketMode
		   ,TicketAllowed
		   ,VIPPrice
		   ,PurchasePrice
		   ,Notes
		   ,Theme
           ,[LastUpdatedDate]
           ,[LastUpdatedBy])
     VALUES
           (@name ,
		   @gameName,
	@hubName ,
	@hubAddress ,
	@machineAddress,
	@effectiveMachineAddress,
	@active,
	@softwareVersion,
	@readerType ,
	@ticketMode,
	@ticketAllowed,
	@vipPrice,
	@purchasePrice,
	@notes,
	@theme,
	@lastUpdatedDate,
	@lastUpdatedBy)
end
commit tran
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdatePrinter]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertOrUpdatePrinter] 
    @PrinterId int,
	@PrinterName varchar(500),
	@PrinterLocation varchar(100),
	@IPAddress varchar(50),
	@KDSTerminal bit,
	@Remarks nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select PrinterId from [Printers] with (updlock,serializable) where PrinterId = @PrinterId)
   begin
   -- Insert statements for procedure here
	UPDATE [dbo].[Printers]
   SET PrinterName = @PrinterName
      ,PrinterLocation = @PrinterLocation
      ,IpAddress = @IPAddress
      ,KDSTerminal = @KDSTerminal
	  ,Remarks = @Remarks
 WHERE PrinterId = @PrinterId
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Printers]
           (PrinterName
           ,IPAddress
           ,PrinterLocation
           ,KDSTerminal
           ,Remarks)
     VALUES
           (@PrinterName
           ,@IPAddress
           ,@PrinterLocation
           ,@KDSTerminal
           ,@Remarks)
end
commit tran
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdatePrintTemplateHeader]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertOrUpdatePrintTemplateHeader] 
    @TemplateId int,
	@TemplateName varchar(500),
	@FontName varchar(100),
	@FontSize int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select TemplateId from [ReceiptPrintTemplateHeader] with (updlock,serializable) where TemplateId = @TemplateId)
   begin
   -- Insert statements for procedure here
	UPDATE [dbo].[ReceiptPrintTemplateHeader]
   SET TemplateName = @TemplateName
      ,FontName = @FontName
      ,FontSize = @FontSize
 WHERE TemplateId = @TemplateId
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[ReceiptPrintTemplateHeader]
           (TemplateName
           ,FontName
           ,FontSize)
     VALUES
           (@TemplateName
           ,@FontName
           ,@FontSize
           )
		   
select SCOPE_IDENTITY()
end
commit tran
select @TemplateId as id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdatePrintTemplateItems]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertOrUpdatePrintTemplateItems] 
	@Id int,
    @TemplateId int,
	@Sequence int,
	@Section varchar(200),
	@FontName varchar(100),
	@FontSize int,
	@Col1Alignment varchar(1),
	@Col1Data varchar(100),
	@Col2Alignment varchar(1),
	@Col2Data varchar(100),
	@Col3Alignment varchar(1),
	@Col3Data varchar(100),
	@Col4Alignment varchar(1),
	@Col4Data varchar(100),
	@Col5Alignment varchar(1),
	@Col5Data varchar(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select Id from [ReceiptPrintTemplate] with (updlock,serializable) where Id = @Id)
   begin
   -- Insert statements for procedure here
	UPDATE [dbo].[ReceiptPrintTemplate]
   SET TemplateId = @TemplateId
	  ,[Sequence] = @Sequence
	  ,Section = @Section
      ,FontName = @FontName
      ,FontSize = @FontSize
	  ,Col1Alignment = @Col1Alignment
	  ,Col1Data = @Col1Data
	  ,Col2Alignment = @Col2Alignment
	  ,Col2Data = @Col2Data
	  ,Col3Alignment = @Col3Alignment
	  ,Col3Data = @Col3Data
	  ,Col4Alignment = @Col4Alignment
	  ,Col4Data = @Col4Data
	  ,Col5Alignment = @Col5Alignment
	  ,Col5Data = @Col5Data

 WHERE Id = @Id
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[ReceiptPrintTemplate]
           (TemplateId
		   ,Sequence
		   ,Section
           ,FontName
           ,FontSize
		   ,Col1Alignment
		   ,Col1Data
		   ,Col2Alignment
		   ,Col2Data
		   ,Col3Alignment
		   ,Col3Data
		   ,Col4Alignment
		   ,Col4Data
		   ,Col5Alignment
		   ,Col5Data)
     VALUES
           (@TemplateId
		   ,@Sequence
		   ,@Section
           ,@FontName
           ,@FontSize
		   ,@Col1Alignment
		   ,@Col1Data
		   ,@Col2Alignment
		   ,@Col2Data
		   ,@Col3Alignment
		   ,@Col3Data
		   ,@Col4Alignment
		   ,@Col4Data
		   ,@Col5Alignment
		   ,@Col5Data
           )
end
commit tran
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateProduct]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
        
-- =============================================        
-- Author:  Harish   Modified:Shridhar     
-- =============================================        
        
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateProduct]        
@name varchar(150),        
@type varchar(50) = null,        
@active bit=null,        
@price decimal(18,3)=null,        
@effectivePrice decimal(18,3)=null,        
@finalPrice decimal(18,3)=null,      
@faceValue decimal(18,3)=null,        
@displayGroupId int = null,        
@displayInPOS bit=null,        
@autoGenerateCardNumber bit=null,        
@category varchar(50)=null,        
@onlyVIP bit=null,        
@posCounter varchar(50)=null,        
@taxInclusive bit=null,        
@taxPercentage decimal(18,3)=null,        
@id int=null  ,      
@Bonus decimal(18,3) =null,      
@LastUpdatedUser varchar(max)=null,      
@TaxName varchar(max)=null,      
@StartDate datetime=null,      
@LastUpdatedDate datetime=null,      
@Games decimal(18,3)=null,      
@CreditsPlus decimal(18,3)=null,      
@Credits decimal(18,3)=null,      
@CardValidFor int=null  ,    
@Courtesy bigint=null   ,
@ExpiryDate datetime =null,
@taxId int = 0
AS        
BEGIN        
 -- SET NOCOUNT ON added to prevent extra result sets from        
 -- interfering with SELECT statements.        
 SET NOCOUNT ON;        
 declare @TotalDays int declare @expire datetime      
  select @TotalDays= Defaultvalue from Settings where name ='CARD_VALIDITY'      
  select @expire=   DATEADD(day, @TotalDays, getdate())       
      
if not exists (select id from Product with (updlock,serializable) where Id = @id)        
begin        
insert into Product(        
[Name],        
[Type],        
Active,        
Price,        
EffectivePrice,        
FaceValue,        
DisplayGroupId,        
DisplayInPOS,        
AutoGenerateCardNumber,        
Category,        
OnlyVIP,        
POSCounter,        
TaxInclusive,        
TaxPercentage,      
Bonus,      
LastUpdatedUser,TaxName,LastUpdatedDate,Games,CreditsPlus,Credits,CardValidFor,Courtesy,  
finalprice    ,
ExpiryDate ,StartDate,TaxId
      
      
)         
Values(@name,@type,@active,@price,@effectivePrice,@faceValue,@displayGroupId,@displayInPOS,        
@autoGenerateCardNumber,@category,@onlyVIP,@posCounter,@taxInclusive,@taxPercentage,@Bonus,@LastUpdatedUser,@TaxName,      
@LastUpdatedDate,@Games,@CreditsPlus,@Credits,@CardValidFor,@Courtesy,@finalPrice,@ExpiryDate,@StartDate,@taxId)        
end        
else        
begin        
 update Product set [Name]= @name,[Type]=@type,[Active]=@active,Price=@price,FinalPrice=@finalPrice,        
     EffectivePrice=@effectivePrice,FaceValue=@faceValue,DisplayGroupId = @displayGroupId,        
     DisplayInPOS=@displayInPOS,AutoGenerateCardNumber=@autoGenerateCardNumber,Category=@category,        
     OnlyVIP=@onlyVIP,POSCounter=@posCounter,TaxInclusive=@taxInclusive,TaxPercentage=@taxPercentage  ,      
  Bonus=@Bonus,LastUpdatedUser=@LastUpdatedUser,TaxName=@TaxName,Games=@Games,CreditsPlus=@CreditsPlus,      
  Credits=@Credits,CardValidFor=@CardValidFor , Courtesy=@Courtesy    ,ExpiryDate=@ExpiryDate,
  TaxId = @taxId
      
      
      
     where Id=@id        
end        
        
END 
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateProductType]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateProductType] 
    @id int,
	@type varchar(50),
	@description varchar(500),
	@reportgroup varchar(50),
	@cardsale bit,
	@active bit,
	@lastupdatedby varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select id from ProductType with (updlock,serializable) where Id = @id)
   begin
   -- Insert statements for procedure here
	Update [ProductType] set [Type] = @type,[Description] = @description,
							ReportGroup = @reportgroup,Active= @active,CardSale = @cardsale,
							@lastUpdatedBy = @lastupdatedby,LastUpdatedDate = GETDATE()
							where Id = @Id
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[ProductType]
           ([Type]
           ,[Description]
           ,[ReportGroup]
           ,[CardSale]
           ,[Active]
           ,[LastUpdatedDate]
           ,[LastUpdatedBy])
     VALUES
           (@type
           ,@description
           ,@reportgroup
           ,@cardsale
           ,@active
		   ,GETDATE()
           ,@lastUpdatedBy
           )
end
commit tran
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateSite]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateSite] 
    @siteId int,
	@siteName varchar(50),
	@siteAddress varchar(100),
	@notes varchar(50),
	@siteGUID uniqueidentifier,
	@logo image,
	@guid uniqueidentifier,
	@CompanyId int,
	@customerKey nvarchar(50),
	@siteCode int,
	@version nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select SiteId from [Site] with (updlock,serializable) where SiteId = @siteId)
   begin
   -- Insert statements for procedure here
	UPDATE [dbo].[Site]
   SET [SiteName] = @siteName
      ,[SiteAddress] = @siteAddress
      ,[Notes] = @notes
      ,[SiteGUID] = @siteGUID
	  ,[CustomerKey] = @customerKey
	  ,[CompanyId] = @CompanyId
	  ,[SiteCode] = @siteCode
      ,[Logo] = @logo
      ,[LastUpdatedTime] = GETDATE()
	  ,[Version] = @version
 WHERE SiteId = @siteId
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Site]
           (
           [SiteName]
           ,[SiteAddress]
           ,[Notes]
           ,[SiteGUID]
           ,[Logo]
           ,[Guid]
           ,[LastUpdatedTime]
           ,[CustomerKey]
           ,[SiteCode]
		   ,[Version])
     VALUES
           (
           @siteName
           ,@siteAddress
           ,@notes
           ,@siteGUID
           ,@logo
           ,newid()
           ,getdate()
           ,@customerKey
           ,@siteCode
		   ,@version)
end
commit tran
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateTax]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create proc [dbo].[sp_InsertOrUpdateTax]
@TaxId int,
@TaxName varchar(100),
@TaxPercent int,
@ActiveFlag bit
as begin 
if not exists(select Taxid from Tax where TaxId=@TaxId)
begin 
insert into tax(TaxName,TaxPercent,ActiveFlag) values(@TaxName,@TaxPercent,@ActiveFlag)
end
else
 begin
 update Tax set TaxName=@TaxName,TaxPercent=@TaxPercent,ActiveFlag=@ActiveFlag where TaxId=@TaxId
 end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateTaxStructure]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_InsertOrUpdateTaxStructure]
@TaxId int,
@TaxStructureId int,
@TaxStructurePercentage decimal,
@TaxStructureName varchar(max)
as begin 
declare @TaxSum decimal
declare @taxsumbyid decimal
if not exists(select 1 from TaxStructure where TaxStructureId=@TaxStructureId)
 begin 
insert into TaxStructure(TaxId,StructureName,TaxStructurePercentage) values(@TaxId,@TaxStructureName,@TaxStructurePercentage)
select @TaxSum=sum(TaxStructurePercentage) from TaxStructure where TaxId=@TaxId
update Tax set TaxPercent =@TaxSum where TaxId=@TaxId

end
else 
begin 
update TaxStructure set TaxId=@TaxId,TaxStructurePercentage=@TaxStructurePercentage,
StructureName=@TaxStructureName where TaxStructureId=@TaxStructureId

--select @taxsumbyid= TaxStructurePercentage from TaxStructure where TaxStructureId=@TaxStructureId
select @TaxSum=sum(TaxStructurePercentage) from TaxStructure where TaxId=@TaxId

update Tax set TaxPercent =@TaxSum where TaxId=@TaxId

end
end

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateTrxHeader]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP PROC sp_InsertOrUpdateTrxHeader
-- ============================================= 
-- Author:    @Author,,Name 
-- Create date: @Create Date,, 
-- Description:  @Description,, 
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateTrxHeader] @trxId  INT, 
                                                @TrxDate DATE,
												@TrxAmount NUMERIC(10,4), 
												@TrxDiscountPercentage NUMERIC(10,4),
												@TaxAmount  NUMERIC(10,4),  
												@TrxNetAmount  NUMERIC(10,4), 
												@POSMachine NVARCHAR(50) = NULL,
												@UserId INT,
												@PaymentMode INT, 
												@CashAmount NUMERIC(10,4), 
												@CreditCardAmount NUMERIC(10,4),  
												@GameCardAmount NUMERIC(10,4),
												@PaymentReference  NVARCHAR(50),
												@PrimaryCardId INT,
												@OrderId INT,
												@POSTypeId INT,
												@TrxNummber NVARCHAR(50),
												@Remarks NVARCHAR(50),
												@POSMachineId INT,
												@OtherPaymentModeAmount NUMERIC(10,4),
												@Status NVARCHAR(50),
												@TrxProfileId INT,
												@LastUpdateTime DATETIME,
												@LastUpdatedBy NVARCHAR(50),
												@TokenNumber INT = 0,
												@Original_System_Reference NVARCHAR(50) = NULL,
												@CustomerId INT = NULL,
												@ExternalSystemReference  NVARCHAR(50) = NULL,
												@OriginalTrxID INT,
												@txId INT OUT
AS 
  BEGIN 
      -- SET NOCOUNT ON added to prevent extra result sets from 
      -- interfering with SELECT statements. 
      SET nocount ON; 

      IF NOT EXISTS (SELECT TrxId 
                 FROM   TransactionHeader WITH (updlock, serializable) 
                 WHERE  TrxId = @trxId) 
            BEGIN
            -- Insert statements for procedure here 
            INSERT INTO [dbo].[TransactionHeader] 
                        (
						 [TrxDate],
						 [TrxAmount], 
						 [TrxDiscountPercentage],
						 [TaxAmount], 
						 [TrxNetAmount], 
						 [POSMachine], 
						 [UserId],
						 [PaymentMode], 
						 [CashAmount], 
						 [CreditCardAmount], 
						 [GameCardAmount],
						 [PaymentReference],
						 [PrimaryCardId],
						 [OrderId],
						 [POSTypeId],
						 [Guid],						 
						 [TrxNummber],
						 [Remarks],
						 [POSMachineId],
						 [OtherPaymentModeAmount],
						 [Status],
						 [TrxProfileId],
						 [LastUpdateTime],
						 [LastUpdatedBy],
						 [TokenNumber],
						 [Original_System_Reference],
						 [CustomerId],
						 [ExternalSystemReference],
						 [OriginalTrxID]
						 ) 

            VALUES      (
					     @TrxDate,
						 @TrxAmount, 
						 @TrxDiscountPercentage,
						 @TaxAmount, 
						 @TrxNetAmount, 
						 @POSMachine, 
						 @UserId,
						 @PaymentMode, 
						 @CashAmount, 
						 @CreditCardAmount, 
						 @GameCardAmount,
						 @PaymentReference,
						 @PrimaryCardId,
						 @OrderId,
						 @POSTypeId,
						 NEWID(),
						 @TrxNummber,
						 @Remarks,
						 @POSMachineId,
						 @OtherPaymentModeAmount,
						 @Status,
						 @TrxProfileId,
						 @LastUpdateTime,
						 @LastUpdatedBy,
						 @TokenNumber,
						 @Original_System_Reference,
						 @CustomerId,
						 @ExternalSystemReference,
						 @OriginalTrxID
						 ) 
						 SET @txId = (select SCOPE_IDENTITY())

			SELECT @txId;
        END 

  END 

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateTrxLines]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP PROC sp_InsertOrUpdateTrxLines
-- ============================================= 
-- Author:    @Author,,Name 
-- Create date: @Create Date,, 
-- Description:  @Description,, 
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateTrxLines] @TrxId INT,
												@LineId INT, 
												@ProductId INT, 
												@Price decimal(10,4),
												@Quantity decimal(10,0), 
												@Amount decimal(10,4), 
												@CardId INT, 
												@CardNumber NVARCHAR(20),
												@Credits decimal(10,4), 
												@Courtesy decimal(10,4), 
												@TaxPercentage decimal(10,4),
												@TaxId INT,
												@Time decimal(10,4),
												@Bonus  decimal(10,4),
												@Tickets decimal(10,4),
												@LoyaltyPoints decimal(10,4),
												@Remarks NVARCHAR(250),
												@PromotionId INT,
												@ReceiptPrinted BIT = 0,
												@ParentLineId INT,
												@UserPrice BIT = 0,
												@GameplayId INT,
												@CancelledTime datetime = NULL,
												@CancelledBy NVARCHAR(50) = NULL,
												@ProductDescription NVARCHAR(255),
												@OriginalLineID INT
AS 
  BEGIN 
      -- SET NOCOUNT ON added to prevent extra result sets from 
      -- interfering with SELECT statements. 

            -- Insert statements for procedure here 
            INSERT INTO [dbo].[TransactionLines]
                        (
							[TrxId],
							[LineId], 
							[ProductId], 
							[Price],
							[Quantity], 
							[Amount], 
							[CardId], 
							[CardNumber],
							[Credits], 
							[Courtesy], 
							[TaxPercentage],
							[TaxId],
							[Time],
							[Bonus],
							[Tickets],
							[LoyaltyPoints],
							[Guid],
							[Remarks],
							[PromotionId],
							[ReceiptPrinted],
							[ParentLineId],
							[UserPrice],
							[GameplayId],
							[CancelledTime],
							[CancelledBy],
							[ProductDescription],
							[OriginalLineID]

						 ) 

            VALUES      (
					        @TrxId,
							@LineId, 
							@ProductId, 
							@Price,
							@Quantity, 
							@Amount, 
							@CardId, 
							@CardNumber,
							@Credits, 
							@Courtesy, 
							@TaxPercentage,
							@TaxId,
							@Time,
							@Bonus,
							@Tickets,
							@LoyaltyPoints,
							NEWID(),
							@Remarks,
							@PromotionId,
							@ReceiptPrinted,
							@ParentLineId,
							@UserPrice,
							@GameplayId,
							@CancelledTime,
							@CancelledBy,
							@ProductDescription,
							@OriginalLineID
						 ) 
        END 


GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateUser]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateUser] 
    @Id int,
	@LoginId varchar(100),
	@Name varchar(100),
	@Role varchar(50),
	@Email varchar(100),
	@Manager varchar(100),
	@Department varchar(100),
	@CompanyAdmin bit,
	@EmpStartDate datetime,
	@EmpEndDate datetime,
	@EmpEndReason varchar(500),
	@CreatedBy varchar(100),
	@LastUpdatedBy  varchar(50),
	@Status varchar(50),
	@POSCounter varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select Id from [User] with (updlock,serializable) where Id = @id)
   begin
   -- Insert statements for procedure here
	UPDATE [dbo].[User]
   SET [Name] = @Name
      ,[LoginId] = @LoginId
      ,[Role] = @Role
      ,[Status] = @Status
      ,[POSCounter] = @POSCounter
      ,[Email] = @Email
      ,[CompanyAdmin] = @CompanyAdmin
      ,[Department] = @Department
      ,[Manager] = @Manager
      ,[EmpStartDate] = @EmpStartDate
      ,[EmpEndDate] = @EmpEndDate
      ,[EmpEndReason] = @EmpEndReason
      ,[CreatedBy] = @CreatedBy
      ,[LastUpdatedBy] = @LastUpdatedBy
      ,[LastUpdatedDate] = GETDATE()
 WHERE Id = @Id
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[User]
           ([Name]
           ,[LoginId]
           ,[Role]
           ,[Status]
           ,[POSCounter]
           ,[Email]
           ,[CompanyAdmin]
           ,[Department]
           ,[Manager]
           ,[EmpStartDate]
           ,[EmpEndDate]
           ,[EmpEndReason]
           ,[CreatationDate]
           ,[CreatedBy]
           ,[LastUpdatedBy]
           ,[LastUpdatedDate])
     VALUES
           (@Name
           ,@LoginId
           ,@Role
           ,@Status
           ,@POSCounter
           ,@Email
           ,@CompanyAdmin
           ,@Department
           ,@Manager
           ,@EmpStartDate
           ,@EmpEndDate
           ,@EmpEndReason
           ,GETDATE()
           ,@CreatedBy
           ,@LastUpdatedBy
           ,GetDate())
end
commit tran
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateUserRole]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateUserRole] 
    @Id int,
	@Role varchar(50),
	@Description varchar(500),
	@ManagerFlag bit,
	@POSClockInOut bit,
	@AllowPOSAccess bit,
	@AllowShiftOpenClose bit,
	@LastUpdatedBy  varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select id from UserRole with (updlock,serializable) where Id = @id)
   begin
   -- Insert statements for procedure here
	Update UserRole set Role = @Role,[Description] = @description,
							ManagerFlag = @ManagerFlag,AllowPOSAccess= @AllowPOSAccess,
							AllowShiftOpenClose = @AllowShiftOpenClose,POSClockInOut = @POSClockInOut,
							LastUpdatedBy = @LastUpdatedBy,LastUpdatedDate = GETDATE()
							where Id = @Id
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[UserRole]
           ([Role]
           ,[Description]
           ,ManagerFlag
           ,AllowPOSAccess
           ,AllowShiftOpenClose
		   ,POSClockInOut
		   ,LastUpdatedBy,
		   LastUpdatedDate)
     VALUES
           (@Role
           ,@Description
           ,@ManagerFlag
           ,@AllowPOSAccess
           ,@AllowShiftOpenClose
		   ,@POSClockInOut
		   ,@LastUpdatedBy
		   ,GETDATE()
           )
end
commit tran
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertTransactionDiscountLines]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- DROP PROC sp_InsertTransactionDiscountLines
-- ============================================= 
-- Author:    @Author,,Name 
-- Create date: @Create Date,, 
-- Description:  @Description,, 
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_InsertTransactionDiscountLines] 
												@TrxId INT,
												@LineId INT,
												@DiscountId INT, 
												@DiscountAmount numeric (18, 4),
												@DiscountPercentage numeric (18, 4),
												@Remarks NVARCHAR(200),
												@ApprovedBy INT = 0
AS 
  BEGIN 
      -- SET NOCOUNT ON added to prevent extra result sets from 
      -- interfering with SELECT statements. 

            -- Insert statements for procedure here 
            INSERT INTO [dbo].[TransactionDiscountLines]
                        (
							[TrxId],
							[LineId],
							[DiscountId],
							[DiscountAmount],
							[DiscountPercentage],
							[Remarks],
							[ApprovedBy] 

						 ) 

            VALUES      (
					        @TrxId,
							@LineId, 
							@DiscountId, 
							@DiscountAmount,
							@DiscountPercentage, 
							@Remarks, 
							@ApprovedBy
						 ) 
        END 



GO
/****** Object:  StoredProcedure [dbo].[sp_InsertTransactionTaxLines]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP PROC sp_InsertOrUpdateTrxLines
-- ============================================= 
-- Author:    @Author,,Name 
-- Create date: @Create Date,, 
-- Description:  @Description,, 
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_InsertTransactionTaxLines] 
												@TrxId INT,
												@LineId INT,
												@TaxId INT, 
												@TaxStructureId INT,
												@Percentage numeric (18, 4),
												@Amount numeric (9, 4),
												@ProductSplitAmount numeric (9, 4) = 0
AS 
  BEGIN 
      -- SET NOCOUNT ON added to prevent extra result sets from 
      -- interfering with SELECT statements. 

            -- Insert statements for procedure here 
            INSERT INTO [dbo].[TransactionTaxLines]
                        (
							[TrxId],
							[LineId],
							[TaxId],
							[TaxStructureId],
							[Percentage],
							[Amount],
							[ProductSplitAmount] 

						 ) 

            VALUES      (
					        @TrxId,
							@LineId, 
							@TaxId, 
							@TaxStructureId,
							@Percentage, 
							@Amount, 
							@ProductSplitAmount
						 ) 
        END 


GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUpdateOrProductCategory]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[sp_InsertUpdateOrProductCategory]  
@id int =null,  
@Name varchar(100)=null,  
@Active bit,  
@ParentCategory varchar(100)=null  
as begin   
if not exists(select id from productCategory where id=@id)
begin
insert into ProductCategory values(@Name,@Active,@ParentCategory)  
end
else
begin 
update ProductCategory set [Name]=@Name,Active=@Active,ParentCategory=@ParentCategory where id=@id
end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUserRoleModuleAction]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertUserRoleModuleAction]
	
	@RoleId varchar(50),
	@PageIds varchar(max)
AS
BEGIN
	-- Insert statement
	    DELETE from RoleModuleAction where RoleId = @RoleId
		INSERT INTO RoleModuleAction
		SELECT @RoleId, CAST(Item AS INT) , (select [Page] from AppModule where Id = CAST(Item AS INT)) 
		FROM  dbo.SplitString(@PageIds, ',')  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateProductKey]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateProductKey]
	@SiteId int,
	@SiteKey image,
	@LicenseKey image
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   Update ProductKey set SiteKey = @SiteKey,LicenseKey = @LicenseKey where site_id = @SiteId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateProductType]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Harish
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateProductType] 
@id int,
@productType varchar(50),
@description varchar(500),
@reportGroup varchar(50),
@cardSale bit,
@active bit,
@updatedBy varchar(50)

AS
BEGIN
	SET NOCOUNT ON;
	 UPDATE ProductType SET [Type] = @productType
      ,[Description] = @description
      ,[ReportGroup] = @reportGroup
      ,[CardSale] = @cardSale
      ,[Active] = @active
      ,[LastUpdatedDate] = GetDate()
      ,[LastUpdatedBy] = @updatedBy
	WHERE Id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateSettings]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateSettings] 
@id int,
@name varchar(255),
@description varchar(255),
@defaultvalue varchar(200),
@type varchar(100),
@screengroup varchar(50),
@active bit,
@userlevel bit,
@poslevel bit,
@updatedby varchar(100),
@caption varchar(255)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	update Settings set [Name] = @name,[Description] = @description,
							[Caption] = @caption,DefaultValue = @defaultvalue,
							[Type] = @type,ScreenGroup = @screengroup,Active =@active,UserLevel = @userlevel,
							PosLevel =@poslevel,LastUpdatedBy = @updatedby,LastUpdatedDate = GETDATE()
							where ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ValidateUser]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC [sp_ValidateUser] 'amar', '123'
--drop proc [sp_ValidateUser]

-- =============================================
-- Author:		Amaresh
-- =============================================
CREATE PROCEDURE [dbo].[sp_ValidateUser] 
(@loginId NVARCHAR(100),@password  NVARCHAR(100) )
AS
BEGIN
	Select  top 1 * from [User]
	where LoginId = @loginId
	and Password = @password
END
GO
/****** Object:  StoredProcedure [dbo].[sSp_InsertOrUpdateCustomer]    Script Date: 12/4/2019 11:46:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================= 
-- Author:    @Author,,Name 
-- Create date: @Create Date,, 
-- Description:  @Description,, 
-- ============================================= 
CREATE PROCEDURE [dbo].[sSp_InsertOrUpdateCustomer] @CustomerId        INT, 
                                               @CustomerName      NVARCHAR(50), 
                                               @Address1          NVARCHAR(50), 
                                               @Address2          NVARCHAR(50), 
                                               @Address3          NVARCHAR(50), 
                                               @City              NVARCHAR(50), 
                                               @State             NVARCHAR(50), 
                                               @Pin               NVARCHAR(50), 
                                               @Country           NVARCHAR(50), 
                                               @Email             NVARCHAR(50), 
                                               @Gender            CHAR(1), 
                                               @DateOfBirth       DATETIME, 
                                               @Anniversary       DATETIME, 
                                               @ContactPhone1     NVARCHAR(50), 
                                               @ContactPhone2     NVARCHAR(50), 
                                               @Notes             NVARCHAR(max), 
                                               @LastUpdatedDate   DATETIME, 
                                               @LastUpdatedUser   NVARCHAR(50), 
                                               @MiddleName        NVARCHAR(50), 
                                               @LastName          NVARCHAR(50), 
                                               @CustomDataSetId   INT, 
                                               @Company           NVARCHAR(200), 
                                               @Designation       NVARCHAR(200), 
                                               @PhotoFileName     NVARCHAR(100), 
                                               @Guid 
UNIQUEIDENTIFIER, 
                                               @SiteId            INT, 
                                               @UniqueID          VARCHAR(100), 
                                               @Username          NVARCHAR(50), 
                                               @FBUserId          NVARCHAR(20), 
                                               @FBAccessToken     NVARCHAR(20), 
                                               @TWAccessToken     NVARCHAR(20), 
                                               @TWAccessSecret    NVARCHAR(20), 
                                               @RightHanded       BIT, 
                                               @TeamUser          BIT, 
                                               @SynchStatus       BIT, 
                                               @Verified          CHAR(1), 
                                               @Password          NVARCHAR(100), 
                                               @LastLoginTime     DATETIME, 
                                               @ExternalSystemRef NVARCHAR(50), 
                                               @IsValid           BIT, 
                                               @DownloadBatchId   INT, 
                                               @IDProofFileName   NVARCHAR(100), 
                                               @Title             NVARCHAR(20) 
AS 
  BEGIN 
      -- SET NOCOUNT ON added to prevent extra result sets from 
      -- interfering with SELECT statements. 
      SET nocount ON; 

      BEGIN TRAN 

      IF EXISTS (SELECT customerid 
                 FROM   customers WITH (updlock, serializable) 
                 WHERE  customerid = @CustomerId) 
        BEGIN 
            -- update statements for procedure here 
            UPDATE dbo.customers 
            SET    customername = @CustomerName, 
                   address1 = @Address1, 
                   address2 = @Address2, 
                   address3 = @Address3, 
                   city = @City, 
                   [state] = @State, 
                   country = @Country, 
                   pin = @Pin, 
                   email = @Email, 
                   dateofbirth = @DateOfBirth, 
                   gender = @Gender, 
                   anniversary = @Anniversary, 
                   contactphone1 = @ContactPhone1, 
                   contactphone2 = @ContactPhone2, 
                   notes = @Notes, 
                   lastupdateddate = @LastUpdatedDate, 
                   lastupdateduser = @LastUpdatedUser, 
                   middlename = @MiddleName, 
                   lastname = @LastName, 
                   customdatasetid = @CustomDataSetId, 
                   company = @Company, 
                   designation = @Designation, 
                   photofilename = @PhotoFileName, 
                   [guid] = @Guid, 
                   siteid = @SiteId, 
                   uniqueid = @UniqueID, 
                   username = @Username, 
                   fbuserid = @FBUserId, 
                   fbaccesstoken = @FBAccessToken, 
                   twaccesstoken = @TWAccessToken, 
                   twaccesssecret = @TWAccessSecret, 
                   righthanded = @RightHanded, 
                   teamuser = @TeamUser, 
                   synchstatus = @SynchStatus, 
                   verified = @Verified, 
                   [password] = @Password, 
                   lastlogintime = @LastLoginTime, 
                   externalsystemref = @ExternalSystemRef, 
                   isvalid = @IsValid, 
                   downloadbatchid = @DownloadBatchId, 
                   idprooffilename = @IDProofFileName, 
                   title = @Title 
            WHERE  customerid = @CustomerId 
        END 
      ELSE 
        BEGIN 
            -- Insert statements for procedure here 
            INSERT INTO [dbo].[customers] 
                        ([customername], 
                         [address1], 
                         [address2], 
                         [address3], 
                         [city], 
                         [state], 
                         [country], 
                         [pin], 
                         [email], 
                         [dateofbirth], 
                         [gender], 
                         [anniversary], 
                         [contactphone1], 
                         [contactphone2], 
                         [notes], 
                         [lastupdateddate], 
                         [lastupdateduser], 
                         [middlename], 
                         [lastname], 
                         [customdatasetid], 
                         [company], 
                         [designation], 
                         [photofilename], 
                         [guid], 
                         [siteid], 
                         [uniqueid], 
                         [username], 
                         [fbuserid], 
                         [fbaccesstoken], 
                         [twaccesstoken], 
                         [twaccesssecret], 
                         [righthanded], 
                         [teamuser], 
                         [synchstatus], 
                         [verified], 
                         [password], 
                         [lastlogintime], 
                         [externalsystemref], 
                         [isvalid], 
                         [downloadbatchid], 
                         [idprooffilename], 
                         [title]) 
            VALUES      (@CustomerName, 
                         @Address1, 
                         @Address2, 
                         @Address3, 
                         @City, 
                         @State, 
                         @Country, 
                         @Pin, 
                         @Email, 
                         @DateOfBirth, 
                         @Gender, 
                         @Anniversary, 
                         @ContactPhone1, 
                         @ContactPhone2, 
                         @Notes, 
                         @LastUpdatedDate, 
                         @LastUpdatedUser, 
                         @MiddleName, 
                         @LastName, 
                         @CustomDataSetId, 
                         @Company, 
                         @Designation, 
                         @PhotoFileName, 
                         @Guid, 
                         @SiteId, 
                         @UniqueID, 
                         @Username, 
                         @FBUserId, 
                         @FBAccessToken, 
                         @TWAccessToken, 
                         @TWAccessSecret, 
                         @RightHanded, 
                         @TeamUser, 
                         @SynchStatus, 
                         @Verified, 
                         @Password, 
                         @LastLoginTime, 
                         @ExternalSystemRef, 
                         @IsValid, 
                         @DownloadBatchId, 
                         @IDProofFileName, 
                         @Title) 
        END 

      COMMIT TRAN 
  END 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Card Master Table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Card'
GO
USE [master]
GO
ALTER DATABASE [Marbale] SET  READ_WRITE 
GO
