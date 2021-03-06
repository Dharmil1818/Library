USE [LibraryDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2020-12-17 10:39:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 2020-12-17 10:39:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[AuthorName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 2020-12-17 10:39:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[CheckOutDate] [datetime2](7) NULL,
	[StatusId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[CheckedOutBy] [int] NULL,
	[OwnerId] [int] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookAuthor]    Script Date: 2020-12-17 10:39:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAuthor](
	[BookAuthorId] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_BookAuthor] PRIMARY KEY CLUSTERED 
(
	[BookAuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 2020-12-17 10:39:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[BookId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 2020-12-17 10:39:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Owner]    Script Date: 2020-12-17 10:39:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owner](
	[OwnerId] [int] IDENTITY(1,1) NOT NULL,
	[OwnerName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED 
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 2020-12-17 10:39:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2020-12-17 10:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[CratedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201214045226_initialcreate1', N'2.2.0-rtm-35687')
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (1, N'Bill Nye')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (2, N'Brian Greene')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (3, N'Clayton Christensen')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (4, N'Cormac McCarthy')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (5, N'D.L. Marston')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (6, N'Dale Carnegie')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (7, N'Douglas Adams')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (8, N'Emmanuel Jal')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (9, N'Eric Ries')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (10, N'Geoff Smart')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (11, N'Gordon C. Andrews')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (12, N'Gruber')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (13, N'Harper Lee')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (14, N'John McPhee')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (15, N'John Steinbeck')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (16, N'Jojo Moyes')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (17, N'Kim Scott')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (18, N'Kurt Vonnegut')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (19, N'Marq de Villiers')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (20, N'Martin Lindstrom')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (21, N'Morgan')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (22, N'Olson Scott Card')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (23, N'Patricia Shaw')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (24, N'Randy Street')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (25, N'Ray Bradbury')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (26, N'Richard Branson')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (27, N'Richard Peddie')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (28, N'Sheryl Sandberg')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (29, N'Simon Sinek')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (30, N'Stanley E. Portny')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (31, N'Thomas Friedman')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (32, N'Verne Harnish')
INSERT [dbo].[Author] ([AuthorId], [AuthorName]) VALUES (33, N'Walter Isaacson')
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (1, N'The Elegant Universe', NULL, 1, 1, NULL, 1)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (2, N'Fahrenheit 451', NULL, 1, 1, NULL, 1)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (3, N'All the Pretty Horses', NULL, 1, 1, NULL, 1)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (4, N'War Child', NULL, 1, 1, NULL, 1)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (5, N'To Kill a Mockingbird', NULL, 1, 1, NULL, 1)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (6, N'Unstoppable', NULL, 1, 1, NULL, 1)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (7, N'Back to the Well', NULL, 1, 1, NULL, 1)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (8, N'Dream Job', NULL, 1, 1, NULL, 1)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (9, N'Steve Jobs', NULL, 1, 1, NULL, 1)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (10, N'Radical Candor', NULL, 1, 1, NULL, 1)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (11, N'Canadian Professional Engineering and Geoscience: Practice and Ethics', NULL, 3, 1, NULL, 1)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (12, N'Law for Professional Engineers, Canadian and Global Insights', NULL, 3, 1, NULL, 1)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (13, N'Me Before You', NULL, 1, 2, NULL, 2)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (14, N'Canadian Professional Engineering and Geoscience: Practice and Ethics', NULL, 1, 1, NULL, 2)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (15, N'Law for Professional Engineers, Canadian and Global Insights', NULL, 1, 1, NULL, 2)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (16, N'Project Management for Dummies', NULL, 1, 1, NULL, 2)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (17, N'Galapagos', NULL, 1, 2, NULL, 3)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (18, N'Tortilla Flat', NULL, 1, 2, NULL, 3)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (19, N'Ender''s Game', NULL, 1, 2, NULL, 3)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (20, N'The Hitchhiker''s Guide to the Galaxy', NULL, 1, 2, NULL, 3)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (21, N'How to win friends and influence people', NULL, 1, 2, NULL, 4)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (22, N'Leaders eat last', CAST(N'2019-10-17T00:00:00.0000000' AS DateTime2), 3, 1, 2, 4)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (23, N'Start with Why', NULL, 1, 1, NULL, 4)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (24, N'The infinite game', NULL, 1, 2, NULL, 4)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (25, N'Scaling Up', CAST(N'2019-10-11T00:00:00.0000000' AS DateTime2), 3, 3, 1, 5)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (26, N'The lean startup', NULL, 1, 2, NULL, 4)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (27, N'Startup Mixology', NULL, 1, 2, NULL, 4)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (28, N'Hot, flat and Crowded', NULL, 1, 2, NULL, 4)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (29, N'Eating the Big Fish', NULL, 1, 2, NULL, 4)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (30, N'Small Data', NULL, 1, 2, NULL, 4)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (31, N'Losing My Virginity', NULL, 1, 2, NULL, 4)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (32, N'Who: A Method for Hiring', CAST(N'2019-11-05T00:00:00.0000000' AS DateTime2), 3, 1, 3, 5)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (33, N'Lean In: Women, Work and the Will to Lead', NULL, 1, 2, NULL, 6)
INSERT [dbo].[Book] ([BookId], [Title], [CheckOutDate], [StatusId], [LocationId], [CheckedOutBy], [OwnerId]) VALUES (34, N'How will you measure your life', NULL, 1, 2, NULL, 4)
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[BookAuthor] ON 

INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (1, 1, 2)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (2, 2, 25)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (3, 3, 4)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (4, 4, 8)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (5, 5, 13)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (6, 6, 5)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (7, 7, 19)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (8, 8, 27)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (9, 9, 33)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (10, 10, 17)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (11, 11, 11)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (12, 11, 23)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (13, 11, 14)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (14, 12, 5)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (15, 13, 16)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (16, 14, 11)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (17, 14, 23)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (18, 14, 14)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (19, 15, 5)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (20, 16, 30)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (21, 17, 18)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (22, 18, 15)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (23, 19, 22)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (24, 20, 7)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (25, 21, 6)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (26, 22, 29)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (27, 23, 29)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (28, 24, 29)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (29, 25, 32)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (30, 26, 9)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (31, 27, 12)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (32, 28, 31)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (33, 29, 21)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (34, 30, 20)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (35, 31, 26)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (36, 32, 10)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (37, 32, 24)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (38, 33, 28)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (39, 34, 3)
SET IDENTITY_INSERT [dbo].[BookAuthor] OFF
GO
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([LocationId], [LocationName]) VALUES (1, N'Office')
INSERT [dbo].[Location] ([LocationId], [LocationName]) VALUES (2, N'Owner’s Home')
INSERT [dbo].[Location] ([LocationId], [LocationName]) VALUES (3, N'In Transit')
SET IDENTITY_INSERT [dbo].[Location] OFF
GO
SET IDENTITY_INSERT [dbo].[Owner] ON 

INSERT [dbo].[Owner] ([OwnerId], [OwnerName]) VALUES (1, N'Dustin')
INSERT [dbo].[Owner] ([OwnerId], [OwnerName]) VALUES (2, N'Jamie')
INSERT [dbo].[Owner] ([OwnerId], [OwnerName]) VALUES (3, N'Dylan')
INSERT [dbo].[Owner] ([OwnerId], [OwnerName]) VALUES (4, N'Eddie')
INSERT [dbo].[Owner] ([OwnerId], [OwnerName]) VALUES (5, N'Gintas')
INSERT [dbo].[Owner] ([OwnerId], [OwnerName]) VALUES (6, N'Laura')
SET IDENTITY_INSERT [dbo].[Owner] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([StatusId], [StatusName]) VALUES (1, N'Available')
INSERT [dbo].[Status] ([StatusId], [StatusName]) VALUES (2, N'Checked Out')
INSERT [dbo].[Status] ([StatusId], [StatusName]) VALUES (3, N'Damaged or Lost')
INSERT [dbo].[Status] ([StatusId], [StatusName]) VALUES (4, N'Digital Copy')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [UserName], [CratedDate]) VALUES (1, N'Dustin', CAST(N'2020-12-13T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[User] ([UserId], [UserName], [CratedDate]) VALUES (2, N'Jamie', CAST(N'2020-12-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[User] ([UserId], [UserName], [CratedDate]) VALUES (3, N'Eddie', CAST(N'2020-11-15T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[User] OFF
GO
/****** Object:  Index [IX_Book_CheckedOutBy]    Script Date: 2020-12-17 10:39:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_Book_CheckedOutBy] ON [dbo].[Book]
(
	[CheckedOutBy] ASC
)
WHERE ([CheckedOutBy] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Book_LocationId]    Script Date: 2020-12-17 10:39:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_Book_LocationId] ON [dbo].[Book]
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Book_OwnerId]    Script Date: 2020-12-17 10:39:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_Book_OwnerId] ON [dbo].[Book]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Book_StatusId]    Script Date: 2020-12-17 10:39:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_Book_StatusId] ON [dbo].[Book]
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BookAuthor_AuthorId]    Script Date: 2020-12-17 10:39:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_BookAuthor_AuthorId] ON [dbo].[BookAuthor]
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BookAuthor_BookId]    Script Date: 2020-12-17 10:39:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_BookAuthor_BookId] ON [dbo].[BookAuthor]
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comment_BookId]    Script Date: 2020-12-17 10:39:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_Comment_BookId] ON [dbo].[Comment]
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comment_UserId]    Script Date: 2020-12-17 10:39:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_Comment_UserId] ON [dbo].[Comment]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Location_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Location_LocationId]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Owner_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Owner] ([OwnerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Owner_OwnerId]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Status_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Status_StatusId]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_User_CheckedOutBy] FOREIGN KEY([CheckedOutBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_User_CheckedOutBy]
GO
ALTER TABLE [dbo].[BookAuthor]  WITH CHECK ADD  CONSTRAINT [FK_BookAuthor_Author_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([AuthorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookAuthor] CHECK CONSTRAINT [FK_BookAuthor_Author_AuthorId]
GO
ALTER TABLE [dbo].[BookAuthor]  WITH CHECK ADD  CONSTRAINT [FK_BookAuthor_Book_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookAuthor] CHECK CONSTRAINT [FK_BookAuthor_Book_BookId]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Book_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Book_BookId]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_User_UserId]
GO
