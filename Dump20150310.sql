CREATE DATABASE  IF NOT EXISTS `db_parking` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `db_parking`;
-- MySQL dump 10.13  Distrib 5.6.17, for Win32 (x86)
--
-- Host: localhost    Database: db_parking
-- ------------------------------------------------------
-- Server version	5.5.27

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
-- Table structure for table `car`
--

DROP TABLE IF EXISTS `car`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `car` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `value` varchar(10) NOT NULL,
  `base_revenue` varchar(10) NOT NULL,
  `name` varchar(45) NOT NULL,
  `car_icon` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `car`
--

LOCK TABLES `car` WRITE;
/*!40000 ALTER TABLE `car` DISABLE KEYS */;
INSERT INTO `car` VALUES (1,'75000','25000','nano','images/1.png'),(2,'100000','35000','audi','images/2.png'),(3,'200000','50000','swift','images/3.png'),(4,'30000','10000','x','images/3.png');
/*!40000 ALTER TABLE `car` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fine_log`
--

DROP TABLE IF EXISTS `fine_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fine_log` (
  `id` int(11) NOT NULL,
  `fine` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fine_log`
--

LOCK TABLES `fine_log` WRITE;
/*!40000 ALTER TABLE `fine_log` DISABLE KEYS */;
INSERT INTO `fine_log` VALUES (18,136),(33,8);
/*!40000 ALTER TABLE `fine_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `garage`
--

DROP TABLE IF EXISTS `garage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `garage` (
  `user_id` int(11) NOT NULL,
  `car_id` int(11) NOT NULL,
  `parking_id` int(11) NOT NULL,
  `time_stamp` datetime NOT NULL,
  `hits` int(11) DEFAULT '0',
  `status` int(11) DEFAULT '0',
  `sno` int(11) NOT NULL AUTO_INCREMENT,
  `class` varchar(10) DEFAULT NULL,
  `robo_level` int(11) DEFAULT NULL,
  PRIMARY KEY (`sno`),
  KEY `FK_GAR_CAR_idx` (`car_id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `garage`
--

LOCK TABLES `garage` WRITE;
/*!40000 ALTER TABLE `garage` DISABLE KEYS */;
INSERT INTO `garage` VALUES (54,1,0,'2015-03-05 03:11:20',2,0,1,NULL,NULL),(54,3,0,'2015-02-24 18:58:18',2,0,2,NULL,NULL),(1001,1,0,'2015-03-05 03:31:21',1,0,3,NULL,NULL),(1002,1,0,'2015-02-24 22:02:08',0,1,4,NULL,NULL),(1002,3,0,'2015-02-20 11:36:13',0,0,5,NULL,NULL),(1028,2,0,'2015-03-05 01:12:26',2,1,6,NULL,NULL),(1028,3,0,'2015-03-05 01:46:17',1,1,7,NULL,NULL),(1032,1,0,'2015-02-20 11:26:30',2,0,8,NULL,NULL),(1032,2,0,'2015-02-20 11:20:13',0,0,9,NULL,NULL),(1032,3,0,'2015-02-20 11:25:53',0,0,10,NULL,NULL),(54,1,0,'2015-03-05 03:11:20',0,0,11,NULL,NULL),(1002,1,0,'2015-02-24 22:02:08',0,0,12,NULL,NULL),(1018,1,207,'2015-02-26 17:31:34',0,1,13,'A',3),(1018,2,0,'2015-02-26 17:05:25',0,1,14,NULL,NULL),(1018,1,0,'2015-02-26 17:31:34',0,0,15,'A',3),(1018,2,0,'2015-02-26 17:13:47',0,0,16,NULL,NULL),(1028,1,0,'2015-03-01 00:48:18',0,1,17,NULL,NULL),(1013,1,0,'2015-03-01 03:15:34',0,0,18,NULL,NULL),(1013,4,0,'2015-03-01 03:24:58',0,0,19,NULL,NULL),(1013,2,0,'2015-03-01 03:28:51',0,0,20,NULL,NULL),(1028,1,0,'2015-03-10 07:07:04',0,0,23,NULL,NULL);
/*!40000 ALTER TABLE `garage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `parking`
--

DROP TABLE IF EXISTS `parking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `parking` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `private` bit(1) NOT NULL,
  `sector_id` int(11) NOT NULL,
  `allowed` bit(1) NOT NULL,
  `isvacant` bit(1) DEFAULT b'1',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=280 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parking`
--

LOCK TABLES `parking` WRITE;
/*!40000 ALTER TABLE `parking` DISABLE KEYS */;
INSERT INTO `parking` VALUES (190,'',1,'\0',''),(191,'',1,'',''),(192,'',1,'\0',''),(193,'',1,'',''),(194,'',1,'\0',''),(195,'',2,'\0',''),(196,'',2,'',''),(197,'',2,'\0',''),(198,'',2,'',''),(199,'',2,'\0',''),(200,'',3,'\0',''),(201,'',3,'',''),(202,'',3,'\0',''),(203,'',3,'',''),(204,'',3,'\0',''),(205,'',3,'\0',''),(206,'',3,'',''),(207,'',3,'\0',''),(208,'',3,'',''),(209,'',3,'\0',''),(210,'',4,'\0',''),(211,'',4,'',''),(212,'',4,'\0',''),(213,'',4,'',''),(214,'',4,'\0',''),(215,'',1,'\0',''),(216,'',1,'',''),(217,'',1,'\0',''),(218,'',1,'',''),(219,'',1,'\0',''),(220,'\0',1,'\0',''),(221,'\0',1,'\0',''),(222,'\0',1,'\0',''),(223,'\0',1,'\0',''),(224,'\0',1,'\0',''),(225,'\0',1,'\0',''),(226,'\0',1,'\0',''),(227,'\0',1,'\0',''),(228,'\0',1,'\0',''),(229,'\0',1,'\0',''),(230,'\0',2,'\0',''),(231,'\0',2,'\0',''),(232,'\0',2,'\0',''),(233,'\0',2,'\0',''),(234,'\0',2,'\0',''),(235,'\0',2,'\0',''),(236,'\0',2,'\0',''),(237,'\0',2,'\0',''),(238,'\0',2,'\0',''),(239,'\0',2,'\0',''),(240,'\0',3,'\0',''),(241,'\0',3,'\0',''),(242,'\0',3,'\0',''),(243,'\0',3,'\0',''),(244,'\0',3,'\0',''),(245,'\0',3,'\0',''),(246,'\0',3,'\0',''),(247,'\0',3,'\0','\0'),(248,'\0',3,'\0',''),(249,'\0',3,'\0',''),(250,'\0',4,'\0',''),(251,'\0',4,'\0',''),(252,'\0',4,'\0',''),(253,'\0',4,'\0',''),(254,'\0',4,'\0',''),(255,'\0',4,'\0',''),(256,'\0',4,'\0',''),(257,'\0',4,'\0',''),(258,'\0',4,'\0',''),(259,'\0',4,'\0',''),(260,'',1,'\0',''),(261,'',1,'',''),(262,'',1,'\0',''),(263,'',1,'',''),(264,'',1,'\0',''),(265,'',4,'\0',''),(266,'',4,'',''),(267,'',4,'\0',''),(268,'',4,'',''),(269,'',4,'\0',''),(270,'',1,'\0',''),(271,'',1,'',''),(272,'',1,'\0',''),(273,'',1,'',''),(274,'',1,'\0',''),(275,'',4,'\0',''),(276,'',4,'',''),(277,'',4,'\0',''),(278,'',4,'',''),(279,'',4,'\0','');
/*!40000 ALTER TABLE `parking` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `parking_log`
--

DROP TABLE IF EXISTS `parking_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `parking_log` (
  `user_id` int(11) NOT NULL,
  `parking_owner_id` int(11) NOT NULL,
  `timestamp` datetime NOT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `is_successful` bit(1) DEFAULT b'0',
  PRIMARY KEY (`id`),
  KEY `userid_idx` (`user_id`),
  KEY `parking_idx` (`user_id`,`parking_owner_id`),
  CONSTRAINT `FK_SUCCESS_USER` FOREIGN KEY (`user_id`) REFERENCES `user` (`ttid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parking_log`
--

LOCK TABLES `parking_log` WRITE;
/*!40000 ALTER TABLE `parking_log` DISABLE KEYS */;
INSERT INTO `parking_log` VALUES (1002,66,'2015-02-18 11:22:12',1,'\0'),(54,114,'2015-02-18 17:24:24',2,'\0'),(54,114,'2015-02-18 17:24:24',3,'\0'),(54,123,'2015-02-18 17:24:24',4,'\0'),(54,111,'2015-02-19 17:42:25',5,'\0'),(1028,206,'2015-02-20 07:21:27',6,'\0'),(54,213,'2015-02-20 11:40:52',7,'\0'),(54,260,'2015-02-23 15:52:15',8,'\0'),(54,264,'2015-02-23 15:48:57',9,'\0'),(54,260,'2015-02-23 15:52:15',10,'\0'),(54,0,'2015-02-23 18:44:59',11,'\0'),(54,260,'2015-02-23 18:48:33',12,'\0'),(1002,0,'2015-02-23 23:02:42',13,'\0'),(54,219,'2015-02-24 18:35:17',14,''),(1032,0,'2015-02-24 21:31:27',15,'\0'),(1032,0,'2015-02-24 21:43:43',16,'\0'),(1002,204,'2015-02-24 22:02:08',17,''),(1018,0,'2015-02-26 17:28:05',18,'\0'),(54,210,'2015-02-25 19:17:26',20,''),(1028,195,'2015-03-05 01:18:56',23,''),(1028,269,'2015-03-05 01:29:15',24,''),(1028,0,'2015-03-05 01:32:29',25,'\0'),(1028,0,'2015-03-05 01:35:32',26,'\0'),(1028,257,'2015-03-05 01:46:18',27,''),(1028,237,'2015-03-05 02:12:04',28,''),(1028,209,'2015-03-05 02:14:02',29,''),(54,210,'2015-03-05 03:11:21',30,'\0'),(1001,210,'2015-03-05 03:31:22',33,'\0'),(1028,234,'2015-03-08 23:44:07',42,''),(1028,246,'2015-03-10 01:46:24',43,''),(1028,249,'2015-03-10 01:50:30',44,''),(1028,246,'2015-03-10 01:54:08',45,''),(1028,239,'2015-03-10 01:59:15',46,''),(1028,258,'2015-03-10 02:02:36',47,''),(1028,247,'2015-03-10 03:08:02',48,''),(1028,246,'2015-03-10 03:19:59',49,''),(1028,247,'2015-03-10 04:54:12',50,'\0'),(1028,256,'2015-03-10 05:04:37',51,''),(1028,256,'2015-03-10 05:13:03',52,''),(1028,255,'2015-03-10 06:40:05',53,''),(1028,275,'2015-03-10 07:07:07',54,'');
/*!40000 ALTER TABLE `parking_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `revenuebyfine`
--

DROP TABLE IF EXISTS `revenuebyfine`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `revenuebyfine` (
  `logid` int(11) NOT NULL,
  `revenue` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`logid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `revenuebyfine`
--

LOCK TABLES `revenuebyfine` WRITE;
/*!40000 ALTER TABLE `revenuebyfine` DISABLE KEYS */;
/*!40000 ALTER TABLE `revenuebyfine` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `revenuelog`
--

DROP TABLE IF EXISTS `revenuelog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `revenuelog` (
  `logid` int(11) NOT NULL,
  `revenue` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`logid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `revenuelog`
--

LOCK TABLES `revenuelog` WRITE;
/*!40000 ALTER TABLE `revenuelog` DISABLE KEYS */;
INSERT INTO `revenuelog` VALUES (20,'2636'),(23,'759'),(24,'698'),(27,'282'),(28,'152'),(29,'133'),(40,'166'),(42,'353'),(43,'754'),(44,'731'),(45,'1130'),(46,'635'),(47,'15695'),(48,'3013'),(49,'38431'),(51,'554'),(52,'30816'),(53,'3313'),(54,'593');
/*!40000 ALTER TABLE `revenuelog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `robo_mapping`
--

DROP TABLE IF EXISTS `robo_mapping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `robo_mapping` (
  `s_no` int(11) NOT NULL AUTO_INCREMENT,
  `class` varchar(10) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `source` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`s_no`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `robo_mapping`
--

LOCK TABLES `robo_mapping` WRITE;
/*!40000 ALTER TABLE `robo_mapping` DISABLE KEYS */;
INSERT INTO `robo_mapping` VALUES (1,'A',1,NULL);
/*!40000 ALTER TABLE `robo_mapping` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `robozzle_score`
--

DROP TABLE IF EXISTS `robozzle_score`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `robozzle_score` (
  `logid` int(11) NOT NULL,
  `score` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `ttid` int(11) DEFAULT NULL,
  `script` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `robozzle_score`
--

LOCK TABLES `robozzle_score` WRITE;
/*!40000 ALTER TABLE `robozzle_score` DISABLE KEYS */;
INSERT INTO `robozzle_score` VALUES (49,1,1,1028,'');
/*!40000 ALTER TABLE `robozzle_score` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sector`
--

DROP TABLE IF EXISTS `sector`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sector` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sector`
--

LOCK TABLES `sector` WRITE;
/*!40000 ALTER TABLE `sector` DISABLE KEYS */;
INSERT INTO `sector` VALUES (1,'Sector A'),(2,'Sector B'),(3,'Sector C'),(4,'Sector D');
/*!40000 ALTER TABLE `sector` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `ttid` int(11) NOT NULL,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `contact` varchar(45) NOT NULL DEFAULT '9878757',
  `cash` varchar(45) NOT NULL DEFAULT '10000',
  `sector_id` int(11) NOT NULL DEFAULT '0',
  `confirmed` int(5) NOT NULL DEFAULT '0',
  `email` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`ttid`),
  UNIQUE KEY `email_UNIQUE` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (54,'aditi','56','986756','99956',1,1,'a@gmail.com'),(1001,'yanat','p','9878757','100833',4,1,'yanat@y.com'),(1002,'Archit Saxena','alohomora','9878757','100000',2,1,NULL),(1003,'Sukankshi Jain','sukku','0878796','100000',3,1,NULL),(1011,'gaurav arora','apoorva','35678900','100000',0,0,NULL),(1013,'Anurag Arora','aws','9878757','116100',4,1,'anu@gmail.com'),(1015,'nikhil singh','ritukhatri','9878757','100000',1,1,NULL),(1018,'Anything','asdf','9878757','936',4,1,NULL),(1028,'Mudit Juneja','123','9878757','418135',4,1,'mudit_juneja@gmail.com'),(1032,'Sufiyan Ansari','1234','9878757','100000',1,1,NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_parking`
--

DROP TABLE IF EXISTS `user_parking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_parking` (
  `user_id` int(11) DEFAULT NULL,
  `parking_id` int(11) DEFAULT NULL,
  KEY `parking_user_idx` (`user_id`),
  CONSTRAINT `parking_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`ttid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_parking`
--

LOCK TABLES `user_parking` WRITE;
/*!40000 ALTER TABLE `user_parking` DISABLE KEYS */;
INSERT INTO `user_parking` VALUES (54,190),(54,191),(54,192),(54,193),(54,194),(1002,195),(1002,196),(1002,197),(1002,198),(1002,199),(1003,200),(1003,201),(1003,202),(1003,203),(1003,204),(1013,205),(1013,206),(1013,207),(1013,208),(1013,209),(1028,210),(1028,211),(1028,212),(1028,213),(1028,214),(1015,215),(1015,216),(1015,217),(1015,218),(1015,219),(1032,260),(1032,261),(1032,262),(1032,263),(1032,264),(1018,265),(1018,266),(1018,267),(1018,268),(1018,269),(1013,270),(1013,271),(1013,272),(1013,273),(1013,274),(1013,275),(1013,276),(1013,277),(1013,278),(1013,279);
/*!40000 ALTER TABLE `user_parking` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-03-10 12:27:43
