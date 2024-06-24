
--CREATE TABLE Desktops(
--	desktop_id INT IDENTITY PRIMARY KEY,
--	desktopBrand VARCHAR(15),
--	price DECIMAL(10,2)
--);

--CREATE TABLE Gaming_Chairs(
--	gamingChair_id INT IDENTITY PRIMARY KEY,
--	gamingChairBrand VARCHAR(15),
--	price DECIMAL(10,2)
--);

--CREATE TABLE Gaming_Console(
--	gamingConsole_id INT IDENTITY PRIMARY KEY,
--	gamingConsoleBrand VARCHAR(15),
--	price DECIMAL(10,2),
--);

CREATE TABLE Products(
	products_id BIGINT IDENTITY(0001,1) primary key,
	productName VARCHAR(30),
	productDescr VARCHAR(50),
	laptop_id BIGINT FOREIGN KEY REFERENCES Laptops(laptop_id),
	television_id BIGINT FOREIGN KEY REFERENCES Televisions(television_id),
	desktop_id BIGINT FOREIGN KEY REFERENCES Desktops(desktop_id),
	gamingChair_id BIGINT FOREIGN KEY REFERENCES Gaming_Chairs(gamingChair_id),
	gamingConsole_id BIGINT FOREIGN KEY REFERENCES  Gaming_Console(gamingConsole_id)
);

CREATE TABLE Orders(
	order_id BIGINT IDENTITY(0001,1) PRIMARY KEY,
	total DECIMAL(10,2),
	customer_id BIGINT FOREIGN KEY REFERENCES Customers(customer_id),
	products_id BIGINT FOREIGN KEY REFERENCES Products(products_id)
); 

