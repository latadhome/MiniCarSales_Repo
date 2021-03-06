USE [Test_MiniCarSales]
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[chk_VehicleWheels]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleDetails]'))
ALTER TABLE [dbo].[VehicleDetails] DROP CONSTRAINT [chk_VehicleWheels]
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[chk_VehicleDoors]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleDetails]'))
ALTER TABLE [dbo].[VehicleDetails] DROP CONSTRAINT [chk_VehicleDoors]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__VehicleDe__Model__7C1A6C5A]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleDetails]'))
ALTER TABLE [dbo].[VehicleDetails] DROP CONSTRAINT [FK__VehicleDe__Model__7C1A6C5A]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__VehicleDe__MakeI__7B264821]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleDetails]'))
ALTER TABLE [dbo].[VehicleDetails] DROP CONSTRAINT [FK__VehicleDe__MakeI__7B264821]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__VehicleDe__Engin__7D0E9093]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleDetails]'))
ALTER TABLE [dbo].[VehicleDetails] DROP CONSTRAINT [FK__VehicleDe__Engin__7D0E9093]
GO
/****** Object:  Table [dbo].[VehicleDetails]    Script Date: 9/17/2017 3:58:55 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleDetails]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleDetails]
GO
/****** Object:  Table [dbo].[VehicleDetails]    Script Date: 9/17/2017 3:58:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VehicleDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleTypeId] [varchar](50) NULL,
	[MakeId] [int] NULL,
	[ModelId] [int] NULL,
	[EngineId] [int] NULL,
	[Doors] [int] NULL,
	[Wheels] [int] NULL,
	[Type] [varchar](50) NULL,
	[ImagePath] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unique_vehicle] UNIQUE NONCLUSTERED 
(
	[VehicleTypeId] ASC,
	[MakeId] ASC,
	[ModelId] ASC,
	[EngineId] ASC,
	[Doors] ASC,
	[Wheels] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__VehicleDe__Engin__7D0E9093]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleDetails]'))
ALTER TABLE [dbo].[VehicleDetails]  WITH CHECK ADD FOREIGN KEY([EngineId])
REFERENCES [dbo].[Engine] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__VehicleDe__MakeI__7B264821]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleDetails]'))
ALTER TABLE [dbo].[VehicleDetails]  WITH CHECK ADD FOREIGN KEY([MakeId])
REFERENCES [dbo].[Manufacturer] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__VehicleDe__Model__7C1A6C5A]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleDetails]'))
ALTER TABLE [dbo].[VehicleDetails]  WITH CHECK ADD FOREIGN KEY([ModelId])
REFERENCES [dbo].[Model] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[chk_VehicleDoors]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleDetails]'))
ALTER TABLE [dbo].[VehicleDetails]  WITH CHECK ADD  CONSTRAINT [chk_VehicleDoors] CHECK  (([VehicleTypeId]=(1) AND [Doors]>(0) OR [VehicleTypeId]=(2) AND [Doors]=(0) OR NOT ([VehicleTypeId]=(2) OR [VehicleTypeId]=(1)) AND [Doors]>=(0)))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[chk_VehicleDoors]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleDetails]'))
ALTER TABLE [dbo].[VehicleDetails] CHECK CONSTRAINT [chk_VehicleDoors]
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[chk_VehicleWheels]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleDetails]'))
ALTER TABLE [dbo].[VehicleDetails]  WITH CHECK ADD  CONSTRAINT [chk_VehicleWheels] CHECK  (([VehicleTypeId]=(1) AND [Wheels]>=(4) OR [VehicleTypeId]=(2) AND [Wheels]>=(2) AND [Wheels]<=(4) OR NOT ([VehicleTypeId]=(2) OR [VehicleTypeId]=(1)) AND [Wheels]>=(0)))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[chk_VehicleWheels]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleDetails]'))
ALTER TABLE [dbo].[VehicleDetails] CHECK CONSTRAINT [chk_VehicleWheels]
GO
