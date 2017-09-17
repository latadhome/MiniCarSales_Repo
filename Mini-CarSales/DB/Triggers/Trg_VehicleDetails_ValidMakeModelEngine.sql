USE [sample]
GO

/****** Object:  Trigger [dbo].[Trg_Model_ValidMakeForVehicle]    Script Date: 9/15/2017 4:36:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[Trg_VehicleDetails_ValidMakeModelEngine]
    ON [dbo].[VehicleDetails]
    INSTEAD OF INSERT
    AS
    BEGIN
	DECLARE @VehicleID INT, @MakeID INT,@ModelID INT, @EngineID INT, @Name VARCHAR(20)
	SET NOCOUNT ON

	SELECT @VehicleID=ins.VehicleTypeId, @MakeID=ins.MakeId, @ModelID=ins.ModelId, @EngineID=ins.EngineId FROM inserted ins

	IF(NOT EXISTS(SELECT mo.VehicleId, mo.MakeId,mo.Id, e.Id FROM Engine e 
                  INNER JOIN Model mo
                  ON  e.ModelId = mo.Id 
                  INNER JOIN Manufacturer man 
                  ON man.Id = mo.MakeId AND mo.VehicleId = man.VehicleId
				  where  mo.VehicleId=@VehicleID AND man.Id = @MakeID AND mo.Id = @ModelID AND  e.Id = @EngineID ) )
	BEGIN
	SELECT @VehicleID,@MakeID,@ModelID,@EngineID
	SELECT @Name=v.VehicleType from Vehicle v where v.Id = @VehicleID
	RAISERROR(' Not Valid Combination Of Manufacturer,Model and Engine For Vehicle Type : %s',16,1, @Name)
	END
	ELSE
	INSERT INTO VehicleDetails SELECT VehicleTypeId,MakeId,ModelId,EngineId,Doors,Wheels,Type,ImagePath FROM inserted
    --select 1		
    END;
GO


