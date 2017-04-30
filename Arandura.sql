CREATE DATABASE  IF NOT EXISTS `arandura` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `arandura`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: arandura
-- ------------------------------------------------------
-- Server version	5.6.23-log

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
-- Table structure for table `atributos`
--

DROP TABLE IF EXISTS `atributos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `atributos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  `costo` int(11) NOT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `atributos`
--

LOCK TABLES `atributos` WRITE;
/*!40000 ALTER TABLE `atributos` DISABLE KEYS */;
INSERT INTO `atributos` VALUES (1,'Atributo1',2000,'admin','2016-02-19 00:00:00','admin','2016-02-19 00:00:00'),(2,'Atributo2',1500,'admin','2016-02-19 00:00:00','admin','2016-02-19 00:00:00'),(3,'Atributo3',5000,'admin','2016-02-19 00:00:00','admin','2016-02-19 00:00:00'),(4,'AtributoA',50120,'admin','2016-02-19 00:00:00','admin','2016-02-19 00:00:00'),(5,'AtributoB',140000,'admin','2016-02-19 00:00:00','admin','2016-02-19 00:00:00');
/*!40000 ALTER TABLE `atributos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `barrios`
--

DROP TABLE IF EXISTS `barrios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `barrios` (
  `id` int(11) NOT NULL,
  `id_pais` int(11) NOT NULL,
  `id_departamento` int(11) NOT NULL,
  `id_ciudad` int(11) NOT NULL,
  `descripcion` varchar(150) NOT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`,`id_pais`,`id_departamento`,`id_ciudad`),
  KEY `fk_barrios_ciudades1_idx` (`id_ciudad`,`id_pais`,`id_departamento`),
  CONSTRAINT `fk_barrios_ciudades1` FOREIGN KEY (`id_ciudad`, `id_pais`, `id_departamento`) REFERENCES `ciudades` (`id`, `id_pais`, `id_departamento`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `barrios`
--

LOCK TABLES `barrios` WRITE;
/*!40000 ALTER TABLE `barrios` DISABLE KEYS */;
/*!40000 ALTER TABLE `barrios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `caracteristicas`
--

DROP TABLE IF EXISTS `caracteristicas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `caracteristicas` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'identificador de la tabla',
  `codigo` varchar(45) NOT NULL,
  `descripcion` varchar(45) NOT NULL COMMENT 'nombre de la caracteristica',
  `valor` float NOT NULL COMMENT 'valor de la caracteristica',
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='caracteristicas para los insumos';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `caracteristicas`
--

LOCK TABLES `caracteristicas` WRITE;
/*!40000 ALTER TABLE `caracteristicas` DISABLE KEYS */;
INSERT INTO `caracteristicas` VALUES (1,'1','Ancho',0,'admin','0000-00-00 00:00:00','admin','0000-00-00 00:00:00'),(2,'2','Largo',0,'admin','0000-00-00 00:00:00','admin','0000-00-00 00:00:00'),(3,'3','Gramaje',0,'admin','0000-00-00 00:00:00','admin','0000-00-00 00:00:00'),(4,'4','Color',0,'admin','0000-00-00 00:00:00','admin','0000-00-00 00:00:00');
/*!40000 ALTER TABLE `caracteristicas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ciudades`
--

DROP TABLE IF EXISTS `ciudades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ciudades` (
  `id` int(11) NOT NULL,
  `id_pais` int(11) NOT NULL,
  `id_departamento` int(11) NOT NULL,
  `descripcion` varchar(45) NOT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`,`id_pais`,`id_departamento`),
  KEY `fk_ciudades_departamentos1_idx` (`id_departamento`,`id_pais`),
  CONSTRAINT `fk_ciudades_departamentos1` FOREIGN KEY (`id_departamento`, `id_pais`) REFERENCES `departamentos` (`id`, `id_pais`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ciudades`
--

LOCK TABLES `ciudades` WRITE;
/*!40000 ALTER TABLE `ciudades` DISABLE KEYS */;
/*!40000 ALTER TABLE `ciudades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departamentos`
--

DROP TABLE IF EXISTS `departamentos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departamentos` (
  `id` int(11) NOT NULL,
  `id_pais` int(11) NOT NULL,
  `descripcion` varchar(150) NOT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`,`id_pais`),
  KEY `fk_departamentos_paises1_idx` (`id_pais`),
  CONSTRAINT `fk_departamentos_paises1` FOREIGN KEY (`id_pais`) REFERENCES `paises` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departamentos`
--

LOCK TABLES `departamentos` WRITE;
/*!40000 ALTER TABLE `departamentos` DISABLE KEYS */;
/*!40000 ALTER TABLE `departamentos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `depositos`
--

DROP TABLE IF EXISTS `depositos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `depositos` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'identificador de la tabla',
  `codigo` varchar(45) NOT NULL,
  `descripcion` varchar(45) NOT NULL COMMENT 'nombre del deposito',
  `direccion` varchar(45) DEFAULT NULL COMMENT 'direccion del deposito',
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `depositos`
--

LOCK TABLES `depositos` WRITE;
/*!40000 ALTER TABLE `depositos` DISABLE KEYS */;
INSERT INTO `depositos` VALUES (1,'1','Deposito 1','Mcal. Estigarribia c/ Brasil','admin','0000-00-00 00:00:00','admin','0000-00-00 00:00:00'),(2,'2','Deposito 2','Nanawa c/ Caballero','admin','0000-00-00 00:00:00','admin','0000-00-00 00:00:00'),(3,'3','Deposito 3','Eusebio Ayala c/ Boggiani','admin','0000-00-00 00:00:00','admin','0000-00-00 00:00:00');
/*!40000 ALTER TABLE `depositos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `depositos_insumos_rel`
--

DROP TABLE IF EXISTS `depositos_insumos_rel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `depositos_insumos_rel` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'identificador de la tabla',
  `id_depositos` int(11) NOT NULL,
  `id_insumos` int(11) NOT NULL,
  `costo` float NOT NULL COMMENT 'costo del almacenado',
  `cantidad` float DEFAULT NULL COMMENT 'cantidad del producto depositado',
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`,`id_depositos`,`id_insumos`),
  KEY `fk_depositos_insumos_rel_depositos1_idx` (`id_depositos`),
  KEY `fk_depositos_insumos_rel_insumos1_idx` (`id_insumos`),
  CONSTRAINT `fk_depositos_insumos_rel_depositos1` FOREIGN KEY (`id_depositos`) REFERENCES `depositos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_depositos_insumos_rel_insumos1` FOREIGN KEY (`id_insumos`) REFERENCES `insumos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `depositos_insumos_rel`
--

LOCK TABLES `depositos_insumos_rel` WRITE;
/*!40000 ALTER TABLE `depositos_insumos_rel` DISABLE KEYS */;
/*!40000 ALTER TABLE `depositos_insumos_rel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `depositos_productos_rel`
--

DROP TABLE IF EXISTS `depositos_productos_rel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `depositos_productos_rel` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'identificador de la tabla',
  `id_productos` int(11) NOT NULL,
  `id_depositos` int(11) NOT NULL,
  `costo` float NOT NULL COMMENT 'costo por el almacenado',
  `cantidad` float DEFAULT NULL COMMENT 'cantidad del producto por deposito',
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`,`id_productos`,`id_depositos`),
  KEY `fk_depositos_productos_rel_productos_idx` (`id_productos`),
  KEY `fk_depositos_productos_rel_depositos1_idx` (`id_depositos`),
  CONSTRAINT `fk_depositos_productos_rel_depositos1` FOREIGN KEY (`id_depositos`) REFERENCES `depositos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_depositos_productos_rel_productos` FOREIGN KEY (`id_productos`) REFERENCES `productos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `depositos_productos_rel`
--

LOCK TABLES `depositos_productos_rel` WRITE;
/*!40000 ALTER TABLE `depositos_productos_rel` DISABLE KEYS */;
/*!40000 ALTER TABLE `depositos_productos_rel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `direcciones`
--

DROP TABLE IF EXISTS `direcciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `direcciones` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_persona` int(11) NOT NULL,
  `descripcion` varchar(300) DEFAULT NULL,
  `id_barrio` int(11) NOT NULL,
  `id_pais` int(11) NOT NULL,
  `id_departamento` int(11) NOT NULL,
  `id_ciudad` int(11) NOT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`,`id_persona`),
  KEY `fk_direcciones_personas1_idx` (`id_persona`),
  KEY `fk_direcciones_barrios1_idx` (`id_barrio`,`id_pais`,`id_departamento`,`id_ciudad`),
  CONSTRAINT `fk_direcciones_barrios1` FOREIGN KEY (`id_barrio`, `id_pais`, `id_departamento`, `id_ciudad`) REFERENCES `barrios` (`id`, `id_pais`, `id_departamento`, `id_ciudad`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_direcciones_personas1` FOREIGN KEY (`id_persona`) REFERENCES `personas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `direcciones`
--

LOCK TABLES `direcciones` WRITE;
/*!40000 ALTER TABLE `direcciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `direcciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empresas`
--

DROP TABLE IF EXISTS `empresas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `empresas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom_fantasia` varchar(100) DEFAULT NULL,
  `nom_contribuyente` varchar(100) DEFAULT NULL,
  `ruc_contribuyente` varchar(50) DEFAULT NULL,
  `descripcion` varchar(300) DEFAULT NULL COMMENT 'Una descripcion de la empresa, a que se dedica, ejemplo "import/export"',
  `estado` varchar(1) DEFAULT 'S',
  `direccion` varchar(300) DEFAULT NULL,
  `telefono` varchar(50) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `nro_patronal` varchar(50) DEFAULT NULL,
  `retentor` varchar(1) DEFAULT NULL,
  `nom_representante` varchar(100) DEFAULT NULL,
  `ruc_representante` varchar(50) DEFAULT NULL,
  `nro_registro` varchar(50) DEFAULT NULL,
  `porc_retencion` varchar(50) DEFAULT NULL COMMENT 'Se describe el porcentaje de retención que tiene la empresa.',
  `carp_compartida` varchar(500) DEFAULT NULL COMMENT 'En esta columna se describe cual es la carpeta compartida de la empresa el cual utilizará el sistema para guardar fotos u otros datos necesarios.',
  `logotipo` varchar(500) DEFAULT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empresas`
--

LOCK TABLES `empresas` WRITE;
/*!40000 ALTER TABLE `empresas` DISABLE KEYS */;
INSERT INTO `empresas` VALUES (1,'arandura','NULL','NULL','NULL','S','NULL','NULL','NULL','NULL','N','NULL','NULL','NULL','NULL','NULL','NULL','admin','2016-01-17 00:00:00','admin','2016-01-07 00:00:00');
/*!40000 ALTER TABLE `empresas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `formato`
--

DROP TABLE IF EXISTS `formato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `formato` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'identificador de la tabla',
  `descripcion` varchar(45) NOT NULL,
  `costo` float NOT NULL COMMENT 'costo del formato',
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formato`
--

LOCK TABLES `formato` WRITE;
/*!40000 ALTER TABLE `formato` DISABLE KEYS */;
INSERT INTO `formato` VALUES (1,'FormatoA',0,'admin','2016-02-19 11:42:07','admin','2016-02-19 11:42:07'),(2,'FormatoB',0,'admin','2016-02-19 11:57:55','admin','2016-02-19 11:57:55'),(3,'',0,'admin','2016-02-19 12:08:43','admin','2016-02-19 12:08:43'),(6,'',0,'admin','2016-02-19 12:28:10','admin','2016-02-19 12:28:10'),(7,'',0,'admin','2016-02-19 12:32:57','admin','2016-02-19 12:32:57'),(8,'Formato Prueba',300000,'admin','2016-02-19 12:54:27','admin','2016-02-19 12:54:27'),(9,'FPrueba1',300000,'admin','2016-02-19 13:10:44','admin','2016-02-19 13:10:44'),(10,'FormatA',300000,'admin','2016-02-19 13:13:44','admin','2016-02-19 13:13:44'),(11,'formatoA',500000,'admin','2016-02-19 13:21:22','admin','2016-02-19 13:21:22'),(12,'formatoB',254000,'admin','2016-02-19 13:23:47','admin','2016-02-19 13:23:47'),(13,'formatoC',200000,'admin','2016-02-19 13:30:34','admin','2016-02-19 13:30:34'),(14,'',0,'admin','2016-02-19 13:31:02','admin','2016-02-19 13:31:02'),(15,'formatoX',200000,'admin','2016-02-19 13:32:43','admin','2016-02-19 13:32:43'),(16,'formato3',200000,'admin','2016-02-19 13:37:25','admin','2016-02-19 13:37:25'),(17,'formato2',200000,'admin','2016-02-19 13:40:48','admin','2016-02-19 13:40:48'),(18,'formatoasd',23423400,'admin','2016-02-19 15:13:37','admin','2016-02-19 15:13:37'),(19,'formato3',25000,'admin','2016-02-19 15:51:22','admin','2016-02-19 15:51:22'),(20,'formato3',300000,'admin','2016-02-19 15:58:39','admin','2016-02-19 15:58:39'),(21,'formato23',300000,'admin','2016-02-19 16:40:24','admin','2016-02-19 16:40:24'),(22,'',0,'admin','2016-02-19 16:41:13','admin','2016-02-19 16:41:13'),(23,'formato123',123123,'admin','2016-02-19 16:42:21','admin','2016-02-19 16:42:21'),(24,'formato1232',123123,'admin','2016-02-19 16:43:39','admin','2016-02-19 16:43:39');
/*!40000 ALTER TABLE `formato` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `formato_atributos_rel`
--

DROP TABLE IF EXISTS `formato_atributos_rel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `formato_atributos_rel` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_formato` int(11) NOT NULL,
  `id_atributos` int(11) NOT NULL,
  `cantidad` varchar(45) DEFAULT NULL,
  `costo` float DEFAULT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`,`id_formato`,`id_atributos`),
  KEY `fk_formato_atributos_rel_formato1_idx` (`id_formato`),
  KEY `fk_formato_atributos_rel_atributos1_idx` (`id_atributos`),
  CONSTRAINT `fk_formato_atributos_rel_atributos1` FOREIGN KEY (`id_atributos`) REFERENCES `atributos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_formato_atributos_rel_formato1` FOREIGN KEY (`id_formato`) REFERENCES `formato` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formato_atributos_rel`
--

LOCK TABLES `formato_atributos_rel` WRITE;
/*!40000 ALTER TABLE `formato_atributos_rel` DISABLE KEYS */;
INSERT INTO `formato_atributos_rel` VALUES (4,2,3,'5',300000,'admin','2016-02-19 00:00:00','admin','2016-02-19 00:00:00'),(5,2,2,'6',450000,'admin','2016-02-19 00:00:00','admin','2016-02-19 00:00:00');
/*!40000 ALTER TABLE `formato_atributos_rel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupos_usuarios`
--

DROP TABLE IF EXISTS `grupos_usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grupos_usuarios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(300) NOT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='Esta tabla sirve para definir los grupos a los cuales pertenecerán los usuarios y se usará para definir cuales son los permisos a los que tienen los distintos grupos.';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupos_usuarios`
--

LOCK TABLES `grupos_usuarios` WRITE;
/*!40000 ALTER TABLE `grupos_usuarios` DISABLE KEYS */;
INSERT INTO `grupos_usuarios` VALUES (1,'admin','admin','2016-01-17 00:00:00','admin','2016-01-17 00:00:00');
/*!40000 ALTER TABLE `grupos_usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `insumos`
--

DROP TABLE IF EXISTS `insumos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `insumos` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'identificador de la tabla',
  `codigo` varchar(45) NOT NULL,
  `descripcion` varchar(45) NOT NULL COMMENT 'descripcion d ela tabla',
  `estado` varchar(1) NOT NULL DEFAULT 'S',
  `costo` float NOT NULL COMMENT 'costo del insumo',
  `cantidad` int(11) DEFAULT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `insumos`
--

LOCK TABLES `insumos` WRITE;
/*!40000 ALTER TABLE `insumos` DISABLE KEYS */;
INSERT INTO `insumos` VALUES (1,'1','Papel Economico 60gr','S',3500,11,'admin','0000-00-00 00:00:00','admin','2016-02-19 19:41:08'),(15,'2','Prueba','S',23000,0,'admin','2016-02-16 16:55:33','admin','2016-02-18 21:38:24'),(16,'3','Demo','S',1231,15,'admin','2016-02-16 23:59:21','admin','2016-02-19 19:41:08'),(17,'4','Papel Mache','S',5000,0,'ADMIN','2016-02-18 21:35:41','admin','2016-02-19 19:41:08');
/*!40000 ALTER TABLE `insumos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `insumos_caracteristicas_rel`
--

DROP TABLE IF EXISTS `insumos_caracteristicas_rel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `insumos_caracteristicas_rel` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'identificador de la tabla',
  `id_insumos` int(11) NOT NULL,
  `id_caracteristicas` int(11) NOT NULL,
  `id_unidad_medida` int(11) DEFAULT NULL,
  `valor` varchar(45) DEFAULT NULL COMMENT 'Define el valor de la caracteristica, si por ejemplo eligió la caracteristica "Color" el valor sería "Rojo" o "Verde", etc.',
  `costo` int(11) DEFAULT NULL COMMENT 'costo de la caracteristica que va a sumar al costo del insumo',
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`,`id_insumos`,`id_caracteristicas`),
  KEY `fk_insumos_caracteristicas_rel_insumos1_idx` (`id_insumos`),
  KEY `fk_insumos_caracteristicas_rel_caracteristicas1_idx` (`id_caracteristicas`),
  CONSTRAINT `fk_insumos_caracteristicas_rel_caracteristicas1` FOREIGN KEY (`id_caracteristicas`) REFERENCES `caracteristicas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_insumos_caracteristicas_rel_insumos1` FOREIGN KEY (`id_insumos`) REFERENCES `insumos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `insumos_caracteristicas_rel`
--

LOCK TABLES `insumos_caracteristicas_rel` WRITE;
/*!40000 ALTER TABLE `insumos_caracteristicas_rel` DISABLE KEYS */;
INSERT INTO `insumos_caracteristicas_rel` VALUES (1,1,1,1,'12',3400,'admin','0000-00-00 00:00:00','admin','0000-00-00 00:00:00'),(2,1,2,4,'8',2000,'admin','0000-00-00 00:00:00','admin','0000-00-00 00:00:00'),(3,1,3,5,'60',1000,'admin','0000-00-00 00:00:00','admin','0000-00-00 00:00:00'),(9,15,1,4,'14',150,'admin','2016-02-16 17:09:38','admin','2016-02-16 17:09:38'),(10,15,2,4,'23',230,'admin','2016-02-16 17:09:49','admin','2016-02-16 17:09:49'),(11,15,3,4,'60',1250,'admin','2016-02-16 17:09:59','admin','2016-02-16 17:09:59'),(12,15,4,1,'Blanco',2500,'admin','2016-02-16 17:10:15','admin','2016-02-16 17:10:15'),(13,15,1,1,'1111',11111,'admin','2016-02-16 19:12:44','admin','2016-02-16 19:12:44'),(14,1,1,0,'',1232,'admin','2016-02-16 19:26:25','admin','2016-02-16 19:26:25'),(15,15,1,2,'',12312,'admin','2016-02-16 19:33:05','admin','2016-02-16 19:33:05'),(16,16,1,1,'1232',111111,'admin','2016-02-16 23:59:21','admin','2016-02-16 23:59:21'),(17,17,1,4,'30',2000,'ADMIN','2016-02-18 21:35:41','ADMIN','2016-02-18 21:35:41');
/*!40000 ALTER TABLE `insumos_caracteristicas_rel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `insumos_productos_rel`
--

DROP TABLE IF EXISTS `insumos_productos_rel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `insumos_productos_rel` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'identificador de la tabla',
  `id_productos` int(11) NOT NULL,
  `id_insumos` int(11) NOT NULL,
  `costo` float DEFAULT NULL COMMENT 'costo del insumo multiplicado por la cantidad',
  `cantidad` float NOT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`,`id_productos`,`id_insumos`),
  KEY `fk_insumos_productos_rel_productos1_idx` (`id_productos`),
  KEY `fk_insumos_productos_rel_insumos1_idx` (`id_insumos`),
  CONSTRAINT `fk_insumos_productos_rel_insumos1` FOREIGN KEY (`id_insumos`) REFERENCES `insumos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_insumos_productos_rel_productos1` FOREIGN KEY (`id_productos`) REFERENCES `productos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='tabla que contiene las relaciones que conforman los ingredientes para los productos';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `insumos_productos_rel`
--

LOCK TABLES `insumos_productos_rel` WRITE;
/*!40000 ALTER TABLE `insumos_productos_rel` DISABLE KEYS */;
/*!40000 ALTER TABLE `insumos_productos_rel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modulos`
--

DROP TABLE IF EXISTS `modulos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `modulos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(100) NOT NULL,
  `activo` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='Esta tabla tiene definido los módulos, en esta se ve cuales están y cuales no Activos';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modulos`
--

LOCK TABLES `modulos` WRITE;
/*!40000 ALTER TABLE `modulos` DISABLE KEYS */;
INSERT INTO `modulos` VALUES (1,'Produccion','S'),(2,'Configuracion','S'),(3,'Atencion','N'),(4,'Recursos Humanos','N');
/*!40000 ALTER TABLE `modulos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orden_de_produccion`
--

DROP TABLE IF EXISTS `orden_de_produccion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orden_de_produccion` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'identificador de la tabla',
  `id_pedidos` int(11) NOT NULL,
  `id_empleado` int(11) DEFAULT NULL,
  `id_producto` int(11) DEFAULT NULL,
  `descripcion` varchar(45) NOT NULL COMMENT 'descripcion de la orden',
  `es_activo` int(11) DEFAULT NULL,
  `fecha_inicio` date DEFAULT NULL COMMENT 'fecha de puesta en marcha de la orden',
  `fecha_fin` date DEFAULT NULL COMMENT 'fecha de entrega de la produccion',
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`,`id_pedidos`),
  KEY `fk_orden_de_produccion_pedidos1_idx` (`id_pedidos`),
  CONSTRAINT `fk_orden_de_produccion_pedidos1` FOREIGN KEY (`id_pedidos`) REFERENCES `pedidos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orden_de_produccion`
--

LOCK TABLES `orden_de_produccion` WRITE;
/*!40000 ALTER TABLE `orden_de_produccion` DISABLE KEYS */;
/*!40000 ALTER TABLE `orden_de_produccion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paises`
--

DROP TABLE IF EXISTS `paises`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `paises` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(150) NOT NULL,
  `abreviatura` varchar(150) DEFAULT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `cod_pais_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paises`
--

LOCK TABLES `paises` WRITE;
/*!40000 ALTER TABLE `paises` DISABLE KEYS */;
/*!40000 ALTER TABLE `paises` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pedidos`
--

DROP TABLE IF EXISTS `pedidos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pedidos` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'identificador de la tabla',
  `id_formato` int(11) NOT NULL,
  `id_cliente` int(11) NOT NULL COMMENT 'identificador del cliente solicitante del pedido',
  `codigo` varchar(45) NOT NULL,
  `descripcion` varchar(45) NOT NULL COMMENT 'descripcion de la tabla',
  `fecha_entrega` date DEFAULT NULL COMMENT 'fecha de entrega del pedido',
  `presupuesto` float NOT NULL COMMENT 'monto presupuestado para el pedido ',
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  `fecha_registro` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_pedidos_formato1_idx` (`id_formato`),
  CONSTRAINT `fk_pedidos_formato1` FOREIGN KEY (`id_formato`) REFERENCES `formato` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='Tabla donde se encuentran los pedidos listados';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pedidos`
--

LOCK TABLES `pedidos` WRITE;
/*!40000 ALTER TABLE `pedidos` DISABLE KEYS */;
INSERT INTO `pedidos` VALUES (1,1,1,'111','Libro 150 hojas Tapadura','2016-06-11',500000,'admin','2016-02-19 00:00:00','admin','2016-02-19 00:00:00','2016-02-19'),(2,24,2,'123','libro123',NULL,123123,'admin','2016-02-19 16:43:42','admin','2016-02-19 16:43:42',NULL);
/*!40000 ALTER TABLE `pedidos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permisos`
--

DROP TABLE IF EXISTS `permisos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `permisos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_grupos_usuarios` int(11) NOT NULL COMMENT 'Define el grupo de usuario a la cual va el permiso',
  `id_rel_modulos_ventanas` int(11) NOT NULL COMMENT 'Define el ID de la relacion a la cual tiene permiso el usuario.',
  `activo` varchar(1) NOT NULL COMMENT 'Define el estado del permiso, si esta activo o no.',
  `inserta` varchar(1) NOT NULL COMMENT 'Define si puede hacer insercion de registros en esta ventana',
  `modifica` varchar(1) NOT NULL COMMENT 'Define si puede modificar registros en esta ventana',
  `elimina` varchar(1) NOT NULL COMMENT 'Define si puede eliminar registros en esta ventana',
  `consulta` varchar(1) NOT NULL COMMENT 'Define si puede hacer consulta de registros en esta ventana',
  `user_insert` varchar(15) NOT NULL COMMENT 'Define quien es el usuario que inserto el registro',
  `date_insert` datetime NOT NULL COMMENT 'Define la fecha en que se inserto el registro',
  `user_update` varchar(15) NOT NULL COMMENT 'Define quien es el usuario que modifico el registro',
  `date_update` datetime NOT NULL COMMENT 'Define la fecha en que se modifico el registro',
  PRIMARY KEY (`id`,`id_grupos_usuarios`,`id_rel_modulos_ventanas`),
  KEY `fk_permisos_grupos_usuarios1_idx` (`id_grupos_usuarios`),
  KEY `fk_permisos_rel_modulos_ventanas1_idx` (`id_rel_modulos_ventanas`),
  CONSTRAINT `fk_permisos_grupos_usuarios1` FOREIGN KEY (`id_grupos_usuarios`) REFERENCES `grupos_usuarios` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_permisos_rel_modulos_ventanas1` FOREIGN KEY (`id_rel_modulos_ventanas`) REFERENCES `rel_modulos_ventanas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8 COMMENT='Esta tabla sirve para definir a que ventanas pueden acceder cada grupo de usuarios';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permisos`
--

LOCK TABLES `permisos` WRITE;
/*!40000 ALTER TABLE `permisos` DISABLE KEYS */;
INSERT INTO `permisos` VALUES (1,1,1,'S','S','S','S','S','admin','2016-01-17 00:00:00','admin','2016-01-17 00:00:00'),(2,1,2,'S','S','S','S','S','admin','2016-01-17 00:00:00','admin','2016-01-17 00:00:00'),(3,1,3,'S','S','S','S','S','admin','2016-01-17 00:00:00','admin','2016-01-17 00:00:00'),(4,1,4,'S','S','S','S','S','admin','2016-01-17 00:00:00','admin','2016-01-17 00:00:00'),(5,1,5,'N','S','S','S','S','admin','2016-01-17 00:00:00','admin','2016-01-17 00:00:00'),(8,1,8,'S','S','S','S','S','admin','2016-01-17 00:00:00','admin','2016-01-17 00:00:00'),(9,1,9,'S','S','S','S','S','admin','2016-01-17 00:00:00','admin','2016-01-17 00:00:00'),(10,1,10,'S','S','S','S','S','admin','2016-01-17 00:00:00','admin','2016-01-17 00:00:00'),(11,1,12,'S','S','S','S','S','admin','2016-01-17 00:00:00','admin','2016-01-17 00:00:00'),(12,1,13,'N','S','S','S','S','admin','2016-01-17 00:00:00','admin','2016-01-17 00:00:00'),(13,1,14,'S','S','S','S','S','admin','2016-01-17 00:00:00','admin','2016-01-17 00:00:00'),(14,1,15,'N','S','S','S','S','admin','2016-01-17 00:00:00','admin','2016-01-17 00:00:00'),(15,1,16,'S','S','S','S','S','admin','2016-01-17 00:00:00','admin','2016-01-17 00:00:00'),(16,1,17,'S','S','S','S','S','admin','2016-01-17 00:00:00','admin','2016-01-17 00:00:00');
/*!40000 ALTER TABLE `permisos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personas`
--

DROP TABLE IF EXISTS `personas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `personas` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `apellido` varchar(100) DEFAULT NULL,
  `fecha_nac` date DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `fisica` char(1) DEFAULT NULL COMMENT 'En esta columna se define si la persona creada es fisica o no, de no ser significa que es una empresa, banco, etc.',
  `cedula` varchar(50) DEFAULT NULL,
  `estado` varchar(1) DEFAULT 'S',
  `id_pais` int(11) DEFAULT NULL,
  `id_departamento` int(11) DEFAULT NULL,
  `id_ciudad` int(11) DEFAULT NULL,
  `id_barrio` int(11) DEFAULT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_persona_UNIQUE` (`id`),
  KEY `fk_personas_paises_idx` (`id_pais`),
  KEY `fk_personas_departamentos1_idx` (`id_departamento`),
  KEY `fk_personas_ciudades1_idx` (`id_ciudad`),
  KEY `fk_personas_barrios1_idx` (`id_barrio`),
  CONSTRAINT `fk_personas_barrios1` FOREIGN KEY (`id_barrio`) REFERENCES `barrios` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_personas_ciudades1` FOREIGN KEY (`id_ciudad`) REFERENCES `ciudades` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_personas_departamentos1` FOREIGN KEY (`id_departamento`) REFERENCES `departamentos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_personas_paises` FOREIGN KEY (`id_pais`) REFERENCES `paises` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='En esta tabla se crean las personas que luego seran clientes, proveedores, empleados, bancos, etc.';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personas`
--

LOCK TABLES `personas` WRITE;
/*!40000 ALTER TABLE `personas` DISABLE KEYS */;
INSERT INTO `personas` VALUES (1,'Williams','Gonzalez','1993-09-02','williamseduardo93','S','5393675','S',NULL,NULL,NULL,NULL,'WILLI','0000-00-00 00:00:00','WILLI','0000-00-00 00:00:00');
/*!40000 ALTER TABLE `personas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `productos` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'identificador de la tabla',
  `codigo` varchar(45) NOT NULL,
  `descripcion` varchar(45) NOT NULL COMMENT 'descripcion del producto',
  `costo` double NOT NULL COMMENT 'costo del producto',
  `estado` varchar(1) NOT NULL DEFAULT 'S',
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  `cantidad` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES (1,'1','Percy Jackson - Libro 1',37000,'S','admin','2016-01-30 00:00:00','admin','2016-02-17 00:31:03',3),(5,'2','Percy Jackson - Libro 2',45000,'S','admin','2016-01-30 00:00:00','admin','2016-02-17 00:31:49',3),(6,'3','Percy Jackson - Libro 3',41000,'S','admin','2016-01-30 00:00:00','admin','2016-02-13 11:39:23',4),(7,'4','Percy Jackson - Libro 4',40000,'S','admin','2016-01-30 00:00:00','admin','2016-02-13 11:39:23',15),(8,'5','Percy Jackson - Libro 5',38000,'S','admin','2016-01-30 00:00:00','admin','2016-02-13 11:39:23',20),(9,'6','Prueba',12500,'S','admin','2016-02-17 00:17:44','admin','2016-02-17 00:17:44',7),(10,'7','Demo',3122,'S','admin','2016-02-17 00:42:38','admin','2016-10-12 19:18:04',1),(11,'8','Carolina Producto',3500,'N','ADMIN','2016-02-18 21:32:42','admin','2016-10-12 19:18:04',0),(12,'H1m1','HarryPotter',200000,'S','admin','2016-02-19 11:00:31','admin','2016-02-19 11:00:49',50);
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rel_modulos_ventanas`
--

DROP TABLE IF EXISTS `rel_modulos_ventanas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rel_modulos_ventanas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_modulos` int(11) NOT NULL,
  `id_ventanas` int(11) NOT NULL,
  PRIMARY KEY (`id`,`id_modulos`,`id_ventanas`),
  KEY `fk_rel_modulos_ventanas_modulos1_idx` (`id_modulos`),
  KEY `fk_rel_modulos_ventanas_ventanas1_idx` (`id_ventanas`),
  CONSTRAINT `fk_rel_modulos_ventanas_modulos1` FOREIGN KEY (`id_modulos`) REFERENCES `modulos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_rel_modulos_ventanas_ventanas1` FOREIGN KEY (`id_ventanas`) REFERENCES `ventanas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rel_modulos_ventanas`
--

LOCK TABLES `rel_modulos_ventanas` WRITE;
/*!40000 ALTER TABLE `rel_modulos_ventanas` DISABLE KEYS */;
INSERT INTO `rel_modulos_ventanas` VALUES (1,1,1),(2,1,2),(3,1,5),(4,1,6),(5,1,7),(12,1,10),(16,1,12),(17,1,15),(6,2,3),(7,2,4),(9,2,8),(14,2,13),(15,2,14),(8,3,5),(10,4,9),(13,4,11);
/*!40000 ALTER TABLE `rel_modulos_ventanas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `seguimientos`
--

DROP TABLE IF EXISTS `seguimientos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `seguimientos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_orden_de_produccion` int(11) NOT NULL,
  `descripcion` varchar(256) NOT NULL,
  `fecha` date NOT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`,`id_orden_de_produccion`),
  KEY `fk_seguimientos_orden_de_produccion1_idx` (`id_orden_de_produccion`),
  CONSTRAINT `fk_seguimientos_orden_de_produccion1` FOREIGN KEY (`id_orden_de_produccion`) REFERENCES `orden_de_produccion` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seguimientos`
--

LOCK TABLES `seguimientos` WRITE;
/*!40000 ALTER TABLE `seguimientos` DISABLE KEYS */;
/*!40000 ALTER TABLE `seguimientos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `seguimientos_insumos_rel`
--

DROP TABLE IF EXISTS `seguimientos_insumos_rel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `seguimientos_insumos_rel` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_seguimientos` int(11) NOT NULL,
  `id_insumos` int(11) NOT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`,`id_seguimientos`,`id_insumos`),
  KEY `fk_seguimientos_insumos_rel_insumos1_idx` (`id_insumos`),
  KEY `fk_seguimientos_insumos_rel_seguimientos1_idx` (`id_seguimientos`),
  CONSTRAINT `fk_seguimientos_insumos_rel_insumos1` FOREIGN KEY (`id_insumos`) REFERENCES `insumos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_seguimientos_insumos_rel_seguimientos1` FOREIGN KEY (`id_seguimientos`) REFERENCES `seguimientos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seguimientos_insumos_rel`
--

LOCK TABLES `seguimientos_insumos_rel` WRITE;
/*!40000 ALTER TABLE `seguimientos_insumos_rel` DISABLE KEYS */;
/*!40000 ALTER TABLE `seguimientos_insumos_rel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `seguimientos_productos_rel`
--

DROP TABLE IF EXISTS `seguimientos_productos_rel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `seguimientos_productos_rel` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_seguimientos` int(11) NOT NULL,
  `id_productos` int(11) NOT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`,`id_seguimientos`,`id_productos`),
  KEY `fk_seguimientos_productos_rel_productos1_idx` (`id_productos`),
  KEY `fk_seguimientos_productos_rel_seguimientos1_idx` (`id_seguimientos`),
  CONSTRAINT `fk_seguimientos_productos_rel_productos1` FOREIGN KEY (`id_productos`) REFERENCES `productos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_seguimientos_productos_rel_seguimientos1` FOREIGN KEY (`id_seguimientos`) REFERENCES `seguimientos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seguimientos_productos_rel`
--

LOCK TABLES `seguimientos_productos_rel` WRITE;
/*!40000 ALTER TABLE `seguimientos_productos_rel` DISABLE KEYS */;
/*!40000 ALTER TABLE `seguimientos_productos_rel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sucursales`
--

DROP TABLE IF EXISTS `sucursales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sucursales` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_empresa` int(11) NOT NULL,
  `descripcion` varchar(150) NOT NULL,
  `direccion` varchar(300) DEFAULT NULL,
  `telefono` varchar(45) DEFAULT NULL,
  `timbrado` varchar(50) DEFAULT NULL,
  `estado` varchar(1) DEFAULT 'S',
  `id_pais` int(11) DEFAULT NULL,
  `id_departamento` int(11) DEFAULT NULL,
  `id_ciudad` int(11) DEFAULT NULL,
  `id_barrio` int(11) DEFAULT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`,`id_empresa`),
  KEY `fk_sucursales_barrios1_idx` (`id_barrio`,`id_pais`,`id_departamento`,`id_ciudad`),
  KEY `fk_sucursales_empresas1_idx` (`id_empresa`),
  CONSTRAINT `fk_sucursales_barrios1` FOREIGN KEY (`id_barrio`, `id_pais`, `id_departamento`, `id_ciudad`) REFERENCES `barrios` (`id`, `id_pais`, `id_departamento`, `id_ciudad`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_sucursales_empresas1` FOREIGN KEY (`id_empresa`) REFERENCES `empresas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sucursales`
--

LOCK TABLES `sucursales` WRITE;
/*!40000 ALTER TABLE `sucursales` DISABLE KEYS */;
/*!40000 ALTER TABLE `sucursales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `telefonos`
--

DROP TABLE IF EXISTS `telefonos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `telefonos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_persona` int(11) NOT NULL,
  `area` varchar(45) DEFAULT NULL,
  `numero` varchar(45) DEFAULT NULL,
  `tipo` varchar(45) DEFAULT NULL COMMENT 'aquí se define si es de trabajo, privado, etc.',
  `defecto` varchar(45) DEFAULT NULL,
  `user_insert` varchar(15) NOT NULL,
  `date_insert` datetime NOT NULL,
  `user_update` varchar(15) NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`,`id_persona`),
  KEY `fk_telefonos_personas1_idx` (`id_persona`),
  CONSTRAINT `fk_telefonos_personas1` FOREIGN KEY (`id_persona`) REFERENCES `personas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `telefonos`
--

LOCK TABLES `telefonos` WRITE;
/*!40000 ALTER TABLE `telefonos` DISABLE KEYS */;
/*!40000 ALTER TABLE `telefonos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unidad_medidas`
--

DROP TABLE IF EXISTS `unidad_medidas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unidad_medidas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` int(11) NOT NULL,
  `descripcion` varchar(45) NOT NULL,
  `abreviatura` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidad_medidas`
--

LOCK TABLES `unidad_medidas` WRITE;
/*!40000 ALTER TABLE `unidad_medidas` DISABLE KEYS */;
INSERT INTO `unidad_medidas` VALUES (1,1,'Unidad','uni'),(2,2,'Kilos','kg'),(3,3,'Metros','mt'),(4,4,'Centimetros','cm'),(5,5,'Gramos','gr');
/*!40000 ALTER TABLE `unidad_medidas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user` varchar(15) NOT NULL COMMENT 'Esta columna registra el "Nombre de Usuario" con el cual se logueará el usuario.',
  `password` varchar(32) NOT NULL COMMENT 'Esta columan registra la contraseña de manera alfanumerica del usuario.',
  `create_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Registra la fecha y hora en que el usuario se creó.',
  `id_persona` int(11) NOT NULL,
  `id_empresa` int(11) NOT NULL,
  `id_grupos_usuarios` int(11) NOT NULL,
  `estado` varchar(1) DEFAULT 'S',
  PRIMARY KEY (`id`,`user`,`id_persona`,`id_empresa`,`id_grupos_usuarios`),
  KEY `fk_user_personas1_idx` (`id_persona`),
  KEY `fk_user_empresas1_idx` (`id_empresa`),
  KEY `fk_user_grupos_usuarios1_idx` (`id_grupos_usuarios`),
  CONSTRAINT `fk_user_empresas1` FOREIGN KEY (`id_empresa`) REFERENCES `empresas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_grupos_usuarios1` FOREIGN KEY (`id_grupos_usuarios`) REFERENCES `grupos_usuarios` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_personas1` FOREIGN KEY (`id_persona`) REFERENCES `personas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'admin','admin123','2016-02-13 18:11:58',1,1,1,'S'),(5,'qqqwerty','qq','2016-02-10 22:59:21',1,1,1,'N');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ventanas`
--

DROP TABLE IF EXISTS `ventanas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ventanas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(300) NOT NULL,
  `nombre` varchar(300) DEFAULT NULL,
  `img` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ventanas`
--

LOCK TABLES `ventanas` WRITE;
/*!40000 ALTER TABLE `ventanas` DISABLE KEYS */;
INSERT INTO `ventanas` VALUES (1,'productos','Productos','Productos'),(2,'insumos','Insumos','Insumos'),(3,'compras','Compras','Formatos'),(4,'ventas','Ventas','Formatos'),(5,'pedidos','Pedidos','Pedidos'),(6,'orden','Orden','Orden'),(7,'calendario','Calendario','Formatos'),(8,'usuarios','Usuarios','Usuarios'),(9,'personas','Personas','Formatos'),(10,'combo','Materia Prima','Combo'),(11,'depositos','Depositos','Depositos'),(12,'seguimientos','Seguimientos','Seguimiento'),(13,'clientes','Clientes','Clientes'),(14,'formatos','Formatos','Formatos'),(15,'productos_combo','Productos Combo','Formatos');
/*!40000 ALTER TABLE `ventanas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'arandura'
--
/*!50003 DROP FUNCTION IF EXISTS `initcap` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `initcap`(x varchar(1000)) RETURNS varchar(1000) CHARSET utf8
BEGIN
SET @str='';
SET @l_str='';
WHILE x REGEXP ' ' DO
SELECT SUBSTRING_INDEX(x, ' ', 1) INTO @l_str;
SELECT SUBSTRING(x, LOCATE(' ', x)+1) INTO x;
SELECT CONCAT(@str, ' ', CONCAT(UPPER(SUBSTRING(@l_str,1,1)),LOWER(SUBSTRING(@l_str,2)))) INTO @str;
END WHILE;
RETURN LTRIM(CONCAT(@str, ' ', CONCAT(UPPER(SUBSTRING(x,1,1)),LOWER(SUBSTRING(x,2)))));
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

-- Dump completed on 2017-04-30 16:41:58
