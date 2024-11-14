USE [hmsNoor]
GO

/****** Object:  Table [dbo].[UserAccount]    Script Date: 11/13/24 8:19:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserAccount](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](100) NOT NULL,
	[UserGroup] [nvarchar](20) NOT NULL,
	[Remark] [nvarchar](max) NULL,
	[isInsert] [bit] NULL,
	[isUpdate] [bit] NULL,
	[isDelete] [bit] NULL,
	[InaActive] [bit] NULL,
	[CreateUserId] [int] NULL,
	[ModifyUserId] [int] NULL,
	[CreateUserDate] [datetime] NULL,
	[ModifyUserDate] [datetime] NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


