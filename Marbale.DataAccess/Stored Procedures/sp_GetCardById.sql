alter  proc [dbo].sp_GetCardById
@CardId int
as begin 

select *,cu.CustomerName as Customer from Card c left join Customer cu on cu.CustomerId=c.CustomerId where CardId=@CardId
end
GO