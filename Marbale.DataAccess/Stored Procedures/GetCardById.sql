create proc [dbo].[GetCardById]
@CardId int
as begin 

select * from Cards where CardId=@CardId
end
GO