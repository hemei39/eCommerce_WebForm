


CREATE PROCEDURE [dbo].[spGetShoppingCart] 
	@Username nvarchar(50)
	
AS
BEGIN

	SET NOCOUNT ON;
	
	Select *, UnitPrice*Quantity as SubTotal from ShoppingCart
	where Username = @Username
END


GO


