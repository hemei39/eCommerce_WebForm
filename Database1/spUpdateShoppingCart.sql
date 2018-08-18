USE [NorthWind]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


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


