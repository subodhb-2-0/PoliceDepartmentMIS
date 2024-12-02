CREATE DATABASE  IF NOT EXISTS `policedepartmentmis` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `policedepartmentmis`;
-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: policedepartmentmis
-- ------------------------------------------------------
-- Server version	9.1.0

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
-- Table structure for table `applicationuser`
--

DROP TABLE IF EXISTS `applicationuser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `applicationuser` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(255) NOT NULL,
  `MiddleName` varchar(255) DEFAULT NULL,
  `LastName` varchar(255) NOT NULL,
  `UserName` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `Password` varchar(255) NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `applicationuser`
--

LOCK TABLES `applicationuser` WRITE;
/*!40000 ALTER TABLE `applicationuser` DISABLE KEYS */;
INSERT INTO `applicationuser` VALUES (1,'Jane',NULL,'Smith','janesmith','janesmith@example.com','123-456-7890','$2a$11$QpFdf6Z2dQfgDJlYl7g6cuY3oknDhhRYE3IQEcdGn79b6q2lNJzDy',0),(2,'Ram',NULL,'Bahadur','RamB1','ram@example.com','9840000000','$2a$11$OrMvm9sB0JGW42yBN5VJCOU47/P45wScIfNSHngEYAyDHy06DN22u',0),(3,'Admin','Admin','Admin','Admin@123','Admin@admin.com','555-1234','$2a$11$FibiB97CgeEkP7wxdL5vnO8RG5K4yBpxh2oPJjJiu4NcAZ2zT0PBO',0);
/*!40000 ALTER TABLE `applicationuser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `booking`
--

DROP TABLE IF EXISTS `booking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `booking` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `InmateId` int NOT NULL,
  `BookingLocation` varchar(255) NOT NULL,
  `FacilityName` varchar(255) NOT NULL,
  `BookedDate` datetime NOT NULL,
  `releaseddate` datetime DEFAULT NULL,
  `Charges` text,
  `ReleasedInformation` text,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT '0',
  `InsertedBy` int NOT NULL,
  `InsertedOn` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedOn` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `booking`
--

