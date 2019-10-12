USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateCards]    Script Date: 9/6/2019 10:13:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_InsertOrUpdateCards]   
@CardId int=null ,  
@CardNumber varchar(20)=null,  
@Custemer varchar(100)=null,  
@FaceValue float =null,  
@IssueDate datetime=null,  
@LastPlayTime datetime=null,  
@LastUpdatedBy varchar(100)=null,  
@LastUpdatedTime datetime =null,  
@Note varchar(max) =null,  
@RealTicketMode bit =null,  
@RefundDate datetime =null,  
@StartTime datetime =null,  
@TechGames varchar(max) =null,  
@TicketAllowed bit =null,  
@TicketCount int =null,  
@TimerResetCard bit =null,  
@VIPCustomer bit =null,  
@RefundAmount float=null,  
@TechCardType varchar(100)=null  ,
@Credits float =null,
@CreditPlus float=null,
@Courtesy float =null,
@CreditsPlayed float=null,
@Bonus float =null,
@ExpireDate datetime=null
as   
 begin   
  
    if exists(select 1 from Cards where Cardid=@CardId)  
 begin   
 update Cards set CardNumber=@CardNumber,Custemer=@Custemer,FaceValue=@FaceValue,IssueDate=@IssueDate,  
 LastPlayTime=@LastPlayTime,LastUpdatedBy=@LastUpdatedBy,LastUpdatedTime=@LastUpdatedTime,  
 Note=@Note,RealTicketMode=@RealTicketMode,RefundDate=@RefundDate,StartTime=@StartTime,  
 TechGames=@TechGames,TicketAllowed=@TicketAllowed,TicketCount=@TicketCount,TimerResetCard=@TimerResetCard,  
 VIPCustomer=@VIPCustomer,TechCardType=@TechCardType,RefundAmount=@RefundAmount,Credits= @Credits,
 CreditPlus=@CreditPlus,Courtesy=@Courtesy,CreditsPlayed=@CreditsPlayed,Bonus=@Bonus,ExpiryDate=@ExpireDate
 
  where CardId=@CardId  
 end  
 else   
 begin   
 insert into Cards(CardNumber,Custemer,FaceValue,IssueDate,LastPlayTime,LastUpdatedBy,LastUpdatedTime,Note,  
 RealTicketMode,RefundDate,StartTime,TechGames,TicketAllowed,TicketCount,TimerResetCard,VIPCustomer,TechCardType,RefundAmount ,
 Credits,CreditPlus,CreditsPlayed,Bonus,Courtesy ,ExpiryDate
 )values(@CardNumber,@Custemer,@FaceValue,@IssueDate,@LastPlayTime,@LastUpdatedBy,@LastUpdatedTime,  
 @Note,@RealTicketMode,@RefundDate,@StartTime,@TechGames,@TicketAllowed,@TicketCount,@TimerResetCard,@VIPCustomer,  
 @TechCardType,@RefundAmount ,@Credits,@CreditPlus,@CreditsPlayed,@Bonus ,@Courtesy,@ExpireDate
 )  
 end  
 end  
  
GO


