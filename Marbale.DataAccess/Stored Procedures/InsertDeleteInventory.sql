USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[InsertDeleteInventory]    Script Date: 11/19/2019 10:25:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[InsertDeleteInventory]  
@Action varchar(10),  
@NumberOfCards int,  
@ActionDate datetime  
as begin   
declare @NoOfCards int  
if (@Action='Reduce')  
begin  
select @NoOfCards=@NumberOfCards*-1  
 end  
 else begin  
 select @NoOfCards=@NumberOfCards  
  end  
insert into inventory(Action,NumberOfCards,ActionDate,ActionBy) values(@Action,@NoOfCards,@ActionDate,'Shridhar')  

select @NoOfCards=count(*) from Inventory

select @NoOfCards'NumberOfCards'
end  
  

GO


