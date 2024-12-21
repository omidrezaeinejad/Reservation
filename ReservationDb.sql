/****** Object:  Table [dbo].[Meetings]    Script Date: 12/21/2024 4:12:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meetings](
	[Id] [uniqueidentifier] NOT NULL,
	[Date] [date] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
	[EmailAddress] [nvarchar](100) NOT NULL,
	[Subject] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Meetings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Meetings] ([Id], [Date], [StartTime], [EndTime], [CreateDateTime], [EmailAddress], [Subject], [Description]) VALUES (N'dbed2f32-b051-41e4-954f-dc216db6e512', CAST(N'2024-12-21' AS Date), CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), CAST(N'2024-12-21T12:52:59.840' AS DateTime), N'omid.rezaeinejad@gmail.com', N'تست جلسه', N'توضیحات')
GO
INSERT [dbo].[Meetings] ([Id], [Date], [StartTime], [EndTime], [CreateDateTime], [EmailAddress], [Subject], [Description]) VALUES (N'5d8971eb-f951-49b6-b5ff-e0f4edc62ced', CAST(N'2024-12-21' AS Date), CAST(N'12:00:00' AS Time), CAST(N'14:00:00' AS Time), CAST(N'2024-12-21T16:02:39.137' AS DateTime), N'omid.rezaeinejad@gmail.com', N'تست جلسه', N'توضیحات')
GO
INSERT [dbo].[Meetings] ([Id], [Date], [StartTime], [EndTime], [CreateDateTime], [EmailAddress], [Subject], [Description]) VALUES (N'5192ab9b-ee15-4388-9ed5-e129c2a49ab6', CAST(N'2024-12-21' AS Date), CAST(N'16:00:00' AS Time), CAST(N'18:00:00' AS Time), CAST(N'2024-12-21T16:06:48.147' AS DateTime), N'omid.rezaeinejad@gmail.com', N'تست جلسه', N'توضیحات')
GO
/****** Object:  Index [IX_Meetings_Date_StartTime]    Script Date: 12/21/2024 4:12:46 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Meetings_Date_StartTime] ON [dbo].[Meetings]
(
	[Date] ASC,
	[StartTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
