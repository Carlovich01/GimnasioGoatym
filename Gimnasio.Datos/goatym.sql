CREATE DATABASE  IF NOT EXISTS `goatym2` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `goatym2`;
-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: goatym2
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
-- Table structure for table `asistencia`
--

DROP TABLE IF EXISTS `asistencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `asistencia` (
  `id_asistencia` bigint unsigned NOT NULL AUTO_INCREMENT COMMENT 'Usar BIGINT si se esperan muchos check-ins',
  `id_miembro` int unsigned DEFAULT NULL COMMENT 'Miembro que realizó el check-in',
  `fecha_hora_checkin` timestamp NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Fecha y hora exactas del intento de ingreso',
  `resultado` enum('Exitoso','Fallido_DNI_NoEncontrado','Fallido_Membresia_Inactiva','Fallido_No_Hay_Membresia','Fallido_Otro') NOT NULL COMMENT 'Resultado de la validación del check-in',
  `id_membresia_valida` int unsigned DEFAULT NULL COMMENT 'Opcional: ID de la membresía que permitió el acceso exitoso',
  PRIMARY KEY (`id_asistencia`),
  KEY `fk_asistencia_membresia_valida` (`id_membresia_valida`),
  KEY `idx_asistencia_miembro` (`id_miembro`),
  KEY `idx_asistencia_fecha` (`fecha_hora_checkin`),
  KEY `idx_asistencia_resultado` (`resultado`),
  CONSTRAINT `fk_asistencia_membresia_valida` FOREIGN KEY (`id_membresia_valida`) REFERENCES `membresias_miembro` (`id_membresia`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `fk_asistencia_miembro` FOREIGN KEY (`id_miembro`) REFERENCES `miembros` (`id_miembro`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Log de ingresos (check-ins) de los miembros';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asistencia`
--

