USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdatePaymentMode]    Script Date: 6/15/2020 6:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Alter PROCEDURE [dbo].[sp_InsertOrUpdateSequence] 
	@SequenceId int,
	@SequenceName varchar(100),
	@Seed int,
	@Increment int,
	@CurrentValue int,
	@Suffix nvarchar(10),
	@Prefix nvarchar(10)
AS
BEGIN
	
	SET NOCOUNT ON;
	
begin tran
if exists (select @SequenceId from Sequences with (updlock,serializable) where SequenceId = @SequenceId)
   begin
   -- Insert statements for procedure here
	Update Sequences set 
	SeqName = @SequenceName,
	Seed = @Seed,
	Incr = @Increment,
	Currval = @CurrentValue,
	Prefix = @Prefix,
	Suffix = @Suffix
	where SequenceId = @SequenceId
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Sequences]
           (SeqName
		   ,Seed
           ,Incr
           ,Currval
		   ,Prefix
		   ,Suffix)
     VALUES
           (@SequenceName,
			@Seed ,
			@Increment ,
			@CurrentValue,
			@Prefix,
			@Suffix)
end
commit tran

END
