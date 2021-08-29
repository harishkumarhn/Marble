 
Create Procedure  CardTransactionSelect
@cardid int=0
As
(

SELECT l.CardId,
	h.trxdate ,
	p.Name ProductName,
	l.amount Amount,
	isnull(l.credits, 0.0) Credits,
	l.courtesy Courtesy,
	isnull(l.bonus, 0.0) AS Bonus,
	isnull(l.TIME, 0) AS [TIME],
	NULL AS Tokens,
	isnull(l.tickets, 0) AS Tickets,
	h.POSMachine POS,
	u.Name 'UserFullName',
	l.Quantity,
	l.Price Price,
	h.TrxId RefId,
	'TRANSACTION' ActivityType
FROM TransactionHeader h
LEFT JOIN TransactionLines l ON l.trxid = h.trxid AND l.CardId IS NOT NULL
LEFT JOIN [User] u ON u.Id = h.UserId
LEFT JOIN Product p ON p.Id = l.ProductId
where (@cardid=0 or  l.CardId=@cardid)
)
