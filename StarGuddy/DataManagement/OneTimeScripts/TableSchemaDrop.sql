
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
		WHERE object_id = OBJECT_ID(N'UserAccent')
			AND type IN (N'U')
		)
	DROP TABLE UserAccent
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