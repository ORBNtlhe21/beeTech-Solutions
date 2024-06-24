CREATE TABLE Products(
	products_id INT IDENTITY PRIMARY KEY,
	productName VARCHAR(30),
	productDescr VARCHAR(50),
	laptop_id INT FOREIGN KEY REFERENCES Laptops(laptop_id),
	desktop_id INT FOREIGN KEY REFERENCES Desktops(desktop_id),
	gamingChair_id INT FOREIGN KEY REFERENCES Gaming_Chairs(gamingChair_id),
	gamingConsole_id INT FOREIGN KEY REFERENCES  Gaming_Console(gamingConsole_id)
);

CREATE TABLE Orders(
	order_id INT IDENTITY PRIMARY KEY,
	total DECIMAL(10,2),
	customer_id INT FOREIGN KEY REFERENCES Customers(customer_id),
	products_id INT FOREIGN KEY REFERENCES Products(products_id)
); 
