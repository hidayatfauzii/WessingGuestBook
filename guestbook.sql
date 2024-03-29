USE [guestbook]
GO
/****** Object:  Table [dbo].[users]    Script Date: 12/11/2016 23:09:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[username] [nvarchar](50) NOT NULL,
	[passwors] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bukutamu]    Script Date: 12/11/2016 23:09:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bukutamu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nama] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[tanggal] [date] NOT NULL,
	[pesan] [nvarchar](max) NOT NULL,
	[pict] [nvarchar](max) NULL,
 CONSTRAINT [PK_bukutamu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_bukutamu_tanggal]    Script Date: 12/11/2016 23:09:37 ******/
ALTER TABLE [dbo].[bukutamu] ADD  CONSTRAINT [DF_bukutamu_tanggal]  DEFAULT (getdate()) FOR [tanggal]
GO
