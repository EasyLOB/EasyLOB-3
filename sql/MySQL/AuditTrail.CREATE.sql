
/*
-- DELETE

DELETE FROM AuditTrail;
DELETE FROM AuditTrailLog;
*/

/*
-- DROP

DROP TABLE AuditTrail;
DROP TABLE AuditTrailLog;
*/

CREATE TABLE AuditTrail
(
	AuditTrailId int NOT NULL AUTO_INCREMENT
	,Domain varchar(255) NOT NULL
	,Entity varchar(255) NOT NULL
	,LogOperations varchar(255)
	,LogMode varchar(1) -- (N)one | (K)ey | (E)ntity
	,CONSTRAINT PK_AuditTrail PRIMARY KEY (AuditTrailId)
);
ALTER TABLE AuditTrail ADD CONSTRAINT UN_AuditTrail_01
    UNIQUE (Entity);
CREATE INDEX IX_AuditTrail_01 ON AuditTrail(Entity);

CREATE TABLE AuditTrailLog
(
	AuditTrailLogId int NOT NULL AUTO_INCREMENT
	,LogDate datetime
	,LogTime datetime
	,LogUserName varchar(255)
	,LogDomain varchar(255) NOT NULL
	,LogEntity varchar(255) NOT NULL
	,LogOperation varchar(1) -- (C)reate | (R)ead | (U)pdate | (D)elete
	,LogId varchar(4095) -- { JSON } C R U D
	,LogEntityBefore varchar(4095) -- { JSON } - R U D
	,LogEntityAfter varchar(4095) -- { JSON } C - U -
	,CONSTRAINT PK_AuditTrailLog PRIMARY KEY (AuditTrailLogId)
);
CREATE INDEX IX_AuditTrailLog_01 ON AuditTrailLog(LogDate, LogTime);
CREATE INDEX IX_AuditTrailLog_02 ON AuditTrailLog(LogUserName);
CREATE INDEX IX_AuditTrailLog_03 ON AuditTrailLog(LogDomain);
CREATE INDEX IX_AuditTrailLog_04 ON AuditTrailLog(LogEntity);
CREATE INDEX IX_AuditTrailLog_05 ON AuditTrailLog(LogOperation);
