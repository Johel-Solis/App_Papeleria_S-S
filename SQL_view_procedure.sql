CREATE PROCEDURE viewtUser 
	-- Add the parameters for the stored procedure here
	@username varchar(50)
	
AS
BEGIN

	SELECT         *
	FROM            users
	WHERE  (username=@username);
	
END
GO;

CREATE PROCEDURE VewPerson
	-- Add the parameters for the stored procedure here
	 
	@id int
	 
AS
BEGIN

	SELECT        *
	FROM            persons
	WHERE  (Id=@id);
END
GO;

CREATE PROCEDURE viewCustomer
	-- Add the parameters for the stored procedure here
	@nit int
	
AS
BEGIN

   SELECT         *
FROM            customers
WHERE  (nit=@nit);
	
END
GO;

CREATE PROCEDURE viewProvider
	-- Add the parameters for the stored procedure here
	@nit int
AS
BEGIN

SELECT         *
FROM            providers
WHERE  (nit=@nit);
END
GO;


CREATE PROCEDURE viewCategory
	-- Add the parameters for the stored procedure here
	
	@id int
AS
BEGIN

SELECT        *
FROM            categories
WHERE  (Id=@id);
	
END
GO;

CREATE PROCEDURE viewProduct
	-- Add the parameters for the stored procedure here
	@reference int
AS
BEGIN

SELECT         *
FROM            products
WHERE  (reference=@reference);
	
END
GO;

CREATE PROCEDURE viewSaleDetail
	-- Add the parameters for the stored procedure here
	@id int
	
AS
BEGIN

SELECT         *
FROM            saleDetails
WHERE  (Id=@id);
	
END
GO;

CREATE PROCEDURE viewBill
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN

SELECT        *
FROM            bills
WHERE  (Id=@id);
	
END
GO;
