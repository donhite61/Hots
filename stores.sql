-- phpMyAdmin SQL Dump
-- version 4.0.10.14
-- http://www.phpmyadmin.net
--
-- Host: localhost:3306
-- Generation Time: May 06, 2017 at 08:25 AM
-- Server version: 5.6.32-78.1-log
-- PHP Version: 5.6.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `hitephot_timeclock`
--

-- --------------------------------------------------------

--
-- Table structure for table `stores`
--

CREATE TABLE IF NOT EXISTS `stores` (
  `strId` int(11) NOT NULL AUTO_INCREMENT,
  `strNicName` varchar(45) NOT NULL,
  `strName` varchar(100) NOT NULL,
  `strAddress` varchar(100) NOT NULL,
  `strCity` varchar(100) NOT NULL,
  `strState` varchar(45) NOT NULL,
  `strZip` varchar(45) NOT NULL,
  `strPhone` varchar(45) NOT NULL,
  `strInactive` tinyint(1) NOT NULL,
  `strTimestamp` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`strId`),
  UNIQUE KEY `strNicName` (`strNicName`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=12 ;

--
-- Dumping data for table `stores`
--

INSERT INTO `stores` (`strId`, `strNicName`, `strName`, `strAddress`, `strCity`, `strState`, `strZip`, `strPhone`, `strInactive`, `strTimestamp`) VALUES
(7, 'Lahser', 'Hite Photo Bloomfield Hills', '3641 West Maple Rd.', 'Bloomfield HIlls', 'MI', '48301', '(248) 593-6286', 0, '0000-00-00 00:00:00'),
(8, 'Orchard', 'Hite Photo West Bloomfield', '6704 Orchard Lake Rd.', 'West Bloomfield', 'MI', '48324', '(248) 851-6340', 0, '0000-00-00 00:00:00'),
(9, 'test', '', '', '', '', '', '(   )    -', 1, '0000-00-00 00:00:00'),
(10, 'test2', '', '', '', '', '', '(   )    -', 1, '0000-00-00 00:00:00'),
(11, 'AArbor', 'Ann Arbor', '9834 skajdfn', 'Ann Arbor', 'MI', '48324', '(248) 851-6340', 0, '0000-00-00 00:00:00');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
