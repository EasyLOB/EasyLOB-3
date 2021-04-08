
/*
DELETE FROM AspNetUserRoles
DELETE FROM AspNetUsers
DELETE FROM AspNetRoles
*/

--------------------------------------------------------------------------------

-- AspNetRoles

INSERT INTO AspNetRoles
	(Id, Name, Discriminator)
	VALUES
	('7698dd46-3905-4869-8d10-0428b70c5af7', 'Administrators', 'ApplicationRole')
INSERT INTO AspNetRoles
	(Id, Name, Discriminator)
	VALUES
	('2f6635db-4e44-4228-bd03-c31c830caad3', 'Users', 'ApplicationRole')

-- AspNetUsers

-- administrator / administrator@gmail.com / P@ssw0rd
INSERT INTO AspNetUsers
	(Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName)
	VALUES
	(NEWID(), 'administrator@gmail.com', 1, 'AHWnRIT3YsO2xsSg2bVVyohuOJxv3k9lYBEPxFCt8ohJ83Y9Nop7+xptCHk8Dcnrwg==', '76f53491-f82c-41da-a8d2-7c3c17ddd09e', NULL, 0, 0, NULL, 0, 0, 'administrator')
-- user / user@gmail.com / P@ssw0rd
INSERT INTO AspNetUsers
	(Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName)
	VALUES
	(NEWID(), 'user@gmail.com', 1, 'AHWnRIT3YsO2xsSg2bVVyohuOJxv3k9lYBEPxFCt8ohJ83Y9Nop7+xptCHk8Dcnrwg==', '76f53491-f82c-41da-a8d2-7c3c17ddd09e', NULL, 0, 0, NULL, 0, 0, 'user')

-- AspNetUserRoles

INSERT INTO AspNetUserRoles
	VALUES
	((SELECT Id FROM AspNetUsers WHERE UserName = 'administrator'), (SELECT Id FROM AspNetRoles WHERE Name = 'Administrators'))

INSERT INTO AspNetUserRoles
	VALUES
	((SELECT Id FROM AspNetUsers WHERE UserName = 'user'), (SELECT Id FROM AspNetRoles WHERE Name = 'Users'))
