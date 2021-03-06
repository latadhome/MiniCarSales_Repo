USE [Test_MiniCarSales]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Manufactu__Vehic__07C12930]') AND parent_object_id = OBJECT_ID(N'[dbo].[Manufacturer]'))
ALTER TABLE [dbo].[Manufacturer] DROP CONSTRAINT [FK__Manufactu__Vehic__07C12930]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 9/17/2017 3:54:34 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Manufacturer]') AND type in (N'U'))
DROP TABLE [dbo].[Manufacturer]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 9/17/2017 3:54:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Manufacturer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Manufacturer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[VehicleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Unique_Vehicle_Make] UNIQUE NONCLUSTERED 
(
	[VehicleId] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Manufactu__Vehic__07C12930]') AND parent_object_id = OBJECT_ID(N'[dbo].[Manufacturer]'))
ALTER TABLE [dbo].[Manufacturer]  WITH CHECK ADD FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicle] ([Id])
GO
