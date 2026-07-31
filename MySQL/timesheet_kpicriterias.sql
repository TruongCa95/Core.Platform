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
-- Table structure for table `kpicriterias`
--

DROP TABLE IF EXISTS `kpicriterias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kpicriterias` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Criteria` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Point` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Type` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DisplayOrder` int NOT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UpdatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedDate` datetime(6) NOT NULL,
  `UpdatedDate` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kpicriterias`
--

LOCK TABLES `kpicriterias` WRITE;
/*!40000 ALTER TABLE `kpicriterias` DISABLE KEYS */;
INSERT INTO `kpicriterias` VALUES ('00000000-0000-0000-0000-000000000001','Thầy giáo của ITS chỉ đạo, hướng dẫn học sinh có thành tích đặc biệt xuất sắc ở các cuộc thi của Trường, của Quốc gia','+40đ','plus',1,1,'','','2026-01-01 00:00:00.000000','2026-07-29 03:00:05.701524'),('00000000-0000-0000-0000-000000000002','Thầy giáo có đóng góp về góp ý, ý tưởng, tham gia trực tiếp hiện thực hóa ý tưởng đạt hiệu quả vượt bậc','+40đ','plus',2,1,'','','2026-01-01 00:00:00.000000','2026-01-01 00:00:00.000000'),('00000000-0000-0000-0000-000000000003','Thầy giáo có những cống hiến quên mình vì sự phát triển của Tổ chức được quản lý trực tiếp đánh giá xuất sắc / đề xuất từ quản lý trực tiếp','+40đ','plus',3,1,'','','2026-01-01 00:00:00.000000','2026-01-01 00:00:00.000000'),('00000000-0000-0000-0000-000000000004','Lớp không có học sinh ở dưới điểm 9 trong các bài kiểm tra, điểm thi học kỳ trên trường','+25đ','plus',4,1,'','','2026-01-01 00:00:00.000000','2026-01-01 00:00:00.000000'),('00000000-0000-0000-0000-000000000005','Phụ huynh ý kiến khen / giới thiệu thêm học sinh cho lớp / trung tâm','+15đ','plus',5,1,'','','2026-01-01 00:00:00.000000','2026-01-01 00:00:00.000000'),('00000000-0000-0000-0000-000000000006','Đi dạy đầy đủ 100% các buổi dạy được phân công trong tháng','+5đ','plus',6,1,'','','2026-01-01 00:00:00.000000','2026-01-01 00:00:00.000000'),('00000000-0000-0000-0000-000000000007','Lớp không có học sinh ở dưới điểm 8 trong các bài kiểm tra','+10đ','plus',7,1,'','','2026-01-01 00:00:00.000000','2026-01-01 00:00:00.000000'),('00000000-0000-0000-0000-000000000008','Lớp có trên 80% học sinh điểm thi trên 8','+10đ','plus',8,1,'','','2026-01-01 00:00:00.000000','2026-01-01 00:00:00.000000'),('00000000-0000-0000-0000-000000000009','Lớp có 1 hoặc 2 học sinh có điểm kiểm tra / thi từ 7 đến < 8 điểm','-5đ','minus',9,1,'','','2026-01-01 00:00:00.000000','2026-01-01 00:00:00.000000'),('00000000-0000-0000-0000-000000000010','Lớp có 3 hoặc 4 học sinh có điểm kiểm tra / thi từ 7 đến < 8 điểm','-10đ','minus',10,1,'','','2026-01-01 00:00:00.000000','2026-01-01 00:00:00.000000'),('00000000-0000-0000-0000-000000000011','Từ chối dạy những buổi theo lịch đã đăng ký','-10đ','minus',11,1,'','','2026-01-01 00:00:00.000000','2026-01-01 00:00:00.000000'),('00000000-0000-0000-0000-000000000012','Lớp có 5 hoặc 6 bạn học sinh có điểm kiểm tra / thi từ 7 đến < 8 điểm','-15đ','minus',12,1,'','','2026-01-01 00:00:00.000000','2026-01-01 00:00:00.000000'),('00000000-0000-0000-0000-000000000013','Lớp có 1 hoặc 2 học sinh có điểm kiểm tra / thi từ 6 đến < 7 điểm','-10đ','minus',13,1,'','','2026-01-01 00:00:00.000000','2026-01-01 00:00:00.000000'),('00000000-0000-0000-0000-000000000014','Lớp có 3 hoặc 4 học sinh có điểm kiểm tra / thi từ 6 đến < 7 điểm','-15đ','minus',14,1,'','','2026-01-01 00:00:00.000000','2026-01-01 00:00:00.000000'),('00000000-0000-0000-0000-000000000015','Lớp có 5 hoặc 6 bạn học sinh có điểm kiểm tra / thi từ 6 đến < 7 điểm','-20đ','minus',15,1,'','','2026-01-01 00:00:00.000000','2026-01-01 00:00:00.000000'),('00000000-0000-0000-0000-000000000016','Lớp có bạn học sinh có điểm kiểm tra / thi < 6 điểm','-40đ','minus',16,1,'','','2026-01-01 00:00:00.000000','2026-01-01 00:00:00.000000');
/*!40000 ALTER TABLE `kpicriterias` ENABLE KEYS */;
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
