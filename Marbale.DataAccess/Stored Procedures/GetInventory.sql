USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[GetInventory]    Script Date: 8/28/2020 8:54:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[GetInventory]    
@From datetime=null,
@To datetime=null

as begin     

declare @TotalNumberOfCards int  

if (isnull(@From,'')='' and isnull(@To,'')='')
begin

  set  @TotalNumberOfCards = (select sum(NumberOfCards) from Inventory where Action = 'Add' ) - (select sum(NumberOfCards) from Inventory where Action = 'Reduce') 
select @TotalNumberOfCards'TotalNumberOfCards',null'User',* from inventory

 end
 else begin 

set  @TotalNumberOfCards = (select sum(NumberOfCards) from Inventory where Action = 'Add' ) - (select sum(NumberOfCards) from Inventory where Action = 'Reduce') 
select @TotalNumberOfCards'TotalNumberOfCards',null'User',* from inventory    where ActionDate between @From and @To
    end
end



