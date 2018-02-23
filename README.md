/Applications/MAMP/Library/bin/mysql --host=localhost -uroot -proot

CREATE DATABASE salon;

USE salon;

CREATE TABLE `salon`.`clients` ( `id` INT NOT NULL AUTO_INCREMENT , `firstName` VARCHAR(255) NOT NULL , `lastName` VARCHAR(255) NOT NULL , `stylistID` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

CREATE TABLE `salon`.`stylists` ( `id` INT NOT NULL AUTO_INCREMENT , `firstName` VARCHAR NOT NULL , `lastName` VARCHAR NOT NULL , `clientID` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

CREATE DATABASE salon_test;

USE salon_test;

CREATE TABLE `salon_test`.`clients` ( `id` INT NOT NULL AUTO_INCREMENT , `firstName` VARCHAR(255) NOT NULL , `lastName` VARCHAR(255) NOT NULL , `stylistID` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

CREATE TABLE `salon_test`.`stylists` ( `id` INT NOT NULL AUTO_INCREMENT , `firstName` VARCHAR NOT NULL , `lastName` VARCHAR NOT NULL , `clientID` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;
