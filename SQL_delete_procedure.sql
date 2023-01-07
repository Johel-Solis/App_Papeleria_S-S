CREATE PROCEDURE deleteUser 
	-- Add the parameters for the stored procedure here
	@username varchar(50)
	
AS
BEGIN

	DELETE FROM users WHERE username = @username
	
END
GO;

CREATE PROCEDURE deletePerson
	-- Add the parameters for the stored procedure here
	 
	@id int
	 
AS
BEGIN

	DELETE FROM persons WHERE Id= @id
END
GO;

CREATE PROCEDURE deleteCustomer
	-- Add the parameters for the stored procedure here
	@nit int
	
AS
BEGIN

  DELETE FROM customers WHERE nit= @nit;
	
END
GO;

CREATE PROCEDURE deleteProvider
	-- Add the parameters for the stored procedure here
	@nit int
AS
BEGIN
DELETE FROM providers WHERE nit = @nit;
END
GO;


CREATE PROCEDURE deleteCategory
	-- Add the parameters for the stored procedure here
	
	@id int
AS
BEGIN
DELETE FROM categories WHERE Id= @id
	
END
GO;

CREATE PROCEDURE deleteProduct
	-- Add the parameters for the stored procedure here
	@reference int
AS
BEGIN
DELETE FROM products WHERE reference = @reference;
END
GO;

CREATE PROCEDURE deleteSaleDetail
	-- Add the parameters for the stored procedure here
	@id int
	
AS
BEGIN

DELETE FROM saleDetails WHERE Id = @id;
	
END
GO;

CREATE PROCEDURE deleteBill
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
DELETE FROM bills WHERE Id = @id;
	
END
GO;
