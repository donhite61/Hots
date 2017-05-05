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
-- Table structure for table `orderheaders`
--

DROP TABLE IF EXISTS `orderheaders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orderheaders` (
  `Ord_MySqlId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Ord_HiteId` varchar(45) NOT NULL,
  `Ord_AltId` varchar(45) DEFAULT NULL,
  `Ord_TimeIn` datetime DEFAULT NULL,
  `Ord_PreTaxTotal` decimal(10,2) DEFAULT NULL,
  `Ord_PromoCode` varchar(45) DEFAULT NULL,
  `Ord_DiscAmount` decimal(10,2) DEFAULT NULL,
  `Ord_SalesTax` decimal(10,2) DEFAULT NULL,
  `Ord_TotalPrice` decimal(10,2) DEFAULT NULL,
  `Ord_PrePaid` tinyint(4) DEFAULT NULL,
  `Ord_LabLabel` varchar(45) DEFAULT NULL,
  `Ord_Catalog` varchar(45) DEFAULT NULL,
  `Ord_FullfillmentStore` varchar(45) DEFAULT NULL,
  `Ord_ServiceTime` varchar(45) DEFAULT NULL,
  `Ord_OrderSystem` varchar(45) DEFAULT NULL,
  `Ord_Products` varchar(45) DEFAULT NULL,
  `Ord_CusId` varchar(45) DEFAULT NULL,
  `Ord_CusName` varchar(45) DEFAULT NULL,
  `Ord_CusAddress1` varchar(45) DEFAULT NULL,
  `Ord_CusAddress2` varchar(45) DEFAULT NULL,
  `Ord_CusCity` varchar(45) DEFAULT NULL,
  `Ord_CusState` varchar(45) DEFAULT NULL,
  `Ord_CusZip` varchar(45) DEFAULT NULL,
  `Ord_CusCountry` varchar(45) DEFAULT NULL,
  `Ord_CusPhone` varchar(45) DEFAULT NULL,
  `Ord_CusEmail` varchar(45) DEFAULT NULL,
  `Ord_BillTo` varchar(45) DEFAULT NULL,
  `Ord_BillCCName` varchar(45) DEFAULT NULL,
  `Ord_BillCCAddress` varchar(45) DEFAULT NULL,
  `Ord_BillCCCity` varchar(45) DEFAULT NULL,
  `Ord_BillCCState` varchar(45) DEFAULT NULL,
  `Ord_BillCCZip` varchar(45) DEFAULT NULL,
  `Ord_ShipMethod` varchar(255) DEFAULT NULL,
  `Ord_ShipCost` decimal(10,2) DEFAULT NULL,
  `Ord_ShipTo` varchar(45) DEFAULT NULL,
  `Ord_ShipName` varchar(45) DEFAULT NULL,
  `Ord_ShipAddress` varchar(45) DEFAULT NULL,
  `Ord_ShipCity` varchar(45) DEFAULT NULL,
  `Ord_ShipState` varchar(45) DEFAULT NULL,
  `Ord_ShipZip` varchar(45) DEFAULT NULL,
  `Ord_ShipPhone` varchar(45) DEFAULT NULL,
  `Ord_ShipEmail` varchar(45) DEFAULT NULL,
  `Ord_PayCCType` varchar(45) DEFAULT NULL,
  `Ord_PayCCNumber` varchar(45) DEFAULT NULL,
  `Ord_PayCCCvv` varchar(45) DEFAULT NULL,
  `Ord_PayCCExp` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Ord_MySqlId`,`Ord_HiteId`),
  UNIQUE KEY `Ord_MySqlId_UNIQUE` (`Ord_MySqlId`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-04-27 23:14:22
