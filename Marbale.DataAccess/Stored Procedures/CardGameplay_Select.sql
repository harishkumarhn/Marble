
create procedure CardGameplay_Select
@CardNumber varchar(50) =''

AS
SELECT     c.CardNumber, gp.credits, gp.courtesy, gp.bonus, gp.time, gp.PlayedDate, gp.TicketCount, 
		   g.Name 'GameName', m.Name 'MachineName', m.MachineAddress, 
          gpr.Name 'Profile', m.id 'MachineId', gp.CardId
FROM         
 
	  machine AS m inner JOIN
              gameplay AS gp ON gp.MachineId = m.Id inner JOIN
              Card AS c ON c.CardId = gp.CardId INNER JOIN
              Game AS g ON m.gameid = g.id INNER JOIN
              GameProfile AS gpr ON g.GameProfileId = gpr.id
			  where (@CardNumber='' or @CardNumber =c.CardNumber)