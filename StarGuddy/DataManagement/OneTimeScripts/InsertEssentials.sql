--Users
--INSERT into Users ( AccessFailedCount, ConcurrencyStamp, Dob, Email, EmailConfirmed, FirstName, Gender, IsCastingProfessional, LastName, LockoutEnabled, LockoutEnd, NormalizedEmail, NormalizedUserName, Designation, OrgName, OrgWebsite, PasswordHash, PhoneNumber, PhoneNumberConfirmed, SecurityStamp, TwoFactorEnabled, UserName)
--VALUES ( 0, N'b8c6e4a2-fb40-4706-b608-f05a4a6ff708', CAST(0x0700000000006D0D0B AS DATETIME2), N'er.ranjeetkumar@gmail.com', 1, N'Ranjeet', N'M', 0, N'Kumar', 0, NULL, N'ER.RANJEETKUMAR@GMAIL.COM', N'ER.RANJEETKUMAR@GMAIL.COM', NULL, NULL, NULL, N'janeman', N'9535304488', 1, N'39d292dc-8713-4f03-9cfb-90784159f854', 0, N'er.ranjeetkumar@gmail.com')
--Users---------------------
INSERT into Users ( AccessFailedCount, ConcurrencyStamp, FirstName, Gender, IsCastingProfessional, LastName, LockoutEnabled, LockoutEnd, Designation, OrgName, OrgWebsite, PasswordHash, SecurityStamp, IsTwoFactorEnabled, UserName)
VALUES ( 0, N'b8c6e4a2-fb40-4706-b608-f05a4a6ff708', N'Ranjeet', N'M', 0, N'Kumar', 0, NULL, NULL, NULL, NULL, N'janeman', N'39d292dc-8713-4f03-9cfb-90784159f854', 0, N'er.ranjeetkumar@gmail.com')


INSERT INTO AgentNeed(Code, [Type], [Description]) VALUES (0,'I don''t have an agent', 'No need of agent')
INSERT INTO AgentNeed(Code, [Type], [Description]) VALUES (1,'I want an agent', 'I want an agent')
INSERT INTO AgentNeed(Code, [Type], [Description]) VALUES (2,'I have an agent', 'I have an agent')

INSERT INTO DancingStyle (Style, Detail) VALUES('Ballet','Ballet')
INSERT INTO DancingStyle (Style, Detail) VALUES('Bollywood','Bollywood')
INSERT INTO DancingStyle (Style, Detail) VALUES('Country','Country')
INSERT INTO DancingStyle (Style, Detail) VALUES('Hip Hop','Hip Hop')


INSERT INTO ExpertLavel(Code, Lavel, Detail) VALUES (1,'Beginner', 'Beginner')
INSERT INTO ExpertLavel(Code, Lavel, Detail) VALUES (2,'Intermediate', 'Intermediate')
INSERT INTO ExpertLavel(Code, Lavel, Detail) VALUES (3,'Expert', 'Expert')

---------------------------------------------ActingExperience-----------------------------------------------------------------------------------
INSERT INTO ActingExperience (Name, Code, Detail, DisplayOrder) values('No previous acting experience',200,'No previous acting experience', 1)
INSERT INTO ActingExperience (Name, Code, Detail, DisplayOrder) values('Credits',201,'Credits', 2)
INSERT INTO ActingExperience (Name, Code, Detail, DisplayOrder) values('Previous unpaid speaking roles',203,'Previous unpaid speaking roles', 3)
INSERT INTO ActingExperience (Name, Code, Detail, DisplayOrder) values('Previous paid speaking roles',204,'Previous paid speaking roles', 4)

---------------------------------------------AuditionsAndJobs--------------------------------------------------------------------
INSERT INTO AuditionsAndJobsGroup (Name, Code, Detail, DisplayOrder) values('Agency Scouts',101,'Agency Scouts', 1)
INSERT INTO AuditionsAndJobsGroup (Name, Code, Detail, DisplayOrder) values('Entertainers',102,'Entertainers', 2)
INSERT INTO AuditionsAndJobsGroup (Name, Code, Detail, DisplayOrder) values('Events & Promotions',103,'Events & Promotions', 3)
INSERT INTO AuditionsAndJobsGroup (Name, Code, Detail, DisplayOrder) values('Feature Films',104,'Feature Films', 4)
INSERT INTO AuditionsAndJobsGroup (Name, Code, Detail, DisplayOrder) values('Music videos',105,'Music videos', 5)
INSERT INTO AuditionsAndJobsGroup (Name, Code, Detail, DisplayOrder) values('Presenters',106,'Presenters', 6)
INSERT INTO AuditionsAndJobsGroup (Name, Code, Detail, DisplayOrder) values('Short Films',107,'Short Films',7)
INSERT INTO AuditionsAndJobsGroup (Name, Code, Detail, DisplayOrder) values('Theater & Musicals',108,'Theater & Musicals', 8)
INSERT INTO AuditionsAndJobsGroup (Name, Code, Detail, DisplayOrder) values('TV commercials',109,'TV commercials',9)
INSERT INTO AuditionsAndJobsGroup (Name, Code, Detail, DisplayOrder) values(' TV Series',110,' TV Series', 10)
INSERT INTO AuditionsAndJobsGroup (Name, Code, Detail, DisplayOrder) values('Voice-over & Radio',111,'Voice-over & Radio', 11)
INSERT INTO AuditionsAndJobsGroup (Name, Code, Detail, DisplayOrder) values('Web',112,'Web', 12)
INSERT INTO AuditionsAndJobsGroup (Name, Code, Detail, DisplayOrder) values('Others',113,'Others', 13)

----------
insert into UserAuditionsAndJobsGroup values (NEWID(), 1, 'D40B2C5D-2881-4E8B-844A-B503DEB090BE', GETUTCDATE(), GETUTCDATE())
insert into UserAuditionsAndJobsGroup values (NEWID(), 2, 'D40B2C5D-2881-4E8B-844A-B503DEB090BE', GETUTCDATE(), GETUTCDATE())
insert into UserAuditionsAndJobsGroup values (NEWID(), 3, 'D40B2C5D-2881-4E8B-844A-B503DEB090BE', GETUTCDATE(), GETUTCDATE())
insert into UserAuditionsAndJobsGroup values (NEWID(), 4, 'D40B2C5D-2881-4E8B-844A-B503DEB090BE', GETUTCDATE(), GETUTCDATE())
insert into UserAuditionsAndJobsGroup values (NEWID(), 5, 'D40B2C5D-2881-4E8B-844A-B503DEB090BE', GETUTCDATE(), GETUTCDATE())

----------------------------------------Languages--------------------------------------------------------------------------------------
INSERT INTO Languages (Name, Code, CountryCode) values('English',1001,'')
INSERT INTO Languages (Name, Code, CountryCode) values('Hindi',1002,'')
INSERT INTO Languages (Name, Code, CountryCode) values('Urdu',1003,'')

--------------------------------------Accents----------------------------------------
INSERT INTO Accents (Name, Code, LanguageCode) values('Indian',2000,'')
INSERT INTO Accents (Name, Code, LanguageCode) values('German',2001,'')
INSERT INTO Accents (Name, Code, LanguageCode) values('French',2002,'')
INSERT INTO Accents (Name, Code, LanguageCode) values('Magahi',2003,'')