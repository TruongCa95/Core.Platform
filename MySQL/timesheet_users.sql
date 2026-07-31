-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: timesheet
-- ------------------------------------------------------
-- Server version	8.0.42

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `Id` char(36) COLLATE utf8mb4_unicode_ci NOT NULL,
  `TenantId` char(36) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Username` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `PasswordHash` varchar(512) COLLATE utf8mb4_unicode_ci NOT NULL,
  `FirstName` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `LastName` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `IsEnabled` tinyint(1) NOT NULL DEFAULT '1',
  `IsLocked` tinyint(1) NOT NULL DEFAULT '0',
  `IsEmailVerified` tinyint(1) NOT NULL DEFAULT '0',
  `IsMfaEnabled` tinyint(1) NOT NULL DEFAULT '0',
  `LastLoginAt` datetime(6) DEFAULT NULL,
  `Locale` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `TimeZone` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  `UpdatedAt` datetime(6) DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  `CreatedBy` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `UpdatedBy` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UK_Users_Tenant_Username` (`TenantId`,`Username`),
  UNIQUE KEY `UK_Users_Tenant_Email` (`TenantId`,`Email`),
  KEY `IX_Users_TenantId` (`TenantId`),
  KEY `IX_Users_Email` (`Email`),
  KEY `IX_Users_Username` (`Username`),
  KEY `IX_Users_IsDeleted` (`IsDeleted`),
  CONSTRAINT `FK_Users_Tenants` FOREIGN KEY (`TenantId`) REFERENCES `tenants` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('2a44d4ff-8bc2-11f1-8d57-34298f7509c6','5e40e1bc-8bba-11f1-8d57-34298f7509c6','admin','admin@cpqn.com','$2a$10$L5W0MGnClmMzt1Slalz3a.7ZnrtoIjHqtWDo78bnSijfUY4weo7XW','System','Administrator',1,0,0,0,NULL,NULL,'GMT+7','2026-07-30 09:55:47.424296','2026-07-30 14:31:23.787354',NULL,NULL,0),('3fa283d0-872e-4712-9d3a-9e997049f32e','804fe81c-8b6a-11f1-8d57-34298f7509c6','Truongca','lavantruong95@gmail.com','$2a$10$L3/mUKqVgYuOKFBXyIEQqeCGuZwQEKPoTBAWe0ALKT6sadn9Q6Y/6',NULL,NULL,1,0,0,0,NULL,NULL,NULL,'2026-07-30 14:16:16.779098','2026-07-30 14:16:16.779098',NULL,NULL,0),('667279a5-145e-44aa-a85a-1172ef35afa0','804fe81c-8b6a-11f1-8d57-34298f7509c6','itsadmin','info@its.edu.vn','$2a$10$akTqJbhcp5jaAedUUipY7ewxJjUc1q5Ar9acRVeK1H3.NDUsrTrKC',NULL,NULL,1,0,0,0,NULL,NULL,NULL,'2026-07-30 14:14:37.754395','2026-07-30 14:20:38.582907',NULL,NULL,0);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-07-31  7:29:52
