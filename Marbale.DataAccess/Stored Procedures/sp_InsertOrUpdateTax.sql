USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateTax]    Script Date: 3/24/2019 5:15:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER proc [dbo].[sp_InsertOrUpdateTax]
@TaxId int,
@TaxName varchar(100),
@TaxPercent int,
@ActiveFlag bit
as begin 
if not exists(select Taxid from Tax where TaxId=@TaxId)
begin 
insert into tax(TaxName,TaxPercent,ActiveFlag) values(@TaxName,@TaxPercent,@ActiveFlag)
end
else
 begin
 update Tax set TaxName=@TaxName,TaxPercent=@TaxPercent,ActiveFlag=@ActiveFlag where TaxId=@TaxId
 end
end