USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetDiscounts]    Script Date: 1/13/2019 6:01:51 PM ******/
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


