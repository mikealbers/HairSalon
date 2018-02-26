# Hair Salon  

#### .NET MVC app that allows a user to make lists of Stylists and Clients.

## Description
_C# Week 3 project._

### _Hair Salon_

* _Allows user to add new stylists_
* _Allows user to add new clients_
* _Allows user to see a list of all stylists_

### Specifications

* _User can add new stylists_
  _input: firstname: Paul / lastname: Mitchell_  
  _output: new stylist with the name: "Paul Mitchell"_  

* _User can add new clients_
  _input: firstname: Fabio / lastname: Lanzoni_  
  _output: new client with the name: "Fabio Lanzoni"_  

* _User can see a list of all stylists_  
  * _input: click on Stylist list link_
  * _output: list of all stylists is displayed_



## Setup / Install

* _Clone this repository:_  
```
git clone https://github.com/mikealbers/HairSalon
```

* _Install .Net Framework and MAMP_
  _Instructions can be found at:_

  https://www.learnhowtoprogram.com/c/getting-started-with-c/installing-c


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

## Technologies Used

* HTML
* Bootstrap
* C#
* .NET Core
* Razor
* MAMP
* MySqlConnection

### License

*MIT License*

Copyright (c) 2018 **_Mike Albers_**

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
