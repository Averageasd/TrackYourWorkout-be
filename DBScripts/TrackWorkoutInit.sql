IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'trackworkout_db')
BEGIN
	CREATE DATABASE trackworkout_db
END
GO

USE trackworkout_db
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='WorkoutUser' and xtype='U')
BEGIN
    CREATE TABLE WorkoutUser (
        Id UNIQUEIDENTIFIER NOT NULL DEFAULT NewID(),
        Name VARCHAR(30) UNIQUE,
		Password VARCHAR(30),
		RefreshToken TEXT,
		RefreshTokenExpiryTime DATETIME,
    )
END


