USE [ContactInfo]
GO
/****** Object:  Table [dbo].[tblContactInfo]    Script Date: 5/29/2018 3:32:56 PM ******/
DROP TABLE [dbo].[tblContactInfo]
GO
/****** Object:  Table [dbo].[tblContactInfo]    Script Date: 5/29/2018 3:32:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblContactInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](500) NULL,
	[PhoneNo] [bigint] NULL,
	[ContactStatus] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblContactInfo] ON 

INSERT [dbo].[tblContactInfo] ([Id], [FirstName], [LastName], [Email], [PhoneNo], [ContactStatus]) VALUES (1, N'Jon', N'Allen', N'Jon.allen@gmail.com', 345688878, NULL)
SET IDENTITY_INSERT [dbo].[tblContactInfo] OFF
