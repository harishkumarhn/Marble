USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAllCards]    Script Date: 11/9/2019 11:26:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

alter  proc [dbo].[sp_GetAllCards]        
@TechnicianCard int=null,        
@CardNumber varchar(20)=null,        
@Custemer varchar(100)=null,        
@VIPCustomer bit=null,        
@IssueDate datetime=null,        
@ToDate datetime=null        
as begin         
  if (@TechnicianCard =1)    
   begin     
  set  @TechnicianCard=2    
    end    
select *,cu.CustomerName as Customer from Card c left join Customer cu on c.CustomerId = cu.CustomerId   
 where  (c.CardNumber=@CardNumber or @CardNumber is null)   
 and (c.VIPCustomer =@VIPCustomer or @VIPCustomer=0 )  
 and (cast(c.IssueDate as date)=cast(@IssueDate as date) or @IssueDate is null)  
 and (cast(c.ExpiryDate as date)=cast( @ToDate as date) or @ToDate is null)  
      and (c.TechnicianCard =@TechnicianCard or @TechnicianCard=0 )    
end        
  
  
  
  


  
        
  
 --  sp_helptext sp_GetAllCards  
GO


