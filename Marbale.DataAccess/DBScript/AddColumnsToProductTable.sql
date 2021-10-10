alter table product add DisplayOrder int null
alter table product add CardExpiryDate datetime null
alter table product add MaximumQuantity int null
alter table product add HSNSACCode varchar(max) null
alter table product add vipCard bit null
alter table product add LineRemarksMandatory bit null
alter table product add InvokeCustomerRegistration bit null
-- Added Newly 
alter table product add InventoryProductCode int null
alter table product add Description varchar(MAX) null