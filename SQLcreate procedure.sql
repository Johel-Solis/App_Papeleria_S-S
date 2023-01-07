 CREATE PROCEDURE InsertUser 
	-- Add the parameters for the stored procedure here
	@username varchar(50), 
	@password varchar(255),
	@typeUser nchar(10),
	@id int,
	@state int
AS
BEGIN

INSERT INTO users (username,password,typeUser,Id,state) VALUES (@username,@password,@typeUser,@Id, @state );
	
END;

CREATE PROCEDURE InsertPerson
	-- Add the parameters for the stored procedure here
	@name varchar(100), 
	@surname varchar(255), 
	@email varchar(100), 
	@id int,
	@phoneNumber int,
	@birthdate varchar(50) 
AS
BEGIN

INSERT INTO persons (Id,name,surname,email,phoneNumber,birthdate) VALUES (@id,@name,@surname,@email,@phoneNumber,@birthdate);
	
END;

CREATE PROCEDURE InsertCustomer
	-- Add the parameters for the stored procedure here
	@name varchar(100), 
	@email varchar(100), 
	@nit int,
	@phoneNumber int,
	@state int
	
AS
BEGIN

INSERT INTO customers (nit,name,email,phoneNumber,state) VALUES (@nit,@name,@email,@phoneNumber,@state);
	
END;

CREATE PROCEDURE InsertProvider
	-- Add the parameters for the stored procedure here
	@name varchar(100), 
	@email varchar(100), 
	@nit int,
	@phoneNumber int,
	@bank varchar(100),
	@accountNumber int,
	@state  int

	
AS
BEGIN

INSERT INTO providers (nit,name,email,phoneNumber,bank,accountNumber,state) VALUES (@nit,@name,@email,@phoneNumber,@bank,@accountNumber,@state);
	
END;


CREATE PROCEDURE InsertCategory
	-- Add the parameters for the stored procedure here
	@name varchar(50), 
	@descripcion varchar(100),
	@id int,
	@state int
AS
BEGIN

INSERT INTO categories(Id,name,description,state) VALUES (@id,@name,@descripcion,@state);

	
END;

CREATE PROCEDURE InsertProduct
	-- Add the parameters for the stored procedure here
	@reference int,
	@name varchar(100), 
	@description varchar(250),
	@brand varchar(50),
	@category_id int,
	@stock int,
	@purchase_price float,
	@sale_price float,
	@provider_id int,
	@state int
AS
BEGIN

INSERT INTO products (reference,name,description,category_id,stock,brand,purchase_price,sale_price,state,provider_id) VALUES (@reference,@name,@description,@category_id,@stock,@brand,@purchase_price,@sale_price,@state,@provider_id );
	
END;

CREATE PROCEDURE InsertSaleDetail
	-- Add the parameters for the stored procedure here
	@id int,
	@product_id int,
	@quantity int,
	@unit_price float,
	@total_price float,
	@state int, 
	@bill_id int
	
AS
BEGIN

INSERT INTO saleDetails(id,product_id,quantity,unit_price,total_price,bill_id,state) VALUES (@id,@product_id,@quantity,@unit_price,@total_price,@bill_id,@state);
	
END;

CREATE PROCEDURE InsertBill
	-- Add the parameters for the stored procedure here
	@id int,
	@seller_id int,
	@customer_id int,
	@total float,
	@date_bill varchar(50),
	@state int
AS
BEGIN

INSERT INTO bills (Id,seller_id,customer_id,total,date_bill,state) VALUES (@id,@seller_id,@customer_id,@total,@date_bill,@state);
	
END;
