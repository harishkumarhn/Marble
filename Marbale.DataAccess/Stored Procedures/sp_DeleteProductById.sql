USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[DeleteProductById]    Script Date: 8/24/2019 11:46:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[DeleteProductById]  
@Id int  
as begin   
  
Delete from product where id =@id  
end
GO


