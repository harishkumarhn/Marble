USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateTaskType]    Script Date: 3/24/2019 5:15:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[sp_UpdateTaskType]
@TaskTypeId int,
@TaskType varchar(200),
@TaskTypeName varchar(200),
@RequiresManagerApproval bit,
@DispalyinPOS bit
as begin 

update task_type set TaskType=@TaskType,TaskTypeName=@TaskTypeName,RequiresManagerApproval=@RequiresManagerApproval,
DisplayInPOS=@DispalyinPOS where TaskTypeId=@TaskTypeId
end