USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_ValidateUser]    Script Date: 3/23/2019 7:11:54 PM ******/
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



