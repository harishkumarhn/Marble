use marbale
insert into settings (Name,Description,DefaultValue,Type,ScreenGroup,Active,UserLevel,PosLevel,Protected,LastUpdatedBy,LastUpdatedDate,Caption)
values ('LOAD_BONUS_LIMIT','Load Bonus Limit',100000,'int','Limit',1,NULL,NULL,NULL,NULL,getdate(),'Load Bonus Limit')

insert into settings (Name,Description,DefaultValue,Type,ScreenGroup,Active,UserLevel,PosLevel,Protected,LastUpdatedBy,LastUpdatedDate,Caption)
values ('LOAD_TICKETS_LIMIT','Load Tickets Limit',1000,'int','Limit',1,NULL,NULL,NULL,NULL,getdate(),'Load Tickets Limit')

insert into settings (Name,Description,DefaultValue,Type,ScreenGroup,Active,UserLevel,PosLevel,Protected,LastUpdatedBy,LastUpdatedDate,Caption)
values ('MANUAL_CARD_UPDATE_GAMES_LIMIT','Manual Card Update Games Limit',200,'int','Limit',1,NULL,NULL,NULL,NULL,getdate(),'Manual Card Update Games Limit')

insert into settings (Name,Description,DefaultValue,Type,ScreenGroup,Active,UserLevel,PosLevel,Protected,LastUpdatedBy,LastUpdatedDate,Caption)
values ('MAX_VARIABLE_RECHARGE_AMAOUNT','Max Variable Recharge Amount',100,'int','Limit',1,NULL,NULL,NULL,NULL,getdate(),'Max Variable Recharge Amount')

select * from settings where ScreenGroup like '%Limit%'