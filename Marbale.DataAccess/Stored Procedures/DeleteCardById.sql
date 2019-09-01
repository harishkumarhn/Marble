create proc DeleteCardById
 @CardId int
 as 
 begin 

 delete from Cards where CardId=@CardId
 end
 
