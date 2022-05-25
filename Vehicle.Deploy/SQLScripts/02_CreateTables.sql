USE [Vehicle]
GO

BEGIN
	BEGIN TRY  
		BEGIN TRANSACTION

		--User table creation
		PRINT 'Vehicle'
		if not exists (select * from sysobjects where name='Vehicle' and xtype='U')
		BEGIN
			--Create table
			CREATE TABLE [dbo].[Vehicle](
				Id					int				NOT NULL	IDENTITY,
				VIN					nvarchar(100)	NOT NULL,
			)
			
			PRINT '	Table "Vehicle" has been created'

			--Add Primary Key
			ALTER TABLE [dbo].[Vehicle]
				ADD CONSTRAINT PK_VehicleId PRIMARY KEY NONCLUSTERED (Id);

			PRINT '	"PK_VehicleId" PK added to "[dbo].[Vehicle]"'

		END
		ELSE
		BEGIN
			PRINT '	Table "[Vehicle]" already exists'
		END

		--Record table creation
		PRINT 'Record'
		if not exists (select * from sysobjects where name='Record' and xtype='U')
		BEGIN

			--Create table
			CREATE TABLE [dbo].[Record](
				Id						int				NOT NULL	IDENTITY,
				VehicleId				int				NOT NULL,
				Latitude				decimal(8,6)	NOT NULL,
				Longitude				decimal(9,6)	NOT NULL,
				Speed					int				NOT NULL,
				Timestamp				datetime		NOT NULL
			)
			PRINT '	"Record" Table has been created'

			--Add Primary Key
			ALTER TABLE [dbo].[Record]
				ADD CONSTRAINT PK_RecordId PRIMARY KEY NONCLUSTERED (Id);

			PRINT '	"PK_RecordId" PK added to "[dbo].[Record]"'

			--Create Foreign Key to [Vehicle]
			ALTER TABLE [dbo].[Record]
				ADD CONSTRAINT FK_Record_Vehicle FOREIGN KEY (VehicleId)
				REFERENCES [dbo].[Vehicle] (Id)

			PRINT '	"FK_Record_Vehicle" Foreign Key Added'

		END
		ELSE
		BEGIN
			PRINT 'Table "Record" already exists'
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		PRINT ERROR_MESSAGE()
	END CATCH
END;
