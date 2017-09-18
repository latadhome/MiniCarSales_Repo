USE [sample]
GO

/****** Object:  StoredProcedure [dbo].[getVehicle]    Script Date: 9/19/2017 2:06:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[getVehicle]
@Id int
AS
BEGIN

SELECT vehdet.[Id],veh.[Id] as VehicleID, veh.[VehicleType],manf.[Id] as MakeId,manf.[Name] as MakeName,modl.[Id] as ModelId,modl.[Name] as ModelName,
	 eng.[Id] as EngineId,eng.[Name] as EngineName,vehdet.[Doors],vehdet.[Wheels],vehdet.[Type],vehdet.[ImagePath]
     FROM [dbo].[VehicleDetails] vehdet
	 INNER JOIN [dbo].[Engine] eng
	 ON eng.Id = vehdet.EngineId and eng.ModelId = vehdet.ModelId
	 INNER JOIN [dbo].[Model] modl
	 ON modl.Id = vehdet.ModelId AND modl.MakeId = vehdet.MakeId AND modl.VehicleId = vehdet.VehicleTypeId
	 INNER JOIN  [dbo].[Manufacturer] manf
	 ON manf.Id = vehdet.MakeId AND manf.VehicleId = vehdet.VehicleTypeId
	 INNER JOIN [dbo].[Vehicle] veh
	 on veh.Id = vehdet.VehicleTypeId
	 where vehdet.Id = @Id

END

GO


