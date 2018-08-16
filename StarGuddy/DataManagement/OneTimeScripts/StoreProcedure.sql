IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'GetVarifiedUser') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE GetVarifiedUser
GO

CREATE PROCEDURE GetVarifiedUser (@UserName NVARCHAR(256), @Password NVARCHAR(max))
AS
BEGIN
	BEGIN TRY
		SELECT *
		FROM Users
		WHERE UserName = @UserName AND PasswordHash = @Password AND IsActive = 1 AND IsDeleted = 0
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
		WHERE object_id = OBJECT_ID(N'AddNewUser') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE AddNewUser
GO

CREATE PROCEDURE AddNewUser (@AccessFailedCount INT, @ConcurrencyStamp VARCHAR(max), @Email NVARCHAR(256), @FirstName NVARCHAR(100), @Gender NVARCHAR(10), @IsCastingProfessional BIT, @LastName NVARCHAR(100), @LockoutEnabled BIT, @LockoutEnd DATETIME, @Designation NVARCHAR(150), @OrgName NVARCHAR(150), @OrgWebsite NVARCHAR(150), @PasswordHash NVARCHAR(max), @SecurityStamp NVARCHAR(max), @IsTwoFactorEnabled BIT, @UserName NVARCHAR(256))
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

		DECLARE @userId UNIQUEIDENTIFIER;

		SELECT @userId = NEWID();

		INSERT INTO Users (Id, UserName, AccessFailedCount, ConcurrencyStamp, FirstName, Gender, IsCastingProfessional, LastName, LockoutEnabled, LockoutEnd, Designation, OrgName, OrgWebsite, PasswordHash, SecurityStamp, IsTwoFactorEnabled)
		VALUES (@userId, @UserName, @AccessFailedCount, @ConcurrencyStamp, @FirstName, @Gender, @IsCastingProfessional, @LastName, @LockoutEnabled, @LockoutEnd, @Designation, @OrgName, @OrgWebsite, @PasswordHash, @SecurityStamp, @IsTwoFactorEnabled)

		INSERT INTO UserEmails (UserId, Email, EmailConfirmed, IsActive, IsDeleted)
		VALUES (@userId, @Email, 0, 1, 0)

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION
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
		WHERE object_id = OBJECT_ID(N'UpdateUser') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UpdateUser
GO

CREATE PROCEDURE UpdateUser (@IsActive BIT, @IsDeleted BIT, @AccessFailedCount INT, @ConcurrencyStamp VARCHAR(max), @FirstName NVARCHAR(100), @Gender NVARCHAR(10), @IsCastingProfessional BIT, @LastName NVARCHAR(100), @LockoutEnabled BIT, @LockoutEnd DATETIME, @Designation NVARCHAR(150), @OrgName NVARCHAR(150), @OrgWebsite NVARCHAR(150), @PasswordHash NVARCHAR(max), @SecurityStamp NVARCHAR(max), @IsTwoFactorEnabled BIT, @UserName NVARCHAR(256))
AS
BEGIN
	BEGIN TRY
		UPDATE Users
		SET IsActive = @IsActive, IsDeleted = @IsDeleted, AccessFailedCount = @AccessFailedCount, ConcurrencyStamp = @ConcurrencyStamp, FirstName = @FirstName, Gender = @Gender, IsCastingProfessional = @IsCastingProfessional, LastName = @LastName, LockoutEnabled = @LockoutEnabled, LockoutEnd = @LockoutEnd, Designation = @Designation, OrgName = @OrgName, OrgWebsite = @OrgWebsite, PasswordHash = @PasswordHash, SecurityStamp = @SecurityStamp, IsTwoFactorEnabled = @IsTwoFactorEnabled
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
		WHERE object_id = OBJECT_ID(N'UpdateEmail') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UpdateEmail
GO

