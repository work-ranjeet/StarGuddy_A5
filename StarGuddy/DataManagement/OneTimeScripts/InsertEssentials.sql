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