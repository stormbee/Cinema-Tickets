-- MySQL dump 10.13  Distrib 8.0.29, for Win64 (x86_64)
--
-- Host: localhost    Database: cinema
-- ------------------------------------------------------
-- Server version	8.0.29

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `asks`
--

DROP TABLE IF EXISTS `asks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `asks` (
  `idasks` int NOT NULL AUTO_INCREMENT,
  `user` varchar(45) NOT NULL,
  `question` varchar(45) NOT NULL,
  PRIMARY KEY (`idasks`),
  UNIQUE KEY `idasks_UNIQUE` (`idasks`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asks`
--

LOCK TABLES `asks` WRITE;
/*!40000 ALTER TABLE `asks` DISABLE KEYS */;
INSERT INTO `asks` VALUES (1,'user','qwe');
/*!40000 ALTER TABLE `asks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movies`
--

DROP TABLE IF EXISTS `movies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `movies` (
  `idmovies` int NOT NULL AUTO_INCREMENT,
  `cinemaname` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `date` varchar(45) NOT NULL,
  `time` varchar(45) NOT NULL,
  `duration` varchar(45) NOT NULL,
  PRIMARY KEY (`idmovies`),
  UNIQUE KEY `idmovies_UNIQUE` (`idmovies`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='\n\n	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movies`
--

LOCK TABLES `movies` WRITE;
/*!40000 ALTER TABLE `movies` DISABLE KEYS */;
INSERT INTO `movies` VALUES (1,'Cinema city','Hulk','23.02.2021','15:20','1:37:00'),(2,'Paramount','Spider-Man','22.01.2021','08:30','1:40:00'),(3,'Atlantic City','Avengers','10.12.2021','15:40','2:43:00'),(4,'Cinema city','The Shawshank Redemption','11.07.2022','12:10','1:52:00'),(5,'Open Air','The Godfather','24.03.2022','11:40','2:13:00'),(6,'Panasonic IMAX','The Dark Knight','22.04.2022','18:35','2:02:00'),(7,'IMAX Tycho Brahe','The Lord of the Rings: The Return of the King','14.04.2022','12:55','1:44:00'),(8,'Cinema city','Schindler\'s List','09.04.2022','22:20','2:24:00'),(9,'Paramount','The Godfather: Part II','19.04.2021','18:45','2:00:00'),(10,'Open Air','12 Angry Men','10.03.2022','08:35','2:52:00'),(11,'Paramount','Pulp Fiction','12.12.2021','23:40','1:30:00'),(12,'Atlantic City','Inception','29.03.2022','21:15','1:52:00'),(13,'Panasonic IMAX','Fight Club','03.02.2021','20:10','1:40:00'),(14,'Open Air','Forrest Gump','10.10.2021','22:35','2:02:00'),(15,'Cinema city','Matrix','07.08.2021','14:55','2:13:00');
/*!40000 ALTER TABLE `movies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `idorder` int NOT NULL AUTO_INCREMENT,
  `login` varchar(45) NOT NULL,
  `movie` varchar(45) NOT NULL,
  `seats` varchar(45) NOT NULL,
  `payment` int NOT NULL,
  PRIMARY KEY (`idorder`),
  UNIQUE KEY `idorder_UNIQUE` (`idorder`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,'user','Hulk','E6 D7 C8 E8 F8',470),(2,'user','Spider-Man','F7',100);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `idusers` int NOT NULL AUTO_INCREMENT,
  `login` varchar(45) NOT NULL,
  `pass` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`idusers`),
  UNIQUE KEY `idusers_UNIQUE` (`idusers`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'admin','admin','admin'),(2,'user','user','user'),(3,'qwe','qwe','user'),(4,'user1','1','user'),(5,'user123','123','user');
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

-- Dump completed on 2022-05-31  0:58:09
