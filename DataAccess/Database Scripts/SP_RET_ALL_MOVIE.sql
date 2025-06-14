CREATE PROCEDURE RET_ALL_MOVIE_PR
AS
BEGIN
    SELECT Id, Created, Updated, Title, Description, ReleaseDate, Genre, Director
	from TBL_Movie
END
GO