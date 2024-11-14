USE [hmsNoor]
GO

/****** Object:  Table [dbo].[UserGroup]    Script Date: 11/13/24 8:19:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserGroup](
	[UserGroupName] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[InActive] [bit] NULL,
	[CreateUserId] [int] NULL,
	[ModifyUserId] [int] NULL,
	[CreateUserDate] [datetime] NULL,
	[ModifyUserDate] [datetime] NULL,
	[FO] [bit] NULL,
	[SaleService] [bit] NULL,
	[Restaurant] [bit] NULL,
	[Account] [bit] NULL,
	[Setup] [bit] NULL,
	[UserAdmin] [bit] NULL,
	[Setting] [bit] NULL,
	[Store] [bit] NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[UserGroupName] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


