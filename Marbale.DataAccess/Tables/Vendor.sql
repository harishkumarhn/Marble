 
CREATE TABLE [dbo].[Vendor](
	[VendorId] [int] IDENTITY(1,1) primary key,
	[VendorName] [nvarchar](200) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	Code [nvarchar](50) NULL,
	[Address1] [nvarchar](200) NOT NULL,
	[Address2] [nvarchar](200) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](200) NOT NULL,
	[PostalCode] [nvarchar](20) NOT NULL,
	[AddressRemarks] [nvarchar](max) NOT NULL,
	[ContactName] [nvarchar](200) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Fax] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Website] [nvarchar](max) ,
	[LastModUserId] [nvarchar](50) NULL,
	[IsActive] bit  NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastupdatedBy] [nvarchar](50) NULL,
	[LastupdatedDate] [datetime] NULL
	 
  
)  

