-- MySQL dump 10.13  Distrib 5.5.54, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: GSB_Csharp
-- ------------------------------------------------------
-- Server version	5.5.54-0+deb8u1

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
-- Table structure for table `Entretien`
--

DROP TABLE IF EXISTS `Entretien`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Entretien` (
  `identretien` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) DEFAULT NULL,
  `prenom` varchar(50) DEFAULT NULL,
  `immatriculation` varchar(25) DEFAULT NULL,
  `datedebut` varchar(50) DEFAULT NULL,
  `datefin` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`identretien`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Entretien`
--

LOCK TABLES `Entretien` WRITE;
/*!40000 ALTER TABLE `Entretien` DISABLE KEYS */;
INSERT INTO `Entretien` VALUES (9,'Picard','Jérémy','BC-784-BV','samedi 8 octobre 2016','vendredi 14 octobre 2016'),(10,'Test','Test','AA-789-BC','samedi 8 octobre 2016','vendredi 14 octobre 2016'),(11,'Test1','Test1','AA-789-BC','mercredi 26 octobre 2016','samedi 29 octobre 2016'),(12,'Test2','Test2','BA-784-BD','vendredi 12 mai 2017','samedi 13 mai 2017');
/*!40000 ALTER TABLE `Entretien` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Utilisateur`
--

DROP TABLE IF EXISTS `Utilisateur`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Utilisateur` (
  `pseudo` varchar(50) NOT NULL,
  `mdp` varchar(50) NOT NULL,
  PRIMARY KEY (`pseudo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Utilisateur`
--

LOCK TABLES `Utilisateur` WRITE;
/*!40000 ALTER TABLE `Utilisateur` DISABLE KEYS */;
INSERT INTO `Utilisateur` VALUES ('admin','admin');
/*!40000 ALTER TABLE `Utilisateur` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `VehiculeElectrique`
--

DROP TABLE IF EXISTS `VehiculeElectrique`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `VehiculeElectrique` (
  `idelectrique` int(11) NOT NULL AUTO_INCREMENT,
  `immatriculation` varchar(25) NOT NULL DEFAULT '0',
  `marque` varchar(25) NOT NULL DEFAULT '0',
  `modele` varchar(25) NOT NULL DEFAULT '0',
  `puissanceFiscale` varchar(25) NOT NULL DEFAULT '0',
  `kilometrage` varchar(25) NOT NULL DEFAULT '0',
  `dateImmatriculation` varchar(25) NOT NULL DEFAULT '0',
  `dateAchat` varchar(25) NOT NULL DEFAULT '0',
  `prixAchat` double NOT NULL DEFAULT '0',
  `loyerMensuel` double NOT NULL DEFAULT '0',
  `tempsDeCharge` double NOT NULL DEFAULT '0',
  `autonomieEnKm` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idelectrique`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `VehiculeElectrique`
--

LOCK TABLES `VehiculeElectrique` WRITE;
/*!40000 ALTER TABLE `VehiculeElectrique` DISABLE KEYS */;
INSERT INTO `VehiculeElectrique` VALUES (3,'BC-784-BV','Tesla','S','1','10000','mercredi 6 janvier 2016','vendredi 7 octobre 2016',65000,0,4,375),(24,'BA-784-BD','Tesla','S','1','0','mercredi 5 octobre 2016','samedi 8 octobre 2016',74000,0,5,500);
/*!40000 ALTER TABLE `VehiculeElectrique` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `VehiculeThermique`
--

DROP TABLE IF EXISTS `VehiculeThermique`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `VehiculeThermique` (
  `idthermique` int(11) NOT NULL AUTO_INCREMENT,
  `immatriculation` varchar(25) NOT NULL DEFAULT '0',
  `marque` varchar(25) NOT NULL DEFAULT '0',
  `modele` varchar(25) NOT NULL DEFAULT '0',
  `puissanceFiscale` int(11) NOT NULL DEFAULT '0',
  `kilometrage` int(11) NOT NULL DEFAULT '0',
  `dateImmatriculation` varchar(25) NOT NULL DEFAULT '0',
  `dateAchat` varchar(25) NOT NULL DEFAULT '0',
  `prixAchat` double NOT NULL DEFAULT '0',
  `loyerMensuel` double NOT NULL DEFAULT '0',
  `capaciteReservoir` int(11) NOT NULL DEFAULT '0',
  `consommationMoy` int(11) NOT NULL DEFAULT '0',
  `typeCarburant` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idthermique`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `VehiculeThermique`
--

LOCK TABLES `VehiculeThermique` WRITE;
/*!40000 ALTER TABLE `VehiculeThermique` DISABLE KEYS */;
INSERT INTO `VehiculeThermique` VALUES (7,'AA-229-AA','Opel','Astra',12,15000,'mercredi 16 juillet 2014','mercredi 10 février 2016',18000,0,48,5,'Diesel'),(8,'AA-789-BC','Nissan','Juke',15,5000,'mercredi 22 juin 2016','samedi 13 août 2016',16200,0,50,6,'Diesel'),(9,'AA-854-BN','Porsche','911 GT3',30,1500,'mardi 6 septembre 2016','samedi 1 octobre 2016',100000,0,68,10,'Essence');
/*!40000 ALTER TABLE `VehiculeThermique` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-05-16  5:52:39
