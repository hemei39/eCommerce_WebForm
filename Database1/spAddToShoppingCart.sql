


CREATE PROCEDURE [dbo].[spAddToShoppingCart] 
	@Username nvarchar(50),
	@ProductID int,
	@UnitPrice money
	
AS
BEGIN

	SET NOCOUNT ON;
	
	select * from ShoppingCart where Username =@Username and ProductID =@ProductID 
	IF (@@ROWCOUNT = 0)
		Begin
			insert into ShoppingCart(Username, ProductID, UnitPrice, Quantity, Discount)
			values (@Username,@ProductID,@UnitPrice,1,0)
		
		End
	Else
		Begin
			update ShoppingCart
			set Quantity = Quantity +1
			Where Username =@Username and ProductID =@ProductID
		ENd
	
END


GO


