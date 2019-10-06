USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDiscountById]    Script Date: 8/15/2019 1:19:50 AM ******/
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




