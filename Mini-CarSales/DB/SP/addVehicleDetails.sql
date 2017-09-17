

ALTER PROCEDURE addVehicleDetails
@VehicleID int = NULL,
@VehicleType varchar(20),
@MakeID int = NULL,
@MakeName varchar(50),
@ModelID int = NULL,
@ModelName varchar(50),
@EngineID int = NULL,
@EngineName varchar(50),
@Doors int,
@Wheels int,
@VehicleTypeID int = NULL,
@Type varchar(50),
@ImagePath varchar(50)

AS
BEGIN
Declare @TempVehId int, @TempMakeId int, @TempModelId int, @TempEngineId int, @TempVehicleTypeID int
IF(@VehicleID IS NULL)
BEGIN
    BEGIN TRY
	BEGIN TRANSACTION
	 INSERT INTO Vehicle(VehicleType) VALUES(@VehicleType)
	 SET @TempVehId = IDENT_CURRENT('Vehicle') 

	 INSERT INTO Manufacturer(Name,VehicleId) VALUES(@MakeName,@TempVehId)
	 SET @TempMakeId = IDENT_CURRENT('Manufacturer')  

	 INSERT INTO Model(Name,MakeId,VehicleId) Values(@ModelName,@TempMakeId,@TempVehId)
	 SET @TempModelId = IDENT_CURRENT('Model')  

	 INSERT INTO Engine(Name,ModelId) VALUES(@EngineName,@TempModelId)
	 SET @TempEngineId =  IDENT_CURRENT('Engine')

	 IF(@VehicleTypeID IS NULL)
	 BEGIN
	 INSERT INTO VehicleType(VehicleId,Type) VALUES(@TempVehId,@Type)
	 END
	 
	 INSERT INTO VehicleDetails(VehicleTypeId,MakeId,ModelId,EngineId,Doors,Wheels,Type,ImagePath)
	 VALUES(@TempVehId,@TempMakeId,@TempModelId,@TempEngineId,@Doors,@Wheels,@Type,@ImagePath)

	COMMIT TRANSACTION
	END TRY  
	BEGIN CATCH
	ROLLBACK TRANSACTION
	END CATCH
	-- select @TempVehId,@TempMakeId,@TempModelId,@TempEngineId

END
ELSE IF(@VehicleID IS NOT NULL AND @MakeID IS NULL)
BEGIN
    BEGIN TRY
	BEGIN TRANSACTION
     SET @TempVehId = @VehicleID 

	 INSERT INTO Manufacturer(Name,VehicleId) VALUES(@MakeName,@TempVehId)
	 SET @TempMakeId = IDENT_CURRENT('Manufacturer')  

	 INSERT INTO Model(Name,MakeId,VehicleId) Values(@ModelName,@TempMakeId,@TempVehId)
	 SET @TempModelId = IDENT_CURRENT('Model')  

	 INSERT INTO Engine(Name,ModelId) VALUES(@EngineName,@TempModelId)
	 SET @TempEngineId =  IDENT_CURRENT('Engine')

	 IF(@VehicleTypeID IS NULL)
	 BEGIN
	 INSERT INTO VehicleType(VehicleId,Type) VALUES(@TempVehId,@Type)
	 END

	 INSERT INTO VehicleDetails(VehicleTypeId,MakeId,ModelId,EngineId,Doors,Wheels,Type,ImagePath)
	 VALUES(@TempVehId,@TempMakeId,@TempModelId,@TempEngineId,@Doors,@Wheels,@Type,@ImagePath)

	COMMIT TRANSACTION
	END TRY  
	BEGIN CATCH
	ROLLBACK TRANSACTION
	END CATCH
	 --select @TempVehId,@TempMakeId,@TempModelId,@TempEngineId
END
ELSE IF(@VehicleID IS NOT NULL AND @MakeID IS NOT NULL AND @ModelID IS NULL)
BEGIN
    BEGIN TRY
	BEGIN TRANSACTION
     SET @TempVehId = @VehicleID
	 SET @TempMakeId = @MakeID

	 INSERT INTO Model(Name,MakeId,VehicleId) Values(@ModelName,@TempMakeId,@TempVehId)
	 SET @TempModelId = IDENT_CURRENT('Model')  

	 INSERT INTO Engine(Name,ModelId) VALUES(@EngineName,@TempModelId)
	 SET @TempEngineId =  IDENT_CURRENT('Engine')

	 IF(@VehicleTypeID IS NULL)
	 BEGIN
	 INSERT INTO VehicleType(VehicleId,Type) VALUES(@TempVehId,@Type)
	 END

	 INSERT INTO VehicleDetails(VehicleTypeId,MakeId,ModelId,EngineId,Doors,Wheels,Type,ImagePath)
	 VALUES(@TempVehId,@TempMakeId,@TempModelId,@TempEngineId,@Doors,@Wheels,@Type,@ImagePath)

	COMMIT TRANSACTION
	END TRY  
	BEGIN CATCH
	ROLLBACK TRANSACTION
	END CATCH
	 
END
ELSE IF(@VehicleID IS NOT NULL AND @MakeID IS NOT NULL AND @ModelID IS NOT NULL AND @EngineID IS NULL)
BEGIN
    BEGIN TRY
	BEGIN TRANSACTION
     SET @TempVehId = @VehicleID
	 SET @TempMakeId = @MakeID
	 SET @TempModelId = @ModelID 

	 INSERT INTO Engine(Name,ModelId) VALUES(@EngineName,@TempModelId)
	 SET @TempEngineId =  IDENT_CURRENT('Engine')

	 IF(@VehicleTypeID IS NULL)
	 BEGIN
	 INSERT INTO VehicleType(VehicleId,Type) VALUES(@TempVehId,@Type)
	 END

	 INSERT INTO VehicleDetails(VehicleTypeId,MakeId,ModelId,EngineId,Doors,Wheels,Type,ImagePath)
	 VALUES(@TempVehId,@TempMakeId,@TempModelId,@TempEngineId,@Doors,@Wheels,@Type,@ImagePath)

	COMMIT TRANSACTION
	END TRY  
	BEGIN CATCH
	ROLLBACK TRANSACTION
	END CATCH
END
ELSE IF(@VehicleID IS NOT NULL AND @MakeID IS NOT NULL AND @ModelID IS NOT NULL AND @EngineID IS NOT NULL)
BEGIN
    BEGIN TRY
	BEGIN TRANSACTION
     SET @TempVehId = @VehicleID
	 SET @TempMakeId = @MakeID
	 SET @TempModelId = @ModelID
	 SET @TempEngineId = @EngineID

	 IF(@VehicleTypeID IS NULL)
	 BEGIN
	 INSERT INTO VehicleType(VehicleId,Type) VALUES(@TempVehId,@Type)
	 END

	 INSERT INTO VehicleDetails(VehicleTypeId,MakeId,ModelId,EngineId,Doors,Wheels,Type,ImagePath)
	 VALUES(@TempVehId,@TempMakeId,@TempModelId,@TempEngineId,@Doors,@Wheels,@Type,@ImagePath)

	COMMIT TRANSACTION
	END TRY  
	BEGIN CATCH
	ROLLBACK TRANSACTION
	END CATCH
END

END