USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetActiveHubMachines]    Script Date: 5/26/2019 5:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetActiveHubMachines]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	select mch.Name Machine,mch.Id Id,hub.Name HubName from Machine mch join Hub hub 
	on hub.Name = mch.HubName where mch.Active = 1 and hub.Id = @id
END
