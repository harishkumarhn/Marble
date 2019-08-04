CREATE proc sp_GetProductTaxLookUp  
as begin   
  
select distinct   TaxId as Id,TaxName as Name, TaxPercent from tax  
end