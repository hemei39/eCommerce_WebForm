


CREATE PROCEDURE [dbo].[spDeleteFromShoppingCart] 
	@Username nvarchar(50),
	@ProductID int
	
AS
BEGIN

	SET NOCOUNT ON;	
	
	Delete From ShoppingCart			
	Where Username =@Username and ProductID =@ProductID
		
	
END


GO


