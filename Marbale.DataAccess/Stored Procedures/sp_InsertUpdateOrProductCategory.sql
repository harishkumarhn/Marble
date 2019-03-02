USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateOrInsertProductCategory]    Script Date: 2/2/2019 8:06:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[sp_UpdateOrInsertProductCategory]  
@id int =null,  
@Name varchar(100)=null,  
@Active bit,  
@ParentCategory varchar(100)=null  
as begin   
if not exists(select id from productCategory where id=@id)
begin
insert into ProductCategory values(@Name,@Active,@ParentCategory)  
end
else
begin 
update ProductCategory set Name=@Name,Active=@Active,ParentCategory=@ParentCategory where id=@id
end
end
GO


