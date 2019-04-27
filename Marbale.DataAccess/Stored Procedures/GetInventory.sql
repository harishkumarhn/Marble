create proc GetInventory    
@From datetime=null,
@To datetime=null

as begin     

declare @TotalNumberOfCards int  

if (isnull(@From,'')='' and isnull(@To,'')='')
begin

  select @TotalNumberOfCards =sum(NumberOfCards) from Inventory  
select @TotalNumberOfCards'TotalNumberOfCards',null'User',* from inventory

 end
 else begin 

  select @TotalNumberOfCards =sum(NumberOfCards) from Inventory  
select @TotalNumberOfCards'TotalNumberOfCards',null'User',* from inventory    where ActionDate between @From and @To
    end
end



