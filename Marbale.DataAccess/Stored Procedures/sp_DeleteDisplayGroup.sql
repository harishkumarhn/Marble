use Marbale
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vijeth>
-- Create date: <16-OCT-2021>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE sp_DeleteDisplayGroup
	-- Add the parameters for the stored procedure here	
	@Id Int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Delete statements for procedure here
	IF (@Id > 0)
	BEGIN
		IF((Select count(Id) from DisplayGroup where Id = @Id) = 1)
		BEGIN
			DELETE from DisplayGroup where Id = @Id
		END
	END
	return @Id
END
GO
