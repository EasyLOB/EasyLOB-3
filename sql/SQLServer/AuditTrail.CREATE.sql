
/*
-- DELETE

DELETE FROM EasyLOBAuditTrailConfiguration
DELETE FROM EasyLOBAuditTrailLog

DBCC CHECKIDENT ('EasyLOBAuditTrailConfiguration', RESEED, 1)
DBCC CHECKIDENT ('EasyLOBAuditTrailLog', RESEED, 1)
*/

/*
-- DROP

DROP TABLE EasyLOBAuditTrailConfiguration
DROP TABLE EasyLOBAuditTrailLog
*/

CREATE TABLE EasyLOBAuditTrailConfiguration
(
	Id int IDENTITY(1,1) NOT NULL
	,Domain varchar(256) NOT NULL
	,Entity varchar(256) NOT NULL
	,LogMode varchar(1) NOT NULL -- (N)one | (K)ey | (E)ntity
	,LogOperations varchar(256)
    ,CONSTRAINT PK_EasyLOBAuditTrailConfiguration PRIMARY KEY (Id)
)
ALTER TABLE EasyLOBAuditTrailConfiguration ADD CONSTRAINT
    UN_EasyLOBAuditTrailConfiguration UNIQUE (Domain, Entity)
CREATE INDEX IX_EasyLOBAuditTrailConfiguration_Domain ON EasyLOBAuditTrailConfiguration(Domain)
CREATE INDEX IX_EasyLOBAuditTrailConfiguration_Entity ON EasyLOBAuditTrailConfiguration(Entity)

CREATE TABLE EasyLOBAuditTrailLog
(
	Id int IDENTITY(1,1) NOT NULL
	,LogDate datetime
	,LogTime datetime
	,LogUserName varchar(256)
	,LogDomain varchar(256)
	,LogEntity varchar(256)
	,LogOperation varchar(1) -- (C)reate | (R)ead | (U)pdate | (D)elete
	,LogId varchar(4096) -- { JSON } C R U D
	,LogEntityBefore varchar(4096) -- { JSON } - R U D
	,LogEntityAfter varchar(4096) -- { JSON } C - U -
    ,CONSTRAINT PK_EasyLOBAuditTrailLog PRIMARY KEY (Id)
)
CREATE INDEX IX_EasyLOBAuditTrailLog_LogDate ON EasyLOBAuditTrailLog(LogDate, LogTime)
CREATE INDEX IX_EasyLOBAuditTrailLog_LogUsername ON EasyLOBAuditTrailLog(LogUserName)
CREATE INDEX IX_EasyLOBAuditTrailLog_LogDomain ON EasyLOBAuditTrailLog(LogDomain)
CREATE INDEX IX_EasyLOBAuditTrailLog_LogEntity ON EasyLOBAuditTrailLog(LogEntity)
CREATE INDEX IX_EasyLOBAuditTrailLog_LogOperation ON EasyLOBAuditTrailLog(LogOperation)
