

CREATE PROCEDURE getAllVehicles
@VehicleID int = NULL,
@MakeID int = NULL,
@ModelID int = NULL,
@EngineID int = NULL

AS
BEGIN

IF(@VehicleID IS NULL AND @MakeID IS NULL AND @ModelID IS NULL AND @EngineID IS NULL )
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
END
ELSE IF(@VehicleID IS NOT NULL AND @MakeID IS NULL AND @ModelID IS NULL AND @EngineID IS NULL)
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
	 WHERE vehdet.VehicleTypeId = @VehicleID
	 --WHERE vehdet.VehicleTypeId = 1
END
ELSE IF(@VehicleID IS NOT NULL AND @MakeID IS NOT NULL AND @ModelID IS NULL AND @EngineID IS NULL)
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
	 WHERE vehdet.VehicleTypeId = @VehicleID AND vehdet.MakeId = @MakeID
	 --WHERE vehdet.VehicleTypeId = 2 AND vehdet.MakeId = 3
END
ELSE IF(@VehicleID IS NOT NULL AND @MakeID IS NOT NULL AND @ModelID IS NOT NULL AND @EngineID IS NULL)
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
	 WHERE vehdet.VehicleTypeId = @VehicleID AND vehdet.MakeId = @MakeID AND vehdet.ModelId = @ModelID
	 --WHERE vehdet.VehicleTypeId = 1 AND vehdet.MakeId = 1 AND vehdet.ModelId = 1
END
ELSE IF(@VehicleID IS NOT NULL AND @MakeID IS NOT NULL AND @ModelID IS NOT NULL AND @EngineID IS NOT NULL)
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
	 WHERE vehdet.VehicleTypeId = @VehicleID AND vehdet.MakeId = @MakeID AND vehdet.ModelId = @ModelID AND vehdet.EngineId = @EngineID
	 --WHERE vehdet.VehicleTypeId = 2 AND vehdet.MakeId = 3 AND vehdet.ModelId = 5 AND vehdet.EngineId = 4
END

END