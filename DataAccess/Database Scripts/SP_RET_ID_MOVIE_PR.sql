CREATE PROCEDURE RET_ID_MOVIE_PR
    @P_Id INT
AS
BEGIN
    SELECT Id, Created, Updated, Title, Description, ReleaseDate, Genre, Director
    FROM TBL_Movie
    WHERE Id = @P_Id
END
GO