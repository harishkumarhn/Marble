USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdatePrintTemplateHeader]    Script Date: 12/1/2019 6:48:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Alter PROCEDURE [dbo].[sp_InsertOrUpdatePrintTemplateItems] 
	@Id int,
    @TemplateId int,
	@Sequence int,
	@Section varchar(200),
	@FontName varchar(100),
	@FontSize int,
	@Col1Alignment varchar(1),
	@Col1Data varchar(100),
	@Col2Alignment varchar(1),
	@Col2Data varchar(100),
	@Col3Alignment varchar(1),
	@Col3Data varchar(100),
	@Col4Alignment varchar(1),
	@Col4Data varchar(100),
	@Col5Alignment varchar(1),
	@Col5Data varchar(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select Id from [ReceiptPrintTemplate] with (updlock,serializable) where Id = @Id)
   begin
   -- Insert statements for procedure here
	UPDATE [dbo].[ReceiptPrintTemplate]
   SET TemplateId = @TemplateId
	  ,[Sequence] = @Sequence
	  ,Section = @Section
      ,FontName = @FontName
      ,FontSize = @FontSize
	  ,Col1Alignment = @Col1Alignment
	  ,Col1Data = @Col1Data
	  ,Col2Alignment = @Col2Alignment
	  ,Col2Data = @Col2Data
	  ,Col3Alignment = @Col3Alignment
	  ,Col3Data = @Col3Data
	  ,Col4Alignment = @Col4Alignment
	  ,Col4Data = @Col4Data
	  ,Col5Alignment = @Col5Alignment
	  ,Col5Data = @Col5Data

 WHERE Id = @Id
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[ReceiptPrintTemplate]
           (TemplateId
		   ,Sequence
		   ,Section
           ,FontName
           ,FontSize
		   ,Col1Alignment
		   ,Col1Data
		   ,Col2Alignment
		   ,Col2Data
		   ,Col3Alignment
		   ,Col3Data
		   ,Col4Alignment
		   ,Col4Data
		   ,Col5Alignment
		   ,Col5Data)
     VALUES
           (@TemplateId
		   ,@Sequence
		   ,@Section
           ,@FontName
           ,@FontSize
		   ,@Col1Alignment
		   ,@Col1Data
		   ,@Col2Alignment
		   ,@Col2Data
		   ,@Col3Alignment
		   ,@Col3Data
		   ,@Col4Alignment
		   ,@Col4Data
		   ,@Col5Alignment
		   ,@Col5Data
           )
end
commit tran
END
