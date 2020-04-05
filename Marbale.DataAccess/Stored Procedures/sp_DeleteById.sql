USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteProductById]    Script Date: 4/5/2020 7:29:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Alter proc [dbo].[sp_DeleteById]  
@id int,
@from varchar(50)
as begin   
  IF @from = 'product'
BEGIN
    Delete from product where id =@id  
END
  IF @from = 'user'
BEGIN
    Delete from [User] where id =@id  
END
IF @from = 'card'
BEGIN
    delete from [Card] where CardId = @id
END
end
