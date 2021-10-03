USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateDisplayGroup]    Script Date: 10/3/2021 9:54:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc  [dbo].[sp_InsertOrUpdateDisplayGroup]
@Id int,
@DisplayGroup varchar(max),
@Description varchar(max),
@SortOrder int,
@LastUpdatedBy varchar(max)
as begin 
if not  exists(select 1 from Displaygroup where Id=@Id )
insert into Displaygroup(Displaygroup,Description,SortOrder,LastupdatedBy,LastupdatedDate)values(@DisplayGroup,@Description,
@SortOrder,'',GETDATE())
else
update Displaygroup set DisplayGroup=@DisplayGroup,
Description=@Description,
SortOrder=@SortOrder,
LastUpdatedBy=@LastUpdatedBy,
LastUpdatedDate = GETDATE() where Id=@Id

end
