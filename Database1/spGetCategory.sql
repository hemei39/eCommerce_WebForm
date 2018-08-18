USE [NorthWind]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetCategory] 

AS
BEGIN

	SET NOCOUNT ON;
	Select * from Categories order by CategoryName ASC
END

GO


