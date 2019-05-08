-- create table camers_operzal_configuration
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[camers_operzal_configuration](
	[config_id] [varchar](50) NOT NULL,
	[config_value] [varchar](500) NOT NULL,
	[config_description] [varchar](max) NULL,
 CONSTRAINT [PK_camers_operzal_configuration] PRIMARY KEY CLUSTERED 
(
	[config_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


-- create table camers_operzal_general
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[camers_operzal_general](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ifns_code] [varchar](4) NOT NULL,
	[camera_img_link] [varchar](1000) NOT NULL,
	[camera_img_file] [varchar](1000) NOT NULL,
	[camera_disable] [bit] NULL,
	[camera_disable_description] [text] NULL,
	[camera_user] [varchar](50) NULL,
	[camera_password] [varchar](50) NULL,
 CONSTRAINT [PK_camers_operzal_general] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[camers_operzal_general]  WITH CHECK ADD  CONSTRAINT [FK_camers_operzal_general_camers_operzal_ifns] FOREIGN KEY([ifns_code])
REFERENCES [dbo].[camers_operzal_ifns] ([ifns_cod])
GO

ALTER TABLE [dbo].[camers_operzal_general] CHECK CONSTRAINT [FK_camers_operzal_general_camers_operzal_ifns]
GO

ALTER TABLE [dbo].[camers_operzal_general] ADD  CONSTRAINT [DF_Table_1_camera_enable]  DEFAULT ((0)) FOR [camera_disable]
GO

-- create table camers_operzal_ifns
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[camers_operzal_ifns](
	[ifns_cod] [varchar](4) NOT NULL,
	[ifns_name] [varchar](250) NOT NULL,
	[order] [int] NULL,
 CONSTRAINT [PK_camers_operzal_ifns] PRIMARY KEY CLUSTERED 
(
	[ifns_cod] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


-- create table camers_operzal_notification
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[camers_operzal_notification](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address] [varchar](250) NOT NULL,
	[message] [text] NULL,
	[date_create] [datetime] NULL,
	[file_name] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[camers_operzal_notification] ADD  DEFAULT (getdate()) FOR [date_create]
GO

-- create table camers_operzal_user_log
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[camers_operzal_user_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[session_id] [varchar](255) NOT NULL,
	[date_add] [datetime] NULL,
	[user_ip] [varchar](20) NOT NULL,
	[camera_id] [varchar](10) NULL,
	[camera_ifns] [varchar](4) NULL,
	[user_browser_agent] [varchar](250) NULL,
	[user_browser_name] [varchar](50) NULL,
	[user_browser_version] [varchar](50) NULL,
	[user_browser_platform] [varchar](50) NULL,
	[user_browser_pattern] [varchar](50) NULL,
 CONSTRAINT [PK_camers_operzal_user_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[camers_operzal_user_log] ADD  CONSTRAINT [DF_camers_operzal_user_log_date_add]  DEFAULT (getdate()) FOR [date_add]
GO