CREATE PROCEDURE UpdateEmail (@UserId UNIQUEIDENTIFIER, @UserEmail NVARCHAR(256))
AS
BEGIN
	BEGIN TRY
		DECLARE @id UNIQUEIDENTIFIER

		SELECT @id = id
		FROM UserEmails
		WHERE UserId = @UserId AND IsActive = 1 AND IsDeleted = 0

		UPDATE UserEmails
		SET IsActive = 0, IsDeleted = 0
		WHERE id = @id

		INSERT INTO UserEmails (UserId, Email)
		VALUES (@UserId, @UserEmail)
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
		WHERE object_id = OBJECT_ID(N'PhysicalAppearanceSaveUpdate') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE PhysicalAppearanceSaveUpdate
GO

CREATE PROCEDURE [PhysicalAppearanceSaveUpdate] (@UserId UNIQUEIDENTIFIER, @BodyType AS INT, @Chest AS INT, @EyeColor AS INT, @HairColor AS INT, @HairLength AS INT, @HairType AS INT, @SkinColor AS INT, @Height AS INT, @Weight AS INT, @West AS INT, @Ethnicity NVARCHAR(500))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF (
			EXISTS (
				SELECT TOP 1 Id
				FROM PhysicalAppearance
				WHERE UserId = @UserId AND IsActive = 1 AND IsDeleted = 0
				)
			)
	BEGIN
		UPDATE PhysicalAppearance
		SET BodyType = @BodyType, Chest = @Chest, EyeColor = @EyeColor, HairColor = @HairColor, HairLength = @HairLength, HairType = @HairType, SkinColor = @SkinColor, Height = @Height, [Weight] = @Weight, West = @West, Ethnicity = @Ethnicity, IsActive = 1, IsDeleted = 0, DttmModified = getutcdate()
		WHERE UserId = @UserId
	END
	ELSE
	BEGIN
		INSERT INTO PhysicalAppearance (UserId, BodyType, Chest, EyeColor, HairColor, HairLength, HairType, SkinColor, Height, [Weight], West, Ethnicity, IsActive, IsDeleted)
		VALUES (@UserId, @BodyType, @Chest, @EyeColor, @HairColor, @HairLength, @HairType, @SkinColor, @Height, @Weight, @West, @Ethnicity, 1, 0)
	END
END
GO

-------------------------------------------------------------------- End PhysicalAppreance ----------------------------------------------------------------------------
-------------------------------------------------------------------- Credits --------------------------------------------------------------------------------
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserCreditsSaveUpdate') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserCreditsSaveUpdate
GO

CREATE PROCEDURE UserCreditsSaveUpdate (@UserId UNIQUEIDENTIFIER, @Year INT, @WorkPlace NVARCHAR(150), @WorkDetail NVARCHAR(300))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF (
			EXISTS (
				SELECT TOP 1 Id
				FROM UserCredits
				WHERE UserId = @UserId AND [Year] = @Year AND IsActive = 1 AND IsDeleted = 0
				)
			)
	BEGIN
		UPDATE UserCredits
		SET [Year] = @Year, workPlace = @WorkPlace, WorkDetail = @WorkDetail, IsActive = 1, IsDeleted = 0, DttmModified = getutcdate()
		WHERE UserId = @UserId AND [Year] = @Year
	END
	ELSE
	BEGIN
		INSERT INTO UserCredits (UserId, [Year], workPlace, WorkDetail, IsActive, IsDeleted)
		VALUES (@UserId, @Year, @WorkPlace, @WorkDetail, 1, 0)
	END
END
GO

--------------------------------------------------------------------- Dancing -------------------------------------------------
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserDancingStyleSave') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserDancingStyleSave
GO

CREATE PROCEDURE UserDancingStyleSave (@UserDancingId UNIQUEIDENTIFIER, @DancingStyleId BIGINT)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	INSERT INTO UserDancingStyle (Id, UserDancingId, DancingStyleId)
	VALUES (newID(), @UserDancingId, @DancingStyleId)
END
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserDancingSaveUpdate') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserDancingSaveUpdate
GO

