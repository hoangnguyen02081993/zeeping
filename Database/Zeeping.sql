-- MySQL dump 10.13  Distrib 5.6.36, for Linux (x86_64)
--
-- Host: localhost    Database: Zeeping
-- ------------------------------------------------------
-- Server version	5.6.36-cll-lve

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
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order` (
  `order_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `guid` varchar(36) NOT NULL,
  `product_id` bigint(20) NOT NULL,
  `style_id` bigint(20) NOT NULL,
  `color_id` bigint(20) NOT NULL,
  `size_id` bigint(20) NOT NULL,
  `quantity` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `ischeckoutcompleted` tinyint(1) NOT NULL DEFAULT '0',
  `createDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `isOrderCompleted` smallint(6) NOT NULL DEFAULT '2',
  `email` varchar(50) NOT NULL,
  `firstname` varchar(30) NOT NULL,
  `lastname` varchar(30) NOT NULL,
  `street_address` varchar(30) NOT NULL,
  `apt_suite_other` varchar(30) NOT NULL,
  `city` varchar(30) NOT NULL,
  `postal_code` varchar(10) NOT NULL,
  `country_id` int(11) NOT NULL,
  `phone_number` varchar(20) NOT NULL,
  `province` varchar(50) NOT NULL,
  `cost` double NOT NULL,
  PRIMARY KEY (`order_id`),
  KEY `fk_username` (`username`),
  KEY `product_id` (`product_id`),
  KEY `style_id` (`style_id`),
  KEY `color_id` (`color_id`),
  KEY `size_id` (`size_id`),
  KEY `isOrderCompleted` (`isOrderCompleted`)
) ENGINE=MyISAM AUTO_INCREMENT=226 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` (`order_id`, `guid`, `product_id`, `style_id`, `color_id`, `size_id`, `quantity`, `username`, `ischeckoutcompleted`, `createDate`, `isOrderCompleted`, `email`, `firstname`, `lastname`, `street_address`, `apt_suite_other`, `city`, `postal_code`, `country_id`, `phone_number`, `province`, `cost`) VALUES (136,'6E208AD6-5DF0-1A2E-024D-669D9EE05602',160,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-08-27 17:34:25',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'','deohieu',0),(137,'3FA6BB65-0A9E-0C9B-69AE-D0B756E3DB8F',160,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-08-27 17:34:35',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'','deohieu',0),(138,'4DACA620-3269-B2A2-1580-C7157C9A100E',155,1,1,2,1,'lahau16@gmail.com',0,'2017-08-27 18:01:40',2,'lahau16@gmail.com','hau','la','quan binh thanh','123','hcm','70000',5,'01234156556','hcm',0),(139,'908F6717-1348-E4A2-B61E-1AF88C321AE5',153,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-08-27 18:02:06',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deohieu',0),(140,'51079E0E-35EF-0200-0CCE-D746BF178C74',153,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-08-27 20:05:13',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deotindc',0),(141,'6FE13C47-F04C-24A3-4E82-2CE79479E133',153,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-08-27 20:20:33',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deotindc',0),(142,'427A138C-C6E9-E1F1-CD74-8680508FD5DA',149,1,2,7,9,'giangtruong.tranluong@gmail.com',0,'2017-08-27 21:23:26',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deotindc',0),(143,'42235F0A-A004-ECA7-76BE-B94276C7290E',160,1,1,4,1,'lahau16@gmail.com',0,'2017-08-27 21:49:02',2,'lahau16@gmail.com','hau','la','quan binh thanh','tgff','hcm','70000',5,'01234156556','hcm',0),(144,'769C62B0-D657-968B-8728-1342E6729AE3',149,1,2,2,1,'giangtruong.tranluong@gmail.com',0,'2017-08-27 22:12:41',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deotindc',0),(145,'FD16982F-102B-7D93-618A-A85CFA9A0A4B',149,1,2,2,1,'giangtruong.tranluong@gmail.com',0,'2017-08-27 22:13:26',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deotindc',0),(146,'3E93FE0A-E84E-21D5-D69A-D94795DA3DCA',149,1,2,2,1,'giangtruong.tranluong@gmail.com',0,'2017-08-27 22:14:41',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deotindc',0),(147,'BA0F4A6F-0B65-D9A9-E888-F8D8999C1C94',160,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-08-27 22:15:24',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deotindc',0),(148,'2D698A76-E466-85FF-9DB6-0AECE89422C7',153,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-08-27 22:55:09',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deotindc',0),(149,'4F741C06-6CCB-4B30-1319-F22F0E8A77BE',159,1,1,8,1,'giangtruong.tranluong@gmail.com',0,'2017-08-28 00:47:17',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deotindc',0),(150,'B5C169FC-DEFF-80E3-5EFD-AB1C9340820F',153,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-08-28 09:24:05',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deotindc',0),(151,'EF4A886A-9846-88A0-C618-9046F0510C40',149,1,2,2,1,'giangtruong.tranluong@gmail.com',0,'2017-08-28 10:22:02',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deotindc',0),(152,'61F0D2F7-9400-1480-FC1C-E67080970F7B',160,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-08-28 10:58:08',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deotindc',0),(153,'011307BB-A262-F6CA-A6DF-944E91A01ECA',159,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-08-28 12:11:41',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deotindc',0),(154,'0BA2D164-1676-CA63-4E44-5E2D98712ECD',142,1,108,2,1,'tuanbanks@gmail.com',0,'2017-08-28 19:14:11',2,'tuanbanks@gmail.com','tun','du','quan binh thanh','dhfh','ho chi minh','700000',1,'0515156516','ho chi minh',0),(155,'09CD265D-6C45-023A-AF92-A9C65277EB66',149,1,2,2,1,'4dpdmen@gmail.com',0,'2017-08-29 20:18:46',2,'4dpdmen@gmail.com','tana','','123456','','123','123456',1,'123456','123',0),(156,'A771A2D8-D302-DDA8-A310-8F7FF6092313',155,1,1,2,1,'lahau16@gmail.com',0,'2017-08-31 12:53:50',2,'lahau16@gmail.com','hau','la','quan binh thanh','sjksks','hcm','70000',5,'01234156556','hcm',0),(157,'FF65C553-C13C-BBB9-B6C4-E8FC01A1F677',153,1,1,7,1,'giangtruong.tranluong@gmail.com',0,'2017-09-01 11:26:43',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deotindc',0),(158,'A263CA12-EA49-62B1-F41D-938FF4496535',159,1,1,2,1,'giangjuve1@yahoo.com',0,'2017-09-01 20:05:27',2,'giangjuve1@yahoo.com','123456','123456','123456','clgt','123456','700000',1,'123456','123456',0),(159,'B636AE9D-9F36-BBE1-316E-1ECDCB4F056F',142,1,108,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-01 21:56:39',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deotindc',0),(160,'EAC5985C-049A-8A5F-5229-9A7BB793E4F5',155,1,1,2,1,'lahau16@gmail.com',0,'2017-09-02 17:09:10',2,'lahau16@gmail.com','hau','la','quan binh thanh','','hcm','70000',5,'01234156556','hcm',0),(161,'B00EED20-8F27-58F9-0998-6A85F2C12E64',153,1,1,2,1,'lahau16@gmail.com',0,'2017-09-03 17:36:46',2,'lahau16@gmail.com','hau','la','quan binh thanh','Ä‘Ã¹','hcm','70000',5,'01234156556','hcm',0),(162,'42BC69CC-ACFE-7164-F478-4BA2B28D2F8B',149,1,2,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-05 19:21:32',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(163,'66C700FA-E557-D03A-9310-1EC12E1C3516',149,1,2,2,1,'tuanbanks@gmail.com',0,'2017-09-06 20:06:08',2,'tuanbanks@gmail.com','tun','du','quan binh thanh','','ho chi minh','700000',1,'78798','ho chi minh',0),(164,'E5715DC2-030B-5030-B9BE-EF1EF9C1212E',163,1,2,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-07 15:50:56',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','apt','hcm','700000',1,'0898190026','deotindc',0),(165,'A866C6DE-32F9-ED36-7021-851FDB00AFE9',168,2,47,2,2,'giangjuve2@yahoo.com',0,'2017-09-09 00:09:25',2,'giangjuve2@yahoo.com','giang','sida','295 mai huynh','trá»³','noi bai','78952165',1,'1645687981','dunno',0),(166,'2C7B91D3-1432-3FEC-D276-755F39D8F8ED',163,1,2,2,1,'giangjuve2@yahoo.com',0,'2017-09-09 00:25:34',2,'giangjuve2@yahoo.com','giang','sida','295 mai huynh','fdsg','noi bai','78952165',5,'1645687981','dunno',0),(167,'D4B89A04-3F87-6E4B-32DD-9C178C92A276',160,1,1,2,1,'giangjuve2@yahoo.com',0,'2017-09-09 00:28:00',2,'giangjuve2@yahoo.com','giang','sida','295 mai huynh','fghfg','noi bai','78952165',5,'1645687981','dunno',0),(168,'8778365A-4D82-0088-AF4F-E7380E23AE5D',155,2,59,2,1,'giangjuve2@yahoo.com',0,'2017-09-09 00:29:32',2,'giangjuve2@yahoo.com','giang','sida','295 mai huynh','43tgr','noi bai','78952165',5,'1645687981','dunno',0),(169,'64A70E76-97C3-8585-DCD0-F2E64E3002E5',149,1,2,2,1,'giangjuve2@yahoo.com',0,'2017-09-09 00:36:24',2,'giangjuve2@yahoo.com','giang','sida','295 mai huynh','Ã©tyt','noi bai','78952165',5,'1645687981','dunno',0),(170,'DE9D9C4F-2A95-7998-2439-5852A5A8AA33',158,1,1,7,1,'giangjuve2@yahoo.com',0,'2017-09-09 00:38:53',2,'giangjuve2@yahoo.com','giang','sida','295 mai huynh','ghfh','noi bai','78952165',5,'1645687981','dunno',0),(171,'BEB30E1B-411E-1A9F-3705-1B57724627C7',155,1,1,8,2,'giangjuve3@yahoo.com',0,'2017-09-09 09:47:36',2,'giangjuve3@yahoo.com','giang','cuteeeee','16 hoang hoa cac','apt','ho chi minh','84',1,'0898190026','ho chi minh',0),(172,'B184F5C0-CE1E-FAD6-2CC0-02D4154445BC',149,1,2,2,1,'giangjuve3@yahoo.com',0,'2017-09-09 10:10:24',2,'giangjuve3@yahoo.com','giang','cuteeeee','16 hoang hoa tham','gdfg','ho chi minh','84',1,'0898190026','ho chi minh',0),(173,'0F88038C-740E-B9F3-3443-2013B39E0B91',163,1,2,2,1,'giangjuve3@yahoo.com',0,'2017-09-09 13:27:46',2,'giangjuve3@yahoo.com','giang','cuteeeee','16 hoang hoa tham','apt','ho chi minh','84',1,'0898190026','ho chi minh',0),(174,'90CF08CC-53C0-6A7D-08EE-FC9F851DF84D',149,1,2,2,1,'giangjuve3@yahoo.com',0,'2017-09-09 13:37:18',2,'giangjuve3@yahoo.com','giang','cuteeeee','16 hoang hoa tham','apt','ho chi minh','84',1,'0898190026','ho chi minh',0),(175,'C76BADAF-5340-0134-F526-C02F06FF28E7',163,1,2,8,2,'giangjuve3@yahoo.com',0,'2017-09-09 14:22:12',2,'giangjuve3@yahoo.com','giang','cuteeeee','16 hoang hoa tham','','ho chi minh','84',1,'0898190026','ho chi minh',0),(176,'0933937B-7014-B969-FF28-08D3874B151F',155,1,1,2,1,'giangjuve3@yahoo.com',0,'2017-09-09 14:44:16',2,'giangjuve3@yahoo.com','giang','cuteeeee','16 hoang hoa tham','','ho chi minh','84',1,'0898190026','ho chi minh',0),(177,'52D19A62-F3C4-DC00-AEF3-0EA392936B76',155,1,1,8,2,'giangjuve3@yahoo.com',0,'2017-09-09 14:44:23',2,'giangjuve3@yahoo.com','giang','cuteeeee','16 hoang hoa tham','','ho chi minh','84',1,'0898190026','ho chi minh',0),(178,'EEF75DB0-D301-D562-46B6-60EDAB299FE5',163,1,2,8,2,'giangtruong.tranluong@gmail.com',0,'2017-09-09 15:06:40',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(179,'6EB7F1E4-407C-BE6A-6687-BBCFDA869F37',155,1,1,8,2,'giangtruong.tranluong@gmail.com',0,'2017-09-09 15:09:14',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(180,'3B7735F2-CB2C-3AE5-F38A-A090ED406F3B',155,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-09 15:56:03',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(181,'5AD1EE70-B929-1F8B-4CDB-27B02CF4B34A',155,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-09 16:10:02',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(182,'79E8ADAF-708D-AEB8-CB12-C7FE791CB09E',155,1,1,8,10,'giangtruong.tranluong@gmail.com',0,'2017-09-09 16:23:08',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(183,'784867D6-1EE4-029D-7C6B-472A4F287BC5',163,1,2,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-09 16:24:26',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(184,'389859D5-26C2-002A-C549-601F9CD702C1',155,1,1,6,2,'giangtruong.tranluong@gmail.com',0,'2017-09-09 16:35:51',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(185,'94B86156-FFE4-E39A-1C86-199B000CBBA9',155,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-09 17:07:31',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(186,'B4712471-09B0-B9B0-7FA4-D0E75210B16B',155,1,1,7,3,'giangjuve2@yahoo.com',0,'2017-09-09 19:59:13',2,'giangjuve2@yahoo.com','giang','sida','295 mai huynh','','noi bai','78952165',1,'1645687981','dunno',0),(187,'32A6BF68-9250-85B8-BA09-9296B09CA511',168,2,47,2,1,'lahau16@gmail.com',0,'2017-09-10 22:25:52',2,'lahau16@gmail.com','hau','la','quan binh thanh','','hcm','70000',1,'01234156556','hcm',0),(188,'92EF02AD-9E04-E82E-BA7C-2C350A97563B',163,1,2,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-10 22:35:51',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(189,'BF99C9F3-5529-870F-46EB-CB4B63CBC004',157,1,1,2,1,'giangjuve2@yahoo.com',0,'2017-09-11 10:53:07',2,'giangjuve2@yahoo.com','giang','sida','295 mai huynh','','noi bai','78952165',5,'1645687981','dunno',0),(190,'B8F609CC-64D9-03F4-C31F-801B42EDBABA',163,1,2,2,1,'giangjuve2@yahoo.com',0,'2017-09-11 10:58:48',2,'giangjuve2@yahoo.com','giang','sida','295 mai huynh','','noi bai','78952165',5,'1645687981','dunno',0),(191,'B503BFE2-3C85-BB8C-5A49-D127CD50A266',163,1,2,2,1,'giangjuve2@yahoo.com',0,'2017-09-11 10:59:11',2,'giangjuve2@yahoo.com','giang','sida','295 mai huynh','','noi bai','78952165',5,'1645687981','dunno',0),(192,'C69E9DB0-BC16-340D-B07F-BE578263DEA6',163,1,2,2,1,'giangjuve2@yahoo.com',0,'2017-09-11 11:52:16',2,'giangjuve2@yahoo.com','giang','sida','295 mai huynh','','noi bai','78952165',5,'1645687981','dunno',0),(193,'D9B39FAB-2820-F7BA-5246-64656F973687',168,2,47,6,1,'giangjuve2@yahoo.com',0,'2017-09-11 11:55:46',2,'giangjuve2@yahoo.com','giang','sida','295 mai huynh','','noi bai','78952165',5,'1645687981','dunno',0),(194,'99B8745A-23A4-CF23-160A-9F79229FF5B5',168,2,47,2,1,'giangjuve2@yahoo.com',0,'2017-09-11 16:15:14',2,'PatsyATopping@armyspy.com','Patsy ','A. Topping','4783 Lowndes Hill Park Road','','Bakersfield','93307',1,'661-444-3341','California',0),(195,'2A9D6D88-1A17-F98E-6128-1B0F16EF30C2',163,1,2,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-13 19:53:45',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(196,'3A238726-AAA2-EA82-7D27-AF29AF7CCD74',155,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-13 23:09:36',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(197,'CF8AD5F7-A028-BF17-A9CD-34521376CAB4',155,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-14 00:13:39',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(198,'E7803267-675D-64E6-2DFE-9DAF714728C9',155,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-14 00:14:47',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(199,'7B578CC8-F3C2-42EB-FF49-8B3757ADE22F',155,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-14 08:56:01',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(200,'49261FF4-998C-462D-ACD0-A29B22B091B8',155,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-14 09:07:06',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(201,'38CE0925-B614-D9F0-294F-E6490CBCD9D7',155,1,1,7,2,'giangtruong.tranluong@gmail.com',0,'2017-09-14 11:48:35',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(202,'C78FECAB-3E13-48C5-096F-2BC0AB955AED',155,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-14 12:19:55',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(203,'701AAC6D-82AE-C38B-01E8-D3DF41B91895',163,1,2,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-14 12:24:11',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(204,'03CE3894-80E4-764F-6B35-FB72AFB346F0',163,1,2,2,1,'giangtruong.tranluong@gmail.com',1,'2017-09-14 12:51:37',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',20.4825),(205,'E1C5F00D-C39C-4A51-DECC-06EF17BCCA5E',155,1,1,2,1,'giangtruong.tranluong@gmail.com',1,'2017-09-14 12:56:15',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',25.98),(206,'DD99D7CA-3EB2-F58A-96A7-E33AB792CCE9',192,1,1,2,1,'hoang.nguyen142536@gmail.com',1,'2017-09-14 20:53:29',2,'hoang.nguyen142536@gmail.com','234234468468','hoang','42342','','423423','23423423',1,'0934162993','423423',23.781),(207,'36CF512C-1DC1-F0E0-B7B8-2FE24293CC81',192,1,1,2,1,'hoang.nguyen142536@gmail.com',1,'2017-09-14 22:33:21',2,'hoang.nguyen142536@gmail.com','234234468468','hoang','42342','','423423','23423423',1,'0934162993','423423',23.781),(208,'81B30C10-6C70-A9EA-5D0F-E37959F305CE',188,1,1,2,1,'hoang.nguyen142536@gmail.com',1,'2017-09-14 22:38:29',2,'hoang.nguyen142536@gmail.com','234234468468','h','42342','','423423','23423423',1,'0934162993','423423',23.781),(209,'111CE8D1-77B2-2FF3-6635-EFD175C770BE',188,1,14,3,1,'tuanbanks1@gmail.com',1,'2017-09-16 11:34:56',2,'tuanbanks1@gmail.com','minh','tuan','quan binh thanh','','hcm','700000',7,'0909999999','hcm',32.291),(210,'6A3C9DA1-07E0-F262-8D3E-C92EF1762D59',188,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-16 13:05:46',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(211,'731AA6BE-0852-3D17-31F7-B04E9E877325',188,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-16 13:09:07',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(212,'34E1D18B-6DFE-EF23-3841-B7E55A25193E',188,1,1,2,1,'tuanbanks@gmail.com',1,'2017-09-16 14:56:22',2,'tuanbanks@gmail.com','tun','du','quan binh thanh','','ho chi minh','700000',1,'78798','ho chi minh',23.781),(213,'F80939DB-F368-8DBF-F4EF-DD68FFF76DD5',190,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-16 14:57:34',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(214,'C7996220-A6B1-B231-800C-2DA38954956E',188,1,1,2,1,'giangtruong.tranluong@gmail.com',1,'2017-09-16 14:58:30',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',25.98),(215,'76C14557-68B4-9B79-8AB5-6CD81B6CA0DA',188,1,1,2,1,'tuanbanks@gmail.com',1,'2017-09-16 15:02:19',2,'tuanbanks@gmail.com','tun','du','quan binh thanh','','ho chi minh','700000',1,'78798','ho chi minh',23.781),(216,'7114E7F0-C6E4-ADE4-7E76-EB15CAE854AE',187,1,14,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-16 16:16:23',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(217,'000D0914-0F57-4712-6729-F4B46DE6ECB2',192,1,1,2,1,'giangfetel@gmail.com',0,'2017-09-16 16:25:41',2,'giangfetel@gmail.com','giang','truong','cac','','lon','84',1,'0898190026','chim',0),(218,'165B6C3F-97DE-B0BA-F10A-2EC4AF676CD5',188,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-17 10:33:18',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(219,'3BFF5B86-0F70-D9D0-04B4-AD74AB9899E9',188,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-27 06:01:01',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(220,'0300E20A-631A-2F9C-AB7B-D6CC1452D01D',188,1,1,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-27 07:31:42',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(221,'A7B1B210-9F26-0D45-DB0D-E46A1C9D1FBC',187,1,14,2,1,'giangtruong.tranluong@gmail.com',0,'2017-09-28 21:06:09',2,'giangtruong.tranluong@gmail.com','giang','cute','16 hht','','hcm','700000',1,'0898190026','deotindc',0),(222,'0702C5B9-C586-F9C8-6F14-052F0C83533D',187,1,14,2,1,'4dpdmen@gmail.com',0,'2017-09-30 02:54:56',2,'4dpdmen@gmail.com','tana','','123456','','123','123456',1,'123456','123',0),(223,'14C3F962-FDD1-E423-BB3A-0ECEC425A9FB',127,1,1,2,1,'hoang.nguyen142536@gmail.com',0,'2017-10-02 00:10:32',2,'hoang.nguyen142536@gmail.com','234234468468','234','42342','','423423','23423423',1,'234','423423',0),(224,'B75D3343-8B83-1A81-0E0B-CFDCE1D7EF86',188,1,1,2,1,'4dpdmen@gmail.com',0,'2017-10-03 07:08:41',2,'4dpdmen@gmail.com','tana','cac','123456','','123','123456',1,'123456','123',0),(225,'B6310FF0-8F66-FE8E-22A3-5432A7C6E96F',188,1,1,2,1,'hoang.nguyen142536@gmail.com',0,'2017-10-09 19:18:15',2,'hoang.nguyen142536@gmail.com','234234468468','234234234','42342','','423423','23423423',1,'0934162993','423423',0);
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_admin_permission`
--

DROP TABLE IF EXISTS `order_admin_permission`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_admin_permission` (
  `id` smallint(6) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_admin_permission`
--

LOCK TABLES `order_admin_permission` WRITE;
/*!40000 ALTER TABLE `order_admin_permission` DISABLE KEYS */;
INSERT INTO `order_admin_permission` (`id`, `name`) VALUES (1,'Guest'),(2,'Administrator'),(3,'Addproducter'),(4,'OrderExer'),(5,'UserManager');
/*!40000 ALTER TABLE `order_admin_permission` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_admin_tracking_login`
--

DROP TABLE IF EXISTS `order_admin_tracking_login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_admin_tracking_login` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `logindate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `logoutdate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `fk_group` (`username`)
) ENGINE=MyISAM AUTO_INCREMENT=369 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_admin_tracking_login`
--

LOCK TABLES `order_admin_tracking_login` WRITE;
/*!40000 ALTER TABLE `order_admin_tracking_login` DISABLE KEYS */;
INSERT INTO `order_admin_tracking_login` (`id`, `username`, `logindate`, `logoutdate`) VALUES (357,'giang','2017-09-16 12:24:22','2017-09-16 14:55:13'),(356,'giang','2017-09-15 18:48:22','2017-09-15 18:48:22'),(355,'tuan','2017-09-15 17:39:13','2017-09-15 19:01:10'),(354,'hoang','2017-09-14 22:58:36','2017-09-14 23:06:37'),(353,'giang','2017-09-14 20:21:40','2017-09-14 21:17:13'),(352,'thuan','2017-09-14 20:12:40','2017-09-14 21:10:58'),(351,'thuan','2017-09-14 18:53:29','2017-09-14 20:02:24'),(350,'giang','2017-09-14 18:52:08','2017-09-14 20:00:10'),(349,'giang','2017-09-14 18:47:32','2017-09-14 18:51:16'),(348,'giang','2017-09-14 18:05:45','2017-09-14 18:10:15'),(347,'giang','2017-09-14 17:58:34','2017-09-14 18:10:15'),(346,'giang','2017-09-14 17:52:33','2017-09-14 17:58:20'),(345,'giang','2017-09-14 17:40:51','2017-09-14 17:51:21'),(344,'giang','2017-09-14 17:32:50','2017-09-14 17:35:59'),(343,'giang','2017-09-14 17:29:26','2017-09-14 17:32:34'),(342,'giang','2017-09-14 17:23:21','2017-09-14 17:29:13'),(341,'giang','2017-09-14 17:00:52','2017-09-14 17:21:35'),(340,'giang','2017-09-14 16:02:21','2017-09-14 16:16:58'),(339,'giang','2017-09-14 09:37:19','2017-09-14 09:47:48'),(338,'hoang','2017-09-12 18:10:25','2017-09-12 18:14:15'),(337,'hoang','2017-09-11 11:43:18','2017-09-11 11:43:27'),(336,'hoang','2017-09-11 11:36:05','2017-09-11 11:36:37'),(335,'hoang','2017-09-11 10:54:52','2017-09-11 10:55:07'),(334,'hoang','2017-09-11 10:51:48','2017-09-11 10:51:48'),(332,'hoang','2017-09-11 10:49:24','2017-09-11 10:49:41'),(333,'hoang','2017-09-11 10:51:02','2017-09-11 10:51:07'),(361,'hoang','2017-10-01 23:12:48','2017-10-01 23:15:37'),(368,'giang','2017-10-11 03:39:23','2017-10-11 03:45:09'),(367,'giang','2017-10-10 08:45:42','2017-10-10 08:51:29'),(358,'giang','2017-09-29 20:59:32','2017-09-29 21:00:07'),(360,'hoang','2017-10-01 22:44:42','2017-10-01 22:44:42'),(366,'giang','2017-10-07 20:29:06','2017-10-07 21:43:17'),(359,'giang','2017-09-30 19:27:27','2017-09-30 19:27:27'),(362,'hoang','2017-10-01 23:16:04','2017-10-01 23:17:18'),(363,'hoang','2017-10-01 23:17:38','2017-10-01 23:22:00'),(364,'hoang','2017-10-01 23:24:03','2017-10-01 23:24:27'),(365,'giang','2017-10-03 07:07:37','2017-10-03 07:10:30');
/*!40000 ALTER TABLE `order_admin_tracking_login` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_admin_user`
--

DROP TABLE IF EXISTS `order_admin_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_admin_user` (
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `permission_id` smallint(6) NOT NULL,
  `firstname` varchar(20) NOT NULL,
  `lastname` varchar(20) NOT NULL,
  `Issupper` tinyint(1) NOT NULL,
  PRIMARY KEY (`username`),
  KEY `fk_permission` (`permission_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_admin_user`
--

LOCK TABLES `order_admin_user` WRITE;
/*!40000 ALTER TABLE `order_admin_user` DISABLE KEYS */;
INSERT INTO `order_admin_user` (`username`, `password`, `permission_id`, `firstname`, `lastname`, `Issupper`) VALUES ('admin','21232f297a57a5a743894a0e4a801fc3',2,'App','Admin',0),('tuan','691b4e31bc41a8c7e6ebd278af2115d0',2,'Tuan','Du',1),('giang','b922e6b4962886835dbed77405626cfb',2,'Giang','Ngu',1),('thang','e10adc3949ba59abbe56e057f20f883e',2,'Thang','Ha',0),('tana','f1330007bd5955a3341d76e88d802261',2,'Tan','So gai',0),('dat','e10adc3949ba59abbe56e057f20f883e',2,'Dat','La',0),('hoang','b7e0c00e1e30354c930528ca82b3a3ee',2,'Hoang','Pro',1),('Unknown','e10adc3949ba59abbe56e057f20f883e',1,'Un','known',0),('hau','1bacaf2ed566eb9255043bab6811e50f',2,'La','Hau',0),('thuan','62dcd02a3a2417785bd58e56c79051b3',2,'Thuan','Pham',0);
/*!40000 ALTER TABLE `order_admin_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_country`
--

DROP TABLE IF EXISTS `order_country`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_country` (
  `country_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `country_name` varchar(100) NOT NULL,
  `country_region` int(11) NOT NULL,
  `ship_cost` double NOT NULL,
  `ship_per_item_cost` double NOT NULL,
  `flashformid` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`country_id`)
) ENGINE=MyISAM AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_country`
--

LOCK TABLES `order_country` WRITE;
/*!40000 ALTER TABLE `order_country` DISABLE KEYS */;
INSERT INTO `order_country` (`country_id`, `country_name`, `country_region`, `ship_cost`, `ship_per_item_cost`, `flashformid`) VALUES (1,'United States',4,3.99,2,1),(2,'Canada\r\n',1,9.5,4,1),(3,'Brazil',1,12.5,4,1),(4,'Mexico\r\n',1,12.5,4,1),(5,'Germany\r\n',2,12.5,4,1),(6,'France\r\n',2,12.5,4,1),(7,'United Kingdom\r\n',2,12.5,4,1),(8,'Austria\r\n',2,12.5,4,1),(9,'Finland\r\n',2,12.5,4,1),(10,'Italia\r\n',2,12.5,4,1),(11,'Australia\r\n',3,12.5,4,1),(12,'Sweden\r\n',2,12.5,4,1),(13,'Netherlands\r\n',2,12.5,4,1);
/*!40000 ALTER TABLE `order_country` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_deleted`
--

DROP TABLE IF EXISTS `order_deleted`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_deleted` (
  `order_id` bigint(20) NOT NULL,
  `guid` varchar(36) NOT NULL,
  `product_id` bigint(20) NOT NULL,
  `style_id` bigint(20) NOT NULL,
  `color_id` bigint(20) NOT NULL,
  `size_id` bigint(20) NOT NULL,
  `quantity` int(11) NOT NULL,
  `username` varchar(20) NOT NULL,
  `ischeckoutcompleted` tinyint(1) NOT NULL DEFAULT '0',
  `createDate` datetime NOT NULL,
  `isOrderCompleted` smallint(6) NOT NULL DEFAULT '3',
  `email` varchar(50) NOT NULL,
  `firstname` varchar(30) NOT NULL,
  `lastname` varchar(30) NOT NULL,
  `street_address` varchar(30) NOT NULL,
  `apt_suite_other` varchar(30) NOT NULL,
  `city` varchar(30) NOT NULL,
  `postal_code` varchar(10) NOT NULL,
  `country_id` int(11) NOT NULL,
  `phone_number` varchar(20) NOT NULL,
  `province` varchar(50) NOT NULL,
  `cost` int(11) NOT NULL,
  PRIMARY KEY (`order_id`),
  KEY `fk_username` (`username`),
  KEY `product_id` (`product_id`),
  KEY `style_id` (`style_id`),
  KEY `color_id` (`color_id`),
  KEY `size_id` (`size_id`),
  KEY `isOrderCompleted` (`isOrderCompleted`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_deleted`
--

LOCK TABLES `order_deleted` WRITE;
/*!40000 ALTER TABLE `order_deleted` DISABLE KEYS */;
/*!40000 ALTER TABLE `order_deleted` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_flashform`
--

DROP TABLE IF EXISTS `order_flashform`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_flashform` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_flashform`
--

LOCK TABLES `order_flashform` WRITE;
/*!40000 ALTER TABLE `order_flashform` DISABLE KEYS */;
INSERT INTO `order_flashform` (`id`, `name`) VALUES (1,'Teespring'),(2,'Sunfrog');
/*!40000 ALTER TABLE `order_flashform` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_guest_tracking`
--

DROP TABLE IF EXISTS `order_guest_tracking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_guest_tracking` (
  `tracking_ip` varchar(20) NOT NULL,
  `tracking_mail` varchar(100) DEFAULT NULL,
  `tracking_time` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_guest_tracking`
--

LOCK TABLES `order_guest_tracking` WRITE;
/*!40000 ALTER TABLE `order_guest_tracking` DISABLE KEYS */;
INSERT INTO `order_guest_tracking` (`tracking_ip`, `tracking_mail`, `tracking_time`) VALUES ('14.161.14.188',NULL,'2017-07-26 06:39:20'),('171.232.239.37',NULL,'2017-07-26 02:25:31'),('115.79.192.142',NULL,'2017-07-30 07:42:36'),('115.79.192.142',NULL,'2017-07-30 08:05:51'),('118.69.224.30',NULL,'2017-07-31 02:59:33'),('171.232.236.177',NULL,'2017-08-01 02:15:14'),('171.232.236.177',NULL,'2017-08-01 02:42:24'),('171.232.239.58',NULL,'2017-08-02 11:57:47'),('27.77.147.228',NULL,'2017-08-03 03:56:07'),('171.232.239.67',NULL,'2017-08-04 11:44:32'),('27.77.122.35',NULL,'2017-08-04 02:45:14'),('14.161.14.188',NULL,'2017-08-07 08:34:20'),('27.3.129.214',NULL,'2017-08-09 04:13:10'),('113.172.108.148',NULL,'2017-08-14 12:48:08'),('14.161.14.188',NULL,'2017-08-16 10:20:28'),('14.161.14.188',NULL,'2017-08-16 10:21:10'),('171.232.236.80',NULL,'2017-08-20 04:56:22'),('171.232.236.80',NULL,'2017-08-20 04:58:00'),('171.232.236.80',NULL,'2017-08-20 04:58:43'),('171.232.236.80',NULL,'2017-08-20 05:29:10'),('171.232.236.80',NULL,'2017-08-20 10:12:01'),('123.21.23.101',NULL,'2017-08-21 01:43:00'),('123.20.35.209',NULL,'2017-08-21 08:58:54'),('115.77.75.176',NULL,'2017-08-27 02:48:31'),('42.116.23.105',NULL,'2017-08-28 09:16:01'),('171.232.236.175',NULL,'2017-08-28 12:28:05'),('14.186.238.59',NULL,'2017-08-28 04:54:25'),('171.232.239.29',NULL,'2017-08-30 12:17:00'),('171.248.118.178',NULL,'2017-08-31 04:30:26'),('171.248.118.178',NULL,'2017-08-31 04:30:46'),('27.77.125.237',NULL,'2017-08-31 09:09:27'),('27.77.125.237',NULL,'2017-08-31 09:25:47'),('27.77.125.237',NULL,'2017-08-31 02:44:30'),('116.109.178.196',NULL,'2017-09-01 04:23:47'),('116.109.178.196',NULL,'2017-09-01 04:24:22'),('42.116.23.108',NULL,'2017-09-01 04:37:35'),('42.116.23.108',NULL,'2017-09-01 04:38:03'),('42.116.23.110',NULL,'2017-09-01 04:39:22'),('14.161.14.188',NULL,'2017-09-01 04:39:37'),('14.161.14.188',NULL,'2017-09-01 04:43:51'),('27.3.129.139',NULL,'2017-09-01 04:22:35'),('27.3.129.139',NULL,'2017-09-01 04:23:42'),('27.3.129.139',NULL,'2017-09-01 04:23:57'),('27.3.129.139',NULL,'2017-09-01 04:24:09'),('171.233.155.5',NULL,'2017-09-01 04:54:05'),('27.64.92.85',NULL,'2017-09-01 05:02:21'),('171.233.155.5',NULL,'2017-09-01 05:02:44'),('27.64.92.85',NULL,'2017-09-01 05:05:21'),('27.64.92.85',NULL,'2017-09-01 05:05:42'),('27.3.129.139',NULL,'2017-09-01 05:11:36'),('27.3.129.139',NULL,'2017-09-01 05:12:11'),('27.3.129.139',NULL,'2017-09-01 05:12:27'),('27.64.92.85',NULL,'2017-09-01 05:13:20'),('27.64.92.85',NULL,'2017-09-01 05:13:28'),('27.64.92.85',NULL,'2017-09-01 05:13:34'),('27.64.92.85',NULL,'2017-09-01 05:14:03'),('27.64.92.85',NULL,'2017-09-01 05:14:13'),('27.64.92.85',NULL,'2017-09-01 05:14:21'),('27.64.92.85',NULL,'2017-09-01 05:14:28'),('27.64.92.85',NULL,'2017-09-01 05:14:40'),('27.64.92.85',NULL,'2017-09-01 05:14:42'),('27.64.92.85',NULL,'2017-09-01 05:14:56'),('27.64.92.85',NULL,'2017-09-01 05:15:26'),('27.64.92.85',NULL,'2017-09-01 05:16:59'),('171.233.155.5',NULL,'2017-09-01 05:50:42'),('171.233.155.5',NULL,'2017-09-05 02:16:52'),('171.232.239.243',NULL,'2017-09-06 12:11:41'),('171.232.239.243',NULL,'2017-09-06 12:12:15'),('27.64.92.85',NULL,'2017-09-06 01:41:40'),('112.78.13.106',NULL,'2017-09-07 06:01:12'),('112.78.13.106',NULL,'2017-09-07 07:42:24'),('27.74.245.80',NULL,'2017-09-08 02:38:13'),('14.187.46.234',NULL,'2017-09-08 04:45:14'),('14.187.46.234',NULL,'2017-09-08 04:55:35'),('171.232.238.164',NULL,'2017-09-09 06:32:41'),('171.232.238.164',NULL,'2017-09-09 08:55:39'),('123.21.7.164',NULL,'2017-09-10 03:43:14'),('113.172.114.233',NULL,'2017-09-11 04:57:06'),('171.232.239.54',NULL,'2017-09-13 11:58:11'),('171.232.239.71',NULL,'2017-09-14 02:38:19'),('116.102.147.119',NULL,'2017-09-14 09:41:08'),('171.232.238.60',NULL,'2017-09-14 10:12:07'),('171.232.238.60',NULL,'2017-09-14 10:14:36'),('42.116.23.107',NULL,'2017-09-14 10:16:53'),('171.232.238.60',NULL,'2017-09-14 10:42:05'),('171.232.238.60',NULL,'2017-09-14 11:25:40'),('171.232.238.60',NULL,'2017-09-14 11:50:06'),('171.232.238.60',NULL,'2017-09-14 11:50:29'),('171.232.238.60',NULL,'2017-09-14 11:50:38'),('171.232.238.60',NULL,'2017-09-14 11:50:50'),('171.232.238.60',NULL,'2017-09-14 11:51:08'),('171.232.238.60',NULL,'2017-09-14 11:51:27'),('171.232.238.60',NULL,'2017-09-14 11:51:46'),('171.232.238.60',NULL,'2017-09-14 11:52:10'),('171.232.238.60',NULL,'2017-09-14 11:52:28'),('171.232.238.60',NULL,'2017-09-14 11:54:31'),('171.232.238.60',NULL,'2017-09-14 11:55:07'),('171.232.238.60',NULL,'2017-09-14 11:56:57'),('171.232.238.60',NULL,'2017-09-14 11:57:05'),('171.232.238.60',NULL,'2017-09-14 11:57:22'),('171.232.238.60',NULL,'2017-09-14 11:57:35'),('171.232.238.60',NULL,'2017-09-14 11:58:11'),('171.232.238.60',NULL,'2017-09-14 11:58:36'),('171.232.238.60',NULL,'2017-09-14 11:58:49'),('171.232.238.60',NULL,'2017-09-14 11:59:01'),('171.232.238.60',NULL,'2017-09-14 11:59:13'),('171.232.238.60',NULL,'2017-09-14 11:59:41'),('171.232.238.60',NULL,'2017-09-14 11:59:50'),('171.232.238.60',NULL,'2017-09-14 12:00:00'),('171.232.238.60',NULL,'2017-09-14 12:00:35'),('171.232.238.60',NULL,'2017-09-14 12:57:39'),('171.232.238.60',NULL,'2017-09-14 12:58:02'),('171.232.238.60',NULL,'2017-09-14 12:58:11'),('171.232.238.60',NULL,'2017-09-14 12:58:20'),('171.232.238.60',NULL,'2017-09-14 12:58:32'),('171.232.238.60',NULL,'2017-09-14 12:58:41'),('171.232.238.60',NULL,'2017-09-14 12:58:53'),('171.232.238.60',NULL,'2017-09-14 12:59:09'),('171.232.238.60',NULL,'2017-09-14 12:59:55'),('171.232.238.60',NULL,'2017-09-14 01:00:16'),('171.232.238.60',NULL,'2017-09-14 01:01:25'),('171.232.238.60',NULL,'2017-09-14 01:01:44'),('171.232.238.60',NULL,'2017-09-14 01:02:32'),('171.232.238.60',NULL,'2017-09-14 01:02:52'),('171.232.238.60',NULL,'2017-09-14 01:03:07'),('171.232.238.60',NULL,'2017-09-14 01:10:45'),('171.232.238.60',NULL,'2017-09-14 01:11:08'),('171.232.238.60',NULL,'2017-09-14 01:11:30'),('171.232.238.60',NULL,'2017-09-14 01:11:42'),('171.232.238.60',NULL,'2017-09-14 01:12:01'),('171.232.238.60',NULL,'2017-09-14 01:12:11'),('171.232.238.60',NULL,'2017-09-14 01:13:14'),('171.232.238.60',NULL,'2017-09-14 01:14:34'),('171.232.238.60',NULL,'2017-09-14 01:15:22'),('171.232.238.60',NULL,'2017-09-14 01:15:32'),('171.232.238.60',NULL,'2017-09-14 01:15:43'),('171.232.238.60',NULL,'2017-09-14 01:16:46'),('171.232.238.60',NULL,'2017-09-14 01:17:00'),('171.232.238.60',NULL,'2017-09-14 01:17:10'),('171.232.238.60',NULL,'2017-09-14 01:17:20'),('171.232.238.60',NULL,'2017-09-14 01:17:41'),('171.232.238.60',NULL,'2017-09-14 01:17:50'),('171.232.238.60',NULL,'2017-09-14 01:18:10'),('171.232.238.60',NULL,'2017-09-14 01:18:20'),('171.232.238.60',NULL,'2017-09-14 01:18:27'),('171.232.238.60',NULL,'2017-09-14 01:18:37'),('171.232.238.60',NULL,'2017-09-14 01:19:24'),('171.232.238.60',NULL,'2017-09-14 01:19:54'),('171.232.238.60',NULL,'2017-09-14 01:20:14'),('171.232.238.60',NULL,'2017-09-14 01:20:22'),('171.232.238.60',NULL,'2017-09-14 01:20:40'),('171.232.238.60',NULL,'2017-09-14 01:20:56'),('171.232.238.60',NULL,'2017-09-14 01:21:07'),('123.21.7.164',NULL,'2017-09-16 04:29:45'),('123.21.7.164',NULL,'2017-09-16 04:29:57'),('27.77.122.162',NULL,'2017-09-16 05:47:23'),('27.77.122.162',NULL,'2017-09-16 09:12:37'),('115.74.98.200',NULL,'2017-09-27 12:53:55'),('116.100.39.150',NULL,'2017-09-27 02:30:26'),('123.20.50.104',NULL,'2017-10-05 01:14:36'),('123.21.24.131',NULL,'2017-10-07 02:51:03'),('171.232.0.242',NULL,'2017-10-09 03:52:07'),('42.116.23.109',NULL,'2017-10-11 10:40:41');
/*!40000 ALTER TABLE `order_guest_tracking` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_mail_tracking`
--

DROP TABLE IF EXISTS `order_mail_tracking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_mail_tracking` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `email` varchar(100) NOT NULL,
  `product_id` bigint(20) NOT NULL,
  `style_id` bigint(11) NOT NULL,
  `color_id` bigint(11) NOT NULL,
  `date` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `style_id` (`style_id`),
  KEY `color_id` (`color_id`)
) ENGINE=MyISAM AUTO_INCREMENT=52 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_mail_tracking`
--

LOCK TABLES `order_mail_tracking` WRITE;
/*!40000 ALTER TABLE `order_mail_tracking` DISABLE KEYS */;
INSERT INTO `order_mail_tracking` (`id`, `email`, `product_id`, `style_id`, `color_id`, `date`) VALUES (48,'boycodon9x2007@gmail.com',149,4,21,'2017-09-11 11:32:11'),(49,'tuanbanks2@gmail.com',187,1,5,'2017-09-16 11:31:12'),(50,'tuanbanks@gmail.com',132,1,3,'2017-09-16 12:47:50'),(51,'cac@gmail.com',188,1,1,'2017-09-17 12:42:40');
/*!40000 ALTER TABLE `order_mail_tracking` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_options`
--

DROP TABLE IF EXISTS `order_options`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_options` (
  `option_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `option_name` varchar(50) NOT NULL,
  `option_value` varchar(50) NOT NULL,
  PRIMARY KEY (`option_id`)
) ENGINE=MyISAM AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_options`
--

LOCK TABLES `order_options` WRITE;
/*!40000 ALTER TABLE `order_options` DISABLE KEYS */;
INSERT INTO `order_options` (`option_id`, `option_name`, `option_value`) VALUES (1,'WebUrl','https://zeeping.com'),(3,'FTPHost','zeeping.com'),(4,'FTPUser','zeeping'),(5,'FTPPassword','Asd@12345'),(6,'PathImageURL','/image/Design/'),(7,'UserGmailNoReply','zeeping.shop@gmail.com'),(8,'PasswordGmailNoReply','Asd123456'),(9,'SubjectSupportForm','Support - Zeeping: Reply your questions'),(10,'UserGmailSupport','zeeping.shop@gmail.com'),(11,'PasswordGmailSupport','Asd123456'),(12,'DateClearTicket','30'),(13,'DateClearLogin','30'),(14,'IsTestPayPal','0'),(15,'ContentProductRoot','products'),(16,'IamgeProductRoot','image/productimage'),(2,'WebUrlWWW','https://www.zeeping.com'),(18,'Version','v5.1'),(19,'releaseLocation','public_html/release'),(20,'PathImageCollections','image/collections');
/*!40000 ALTER TABLE `order_options` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_product`
--

DROP TABLE IF EXISTS `order_product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_product` (
  `product_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `product_name` varchar(100) NOT NULL,
  `product_image_design` varchar(100) NOT NULL,
  `product_title` varchar(100) NOT NULL,
  `product_content` varchar(1000) NOT NULL,
  `product_link` varchar(100) NOT NULL,
  `style_list` varchar(100) NOT NULL DEFAULT 'a',
  `color_list` varchar(1500) NOT NULL,
  `style_design` varchar(1000) NOT NULL,
  `sellerCount` int(11) NOT NULL DEFAULT '0',
  `createdDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `isFeaturedProduct` tinyint(1) NOT NULL DEFAULT '0',
  `linkFeaturedImage` varchar(100) NOT NULL,
  `linkProduct` varchar(100) NOT NULL,
  `Catogarys` varchar(50) NOT NULL,
  `rangcost` varchar(50) NOT NULL,
  `hashtag` varchar(200) NOT NULL,
  `flashformid` int(11) NOT NULL DEFAULT '1',
  `isFrontVision` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`product_id`),
  KEY `flashformid` (`flashformid`)
) ENGINE=MyISAM AUTO_INCREMENT=194 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_product`
--

LOCK TABLES `order_product` WRITE;
/*!40000 ALTER TABLE `order_product` DISABLE KEYS */;
INSERT INTO `order_product` (`product_id`, `product_name`, `product_image_design`, `product_title`, `product_content`, `product_link`, `style_list`, `color_list`, `style_design`, `sellerCount`, `createdDate`, `isFeaturedProduct`, `linkFeaturedImage`, `linkProduct`, `Catogarys`, `rangcost`, `hashtag`, `flashformid`, `isFrontVision`) VALUES (141,'ARMY MON IS A PRIVILEGE','armyMom.png,None','ARMY MOM IS A PRIVILEGE','<h2>ARMY MON IS A PRIVILEGE shirt</h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/army-mon-is-a-privilege','3,7','var color_pro = {c75:\"#22488F\",c73:\"#D1D1D1\",c82:\"#ea80ac\",c80:\"#222222\",c89:\"#000000\",c92:\"#222223\",c91:\"#02021E\",};','var product_pro = {s3 :{cl :\"75,73,82,80\", t :\"183!169@160!187\", s :\"0!0@0!0\", },s7 :{cl :\"89,92,91\", t :\"189!247@155!187\", s :\"0!0@0!0\", },}',0,'2017-08-03 22:30:21',0,'army-mon-is-a-privilege-1.jpg','army-mon-is-a-privilege-1','3','$22.99 - $26.99','',1,1),(127,'UNITED STATES VETERAN','None,Vereran_Army.png','UNITED STATES VETERAN','UNITED STATES VETERAN shirt<br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s).  <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt<br/>','https://teespring.com/united-states-vetera','1,2','var color_pro = {c1:\"#1a1a1a\",c2:\"#0A1339\",c14:\"#3f3f38\",c46:\"#222222\",c59:\"#1c3d28\",c47:\"#262C50\",};','var product_pro = {s1 :{cl :\"1,2,14\", t :\"0!0@0!0\", s :\"171!98@166!252\", },s2 :{cl :\"46,59,47\", t :\"0!0@0!0\", s :\"169!137@177!261\", },}',0,'2017-07-27 21:45:34',1,'united-states-veteran-1.jpg','united-states-veteran-1','2','$21.99 - $38.99','True',1,0),(193,'We dont know them all but we owe them all','weknowthem.png,None','We dont know them all but we owe them all','<H2>We dont know them all but we owe them all</H2><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/we-dont-know-them-all-but-we-o','1,2','var color_pro = {c1:\"#1a1a1a\",c3:\"#3A4B98\",c15:\"#5c739c\",c5:\"#134522\",c14:\"#3f3f38\",c46:\"#222222\",c59:\"#1c3d28\",c47:\"#262C50\",c49:\"#014A8E\",c60:\"#1f6522\",c53:\"#676769\",};','var product_pro = {s1 :{cl :\"1,3,15,5,14\", t :\"169!105@185!205\", s :\"0!0@0!0\", },s2 :{cl :\"46,59,47,49,60,53\", t :\"169!154@181!187\", s :\"0!0@0!0\", },}',0,'2017-10-07 20:37:16',1,'we-dont-know-them-all-but-we-owe-them-all.jpg','we-dont-know-them-all-but-we-owe-them-all','2','$21.99 - $38.99','veteransday,veteransmemorialsday,veteransweowe,wedontknowthemall,wedontknowthemallweowethemmemorialdaytee,wedontknowthemallweowethemmemorialdaytee1,weoweourveterans,weowethemall,weowethemallshirt,weow',1,1),(128,'FREEDOM ISNOT FREE WE PAID FOR IT ','freedomnotfree.png,None','FREEDOM ISN\'T FREE! WE PAID FOR IT','<h2>FREEDOM ISN\'T FREE! WE PAID FOR IT shirt</h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/new-freedom-isn-t-free-we-pa','1,2,5','var color_pro = {c1:\"#1a1a1a\",c2:\"#0A1339\",c14:\"#3f3f38\",c46:\"#222222\",c47:\"#262C50\",c60:\"#1f6522\",c35:\"#222222\",c36:\"#262C50\",c44:\"#494A4D\",};','var product_pro = {s1 :{cl :\"1,2,14\", t :\"176!98@178!258\", s :\"0!0@0!0\", },s2 :{cl :\"46,47,60\", t :\"170!132@193!257\", s :\"0!0@0!0\", },s5 :{cl :\"35,36,44\", t :\"179!194@181!252\", s :\"0!0@0!0\", },}',1,'2017-07-27 23:36:29',1,'freedom-isnot-free-we-paid-for-it--1.jpg','freedom-isnot-free-we-paid-for-it--1','2','$21.99 - $38.99','freedomamerican,freedomamericantshirt,freedomandflaghoodie,freedomandflagshirt,freedomandflagtee,freedomandflagtshirt,freedomandjustice,freedomart,freedomtshirts,freedomtshirtsseaside',1,1),(129,'MARINE ASSAULTMAN','MARINEASSAULTMAN.png,None','MARINE ASSAULTMAN','<h2>MARINE ASSAULTMAN IT shirt</h2><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/marine-assaultman','1,2','var color_pro = {c18:\"#D6D5D5\",c15:\"#5c739c\",c3:\"#3A4B98\",c48:\"#C3C0C6\",c58:\"#827F77\",c53:\"#676769\",c49:\"#014A8E\",};','var product_pro = {s1 :{cl :\"18,15,3\", t :\"175!116@175!200\", s :\"0!0@0!0\", },s2 :{cl :\"48,58,53,49\", t :\"175!165@169!180\", s :\"0!0@0!0\", },}',0,'2017-07-30 10:58:42',0,'marine-assaultman-1.jpg','marine-assaultman-1','2','$21.99 - $38.99','',1,1),(130,'THIS WELL DEFEND','THISWELLDEFEND.png,None','THIS WE\'LL DEFEND','<h2>THIS WE\'LL DEFEND shirt</h2><br/><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/this-we-ll-defend-5224','5,1,2','var color_pro = {c35:\"#222222\",c36:\"#262C50\",c44:\"#494A4D\",c1:\"#1a1a1a\",c2:\"#0A1339\",c14:\"#3f3f38\",c47:\"#262C50\",c46:\"#222222\",c53:\"#676769\",};','var product_pro = {s5 :{cl :\"35,36,44\", t :\"199!191@139!171\", s :\"0!0@0!0\", },s1 :{cl :\"1,2,14\", t :\"152!94@219!239\", s :\"0!0@0!0\", },s2 :{cl :\"47,46,53\", t :\"168!141@188!216\", s :\"0!0@0!0\", },}',0,'2017-07-30 11:12:14',0,'this-well-defend-1.jpg','this-well-defend-1','2','$21.99 - $38.99','',1,1),(131,'THIS WELL DEFEND UNITED STATES','THISWELLDEFENDUNITEDSTATES.png,None','THIS WE\'LL DEFEND UNITED STATES','<h2>THIS WE\'LL DEFEND UNITED STATES shirt</h2><br/><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/this-we-ll-defend-united-9226','1,2','var color_pro = {c14:\"#3f3f38\",c15:\"#5c739c\",c3:\"#3A4B98\",c46:\"#222222\",c58:\"#827F77\",c48:\"#C3C0C6\",c49:\"#014A8E\",c55:\"#6299DD\",};','var product_pro = {s1 :{cl :\"14,15,3\", t :\"164!114@195!208\", s :\"0!0@0!0\", },s2 :{cl :\"46,58,48,49,55\", t :\"169!164@176!184\", s :\"0!0@0!0\", },}',1,'2017-07-30 11:25:59',0,'this-well-defend-united-states-1.jpg','this-well-defend-united-states-1','2','$21.99 - $38.99','',1,1),(132,'COMBAT ENGINEER','COMBATENGINEER.png,None','COMBAT ENGINEER','<h2>COMBAT ENGINEER shirt</h2><br/><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/combat-engineer-july-2017','1,4','var color_pro = {c13:\"#FFC4C4\",c15:\"#5c739c\",c3:\"#3A4B98\",c18:\"#D6D5D5\",c30:\"#FFD5D5\",c22:\"#C6C5C5\",c24:\"#96B3EF\",c111:\"#FFFFFF\",};','var product_pro = {s1 :{cl :\"13,15,3,18\", t :\"167!121@185!215\", s :\"0!0@0!0\", },s4 :{cl :\"30,22,24,111\", t :\"168!119@196!226\", s :\"0!0@0!0\", },}',0,'2017-07-30 11:34:55',0,'combat-engineer-1.jpg','combat-engineer-1','2','$21.99 - $25.99','',1,1),(175,'Im A Military People','militarypeople.png,None','I\'m A Military People','I\'m A Military People<br/><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/i-m-a-military-people','1,2','var color_pro = {c2:\"#0A1339\",c1:\"#1a1a1a\",c14:\"#3f3f38\",c15:\"#5c739c\",c46:\"#222222\",c47:\"#262C50\",c49:\"#014A8E\",};','var product_pro = {s1 :{cl :\"2,1,14,15\", t :\"175!105@171!242\", s :\"0!0@0!0\", },s2 :{cl :\"46,47,49\", t :\"185!159@159!205\", s :\"0!0@0!0\", },}',0,'2017-09-14 19:15:39',0,'im-a-military-people.jpg','im-a-military-people','2','$21.99 - $38.99','militaryallies,militaryamazonmenst,militaryandveterans,militaryapparel,militaryapparell,militaryarmedforcestee,militaryarmy,militaryarmyshirt,militaryarmyshirts,militarypeople',1,1),(173,'Im A Soldier','iamsoldier.png,None','I\'m A Soldier','I\'m A Soldier<br/><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/get-i-m-a-soldier','1,2','var color_pro = {c18:\"#D6D5D5\",c2:\"#0A1339\",c1:\"#1a1a1a\",c14:\"#3f3f38\",c46:\"#222222\",c47:\"#262C50\",c49:\"#014A8E\",c48:\"#C3C0C6\",};','var product_pro = {s1 :{cl :\"18,2,1,14\", t :\"160!108@211!172\", s :\"0!0@0!0\", },s2 :{cl :\"46,47,49,48\", t :\"165!150@195!160\", s :\"0!0@0!0\", },}',0,'2017-09-14 19:11:42',0,'im-a-soldier.jpg','im-a-soldier','2','$21.99 - $38.99','iamasoldier,iamasoldiertshirt,soldieralways,soldieramerica,soldieramerican,soldierapparel,soldierawesome,soldierawesomegift,soldierawesomejob,soldierawesometshirt',1,1),(174,'Knight of america','None,americanhero.png','Knight of america','<h2>Knight of america<h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/knight-of-america','1,2,4','var color_pro = {c1:\"#1a1a1a\",c2:\"#0A1339\",c14:\"#3f3f38\",c46:\"#222222\",c47:\"#262C50\",c53:\"#676769\",c20:\"#222222\",c21:\"#262C50\",c28:\"#494949\",};','var product_pro = {s1 :{cl :\"1,2,14\", t :\"0!0@0!0\", s :\"166!71@180!317\", },s2 :{cl :\"46,47,53\", t :\"0!0@0!0\", s :\"173!134@172!304\", },s4 :{cl :\"20,21,28\", t :\"0!0@0!0\", s :\"171!73@195!290\", },}',0,'2017-09-14 19:14:03',0,'knight-of-america.jpg','knight-of-america','2','$21.99 - $38.99','knight,knightitsathingknightitsathing,knightitsathingshirts,knightmadeinamerica,knightmadeinamericaknightmadeinamerica,knightmadeinamericashirts,knightneverunderestimateaknight,knightneverunderestimat',1,0),(136,'STRONG MOM ARMY','Army_Strong_Mon.png,None','STRONG MOM ARMY','<h2>STRONG MOM ARMY shirt</h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/strong-mom-army-july-2017','1,6,2','var color_pro = {c3:\"#3A4B98\",c1:\"#1a1a1a\",c18:\"#D6D5D5\",c12:\"#FF3900\",c62:\"#222222\",c65:\"#193C84\",c63:\"#222353\",c68:\"#C4C3C3\",c46:\"#222222\",c49:\"#014A8E\",c59:\"#1c3d28\",};','var product_pro = {s1 :{cl :\"3,1,18,12\", t :\"166!111@197!242\", s :\"0!0@0!0\", },s6 :{cl :\"62,65,63,68\", t :\"173!122@189!247\", s :\"0!0@0!0\", },s2 :{cl :\"46,49,59\", t :\"173!145@181!226\", s :\"0!0@0!0\", },}',0,'2017-08-03 22:04:08',0,'strong-mom-army-1.jpg','strong-mom-army-1','2','$21.99 - $38.99','',1,1),(140,'UNITED STATE ARMY','Strong_Army_Back_2.png,Strong_Army_Back_1.png','UNITED STATE ARMY','<h2>UNITED STATE ARMY shirt</h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/united-state-army_copy_1','1,4,2','var color_pro = {c2:\"#0A1339\",c18:\"#D6D5D5\",c14:\"#3f3f38\",c20:\"#222222\",c26:\"#014a8e\",c27:\"#383838\",c32:\"#1C3D28\",c47:\"#262C50\",};','var product_pro = {s1 :{cl :\"2,18,14,1\", t :\"282!106@83!75\", s :\"165!60@181!209\", },s4 :{cl :\"20,26,27,32\", t :\"288!118@85!75\", s :\"164!61@198!222\", },s2 :{cl :\"47\", t :\"287!148@80!68\", s :\"168!123@191!221\", },}',0,'2017-08-03 22:26:27',0,'united-state-army-1.jpg','united-state-army-1','2','$21.99 - $38.99','',1,0),(138,'TERRORISM ON AMERICAN SOIL','americansoil.png,None','TERRORISM ON AMERICAN SOIL','<h2>TERRORISM ON AMERICAN SOIL shirt</h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/terrorism-on-american-soi-7753','1,4','var color_pro = {c1:\"#1a1a1a\",c2:\"#0A1339\",c5:\"#134522\",c14:\"#3f3f38\",c20:\"#222222\",c26:\"#014a8e\",c32:\"#1C3D28\",c21:\"#262C50\",c28:\"#494949\",};','var product_pro = {s1 :{cl :\"1,2,5,14\", t :\"163!117@205!230\", s :\"0!0@0!0\", },s4 :{cl :\"20,26,32,21,28\", t :\"165!118@208!232\", s :\"0!0@0!0\", },}',0,'2017-08-03 22:16:08',0,'terrorism-on-american-soil-1.jpg','terrorism-on-american-soil-1','2','$21.99 - $25.99','',1,1),(139,'AIR FORCE US','Air_force_Army.png,None','AIR FORCE US','<h2>AIR FORCE US shirt</h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/air-force-us-3530','1,4','var color_pro = {c1:\"#1a1a1a\",c14:\"#3f3f38\",c20:\"#222222\",c26:\"#014a8e\",c27:\"#383838\",};','var product_pro = {s1 :{cl :\"1,14\", t :\"158!100@226!282\", s :\"0!0@0!0\", },s4 :{cl :\"20,26,27\", t :\"155!98@226!275\", s :\"0!0@0!0\", },}',0,'2017-08-03 22:19:20',0,'air-force-us-1.jpg','air-force-us-1','2','$21.99 - $25.99','',1,1),(142,'CHARLID DONT SURF','charliedontsurf.png,None','CHARLID DONT SURF','<h2>CHARLID DONT SURF shirt</h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/charlid-dont-surf-5331','1,2','var color_pro = {c108:\"#FFFFFF\",c19:\"#97E04A\",c5:\"#134522\",c109:\"#FFFFFF\",c48:\"#C3C0C6\",c55:\"#6299DD\",c60:\"#1f6522\",};','var product_pro = {s1 :{cl :\"108,19,5\", t :\"165!112@193!210\", s :\"0!0@0!0\", },s2 :{cl :\"109,48,55,60\", t :\"165!151@198!215\", s :\"0!0@0!0\", },}',0,'2017-08-03 22:34:13',1,'charlid-dont-surf-1.jpg','charlid-dont-surf-1','2','$21.99 - $38.99','',1,1),(143,'HALF MY HEART IS IN THE ARMY','Halfmyheartinthearmy.png,None','HALF MY HEART IS IN THE ARMY','<h2>HALF MY HEART IS IN THE ARMY shirt</h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/half-my-heart-is-in-the-a-1611','1,4,6','var color_pro = {c5:\"#134522\",c2:\"#0A1339\",c3:\"#3A4B98\",c32:\"#1C3D28\",c21:\"#262C50\",c26:\"#014a8e\",c24:\"#96B3EF\",c65:\"#193C84\",c64:\"#616672\",c67:\"#510B7D\",};','var product_pro = {s1 :{cl :\"5,2,3\", t :\"169!112@186!243\", s :\"0!0@0!0\", },s4 :{cl :\"32,21,26,24\", t :\"175!110@191!240\", s :\"0!0@0!0\", },s6 :{cl :\"65,64,67\", t :\"174!147@185!246\", s :\"0!0@0!0\", },}',0,'2017-08-03 22:37:50',0,'half-my-heart-is-in-the-army-1.jpg','half-my-heart-is-in-the-army-1','2','$21.99 - $25.99','',1,1),(144,'U.S MILITARY','americanmilitary.png,None','U.S MILITARY','<h2>U.S MILITARY shirt</h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/new-u-s-military','1,4','var color_pro = {c2:\"#0A1339\",c1:\"#1a1a1a\",c20:\"#222222\",c21:\"#262C50\",c26:\"#014a8e\",};','var product_pro = {s1 :{cl :\"2,1\", t :\"169!123@183!216\", s :\"0!0@0!0\", },s4 :{cl :\"20,21,26\", t :\"168!119@197!233\", s :\"0!0@0!0\", },}',0,'2017-08-03 22:45:56',1,'u.s-military-1.jpg','u.s-military-1','2','$21.99 - $25.99','',1,1),(145,'AMERICAN NAVY SEALS','USnavyseal.png,None','AMERICAN NAVY SEALS','<h2>AMERICAN NAVY SEALS shirt</h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/vi-VN/american-navy-seals_copy_1','1,2,6','var color_pro = {c1:\"#1a1a1a\",c2:\"#0A1339\",c3:\"#3A4B98\",c5:\"#134522\",c18:\"#D6D5D5\",c14:\"#3f3f38\",c46:\"#222222\",c47:\"#262C50\",c49:\"#014A8E\",c54:\"#88353C\",c59:\"#1c3d28\",c63:\"#222353\",c65:\"#193C84\",c62:\"#222222\",c69:\"#38393a\",};','var product_pro = {s1 :{cl :\"1,2,3,5,18,14\", t :\"272!135@74!66\", s :\"0!0@0!0\", },s2 :{cl :\"46,47,49,54,59\", t :\"265!169@75!68\", s :\"0!0@0!0\", },s6 :{cl :\"63,65,62,69\", t :\"269!150@75!71\", s :\"0!0@0!0\", },}',0,'2017-08-03 22:49:53',0,'american-navy-seals-1.jpg','american-navy-seals-1','2','$21.99 - $38.99','',1,1),(146,'MILITARY POLICE CORPS','militarypolicecorps.png,None','MILITARY POLICE CORPS','<h2>MILITARY POLICE CORPS shirt</h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/vi-VN/american-navy-seals_copy_1','1,2','var color_pro = {c5:\"#134522\",c3:\"#3A4B98\",c2:\"#0A1339\",c1:\"#1a1a1a\",c46:\"#222222\",c47:\"#262C50\",c59:\"#1c3d28\",};','var product_pro = {s1 :{cl :\"5,3,2,1\", t :\"169!117@179!188\", s :\"0!0@0!0\", },s2 :{cl :\"46,47,59\", t :\"188!165@150!152\", s :\"0!0@0!0\", },}',0,'2017-08-03 22:54:38',0,'military-police-corps-1.jpg','military-police-corps-1','2','$21.99 - $38.99','',1,1),(147,'ARMY STRONG','strongarmy.png,None','ARMY STRONG','<h2>ARMY STRONG shirt</h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/army-strong-august-2017','1,2','var color_pro = {c2:\"#0A1339\",c1:\"#1a1a1a\",c46:\"#222222\",c47:\"#262C50\",};','var product_pro = {s1 :{cl :\"2,1\", t :\"160!120@208!199\", s :\"0!0@0!0\", },s2 :{cl :\"46,47\", t :\"171!161@184!185\", s :\"0!0@0!0\", },}',0,'2017-08-03 23:00:20',0,'army-strong-1.jpg','army-strong-1','2','$21.99 - $38.99','',1,1),(148,'NO TRY NOT','None,theforcewithyou.png','NO TRY NOT','<h2>NO TRY NOT shirt</h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/no-try-not','1,2','var color_pro = {c2:\"#0A1339\",c1:\"#1a1a1a\",c46:\"#222222\",c47:\"#262C50\",};','var product_pro = {s1 :{cl :\"2,1\", t :\"0!0@0!0\", s :\"160!79@196!279\", },s2 :{cl :\"46,47\", t :\"0!0@0!0\", s :\"164!130@219!284\", },}',0,'2017-08-03 23:06:31',1,'no-try-not-1.jpg','no-try-not-1','2','$21.99 - $38.99','',1,0),(149,'PROUD ARMY DAD','proudarmydad.png,None','PROUD ARMY DAD','<h2>PROUD ARMY DAD shirt</h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/proud-army-dad-august-2018','1,4,6','var color_pro = {c2:\"#0A1339\",c1:\"#1a1a1a\",c14:\"#3f3f38\",c21:\"#262C50\",c20:\"#222222\",c62:\"#222222\",c65:\"#193C84\",c69:\"#38393a\",};','var product_pro = {s1 :{cl :\"2,1,14\", t :\"163!111@199!243\", s :\"0!0@0!0\", },s4 :{cl :\"21,20\", t :\"159!107@215!246\", s :\"0!0@0!0\", },s6 :{cl :\"62,65,69\", t :\"163!138@205!256\", s :\"0!0@0!0\", },}',1,'2017-08-03 23:13:06',1,'proud-army-dad-1.jpg','proud-army-dad-1','2','$21.99 - $25.99','',1,1),(150,'PEACE THROUGH STRENGTH','d_2.png,None','PEACE THROUGH STRENGTH','<h2>PEACE THROUGH STRENGTH shirt</h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/get-peace-through-strength','1','var color_pro = {c2:\"#0A1339\",c1:\"#1a1a1a\",c14:\"#3f3f38\",c5:\"#134522\",};','var product_pro = {s1 :{cl :\"2,1,14,5\", t :\"174!115@183!217\", s :\"0!0@0!0\", },}',0,'2017-08-03 23:15:54',0,'peace-through-strength-1.jpg','peace-through-strength-1','2','$21.99 - $21.99','',1,1),(151,'The USARMY','US_army.png,None','The U.S.ARMY','<h2>The U.S.ARMY shirt</h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/the-u-s-army','1,6','var color_pro = {c2:\"#0A1339\",c1:\"#1a1a1a\",c5:\"#134522\",c62:\"#222222\",c65:\"#193C84\",c69:\"#38393a\",};','var product_pro = {s1 :{cl :\"2,1,5\", t :\"171!112@179!257\", s :\"0!0@0!0\", },s6 :{cl :\"62,65,69\", t :\"168!135@190!286\", s :\"0!0@0!0\", },}',0,'2017-08-03 23:20:11',0,'the-usarmy-1.jpg','the-usarmy-1','2','$21.99 - $23.99','',1,1),(163,'This is the best waterboarding','Waterboarding.png,None','This is the best waterboarding','<img zeeping.com/image/common/topseller.jpg><br/>Get the hoodie here --> https://teespring.com/new-this-is-the-best-waterboar<br/><br/>Only available for a LIMITED TIME so get yours TODAY ! Printed right here in the U.S.A.<br/>Checkout via Paypal/Visa/MasterCard*','https://teespring.com/this-is-the-best-waterboarding','1,6,2','var color_pro = {c2:\"#0A1339\",c1:\"#1a1a1a\",c5:\"#134522\",c15:\"#5c739c\",c14:\"#3f3f38\",c3:\"#3A4B98\",c62:\"#222222\",c63:\"#222353\",c65:\"#193C84\",c69:\"#38393a\",c66:\"#5C88A4\",c46:\"#222222\",c47:\"#262C50\",c49:\"#014A8E\",c59:\"#1c3d28\",c60:\"#1f6522\",};','var product_pro = {s1 :{cl :\"2,1,5,15,14,3\", t :\"149!99@223!322\", s :\"0!0@0!0\", },s6 :{cl :\"62,63,65,69,66\", t :\"152!131@226!334\", s :\"0!0@0!0\", },s2 :{cl :\"46,47,49,59,60\", t :\"175!159@178!204\", s :\"0!0@0!0\", },}',1,'2017-09-07 14:40:02',1,'this-is-the-best-waterboarding.jpg','this-is-the-best-waterboarding','2','$21.99 - $38.99','terroristsuck,terroristtshirt,terroristattacts,terroristcheapshirt,terroristrapists,terroristsshirt,terroriststshirt,veterannothingtoprove,waterboarding',1,1),(153,'U S Veteran','veterandad.png,None','U.S.Veteran ',' <h2>U.S.Veteran<h2><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/u-s-veteran-3508','1,2','var color_pro = {c1:\"#1a1a1a\",c5:\"#134522\",c2:\"#0A1339\",c14:\"#3f3f38\",c53:\"#676769\",c46:\"#222222\",c47:\"#262C50\",c59:\"#1c3d28\",c49:\"#014A8E\",};','var product_pro = {s1 :{cl :\"1,5,2,14\", t :\"166!120@191!207\", s :\"0!0@0!0\", },s2 :{cl :\"53,46,47,59,49\", t :\"181!158@163!194\", s :\"0!0@0!0\", },}',0,'2017-08-17 11:37:51',1,'u-s-veteran-1.jpg','u-s-veteran-1','2','$21.99 - $38.99','neverunderestimatethetenaciouspower,neverunderestimatethetenaciouspowerofagrandtshirtsmenstshirt,neverunderestimatethetenaciouspowerofagrandpa,neverunderestimatethetenaciouspowerofapapa,veterandadtshi',1,1),(154,'I Did and I m Veteran','veteran.png,None','I Did and I m Veteran',' <h2>I Did and I m Veteran<h2><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/i-did-and-i-m-veteran-8635','1,2','var color_pro = {c1:\"#1a1a1a\",c5:\"#134522\",c2:\"#0A1339\",c14:\"#3f3f38\",c15:\"#5c739c\",c53:\"#676769\",c46:\"#222222\",c47:\"#262C50\",c59:\"#1c3d28\",c49:\"#014A8E\",};','var product_pro = {s1 :{cl :\"1,5,2,14,15\", t :\"169!100@178!249\", s :\"0!0@0!0\", },s2 :{cl :\"53,46,47,59,49\", t :\"176!155@167!201\", s :\"0!0@0!0\", },}',0,'2017-08-17 11:47:29',0,'i-did-and-i-m-veteran-1.jpg','i-did-and-i-m-veteran-1','2','$21.99 - $38.99','iamaveteranshirt,iamaveteranshirts,iamaveterantshirt,iamaveterantshirts,iamaveterantshirtsmenspremiumtshirt,iamaveterantee,iamaveterantshirt,iamaveterans,iamaveteransdaughtershirt,ididandiamveteran',1,1),(155,'Trust the Veteran','Trustme.png,None','Trust the Veteran',' <h2>Trust the Veteran<h2><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/trust-the-veteran','1,2','var color_pro = {c1:\"#1a1a1a\",c2:\"#0A1339\",c14:\"#3f3f38\",c15:\"#5c739c\",c5:\"#134522\",c3:\"#3A4B98\",c59:\"#1c3d28\",c46:\"#222222\",c47:\"#262C50\",c49:\"#014A8E\",c53:\"#676769\",c58:\"#827F77\",c52:\"#C03545\",};','var product_pro = {s1 :{cl :\"1,2,14,15,5,3\", t :\"172!119@176!216\", s :\"0!0@0!0\", },s2 :{cl :\"59,46,47,49,53,58,52\", t :\"177!134@170!243\", s :\"0!0@0!0\", },}',2,'2017-08-17 11:54:29',1,'trust-the-veteran-1.jpg','trust-the-veteran-1','2','$21.99 - $38.99','iamaveteranshirts,iamaveteransweater,iamaveterantshirt,iamaveterantshirts,iamaveterantshirtsmenspremiumtshirt,iamaveterantee,iamaveterantshirt,iamaveteranwalkawaytshirtiamaveteran,iamaveterans,veteran',1,1),(156,'STAND FOR THE FLAG','Standforflag.png,None','STAND FOR THE FLAG',' <h2>STAND FOR THE FLAG<h2><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/stand-for-the-flag-august-2017','1,2','var color_pro = {c1:\"#1a1a1a\",c2:\"#0A1339\",c15:\"#5c739c\",c14:\"#3f3f38\",c46:\"#222222\",c47:\"#262C50\",c59:\"#1c3d28\",c58:\"#827F77\",c54:\"#88353C\",};','var product_pro = {s1 :{cl :\"1,2,15,14\", t :\"161!103@202!247\", s :\"0!0@0!0\", },s2 :{cl :\"46,47,59,58,54\", t :\"177!151@169!222\", s :\"0!0@0!0\", },}',0,'2017-08-17 12:00:48',0,'stand-for-the-flag-1.jpg','stand-for-the-flag-1','2','$21.99 - $38.99','americanflagbeardshirt,americanflagbedding,standfortheflag,standfortheflagkneel,standfortheflagkneelforthecross,standfortheflagkneelforthecrosswomenswidenecksweatshirt,standfortheflagkneelforthecrosst',1,1),(157,'Military Police','militarypolice.png,None','Military Police',' <h2>Military Police<h2><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/military-police-august-2017','1,6','var color_pro = {c1:\"#1a1a1a\",c5:\"#134522\",c14:\"#3f3f38\",c15:\"#5c739c\",c62:\"#222222\",c69:\"#38393a\",c68:\"#C4C3C3\",c66:\"#5C88A4\",};','var product_pro = {s1 :{cl :\"1,5,14,15\", t :\"148!89@225!284\", s :\"0!0@0!0\", },s6 :{cl :\"62,69,68,66\", t :\"154!125@220!283\", s :\"0!0@0!0\", },}',0,'2017-08-17 12:08:01',0,'military-police-1.jpg','military-police-1','2','$21.99 - $23.99','militarypolicegrandad,militarypoliceguy,militarypolicehalloweentees,militarypolicehoney,militarypoliceinsignia,militarypolicejob,militarypolicejobshirts,militarypolicejobtshirts,militarypolicelegend,m',1,1),(158,'Son of America VETERAN','sonofamerican.png,None','Son of America VETERAN',' <h2>Son of America VETERAN<h2><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/son-of-america-veteran-1691','1,2','var color_pro = {c1:\"#1a1a1a\",c2:\"#0A1339\",c14:\"#3f3f38\",c5:\"#134522\",c46:\"#222222\",c47:\"#262C50\",c59:\"#1c3d28\",c53:\"#676769\",};','var product_pro = {s1 :{cl :\"1,2,14,5\", t :\"157!109@204!178\", s :\"0!0@0!0\", },s2 :{cl :\"46,47,59,53\", t :\"161!151@204!164\", s :\"0!0@0!0\", },}',0,'2017-08-17 12:13:18',0,'son-of-america-veteran-1.jpg','son-of-america-veteran-1','2','$21.99 - $38.99','sonsofamerica,sonsofamericashirt,sonsofamericashirts,sonsofamericatshirt,sonsofamericatshirt,sonsofamericatshirts,sonsofamericausmc,sonsofamericaveteran,sonsofamerican,sonsofamericaninfidel',1,1),(159,'Proud Army Brother','proudarmy.png,None','Proud Army Brother',' <h2>Proud Army Brother<h2><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/proud-army-brother-2017','1,6','var color_pro = {c1:\"#1a1a1a\",c2:\"#0A1339\",c5:\"#134522\",c3:\"#3A4B98\",c14:\"#3f3f38\",c62:\"#222222\",c63:\"#222353\",c65:\"#193C84\",c69:\"#38393a\",};','var product_pro = {s1 :{cl :\"1,2,5,3,14\", t :\"161!109@203!267\", s :\"0!0@0!0\", },s6 :{cl :\"62,63,65,69\", t :\"163!124@204!259\", s :\"0!0@0!0\", },}',0,'2017-08-17 12:18:26',0,'proud-army-brother-1.jpg','proud-army-brother-1','2','$21.99 - $23.99','armybrothergift,armybrothershirt,armybrotherspecialhood,armybrotherspecialtee,armybrothersweater,armybrothertshirt,armybrothertee,armybrothertees,armybrothers,armybrothersshirt',1,1),(160,'I m the luckiest man in the world','soldierveteran.png,None','I m the luckiest man in the world',' <h2>I m the luckiest man in the world<h2><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/i-m-the-luckiest-man-in-the-wo','1,2','var color_pro = {c1:\"#1a1a1a\",c2:\"#0A1339\",c14:\"#3f3f38\",c5:\"#134522\",c46:\"#222222\",c47:\"#262C50\",c59:\"#1c3d28\",c49:\"#014A8E\",};','var product_pro = {s1 :{cl :\"1,2,14,5\", t :\"172!106@180!233\", s :\"0!0@0!0\", },s2 :{cl :\"46,47,59,49\", t :\"170!147@189!225\", s :\"0!0@0!0\", },}',0,'2017-08-17 12:24:56',0,'i-m-the-luckiest-man-in-the-world-1.jpg','i-m-the-luckiest-man-in-the-world-1','2','$21.99 - $38.99','veterananothergenerationmenstshirt,veteranhappyindependenceday,veteraniregretnothing,veteraniwantedtoserve,veteraniwantedtoserve,veteranmenspremiumtshirt,veteranmenstshirt,veterannothingtoprove,vetera',1,1),(172,'I got your SIX','Igotyoursix.png,None','I got your SIX','I got your SIX<br/><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/i-got-your-six-9072','1,2','var color_pro = {c5:\"#134522\",c2:\"#0A1339\",c1:\"#1a1a1a\",c14:\"#3f3f38\",c46:\"#222222\",c47:\"#262C50\",c59:\"#1c3d28\",c49:\"#014A8E\",c53:\"#676769\",};','var product_pro = {s1 :{cl :\"5,2,1,14\", t :\"174!111@181!147\", s :\"0!0@0!0\", },s2 :{cl :\"46,47,59,49,53\", t :\"182!152@165!142\", s :\"0!0@0!0\", },}',0,'2017-09-14 19:07:06',0,'i-got-your-six.jpg','i-got-your-six','2','$21.99 - $38.99','',1,1),(176,'Proud USArmy Dad','ProudofArmyDad.png,None','Proud U.S.Army Dad','Proud U.S.Army Dad<br/><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/proud-u-s-army-dad-4142#pid=2&cid=566&sid=front','1','var color_pro = {c14:\"#3f3f38\",c2:\"#0A1339\",c5:\"#134522\",};','var product_pro = {s1 :{cl :\"14,2,5\", t :\"165!109@197!182\", s :\"0!0@0!0\", },}',0,'2017-09-14 19:23:29',0,'proud-usarmy-dad.jpg','proud-usarmy-dad','2','$21.99 - $21.99','armydadtshirtgoogle,armydadtshirts,armydaduglyshirts,armydaddy,armydads,armydadytshirt,usarmydadreturnsfrom,usarmydadtshirts,usarmydads',1,1),(177,'America  We are ready and alway ready','american.png,None','America , We\'re ready and alway ready','<h2>America, We\'re ready and alway ready<h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com//america-we-re-ready-and-alwa','1,2,4','var color_pro = {c1:\"#1a1a1a\",c14:\"#3f3f38\",c2:\"#0A1339\",c5:\"#134522\",c46:\"#222222\",c53:\"#676769\",c59:\"#1c3d28\",c20:\"#222222\",c27:\"#383838\",c28:\"#494949\",};','var product_pro = {s1 :{cl :\"1,14,2,5\", t :\"158!120@211!141\", s :\"0!0@0!0\", },s2 :{cl :\"46,53,59\", t :\"163!149@210!168\", s :\"0!0@0!0\", },s4 :{cl :\"20,27,28\", t :\"167!129@202!125\", s :\"0!0@0!0\", },}',0,'2017-09-14 19:24:12',1,'america-were-ready-and-alway-ready.jpg','america--we-are-ready-and-alway-ready','2','$21.99 - $38.99','americaweareready,iamreadytaken,makeamericagreatagainshirts,makeamericagreatagaintshirt,wearereadyforamerica,weareready,areyoureadyforamerica,americaiamready,soldieriamready,iamreadyforsoldier',1,1),(178,'Proud USArmy Dad','ProudofArmyDad.png,None','Proud U.S.Army Dad-Women','Proud U.S.Army Dad<br/><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/proud-u-s-army-dad-4142','3','var color_pro = {c80:\"#222222\",c82:\"#ea80ac\",c75:\"#22488F\",c74:\"#523885\",};','var product_pro = {s3 :{cl :\"80,82,75,74\", t :\"179!149@180!198\", s :\"0!0@0!0\", },}',0,'2017-09-14 19:28:02',0,'proud-usarmy-dad-1.jpg','proud-usarmy-dad-1','3','$22.99 - $22.99','armydadtshirtgoogle,armydadtshirts,armydaduglyshirts,armydaddy,armydads,armydadytshirt,usarmydadreturnsfrom,usarmydadtshirts,usarmydads',1,1),(179,'You gave something','None,allgavesome-somegaveallb.png','You gave something?','<h2>You gave something?<h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/you-gave-something-5149','1,2','var color_pro = {c1:\"#1a1a1a\",c14:\"#3f3f38\",c5:\"#134522\",c2:\"#0A1339\",c46:\"#222222\",c53:\"#676769\",c47:\"#262C50\",};','var product_pro = {s1 :{cl :\"1,14,5,2\", t :\"0!0@0!0\", s :\"151!92@204!149\", },s2 :{cl :\"46,53,47\", t :\"0!0@0!0\", s :\"168!146@187!158\", },}',0,'2017-09-14 19:29:40',0,'you-gave-something.jpg','you-gave-something','2','$21.99 - $38.99','allgavesomesomegaveall,allgavesometshirt,eagleamerica,eagleamericanflag,eagleamericantshirt,igaveall,somegaveall,gavealltoamerica,somegavealltshirt,gavealltshirt',1,1),(180,'Army and Sister','armysisterfront.png,None','Army and Sister','Army and Sister<br/><br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/army-and-sister','3,7','var color_pro = {c80:\"#222222\",c79:\"#0C1A2C\",c75:\"#22488F\",c74:\"#523885\",c84:\"#433e44\",c89:\"#000000\",c85:\"#282FA4\",c92:\"#222223\",c91:\"#02021E\",};','var product_pro = {s3 :{cl :\"80,79,75,74,84\", t :\"185!159@161!204\", s :\"0!0@0!0\", },s7 :{cl :\"89,85,92,91\", t :\"196!249@134!168\", s :\"0!0@0!0\", },}',0,'2017-09-14 19:37:21',0,'army-and-sister.jpg','army-and-sister','3','$22.99 - $26.99','armysistertshirt,armysistertshirts,armysistertattoos,armysistertee,armysisterteeshirt,armysistertees,armysistertshirt,armysistertshirts,armysistertspringshirt,armysisters',1,1),(181,'I did not choose','armopride.png,None','I didn\'t choose','<h2>I didn\'t choose<h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/new-i-didn-t-choose','1,2','var color_pro = {c1:\"#1a1a1a\",c14:\"#3f3f38\",c2:\"#0A1339\",c18:\"#D6D5D5\",c59:\"#1c3d28\",c48:\"#C3C0C6\",c46:\"#222222\",c47:\"#262C50\",};','var product_pro = {s1 :{cl :\"1,14,2,18\", t :\"167!106@186!221\", s :\"0!0@0!0\", },s2 :{cl :\"59,48,46,47\", t :\"176!155@179!187\", s :\"0!0@0!0\", },}',0,'2017-09-14 19:39:45',0,'i-did-not-choose.jpg','i-did-not-choose','2','$21.99 - $38.99','ammosexual,ammosexualhannestee,ammosexualquotes,ammosexualshirthoodie,ammosexualtshirt,ammosexualtees,ammosexualtshirt,ammosexualtshirts,ammosexuality,ammosexuals',1,1),(182,'Veteran Mom','VeteranMom.png,None','Veteran Mom','Veteran Mom<br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/veteran-mom-august-2017','3','var color_pro = {c80:\"#222222\",c79:\"#0C1A2C\",c83:\"#b25192\",c76:\"#448e4f\",c84:\"#433e44\",c75:\"#22488F\",};','var product_pro = {s3 :{cl :\"80,79,83,76,84,75\", t :\"178!149@182!286\", s :\"0!0@0!0\", },}',0,'2017-09-14 19:40:29',0,'veteran-mom.jpg','veteran-mom','3','$22.99 - $22.99','veteranmomtshirts,veteranmomtank,veteranmomtee,veteranmomtshirt,veteranmomtshirts,veteranmommy,veteranmoms,veteranmomswomenspremium,veteranmomswomenspremiumtshirt,veteranmomsshirts',1,1),(183,'Veterans Wife','veteranwife.png,None','Veteran\'s Wife','Veteran\'s Wife<br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/veteran-s-wife-august-2017','3','var color_pro = {c80:\"#222222\",c79:\"#0C1A2C\",c75:\"#22488F\",c84:\"#433e44\",c83:\"#b25192\",};','var product_pro = {s3 :{cl :\"80,79,75,84,83\", t :\"172!151@190!260\", s :\"0!0@0!0\", },}',0,'2017-09-14 19:43:10',0,'veterans-wife.jpg','veterans-wife','3','$22.99 - $22.99','veteranwifeshirt,veteranwifeshirts,veteranwifetshirt,veteranwifetshirts,veteranwifetee,veteranwifeteeshirts,veteranwifeteespring,veteranwifetshirt,veteranwifetshirtbing',1,1),(184,'Army Sister','armysisterback.png,None','Army Sister','<h2>Army Sister<h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/army-sister-2017','1,6','var color_pro = {c1:\"#1a1a1a\",c2:\"#0A1339\",c14:\"#3f3f38\",c62:\"#222222\",c63:\"#222353\",c69:\"#38393a\",};','var product_pro = {s1 :{cl :\"1,2,14\", t :\"165!114@186!210\", s :\"0!0@0!0\", },s6 :{cl :\"62,63,69\", t :\"163!147@197!209\", s :\"0!0@0!0\", },}',0,'2017-09-14 19:44:57',1,'army-sister.jpg','army-sister','1','$21.99 - $23.99','armysistershirts,armysistertshirt,armysistertshirts,armysistertee,armysisterteeshirt,armysistertshirt,armysistertshirts,armysistertspringshirt,armysisters',1,1),(185,'I MISS MY SOLDIER','Imissmysoldier.png,None','I MISS MY SOLDIER','I MISS MY SOLDIER<br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/new-i-miss-my-soldier','3,7','var color_pro = {c80:\"#222222\",c79:\"#0C1A2C\",c75:\"#22488F\",c84:\"#433e44\",c89:\"#000000\",c85:\"#282FA4\",c92:\"#222223\",c91:\"#02021E\",};','var product_pro = {s3 :{cl :\"80,79,75,84\", t :\"192!163@152!124\", s :\"0!0@0!0\", },s7 :{cl :\"89,85,92,91\", t :\"196!237@144!121\", s :\"0!0@0!0\", },}',0,'2017-09-14 19:47:24',0,'i-miss-my-soldier.jpg','i-miss-my-soldier','3','$22.99 - $26.99','imissmysoldier,imissmysoldiershirt,missmysoldierboy,missmysoldierson,mysoldier,mysoldierdadshirt,mysoldiershirt,mysoldiertshirt,mysoldiers',1,1),(186,'Freedom Is not Free','freedom.png,None','Freedom Isn\'t Free','<h2>Freedom Isn\'t Free<h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/freedom-isn-t-free-5130','1,2','var color_pro = {c1:\"#1a1a1a\",c2:\"#0A1339\",c14:\"#3f3f38\",c3:\"#3A4B98\",c15:\"#5c739c\",c46:\"#222222\",c47:\"#262C50\",c49:\"#014A8E\",c59:\"#1c3d28\",};','var product_pro = {s1 :{cl :\"1,2,14,3,15\", t :\"181!117@156!183\", s :\"0!0@0!0\", },s2 :{cl :\"46,47,49,59\", t :\"167!158@188!197\", s :\"0!0@0!0\", },}',0,'2017-09-14 19:49:46',1,'freedom-is-not-free.jpg','freedom-is-not-free','2','$21.99 - $38.99','freedomisnotfree,freedomisnotfreeipaidforitusveteran3454,freedomisnotfreemyan,freedomisnotfreeshirt,freedomisnotfreetee,ipaidforfreedom,unitedstateveteran,unitedstatesveteranone,unitedstatesveterantee',1,1),(187,'America Navy','None,navyus.png','America Navy','America Navy<br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/new-america-navy','1,2','var color_pro = {c14:\"#3f3f38\",c5:\"#134522\",c3:\"#3A4B98\",c47:\"#262C50\",c49:\"#014A8E\",c59:\"#1c3d28\",};','var product_pro = {s1 :{cl :\"14,5,3\", t :\"0!0@0!0\", s :\"161!115@183!141\", },s2 :{cl :\"47,49,59\", t :\"0!0@0!0\", s :\"164!148@188!146\", },}',0,'2017-09-14 19:50:32',1,'america-navy.jpg','america-navy','2','$21.99 - $38.99','americannavy,americannavyhonor,americannavytshirt,americannavyveteran,amricanavy,navy,navyvietnamwarwsvcribbons,navyactivet,navyall,navyamerican',1,0),(188,'Made In The USA','None,makeinUSA.png','Made In The USA','Made In The USA<br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/made-in-the-usa-7827','1,6','var color_pro = {c1:\"#1a1a1a\",c2:\"#0A1339\",c14:\"#3f3f38\",c62:\"#222222\",};','var product_pro = {s1 :{cl :\"1,2,14\", t :\"0!0@0!0\", s :\"165!76@187!294\", },s6 :{cl :\"62\", t :\"0!0@0!0\", s :\"171!79@191!294\", },}',5,'2017-09-14 19:53:15',1,'made-in-the-usa.jpg','made-in-the-usa','2','$21.99 - $23.99','madeintheusa,madeintheusabirthday,madeintheusaclothing,madeintheusashirt,madeintheusatshirts,madeintheusatshirt,madeintheusawomens,madeinusateespring,madeinusatshirt,madeinusatshirts',1,0),(189,'The Best Kind Of Mom','BestkindofMomArmy.png,None','The Best Kind Of Mom','<h2>The Best Kind Of Mom<h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/the-best-kind-of-mom-7458#pid=2&cid=569&sid=front','1','var color_pro = {c3:\"#3A4B98\",c1:\"#1a1a1a\",c11:\"#4B256E\",c14:\"#3f3f38\",};','var product_pro = {s1 :{cl :\"3,1,11,14\", t :\"173!110@174!213\", s :\"0!0@0!0\", },}',0,'2017-09-14 19:53:46',0,'the-best-kind-of-mom.jpg','the-best-kind-of-mom','2','$21.99 - $21.99','armymomlove,armymommilitarytshirt,armymommostpeopleonlydreamofmeetingtheir,armymomproud,armymomproudtshirt,raiseanamry,thebestkindofmomraisesamarine,momraisesanarmy,armyandmom,momandarmy',1,1),(190,'I Am A Veteran','Iamveteran.png,None','I Am A Veteran','I Am A Veteran<br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/i-am-a-veteran-4973','1,6','var color_pro = {c1:\"#1a1a1a\",c2:\"#0A1339\",c14:\"#3f3f38\",c62:\"#222222\",c63:\"#222353\",c69:\"#38393a\",};','var product_pro = {s1 :{cl :\"1,2,14\", t :\"168!107@195!290\", s :\"0!0@0!0\", },s6 :{cl :\"62,63,69\", t :\"160!140@207!276\", s :\"0!0@0!0\", },}',0,'2017-09-14 19:56:23',0,'i-am-a-veteran.jpg','i-am-a-veteran','2','$21.99 - $23.99','allergictobullshittshirtallergictobullshitgifts,allergictostupidity,allergictostupiditysh,allergictostupiditybt,allergictostupiditys,iamaveterantshirt,iamaveterantshirts,iamaveterantee,iamaveterantshi',1,1),(191,'The Best Kind Of Mom','BestkindofMomArmy.png,None','The Best Kind Of Mom','<h2>The Best Kind Of Mom<h2><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/the-best-kind-of-mom-7458','3','var color_pro = {c74:\"#523885\",c81:\"#ADB1B0\",c83:\"#b25192\",c75:\"#22488F\",c80:\"#222222\",};','var product_pro = {s3 :{cl :\"74,81,83,75,80\", t :\"167!149@199!293\", s :\"0!0@0!0\", },}',0,'2017-09-14 19:57:19',0,'the-best-kind-of-mom-1.jpg','the-best-kind-of-mom-1','3','$22.99 - $22.99','armymomlove,armymommilitarytshirt,armymommostpeopleonlydreamofmeetingtheir,armymomproud,armymomproudtshirt,raiseanamry,thebestkindofmomraisesamarine,momraisesanarmy,armyandmom,momandarmy',1,1),(192,'Always Ready','armynationalguard.png,None','Always Ready','Always Ready<br/><br/><br/>Limited Edition tees, available in the color of your choice!<br/><br/>When you press the big green button, you will be able to choose your size(s). <br/><br/>SHARE it with your friends, order together and save on shipping.<br/>100% Printed in the U.S.A - Ship to 178 countries<br/><br/>Hope you like this shirt','https://teespring.com/get-always-ready','1,6','var color_pro = {c1:\"#1a1a1a\",c2:\"#0A1339\",c14:\"#3f3f38\",c3:\"#3A4B98\",c62:\"#222222\",c63:\"#222353\",c69:\"#38393a\",c65:\"#193C84\",};','var product_pro = {s1 :{cl :\"1,2,14,3\", t :\"169!116@190!273\", s :\"0!0@0!0\", },s6 :{cl :\"62,63,69,65\", t :\"168!146@190!269\", s :\"0!0@0!0\", },}',2,'2017-09-14 19:58:37',1,'always-ready.jpg','always-ready','2','$21.99 - $23.99','armymilitarytshirts,armyamerica,armyamerican,armyamericantshirt,armynationalguard,armynationalguardfunnyandlove,armynationalguardhoodie,armynationalguardshirt,armynationalguardtshirt,armytshirts',1,1);
/*!40000 ALTER TABLE `order_product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_product_color`
--

DROP TABLE IF EXISTS `order_product_color`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_product_color` (
  `color_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `color_name` varchar(50) NOT NULL,
  `color_value` varchar(7) NOT NULL,
  `colorofstyle` bigint(20) NOT NULL DEFAULT '1',
  `flashformid` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`color_id`),
  KEY `flashformid` (`flashformid`)
) ENGINE=MyISAM AUTO_INCREMENT=211 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_product_color`
--

LOCK TABLES `order_product_color` WRITE;
/*!40000 ALTER TABLE `order_product_color` DISABLE KEYS */;
INSERT INTO `order_product_color` (`color_id`, `color_name`, `color_value`, `colorofstyle`, `flashformid`) VALUES (1,'Back Basic Tees\n','#1a1a1a',1,1),(2,'Navy Basic Tees\n','#0A1339',1,1),(3,'Deep royal Basic Tees\n','#3A4B98',1,1),(4,'Deep red Basic Tees\n','#9F0110',1,1),(5,'Deep Forest Basic Tees','#134522',1,1),(12,'Orange Basic Tees','#FF3900',1,1),(11,'Purple Basic Tees','#4B256E',1,1),(13,'Pale Pink Basic Tees','#FFC4C4',1,1),(14,'Smoke grey Basic Tees','#3f3f38',1,1),(15,'Denim Blue Basic Tees','#5c739c',1,1),(16,'Yellow Basic Tees','#fef344',1,1),(17,'Gold Basic Tees','#fc9f00',1,1),(18,'Light Steel Basic Tees','#D6D5D5',1,1),(19,'Lime Basic Tees','#97E04A',1,1),(20,'Black Lsleeve\n','#222222',4,1),(21,'Navy Lsleeve\n','#262C50',4,1),(22,'Sport grey Lsleeve\n','#C6C5C5',4,1),(23,'Red Lsleeve\n','#C90013',4,1),(24,'Light blue Lsleeve\n','#96B3EF',4,1),(25,'Purple Lsleeve\n','#4D2379',4,1),(26,'Royal Lsleeve','#014a8e',4,1),(27,'Dark Heather Lsleeve','#383838',4,1),(28,'Charcoal Lsleeve','#494949',4,1),(29,'Safety Orange Lsleeve','#FF5400',4,1),(30,'Light Pink Lsleeve','#FFD5D5',4,1),(31,'Irish Green Lsleeve','#1f6522',4,1),(32,'Forest Green Lsleeve','#1C3D28',4,1),(33,'Gold Lsleeve','#FFBA31',4,1),(34,'Cardinal red Lsleeve','#711127',4,1),(35,'Black Tanktop\n','#222222',5,1),(36,'Navy Tanktop\n','#262C50',5,1),(37,'Sport grey tanktop\n','#D0CFD1',5,1),(38,'Red tanktop','#C90013',5,1),(39,'Orange tanktop','#CF7602',5,1),(40,'Deep orange tanktop','#CF7729',5,1),(41,'Gold Tanktop','#D7AE4C',5,1),(42,'Royal Tanktop','#014A8E',5,1),(43,'Purple Tanktop','#4D2379',5,1),(44,'Charcoal Tanktop','#494A4D',5,1),(45,'Carolina Blue Tanktop','#6299DD',5,1),(46,'Black hoodies\n','#222222',2,1),(47,'Navy hoodies\n','#262C50',2,1),(48,'Sport grey hoodies\n','#C3C0C6',2,1),(49,'Royal hoodies','#014A8E',2,1),(50,'Red hoodies','#C90013',2,1),(51,'Purple Hoodies','#4D2379',2,1),(52,'Cardinal Red Hoodie','#C03545',2,1),(53,'Dark Heather Hoodies','#676769',2,1),(54,'Maroon Hoodies','#88353C',2,1),(55,'Carolina BLue Hoodies','#6299DD',2,1),(56,'Safety Orange Hoodies','#FF5400',2,1),(57,'Heliconia Hoodies','#ED2870',2,1),(58,'Charcoal Hoodies','#827F77',2,1),(59,'Forest Green Hoodies','#1c3d28',2,1),(60,'Irish Green Hoodies','#1f6522',2,1),(61,'Light Pink Hoodies','#FFD5D5',2,1),(62,'Black Vneck','#222222',6,1),(63,'Navy Vneck','#222353',6,1),(64,'Deep Heather Vneck','#616672',6,1),(65,'True Royal Vneck','#193C84',6,1),(66,'Steal Blue Vneck','#5C88A4',6,1),(67,'Purple Vneck','#510B7D',6,1),(68,'Althetic Heather Vneck','#C4C3C3',6,1),(69,'Dark Grey Heather Vneck','#38393a',6,1),(70,'Red Vneck','#BB0712',6,1),(71,'Deep orange women tees','#CA522F',3,1),(72,'White women tees','#F7F7F7',3,1),(73,'Light Heather grey women tees','#D1D1D1',3,1),(74,'Purple women tees','#523885',3,1),(75,'Deep royal women tees','#22488F',3,1),(76,'Kelly Green women tees','#448e4f',3,1),(77,'Lemon yellow women tees','#FCF58B',3,1),(78,'Classic Red women tees','#ba393f',3,1),(79,'New Navy women tees','#0C1A2C',3,1),(80,'Black women tees','#222222',3,1),(81,'Grey women tees','#ADB1B0',3,1),(82,'True Pink women tees','#ea80ac',3,1),(83,'Heathered Pink Raspberry women tees','#b25192',3,1),(84,'Heathered Charcoal women tees','#433e44',3,1),(85,'True Royal women\'s tanktop','#282FA4',7,1),(86,'Kelly women\'s tanktop','#007E51',7,1),(87,'Red women\'s tanktop','#B50A0A',7,1),(88,'Soft Pink women\'s tanktop','#FFDEF5',7,1),(89,'Black women\'s tanktop','#000000',7,1),(90,'Coral women\'s tanktop','#F77E73',7,1),(91,'Midnight women\'s tanktop','#02021E',7,1),(92,'Dark grey heather women\'s tanktop','#222223',7,1),(93,'Neon Pink women\'s tanktop','#EF608F',7,1),(94,'Neon Yellow women\'s tanktop','#EDF212',7,1),(95,'Lemon yellow Kid\'s tee','#FCF68A',8,1),(96,'Light Heather grey Kid\'s tee','#AAA9AA',8,1),(97,'Purple Kid\'s tee','#6349A2',8,1),(98,'Deep royal Kid\'s tee','#21498F',8,1),(99,'Kelly Green Kid\'s tee','#41884E',8,1),(100,'Heathered Bright Turquoise Kid\'s tee','#439AD4',8,1),(101,'Classic Red Kid\'s tee','#ba393f',8,1),(102,'Heathered Charcoal Kid\'s tee','#423D43',8,1),(103,'Deep Orange Kid\'s tee','#CA532F',8,1),(104,'Heathered Pink Raspberry Kid\'s tee','#bb579a',8,1),(105,'True Pink Kid\'s tee','#ea80ac',8,1),(106,'New Navy Kid\'s tee','#0C1A2C',8,1),(107,'Black Kid\'s tee','#222222',8,1),(108,'White','#FFFFFF',1,1),(109,'White','#FFFFFF',2,1),(110,'White','#FFFFFF',3,1),(111,'White','#FFFFFF',4,1),(112,'White','#FFFFFF',5,1),(113,'White','#FFFFFF',6,1),(114,'White','#FFFFFF',7,1),(115,'White','#FFFFFF',8,1),(116,'White Guys Tee','#ffffff',10,2),(117,'Sports Grey Guys Tee','#b9b9b9',10,2),(118,'Dark Grey Guys Tee','#464646',10,2),(119,'Brown Guys Tee','#68381a',10,2),(120,'Light Pink Guys Tee','#ffbbd3',10,2),(121,'Hot Pink Guys Tee','#fb2360',10,2),(122,'Red Guys Tee','#c10d0f',10,2),(123,'Orange Guys Tee','#ff3e04',10,2),(124,'Yellow Guys Tee','#ffc322',10,2),(125,'Green Guys Tee','#399548',10,2),(126,'Forest Guys Tee','#2d391c',10,2),(127,'Light Blue Guys Tee','#c3e2f1',10,2),(128,'Royal Blue Guys Tee','#324e94',10,2),(129,'Navy Blue Guys Tee','#03031f',10,2),(130,'Purple Guys Tee','#433161',10,2),(131,'Black Guys Tee','#000000',10,2),(132,'Maroon Guys Tee','#470009',10,2),(133,'White Ladies Tee\n','#ffffff',11,2),(134,'Sports Grey Ladies Tee','#b9b9b9',11,2),(135,'Dark Grey Ladies Tee','#464646',11,2),(136,'Brown Ladies Tee','#68381a',11,2),(137,'Light Pink Ladies Tee','#ffbbd3',11,2),(138,'Hot Pink Ladies Tee','#fb2360',11,2),(139,'Red Ladies Tee','#c10d0f',11,2),(140,'Orange Ladies Tee','#ff3e04',11,2),(141,'Yellow Ladies Tee','#ffc322',11,2),(142,'Green Ladies Tee','#399548',11,2),(143,'Forest Ladies Tee','#2d391c',11,2),(144,'Light Blue Ladies Tee','#c3e2f1',11,2),(145,'Royal Blue Ladies Tee','#324e94',11,2),(146,'Navy Blue Ladies Tee','#03031f',11,2),(147,'Purple Ladies Tee','#433161',11,2),(148,'Black Ladies Tee','#000000',11,2),(149,'Maroon Ladies Tee','#470009',11,2),(150,'White Youth Tee\r\n\r\n','#ffffff',12,2),(151,'Sports Grey Youth Tee','#b9b9b9',12,2),(152,'Dark Grey Youth Tee','#464646',12,2),(153,'Red Youth Tee','#c10d0f',12,2),(154,'Royal Blue Youth Tee','#324e94',12,2),(155,'Navy Blue Youth Tee','#03031f',12,2),(156,'Black Youth Tee','#000000',12,2),(157,'White Hoodie\r\n\r\n','#ffffff',13,2),(158,'Sports Grey Hoodie','#b9b9b9',13,2),(159,'Red Hoodie','#e70101',13,2),(160,'Green Hoodie','#399548',13,2),(161,'Forest Hoodie','#2d391c',13,2),(162,'Royal Blue Hoodie','#324e94',13,2),(163,'Navy Blue Hoodie','#03031f',13,2),(164,'Black Hoodie','#000000',13,2),(165,'Maroon Hoodie','#470009',13,2),(166,'Charcoal Hoodie','#444244',13,2),(167,'White Sweat Shirt\r\n\r\n','#ffffff',14,2),(168,'Sports Grey Sweat Shirt','#b9b9b9',14,2),(169,'Red Sweat Shirt','#c10d0f',14,2),(170,'Forest Sweat Shirt','#2d391c',14,2),(171,'Royal Blue Sweat Shirt','#324e94',14,2),(172,'Navy Blue Sweat Shirt','#03031f',14,2),(173,'Black Sweat Shirt','#000000',14,2),(174,'White Guys V-Neck\r\n\r\n\r\n','#ffffff',15,2),(175,'Sports Grey Guys V-Neck','#b9b9b9',15,2),(176,'Red Guys V-Neck','#c10d0f',15,2),(177,'Navy Blue Guys V-Neck','#03031f',15,2),(178,'Black Guys V-Neck','#000000',15,2),(179,'White Ladies V-Neck\r\n\r\n','#ffffff',16,2),(180,'Dark Grey Ladies V-Neck','#464646',16,2),(181,'Red Ladies V-Neck','#c10d0f',16,2),(182,'Royal Blue Ladies V-Neck','#324e94',16,2),(183,'Navy Blue Ladies V-Neck','#03031f',16,2),(184,'Purple Ladies V-Neck','#433161',16,2),(185,'Black Ladies V-Neck','#000000',16,2),(186,'White Unisex Tank Top\r\n\r\n','#ffffff',17,2),(187,'Sports Grey Unisex Tank Top','#b9b9b9',17,2),(188,'Red Unisex Tank Top','#c10d0f',17,2),(189,'Royal Blue Unisex Tank Top','#324e94',17,2),(190,'Navy Blue Unisex Tank Top','#03031f',17,2),(191,'Black Unisex Tank Top','#000000',17,2),(192,'White Unisex Long Sleeve\r\n\r\n\r\n','#ffffff',18,2),(193,'Sports Grey Unisex Long Sleeve','#b9b9b9',18,2),(194,'Red Unisex Long Sleeve','#c10d0f',18,2),(195,'Dark Grey Unisex Long Sleeve','#464646',18,2),(196,'Navy Blue Unisex Long Sleeve','#03031f',18,2),(197,'Black Unisex Long Sleeve','#000000',18,2),(198,'Black Leggings','#000000',19,2),(199,'Black Coffee Mug','#000000',20,2),(200,'White Coffee Mug','#ffffff',20,2),(201,'White Coffee Mug Change','#ffffff',21,2),(202,'Red Hat','#c10d0f',22,2),(203,'Green Hat','#399548',22,2),(204,'Royal Blue Hat','#324e94',22,2),(205,'Navy Blue Hat','#03031f',22,2),(206,'Black Ladies Hat','#000000',22,2),(207,'White Trucker Hat','#ffffff',23,2),(208,'Dark Grey Trucker Hat','#464646',23,2),(209,'Black Trucker Hat','#000000',23,2),(210,'Navy Blue Trucker Hat','#03031f',23,2);
/*!40000 ALTER TABLE `order_product_color` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_product_rate`
--

DROP TABLE IF EXISTS `order_product_rate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_product_rate` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `product_id` bigint(20) NOT NULL,
  `username` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `rate` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_product_rate`
--

LOCK TABLES `order_product_rate` WRITE;
/*!40000 ALTER TABLE `order_product_rate` DISABLE KEYS */;
/*!40000 ALTER TABLE `order_product_rate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_product_size`
--

DROP TABLE IF EXISTS `order_product_size`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_product_size` (
  `size_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `size_name` varchar(10) NOT NULL,
  `size_additional_cost` varchar(5) NOT NULL DEFAULT '0',
  `flashformid` int(11) DEFAULT '1',
  PRIMARY KEY (`size_id`),
  KEY `flashformid` (`flashformid`)
) ENGINE=MyISAM AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_product_size`
--

LOCK TABLES `order_product_size` WRITE;
/*!40000 ALTER TABLE `order_product_size` DISABLE KEYS */;
INSERT INTO `order_product_size` (`size_id`, `size_name`, `size_additional_cost`, `flashformid`) VALUES (1,'XS','0',1),(2,'S','0',1),(3,'M','0',1),(4,'L','0',1),(5,'XL','0',1),(6,'2XL','2',1),(7,'3XL','2',1),(8,'4XL','2',1),(9,'5XL','2',1),(10,'XS','0',2),(11,'S','0',2),(12,'M','0',2),(13,'L','0',2),(14,'XL','0',2),(15,'2XL','3',2),(16,'3XL','3',2),(17,'4XL','3',2),(18,'5XL','3',2),(19,'-','0',2);
/*!40000 ALTER TABLE `order_product_size` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_product_style`
--

DROP TABLE IF EXISTS `order_product_style`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_product_style` (
  `style_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `style_name` varchar(50) NOT NULL,
  `ishavebehide` tinyint(1) NOT NULL DEFAULT '1',
  `style_listsize` varchar(50) NOT NULL,
  `style_cost` varchar(10) DEFAULT '0',
  `flashformid` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`style_id`),
  KEY `flashformid` (`flashformid`)
) ENGINE=MyISAM AUTO_INCREMENT=27 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_product_style`
--

LOCK TABLES `order_product_style` WRITE;
/*!40000 ALTER TABLE `order_product_style` DISABLE KEYS */;
INSERT INTO `order_product_style` (`style_id`, `style_name`, `ishavebehide`, `style_listsize`, `style_cost`, `flashformid`) VALUES (1,'Basic Tees',1,'2,3,4,5,6,7,8','21.99',1),(2,'Hoodies & Sweatshirts',1,'2,3,4,5,6,7,8','38.99',1),(3,'Woman\'s Tees',1,'1,2,3,4,5,6,7','22.99',1),(4,'Long Sleeve Tees',1,'2,3,4,5,6,7,8','25.99',1),(5,'Gildan Unisex Tank',1,'2,3,4,5,6','21.99',1),(6,'V-Neck Tees',1,'1,2,3,4,5,6','23.99',1),(7,'Women\'s Flowy Tank',1,'2,3,4,5,6,7','26.99',1),(8,'Kids Premium Tees',1,'1,2,3,4,5','18.99',1),(9,'Kids Premium Tees',1,'1,2,3,4,5','18.99',1),(10,'Guys Tee',1,'11,12,13,14,15,16,17,18','21.99',2),(11,'Ladies Tee',1,'11,12,13,14,15,16','22.99',2),(12,'Youth Tee',1,'10,11,12,13,14','22.99',2),(13,'Hoodie',1,'11,12,13,14,15,16,17,18','38.99',2),(14,'Sweat Shirt',1,'11,12,13,14,15','34.99',2),(15,'Guys V-Neck',1,'11,12,13,14,15','24.99',2),(16,'LadiesV-Neck',1,'11,12,13,14,15','24.99',2),(17,'Unisex Tank Top',1,'11,12,13,14,15','24.99',2),(18,'Unisex Long Sleeve',1,'11,12,13,14,15','34.99',2),(19,'Leggings',0,'19','39.99',2),(20,'Coffee Mug',1,'19','16.99',2),(21,'Coffee Mug Change',1,'19','16.99',2),(22,'Hat',0,'19','19.99',2),(23,'Trucker Hat',0,'19','39.99',2);
/*!40000 ALTER TABLE `order_product_style` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_session`
--

DROP TABLE IF EXISTS `order_session`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_session` (
  `session_id` int(11) NOT NULL,
  `ip` varchar(20) NOT NULL,
  `username` varchar(50) NOT NULL,
  `last_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `isadmin` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`session_id`),
  KEY `fk_username` (`username`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_session`
--

LOCK TABLES `order_session` WRITE;
/*!40000 ALTER TABLE `order_session` DISABLE KEYS */;
INSERT INTO `order_session` (`session_id`, `ip`, `username`, `last_time`, `isadmin`) VALUES (2,'123.21.231.28','hoang.nguyen142536@gmail.com','2017-10-24 06:14:27',0);
/*!40000 ALTER TABLE `order_session` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_status`
--

DROP TABLE IF EXISTS `order_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_status` (
  `id` smallint(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `cssclass` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `isenable` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_status`
--

LOCK TABLES `order_status` WRITE;
/*!40000 ALTER TABLE `order_status` DISABLE KEYS */;
INSERT INTO `order_status` (`id`, `name`, `cssclass`, `isenable`) VALUES (1,'All','',1),(2,'Sold','label label-sm label-info arrowed arrowed-righ',1),(3,'In Transit','label label-sm label-warning',1),(4,'Delivered','label label-sm label-success',1),(5,'Deleted (Coming Soon)','',0);
/*!40000 ALTER TABLE `order_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_user`
--

DROP TABLE IF EXISTS `order_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_user` (
  `username` varchar(50) NOT NULL,
  `usernamemd5` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `userimage` varchar(100) NOT NULL,
  `promosion_money` double NOT NULL DEFAULT '0',
  `proInfo` varchar(200) NOT NULL,
  `email` varchar(50) NOT NULL,
  `fullname` varchar(30) NOT NULL,
  `street_address` varchar(30) NOT NULL,
  `apt_suite_other` varchar(30) NOT NULL,
  `city` varchar(30) NOT NULL,
  `postal_code` varchar(10) NOT NULL,
  `country_id` int(11) NOT NULL,
  `phone_number` varchar(20) NOT NULL,
  `province` varchar(50) NOT NULL,
  `isenable` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`username`),
  KEY `fk_country` (`country_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_user`
--

LOCK TABLES `order_user` WRITE;
/*!40000 ALTER TABLE `order_user` DISABLE KEYS */;
INSERT INTO `order_user` (`username`, `usernamemd5`, `password`, `userimage`, `promosion_money`, `proInfo`, `email`, `fullname`, `street_address`, `apt_suite_other`, `city`, `postal_code`, `country_id`, `phone_number`, `province`, `isenable`) VALUES ('lahau16@gmail.com','6460f7c64f59467d58328d4b417da454','1bacaf2ed566eb9255043bab6811e50f','http://zeeping.com/image/UserImage/lahau16@gmail.com.JPG',206.91000000000003,'','lahau16@gmail.com','hau la','quan binh thanh','','hcm','70000',1,'01234156556','hcm',1),('hoang.nguyen142536@gmail.com','559dc75e74326e3c2813519dc521271d','b7e0c00e1e30354c930528ca82b3a3ee','https://zeeping.com/image/UserImage/hoang.nguyen142536@gmail.com.jpg',66.97,'','hoang.nguyen142536@gmail.com','hoang','42342','','423423','23423423',1,'0934162993','423423',1),('tuanbanks1@gmail.com','46b15c37fb23dabe386a9b0dfdf16b6a','691b4e31bc41a8c7e6ebd278af2115d0','',22.99,'','tuanbanks1@gmail.com','minh tuan','quan binh thanh','','hcm','700000',7,'0909999999','hcm',1),('tuanbanks@gmail.com','a9d3e23e7dbe2aa68410c00ab913ec85','e10adc3949ba59abbe56e057f20f883e','http://zeeping.com/image/UserImage/tuanbanks@gmail.com.jpg',44.98,'','tuanbanks@gmail.com','tun du','quan binh thanh','','ho chi minh','700000',1,'78798','ho chi minh',1),('giangtruong.tranluong@gmail.com','6c7f1326ca469ccdfcbf0a720d3d2a80','b922e6b4962886835dbed77405626cfb','http://zeeping.com/image/UserImage/giangtruong.tranluong@gmail.com.jpg',1000065.97,'','giangtruong.tranluong@gmail.com','giang cute','16 hht','','hcm','700000',1,'0898190026','deotindc',1),('4dpdmen@gmail.com','8b86bc479086443207d6020bcfd441b3','c4ca4238a0b923820dcc509a6f75849b','http://zeeping.com/image/UserImage/4dpdmen@gmail.com.png',0,'','4dpdmen@gmail.com','tana','123456','','123','123456',1,'123456','123',1),('giangjuve1@yahoo.com','fd4b94a2b9ec01a881ad21e76874df0a','','',0,'','giangjuve1@yahoo.com','','','','','',0,'','',0),('giangfetel@gmail.com','c1cdfa512b0939b9ed182fbdec186399','4297f44b13955235245b2497399d7a93','',0,'','giangfetel@gmail.com','giang truong','cac','','lon','84',1,'0898190026','chim',1),('giangjuve2@yahoo.com','abc9adabcd92cba1ee8df00170057a58','e10adc3949ba59abbe56e057f20f883e','',0,'','giangjuve2@yahoo.com','zeeping','295 mai huynh','','noi bai','78952165',5,'1645687981','dunno',1),('giangjuve3@yahoo.com','6051fe08b780c73d34ec10d20d6caf1d','4297f44b13955235245b2497399d7a93','',0,'','giangjuve3@yahoo.com','giang cuteeeee','16 hoang hoa tham','','ho chi minh','84',1,'0898190026','ho chi minh',1),('giangjuve4@yahoo.com','fb848194aef99bedc2c1221268a4011e','','',0,'','giangjuve4@yahoo.com','','','','','',0,'','',0),('boycodon9x2007@gmail.com','3e4bbfc17e0099b8887cc19e1b59202e','','',0,'','boycodon9x2007@gmail.com','','','','','',0,'','',0),('giangjuve5@yahoo.com','cc45abd9ce6ff948d480bcefa6a93200','','',0,'','giangjuve5@yahoo.com','','','','','',0,'','',0);
/*!40000 ALTER TABLE `order_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_user_forgot_password`
--

DROP TABLE IF EXISTS `order_user_forgot_password`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_user_forgot_password` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `newpassword` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `fullname` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `createddate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_user_forgot_password`
--

LOCK TABLES `order_user_forgot_password` WRITE;
/*!40000 ALTER TABLE `order_user_forgot_password` DISABLE KEYS */;
/*!40000 ALTER TABLE `order_user_forgot_password` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_user_promosion`
--

DROP TABLE IF EXISTS `order_user_promosion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_user_promosion` (
  `id` smallint(6) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `promosion_begin` double NOT NULL,
  `promosion_end` double NOT NULL,
  `promosion_value` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_user_promosion`
--

LOCK TABLES `order_user_promosion` WRITE;
/*!40000 ALTER TABLE `order_user_promosion` DISABLE KEYS */;
INSERT INTO `order_user_promosion` (`id`, `name`, `promosion_begin`, `promosion_end`, `promosion_value`) VALUES (1,'Normal Member',0,149.99,10),(2,'Silver Member',150,399.99,15),(3,'Golden Member',400,999.99,20),(4,'Super Golden Member',1000,1000000,25);
/*!40000 ALTER TABLE `order_user_promosion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_user_support`
--

DROP TABLE IF EXISTS `order_user_support`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_user_support` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `mail` varchar(50) NOT NULL,
  `phonenumber` varchar(20) NOT NULL,
  `message` varchar(1000) NOT NULL,
  `createddate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `isreplied` tinyint(1) NOT NULL DEFAULT '0',
  `repliedsubject` varchar(50) NOT NULL DEFAULT '',
  `repliedmessage` varchar(1000) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_user_support`
--

LOCK TABLES `order_user_support` WRITE;
/*!40000 ALTER TABLE `order_user_support` DISABLE KEYS */;
INSERT INTO `order_user_support` (`id`, `name`, `mail`, `phonenumber`, `message`, `createddate`, `isreplied`, `repliedsubject`, `repliedmessage`) VALUES (1,'hoang','hoang.nguyen142536@gmail.com','0890890890','','2017-08-17 15:57:55',1,'Support - Zeeping: Reply your questions','Dear hoang,\n\ntest mail nhes\n\nThanks & Best Regards,\nZeeping Support Team.'),(2,'hoang','hoang.nguyen142536@gmail.com','0890890890','','2017-08-17 15:57:55',1,'Support - Zeeping: Reply your questions','Dear hoang,\n\ntest send mail\n\nThanks & Best Regards,\nZeeping Support Team.'),(3,'534534','hoang.nguyen142536@gmail.com','0890890890','534534','2017-08-17 15:57:55',1,'Support - Zeeping: Reply your questions','Dear 534534,\n\ntest mail nhé\n\nThanks & Best Regards,\nZeeping Support Team.'),(4,'hoang','hoang.nguyen142536@gmail.com','01234156556','tuan du co phai ko ?','2017-08-17 15:57:55',1,'Support - Zeeping: Reply your questions','Dear hoang,\n\n23423423423\n\nThanks & Best Regards,\nZeeping Support Team.'),(5,'hau','lahau16@gmail.com','01638061306','test luong xu ly suppoty','2017-08-17 15:57:55',1,'Support - Zeeping: Reply your questions','Dear hau,\n\ntest luong xu ly support\n\nThanks & Best Regards,\nZeeping Support Team.'),(6,'hoang','hoang.nguyen142536@gmail.com','0934162993','test thu mail xem the nao','2017-08-17 15:57:55',1,'Support - Zeeping: Reply your questions','Dear hoang,\n\nfeedback mail test\n\nThanks & Best Regards,\nZeeping Support Team.'),(7,'hoang','hoang.nguyen142536@gmail.com','0934162993','test mail nhe','2017-08-23 14:08:05',1,'Support - Zeeping: Reply your questions','Dear hoang,\n\nhoang test mail\n\nThanks & Best Regards,\nZeeping Support Team.\n\n<img src=\"http://zeeping.com/image/common/logo.jpg\" style=\"width:200px;height:100px\" />'),(8,'hoang','hoang.nguyen142536@gmail.com','0934162993','test mail nhe','2017-08-23 14:22:20',1,'Support - Zeeping: Reply your questions','Dear hoang,\n\nhoang test\n\nThanks & Best Regards,\nZeeping Support Team.\n\n<img src=\"http://zeeping.com/image/common/logo.jpg\" style=\"width:200px;height:100px\" />'),(9,'hoang','hoang.nguyen142536@gmail.com','0934162993','hoang test thu the nao','2017-08-29 11:31:38',1,'Support - Zeeping: Reply your questions','Dear hoang,\n\nhoang test mail\n\nThanks & Best Regards,\nZeeping Support Team.\n\n<img src=\"http://zeeping.com/image/common/logo.jpg\" style=\"width:200px;height:100px\" />');
/*!40000 ALTER TABLE `order_user_support` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scrum_priority`
--

DROP TABLE IF EXISTS `scrum_priority`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `scrum_priority` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scrum_priority`
--

LOCK TABLES `scrum_priority` WRITE;
/*!40000 ALTER TABLE `scrum_priority` DISABLE KEYS */;
INSERT INTO `scrum_priority` (`id`, `name`) VALUES (1,'Very high'),(2,'High'),(3,'Medium'),(4,'Low'),(5,'Very low');
/*!40000 ALTER TABLE `scrum_priority` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scrum_related`
--

DROP TABLE IF EXISTS `scrum_related`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `scrum_related` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scrum_related`
--

LOCK TABLES `scrum_related` WRITE;
/*!40000 ALTER TABLE `scrum_related` DISABLE KEYS */;
INSERT INTO `scrum_related` (`id`, `name`) VALUES (1,'Facebook Ads'),(2,'Google Ads'),(3,'Web Design'),(4,'Web Logic'),(5,'Dashboard Admin'),(6,'DashBoard User');
/*!40000 ALTER TABLE `scrum_related` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scrum_status`
--

DROP TABLE IF EXISTS `scrum_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `scrum_status` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scrum_status`
--

LOCK TABLES `scrum_status` WRITE;
/*!40000 ALTER TABLE `scrum_status` DISABLE KEYS */;
INSERT INTO `scrum_status` (`id`, `name`) VALUES (1,'To do'),(2,'In progress'),(3,'In Review'),(4,'Pending/Need Help'),(5,'Done');
/*!40000 ALTER TABLE `scrum_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scrum_ticket`
--

DROP TABLE IF EXISTS `scrum_ticket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `scrum_ticket` (
  `id` bigint(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(500) CHARACTER SET utf8 COLLATE utf8_unicode_520_ci NOT NULL,
  `reviewdescription` text NOT NULL,
  `priority` int(11) NOT NULL,
  `related` int(11) NOT NULL,
  `assigner` varchar(50) NOT NULL,
  `creater` varchar(50) NOT NULL,
  `status` int(11) NOT NULL,
  `createdate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `donedate` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `priority` (`priority`),
  KEY `related` (`related`),
  KEY `status` (`status`)
) ENGINE=MyISAM AUTO_INCREMENT=70 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scrum_ticket`
--

LOCK TABLES `scrum_ticket` WRITE;
/*!40000 ALTER TABLE `scrum_ticket` DISABLE KEYS */;
INSERT INTO `scrum_ticket` (`id`, `name`, `description`, `reviewdescription`, `priority`, `related`, `assigner`, `creater`, `status`, `createdate`, `donedate`) VALUES (61,'A.Hoang- can ch?nh hi?n th? page','\0H\0i\0e\0n\0 \0t\0h\0i\0 \0c\0o\0 \0d\0i\0n\0h\0 \0o\0 \0g\0i\0u\0a\0 \0p\0a\0g\0e','\0h\0o\0a\0n\0g\0 \0:\0 \0R\0u\0n\0 \0\r\0\n',1,3,'hoang','thuan',2,'2017-08-16 22:17:26','0000-00-00 00:00:00'),(63,'A.Tan - Dieu chinh noi dung footer','','',1,3,'tana','thuan',1,'2017-08-16 22:19:03','0000-00-00 00:00:00'),(64,'4- A.Giang- Dieu chinh 4 step dat hang','','',1,3,'admin','thuan',1,'2017-08-16 22:20:04','0000-00-00 00:00:00'),(65,'5- A.Thang- Noi dung + Demo 1 Collection','\0A\0.\0H\0o\0a\0n\0g\0 \0h\0o\0 \0t\0r\0o','',1,1,'admin','thuan',1,'2017-08-16 22:37:37','0000-00-00 00:00:00'),(66,'6- A.Giang- code tracking cho zeeping','\0A\0.\0H\0o\0a\0n\0g\0 \0h\0o\0 \0t\0r\0o','',1,1,'giang','thuan',1,'2017-08-16 22:38:55','0000-00-00 00:00:00'),(67,'hoàn thành giao di?n áo hoàn ch?nh','','\0\r\0\n\0t\0u\0a\0n\0 \0:\0 \0a\0n\0g\0 \0h\0o\0à\0n\0 \0t\0h\0à\0n\0h\0 \0të\0 \0të\0\r\0\n',1,1,'tuan','tuan',2,'2017-08-25 18:31:36','0000-00-00 00:00:00'),(68,'ch?n quote và thuê design áo d?u tiên','\0s½\0 \0h\0o\0à\0n\0 \0t\0h\0à\0n\0h\0 \0t\0r°Û\0c\0 \0n\0g\0à\0y\0 \01\00\0/\08','',1,1,'tuan','tuan',1,'2017-08-25 18:32:18','0000-00-00 00:00:00'),(69,'design áo th? 2 choi tren','\0h\0o\0à\0n\0 \0t\0h\0à\0n\0h\0 \0t\0r\0c\0 \0n\0g\0à\0y\0 \01\05\0/\09','\0\r\0\n\0t\0u\0a\0n\0 \0:\0 \0d\0i\0s\0 \0m¹\0 \0a\0l\0l\0\r\0\n',1,1,'tuan','tuan',2,'2017-08-25 18:32:38','0000-00-00 00:00:00');
/*!40000 ALTER TABLE `scrum_ticket` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `web_collections`
--

DROP TABLE IF EXISTS `web_collections`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `web_collections` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `featureimage` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `title` varchar(200) COLLATE utf8_unicode_ci NOT NULL,
  `description` varchar(1000) COLLATE utf8_unicode_ci NOT NULL,
  `content` varchar(15000) COLLATE utf8_unicode_ci NOT NULL,
  `relatedmenu` int(11) NOT NULL,
  `createdDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `isdraft` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `relatedmenu` (`relatedmenu`)
) ENGINE=MyISAM AUTO_INCREMENT=20 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `web_collections`
--

LOCK TABLES `web_collections` WRITE;
/*!40000 ALTER TABLE `web_collections` DISABLE KEYS */;
INSERT INTO `web_collections` (`id`, `name`, `featureimage`, `title`, `description`, `content`, `relatedmenu`, `createdDate`, `isdraft`) VALUES (19,'this-is-the-best-waterboarding','this-is-the-best-waterboarding.jpg','This is the best waterboarding','<span style=\"display:none\">Waterboarding is when is baptize. Terrorists with freedom </span>','<img src=\"http://zeeping.com/image/collections/-1/waterboarding.png\"  style=\"width:50%;margin-left:25%\"><br/><br/><div  style=\"text-align:center;font-size:1.325em\"><strong>Humanity with enemies which is killed ourselves.</strong> </div> <br/><div style=\"text-align:center\"><br/>The Islam extremist is so cruel. They killed many innocent persons, woman and children to achieve their goals. We who love freedom is ready to fight against them by military, minding, propaganda to bring peace into America and our alliances. <br/><br/>IS which terrorism organization massacring by them. They bring fear around the world and declaring war to America and Western countries. We don\'t ignore, we must fight and win this war. Freedom isn\'t free, we must use force to fight against IS terrorism<br/>Make America great again. God bless you.<br/></div>',5,'2017-09-15 19:18:06',0);
/*!40000 ALTER TABLE `web_collections` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `web_menu_group`
--

DROP TABLE IF EXISTS `web_menu_group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `web_menu_group` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `stt` int(11) NOT NULL DEFAULT '1',
  `floor` smallint(6) NOT NULL DEFAULT '1',
  `childof` varchar(50) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `link` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `isPage` tinyint(1) NOT NULL DEFAULT '1',
  `Isflash` tinyint(1) NOT NULL DEFAULT '0',
  `isvisible` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=18 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `web_menu_group`
--

LOCK TABLES `web_menu_group` WRITE;
/*!40000 ALTER TABLE `web_menu_group` DISABLE KEYS */;
INSERT INTO `web_menu_group` (`id`, `stt`, `floor`, `childof`, `name`, `link`, `isPage`, `Isflash`, `isvisible`) VALUES (1,1,1,'','Home','',0,0,1),(2,2,1,'','Men','men',0,0,1),(3,3,1,'','Women','women',0,0,1),(4,4,1,'','About us','about-us',1,0,0),(5,5,1,'','Collections','collections',0,1,0),(9,6,1,'','Zeeping point system','zeeping-point-system',1,0,0),(10,1,1,'','About Shipping','about-shipping',1,0,0),(11,1,1,'','About Payment','about-payment',1,0,0),(13,1,1,'','Terms Conditions','terms-conditions',1,0,0),(14,1,1,'','Privacy Security','privacy-security',1,0,0),(16,1,1,'','Zeeping Size Guide','zeeping-size-guide',1,0,0),(17,1,1,'','Purchase Guideline','purchase-guideline',1,0,0);
/*!40000 ALTER TABLE `web_menu_group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `web_menu_page`
--

DROP TABLE IF EXISTS `web_menu_page`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `web_menu_page` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(200) COLLATE utf8_unicode_ci NOT NULL,
  `content` varchar(20000) COLLATE utf8_unicode_ci NOT NULL,
  `relatedmenu` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `relatedmenu` (`relatedmenu`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `web_menu_page`
--

LOCK TABLES `web_menu_page` WRITE;
/*!40000 ALTER TABLE `web_menu_page` DISABLE KEYS */;
INSERT INTO `web_menu_page` (`id`, `title`, `content`, `relatedmenu`) VALUES (1,'About Us','<br/>\n<br/>\nZeeping is a specialized online T-shirt store website, we supply designed fashionable and meaningful T-shirt with high quality. Moreover, we will deliver our products around the world with Teespring.com support<br/><br/>\n\nWith cooperation with Teespring which is best website seller about designed T-shirt. And Zeeping\'s creation staffs who bring wonderful online shopping experience for all customers. Especially, we always have interesting promotion programs for customers<br/><br/>\n\nFor the customers who doesn\'t have Zeeping\'account:<br/>\n     &nbsp;&nbsp;&nbsp;&nbsp;Step1: Choose any products which you love by yourself<br/>\n     &nbsp;&nbsp;&nbsp;&nbsp;Step2: Now, you have two ways to buy product you like<br/>\n      &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;   - Click button \" Buy with Teespring\". After, automatically send to Teespring.com and you can buy product directly<br/>\n      &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;   - If you would like to discount for following buying, click button \"Discount\". Then, you fill out your e-mails and automatically send to Teespring.com and you buy. Then, we are going to supply Zeeping\'s account to your e-mails and you can receive accumulation point discount. ( We will supply Zeeping\'account within 6 hours when you traded completely)<br/><br/>\n\nFor the customers who have Zeeping\'account<br/>\n     &nbsp;&nbsp;&nbsp;&nbsp;- Now, you are Zeeping\'patrons and you are going to be received attractive promotion <br/>\n     &nbsp;&nbsp;&nbsp;&nbsp;- Please log in your account which we sended .You can buy any products at Zeeping.com.<br/>\n     &nbsp;&nbsp;&nbsp;&nbsp;- Then, you order directly at Zeeping.store with button \" Add to cart\" . <br/>\n     &nbsp;&nbsp;&nbsp;&nbsp;- Next to, you fill out your discount code which we will supply to your e-mails when you already bought any Zeeping\'products. <br/>\n     &nbsp;&nbsp;&nbsp;&nbsp;- Finally, you pay by Visa or Master Card or Paypal to Zeeping store and we commit Teespring which delivered to you at your place which you fill out. <br/><br/>\n\nEspecially, when you have Zeeping\'s account. If you want to print any designed T-shirts with the best price, please send to Zeeping\'s store about images, quotes, outlines, ideas you love. Next to, you design and sell designed T-shirt for you.\n',4),(2,'<font size=\"6\">Zeeping point system</font>','					<style type=\"text/css\" scoped=\"\">\r\n						.large{\r\n							font-size: 18px;\r\n						}\r\n						.small{\r\n							font-size: 16px;\r\n						}\r\n						strong {\r\n							font-weight: bold;\r\n						}\r\n					</style>\r\n					<br>\r\n					<br\r\n                   <p><br/></p>\r\n				   <p class=\"large\"><span><strong>What is the Zeeping Point?</strong></span></p>\r\n				   <p class=\"large\"><span>Zeeping Points are Points to use to get the percent discount. You can find the discount corresponding with your point as below:</span></p>\r\n					 <br/>\r\n					<p class=\"small\"><strong><span  style=\"color: rgb(0, 0, 255)\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;100 Points = 100USD at Zeeping.com</span></strong></p><br/>\r\n				  \r\n				   <p class=\"small\"><span>0 to 149 Points  : you will get 10% discount </span></p>		\r\n				   <p class=\"small\"><span>150 - 399 Points : you will get 15% discount </span></p>	\r\n				   <p class=\"small\"><span>400 - 999 Points : you will get 20% discount </span></p>	\r\n				   <p class=\"small\"><span>Over 1000 Points : you will get 25% discount </span></p>\r\n				   <br/><br/>\r\n				   <p ><span class=\"large\"><strong>How to Earn Points?</strong></span></p>\r\n				   <p ><span class=\"large\">For every Zeepinger, you will easily earn points with the following approach:</span></p>\r\n				   <p class=\"small\"><span><br/></span></p>\r\n				   <p class=\"large\"><strong><span>Approach NO.1:</span></strong></p>\r\n				   <p class=\"small\"><strong><span>Signing up for Zeeping will get you points!</span></strong></p>\r\n				   <p class=\"small\"><span>Simply registering an account at zeeping.com, and you will get at least 10 points.</span></p>\r\n				   <p class=\"small\"><span><br/></span></p>\r\n				   <p class=\"large\"><strong><span\">Approach NO.2:</span></strong></p>\r\n				   <p class=\"small\"><strong><span>Sharing Zeeping products on social networks to gain points!</span></strong></p>\r\n				   <p class=\"small\"><span> Share any Zeeping products on social networks or forums, and copy the link.</span></p>\r\n				   <p class=\"small\"><span>Notice:</span></p>\r\n				   <p class=\"small\"><span>1. Social networks would be: Facebook, Twitter, Pinterest, VK, Google Plus, and etc</span></p>\r\n				   <p class=\"small\"><span>2. Please share products on different networks and within 24 hours you can share only 1 link on the same platforms.</span></p>\r\n				   <p class=\"small\"><span><br/></span></p>\r\n				   <p class=\"large\"><strong><span>Approach NO.3:</span></strong></p>\r\n				   <p class=\"small\"><strong><span>Reviewing Zeeping products and earn Points!</span></strong></p>\r\n				   <p class=\"small\"><span>1. Sign into your zeeping account.</span></p>\r\n				   <p class=\"small\"><span>2. Choose any zeeping products, and write reviews. Each good review could achieve 5 Points.</span></p>\r\n				   <p class=\"small\"><span><br/></span></p>\r\n				   <p class=\"large\"><strong><span>Approach NO.4:</span></strong></p>\r\n				   <p class=\"small\"><strong><span style=\"color: rgb(0, 0, 255)\">Shopping at zeeping to receive Points!</span></strong></p>\r\n				   <p class=\"small\"><span>This is simply the most effective and easy way to get Zeeping Points. As long as you buy products at Zeeping.com, bonus points will be added to your account automatically after you receive your order. 1 USD spent could add 1 Zeeping Point to your account, as like $100 spent = 100 Points be added to your account! (Shipping fees is excluded)</span></p>\r\n				   <p class=\"small\"><span><br/></span></p><br/>\r\n				   <p class=\"large\"><span><strong>Where can I check my point status?</strong></span></p>\r\n				   <p class=\"small\"><span\">Log into your account and you will see your point status.</span></p>\r\n				   <p class=\"small\"><span><br/></span></p>\r\n				   <p ><span lang=\"EN-US\" style=\"font-family: &quot;Verdana&quot;,&quot;sans-serif&quot;; font-size: 19px\">Now you may start earning points to save money.<br/></span></p>\r\n				   <p><br/></p>  ',9),(3,'<font size=\"6\">About Shipping</font>','						<style type=\"text/css\" scoped>\n                            .large{\n				                font-size: 18px;\n				                font-family: Arial;\n			                }\n			                   .small{\n				                font-size: 14px;\n				                font-family: Arial;\n			                }\n                        </style>\n						<br>\n						<br>\n						<p class=\"large\"><span>Zeeping has three different shipping fees, depending on whether you\'re shipping an item to the US, Canada or International. Rush shipping is also available on some products with an additional fee.</span></p>\n						<br>\n						<p class=\"large\"><span>If you order items from multiple campaigns, and all items selected from each campaign qualify for Rush Handling/Shipping, the additional cost for the first shipment (items from the first campaign) and $3.00 for each additional shipment, (items from each additional campaign.)</span></p>\n						<br>\n						<p class=\"large\"><strong>US shipping rates:</strong></p>\n						<p class=\"small\">&nbsp;&nbsp;&nbsp;&nbsp;$3.99 flat rate, plus $2.00 per each additional item</p>\n						<p class=\"small\">&nbsp;&nbsp;&nbsp;&nbsp;£2.99 flat rate, plus £1.50 per each additional item</p>\n						<p class=\"small\">&nbsp;&nbsp;&nbsp;&nbsp;€3.99 flat rate, plus €2.00 per each additional item</p>\n						<p class=\"small\">&nbsp;&nbsp;&nbsp;&nbsp;$5.49 CAD flat rate, plus $2.50 CAD per each additional item</p>\n						<p class=\"small\">&nbsp;&nbsp;&nbsp;&nbsp;A$5.49 flat rate, plus A$3.00 per each additional item</p>\n						<br>\n						<p class=\"large\"><strong>Canadian shipping rates:</strong></p>\n						<p class=\"small\">&nbsp;&nbsp;&nbsp;&nbsp;$9.50 flat rate, plus $4.00 per each additional item</p>\n						<p class=\"small\">&nbsp;&nbsp;&nbsp;&nbsp;£6.49 flat rate, plus £3.00 per each additional item</p>\n						<p class=\"small\">&nbsp;&nbsp;&nbsp;&nbsp;€8.49 flat rate, plus €4.00 per each additional item</p>\n						<p class=\"small\">&nbsp;&nbsp;&nbsp;&nbsp;$11.49 CAD flat rate, plus $5.00 CAD per each additional item</p>\n						<p class=\"small\">&nbsp;&nbsp;&nbsp;&nbsp;A$11.99 flat rate, plus A$5.00 per each additional item</p>\n						<br>\n						<p class=\"large\"><strong>All other International shipping rates:</strong></p>\n						<p class=\"small\">&nbsp;&nbsp;&nbsp;&nbsp;$12.50 flat rate, plus $4.00 per each additional item</p>\n						<p class=\"small\">&nbsp;&nbsp;&nbsp;&nbsp;£7.99 flat rate, plus £3.50 per each additional item</p>\n						<p class=\"small\">&nbsp;&nbsp;&nbsp;&nbsp;€11.49 flat rate, plus €5.00 per each additional item</p>\n						<p class=\"small\">&nbsp;&nbsp;&nbsp;&nbsp;$15.49 CAD flat rate, plus $6.50 CAD per each additional item</p>\n						<p class=\"small\">&nbsp;&nbsp;&nbsp;&nbsp;A$15.99 flat rate, plus A$7.00 per each additional item</p>',10),(4,'<font size=\"6\">About Payment</font>','						<style type=\"text/css\" scoped>\r\n						.large{\r\n							font-size: 18px;\r\n						}\r\n						.small{\r\n							font-size: 16px;\r\n						}\r\n						</style>\r\n						<br>\r\n						<br>\r\n						<p class=\"large\"><span>To make your purchase from&nbsp;Zeeping as easy as possible, we offer a wide range of payment options. Currently we can&nbsp; accept payments in GBP (Pound Sterling), USD, Euro, CAD, AUD currency and so on.</span></p>\r\n						<br>\r\n						<p class=\"large\"><span>\r\n						We accept PayPal payments via our secure checkout system. We will only dispatch orders to the PayPal account holders registered address.</span></p>\r\n						<br>\r\n						<p class=\"large\"><span>\r\n						If you want to pay with credit card, you can just choose to pay by Paypal, then click \"pay\" button and there will be a webpage for you to enter your credit card information. </span></p>\r\n						<br>\r\n						<p class=\"large\" style=\"color: rgb(255, 0, 0);\"><span>Your order will be dispatched once payment is received. Please leave your name, delivery address, contact telephone number.</span></p>\r\n						<p>&nbsp;</p>\r\n						<p>&nbsp;</p>\r\n						<p class=\"large\" ><span style=\"color: rgb(0, 0, 255);\">Payment FAQs:<br>\r\n						</span><span>&nbsp;<br>\r\n						<strong>1. I want to make payment by Credit card but don\'t want to register paypal account, is that OK?</strong><br>\r\n						Yes, sure, it\'s OK. You can just choose to pay by Paypal, then click \"pay\" button and there will be a webpage for you to enter your credit card information. If anybody used Paypal in your computer before, you need to clean all the cache of your browser, then can pay by Credit card successfully. </span></p>\r\n						<br>\r\n						<p class=\"large\"><span>\r\n						<strong>2. I have credit balance from my previous order, but how can I use it in my new order?</strong><br>\r\n						When pay your order, there will be an option you can choose to use your balance.</span></p>\r\n						<p class=\"large\"><span>\r\n						&nbsp;&nbsp;&nbsp; <br>\r\n						<strong>3. Why the amount you received is less than what I paid in Bank?</strong><br>\r\n						Besides transaction fee in the bank you make transfer, also, there may be some third party Bank charging you in the process. That\'s because, if the bank in which you make payment has no business relationship with our bank, then payment may be sent to a third party bank first, and then send to our bank. If that happens, the third party will charge the transaction fee from the payment, so the payment time will be longer and the amount we receive will be less than the amount you pay.</span></p>\r\n						<p>&nbsp;</p>',11),(6,'<font size=\"6\">Terms Conditions</font>','						<style type=\"text/css\" scoped>\r\n							.large{\r\n								font-size: 18px;\r\n							}\r\n							.small{\r\n								font-size: 16px;\r\n							}\r\n						</style>\r\n						<br>\r\n						<br>\r\n						<p class=\"large\"><strong>Terms & Conditions</strong></p>\r\n						<p class=\"small\">The website is owned and operated by Zeeping Team. All names, brands, trademarks and logos are protected by copyright and can only be used with the permission of Zeeping.com. By using this website, you agree to be bound by the terms and conditions bellow. We reserve the right to correct or change any information on this site. Under this agreement, all your purchase will be processed by  \r\n						Zeeping Team and you will be contracting with that entity.</p>\r\n						<br>\r\n						<p class=\"large\"><strong>Copyright</strong></p>\r\n						<p class=\"small\">The entire content included in this site, including but not limited to text, graphics or code is copyrighted as a collective work under copyright laws, and is the property of Zeeping.com. The collective work includes works that are licensed to Zeeping.com. Copyright 2008, Zeeping.com ALL RIGHTS RESERVED.</p>\r\n						<p class=\"small\">Permission is granted to electronically copy and print hard copy portions of this site for the sole purpose of placing an order with Zeeping.com or purchasing Zeeping.com products. You may display and, subject to any expressly stated restrictions or limitations relating to specific material, download or print portions of the material from the different areas of the site solely for your own non-commercial use, or to place an order with Zeeping.com or to purchase Zeeping.com products. Any other use, including but not limited to the reproduction, distribution, display or transmission of the content of this site is strictly prohibited, unless authorized by Zeeping.com.You further agree not to change or delete any proprietary notices from materials downloaded from the site.</p>\r\n						<br>\r\n						<p class=\"large\"><strong>Limitation of liability</strong></p>\r\n						<p class=\"small\">Zeeping.com shall not be liable for any special or consequential damages that result from the use of, or the inability to use, the materials on this site or the performance of the products, even if Zeeping.com has been advised of the possibility of such damages. Applicable law may not allow the limitation of exclusion of liability or incidental or consequential damages, so the above limitation or exclusion may not apply to you.</p>\r\n						<br>\r\n						<p class=\"large\"><strong>Typographical errors</strong></p>\r\n						<p class=\"small\">While Zeeping.com strives to provide accurate product and pricing information, pricing or typographical errors may occur. Zeeping.com cannot confirm the price of an item until after you order. In the event that an item is listed at an incorrect price or with incorrect information due to an error in pricing or product information, Zeeping.com shall have the right, at our sole discretion, to refuse or cancel any orders placed for that item. In the event that an item is priced incorrectly, Zeeping.com may,at our discretion, either contact you for instructions or cancel your order and notify you of such cancellation.</p>\r\n						<br>\r\n						<p class=\"large\"><strong>Termination</strong></p>\r\n						<p class=\"small\">These terms and conditions are applicable to you upon your accessing the site and/or completing the registration or shopping process. These terms and conditions, or any part of them, may be terminated by Zeeping.com without notice at any time, for any reason. Any termination of this Agreement shall not affect the respective rights and obligations (including without limitation, payment obligations) of the parties arising before the date of termination.</p>\r\n						<br>\r\n						<p class=\"large\"><strong>Use of site</strong></p>\r\n						<p class=\"small\">Harassment in any manner or form on the site, including via e-mail, chat, or by use of obscene or abusive language, is strictly forbidden. Impersonation of others, including a Zeeping.com or other licensed employee, host, or representative, as well as other members or visitors on the site is prohibited. You may not upload to, distribute, or otherwise publish through the site any content which is libelous, defamatory, obscene, threatening, invasive of privacy or publicity rights, abusive, illegal, or otherwise objectionable which may constitute or encourage a criminal offense, violate the rights of any party or which may otherwise give rise to liability or violate any law. You may not upload commercial content on the site or use the site to solicit others to join or become members of any other commercial online service or other organization.</p>\r\n						<br>\r\n						<p class=\"large\"><strong>Links</strong></p>\r\n						<p class=\"small\">In an attempt to provide increased value to our visitors, Zeeping.com may link to sites operated by third parties. However, even if the third party is affiliated with Zeeping.com, Zeeping.com has no control over these linked sites, all of which have separate privacy and data collection practices, independent of Zeeping.com. These linked sites are only for your convenience and therefore you access them at your own risk. Nonetheless, Zeeping.com seeks to protect the integrity of its web site and the links placed upon it and therefore requests any feedback on not only its own site, but for sites it links to as well (including if a specific link does not work).</p>\r\n						<br>\r\n						<p class=\"large\"><strong>Different pricing currencies</strong></p>\r\n						<p class=\"small\">Pricing of products sold by Zeeping.com is based upon figures calculated in U.S. Dollars  (US$). Prices displayed in other currencies are converted from U.S. Dollars according to the most  up to date conversion rates.</p>\r\n						<p class=\"small\">Due to fluctuating currency values, prices displayed in non-U.S.  denominations of currency on the Site, other than on the individual product page, may not be the  most current. Areas of the Site where non-U.S. denominations of currency might be inaccurate  include, but are not limited to, promotional banners, promotional pages, and information on  product category pages. The price displayed on an individual product page, regardless of currency denomination, is the current price you are liable to pay to Zeeping.com, excluding shipping.</p>\r\n						<br>',13),(7,'<font size=\"6\">Privacy Security</font>','						<style type=\"text/css\" scoped>\n						.large{\n							font-size: 18px;\n						}\n						.small{\n							font-size: 16px;\n						}\n						a:link {\n							color: green; \n							background-color: transparent; \n							text-decoration: none;\n						}\n						a:visited {\n							color: #0a10ec;\n							background-color: transparent;\n							text-decoration: none;\n						}\n\n						a:hover {\n							color: #00a49d;\n							background-color: transparent;\n							text-decoration: underline;\n						}\n						</style>\n						<br>\n						<br>\n						<p class=\"large\"><font color=\"red\"><strong>Privacy</strong></font></p>\n						<p class=\"small\">Zeeping.com is committed to protecting our customers privacy. Please rest assured that all information about customers will not be disclosed to any third parties except for those who fulfill the delivery or any necessary process to check the order or payment. By placing an order with us, you consent to us collecting and using personal data about you as specified below in accordance with this policy statement. Any changes made to these terms will be posted here so that you are always kept informed about the collection and use of your personal information.</p>\n						<p class=\"small\">Secure Socket Layer (SSL), to process securely online credit card transaction. Your payment details is encrypted and cannot be read as it travels over the internet. Credit card numbers are not held in clear text within our web site.</p>\n						<br>\n						<p class=\"large\"><font color=\"red\"><strong>Collection and Use of Personal Data</strong></font></p>\n						<p class=\"small\">We will collect the shipping information of your order, including your name, address, telephone number, email address and anything else needed. This is necessary for us to process and fufill your order. </p>\n						<p class=\"small\">And then we will use your email address to send you the  tracking information after we ship it out. What\'s more, we will contact you via email or phone if there is any problems with the fulfillment of your order. </p>\n						<p class=\"small\">At last, we may occasionally email you with updates of our arrivals or promotions if you have ever palced an order from us. You can click the unsubscribe link at anytime if you don\'t want to receive it.</p>\n						<br>\n						<p class=\"large\"><font color=\"red\"><strong>Third Parties</strong></font></p>\n						<p class=\"small\">The details you provide to us will not be sold to third party organisations; they may only be shared for the purpose of processing your chosen order as outlined above. Our site may contain links to and from other websites, advertisers and third parties, in following these links you must also view that websites own privacy policies as we do not accept any responsibility or liability for these policies.</p>\n						<br>\n						<p class=\"large\"><font color=\"red\"><strong>Inaccuracies and corrections</strong></font></p>\n						<p class=\"small\">We aim to keep your personal data accurate and up to date. If you become aware of errors or inaccuracies, please contact us by&nbsp;clicking on the \"<a href=\"http://zeeping.com/customer/support.php\"><u>Contact Us</u></a>\" link in the menu.</p>\n						<br>',14),(9,'<font size=\"6\">Zeeping Size Guide</font>','						<style type=\"text/css\" scoped>\r\n							.large{\r\n								font-size: 18px;\r\n							}\r\n							.small{\r\n								font-size: 16px;\r\n							}\r\n						</style>\r\n						<br>\r\n						<br>\r\n						<br>\r\n						<div class=\"body row\">\r\n							<div class=\"col-md-12\">\r\n								<p class=\"large\"><strong>Please make sure you order the correct size that correlates to your measurements since all products are custom made.&nbsp;</strong></p>\r\n								<br>\r\n								<p class=\"small\">Unfortunately, exchanges and returns are not an option for Standard brand apparel. So please check the sizing chart provided on the campaign page you are purchasing from.</p>\r\n								<br>\r\n								<p class=\"small\">Below you will find US brands and measurements to help you select the correct size.</p>\r\n								<br>\r\n								<p class=\"small\">Meet Eirinie (size S), Dena (size L), and James (size M) sporting our most popular items. Please keep in mind that displayed \"width\" measurements span across the chest (from seam to seam, not full body).</p>\r\n								<br>\r\n								<p class=\"small\"><strong>Hanes Tagless Tee (Unisex)</strong></p>\r\n								<br>\r\n								<img src=\"http://zeeping.com/image/sizeguide/size_1.png\">\r\n								<br>\r\n								<br>\r\n								<p class=\"small\">James is wearing a size Medium with a height of 6\' and 30/31 waist&nbsp;</p>\r\n								<p class=\"small\">Eirinie is wearing a size Small with a height of 5\'11\" and 34\" bust, 25\" waist, 35\" hips&nbsp;</p>\r\n								<p class=\"small\">Dena is wearing a size Large with a height of 5\' 9\" and 43\" bust, 34\" waist, 46\" hips</p>\r\n								<br>\r\n								<br>\r\n								<img src=\"http://zeeping.com/image/sizeguide/size_2.png\" >\r\n								<br>\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>American Apparel Crew (Unisex)</strong></p>\r\n								<br>\r\n								<p class=\"small\">A fitted tee that runs true to size</p>\r\n								<br>\r\n								<img src=\"http://zeeping.com/image/sizeguide/size_3.png\">\r\n								<br>\r\n								<br>\r\n								<p class=\"small\">James is wearing a size Medium with a height of 6\' and 30/31 waist&nbsp;</p>\r\n								<p class=\"small\">Eirinie is wearing a size Small with a height of 5\'11\" and 34\" bust, 25\" waist, 35\" hips&nbsp;</p>\r\n								<p class=\"small\">Dena is wearing a size Large with a height of 5\' 9\" and 43\" bust, 34\" waist, 46\" hips</p>\r\n								&nbsp;<br>\r\n								<img src=\"http://zeeping.com/image/sizeguide/size_4.png\" ><br>\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Gildan Pullover Hoodie</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs true to size</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_5.png\" ><br>\r\n								<br>\r\n								<p class=\"small\">Nattie is wearing a size Small with a height of 5\'9\" a 32\" bust, 25\" waist, 36\" hips.&nbsp;</p>\r\n								&nbsp;<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_6.pngr\" >\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Gildan Long Sleeve Tee</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs true to size</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_7.png\" >\r\n								<br>\r\n								<br>\r\n								<p class=\"small\">Nattie is wearing a size Small with a height of 5\'9\" a 32\" bust, 25\" waist, 36\" hips.&nbsp;</p>\r\n								&nbsp;<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_8.png\" ><br>\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Premium Tee</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs small</p>\r\n								<br>\r\n								<img src=\"http://zeeping.com/image/sizeguide/size_9.png\">\r\n								<br>\r\n								<br>\r\n								<p class=\"small\">Nattie is wearing a size Small with a height of 5\'9\" a 32\" bust, 25\" waist, 36\" hips.&nbsp;</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_10.png\" ><br>\r\n								&nbsp;<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Hanes Crew Neck Sweatshirt</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs true to size</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_11.png\">\r\n								<br>\r\n								<br>\r\n								<p class=\"small\">Nattie is wearing a size Small with a height of 5\'9\" a 32\" bust, 25\" waist, 36\" hips.&nbsp;</p>\r\n								&nbsp;<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_12.png\" ><br>\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Women\'s Premium Tee</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs small</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_13.png\" >\r\n								<br>\r\n								<br>\r\n								<p class=\"small\">Erin is wearing a size Small with a height of 5\'8\" a 32\" bust, 26\" waist, 35.5\" hips.&nbsp;</p>\r\n								<p class=\"small\">Adriana is wearing a size 2XL with a height of 5\'11\" a 42\" bust, 36\" waist, 45\" hips. &nbsp;</p>\r\n								&nbsp;<br>\r\n								<img src=\"http://zeeping.com/image/sizeguide/size_14.png\" >\r\n								<br>\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Bella Flowy Tank</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs true to size</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_15.png\" >\r\n								<br>\r\n								<br>\r\n								<p class=\"small\">Erin is wearing a size Small with a height of 5\'8\" a 32\" bust, 26\" waist, 35.5\" hips.&nbsp;</p>\r\n								<p class=\"small\">Adriana is wearing a size 2XL with a height of 5\'11\" a 42\" bust, 36\" waist, 45\" hips. &nbsp;</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_16.png\" >\r\n								<br>\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Bella Slouchy Tee</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs true to size</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_17.png\" ><br>\r\n								<br>\r\n								<p class=\"small\">Erin is wearing a size Small with a height of 5\'8\" a 32\" bust, 26\" waist, 35.5\" hips.&nbsp;</p>\r\n								<p class=\"small\">Adriana is wearing a size 2XL with a height of 5\'11\" a 42\" bust, 36\" waist, 45\" hips. &nbsp;</p>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_18.png\">\r\n								<br>\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Gildan Women\'s Relaxed Tee</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs small</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_19.png\">\r\n								<br>\r\n								<br>\r\n								<p class=\"small\">Erin is wearing a size Small with a height of 5\'8\" a 32\" bust, 26\" waist, 35.5\" hips.&nbsp;</p>\r\n								<p class=\"small\">Adriana is wearing a size 2XL with a height of 5\'11\" a 42\" bust, 36\" waist, 45\" hips. &nbsp;</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_20.png\">\r\n								<br>\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Hanes Women\'s Relaxed V-Neck</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs true to size</p>\r\n								<br>\r\n								<img src=\"http://zeeping.com/image/sizeguide/size_21.png\" >\r\n								<br>\r\n								<br>\r\n								<p class=\"small\">Erin is wearing a size Small with a height of 5\'8\" a 32\" bust, 26\" waist, 35.5\" hips.&nbsp;</p>\r\n								<p class=\"small\">Adriana is wearing a size 2XL with a height of 5\'11\" a 42\" bust, 36\" waist, 45\" hips. &nbsp;</p>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_22.png\" >\r\n								<br>\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Bella Women\'s Fitted V-Neck</strong><br>\r\n								<br>\r\n								<p class=\"small\">Runs small</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_23.png\" >\r\n								<br>\r\n								<p class=\"small\">Erin is wearing a size Small with a height of 5\'8\" a 32\" bust, 26\" waist, 35.5\" hips.&nbsp;</p>\r\n								<p class=\"small\">Adriana is wearing a size 2XL with a height of 5\'11\" a 42\" bust, 36\" waist, 45\" hips. &nbsp;</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_24.png\" >\r\n								<br>\r\n								&nbsp;<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Canvas Ringspun V-Neck (Unisex)</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs true to size</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_25.png\" >\r\n								<br>\r\n								<br>\r\n								<p class=\"small\">James is wearing a size Medium with a height of 6\' and 30/31 waist&nbsp;</p>\r\n								<p class=\"small\">Eirinie is wearing a size Small with a height of 5\'11\" and 34\" bust, 25\" waist, 35\" hips&nbsp;</p>\r\n								<p class=\"small\">Dena is wearing a size Large with a height of 5\' 9\" and 43\" bust, 34\" waist, 46\" hips</p>\r\n								&nbsp;<br>\r\n								<img src=\"http://zeeping.com/image/sizeguide/size_26.png\" >\r\n								<br>\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>American Apparel Triblend Tee (Unisex)</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs true to size</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_27.png\" >\r\n								<br>\r\n								<br>\r\n								<p class=\"small\">James is wearing a size Medium with a height of 6\' and 30/31 waist&nbsp;</p>\r\n								<p class=\"small\">Eirinie is wearing a size Small with a height of 5\'11\" and 34\" bust, 25\" waist, 35\" hips&nbsp;</p>\r\n								<p class=\"small\">Dena is wearing a size Large with a height of 5\' 9\" and 43\" bust, 34\" waist, 46\" hips</p>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_28.png\" >\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Gildan Unisex Tank</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs small</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_29.png\" >\r\n								<br>\r\n								<br>\r\n								<p class=\"small\">James is wearing a size Medium with a height of 6\' and 30/31 waist&nbsp;</p>\r\n								<p class=\"small\">Eirinie is wearing a size Small with a height of 5\'11\" and 34\" bust, 25\" waist, 35\" hips&nbsp;</p>\r\n								<p class=\"small\">Dena is wearing a size Large with a height of 5\' 9\" and 43\" bust, 34\" waist, 46\" hips</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_30.png\" >\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Canvas Ringspun Tank (Unisex)</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs true to size</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_31.png\" >\r\n								<br>\r\n								<br>\r\n								<p class=\"small\">James is wearing a size Medium with a height of 6\' and 30/31 waist&nbsp;</p>\r\n								<p class=\"small\">Eirinie is wearing a size Small with a height of 5\'11\" and 34\" bust, 25\" waist, 35\" hips&nbsp;</p>\r\n								<p class=\"small\">Dena is wearing a size Large with a height of 5\' 9\" and 43\" bust, 34\" waist, 46\" hips</p>\r\n								&nbsp;<br>\r\n								<img src=\"http://zeeping.com/image/sizeguide/size_32.png\" >\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Hanes Heavy Blend Full Zip Hoodie (Unisex)</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs true to size</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_33.png\" >\r\n								<br>\r\n								<br>\r\n								<p class=\"small\">James is wearing a size Medium with a height of 6\' and 30/31 waist&nbsp;</p>\r\n								<p class=\"small\">Eirinie is wearing a size Small with a height of 5\'11\" and 34\" bust, 25\" waist, 35\" hips</p>\r\n								<br>\r\n								<br>\r\n								<img src=\"http://zeeping.com/image/sizeguide/size_34.png\" >\r\n								<br>\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>American Apparel Pullover Hoodie</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs true to size</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_35.png\" >\r\n								<br>\r\n								<p class=\"small\">Nattie is wearing a size Small with a height of 5\'9\" a 32\" bust, 25\" waist, 36\" hips.&nbsp;</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_36.png\" >\r\n								<br>\r\n								&nbsp;<br>\r\n								<br>\r\n								<p class=\"small\"><strong>American Apparel Long Sleeve Tee</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs true to size</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_37.png\" >\r\n								<br>\r\n								<br>\r\n								<p class=\"small\">Nattie is wearing a size Small with a height of 5\'9\" a 32\" bust, 25\" waist, 36\" hips.&nbsp;</p>\r\n								<br>\r\n								<img src=\"http://zeeping.com/image/sizeguide/size_38.png\" >\r\n								<br>\r\n								&nbsp;<br>\r\n								<p class=\"small\"><strong>American Apparel Raglan T-Shirt</strong></p>\r\n								<br>\r\n								<p class=\"small\">Runs true to size</p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_39.png\" >\r\n								<br>\r\n								<br>\r\n								Nattie is wearing a size Small with a height of 5\'9\" a 32\" bust, 25\" waist, 36\" hips.&nbsp;</p>\r\n								&nbsp;<br>\r\n								<img src=\"http://zeeping.com/image/sizeguide/size_40.png\" ><br>\r\n								<br>\r\n								<br>\r\n								&nbsp;<strong>Rabbit Skins Baby Onesie</strong></p>\r\n								<br>\r\n								<img src=\"http://zeeping.com/image/sizeguide/size_41.png\" ><br>\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Gildan Toddler Tee</strong></p>\r\n								<br>\r\n								&nbsp;<img src=\"http://zeeping.com/image/sizeguide/size_42.png\" ><br>\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Kids Premium Tee</strong></p>\r\n								<br>\r\n								<img src=\"http://zeeping.com/image/sizeguide/size_43.png\" ><br>\r\n								<br>\r\n								<br>\r\n								<p class=\"small\"><strong>Alternative Women\'s Meegs Racerback Tank</strong></p>\r\n								<br>\r\n								<img alt=\"\" src=\"http://zeeping.com/image/sizeguide/size_44.png\" >\r\n								<br>\r\n								<br>\r\n								<br>\r\n								<p class=\"large\">If you have a question about a specific garment that is not displayed and not answered by viewing the available sizing chart available on the campaign page, please don\'t hesitate to contact us.&nbsp;</p>\r\n								<br>\r\n								<br>\r\n\r\n								<p class=\"p1\">&nbsp;</p>\r\n\r\n								<p class=\"p1\">&nbsp;</p>\r\n\r\n							</div>\r\n						  </div>',16),(10,'<font size=\"6\">Purchase Guideline</font>','						<style type=\"text/css\" scoped>\n						.large{\n							font-size: 18px;\n						}\n						.small{\n							font-size: 16px;\n						}\n						</style>\n						<br>\n						<br>\n						<p class=\"large\"><span style=\"color:red\">Tips: Before you place the order, please register firstly, thanks.</span></p>\n						<br>\n						<br>\n						<br>\n						<p class=\"large\"><span style=\" font-size:20px;\"> <strong>FIRST ORDER</strong></span></p>\n						<br>\n						<p class=\"large\"><strong>Step 1: Choose your zeeping product and click \"Discount\" button. </strong></p>\n						<br>\n						<img src=\"http://zeeping.com/image/common/guideline_1.png\" width=\"70%\" height=\"85%\" alt=\"\">\n						<br>\n						<br>\n						<p class=\"large\"><strong>Step 2: Register your email to get 10% discount for next order and then click \"Buy\" to continue for next step.</strong></p>\n						<br>\n						<p class=\"small\"><span style=\"color:red\">&nbsp;&nbsp;&nbsp;Notice: We \'ll send you an e-mail, please log in and verify your account. </span></p>\n						<br>\n						<img src=\"http://zeeping.com/image/common/guideline_2.png\" width=\"80%\" height=\"60%\" alt=\"\">\n						<br>\n						<br>\n						<br>\n						<p class=\"large\"><span style=\" font-size:20px;\"> <strong>SECOND ORDER</strong></span></p>						\n						<br>\n						<p class=\"large\"><strong>Step 1: Click \"My account\" to login </strong></p>\n						<br>\n						<img src=\"http://zeeping.com/image/common/guideline_3.png\" width=\"80%\" height=\"20%\" alt=\"\">\n						<br>\n						<br>\n						<p class=\"large\">&nbsp;&nbsp;&nbsp;Sign your ID and Password </p>\n						<br>\n						<img src=\"http://zeeping.com/image/common/guideline_4.png\" width=\"50%\" height=\"60%\" alt=\"\">\n						<br>\n						<br>\n						<p class=\"large\">&nbsp;&nbsp;&nbsp;Check your discount  </p>\n						<br>\n						<img src=\"http://zeeping.com/image/common/guideline_5.png\" width=\"80%\" height=\"60%\" alt=\"\">\n						<br>\n						<br>\n						<p class=\"large\"><strong>Step 2: Choose your zeeping product and click \"Discount\" button. </strong></p>\n						<br>\n						<img src=\"http://zeeping.com/image/common/guideline_1.png\" width=\"60%\" height=\"90%\" alt=\"\">\n						<br>\n						<br>\n						<br>\n						<p class=\"large\"><strong>Step 3: In Delivery form, choose your size and quatity then click \"Next\" </strong></p>\n						<br>\n						<img src=\"http://zeeping.com/image/common/guideline_6.png\" width=\"60%\" height=\"90%\" alt=\"\">\n						<br>\n						<br>\n						<br>\n						<p class=\"large\"><strong>Step 4: In Confirmation form, check your information and then click \"Next\" </strong></p>\n						<br>\n						<img src=\"http://zeeping.com/image/common/guideline_7.png\" width=\"60%\" height=\"90%\" alt=\"\">\n						<br>	\n						<br>	\n						<br>	\n						<p class=\"large\"><strong>Step 5: In Checkout form, check your money have to pay and then click \"Paypal\" button.</strong></p>\n						<br>\n						<img src=\"http://zeeping.com/image/common/guideline_8.png\" width=\"60%\" height=\"90%\" alt=\"\">\n						<br>						\n',17);
/*!40000 ALTER TABLE `web_menu_page` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `web_page_FAQ`
--

DROP TABLE IF EXISTS `web_page_FAQ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `web_page_FAQ` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `question` varchar(500) COLLATE utf8_unicode_ci NOT NULL,
  `answer` varchar(2000) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=23 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `web_page_FAQ`
--

LOCK TABLES `web_page_FAQ` WRITE;
/*!40000 ALTER TABLE `web_page_FAQ` DISABLE KEYS */;
INSERT INTO `web_page_FAQ` (`id`, `question`, `answer`) VALUES (10,'What is the free size?','It usually means the only size is available. The size may be different due to different countries. Therefore we suggest you that check the measurement carefully, then you will know if it fits you.'),(8,'How about the quality of your product?','Our products are of high quality compared with many rivals. We pay much attention to our customers\'shopping experience. We  will always put it on our priority.'),(9,'Whether your photos are exactly the same with the products?','Most of the photos are shot by our own photographer, and only a few of them are from magazines. '),(11,'Can I get a discount if I place a bulk order?','Of course.  Usually you will enjoy 10% discount if you sign as a member of our website.\nYou can check for more information discount <a href=\"http://zeeping.com/zeeping-point-system\" ><span style=\"color: #0000FF\">Here !!! </span></a>'),(12,'Can you send your catalogue to me?','We are sorry that we couldn\'t offer the catalogue, because we update our product everyday. Hope you could take your time to have a view on our website. Thanks!'),(13,'How long will the out-of-stock items be restocked?','We are not sure about that, but for hot-sale styles, we\'ll restock as soon as possible.'),(14,'The item is available when I place the order, but why it is not after I finish the payment?','Most of the items on our website are available, but with the increasing of the order, we nearly not notice the inventory of it. We are sorry to being late to update the listing.'),(15,'What if I forgot my password?','Please feel free to contact us via live chat or email, we will help you reset it.'),(16,'Can I change or cancel the items in my paid order?','Yes, you can, as long as it hasn\'t been shipped yet. '),(17,'What the delivery company  you use?','Now, all of our product is shipping by Teespring.'),(18,'How much will be the shipping cost?','It depends on your area, quatity and the shipping method you choose. You can have a try to place a order and the system will automatically calculate it for you.'),(19,'Do you offer free shipping?','Yes, but we only offer free shipping for large order.'),(20,'How long does it take to deliver it to me?','It depends on the shipping method you choose. Usually, you will take it after 12 -16 days. But It can be deliver in 2-5 days by using special method. Please contact us if you need more information'),(21,'How do I track my order?','Once  the tracking number is available, we will email to inform you, and you can track it online by accessing the website of the relevant delivery company. '),(22,'If the package is detained by customs, who is responsible for clearance of the items?','It\'s the buyer.');
/*!40000 ALTER TABLE `web_page_FAQ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `web_page_testimonial`
--

DROP TABLE IF EXISTS `web_page_testimonial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `web_page_testimonial` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `testimonial` varchar(2000) COLLATE utf8_unicode_ci NOT NULL,
  `createguest` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `createuser` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `createdate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `FK_testimonial_user` (`createuser`)
) ENGINE=MyISAM AUTO_INCREMENT=403 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `web_page_testimonial`
--

LOCK TABLES `web_page_testimonial` WRITE;
/*!40000 ALTER TABLE `web_page_testimonial` DISABLE KEYS */;
INSERT INTO `web_page_testimonial` (`id`, `testimonial`, `createguest`, `createuser`, `createdate`) VALUES (29,'I\'ve looked at a lot of Army shirts, but this has to be the best one yet.\r\nThe front has the regular US army logo, but the back has the sick Army Strong with the cool picture of the soldier holding the helmet.\r\nLove buying military shirts and supporting the military, this has to be the coolest shirt I\'ve bought yet.','FMendoza','','2017-08-27 14:49:32'),(30,'Nice design and printed on good quality cotton!','Sonia White','','2017-08-27 14:50:23'),(28,'I would buy a shirt in Army for women that are currently serving for the country. Also would recommend Army daughter or sister that\'s currently serving in the Army or Navy ','Charlene Author','','2017-08-24 10:28:02'),(31,'It\'s a well made, solid piece of clothing! It fits comfortably and feels great against the skin. The shirt is perfect, will certainly continue to buy from Grunt Style! What a great, patriotic shirt!','Sylvia V','','2017-08-27 14:50:50'),(34,'My husband loved this shirt','Reba Picard','','2017-09-01 23:21:44');
/*!40000 ALTER TABLE `web_page_testimonial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `web_search_session`
--

DROP TABLE IF EXISTS `web_search_session`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `web_search_session` (
  `name` varchar(200) COLLATE utf8_unicode_ci NOT NULL,
  `link` varchar(200) COLLATE utf8_unicode_ci NOT NULL,
  `ip` varchar(20) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `web_search_session`
--

LOCK TABLES `web_search_session` WRITE;
/*!40000 ALTER TABLE `web_search_session` DISABLE KEYS */;
INSERT INTO `web_search_session` (`name`, `link`, `ip`) VALUES ('Search','Search','166.70.207.2'),('dad','dad','42.116.23.110'),('Search','Search','185.38.14.215');
/*!40000 ALTER TABLE `web_search_session` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'Zeeping'
--

--
-- Dumping routines for database 'Zeeping'
--
/*!50003 DROP PROCEDURE IF EXISTS `sp_checksignin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`zeeping`@`localhost` PROCEDURE `sp_checksignin`(IN `username1` VARCHAR(50), IN `password1` VARCHAR(50), OUT `session1` INT(11), IN `ip1` VARCHAR(20))
BEGIN
	DECLARE sohang int (11) DEFAULT 0;
    set sohang = (select COUNT(t1.username) from order_user t1 where t1.username = username1 and t1.password = password1 and t1.isenable = true);
    if(sohang > 0) THEN
    	set session1 = 1;
        set sohang = (select COUNT(t1.session_id) from `order_session` t1 where t1.session_id = session1);
        WHILE (sohang > 0) DO
        	set session1 = session1 + 1;
            set sohang = (select COUNT(t1.session_id) from `order_session` t1 where t1.session_id = session1);
        end WHILE;
        INSERT into order_session(`session_id`,`ip`, `username`, `last_time`, `isadmin`) VALUES (session1,ip1,username1,NOW(),0);
    ELSE 
    	set session1 = -1;
    END IF;
    select session1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-10-24 21:58:01
