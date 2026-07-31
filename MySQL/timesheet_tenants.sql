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
-- Table structure for table `tenants`
--

DROP TABLE IF EXISTS `tenants`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tenants` (
  `Id` char(36) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Name` varchar(150) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Slug` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Domain` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Status` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT 'ACTIVE',
  `Description` varchar(1000) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  `UpdatedAt` datetime(6) DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  `CreatedBy` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `UpdatedBy` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UK_Tenants_Slug` (`Slug`),
  KEY `IX_Tenants_Status` (`Status`),
  KEY `IX_Tenants_IsDeleted` (`IsDeleted`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tenants`
--

LOCK TABLES `tenants` WRITE;
/*!40000 ALTER TABLE `tenants` DISABLE KEYS */;
INSERT INTO `tenants` VALUES ('5e40e1bc-8bba-11f1-8d57-34298f7509c6','Platform','platform','','ACTIVE',NULL,'2026-07-30 08:59:58.667981','2026-07-30 13:04:52.443306','sysadmin','sysadmin',0),('804fe81c-8b6a-11f1-8d57-34298f7509c6','iTS Academy','its-academy','https://its.edu.vn/','ACTIVE','Hộ kinh doanh ITS','2026-07-29 23:28:16.039671','2026-07-30 13:12:42.259316','sysadmin','sysadmin',0),('883c03f4-8b6a-11f1-8d57-34298f7509c6','Aten English','aten-english','https://aten.edu.vn/','ACTIVE',' ','2026-07-29 23:28:29.362186','2026-07-30 13:12:42.263002','sysadmin','sysadmin',0),('8b16bb7b-8b6a-11f1-8d57-34298f7509c6','Minh Duy Consulting & Education Center','md-center','https://md.edu.vn/','ACTIVE','Công ty TNHH Đầu tư và Phát Triển giáo dục Minh Duy','2026-07-29 23:28:34.151098','2026-07-30 13:12:42.260980','sysadmin','sysadmin',0),('8d109148-8b6a-11f1-8d57-34298f7509c6','MindX Technology School','mindx-school','https://mindx.edu.vn/','ACTIVE','Công ty Cổ phần Trường học Công nghệ MindX','2026-07-29 23:28:37.466062','2026-07-30 13:12:42.262098','sysadmin','sysadmin',0);
/*!40000 ALTER TABLE `tenants` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-07-31  7:29:53
