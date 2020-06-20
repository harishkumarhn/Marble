	 
Create View InventoryActivity
as	 
	 
	 select 'Current Stock' TrxType, ProductId, LocationId, -1 TransferLocationId, Quantity, LastUpdatedDate, LastUpdatedBy 
	from InventoryStore l
	
	union all
	
	select AdjustmentType, productid, fromlocationid, -1, AdjustmentQuantity, LastUpdatedDate, LastUpdatedBy 
	from InventoryAdjustments
	 
	union all
	
	select 'Receipts', Productid, Locationid, -1, quantity, r.ReceiveDate, r.ReceivedBy 
	from PurchaseOrderReceiveLine l, InventoryReceipt r
	where r.InventoryReceiptID = l.ReceiptId
	 