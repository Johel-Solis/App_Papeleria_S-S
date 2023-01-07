CREATE PROCEDURE UpdatetUser 
	-- Add the parameters for the stored procedure here
	@username varchar(50), 
	@password varchar(255),
	@typeUser nchar(10),
	@id int,
	@state int
AS
BEGIN

	UPDATE users SET username = @username , password =@password, typeUser = @typeUser, Id=@id , state =@state  WHERE username=@username;

END;

CREATE PROCEDURE UpdatePerson
	-- Add the parameters for the stored procedure here
	@name varchar(100), 
	@surname varchar(255), 
	@email varchar(100), 
	@id int,
	@phoneNumber int,
	@birthdate varchar(50) 
AS
BEGIN
UPDATE persons  SET Id = @Id ,name = @name , surname = @surname , email = @email , phoneNumber= @phoneNumber, birthdate =@birthdate  WHERE Id=@id;

	
END;

CREATE PROCEDURE UpdateCustomer
	-- Add the parameters for the stored procedure here
	@name varchar(100), 
	@email varchar(100), 
	@nit int,
	@phoneNumber int,
	@state int
	
AS
BEGIN
 UPDATE customers SET nit= @nit	, name=@name, phoneNumber=@phoneNumber, email=@email, state= @state WHERE nit=@nit;
END;

CREATE PROCEDURE UpdateProvider
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

Update  providers SET nit=@nit,name=@name,email=@email,phoneNumber=@phoneNumber,bank=@bank,accountNumber=@accountNumber,state=@state  WHERE nit=@nit;
	
END;


CREATE PROCEDURE UpdateCategory
	-- Add the parameters for the stored procedure here
	@name varchar(50), 
	@descripcion varchar(100),
	@id int,
	@state int
AS
BEGIN

UPDATE categories SET Id=@id,name=@name,description=@descripcion,state=@state WHERE Id=@id;

	
END;

CREATE PROCEDURE UpdateProduct
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

UPDATE products SET reference=@reference,name=@name,description=@description,category_id=@category_id,stock=@stock,brand=@brand,purchase_price=@purchase_price,sale_price=@sale_price,state=@state,provider_id=@provider_id WHERE reference=@reference;
END;

CREATE PROCEDURE UpdateSaleDetail
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

UPDATE saleDetails SET Id=@id,product_id=@product_id,quantity=@quantity,unit_price=@unit_price,total_price=@total_price,bill_id=@bill_id,state=@state WHERE Id=@id;
	
END;

CREATE PROCEDURE UpdateBill
	-- Add the parameters for the stored procedure here
	@id int,
	@seller_id int,
	@customer_id int,
	@total float,
	@date_bill varchar(50),
	@state int
AS
BEGIN

UPDATE bills SET Id=@id,seller_id=@seller_id,customer_id=@customer_id,total=@total,date_bill=@date_bill,state=@state WHERE Id=@id;
	
END;