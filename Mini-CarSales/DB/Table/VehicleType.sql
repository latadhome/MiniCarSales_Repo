USE [Test_MiniCarSales]
GO
/****** Object:  Table [dbo].[VehicleType]    Script Date: 9/17/2017 4:04:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleType]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleType]
GO
/****** Object:  Table [dbo].[VehicleType]    Script Date: 9/17/2017 4:04:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VehicleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NULL,
	[Type] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