LOCK TABLES `booking` WRITE;
/*!40000 ALTER TABLE `booking` DISABLE KEYS */;
INSERT INTO `booking` VALUES (1,1,'Side Prison','Central Detention Facility','2024-12-01 00:00:00','2024-12-17 00:00:00','Assault, Theft','Released on bail',0,2,'2024-12-01 10:38:54',3,'2024-12-02 17:15:18'),(2,2,'Thankot, Kathmandu','Balambu Police Station','2024-12-01 00:00:00','2024-12-18 00:00:00','Speeding bike','Released by parent',0,2,'2024-12-02 12:17:45',2,'2024-12-02 13:04:20'),(3,1,'Kalanki','Kalamiti PD','2024-12-01 00:00:00','2024-12-04 00:00:00','Over Speeding','',0,2,'2024-12-02 16:51:29',NULL,NULL);
/*!40000 ALTER TABLE `booking` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inmates`
--

DROP TABLE IF EXISTS `inmates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inmates` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(255) NOT NULL,
  `MiddleName` varchar(255) DEFAULT NULL,
  `LastName` varchar(255) NOT NULL,
  `DOB` datetime NOT NULL,
  `CitizenshipNumber` varchar(255) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT '0',
  `InsertedBy` int NOT NULL,
  `InsertedOn` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedOn` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inmates`
--

LOCK TABLES `inmates` WRITE;
/*!40000 ALTER TABLE `inmates` DISABLE KEYS */;
INSERT INTO `inmates` VALUES (1,'Ram','','Krishhna','1999-12-18 00:00:00','1234567891',0,2,'2024-12-01 00:04:59',2,'2024-12-02 10:28:52'),(2,'Shyam',NULL,'Bahadur','2002-01-06 00:00:00','1234345752',0,2,'2024-12-01 09:35:14',2,'2024-12-02 08:25:43'),(3,'John','','Doe','1989-06-17 00:00:00','214-54221-6842',0,2,'2024-12-02 09:45:24',NULL,NULL),(4,'Hari','','Sharma','1997-06-18 00:00:00','1234567890',0,2,'2024-12-02 10:27:15',2,'2024-12-02 10:28:35');
/*!40000 ALTER TABLE `inmates` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'policedepartmentmis'
--
/*!50003 DROP PROCEDURE IF EXISTS `SpDeleteBooking` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpDeleteBooking`(
    IN p_Id INT,         -- Booking ID to delete
    IN p_UpdatedBy INT,  -- User ID who is updating the record
    OUT p_Message VARCHAR(255)  -- Message to return success or failure
)
BEGIN
    -- Update the booking status to soft delete (IsDeleted = 1)
    UPDATE `Booking`
    SET 
        `IsDeleted` = 1,
        `UpdatedBy` = p_UpdatedBy,
        `UpdatedOn` = NOW()
    WHERE `Id` = p_Id AND `IsDeleted` = 0;

    -- Check if any rows were affected (booking found and marked as deleted)
    IF ROW_COUNT() > 0 THEN
        SET p_Message = 'Booking successfully deleted';
    ELSE
        SET p_Message = 'Booking not found or already deleted';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpDeleteInmate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpDeleteInmate`(
    IN p_Id INT,         -- Inmate ID to delete
    IN p_UpdatedBy INT,   -- ID of the user updating the record
    OUT p_Message VARCHAR(250)
)
BEGIN
    -- Update IsDeleted to 1 (soft delete) and set UpdatedBy and UpdatedDate
    UPDATE `Inmates`
    SET 
        `IsDeleted` = 1,
        `UpdatedBy` = p_UpdatedBy,
        `UpdatedOn` = NOW()
    WHERE `Id` = p_Id;

    -- Check if any rows were affected
    IF ROW_COUNT() > 0 THEN
        SET p_Message = 'Inmate successfully deleted';
    ELSE
        SET p_Message = 'Inmate not found or delete failed';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpGetApplicationUserById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpGetApplicationUserById`(
    IN p_Id INT,
    OUT p_Message VARCHAR(255)
)
BEGIN
    -- Create a temporary table to hold the user data
    CREATE TEMPORARY TABLE IF NOT EXISTS temp_user_data (
        `Id` INT,
        `FirstName` VARCHAR(255),
        `MiddleName` VARCHAR(255),
        `LastName` VARCHAR(255),
        `UserName` VARCHAR(255),
        `Email` VARCHAR(255),
        `Phone` VARCHAR(20)
    );

    -- Insert the user data into the temporary table, excluding soft-deleted users
    INSERT INTO temp_user_data
    SELECT 
        `Id`,
        `FirstName`,
        `MiddleName`,
        `LastName`,
        `UserName`,
        `Email`,
        `Phone`
    FROM `applicationuser`
    WHERE `Id` = p_Id AND `IsDeleted` = 0;

    -- Check if data was inserted into the temporary table
    IF (SELECT COUNT(*) FROM temp_user_data) > 0 THEN
        SET p_Message = 'User found successfully';
    ELSE
        SET p_Message = 'No such user found or user is deleted';
    END IF;

    -- Select the data from the temporary table
    SELECT * FROM temp_user_data;

    -- Drop the temporary table after usage (optional, but good practice)
    DROP TEMPORARY TABLE IF EXISTS temp_user_data;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpGetBookingByEmployeeId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpGetBookingByEmployeeId`(
    IN p_EmployeeId INT,             
    OUT p_TotalRecords INT
)
BEGIN
    -- Declare a variable to hold the SQL query dynamically
    SET @sql = CONCAT('CREATE TEMPORARY TABLE IF NOT EXISTS temp_booking_data (
        `Id` INT,
        `InmateId` INT,
        `InmateName` VARCHAR(255),
        `BookingLocation` VARCHAR(255),
        `FacilityName` VARCHAR(255),
        `BookedDate` DATETIME,
        `ReleasedDate` DATETIME,
        `Charges` VARCHAR(255),
        `ReleasedInformation` VARCHAR(255),
        `IsDeleted` TINYINT(1)
    )');

    -- Execute the dynamic SQL to create the temporary table
    PREPARE stmt_create FROM @sql;
    EXECUTE stmt_create;
    DEALLOCATE PREPARE stmt_create;

    -- Start building the dynamic SQL for data insertion
    SET @sql = CONCAT('INSERT INTO temp_booking_data
    SELECT b.`Id`, b.`InmateId`, CONCAT(i.`FirstName`, " ", IFNULL(i.`MiddleName`, ""), " ", i.`LastName`) AS `InmateName`, 
           b.`BookingLocation`, b.`FacilityName`, b.`BookedDate`, b.`ReleasedDate`, b.`Charges`, 
           b.`ReleasedInformation`, b.`IsDeleted`
    FROM `Booking` AS b
    LEFT JOIN `Inmates` AS i 
    ON b.InmateId = i.Id
    WHERE b.`IsDeleted` = 0 ');
	SET @sql = CONCAT(@sql, ' AND b.`InmateId` = ',p_EmployeeId);
    
    PREPARE stmt_insert FROM @sql;
    EXECUTE stmt_insert;
    DEALLOCATE PREPARE stmt_insert;

    -- Now, perform the pagination and ordering
    SET @sql = CONCAT('SELECT SQL_CALC_FOUND_ROWS * FROM temp_booking_data');

    -- Prepare and execute the dynamic SQL to fetch the paginated data
    PREPARE stmt_select FROM @sql;
    EXECUTE stmt_select;
    DEALLOCATE PREPARE stmt_select;

    -- Get the total number of records that match the filter (ignoring pagination)
    SELECT FOUND_ROWS() INTO p_TotalRecords;

    -- Clean up the temporary table
    SET @sql = 'DROP TEMPORARY TABLE IF EXISTS temp_booking_data';
    PREPARE stmt_drop FROM @sql;
    EXECUTE stmt_drop;
    DEALLOCATE PREPARE stmt_drop;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpGetBookingById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpGetBookingById`(
    IN p_Id INT,                 -- Booking ID to fetch
    OUT p_Message VARCHAR(255)   -- Output message
)
BEGIN
    -- Create a temporary table to hold the booking data
    CREATE TEMPORARY TABLE IF NOT EXISTS temp_booking_data (
        `Id` INT,
        `InmateId` INT,
        `InmateName` VARCHAR(255),
        `BookingLocation` VARCHAR(255),
        `FacilityName` VARCHAR(255),
        `BookedDate` DATE,
        `ReleasedDate` DATE,
        `Charges` VARCHAR(255),
        `ReleasedInformation` VARCHAR(255)
    );

    -- Insert the booking data into the temporary table, excluding soft-deleted bookings
    INSERT INTO temp_booking_data
    SELECT 
        b.`Id`,
		b.`InmateId`,
		CONCAT(i.`FirstName`, ' ', IFNULL(i.`MiddleName`, ''), ' ', i.`LastName`) AS `InmateName`,  -- Concatenate FirstName, MiddleName, and LastName
		b.`BookingLocation`,
		b.`FacilityName`,
		b.`BookedDate`,
		b.`ReleasedDate`,
		b.`Charges`,
		b.`ReleasedInformation`
    FROM `Booking` as b
    LEFT JOIN `Inmates` as i
    ON b.InmateId = i.Id
    WHERE b.`Id` = p_Id AND b.`IsDeleted` = 0;  -- Ensure the booking is not soft-deleted

    -- Check if data was inserted into the temporary table
    IF (SELECT COUNT(*) FROM temp_booking_data) > 0 THEN
        SET p_Message = 'Booking found successfully';
    ELSE
        SET p_Message = 'No such booking found or booking is deleted';
    END IF;

    -- Select the data from the temporary table
    SELECT * FROM temp_booking_data;

    -- Drop the temporary table after usage (optional, but good practice)
    DROP TEMPORARY TABLE IF EXISTS temp_booking_data;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpGetFilteredApplicationUsers` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpGetFilteredApplicationUsers`(
    IN p_SearchByColumn VARCHAR(255),  -- Column to search by (e.g., 'FirstName', 'LastName', etc.)
    IN p_SearchValue VARCHAR(255),     -- The value to search for
    IN p_OrderByColumn VARCHAR(255),   -- Column to order by (e.g., 'FirstName', 'LastName', etc.)
    IN p_OrderBy VARCHAR(4),           -- 'ASC' or 'DESC'
    IN p_PageSize INT,                 -- Number of records per page
    IN p_PageNumber INT,               -- Page number (1-based)
    OUT p_TotalRecords INT             -- Total number of records that match the filter
)
BEGIN
    -- Declare a variable to hold the SQL query dynamically
    SET @sql = CONCAT('CREATE TEMPORARY TABLE IF NOT EXISTS temp_user_data (
        `Id` INT,
        `FirstName` VARCHAR(255),
        `MiddleName` VARCHAR(255),
        `LastName` VARCHAR(255),
        `UserName` VARCHAR(255),
        `Email` VARCHAR(255),
        `Phone` VARCHAR(20),
        `Password` VARCHAR(255),
        `IsDeleted` TINYINT(1)
    )');

    -- Execute the dynamic SQL to create the temporary table
    PREPARE stmt_create FROM @sql;
    EXECUTE stmt_create;
    DEALLOCATE PREPARE stmt_create;

    -- Insert the filtered data into the temporary table (soft delete filter applied)
    SET @sql = CONCAT('INSERT INTO temp_user_data
    SELECT `Id`, `FirstName`, `MiddleName`, `LastName`, `UserName`, `Email`, `Phone`, `Password`, `IsDeleted`
    FROM `applicationuser`
    WHERE `IsDeleted` = 0');

    -- Apply additional filtering by search column and search value if provided
    IF p_SearchByColumn IS NOT NULL AND p_SearchValue IS NOT NULL THEN
        SET @sql = CONCAT(@sql, ' AND ', p_SearchByColumn, ' LIKE "%', p_SearchValue, '%"');
    END IF;

    -- Execute the dynamic SQL to insert data into the temporary table
    PREPARE stmt_insert FROM @sql;
    EXECUTE stmt_insert;
    DEALLOCATE PREPARE stmt_insert;

    -- Now, perform the pagination and ordering
    SET @sql = CONCAT('SELECT SQL_CALC_FOUND_ROWS * FROM temp_user_data');

    -- Apply ordering if needed
    IF p_OrderByColumn IS NOT NULL AND p_OrderBy IN ('ASC', 'DESC') THEN
        SET @sql = CONCAT(@sql, ' ORDER BY ', p_OrderByColumn, ' ', p_OrderBy);
    ELSE
        -- Default ordering by Id in ascending order
        SET @sql = CONCAT(@sql, ' ORDER BY `Id` ASC');
    END IF;

    -- Apply pagination using LIMIT and OFFSET
    SET @offset = (p_PageNumber - 1) * p_PageSize;
    SET @sql = CONCAT(@sql, ' LIMIT ', p_PageSize, ' OFFSET ', @offset);

    -- Prepare and execute the dynamic SQL to fetch the paginated data
    PREPARE stmt_select FROM @sql;
    EXECUTE stmt_select;
    DEALLOCATE PREPARE stmt_select;

    -- Get the total number of records that match the filter (ignoring pagination)
    SELECT FOUND_ROWS() INTO p_TotalRecords;

    -- Clean up the temporary table
    SET @sql = 'DROP TEMPORARY TABLE IF EXISTS temp_user_data';
    PREPARE stmt_drop FROM @sql;
    EXECUTE stmt_drop;
    DEALLOCATE PREPARE stmt_drop;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpGetFilteredBookings` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpGetFilteredBookings`(
    IN p_SearchByColumn VARCHAR(255),    -- Column to search by (e.g., 'BookingLocation', 'Charges', etc.)
    IN p_SearchValue VARCHAR(255),       -- The value to search for
    IN p_OrderByColumn VARCHAR(255),     -- Column to order by (e.g., 'BookingLocation', 'FacilityName', etc.)
    IN p_OrderBy VARCHAR(4),             -- 'ASC' or 'DESC'
    IN p_PageSize INT,                   -- Number of records per page
    IN p_PageNumber INT,                 -- Page number (1-based)
    OUT p_TotalRecords INT               -- Total number of records that match the filter
)
BEGIN
    -- Declare a variable to hold the SQL query dynamically
    SET @sql = CONCAT('CREATE TEMPORARY TABLE IF NOT EXISTS temp_booking_data (
        `Id` INT,
        `InmateId` INT,
        `InmateName` VARCHAR(255),
        `BookingLocation` VARCHAR(255),
        `FacilityName` VARCHAR(255),
        `BookedDate` DATETIME,
        `ReleasedDate` DATETIME,
        `Charges` VARCHAR(255),
        `ReleasedInformation` VARCHAR(255),
        `IsDeleted` TINYINT(1)
    )');

    -- Execute the dynamic SQL to create the temporary table
    PREPARE stmt_create FROM @sql;
    EXECUTE stmt_create;
    DEALLOCATE PREPARE stmt_create;

    -- Start building the dynamic SQL for data insertion
    SET @sql = CONCAT('INSERT INTO temp_booking_data
    SELECT b.`Id`, b.`InmateId`, CONCAT(i.`FirstName`, " ", IFNULL(i.`MiddleName`, ""), " ", i.`LastName`) AS `InmateName`, 
           b.`BookingLocation`, b.`FacilityName`, b.`BookedDate`, b.`ReleasedDate`, b.`Charges`, 
           b.`ReleasedInformation`, b.`IsDeleted`
    FROM `Booking` AS b
    LEFT JOIN `Inmates` AS i 
    ON b.InmateId = i.Id
    WHERE b.`IsDeleted` = 0');

    -- Apply additional filtering by search column and search value if provided
    IF p_SearchByColumn IS NOT NULL AND p_SearchValue IS NOT NULL AND p_SearchValue != '' THEN
        SET @sql = CONCAT(@sql, ' AND b.', p_SearchByColumn, ' LIKE "%', p_SearchValue, '%"');
    END IF;

    -- Execute the dynamic SQL to insert data into the temporary table
    PREPARE stmt_insert FROM @sql;
    EXECUTE stmt_insert;
    DEALLOCATE PREPARE stmt_insert;

    -- Now, perform the pagination and ordering
    SET @sql = CONCAT('SELECT SQL_CALC_FOUND_ROWS * FROM temp_booking_data');

    -- Apply ordering if needed
    IF p_OrderByColumn IS NOT NULL AND p_OrderBy IN ('ASC', 'DESC') THEN
        SET @sql = CONCAT(@sql, ' ORDER BY ', p_OrderByColumn, ' ', p_OrderBy);
    ELSE
        -- Default ordering by Id in ascending order
        SET @sql = CONCAT(@sql, ' ORDER BY b.`Id` ASC');
    END IF;

    -- Apply pagination using LIMIT and OFFSET
    SET @offset = (p_PageNumber - 1) * p_PageSize;
    SET @sql = CONCAT(@sql, ' LIMIT ', p_PageSize, ' OFFSET ', @offset);

    -- Prepare and execute the dynamic SQL to fetch the paginated data
    PREPARE stmt_select FROM @sql;
    EXECUTE stmt_select;
    DEALLOCATE PREPARE stmt_select;

    -- Get the total number of records that match the filter (ignoring pagination)
    SELECT FOUND_ROWS() INTO p_TotalRecords;

    -- Clean up the temporary table
    SET @sql = 'DROP TEMPORARY TABLE IF EXISTS temp_booking_data';
    PREPARE stmt_drop FROM @sql;
    EXECUTE stmt_drop;
    DEALLOCATE PREPARE stmt_drop;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpGetFilteredInmates` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpGetFilteredInmates`(
    IN p_SearchByColumn VARCHAR(255),    -- Column to search by (e.g., 'FirstName', 'LastName', etc.)
    IN p_SearchValue VARCHAR(255),       -- The value to search for
    IN p_OrderByColumn VARCHAR(255),     -- Column to order by (e.g., 'FirstName', 'LastName', etc.)
    IN p_OrderBy VARCHAR(4),             -- 'ASC' or 'DESC'
    IN p_PageSize INT,                   -- Number of records per page
    IN p_PageNumber INT,                 -- Page number (1-based)
    OUT p_TotalRecords INT               -- Total number of records that match the filter
)
BEGIN
    -- Declare a variable to hold the SQL query dynamically
    SET @sql = CONCAT('CREATE TEMPORARY TABLE IF NOT EXISTS temp_inmate_data (
        `Id` INT,
        `InmateName` VARCHAR(255),
        `DOB` DATE,
        `CitizenshipNumber` VARCHAR(255),
        `IsDeleted` TINYINT(1)
    )');

    -- Execute the dynamic SQL to create the temporary table
    PREPARE stmt_create FROM @sql;
    EXECUTE stmt_create;
    DEALLOCATE PREPARE stmt_create;

    -- Start building the dynamic SQL for data insertion
    SET @sql = CONCAT('INSERT INTO temp_inmate_data
    SELECT `Id`, CONCAT(i.`FirstName`, " ", IFNULL(i.`MiddleName`, ""), " ", i.`LastName`) AS `InmateName`, `DOB`, `CitizenshipNumber`, `IsDeleted`
    FROM `Inmates` as i
    WHERE `IsDeleted` = 0');

    -- Apply additional filtering by search column and search value if provided
    IF p_SearchByColumn IS NOT NULL AND p_SearchValue IS NOT NULL AND p_SearchValue != '' THEN
        SET @sql = CONCAT(@sql, ' AND ', p_SearchByColumn, ' LIKE "%', p_SearchValue, '%"');
    END IF;

    -- Execute the dynamic SQL to insert data into the temporary table
    PREPARE stmt_insert FROM @sql;
    EXECUTE stmt_insert;
    DEALLOCATE PREPARE stmt_insert;

    -- Now, perform the pagination and ordering
    SET @sql = CONCAT('SELECT SQL_CALC_FOUND_ROWS * FROM temp_inmate_data');

    -- Apply ordering if needed
    IF p_OrderByColumn IS NOT NULL AND p_OrderBy IN ('ASC', 'DESC') THEN
        SET @sql = CONCAT(@sql, ' ORDER BY ', p_OrderByColumn, ' ', p_OrderBy);
    ELSE
        -- Default ordering by Id in ascending order
        SET @sql = CONCAT(@sql, ' ORDER BY `Id` ASC');
    END IF;

    -- Apply pagination using LIMIT and OFFSET
    SET @offset = (p_PageNumber - 1) * p_PageSize;
    SET @sql = CONCAT(@sql, ' LIMIT ', p_PageSize, ' OFFSET ', @offset);

    -- Prepare and execute the dynamic SQL to fetch the paginated data
    PREPARE stmt_select FROM @sql;
    EXECUTE stmt_select;
    DEALLOCATE PREPARE stmt_select;

    -- Get the total number of records that match the filter (ignoring pagination)
    SELECT FOUND_ROWS() INTO p_TotalRecords;

    -- Clean up the temporary table
    SET @sql = 'DROP TEMPORARY TABLE IF EXISTS temp_inmate_data';
    PREPARE stmt_drop FROM @sql;
    EXECUTE stmt_drop;
    DEALLOCATE PREPARE stmt_drop;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpGetInmateById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpGetInmateById`(
    IN p_Id INT,                 -- Inmate ID to fetch
    OUT p_Message VARCHAR(255)   -- Output message
)
BEGIN
    -- Create a temporary table to hold the inmate data
    CREATE TEMPORARY TABLE IF NOT EXISTS temp_inmate_data (
        `Id` INT,
        `FirstName` VARCHAR(255),
        `MiddleName` VARCHAR(255),
        `LastName` VARCHAR(255),
        `DOB` DATE,
        `CitizenshipNumber` VARCHAR(255)
    );

    -- Insert the inmate data into the temporary table, excluding soft-deleted inmates
    INSERT INTO temp_inmate_data
    SELECT 
        `Id`,
        `FirstName`,
        `MiddleName`,
        `LastName`,
        `DOB`,
        `CitizenshipNumber`
    FROM `Inmates`
    WHERE `Id` = p_Id AND `IsDeleted` = 0;  -- Ensure the inmate is not soft-deleted

    -- Check if data was inserted into the temporary table
    IF (SELECT COUNT(*) FROM temp_inmate_data) > 0 THEN
        SET p_Message = 'Inmate found successfully';
    ELSE
        SET p_Message = 'No such inmate found or inmate is deleted';
    END IF;

    -- Select the data from the temporary table
    SELECT * FROM temp_inmate_data;

    -- Drop the temporary table after usage (optional, but good practice)
    DROP TEMPORARY TABLE IF EXISTS temp_inmate_data;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpInsertApplicationUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpInsertApplicationUser`(
    IN p_FirstName VARCHAR(255),
    IN p_MiddleName VARCHAR(255),
    IN p_LastName VARCHAR(255),
    IN p_UserName VARCHAR(255),
    IN p_Email VARCHAR(255),
    IN p_Phone VARCHAR(20),
    IN p_Password VARCHAR(255),
    OUT p_NewId INT
)
BEGIN
	INSERT INTO `applicationuser` (
        `FirstName`, 
        `MiddleName`, 
        `LastName`, 
        `UserName`, 
        `Email`, 
        `Phone`, 
        `Password`, 
        `IsDeleted`
    )
    VALUE(
        p_FirstName, 
        p_MiddleName, 
        p_LastName, 
        p_UserName, 
        p_Email, 
        p_Phone, 
        p_Password, 
        0
    );

    -- Set the output parameter to the newly generated Id
    SET p_NewId = LAST_INSERT_ID();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpInsertBooking` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpInsertBooking`(
    IN p_InmateId INT,
    IN p_BookingLocation VARCHAR(255),
    IN p_FacilityName VARCHAR(255),
    IN p_BookedDate DATETIME,
    IN p_ReleasedDate DATETIME,
    IN p_Charges VARCHAR(255),
    IN p_ReleasedInformation VARCHAR(255),
    IN p_CreatedBy INT,
    OUT p_BookingId INT,
    OUT p_Message VARCHAR(255)  -- Message output parameter
)
BEGIN
    -- Check if a booking for the same inmate on the same booked date already exists
    IF EXISTS (SELECT 1 FROM `Booking` 
               WHERE `InmateId` = p_InmateId 
                 AND `BookedDate` = p_BookedDate 
                 AND `IsDeleted` = 0) THEN
        SET p_Message = 'A booking for this inmate on the same date already exists';
        SET p_BookingId = 0;  -- Set BookingId to 0 when the record exists
    ELSE
        -- Insert the new booking record
        INSERT INTO `Booking` (InmateId, BookingLocation, FacilityName, BookedDate, ReleasedDate, Charges, ReleasedInformation, InsertedBy, InsertedOn, IsDeleted)
        VALUES (p_InmateId, p_BookingLocation, p_FacilityName, p_BookedDate, p_ReleasedDate, p_Charges, p_ReleasedInformation, p_CreatedBy, NOW(), 0);

        -- Set the output parameters
        SET p_BookingId = LAST_INSERT_ID();  -- Get the newly inserted BookingId
        SET p_Message = 'Booking successfully inserted';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpInsertInmate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpInsertInmate`(
    IN p_FirstName VARCHAR(255),
    IN p_MiddleName VARCHAR(255),
    IN p_LastName VARCHAR(255),
    IN p_DOB DATE,
    IN p_CitizenshipNumber VARCHAR(255),
    IN p_CreatedBy INT,
    OUT p_InmateId INT,
    OUT p_Message VARCHAR(255)  -- Message output parameter
)
BEGIN
    -- Check if an inmate with the same CitizenshipNumber exists
    IF EXISTS (SELECT 1 FROM `Inmates` WHERE `CitizenshipNumber` = p_CitizenshipNumber AND `IsDeleted` = 0) THEN
        SET p_Message = 'Inmate with the same Citizenship Number already exists';
        SET p_InmateId = 0;  -- Set InmateId to 0 when the record exists
    ELSE
        -- Insert the new inmate record
        INSERT INTO `Inmates` (FirstName, MiddleName, LastName, DOB, CitizenshipNumber, InsertedBy, InsertedOn, IsDeleted)
        VALUES (p_FirstName, p_MiddleName, p_LastName, p_DOB, p_CitizenshipNumber, p_CreatedBy, NOW(), 0);

        -- Set the output parameters
        SET p_InmateId = LAST_INSERT_ID();
        SET p_Message = 'Inmate successfully inserted';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpSoftDeleteApplicationUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpSoftDeleteApplicationUser`(
    IN p_Id INT,
    OUT p_Message VARCHAR(255)
)
BEGIN
    -- Perform soft delete by setting IsDeleted to 1
    UPDATE `applicationuser`
    SET `IsDeleted` = 1
    WHERE `Id` = p_Id AND `IsDeleted` = 0;  -- Only update if not already marked as deleted

    -- Check if any rows were affected
    IF ROW_COUNT() > 0 THEN
        SET p_Message = 'User deleted successfully';
    ELSE
        SET p_Message = 'No such user found or user already deleted';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpUpdateApplicationUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpUpdateApplicationUser`(
    IN p_Id INT,
    IN p_FirstName VARCHAR(255),
    IN p_MiddleName VARCHAR(255),
    IN p_LastName VARCHAR(255),
    IN p_UserName VARCHAR(255),
    IN p_Email VARCHAR(255),
    IN p_Phone VARCHAR(20),
    IN p_Password VARCHAR(255),
    OUT p_Message VARCHAR(255)
)
BEGIN
    -- Update the user details based on the provided Id
    UPDATE `applicationuser`
    SET
        `FirstName` = p_FirstName,
        `MiddleName` = p_MiddleName,
        `LastName` = p_LastName,
        `UserName` = p_UserName,
        `Email` = p_Email,
        `Phone` = p_Phone,
        `Password` = p_Password
    WHERE `Id` = p_Id;

    -- Check if any rows were affected
    IF ROW_COUNT() > 0 THEN
        SET p_Message = 'User updated successfully';
    ELSE
        SET p_Message = 'No such user found or update failed';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpUpdateBooking` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpUpdateBooking`(
    IN p_Id INT,                     -- Booking ID to update
    IN p_InmateId INT,               -- Inmate ID associated with the booking
    IN p_BookingLocation VARCHAR(255),
    IN p_FacilityName VARCHAR(255),
    IN p_BookedDate DATE,
    IN p_ReleasedDate DATE,
    IN p_Charges VARCHAR(255),
    IN p_ReleasedInformation VARCHAR(255),
    IN p_UpdatedBy INT,              -- User who is updating the booking
    OUT p_Message VARCHAR(255),      -- Output message
    OUT p_Success BIT               -- Output success flag
)
BEGIN
    -- Check if the booking exists
    IF EXISTS (SELECT 1 FROM `Booking` 
               WHERE `Id` = p_Id AND `IsDeleted` = 0) THEN
        -- Update the booking details
        UPDATE `Booking`
        SET 
            `InmateId` = p_InmateId,
            `BookingLocation` = p_BookingLocation,
            `FacilityName` = p_FacilityName,
            `BookedDate` = p_BookedDate,
            `ReleasedDate` = p_ReleasedDate,
            `Charges` = p_Charges,
            `ReleasedInformation` = p_ReleasedInformation,
            `UpdatedBy` = p_UpdatedBy,
            `UpdatedOn` = NOW()
        WHERE `Id` = p_Id AND `IsDeleted` = 0;

        -- Set success flag and message
        SET p_Success = 1;
        SET p_Message = 'Booking updated successfully.';
    ELSE
        -- Booking not found or already deleted
        SET p_Success = 0;
        SET p_Message = 'Booking not found or already deleted.';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpUpdateInmate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpUpdateInmate`(
    IN p_Id INT,                     -- Inmate ID to update
    IN p_FirstName VARCHAR(255),
    IN p_MiddleName VARCHAR(255),
    IN p_LastName VARCHAR(255),
    IN p_DOB DATE,
    IN p_CitizenshipNumber VARCHAR(255),
    IN p_UpdatedBy INT,
    OUT p_Message VARCHAR(255),      -- Output message
    OUT p_Success BIT           -- Output success flag
)
BEGIN
    -- Check if the CitizenshipNumber already exists for another inmate
    IF EXISTS (SELECT 1 FROM `Inmates` 
               WHERE `CitizenshipNumber` = p_CitizenshipNumber 
                 AND `Id` != p_Id
                 AND `IsDeleted` = 0) THEN
        -- Set failure flag and message if CitizenshipNumber exists for another inmate
        SET p_Success = 0;
        SET p_Message = 'Inmate with this Citizenship Number already exists.';
    
	ELSE
    -- Check if the inmate exists
		IF EXISTS (SELECT 1 FROM `Inmates` WHERE `Id` = p_Id AND `IsDeleted` = 0) THEN
			-- Update inmate details
			UPDATE `Inmates`
			SET 
				`FirstName` = p_FirstName,
				`MiddleName` = p_MiddleName,
				`LastName` = p_LastName,
				`DOB` = p_DOB,
				`CitizenshipNumber` = p_CitizenshipNumber,
				`UpdatedBy` = p_UpdatedBy,
				`UpdatedOn` = NOW()
			WHERE `Id` = p_Id;

			-- Set success flag and message
			SET p_Success = 1;
			SET p_Message = 'Inmate updated successfully.';
		ELSE
			-- Inmate not found or already deleted
			SET p_Success = 0;
			SET p_Message = 'Inmate not found or already deleted.';
		END IF;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpValidateUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpValidateUser`(
    IN p_UserName VARCHAR(255),
    OUT p_Validated INT,
    OUT p_StoredPassword VARCHAR(255)
)
BEGIN
    DECLARE v_StoredPassword VARCHAR(255);
    DECLARE v_IsDeleted TINYINT(1);
    DECLARE v_ApplicationUserId INT;

    -- Initialize output variables
    SET p_Validated = 0;
	SET p_StoredPassword = '';
    
    -- Check if user exists by UserName (email/phone/username) and fetch password and IsDeleted status
    SELECT `Password`, `IsDeleted`, `Id`
    INTO v_StoredPassword, v_IsDeleted, v_ApplicationUserId
    FROM `applicationuser`
    WHERE `Email` = p_UserName
       OR `Phone` = p_UserName
       OR `UserName` = p_UserName
    LIMIT 1;
    -- If user exists, validate password
    IF v_StoredPassword IS NOT NULL THEN
        -- Check if user is deleted (soft delete logic)
        IF v_IsDeleted = 1 THEN
            SET p_Validated = 0;
        ELSE
				SET p_Validated = v_ApplicationUserId;
                SET p_StoredPassword = v_StoredPassword;
        END IF;
    ELSE
        SET p_Validated = 0;
    END IF;

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

-- Dump completed on 2024-12-02 18:01:58
