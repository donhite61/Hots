CREATE DATABASE  IF NOT EXISTS `hots` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `hots`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: hots
-- ------------------------------------------------------
-- Server version	5.7.18-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `oisystem`
--

DROP TABLE IF EXISTS `oisystem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `oisystem` (
  `OrdInputSys_Id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `OrdInputSys_Name` varchar(45) NOT NULL,
  `OrdInputSys_InputFldrNameKeyword` varchar(255) DEFAULT NULL,
  `OrdInputSys_OutputRenderedFolder` varchar(255) DEFAULT NULL,
  `OrdInputSys_RenderSubFolderString` varchar(45) DEFAULT NULL,
  `OrdInputSys_ExportToLabInFolder` varchar(255) DEFAULT NULL,
  `OrdInputSys_ThumbnailSubFolder` varchar(255) DEFAULT NULL,
  `OrdInputSys_Timestamp` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`OrdInputSys_Id`),
  UNIQUE KEY `ois_Id_UNIQUE` (`OrdInputSys_Id`),
  UNIQUE KEY `OrdInputSys_Name_UNIQUE` (`OrdInputSys_Name`),
  UNIQUE KEY `OrdInputSys_InputFldrNameKeyword_UNIQUE` (`OrdInputSys_InputFldrNameKeyword`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-04-27 23:15:01
