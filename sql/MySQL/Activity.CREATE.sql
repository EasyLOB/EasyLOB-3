
/*
-- DELETE

DELETE FROM ActivityRole;
DELETE FROM Activity;
*/

/*
-- DROP

DROP TABLE ActivityRole;
DROP TABLE Activity;
*/

CREATE TABLE Activity
(
	Id varchar(128) NOT NULL
	,Name varchar(255) NOT NULL
	,CONSTRAINT PK_Activity PRIMARY KEY (Id)
);
CREATE INDEX IX_Activity_01 ON Activity(Name);

CREATE TABLE ActivityRole
(
	ActivityId varchar(128) NOT NULL
	,RoleName varchar(128) NOT NULL
	,Operations varchar(255) NULL
	,CONSTRAINT PK_ActivityRole PRIMARY KEY (ActivityId, RoleName)
);
ALTER TABLE ActivityRole ADD CONSTRAINT FK_ActivityRole_01
    FOREIGN KEY(ActivityId) REFERENCES Activity(Id) ON UPDATE CASCADE;
