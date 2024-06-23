-- Date of script 20/06/2024 Thursday 00:00:00--

-- Script date 22-06-2024 19:15 -- 

--Customers Table --
CREATE TABLE Customers(
	customer_id INT NOT NULL IDENTITY PRIMARY KEY,
	firstName VARCHAR(20),
	lastName VARCHAR(20) NOT NULL,
	email VARCHAR(35) NOT NULL,
	phoneNumber VARCHAR(10),
	passcode VARCHAR(10) NOT NULL
);

