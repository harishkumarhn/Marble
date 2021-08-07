USE [Marbale]

go

/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateCards]    Script Date: 8/7/2021 8:47:35 PM ******/
SET ansi_nulls ON

go

SET quoted_identifier ON

go

ALTER PROC [dbo].[sp_InsertOrUpdateCards] @CardId          INT=NULL,
                                          @CardNumber      VARCHAR(20)=NULL,
                                          @Custemer        VARCHAR(100)=NULL,
                                          @FaceValue       FLOAT =NULL,
                                          @IssueDate       DATETIME=NULL,
                                          @LastPlayTime    DATETIME=NULL,
                                          @LastUpdatedBy   VARCHAR(100)=NULL,
                                          @LastUpdatedTime DATETIME =NULL,
                                          @Note            VARCHAR(max) =NULL,
                                          @RealTicketMode  BIT =NULL,
                                          @RefundDate      DATETIME =NULL,
                                          @StartTime       DATETIME =NULL,
                                          @TechGames       VARCHAR(max) =NULL,
                                          @TicketAllowed   BIT =NULL,
                                          @TicketCount     INT =NULL,
                                          @TimerResetCard  BIT =NULL,
                                          @VIPCustomer     BIT =NULL,
                                          @RefundAmount    FLOAT=NULL,
                                          @TechCardType    VARCHAR(100)=NULL,
                                          @Credits         FLOAT =NULL,
                                          @CreditPlus      FLOAT=NULL,
                                          @Courtesy        FLOAT =NULL,
                                          @CreditsPlayed   FLOAT=NULL,
                                          @Bonus           FLOAT =NULL,
                                          @ExpiryDate      DATETIME=NULL,
										  @Valid		   BIT =NULL 
AS
  BEGIN
      ALTER TABLE card
        ALTER COLUMN custemer VARCHAR(100)

      IF EXISTS(SELECT 1
                FROM   card
                WHERE  cardid = @CardId)
        BEGIN
            UPDATE card
            SET    cardnumber = @CardNumber,
                   custemer = @Custemer,
                   facevalue = @FaceValue,
                   issuedate = @IssueDate,
                   lasttimeplayed = @LastPlayTime,
                   lastupdatedby = @LastUpdatedBy,
                   lastupdatedtime = @LastUpdatedTime,
                   note = @Note,
                   realticketmode = @RealTicketMode,
                   refunddate = @RefundDate,
                   startdatettime = @StartTime,
                   techgames = @TechGames,
                   ticketallowed = @TicketAllowed,
                   ticketcount = @TicketCount,
                   timerresetcard = @TimerResetCard,
                   vipcustomer = @VIPCustomer,
                   techniciancard = @TechCardType,
                   refundamount = @RefundAmount,
                   credits = @Credits,
                   creditplus = @CreditPlus,
                   courtesy = @Courtesy,
                   creditsplayed = @CreditsPlayed,
                   bonus = @Bonus,
                   expirydate = @ExpiryDate,
				   validFlag = @Valid
            WHERE  cardid = @CardId
        END
      ELSE
        BEGIN
            INSERT INTO card
                        (cardnumber,
                         custemer,
                         facevalue,
                         issuedate,
                         lasttimeplayed,
                         lastupdatedby,
                         lastupdatedtime,
                         note,
                         realticketmode,
                         refunddate,
                         startdatettime,
                         techgames,
                         ticketallowed,
                         ticketcount,
                         timerresetcard,
                         vipcustomer,
                         techniciancard,
                         refundamount,
                         credits,
                         creditplus,
                         creditsplayed,
                         bonus,
                         courtesy,
                         expirydate,
						 validFlag)
            VALUES     (@CardNumber,
                        @Custemer,
                        @FaceValue,
                        Getdate(),
                        @LastPlayTime,
                        @LastUpdatedBy,
                        @LastUpdatedTime,
                        @Note,
                        @RealTicketMode,
                        @RefundDate,
                        @StartTime,
                        @TechGames,
                        @TicketAllowed,
                        @TicketCount,
                        @TimerResetCard,
                        @VIPCustomer,
                        @TechCardType,
                        @RefundAmount,
                        @Credits,
                        @CreditPlus,
                        @CreditsPlayed,
                        @Bonus,
                        @Courtesy,
                        @ExpiryDate,
						@Valid )
        END
  END 