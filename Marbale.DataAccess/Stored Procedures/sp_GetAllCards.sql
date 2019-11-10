USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllCards]    Script Date: 10/27/2019 10:54:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  proc [dbo].[sp_GetAllCards]      
@TechnicianCard bit=null,      
@CardNumber varchar(20)=null,      
@Custemer varchar(100)=null,      
@VIPCustomer bit=null,      
@IssueDate datetime=null,      
@ToDate datetime=null      
as begin       
select *,cu.CustomerName as Customer from Card c left join Customer cu on c.CustomerId = cu.CustomerId 
 where  (c.CardNumber=@CardNumber or @CardNumber is null) 
 and (c.VIPCustomer =@VIPCustomer or @VIPCustomer=0 )
 and (cast(c.IssueDate as date)=cast(@IssueDate as date) or @IssueDate is null)
 and (cast(c.ExpiryDate as date)=cast( @ToDate as date) or @ToDate is null)
     
end      
      