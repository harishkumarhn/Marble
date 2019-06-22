USE [Marbale] 

go 

/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateCard]    Script Date: 6/22/2019 11:42:05 PM ******/ 
SET ansi_nulls ON 

go 

SET quoted_identifier ON 

go 

-- ============================================= 
-- Author:    @Author,,Name 
-- Create date: @Create Date,, 
-- Description:  @Description,, 
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateCard] @CardNumber        INT, 
                                               @IssueDate         DATETIME, 
                                               @FaceValue         INT, 
                                               @RefundFlag        BIT, 
                                               @RefundAmount      INT, 
                                               @RefundDate        DATETIME, 
                                               @ValidFlag         BIT, 
                                               @TicketCount       INT, 
                                               @LastUpdated       DATETIME, 
                                               @Credits           DECIMAL, 
                                               @Courtesy          DECIMAL, 
                                               @Bonus             INT, 
                                               @CustomerId        INT, 
                                               @CreditsPlayed     DECIMAL, 
                                               @TicketAllowed     BIT, 
                                               @RealTicketMode    BIT, 
                                               @VipCustomer       BIT, 
                                               @SiteId            INT, 
                                               @Notes             VARCHAR(200), 
                                               @StartDateTtime    DATETIME, 
                                               @LastTimePlayed    DATETIME, 
                                               @LastUpdatedBy     VARCHAR(50), 
                                               @TechnicianCard    BIT, 
                                               @TechGames         BIT, 
                                               @TimerResetCard    BIT, 
                                               @LoyaltyPoints     INT, 
                                               @CardTypeId        INT, 
                                               @Guid 
UNIQUEIDENTIFIER, 
                                               @UploadSiteId      INT, 
                                               @UploadTime        DATETIME, 
                                               @SynchStatus       BIT, 
                                               @ExpiryDate        DATETIME, 
                                               @DownloadBatchId   INT, 
                                               @RefreshFromHQTime DATETIME 
AS 
  BEGIN 
      -- SET NOCOUNT ON added to prevent extra result sets from 
      -- interfering with SELECT statements. 
      SET nocount ON; 

      BEGIN TRAN 

      IF EXISTS (SELECT cardnumber 
                 FROM   cards WITH (updlock, serializable) 
                 WHERE  cardnumber = @CardNumber) 
        BEGIN 
            -- Insert statements for procedure here 
            UPDATE dbo.cards 
            SET    cardnumber = @CardNumber, 
                   issuedate = @IssueDate, 
                   facevalue = @FaceValue, 
                   refundflag = @RefundFlag, 
                   refundamount = @RefundAmount, 
                   refunddate = @RefundDate, 
                   validflag = @ValidFlag, 
                   ticketcount = @TicketCount, 
                   notes = @Notes, 
                   lastupdated = @LastUpdated, 
                   credits = @Credits, 
                   courtesy = @Courtesy, 
                   bonus = @Bonus, 
                   customerid = @CustomerId, 
                   creditsplayed = @CreditsPlayed, 
                   ticketallowed = @TicketAllowed, 
                   realticketmode = @RealTicketMode, 
                   vipcustomer = @VipCustomer, 
                   siteid = @SiteId, 
                   startdatettime = @StartDateTtime, 
                   lasttimeplayed = @LastTimePlayed, 
                   techniciancard = @TechnicianCard, 
                   techgames = @TechGames, 
                   timerresetcard = @TimerResetCard, 
                   loyaltypoints = @LoyaltyPoints, 
                   lastupdatedby = @LastUpdatedBy, 
                   cardtypeid = @CardTypeId, 
                   guid = @Guid, 
                   uploadsiteid = @UploadSiteId, 
                   uploadtime = @UploadTime, 
                   synchstatus = @SynchStatus, 
                   expirydate = @ExpiryDate, 
                   downloadbatchid = @DownloadBatchId, 
                   refreshfromhqtime = @RefreshFromHQTime 
            WHERE  cardnumber = @CardNumber 
        END 
      ELSE 
        BEGIN 
            -- Insert statements for procedure here 
            INSERT INTO [dbo].[cards] 
                        ([cardnumber], 
                         [issuedate], 
                         [facevalue], 
                         [refundflag], 
                         [refundamount], 
                         [refunddate], 
                         [validflag], 
                         [ticketcount], 
                         [notes], 
                         [lastupdated], 
                         [credits], 
                         [courtesy], 
                         [bonus], 
                         [customerid], 
                         [creditsplayed], 
                         [ticketallowed], 
                         [realticketmode], 
                         [vipcustomer], 
                         [siteid], 
                         [startdatettime], 
                         [lasttimeplayed], 
                         [techniciancard], 
                         [techgames], 
                         [timerresetcard], 
                         [loyaltypoints], 
                         [lastupdatedby], 
                         [cardtypeid], 
                         [guid], 
                         [uploadsiteid], 
                         [uploadtime], 
                         [synchstatus], 
                         [expirydate], 
                         [downloadbatchid], 
                         [refreshfromhqtime]) 
            VALUES      (@CardNumber, 
                         @IssueDate, 
                         @FaceValue, 
                         @RefundFlag, 
                         @RefundAmount, 
                         @RefundDate, 
                         @ValidFlag, 
                         @TicketCount, 
                         @Notes, 
                         @LastUpdated, 
                         @Credits, 
                         @Courtesy, 
                         @Bonus, 
                         @CustomerId, 
                         @CreditsPlayed, 
                         @TicketAllowed, 
                         @RealTicketMode, 
                         @VipCustomer, 
                         @SiteId, 
                         @StartDateTtime, 
                         @LastTimePlayed, 
                         @TechnicianCard, 
                         @TechGames, 
                         @TimerResetCard, 
                         @LoyaltyPoints, 
                         @LastUpdatedBy, 
                         @CardTypeId, 
                         @Guid, 
                         @UploadSiteId, 
                         @UploadTime, 
                         @SynchStatus, 
                         @ExpiryDate, 
                         @DownloadBatchId, 
                         @RefreshFromHQTime) 
        END 

      COMMIT TRAN 
  END 