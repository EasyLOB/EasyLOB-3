SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema securityidentity
-- -----------------------------------------------------

/*
-- -----------------------------------------------------
-- Schema securityidentity
-- -----------------------------------------------------
-- CREATE SCHEMA IF NOT EXISTS `securityidentity` DEFAULT CHARACTER SET utf8 ;
*/

/*
USE `easylobidentity` ;
*/
/*
-- -----------------------------------------------------
-- Table `__migrationhistory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `__migrationhistory` (
  `MigrationId` VARCHAR(100) NOT NULL COMMENT '',
  `ContextKey` VARCHAR(200) NOT NULL COMMENT '',
  `Model` LONGBLOB NOT NULL COMMENT '',
  `ProductVersion` VARCHAR(32) NOT NULL COMMENT '',
  PRIMARY KEY (`MigrationId`, `ContextKey`)  COMMENT '')
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;
*/

-- -----------------------------------------------------
-- Table `aspnetroles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` VARCHAR(128) NOT NULL COMMENT '',
  `Name` VARCHAR(256) NOT NULL COMMENT '',
  `Discriminator` VARCHAR(128) NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '')
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `aspnetusers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` VARCHAR(128) NOT NULL COMMENT '',
  `Email` VARCHAR(256) NULL DEFAULT NULL COMMENT '',
  `EmailConfirmed` TINYINT(1) NOT NULL COMMENT '',
  `PasswordHash` LONGTEXT NULL DEFAULT NULL COMMENT '',
  `SecurityStamp` LONGTEXT NULL DEFAULT NULL COMMENT '',
  `PhoneNumber` LONGTEXT NULL DEFAULT NULL COMMENT '',
  `PhoneNumberConfirmed` TINYINT(1) NOT NULL COMMENT '',
  `TwoFactorEnabled` TINYINT(1) NOT NULL COMMENT '',
  `LockoutEndDateUtc` DATETIME NULL DEFAULT NULL COMMENT '',
  `LockoutEnabled` TINYINT(1) NOT NULL COMMENT '',
  `AccessFailedCount` INT(11) NOT NULL COMMENT '',
  `UserName` VARCHAR(256) NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '')
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `aspnetuserclaims`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT COMMENT '',
  `UserId` VARCHAR(128) NOT NULL COMMENT '',
  `ClaimType` LONGTEXT NULL DEFAULT NULL COMMENT '',
  `ClaimValue` LONGTEXT NULL DEFAULT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  CONSTRAINT `ApplicationUser_Claims`
    FOREIGN KEY (`UserId`)
    REFERENCES `aspnetusers` (`Id`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE UNIQUE INDEX `Id` ON `aspnetuserclaims` (`Id` ASC)  COMMENT '';

CREATE INDEX `UserId` ON `aspnetuserclaims` (`UserId` ASC)  COMMENT '';


-- -----------------------------------------------------
-- Table `aspnetuserlogins`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `LoginProvider` VARCHAR(128) NOT NULL COMMENT '',
  `ProviderKey` VARCHAR(128) NOT NULL COMMENT '',
  `UserId` VARCHAR(128) NOT NULL COMMENT '',
  PRIMARY KEY (`LoginProvider`, `ProviderKey`, `UserId`)  COMMENT '',
  CONSTRAINT `ApplicationUser_Logins`
    FOREIGN KEY (`UserId`)
    REFERENCES `aspnetusers` (`Id`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `ApplicationUser_Logins` ON `aspnetuserlogins` (`UserId` ASC)  COMMENT '';


-- -----------------------------------------------------
-- Table `aspnetuserroles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` VARCHAR(128) NOT NULL COMMENT '',
  `RoleId` VARCHAR(128) NOT NULL COMMENT '',
  PRIMARY KEY (`UserId`, `RoleId`)  COMMENT '',
  CONSTRAINT `ApplicationUser_Roles`
    FOREIGN KEY (`UserId`)
    REFERENCES `aspnetusers` (`Id`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
  CONSTRAINT `IdentityRole_Users`
    FOREIGN KEY (`RoleId`)
    REFERENCES `aspnetroles` (`Id`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IdentityRole_Users` ON `aspnetuserroles` (`RoleId` ASC)  COMMENT '';


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
