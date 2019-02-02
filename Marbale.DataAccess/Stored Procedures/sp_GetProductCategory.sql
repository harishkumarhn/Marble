USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetProductCategory]    Script Date: 2/2/2019 3:50:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_GetProductCategory]  
as begin   
select * from productCategory order by id 
end 


GO


