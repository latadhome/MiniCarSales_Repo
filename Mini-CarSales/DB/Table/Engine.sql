USE [Test_MiniCarSales]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Engine__ModelId__10566F31]') AND parent_object_id = OBJECT_ID(N'[dbo].[Engine]'))
ALTER TABLE [dbo].[Engine] DROP CONSTRAINT [FK__Engine__ModelId__10566F31]
GO
/****** Object:  Table [dbo].[Engine]    Script Date: 9/17/2017 4:02:54 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Engine]') AND type in (N'U'))
DROP TABLE [dbo].[Engine]
GO
/****** Object:  Table [dbo].[Engine]    Script Date: 9/17/2017 4:02:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Engine]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Engine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[ModelId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Engine__ModelId__10566F31]') AND parent_object_id = OBJECT_ID(N'[dbo].[Engine]'))
ALTER TABLE [dbo].[Engine]  WITH CHECK ADD FOREIGN KEY([ModelId])
REFERENCES [dbo].[Model] ([Id])
GO
