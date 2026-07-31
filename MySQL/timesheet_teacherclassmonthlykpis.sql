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
-- Table structure for table `teacherclassmonthlykpis`
--

DROP TABLE IF EXISTS `teacherclassmonthlykpis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `teacherclassmonthlykpis` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ClassroomId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Year` int NOT NULL,
  `Month` int NOT NULL,
  `KPI` int NOT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UpdatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedDate` datetime(6) NOT NULL,
  `UpdatedDate` datetime(6) NOT NULL,
  `Note` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_TeacherClassMonthlyKPIs_ClassroomId_Year_Month` (`ClassroomId`,`Year`,`Month`),
  CONSTRAINT `FK_TeacherClassMonthlyKPIs_ClassRooms_ClassroomId` FOREIGN KEY (`ClassroomId`) REFERENCES `classrooms` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacherclassmonthlykpis`
--

LOCK TABLES `teacherclassmonthlykpis` WRITE;
/*!40000 ALTER TABLE `teacherclassmonthlykpis` DISABLE KEYS */;
INSERT INTO `teacherclassmonthlykpis` VALUES ('08000acc-2eed-4ebe-9f68-1ee6bb616d03','741ee4ea-5beb-43de-9fe7-11f0d2ca0afb',2026,3,3,1,'','','2026-07-28 08:12:30.711890','2026-07-28 08:12:30.711890','Tổng điểm 115: điểm > 8 '),('1b7924ba-bc06-4bce-bbb5-3906776670f4','5533aba1-fbbf-4115-badf-948e89308157',2026,3,5,1,'','','2026-07-28 08:16:09.332113','2026-07-28 08:16:20.622047','Tổng điểm 60: điểm thi 43/100'),('226ea16f-1457-42fa-85a5-8a5614b8fe78','effc4e3e-3ae8-476e-8d62-f89d83d3d6eb',2026,3,3,1,'','','2026-07-28 08:11:38.385348','2026-07-28 08:11:38.385399','Tổng điểm 120: Phụ huynh khen/giới thiệu thêm học sinh'),('8cdd06e1-87cc-4e4d-8a90-44332159544a','395198a8-351b-4537-8542-ccf1e2697604',2026,3,3,1,'','','2026-07-28 08:17:11.046545','2026-07-28 08:17:11.046545','Tổng điểm 115: phụ huynh khen/giới thiệu thêm học sinh'),('ced3b52a-d876-4514-8a3b-614b366f7ca2','5ff4fd14-2395-4384-8d56-f8045f3a28f7',2026,3,1,1,'','','2026-07-28 08:13:40.770163','2026-07-28 08:13:40.770163','Tổng điểm 125: All điểm > 9'),('f61d3632-51d9-4e07-abba-846308711115','a9b59726-cb39-4633-80e3-e5a3bf1c3e79',2026,7,2,1,'','','2026-07-28 07:53:37.758698','2026-07-28 07:53:37.758770','');
/*!40000 ALTER TABLE `teacherclassmonthlykpis` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-07-31  7:29:54
