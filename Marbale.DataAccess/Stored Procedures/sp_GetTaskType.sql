USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTaskType]    Script Date: 3/24/2019 5:11:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[sp_GetTaskType]
as begin
select * from task_type
 end