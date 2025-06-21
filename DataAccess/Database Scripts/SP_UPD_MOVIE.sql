CREATE PROCEDURE UPD_MOVIE_PR
(
	@P_Id int,
	@P_Title nvarchar(75),
	@P_Description nvarchar(50),
	@P_ReleaseDate Datetime,
	@P_Genre nvarchar(20),
	@P_Director nvarchar(30)
)
AS
BEGIN
	UPDATE TBL_Movie
	SET
		Title = @P_Title,
		Description = @P_Description,
		ReleaseDate = @P_ReleaseDate,
		Genre = @P_Genre,
		Director = @P_Director
    WHERE Id = @P_Id
END
GO