USE [Marbale] 
/****** Object:  Table [dbo].[Report]    Script Date: 9/13/2020 9:56:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Report](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportName] [nvarchar](200) NULL,
	[ReportKey] [nvarchar](50) NULL,
	[IsCustomReport] [bit] NULL,
	[OutputFormat] [varchar](10) NULL,
	[DBQuery] [varchar](max) NULL,
	[ReportGroup] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK__Report__3214EC076B85C7E3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Report] ON 

GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (1, N'Transaction', N'Transaction', 0, NULL, NULL, N'Sales/Transaction', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (2, N'Shift End Report', N'Shift_End_Report', 1, NULL, NULL, N'Sales/Transaction', 0)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (3, N'Sales By Pos', N'Sales_By_Pos', 1, N'PDF', N' select  h.POSMachine ''POS_Machine'', convert(numeric(10,2), sum(isnull( h.CreditCardAmount,0))) ''Credit_Card_Amount'',  sum(h.trxAmount  ) Gross_total  from TransactionHeader H
where h.trxdate between @dateFrom and @dateTo
   
 group by h.POSMachine    ', N'Sales/Transaction', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (4, N'Sales By User', N'Sales_By_User', 1, NULL, N' 
select  isnull(h.posmachine, ''Undefined'') ''POS_Counter'' , u.Name ''User'', u.LoginId LoginID , sum( h.trxNetAmount )  ''Void_Amount'', sum(h.TrxAmount),''Total''
from  TransactionHeader h 
left join [User] u on u.Id=h.userid where h.trxdate between @dateFrom and @dateTo
group by h.posmachine,u.Name,u.LoginId ', N'Sales/Transaction', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (5, N'Sales By product', N'Sales_By_product', 1, NULL, N'
select pt.Type,  p.Name,sum(l.Quantity ) Quantity,  sum( L.Amount) Tax ,sum(ttl.Amount )Total  from TransactionHeader h
inner join TransactionLines l on h.TrxId=l.TrxId
left join TransactionTaxLines ttl on ttl.TrxId=l.TrxId and ttl.LineId=l.LineId   
inner join product p on l.ProductId=p.Id
inner join ProductType pt on pt.Id=p.Type
where h.trxdate between @dateFrom and @dateTo
group by pt.Type,p.Name', N'Sales/Transaction', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (6, N'Sales Reversal', N'Sales_Reversal', 1, NULL, N'
select l.CancelledTime Date,p.Type ''Product_Type'',p.Name ''Product_Name'',l.CardNumber,l.Quantity,l.Amount ''Net_Amount'', l.Price ''Gross'', ttl.Amount ''Tax''
,u.Name ''User_Name'',h.Remarks
  from TransactionHeader h
inner join TransactionLines l on h.TrxId=l.TrxId
left join TransactionTaxLines ttl on ttl.TrxId=l.TrxId and ttl.LineId=l.LineId   
 inner join product p on l.ProductId=p.Id
 inner join ProductType pt on pt.Id=p.Type
  left join [User] u on u.Id=h.UserId where h.trxdate between @dateFrom and @dateTo', N'Sales/Transaction', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (7, N'Sales Refund', N'Sales_Refund', 1, NULL, N'
  select h.TrxDate Date, l.CardNumber  ''Card Number'' , l.Amount ''Net Amount'', l.Price ''Gross'', ttl.Amount ''Tax''
,u.Name ''User Name'',h.Remarks
  from TransactionHeader h
inner join TransactionLines l on h.TrxId=l.TrxId
left join TransactionTaxLines ttl on ttl.TrxId=l.TrxId and ttl.LineId=l.LineId   
 inner join product p on l.ProductId=p.Id
 inner join ProductType pt on pt.Id=p.Type
  left join [User] u on u.Id=h.UserId
  where pt.Type=''REFUND''  and h.trxdate between @dateFrom and @dateTo  ', N'Sales/Transaction', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (8, N'Card Activity Report', N'Card_Activity_Report', 1, NULL, N'
select c.CustomerId,cu.customername, c.CardId,c.ValidFlag, c.CardNumber,   sum(quantity * price) Amount, sum(l.credits) Credits, sum(l.bonus) Bonus, sum(l.courtesy) Courtesy, sum(l.time) Time , sum(l.Tickets) Tickets 
from card c
inner join  TransactionLines l on c.CardId = l.CardId
left join customer cu on c.CustomerId=cu.customerid
where 
c.IssueDate >= @dateFrom and c.IssueDate < @dateTo   
AND ValidFlag = 1
group by c.CardId, c.CardNumber,  cu.customername, c.credits, c.bonus, c.courtesy ,c.ValidFlag,c.CustomerId', N'Cards', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (9, N'Balance on Active card', N'Balanceon_Active_card', 1, NULL, N'
	 select  substring(convert(varchar, IssueDate, 106), 4, 8) issue_month, count(*) count, sum(FaceValue) card_deposit, 
sum(Amount) Amount,
sum(Credits) Credits, sum(Bonus) Bonus, sum(Courtesy) Courtesy, sum(Time) Time, sum(credits) credits, sum(bonus) bal_bonus, sum(courtesy) bal_courtesy, sum(time) bal_time,sum(Tickets) ''balance_Tickets''
from( 

select c.CardId, c.CardNumber, c.FaceValue, IssueDate, c.credits credits1, c.bonus bonus1,  c.courtesy courtesy1, sum(quantity * price) Amount, sum(l.credits) Credits, sum(l.bonus) Bonus, sum(l.courtesy) Courtesy, sum(l.time) Time , sum(l.Tickets) Tickets 
from card c, TransactionLines l
where 
 c.IssueDate >= @dateFrom and c.IssueDate < @dateTo and 
c.CardId = l.CardId
and ValidFlag = 1   
group by c.CardId, c.CardNumber, c.FaceValue, IssueDate, c.credits, c.bonus, c.courtesy 

)main
group by substring(convert(varchar, IssueDate, 106), 4, 8) ', N'Cards', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (10, N'Card Balance Report', N'Card_Balance_Report', 1, NULL, N'
 
 select   main.CardNumber,case when main.ValidFlag =1 then ''Active'' else ''De-active'' end ''Active'', count(*) count, sum(FaceValue) card_deposit, 
sum(Amount) Amount,
sum(Credits) Credits, sum(Bonus) Bonus, sum(Courtesy) Courtesy, sum(Time) Time, sum(credits) credits, sum(bonus) bal_bonus, sum(courtesy) bal_courtesy, sum(time) bal_time,sum(Tickets) ''balance_Tickets''
from( 

select c.CardId,c.ValidFlag, c.CardNumber, c.FaceValue, IssueDate, c.credits credits1, c.bonus bonus1,  c.courtesy courtesy1, sum(quantity * price) Amount, sum(l.credits) Credits, sum(l.bonus) Bonus, sum(l.courtesy) Courtesy, sum(l.time) Time , sum(l.Tickets) Tickets 
from card c, TransactionLines l
where 
c.IssueDate >= @dateFrom and c.IssueDate < @dateTo and 
c.CardId = l.CardId
and ValidFlag = 1
group by c.CardId, c.CardNumber, c.FaceValue, IssueDate, c.credits, c.bonus, c.courtesy ,c.ValidFlag

)main
group by substring(convert(varchar, IssueDate, 106), 4, 8) ,main.CardNumber,main.ValidFlag', N'Cards', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (11, N'Card report By product', N'Card_report_By_roduct', 1, NULL, N'
select l.CardNumber, p.Name,sum(l.Quantity ) Quantity, c.IssueDate, 
(select top 1  min(h.trxdate) from  TransactionHeader h1
inner join TransactionLines l1  on h1.TrxId=l1.TrxId where l1.cardnumber=l.cardnumber) first_use,
(select top 1  max(h.trxdate) from  TransactionHeader h1
inner join TransactionLines l1  on h1.TrxId=l1.TrxId where l1.cardnumber=l.cardnumber) last_use

  from TransactionHeader h
inner join TransactionLines l on h.TrxId=l.TrxId
left join TransactionTaxLines ttl on ttl.TrxId=l.TrxId and ttl.LineId=l.LineId   
inner join product p on l.ProductId=p.Id
inner join ProductType pt on pt.Id=p.Type
inner join  card c on c.CardId=l.CardId
group by pt.Type,p.Name ,l.CardNumber,c.IssueDate', N'Cards', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (12, N'Card Expiry report', N'Card_Expiry_report', 1, NULL, N'select l.CardNumber , c.IssueDate,   p.Name,sum(l.Quantity ) Quantity,
(case when c.ExpiryDate>=getdate() then c.Credits  else 0 end) Balance, 
(select top 1  max(h.trxdate) from  TransactionHeader h1
inner join TransactionLines l1  on h1.TrxId=l1.TrxId where l1.cardnumber=l.cardnumber) last_use,
(case when c.ExpiryDate<getdate() then c.Credits  else 0 end) ''Expired_Balance''
  from TransactionHeader h
inner join TransactionLines l on h.TrxId=l.TrxId
left join TransactionTaxLines ttl on ttl.TrxId=l.TrxId and ttl.LineId=l.LineId   
inner join product p on l.ProductId=p.Id
inner join ProductType pt on pt.Id=p.Type
inner join  card c on c.CardId=l.CardId
group by pt.Type,p.Name ,l.CardNumber,c.IssueDate,c.Credits ,c.ExpiryDate', N'Cards', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (13, N'Card Inventory', N'Card_Inventory', 1, NULL, NULL, N'Cards', 0)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (14, N'Registered Customer report', N'Registered_Customer_report', 1, NULL, N'select c.CardNumber, cu.customername,cu.ContactPhone1,cu.Email,cu.Address1,cu.Address2,  c.ValidFlag ''Valid'', 
sum(quantity * price) Amount, sum(l.credits) Credits, sum(l.time) Time , sum(l.bonus) Bonus,  sum(l.Tickets) Tickets ,
(case when c.expirydate<GETDATE() then sum(l.credits)  else 0 end) ''Balance_Credits'',
(case when c.expirydate<GETDATE() then sum(l.Time )  else 0 end) ''Balance_Time'' ,
(case when c.expirydate<GETDATE() then sum(l.Bonus)  else 0 end) ''Balance_Bonus'',
(case when c.expirydate<GETDATE() then sum(l.Tickets)  else 0 end) ''Balance_Tickets''
from card c
inner join  TransactionLines l on c.CardId = l.CardId
left join customer cu on c.CustomerId=cu.customerid
where 
--c.IssueDate >= @dateFrom and c.IssueDate < @dateTo and 
 ValidFlag = 1
group by c.CardId, c.CardNumber,  cu.customername, c.credits, c.bonus, c.courtesy ,c.ValidFlag,c.CustomerId,cu.ContactPhone1,cu.Email,cu.Address1,cu.Address2,c.ExpiryDate', N'Customer', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (15, N'Game Play Report', N'Game_Play_Report', 1, NULL, NULL, N'Games', 0)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (16, N'Technician Card Report', N'Technician_Card_Report', 1, NULL, NULL, N'Games', 0)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (17, N'Inventory Product report', N'Inventory_Product_report', 1, NULL, N'
select p.ProductName,p.Code ''Product Code'', c.CategoryName ''Category'',p.Description,p.IsActive ''Active'',s.Quantity,l.Name ''Location'',p.Cost ,p.SalePrice,p.PriceInTickets ''Ticket Price'',v.Name ''Vendor'' from InventoryProduct p
inner join InventoryStore s on s.ProductId=p.ProductId and s.LocationId=p.DefaultLocationId
inner join Category c on c.CategoryId=p.CategoryId
inner join Location l on l.LocationId=s.LocationId
inner join Vendor v on v.VendorId=p.DefaultVendorId', N'Inventory', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (18, N'Inventory Status report', N'Inventory_Status_report', 1, NULL, NULL, N'Inventory', 0)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (19, N'Redemption Report', N'Redemption_Report', 1, NULL, NULL, N'Redemption', 0)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (20, N'sad', N'sad', 0, N'PDF', N' asdaasd', N'asd', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (21, N'sad', N'sad', 0, N'PDF', N' asdaasd', N'asd', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (22, N'sad', N'sad', 0, N'PDF', N' asdaasd', N'asd', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (23, N'sad', N'sad', 0, N'PDF', N' asdaasd', N'asd', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (36, N'asda', N'asda', 0, N'EXCEL', N' asdasd', N'sdasd', 0)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (37, N'asd', N'asd', 0, N'PDF', N' asd', N'sad', 0)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (38, N'asd', N'asd', 1, N'EXCEL', N' dasdasd', N'asdas', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (39, N'asdas', N'asdas', 1, N'EXCEL', N' asd', N'dasd', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (40, N'asdas', N'asdas', 1, N'PDF', N' asdas', N'dasd', 1)
GO
INSERT [dbo].[Report] ([Id], [ReportName], [ReportKey], [IsCustomReport], [OutputFormat], [DBQuery], [ReportGroup], [IsActive]) VALUES (41, N'asdas', N'asdas', 1, N'PDF', N' asd', N'asd', 1)
GO
SET IDENTITY_INSERT [dbo].[Report] OFF
GO
