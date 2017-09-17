USE [sample]
GO

/****** Object:  Trigger [dbo].[Trg_Model_ValidMakeForVehicle]    Script Date: 9/15/2017 4:36:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[Trg_Model_ValidMakeForVehicle]
    ON [dbo].[Model]
    INSTEAD OF INSERT
    AS
    BEGIN
	DECLARE @Name VARCHAR(20)
	SET NOCOUNT ON
	IF(NOT EXISTS(SELECT m.Id FROM Manufacturer m INNER JOIN inserted d 
	ON m.Id = d.MakeID and m.VehicleId = d.VehicleId) )
	BEGIN
	SELECT @Name=v.VehicleType from Vehicle v INNER JOIN inserted i on v.Id = i.VehicleId
	RAISERROR('Make Sure given Manufacturer Exists In The Manufacturer Table For Vehicle Type : %s',16,1, @Name)
	END
	ELSE
	INSERT INTO Model SELECT Name, MakeId, VehicleID FROM inserted
    		
    END;
GO


