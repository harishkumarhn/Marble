USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMessages]    Script Date: 3/24/2019 5:16:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[sp_GetMessages]
as begin
select * from Messages
 end