CREATE PROCEDURE UserDancingSaveUpdate (@UserId UNIQUEIDENTIFIER, @DanceAbilitiesCode INT = 1, @ChoreographyAbilitiesCode INT = 1, @AgentNeedCode INT = 1, @IsAttendedSchool BIT = 0, @IsAgent BIT = 0, @Experiance NVARCHAR(2000), @UserDancingId UNIQUEIDENTIFIER OUTPUT)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF (
			EXISTS (
				SELECT TOP 1 Id
				FROM UserDancing
				WHERE UserId = @UserId AND IsActive = 1 AND IsDeleted = 0
				)
			)
	BEGIN
		SET @UserDancingId = (
				SELECT Id
				FROM UserDancing
				WHERE UserId = @UserId AND IsActive = 1 AND IsDeleted = 0
				)

		UPDATE UserDancing
		SET DanceAbilitiesCode = @DanceAbilitiesCode, ChoreographyAbilitiesCode = @ChoreographyAbilitiesCode, AgentNeedCode = @AgentNeedCode, IsAttendedSchool = @IsAttendedSchool, IsAgent = @IsAgent, Experiance = @Experiance, DttmModified = getutcdate()
		WHERE id = @UserDancingId
	END
	ELSE
	BEGIN
		SET @UserDancingId = NEWID()

		INSERT INTO UserDancing (Id, UserId, DanceAbilitiesCode, ChoreographyAbilitiesCode, AgentNeedCode, IsAttendedSchool, IsAgent, Experiance, IsActive, IsDeleted, DttmCreated, DttmModified)
		VALUES (@UserDancingId, @UserId, @DanceAbilitiesCode, @ChoreographyAbilitiesCode, @AgentNeedCode, @IsAttendedSchool, @IsAgent, @Experiance, 1, 0, getutcdate(), getutcdate())
	END
END
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'DancingStyleSelect') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE DancingStyleSelect
GO

CREATE PROCEDURE DancingStyleSelect (@UserId UNIQUEIDENTIFIER)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @userDancingId UNIQUEIDENTIFIER

	SELECT @userDancingId = Id
	FROM UserDancing
	WHERE UserId = @UserId AND IsActive = 1 AND IsDeleted = 0

	SELECT DS.Id, DS.Id AS Value, DS.Style, COALESCE(UDS.DancingStyleId, 0) AS SelectedValue
	FROM DancingStyle DS
	LEFT JOIN UserDancingStyle UDS ON UDS.DancingStyleId = DS.Id
	LEFT JOIN UserDancing UD ON UD.Id = UDS.UserDancingId AND Ud.IsActive = 1 AND UD.IsDeleted = 0 AND UD.UserId = @userDancingId AND UD.IsActive = 1 AND UD.IsDeleted = 0
	WHERE DS.IsActive = 1 AND DS.IsDeleted = 0
END
GO


----------------------------------------------------------------------User Acting -----------------------------------------------------------------------
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'GetUserActingDetail') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE GetUserActingDetail
GO

