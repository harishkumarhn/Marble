





alter proc [dbo].[sp_InsertOrUpdateCards]   
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
@ExpiryDate  datetime=null
as   
 begin   
  
  alter table card alter column Custemer varchar(100)

    if exists(select 1 from Card where Cardid=@CardId)  
 begin   
 update Card set CardNumber=@CardNumber,Custemer=@Custemer,FaceValue=@FaceValue,IssueDate=@IssueDate,  
 LastTimePlayed=@LastPlayTime,LastUpdatedBy=@LastUpdatedBy,LastUpdatedTime=@LastUpdatedTime,  
 Note=@Note,RealTicketMode=@RealTicketMode,RefundDate=@RefundDate,StartDateTtime=@StartTime,  
 TechGames=@TechGames,TicketAllowed=@TicketAllowed,TicketCount=@TicketCount,TimerResetCard=@TimerResetCard,  
 VIPCustomer=@VIPCustomer,TechnicianCard=@TechCardType,RefundAmount=@RefundAmount,Credits= @Credits,
 CreditPlus=@CreditPlus,Courtesy=@Courtesy,CreditsPlayed=@CreditsPlayed,Bonus=@Bonus,ExpiryDate=@ExpiryDate 
 
  where CardId=@CardId  
 end  
 else   
 begin   
 insert into Card(CardNumber,Custemer,FaceValue,IssueDate,LastTimePlayed,LastUpdatedBy,LastUpdatedTime,Note,  
 RealTicketMode,RefundDate,StartDateTtime,TechGames,TicketAllowed,TicketCount,TimerResetCard,VIPCustomer,TechnicianCard,RefundAmount ,
 Credits,CreditPlus,CreditsPlayed,Bonus,Courtesy ,ExpiryDate
 )values(@CardNumber,@Custemer,@FaceValue,@IssueDate,@LastPlayTime,@LastUpdatedBy,@LastUpdatedTime,  
 @Note,@RealTicketMode,@RefundDate,@StartTime,@TechGames,@TicketAllowed,@TicketCount,@TimerResetCard,@VIPCustomer,  
 @TechCardType,@RefundAmount ,@Credits,@CreditPlus,@CreditsPlayed,@Bonus ,@Courtesy,@ExpiryDate 
 )  
 end  
 end  
  
GO


