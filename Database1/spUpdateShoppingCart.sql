


CREATE PROCEDURE [dbo].[spUpdateShoppingCart] 
	@Username nvarchar(50),
	@ProductID int,
	@Quantity int
	
AS
BEGIN

	SET NOCOUNT ON;
	
	
	update ShoppingCart
	set Quantity = @Quantity
	Where Username =@Username and ProductID =@ProductID
	
	
END


GO


