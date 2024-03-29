USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateDisplayGroup]    Script Date: 10/19/2019 11:11:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc  [dbo].[sp_InsertOrUpdateDisplayGroup]
@Id int,
@DisplayGroup varchar(max),
@Description varchar(max),
@SortOrder int
as begin 
if not  exists(select 1 from Displaygroup where Displaygroupid=@Id )
insert into Displaygroup(Displaygroup,Description,SortOrder,LastupdatedBy,LastupdatedDate)values(@DisplayGroup,@Description,
@SortOrder,'',GETDATE())
else
update Displaygroup set DisplayGroup=@DisplayGroup,
Description=@Description,
SortOrder=@SortOrder where Displaygroupid=@Id

end
