delete from product
delete from ProductType
insert into ProductType values ('Manual','Manual','type',1,1,GETDATE(),'vijeth')
insert into ProductType values ('New Card','New Card','type',1,1,GETDATE(),'vijeth')
insert into ProductType values ('Recharge','Recharge','type',1,1,GETDATE(),'vijeth')
insert into ProductType values ('Variable','Variable','type',1,1,GETDATE(),'vijeth')
insert into ProductType values ('Tier Card','Tier Card','type',1,1,GETDATE(),'vijeth')
select * from ProductType