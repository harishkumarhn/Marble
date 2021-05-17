/****** Object:  Table [dbo].[Sequences]    Script Date: 7/5/2020 2:53:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sequences](
[SequenceId] [int] IDENTITY(1,1) NOT NULL,
[SeqName] [nvarchar](255) NOT NULL,
[Seed] [int] NOT NULL,
[Incr] [int] NOT NULL,
[Currval] [int] NULL,
[Prefix] [nvarchar](10) NULL,
[Suffix] [nvarchar](10) NULL,
[Width] [int] NULL,
[UserColumnHeading] [nvarchar](20) NULL,
[Guid] [uniqueidentifier] NULL,
[SynchStatus] [bit] NULL,
[site_id] [int] NULL,
[POSMachineId] [int] NULL,
[MaximumValue] [int] NULL,
[MasterEntityId] [int] NULL,
 CONSTRAINT [PK_Sequences] PRIMARY KEY CLUSTERED
(
[SequenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Sequences] ADD  DEFAULT ((1)) FOR [Seed]
GO

ALTER TABLE [dbo].[Sequences] ADD  DEFAULT ((1)) FOR [Incr]
GO

ALTER TABLE [dbo].[Sequences] ADD  CONSTRAINT [DF_Sequences_Guid]  DEFAULT (newid()) FOR [Guid]
GO

--ALTER TABLE [dbo].[Sequences]  WITH CHECK ADD  CONSTRAINT [FK_Sequences_POSMachines] FOREIGN KEY([POSMachineId])
--REFERENCES [dbo].[POSMachines] ([POSMachineId])
--GO

--ALTER TABLE [dbo].[Sequences] CHECK CONSTRAINT [FK_Sequences_POSMachines]
GO



