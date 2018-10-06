

CREATE PROCEDURE [dbo].[spGetCategory] 

AS
BEGIN

	SET NOCOUNT ON;
	Select * from Categories order by CategoryName ASC
END

GO


