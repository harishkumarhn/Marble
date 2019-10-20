create proc [dbo].[GetCardById]
@CardId int
as begin 

select * from Card where CardId=@CardId
end
GO