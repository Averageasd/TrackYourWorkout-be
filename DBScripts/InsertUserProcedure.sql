IF OBJECT_ID ( 'Insert_User', 'P' ) IS NOT NULL
    DROP PROCEDURE Insert_User;
GO


CREATE OR ALTER PROCEDURE Insert_User
	@Name VARCHAR(30),
	@Password VARCHAR(30)
AS
	INSERT INTO WorkoutUser (Name, Password) VALUES
	(@Name, @Password)

	 