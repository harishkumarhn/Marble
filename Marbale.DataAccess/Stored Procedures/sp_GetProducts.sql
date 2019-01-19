USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDiscounts]    Script Date: 1/19/2019 6:58:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[sp_GetProducts]
as 
begin 
select * from Product
end
