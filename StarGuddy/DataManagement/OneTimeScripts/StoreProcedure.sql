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
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UpdateEmail')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE UpdateEmail
GO
CREATE PROCEDURE UpdateEmail (@UserId UNIQUEIDENTIFIER, @UserEmail NVARCHAR(256))
AS
BEGIN
	BEGIN TRY
		DECLARE @id UNIQUEIDENTIFIER

		SELECT @id = id FROM UserEmails WHERE UserId = @UserId AND IsActive = 1 AND IsDeleted = 0 
		UPDATE UserEmails SET IsActive = 0, IsDeleted = 0 WHERE id = @id
		INSERT INTO UserEmails (UserId, Email) VALUES (@UserId, @UserEmail)
	END TRY

	BEGIN CATCH
		
	END CATCH
END
GO
	-------------------------------------------------------------------- End UpdateEmail ----------------------------------------------------------------------------------
	-------------------------------------------------------------------- PhysicalAppreance --------------------------------------------------------------------------------
	IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'PhysicalAppearanceSave')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE PhysicalAppearanceSave
GO
CREATE PROCEDURE PhysicalAppearanceSave (@UserId AS UNIQUEIDENTIFIER, @BodyType AS INT, @Chest AS INT, @EyeColor AS INT, @HairColor AS INT, @HairLength AS INT, @HairType AS INT, @SkinColor AS INT, @Height AS INT, @Weight AS INT, @West AS INT, @Ethnicity NVARCHAR(500))
AS
BEGIN
	INSERT INTO PhysicalAppearance (UserId, BodyType, Chest, EyeColor, HairColor, HairLength, HairType, SkinColor, Height, [Weight], West, Ethnicity)
	VALUES (@UserId, @BodyType, @Chest, @EyeColor, @HairColor, @HairLength, @HairType, @SkinColor, @Height, @Weight, @West, @Ethnicity)
END
GO
-------------------------------------
	IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'PhysicalAppearanceUpdate')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE PhysicalAppearanceUpdate
GO
CREATE PROCEDURE PhysicalAppearanceUpdate (@UserId AS UNIQUEIDENTIFIER, @BodyType AS INT, @Chest AS INT, @EyeColor AS INT, @HairColor AS INT, @HairLength AS INT, @HairType AS INT, @SkinColor AS INT, @Height AS INT, @Weight AS INT, @West AS INT, @IsActive AS BIT, @IsDeleted AS BIT, @DttmModified AS DATETIME2)
AS
BEGIN
	UPDATE PhysicalAppearance
	SET BodyType = @BodyType, Chest = @Chest, EyeColor = @EyeColor, HairColor = @HairColor, HairLength = @HairLength, HairType = @HairType, SkinColor = @SkinColor, Height = @Height, [Weight] = @Weight, West = @West, IsActive = @IsActive, IsDeleted = @IsDeleted, DttmModified = @DttmModified
	WHERE UserId = @UserId
END
	-------------------------------------------------------------------- End PhysicalAppreance ----------------------------------------------------------------------------
