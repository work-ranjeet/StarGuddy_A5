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

CREATE PROCEDURE GetVarifiedUser (@Email NVARCHAR(256), @Password NVARCHAR(max))
AS
BEGIN
	BEGIN TRY
		SELECT *
		FROM Users
		WHERE Email = @Email
			AND PasswordHash = @Password
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

CREATE PROCEDURE AddNewUser (@AccessFailedCount INT, @ConcurrencyStamp VARCHAR(max),  @Email NVARCHAR(256), @EmailConfirmed BIT, @FirstName NVARCHAR(100), @Gender NVARCHAR(10), @IsCastingProfessional BIT, @LastName NVARCHAR(100), @LockoutEnabled BIT, @LockoutEnd DATETIME, @NormalizedEmail NVARCHAR(256), @NormalizedUserName NVARCHAR(256), @Designation NVARCHAR(150), @OrgName NVARCHAR(150), @OrgWebsite NVARCHAR(150), @PasswordHash NVARCHAR(max), @PhoneNumber NVARCHAR(20), @PhoneNumberConfirmed BIT, @SecurityStamp NVARCHAR(max), @TwoFactorEnabled BIT, @UserName NVARCHAR(256))
AS
BEGIN
	BEGIN TRY
		INSERT INTO Users (AccessFailedCount, ConcurrencyStamp, Email, EmailConfirmed, FirstName, Gender, IsCastingProfessional, LastName, LockoutEnabled, LockoutEnd, NormalizedEmail, NormalizedUserName, Designation, OrgName, OrgWebsite, PasswordHash, PhoneNumber, PhoneNumberConfirmed, SecurityStamp, TwoFactorEnabled, UserName)
		VALUES (@AccessFailedCount, @ConcurrencyStamp, @Email, @EmailConfirmed, @FirstName, @Gender, @IsCastingProfessional, @LastName, @LockoutEnabled, @LockoutEnd, @NormalizedEmail, @NormalizedUserName, @Designation, @OrgName, @OrgWebsite, @PasswordHash, @PhoneNumber, @PhoneNumberConfirmed, @SecurityStamp, @TwoFactorEnabled, @UserName)
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

CREATE PROCEDURE UpdateUser (
	@AccessFailedCount INT, 
	@ConcurrencyStamp VARCHAR(max), 
	@Email NVARCHAR(256), 
	@EmailConfirmed BIT, 
	@FirstName NVARCHAR(100), 
	@Gender NVARCHAR(10), 
	@IsCastingProfessional BIT, 
	@LastName NVARCHAR(100), 
	@LockoutEnabled BIT, 
	@LockoutEnd DATETIME, 
	@NormalizedEmail NVARCHAR(256), 
	@NormalizedUserName NVARCHAR(256), 
	@Designation NVARCHAR(150), 
	@OrgName NVARCHAR(150), 
	@OrgWebsite NVARCHAR(150), 
	@PasswordHash NVARCHAR(max), 
	@PhoneNumber NVARCHAR(20), 
	@PhoneNumberConfirmed BIT, 
	@SecurityStamp NVARCHAR(max), 
	@TwoFactorEnabled BIT, 
	@UserName NVARCHAR(256)
	)
AS
BEGIN
	BEGIN TRY
		Update Users  
		set AccessFailedCount = @AccessFailedCount, 
		ConcurrencyStamp = @ConcurrencyStamp,
		Email = @Email, 
		EmailConfirmed = @EmailConfirmed, 
		FirstName = @FirstName, 
		Gender = @Gender, 
		IsCastingProfessional = @IsCastingProfessional, 
		LastName = @LastName, 
		LockoutEnabled = @LockoutEnabled, 
		LockoutEnd = @LockoutEnd, 
		NormalizedEmail = @NormalizedEmail, 
		NormalizedUserName = @NormalizedUserName, 
		Designation = @Designation, 
		OrgName = @OrgName, 
		OrgWebsite = @OrgWebsite, 
		PasswordHash = @PasswordHash, 
		PhoneNumber = @PhoneNumber, 
		PhoneNumberConfirmed = @PhoneNumberConfirmed, 
		SecurityStamp = @SecurityStamp, 
		TwoFactorEnabled = @TwoFactorEnabled 		
		where UserName = @UserName AND IsActive = 0 AND IsDeleted = 0	
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
