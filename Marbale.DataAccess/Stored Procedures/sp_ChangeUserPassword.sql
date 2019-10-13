USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_ChangeUserPassword]    Script Date: 9/6/2019 10:13:19 AM ******/
SET ANSI_NULLS ON
GO

-- DROP PROC sp_ChangeUserPassword
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