LOCK TABLES `asistencia` WRITE;
/*!40000 ALTER TABLE `asistencia` DISABLE KEYS */;
INSERT INTO `asistencia` VALUES (12,15,'2025-05-11 18:49:50','Exitoso',NULL);
/*!40000 ALTER TABLE `asistencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `membresias_miembro`
--

DROP TABLE IF EXISTS `membresias_miembro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `membresias_miembro` (
  `id_membresia` int unsigned NOT NULL AUTO_INCREMENT,
  `id_miembro` int unsigned NOT NULL COMMENT 'Referencia al miembro',
  `id_plan` int unsigned NOT NULL COMMENT 'Referencia al plan contratado',
  `fecha_inicio` date NOT NULL COMMENT 'Fecha de inicio de la vigencia de esta membresía',
  `fecha_fin` date NOT NULL COMMENT 'Fecha de fin de la vigencia de esta membresía (calculada)',
  `estado_membresia` enum('Activa','Inactiva') NOT NULL DEFAULT 'Inactiva' COMMENT 'Estado actual de esta instancia de membresía',
  `fecha_registro` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `ultima_modificacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_membresia`),
  KEY `idx_membresia_miembro` (`id_miembro`),
  KEY `idx_membresia_plan` (`id_plan`),
  KEY `idx_membresia_fechas` (`fecha_inicio`,`fecha_fin`),
  KEY `idx_membresia_estado` (`estado_membresia`),
  CONSTRAINT `fk_membresia_miembro` FOREIGN KEY (`id_miembro`) REFERENCES `miembros` (`id_miembro`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_membresia_plan` FOREIGN KEY (`id_plan`) REFERENCES `planes_membresia` (`id_plan`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Instancias de suscripción de los miembros a planes';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `membresias_miembro`
--

LOCK TABLES `membresias_miembro` WRITE;
/*!40000 ALTER TABLE `membresias_miembro` DISABLE KEYS */;
INSERT INTO `membresias_miembro` VALUES (20,19,10,'2025-05-11','2025-05-11','Inactiva','2025-05-11 19:18:41','2025-05-11 20:58:14'),(21,20,9,'2025-05-11','2025-05-26','Activa','2025-05-11 19:31:53','2025-05-11 19:58:39'),(22,20,10,'2025-05-11','2025-05-11','Inactiva','2025-05-11 19:41:53','2025-05-11 19:41:53'),(23,17,10,'2025-05-11','2025-05-11','Inactiva','2025-05-11 19:58:49','2025-05-11 19:58:49'),(24,22,9,'2025-05-11','2025-05-11','Inactiva','2025-05-11 20:02:46','2025-05-11 20:02:46'),(25,21,9,'2025-05-11','2025-05-26','Activa','2025-05-11 20:03:44','2025-05-11 20:03:48'),(27,15,9,'2025-05-11','2025-05-11','Inactiva','2025-05-11 20:54:02','2025-05-11 20:54:02');
/*!40000 ALTER TABLE `membresias_miembro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `miembros`
--

DROP TABLE IF EXISTS `miembros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `miembros` (
  `id_miembro` int unsigned NOT NULL AUTO_INCREMENT,
  `dni` varchar(15) NOT NULL COMMENT 'Documento Nacional de Identidad (clave natural única)',
  `nombre` varchar(100) NOT NULL,
  `apellido` varchar(100) NOT NULL,
  `genero` enum('Masculino','Femenino','Otro','Prefiero no decir') DEFAULT NULL,
  `telefono` varchar(30) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL COMMENT 'Email del miembro (puede ser único si se usa para login futuro)',
  `fecha_registro` timestamp NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Fecha en que el miembro fue registrado en el sistema',
  `ultima_modificacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_miembro`),
  UNIQUE KEY `dni` (`dni`),
  KEY `idx_miembro_dni` (`dni`),
  KEY `idx_miembro_apellido` (`apellido`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Clientes del gimnasio';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `miembros`
--

LOCK TABLES `miembros` WRITE;
/*!40000 ALTER TABLE `miembros` DISABLE KEYS */;
INSERT INTO `miembros` VALUES (15,'454699222','carlossss','diaz','Prefiero no decir','37342312','car@yahoo.com','2025-05-11 18:42:56','2025-05-11 20:39:09'),(16,'32313','ram','gia','Masculino','3133223','xd@gmail.com','2025-05-11 18:43:50','2025-05-11 18:43:50'),(17,'123','chismu','x','Masculino',NULL,NULL,'2025-05-11 19:16:38','2025-05-11 19:16:38'),(18,'12345','nose','nose','Masculino',NULL,NULL,'2025-05-11 19:17:50','2025-05-11 19:17:50'),(19,'2222','xd','das','Masculino',NULL,NULL,'2025-05-11 19:18:21','2025-05-11 19:18:21'),(20,'777','Vegeta','nose','Masculino',NULL,NULL,'2025-05-11 19:31:35','2025-05-11 19:31:35'),(21,'000','juan','xd','Masculino',NULL,NULL,'2025-05-11 20:02:04','2025-05-11 20:02:04'),(22,'999','Pepe','Pepe','Masculino',NULL,NULL,'2025-05-11 20:02:36','2025-05-11 20:02:36'),(23,'nose','Dr ','House','Masculino',NULL,NULL,'2025-05-11 20:04:35','2025-05-11 20:04:35');
/*!40000 ALTER TABLE `miembros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagos`
--

DROP TABLE IF EXISTS `pagos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pagos` (
  `id_pago` int unsigned NOT NULL AUTO_INCREMENT,
  `id_membresia` int unsigned DEFAULT NULL COMMENT 'Membresía específica que se está pagando/renovando',
  `id_usuario_registro` int unsigned DEFAULT NULL COMMENT 'Usuario del sistema que registró el pago (opcional, para auditoría)',
  `fecha_pago` timestamp NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Fecha y hora exactas en que se registró el pago',
  `monto_pagado` decimal(10,2) NOT NULL COMMENT 'Cantidad de dinero recibida',
  `metodo_pago` enum('Efectivo','Tarjeta Débito','Tarjeta Crédito','Transferencia Bancaria','Mercado Pago','Otro') NOT NULL,
  `numero_comprobante` varchar(100) DEFAULT NULL COMMENT 'Número de factura, ticket o referencia de la transacción',
  `notas` text COMMENT 'Notas adicionales sobre el pago',
  PRIMARY KEY (`id_pago`),
  KEY `idx_pago_membresia` (`id_membresia`),
  KEY `idx_pago_usuario` (`id_usuario_registro`),
  KEY `idx_pago_fecha` (`fecha_pago`),
  CONSTRAINT `fk_pago_membresia` FOREIGN KEY (`id_membresia`) REFERENCES `membresias_miembro` (`id_membresia`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `fk_pago_usuario` FOREIGN KEY (`id_usuario_registro`) REFERENCES `usuarios_sistema` (`id_usuario`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Registro de transacciones económicas de los miembros';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagos`
--

LOCK TABLES `pagos` WRITE;
/*!40000 ALTER TABLE `pagos` DISABLE KEYS */;
INSERT INTO `pagos` VALUES (10,NULL,1,'2025-05-11 18:46:53',14000.00,'Mercado Pago',NULL,NULL),(11,NULL,1,'2025-05-11 18:48:11',1000.00,'Efectivo',NULL,NULL),(13,21,1,'2025-05-11 19:58:39',14000.00,'Efectivo',NULL,NULL),(15,25,1,'2025-05-11 20:03:48',14000.00,'Efectivo',NULL,NULL),(16,NULL,1,'2025-05-11 20:04:47',1000.00,'Efectivo',NULL,NULL);
/*!40000 ALTER TABLE `pagos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `planes_membresia`
--

DROP TABLE IF EXISTS `planes_membresia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `planes_membresia` (
  `id_plan` int unsigned NOT NULL AUTO_INCREMENT,
  `nombre_plan` varchar(100) NOT NULL COMMENT 'Nombre descriptivo del plan (Ej: Mensual Full, Trimestral Mañanas)',
  `descripcion` text,
  `duracion_dias` int unsigned NOT NULL COMMENT 'Duración del plan en días (Ej: 30, 90, 365)',
  `precio` decimal(10,2) NOT NULL COMMENT 'Costo del plan',
  `fecha_creacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `ultima_modificacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_plan`),
  UNIQUE KEY `nombre_plan` (`nombre_plan`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Tipos de suscripciones ofrecidas';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `planes_membresia`
--

LOCK TABLES `planes_membresia` WRITE;
/*!40000 ALTER TABLE `planes_membresia` DISABLE KEYS */;
INSERT INTO `planes_membresia` VALUES (9,'Futb','x',15,14000.00,'2025-05-11 18:41:43','2025-05-11 18:42:17'),(10,'xd','aaa',10,1000.00,'2025-05-11 18:42:33','2025-05-11 18:42:33');
/*!40000 ALTER TABLE `planes_membresia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reclamos`
--

DROP TABLE IF EXISTS `reclamos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reclamos` (
  `id_reclamos` int NOT NULL AUTO_INCREMENT,
  `tipo` enum('sugerencia','reclamo') NOT NULL,
  `descripcion` text NOT NULL,
  `fecha_envio` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `estado` enum('pendiente','resuelto') NOT NULL DEFAULT 'pendiente',
  `respuesta` text,
  `fecha_respuesta` timestamp NULL DEFAULT NULL,
  `id_miembro` int unsigned DEFAULT NULL,
  PRIMARY KEY (`id_reclamos`),
  KEY `fk_reclamos_miembros1_idx` (`id_miembro`),
  CONSTRAINT `fk_reclamos_miembros1` FOREIGN KEY (`id_miembro`) REFERENCES `miembros` (`id_miembro`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reclamos`
--

LOCK TABLES `reclamos` WRITE;
/*!40000 ALTER TABLE `reclamos` DISABLE KEYS */;
INSERT INTO `reclamos` VALUES (4,'sugerencia','xd','2025-05-11 16:33:29','resuelto','xddddddd','2025-05-11 16:38:40',NULL),(5,'sugerencia','xdddd','2025-05-11 16:33:53','pendiente','aaaaa','2025-05-11 17:06:20',NULL),(7,'sugerencia','adadsasddsdsa','2025-05-11 18:50:49','resuelto','ta bien xd','2025-05-11 18:51:39',15);
/*!40000 ALTER TABLE `reclamos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `id_rol` int unsigned NOT NULL AUTO_INCREMENT,
  `nombre_rol` enum('Administrador','Recepcionista') NOT NULL COMMENT 'Nombre único del rol (Ej: Administrador, Recepcionista)',
  `descripcion_rol` text COMMENT 'Descripción opcional de las responsabilidades del rol',
  `fecha_creacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_rol`),
  UNIQUE KEY `nombre_rol` (`nombre_rol`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Roles de los usuarios del sistema';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Administrador','Acceso a todo el Sistema','2025-05-05 03:36:00'),(2,'Recepcionista','Acceso parcial','2025-05-05 03:36:00');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios_sistema`
--

DROP TABLE IF EXISTS `usuarios_sistema`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios_sistema` (
  `id_usuario` int unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL COMMENT 'Nombre de usuario para login',
  `password_hash` varchar(255) NOT NULL COMMENT 'Contraseña hasheada (NUNCA guardar texto plano)',
  `nombre_completo` varchar(150) NOT NULL COMMENT 'Nombre y apellido del empleado',
  `email` varchar(100) DEFAULT NULL COMMENT 'Email del empleado (opcional, pero útil)',
  `id_rol` int unsigned NOT NULL COMMENT 'Rol del usuario en el sistema',
  `fecha_creacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `ultima_modificacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_usuario`),
  UNIQUE KEY `username` (`username`),
  KEY `idx_usuario_rol` (`id_rol`),
  CONSTRAINT `fk_usuario_rol` FOREIGN KEY (`id_rol`) REFERENCES `roles` (`id_rol`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Usuarios que operan el sistema (staff)';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios_sistema`
--

LOCK TABLES `usuarios_sistema` WRITE;
/*!40000 ALTER TABLE `usuarios_sistema` DISABLE KEYS */;
INSERT INTO `usuarios_sistema` VALUES (1,'admin','A6xnQhbz4Vx2HuGl4lXwZ5U2I8iziLRFnhP5eNfIRvQ=','Carlos Diaz',NULL,1,'2025-05-07 01:56:09','2025-05-07 01:56:09'),(3,'Ramiro','A6xnQhbz4Vx2HuGl4lXwZ5U2I8iziLRFnhP5eNfIRvQ=','Ramiro Gianello','ramiro@gmail.com',2,'2025-05-08 11:29:43','2025-05-11 18:32:23');
/*!40000 ALTER TABLE `usuarios_sistema` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `vista_asistencia`
--

DROP TABLE IF EXISTS `vista_asistencia`;
/*!50001 DROP VIEW IF EXISTS `vista_asistencia`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vista_asistencia` AS SELECT 
 1 AS `id_asistencia`,
 1 AS `id_miembro`,
 1 AS `id_membresia`,
 1 AS `dni_miembro`,
 1 AS `nombre_miembro`,
 1 AS `apellido_miembro`,
 1 AS `fecha_ingreso`,
 1 AS `resultado`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vista_membresias`
--

DROP TABLE IF EXISTS `vista_membresias`;
/*!50001 DROP VIEW IF EXISTS `vista_membresias`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vista_membresias` AS SELECT 
 1 AS `id_membresia`,
 1 AS `id_miembro`,
 1 AS `id_plan`,
 1 AS `dni_miembro`,
 1 AS `apellido_miembro`,
 1 AS `nombre_miembro`,
 1 AS `nombre_plan`,
 1 AS `precio_plan`,
 1 AS `duracion_dias_plan`,
 1 AS `fecha_inicio`,
 1 AS `fecha_fin`,
 1 AS `estado_membresia`,
 1 AS `fecha_registro`,
 1 AS `ultima_modificacion`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vista_pagos`
--

DROP TABLE IF EXISTS `vista_pagos`;
/*!50001 DROP VIEW IF EXISTS `vista_pagos`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vista_pagos` AS SELECT 
 1 AS `id_pago`,
 1 AS `id_membresia`,
 1 AS `id_usuario_registro`,
 1 AS `apellido_miembro`,
 1 AS `nombre_miembro`,
 1 AS `dni_miembro`,
 1 AS `nombre_plan`,
 1 AS `monto`,
 1 AS `metodo`,
 1 AS `comprobante`,
 1 AS `fecha_pago`,
 1 AS `nombre_usuario`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vista_reclamos`
--

DROP TABLE IF EXISTS `vista_reclamos`;
/*!50001 DROP VIEW IF EXISTS `vista_reclamos`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vista_reclamos` AS SELECT 
 1 AS `id_reclamos`,
 1 AS `tipo`,
 1 AS `descripcion`,
 1 AS `fecha_envio`,
 1 AS `estado`,
 1 AS `respuesta`,
 1 AS `fecha_respuesta`,
 1 AS `dni_miembro`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'goatym2'
--

--
-- Dumping routines for database 'goatym2'
--

--
-- Final view structure for view `vista_asistencia`
--

/*!50001 DROP VIEW IF EXISTS `vista_asistencia`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vista_asistencia` AS select `a`.`id_asistencia` AS `id_asistencia`,`a`.`id_miembro` AS `id_miembro`,`a`.`id_membresia_valida` AS `id_membresia`,`m`.`dni` AS `dni_miembro`,`m`.`nombre` AS `nombre_miembro`,`m`.`apellido` AS `apellido_miembro`,`a`.`fecha_hora_checkin` AS `fecha_ingreso`,`a`.`resultado` AS `resultado` from ((`asistencia` `a` join `miembros` `m` on((`a`.`id_miembro` = `m`.`id_miembro`))) left join `membresias_miembro` `mm` on((`a`.`id_membresia_valida` = `mm`.`id_membresia`))) order by `a`.`fecha_hora_checkin` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vista_membresias`
--

/*!50001 DROP VIEW IF EXISTS `vista_membresias`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vista_membresias` AS select `mm`.`id_membresia` AS `id_membresia`,`mm`.`id_miembro` AS `id_miembro`,`mm`.`id_plan` AS `id_plan`,`m`.`dni` AS `dni_miembro`,`m`.`apellido` AS `apellido_miembro`,`m`.`nombre` AS `nombre_miembro`,`p`.`nombre_plan` AS `nombre_plan`,`p`.`precio` AS `precio_plan`,`p`.`duracion_dias` AS `duracion_dias_plan`,`mm`.`fecha_inicio` AS `fecha_inicio`,`mm`.`fecha_fin` AS `fecha_fin`,`mm`.`estado_membresia` AS `estado_membresia`,`mm`.`fecha_registro` AS `fecha_registro`,`mm`.`ultima_modificacion` AS `ultima_modificacion` from ((`membresias_miembro` `mm` join `miembros` `m` on((`mm`.`id_miembro` = `m`.`id_miembro`))) join `planes_membresia` `p` on((`mm`.`id_plan` = `p`.`id_plan`))) order by `mm`.`ultima_modificacion` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vista_pagos`
--

/*!50001 DROP VIEW IF EXISTS `vista_pagos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vista_pagos` AS select `p`.`id_pago` AS `id_pago`,`p`.`id_membresia` AS `id_membresia`,`p`.`id_usuario_registro` AS `id_usuario_registro`,`m`.`apellido` AS `apellido_miembro`,`m`.`nombre` AS `nombre_miembro`,`m`.`dni` AS `dni_miembro`,`pm`.`nombre_plan` AS `nombre_plan`,`p`.`monto_pagado` AS `monto`,`p`.`metodo_pago` AS `metodo`,`p`.`numero_comprobante` AS `comprobante`,`p`.`fecha_pago` AS `fecha_pago`,`us`.`nombre_completo` AS `nombre_usuario` from ((((`pagos` `p` left join `membresias_miembro` `mm` on((`p`.`id_membresia` = `mm`.`id_membresia`))) left join `miembros` `m` on((`mm`.`id_miembro` = `m`.`id_miembro`))) left join `planes_membresia` `pm` on((`mm`.`id_plan` = `pm`.`id_plan`))) left join `usuarios_sistema` `us` on((`p`.`id_usuario_registro` = `us`.`id_usuario`))) order by `p`.`fecha_pago` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vista_reclamos`
--

/*!50001 DROP VIEW IF EXISTS `vista_reclamos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vista_reclamos` AS select `r`.`id_reclamos` AS `id_reclamos`,`r`.`tipo` AS `tipo`,`r`.`descripcion` AS `descripcion`,`r`.`fecha_envio` AS `fecha_envio`,`r`.`estado` AS `estado`,`r`.`respuesta` AS `respuesta`,`r`.`fecha_respuesta` AS `fecha_respuesta`,`m`.`dni` AS `dni_miembro` from (`reclamos` `r` left join `miembros` `m` on((`r`.`id_miembro` = `m`.`id_miembro`))) order by `r`.`fecha_envio` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-11 18:21:26
