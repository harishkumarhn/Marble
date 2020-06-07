
Alter PROCEDURE sp_InsertOrUpdatePaymentMode 
	@PaymentModeId int,
	@PaymentMode varchar(100),
	@IsCreditCard bit,
	@IsDebitCard bit,
	@IsCash bit,
	@IsRoundOff bit,
	@ManagerApprovalRequired bit,
	@POSAvailable bit,
	@DisplayOrder bit,
	@GateWay varchar(100),
	@Guid uniqueidentifier,
	@SynchStatus bit,
	@SiteId int
AS
BEGIN
	
	SET NOCOUNT ON;
	begin tran
if exists (select SiteId from [Site] with (updlock,serializable) where SiteId = @siteId)
   begin
   -- Insert statements for procedure here
	UPDATE [dbo].[PaymentModes]
   SET [PaymentMode]	= @PaymentMode
      ,[PaymentModeId]	= @PaymentModeId
      ,[IsCash]			= @IsCash
      ,[IsCreditCard]	= @IsCreditCard
	  ,[IsDebitCard]	= @IsDebitCard
	  ,[IsRoundOff]		= @IsRoundOff
	  ,[SiteId]			= @SiteId
      ,[Guid]				= @Guid
      ,[ManagerApprovalRequired] = @ManagerApprovalRequired
	  ,[SynchStatus]	= @SynchStatus
	  ,[DisplayOrder] = @DisplayOrder
	  ,[POSAvailable] = @POSAvailable
	  ,[GateWay]		= @GateWay
 WHERE PaymentModeId = @PaymentModeId
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[PaymentModes]
           (		   
		    [PaymentMode]		
		   ,[IsCash]			
		   ,[IsCreditCard]	
		   ,[IsDebitCard]	
		   ,[IsRoundOff]		
		   ,[SiteId]			
		   ,[Guid]			
		   ,[ManagerApprovalRequired]
		   ,[SynchStatus]	
		   ,[DisplayOrder]
		   ,[POSAvailable] 
		   ,[GateWay]		   
		   )
     VALUES
           (@PaymentMode
		   ,@IsCash
		   ,@IsCreditCard,
		   @IsDebitCard
		   ,@IsRoundOff
		   ,@SiteId
		   ,@Guid
		   ,@ManagerApprovalRequired
		   ,@SynchStatus
		   ,@DisplayOrder
		   ,@POSAvailable
		   ,@GateWay)
end
commit tran
END
GO
