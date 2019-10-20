create  proc [dbo].[sp_GetAllCards]      
@TechnicianCard bit=null,      
@CardNumber varchar(20)=null,      
@Custemer varchar(100)=null,      
@VIPCustomer bit=null,      
@IssueDate datetime=null,      
@ToDate datetime=null      
as begin       
select * from Card   c
 
 where  (c.CardNumber=@CardNumber or @CardNumber is null) 
 and (c.VIPCustomer =@VIPCustomer or @VIPCustomer=0 )
 and (cast(c.IssueDate as date)=cast(@IssueDate as date) or @IssueDate is null)
  and (cast(c.ExpiryDate as date)=cast( @ToDate as date) or @ToDate is null)
     
end      
      