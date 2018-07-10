
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserCredits')
			AND type IN (N'U')
		)
	DROP TABLE UserCredits
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserSettings')
			AND type IN (N'U')
		)
	DROP TABLE UserSettings
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserEmails')
			AND type IN (N'U')
		)
	DROP TABLE UserEmails
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserPhones')
			AND type IN (N'U')
		)
	DROP TABLE UserPhones
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserSocialAddress')
			AND type IN (N'U')
		)
	DROP TABLE UserSocialAddress
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SocialAddress')
			AND type IN (N'U')
		)
	DROP TABLE SocialAddress
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserLanguage')
			AND type IN (N'U')
		)
	DROP TABLE UserLanguage
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Languages')
			AND type IN (N'U')
		)
	DROP TABLE Languages
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserAccents')
			AND type IN (N'U')
		)
	DROP TABLE UserAccents
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Accents')
			AND type IN (N'U')
		)
	DROP TABLE Accents
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'PhysicalAppearance')
			AND type IN (N'U')
		)
	DROP TABLE PhysicalAppearance
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserDetail')
			AND type IN (N'U')
		)
	DROP TABLE UserDetail
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserAddress')
			AND type IN (N'U')
		)
	DROP TABLE UserAddress
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Users')
			AND type IN (N'U')
		)
	DROP TABLE Users
GO