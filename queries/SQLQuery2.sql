CREATE TABLE categories(
	id int IDENTITY  PRIMARY KEY,
	name VARCHAR(100) NOT NULL,
);

CREATE TABLE product(
	id int IDENTITY PRIMARY KEY,
	category_id int NOT NULL,
	name VARCHAR(100) NOT NULL,
	description VARCHAR (250) NOT NULL,
	price decimal (10,2) NOT NULL,
	stock int NOT NULL,
	image VARCHAR (250)
	FOREIGN KEY (category_id) REFERENCES categories(id)
);