CREATE PROCEDURE GetUserActingDetail (@UserId UNIQUEIDENTIFIER)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	--EXEC GetUserActingDetail 'D40B2C5D-2881-4E8B-844A-B503DEB090BE'
	SELECT UA.Id, UA.UserId, AE.Code AS ActingExperianceCode, AE.Name AS ActingExperiance, AN.Code AS AgentNeedCode, AN.[Type] AS AgentNeed, UA.Experiance, UA.IsActive, UA.IsDeleted, UA.DttmCreated, UA.DttmModified
	FROM UserActing UA
	LEFT JOIN ActingExperience AE ON AE.Code = UA.ActingExperiance AND AE.IsActive = 1 AND AE.IsDeleted = 0
	LEFT JOIN AgentNeed AN ON AN.Code = UA.AgentNeedCode AND AN.IsActive = 1 AND AN.IsDeleted = 0
	WHERE UA.UserId = @UserId AND UA.IsActive = 1 AND UA.IsDeleted = 0

	SELECT LAN.Id, LAN.Code, LAN.CountryCode, LAN.Name, (CASE WHEN LAN.Id = UL.LanguagesId THEN LAN.Code ELSE '' END) AS SelectedLanguageCode
	FROM Languages LAN
	LEFT JOIN UserLanguage UL ON UL.LanguagesId = LAN.Id AND UL.UserId = @UserId
	WHERE LAN.IsActive = 1 AND LAN.IsDeleted = 0

	SELECT ACC.Id, ACC.Code, ACC.Name, ACC.LanguageCode, (CASE WHEN ACC.Id = UACC.AccentsId THEN ACC.Code ELSE '' END) AS SelectedAccent
	FROM Accents ACC
	LEFT JOIN UserAccents UACC ON UACC.AccentsId = ACC.Id AND UACC.UserId = @UserId
	WHERE ACC.IsActive = 1 AND ACC.IsDeleted = 0

	SELECT JOB.Id, JOB.Code, JOB.Name, (CASE WHEN JOB.Id = UJOB.JobId THEN JOB.Code ELSE 0 END) AS SelectedCode
	FROM AuditionsAndJobsGroup JOB
	LEFT JOIN UserAuditionsAndJobsGroup UJOB ON UJOB.JobId = JOB.Id AND UJOB.UserId = @UserId
	WHERE JOB.IsActive = 1 AND JOB.IsDeleted = 0
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserActingSaveUpdate') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserActingSaveUpdate
GO
CREATE PROCEDURE UserActingSaveUpdate (@UserId UNIQUEIDENTIFIER, @ActingExpCode INT, @AgentNeedCode INT, @Experiance NVARCHAR(2000))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF (EXISTS (SELECT TOP 1 Id	FROM UserActing WHERE UserId = @UserId AND IsActive = 1 AND IsDeleted = 0))
	BEGIN
		UPDATE UserActing
		SET ActingExperiance = @ActingExpCode, AgentNeedCode =@AgentNeedCode, Experiance = @Experiance, IsActive = 1, IsDeleted = 0, DttmModified = getutcdate()
		WHERE UserId = @UserId 
	END
	ELSE
	BEGIN
		INSERT INTO UserActing (Id, UserId, ActingExperiance, AgentNeedCode, Experiance, IsActive, IsDeleted)
		VALUES (NEWID(), @UserId, @ActingExpCode, @AgentNeedCode, @Experiance, 1, 0)
	END
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserActingClear') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserActingClear
GO
CREATE PROCEDURE UserActingClear (@UserId UNIQUEIDENTIFIER)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DELETE FROM  UserLanguage WHERE UserId = @UserId
	DELETE FROM  UserAccents WHERE UserId = @UserId
	DELETE FROM  UserAuditionsAndJobsGroup WHERE UserId = @UserId
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserLanguageSave') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserLanguageSave
GO
CREATE PROCEDURE UserLanguageSave (@UserId UNIQUEIDENTIFIER , @LanguageCode NVARCHAR(100))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @LanguageId BIGINT
	SELECT @LanguageId = Id FROM Languages where Code = @LanguageCode

	INSERT INTO UserLanguage(Id, UserId, LanguagesId, DttmCreated, DttmModified)
	VALUES (NEWID(), @UserId, @LanguageId, getutcdate(), getutcdate())
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserAccentSave') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserAccentSave
GO
CREATE PROCEDURE UserAccentSave (@UserId UNIQUEIDENTIFIER , @AccentCode NVARCHAR(100))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @AccentId BIGINT
	SELECT @AccentId = Id FROM Accents where Code = @AccentCode

	INSERT INTO UserAccents(Id, UserId, AccentsId, IsActive, IsDeleted, DttmCreated, DttmModified)
	VALUES (NEWID(), @UserId, @AccentId, 1, 0, getutcdate(), getutcdate())
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserAuditionsAndJobsGroupSave') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserAuditionsAndJobsGroupSave
GO
CREATE PROCEDURE UserAuditionsAndJobsGroupSave (@UserId UNIQUEIDENTIFIER , @JobCode INT)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @Id BIGINT
	SELECT @Id = Id FROM AuditionsAndJobsGroup where Code = @JobCode AND IsActive = 1 AND IsDeleted = 0

	INSERT INTO UserAuditionsAndJobsGroup(Id, UserId, JobId, DttmCreated, DttmModified)
	VALUES (NEWID(), @UserId, @Id, getutcdate(), getutcdate())
END