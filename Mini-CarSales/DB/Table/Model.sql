USE [Test_MiniCarSales]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Model__VehicleId__0D7A0286]') AND parent_object_id = OBJECT_ID(N'[dbo].[Model]'))
ALTER TABLE [dbo].[Model] DROP CONSTRAINT [FK__Model__VehicleId__0D7A0286]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Model__MakeId__0C85DE4D]') AND parent_object_id = OBJECT_ID(N'[dbo].[Model]'))
ALTER TABLE [dbo].[Model] DROP CONSTRAINT [FK__Model__MakeId__0C85DE4D]
GO
/****** Object:  Table [dbo].[Model]    Script Date: 9/17/2017 4:01:38 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Model]') AND type in (N'U'))
DROP TABLE [dbo].[Model]
GO
/****** Object:  Table [dbo].[Model]    Script Date: 9/17/2017 4:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Model]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Model](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[MakeId] [int] NOT NULL,
	[VehicleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UniqueModel_Vehicle_Make] UNIQUE NONCLUSTERED 
(
	[MakeId] ASC,
	[VehicleId] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Model__MakeId__0C85DE4D]') AND parent_object_id = OBJECT_ID(N'[dbo].[Model]'))
ALTER TABLE [dbo].[Model]  WITH CHECK ADD FOREIGN KEY([MakeId])
REFERENCES [dbo].[Manufacturer] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Model__VehicleId__0D7A0286]') AND parent_object_id = OBJECT_ID(N'[dbo].[Model]'))
ALTER TABLE [dbo].[Model]  WITH CHECK ADD FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicle] ([Id])
GO
