## Setup / Install

* _Clone this repository:_  
```
  git clone https://github.com/mikealbers/HairSalon
```

* _Install .Net Framework and MAMP_
  _Instructions can be found at:_
  ```
  https://www.learnhowtoprogram.com/c/getting-started-with-c/installing-c
  ```

* _Enter the following command into the command line to run mysql_
  ```
  /Applications/MAMP/Library/bin/mysql --host=localhost -uroot -proot
  ```

  _Enter the folowing commands into mysql to create databases_
  ```
  CREATE DATABASE mike_albers;

  USE mike_albers;

  CREATE TABLE `mike_albers`.`clients` ( `id` INT NOT NULL AUTO_INCREMENT , `firstName` VARCHAR(255) NOT NULL , `lastName` VARCHAR(255) NOT NULL , `stylistID` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

  CREATE TABLE `mike_albers`.`stylists` ( `id` INT NOT NULL AUTO_INCREMENT , `firstName` VARCHAR NOT NULL , `lastName` VARCHAR NOT NULL , `clientID` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

  CREATE DATABASE mike_albers_test;

  CREATE TABLE `mike_albers_test`.`clients` ( `id` INT NOT NULL AUTO_INCREMENT , `firstName` VARCHAR(255) NOT NULL , `lastName` VARCHAR(255) NOT NULL , `stylistID` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

  CREATE TABLE `mike_albers_test`.`stylists` ( `id` INT NOT NULL AUTO_INCREMENT , `firstName` VARCHAR NOT NULL , `lastName` VARCHAR NOT NULL , `clientID` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;
  ```

* _Open MAMP and start the mySql server by clicking the start server button_

* _Run the app by navigating to the HairSolon folder and entering the following commands:_
  ```
  dotnet restore
  dotnet run
  ```

* _After the program is running, in a browser navigate to localhost:5000/_
