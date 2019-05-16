create proc sp_GetAllValuesButtons  
as begin   
  
select * from ValuesButtons where Active =1  
  
end