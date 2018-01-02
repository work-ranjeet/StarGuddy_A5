IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserAddresses')
			AND type IN (N'U')
		)
	DROP TABLE UserAddresses
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Users')
			AND type IN (N'U')
		)
	DROP TABLE Users
GO