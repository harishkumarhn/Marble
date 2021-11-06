 
 delete   from Settings
where ScreenGroup='pos'
 
 
delete from Settings
where ScreenGroup='card'

INSERT [dbo].[Settings] (  [Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active]  ) 
VALUES 
(  'ALLOW_MANUAL_CARD_IN_POS',  'Allow_Manual_Card In POS',  'True', 'bool', N'card', 1  ),
(  'ALLOW_PARTIAL_REFUND',  'Allow Partial Refund In POS',  'True', 'bool', N'card', 1  ),
(  'ALLOW_FULL_REFUND',  'Allow Full Refund In POS',  'True', 'bool', N'card', 1  ),
(  'CARD_FACE_VALUE',  'Allow_Manual_Card In POS',  '10', 'int', N'card', 1  ),
(  'ALLOW_MANUAL_CARD_IN_POS',  'Price of a Card',  'True', 'bool', N'card', 1  ),
(  'CARD_NUMBER_LENGTH',  'Card Number Length',  '8', 'int', N'card', 1  ),
(  'CARD_VALIDITY',  'Card Validity in number of Months',        '12', 'int', N'card', 1  ), 
(  'REACTIVATE_EXPIRED_CARD',  'Reactivate Expired Card',        'True', 'bool', N'card', 1  ),
(  'REVERSE_DESKTOP_CARDNUMBER',  'Reverse Desktop CardNumber',  'True', 'bool', N'card', 1  )
	 GO



INSERT [dbo].[Settings] ([Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [Caption], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'ENALE_DISCOUNT_IN_POS', N'Enale Discount In POS', N'True', N'bool', N'POS', 1, NULL, NULL, NULL, N'Enale Discount In POS', NULL, NULL)
GO
INSERT [dbo].[Settings] ([Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [Caption], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'ENALE_PRODUCT_IN_POS', N'Enale Product In POS', N'True', N'bool', N'POS', 1, NULL, NULL, NULL, N'Enale Product In POS', NULL, NULL)
GO
INSERT [dbo].[Settings] ([Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [Caption], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'ENALE_REFUND_IN_POS', N'Enale Refund In POS', N'False', N'bool', N'POS', 1, NULL, NULL, NULL, N'Enale Refund In POS', NULL, NULL)
GO
INSERT [dbo].[Settings] ([Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [Caption], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'ENALE_TASK_IN_POS', N'Enale Task In POS', N'False', N'bool', N'POS', 1, NULL, NULL, NULL, N'Enale Task In POS', NULL, NULL)
GO




INSERT [dbo].[Settings] ([Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [Caption], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'USB_READER_OPT_STRING', N'USB Reader Optional String', N'0000', N'string', N'POS', 1, NULL, NULL, NULL, N'USB Reader Optional String', NULL, NULL)
GO
INSERT [dbo].[Settings] ([Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [Caption], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'USB_READER_PID', N'Use Reader PID', N'PID_0035', N'string', N'POS', 1, NULL, NULL, NULL, N'USB Reader PID', NULL, NULL)
GO
INSERT [dbo].[Settings] ([Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [Caption], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'USB_READER_VID', N'USB Reader VID', N'VID_FFFF', N'string', N'POS', 1, NULL, NULL, NULL, N'USB Reader VID', NULL, NULL)
GO


INSERT [dbo].[Settings] ([Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [Caption], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'ENALE_CARDDETAILS_IN_POS', N'Enale Card Details In POS', N'True', N'bool', N'POS', 0, NULL, NULL, NULL, N'Enale Card Details In POS', NULL, NULL)
GO

INSERT [dbo].[Settings] ([Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [Caption], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'POS_CARD_READER_BAUDRATE', N'Card Reader COM Port Baudrate', N'2', N'int', N'POS', 0, 1, 1, NULL, N'Card Reader COM Port Baudrate', NULL, NULL)
GO
INSERT [dbo].[Settings] ([Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [Caption], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'POS_SKIN_COLOR', N'POS Screen Skin Color', N'blue', N'string', N'POS', 0, 1, 1, NULL, N'POS Screen Skin Color', NULL, NULL)
GO
INSERT [dbo].[Settings] ([Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [Caption], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'RETURN_WITHIN_DAYS', N'Return Within Days', N'300', N'int', N'POS', 0, NULL, NULL, NULL, N'Return Within Days', NULL, NULL)
GO
INSERT [dbo].[Settings] ([Name], [Description], [DefaultValue], [Type], [ScreenGroup], [Active], [UserLevel], [PosLevel], [Protected], [Caption], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'SHOW_POS_SHIFT_COLLECTION', N'Show POS Shift Collection', N'True', N'bool', N'POS', 0, NULL, NULL, NULL, N'Show POS Shift Collection', NULL, NULL)
GO