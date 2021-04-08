
-- AspNetRoles

INSERT INTO AspNetRoles
	(Id, Name, Discriminator)
	VALUES
	('7698dd46-3905-4869-8d10-0428b70c5af7', 'Administrators', 'ApplicationRole');
INSERT INTO AspNetRoles
	(Id, Name, Discriminator)
	VALUES
	('2f6635db-4e44-4228-bd03-c31c830caad3', 'Users', 'ApplicationRole');
    
-- AspNetUsers

-- administrator / administrator@gmail.com / P@ssw0rd
INSERT INTO AspNetUsers
	(Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName)
	VALUES
	('ced7e48f-682c-4903-8c4f-33b31c239a0e', 'administrator@gmail.com', 0, 'AHWnRIT3YsO2xsSg2bVVyohuOJxv3k9lYBEPxFCt8ohJ83Y9Nop7+xptCHk8Dcnrwg==', '76f53491-f82c-41da-a8d2-7c3c17ddd09e', NULL, 0, 0, NULL, 0, 0, 'administrator');
-- user / user@gmail.com / P@ssw0rd
INSERT INTO AspNetUsers
	(Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName)
	VALUES
	('35b60d61-d4ab-4eef-b8b7-963da3979835', 'user@gmail.com', 0, 'AHWnRIT3YsO2xsSg2bVVyohuOJxv3k9lYBEPxFCt8ohJ83Y9Nop7+xptCHk8Dcnrwg==', '76f53491-f82c-41da-a8d2-7c3c17ddd09e', NULL, 0, 0, NULL, 0, 0, 'user');

-- AspNetUserRoles

INSERT INTO AspNetUserRoles
	(UserId, RoleId)
	VALUES
	('ced7e48f-682c-4903-8c4f-33b31c239a0e', '7698dd46-3905-4869-8d10-0428b70c5af7');
INSERT INTO AspNetUserRoles
	(UserId, RoleId)
	VALUES
	('35b60d61-d4ab-4eef-b8b7-963da3979835', '2f6635db-4e44-4228-bd03-c31c830caad3');
