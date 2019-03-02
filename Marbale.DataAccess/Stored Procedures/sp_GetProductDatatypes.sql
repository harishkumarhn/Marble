CREATE proc sp_GetProductDatatypes   
as begin   
select distinct identity(int,1,1) Id, Type into #ProductDatatypes from Settings where Type is not null  
select * from #ProductDatatypes  
drop table #ProductDatatypes  
end  
  
  