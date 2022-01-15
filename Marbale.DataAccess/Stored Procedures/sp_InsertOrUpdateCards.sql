/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateCards]    Script Date: 8/7/2021 8:47:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[sp_InsertOrUpdateCards] @CardId INT = NULL
	,@CardNumber VARCHAR(20) = NULL
	,
	-- @Custemer        VARCHAR(100)=NULL,
	@FaceValue FLOAT = NULL
	,@IssueDate DATETIME = NULL
	,@LastPlayTime DATETIME = NULL
	,@LastUpdatedBy VARCHAR(100) = NULL
	,@LastUpdatedTime DATETIME = NULL
	,@Note VARCHAR(max) = NULL
	,@RealTicketMode BIT = NULL
	,@RefundDate DATETIME = NULL
	,@StartTime DATETIME = NULL
	,@TechGames VARCHAR(max) = NULL
	,@TicketAllowed BIT = NULL
	,@TicketCount INT = NULL
	,@TimerResetCard BIT = NULL
	,@VIPCustomer BIT = NULL
	,@RefundAmount FLOAT = NULL
	,@TechCardType VARCHAR(100) = NULL
	,@Credits FLOAT = NULL
	,@CreditPlus FLOAT = NULL
	,@Courtesy FLOAT = NULL
	,@CreditsPlayed FLOAT = NULL
	,@Bonus FLOAT = NULL
	,@ExpiryDate DATETIME = NULL
	,@Valid BIT = NULL
AS
BEGIN
	DECLARE @count INT = 0
		,@Result INT = 0
		,@Message VARCHAR(300) = 'Failed'

	SET @count = (
			SELECT count(*)
			FROM card
			WHERE cardnumber = @CardNumber
			)

	IF @count > 0
		AND @CardId = 0
	BEGIN
		SET @Result = 0
		SET @Message = 'Card number already exist'
	END

	ELSE IF @count = 1
		AND @CardId > 0
	BEGIN
		--Update Card
		UPDATE card
		SET cardnumber = @CardNumber
			,
			--custemer = @Custemer,
			facevalue = @FaceValue
			,issuedate = @IssueDate
			,lasttimeplayed = @LastPlayTime
			,lastupdatedby = @LastUpdatedBy
			,lastupdatedtime = @LastUpdatedTime
			,note = @Note
			,realticketmode = @RealTicketMode
			,refunddate = @RefundDate
			,startdatettime = @StartTime
			,techgames = @TechGames
			,ticketallowed = @TicketAllowed
			,ticketcount = @TicketCount
			,timerresetcard = @TimerResetCard
			,vipcustomer = @VIPCustomer
			,techniciancard = @TechCardType
			,refundamount = @RefundAmount
			,credits = @Credits
			,creditplus = @CreditPlus
			,courtesy = @Courtesy
			,creditsplayed = @CreditsPlayed
			,bonus = @Bonus
			,expirydate = @ExpiryDate
			,validFlag = @Valid
		WHERE cardid = @CardId

		SET @Result = 1
		SET @Message = 'Card details updated successfully'
	END
	ELSE
	BEGIN
		---insert Card
		INSERT INTO card (
			cardnumber
			,
			-- custemer,
			facevalue
			,issuedate
			,lasttimeplayed
			,lastupdatedby
			,lastupdatedtime
			,note
			,realticketmode
			,refunddate
			,startdatettime
			,techgames
			,ticketallowed
			,ticketcount
			,timerresetcard
			,vipcustomer
			,techniciancard
			,refundamount
			,credits
			,creditplus
			,creditsplayed
			,bonus
			,courtesy
			,expirydate
			,validFlag
			)
		VALUES (
			@CardNumber
			,
			-- @Custemer,
			@FaceValue
			,Getdate()
			,@LastPlayTime
			,@LastUpdatedBy
			,@LastUpdatedTime
			,@Note
			,@RealTicketMode
			,@RefundDate
			,@StartTime
			,@TechGames
			,@TicketAllowed
			,@TicketCount
			,@TimerResetCard
			,@VIPCustomer
			,@TechCardType
			,@RefundAmount
			,@Credits
			,@CreditPlus
			,@CreditsPlayed
			,@Bonus
			,@Courtesy
			,@ExpiryDate
			,@Valid
			)

		SET @Result = 1
		SET @Message = 'Card details updated successfully'
	END

	SELECT @Result AS Result
		,@Message AS Message
END
