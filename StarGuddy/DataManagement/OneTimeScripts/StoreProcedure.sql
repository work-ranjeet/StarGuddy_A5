IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'GetVarifiedUser')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE GetVarifiedUser
GO

CREATE PROCEDURE GetVarifiedUser (@UserName NVARCHAR(256), @Password NVARCHAR(max))
AS
BEGIN
	BEGIN TRY
		SELECT *
		FROM Users
		WHERE UserName = @UserName
			AND PasswordHash = @Password
			AND IsActive = 1
			ANd IsDeleted = 0
	END TRY

	BEGIN CATCH
		--INSERT INTO ErrorLog (
		--	ErrorType,
		--	ErrorName,
		--	CustomMesage,
		--	ErrorNumber,
		--	ErrorMessage
		--	)
		--VALUES (
		--	1,
		--	'Select20InterNews',
		--	'Error from Select20InterNews Store Procedure',
		--	ERROR_NUMBER(),
		--	ERROR_MESSAGE()
		--	)
	END CATCH
END
	--EXEC GetVarifiedUser 'er.ranjeetkumar@gmail.com' , 'janeman'
	------------------------------------------- Save User Address ---------------------------------------
GO

----------------------------------------- User table -----------------------------------------------
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'AddNewUser')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE AddNewUser
GO

CREATE PROCEDURE AddNewUser (@AccessFailedCount INT, @ConcurrencyStamp VARCHAR(max), @Email NVARCHAR(256), @FirstName NVARCHAR(100), @Gender NVARCHAR(10), @IsCastingProfessional BIT, @LastName NVARCHAR(100), @LockoutEnabled BIT, @LockoutEnd DATETIME, @Designation NVARCHAR(150), @OrgName NVARCHAR(150), @OrgWebsite NVARCHAR(150), @PasswordHash NVARCHAR(max), @SecurityStamp NVARCHAR(max), @IsTwoFactorEnabled BIT, @UserName NVARCHAR(256))
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			DECLARE @userId UNIQUEIDENTIFIER;
			SELECT @userId = NEWID();
			INSERT INTO Users (Id, UserName, AccessFailedCount, ConcurrencyStamp, FirstName, Gender, IsCastingProfessional, LastName, LockoutEnabled, LockoutEnd, Designation, OrgName, OrgWebsite, PasswordHash, SecurityStamp, IsTwoFactorEnabled)
			VALUES (@userId, @UserName, @AccessFailedCount, @ConcurrencyStamp, @FirstName, @Gender, @IsCastingProfessional, @LastName, @LockoutEnabled, @LockoutEnd, @Designation, @OrgName, @OrgWebsite, @PasswordHash, @SecurityStamp, @IsTwoFactorEnabled)
	
			INSERT INTO UserEmails(UserId, Email, EmailConfirmed, IsActive, IsDeleted)
			VALUES (@userId, @Email, 0, 1, 0)
		COMMIT TRAN
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
			--INSERT INTO ErrorLog (
			--	ErrorType,
			--	ErrorName,
			--	CustomMesage,
			--	ErrorNumber,
			--	ErrorMessage
			--	)
			--VALUES (
			--	1,
			--	'Select20InterNews',
			--	'Error from Select20InterNews Store Procedure',
			--	ERROR_NUMBER(),
			--	ERROR_MESSAGE()
			--	)
	END CATCH
END
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UpdateUser')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE UpdateUser
GO

CREATE PROCEDURE UpdateUser (@IsActive BIT, @IsDeleted BIT, @AccessFailedCount INT, @ConcurrencyStamp VARCHAR(max), @FirstName NVARCHAR(100), @Gender NVARCHAR(10), @IsCastingProfessional BIT, @LastName NVARCHAR(100), @LockoutEnabled BIT, @LockoutEnd DATETIME, @Designation NVARCHAR(150), @OrgName NVARCHAR(150), @OrgWebsite NVARCHAR(150), @PasswordHash NVARCHAR(max), @SecurityStamp NVARCHAR(max), @IsTwoFactorEnabled BIT, @UserName NVARCHAR(256))
AS
BEGIN
	BEGIN TRY
		UPDATE Users
		SET IsActive =  @IsActive, IsDeleted = @IsDeleted, AccessFailedCount = @AccessFailedCount, ConcurrencyStamp = @ConcurrencyStamp, FirstName = @FirstName, Gender = @Gender, IsCastingProfessional = @IsCastingProfessional, LastName = @LastName, LockoutEnabled = @LockoutEnabled, LockoutEnd = @LockoutEnd, Designation = @Designation, OrgName = @OrgName, OrgWebsite = @OrgWebsite, PasswordHash = @PasswordHash, SecurityStamp = @SecurityStamp, IsTwoFactorEnabled = @IsTwoFactorEnabled
		WHERE UserName = @UserName
	END TRY

	BEGIN CATCH
		--INSERT INTO ErrorLog (
		--	ErrorType,
		--	ErrorName,
		--	CustomMesage,
		--	ErrorNumber,
		--	ErrorMessage
		--	)
		--VALUES (
		--	1,
		--	'Select20InterNews',
		--	'Error from Select20InterNews Store Procedure',
		--	ERROR_NUMBER(),
		--	ERROR_MESSAGE()
		--	)
	END CATCH
END
	-------------------------------------------------------------------- End User Table ----------------------------------------------------------------------------------
