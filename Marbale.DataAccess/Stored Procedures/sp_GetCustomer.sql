USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDiscounts]    Script Date: 1/19/2019 6:58:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP PROCEDURE sp_GetCustomer
Create proc [dbo].[sp_GetCustomer] 
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

