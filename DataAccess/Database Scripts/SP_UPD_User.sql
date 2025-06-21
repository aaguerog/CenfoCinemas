CREATE PROCEDURE UPD_USER_PR
(
	@P_Id int,
	@P_UserCode nvarchar(30),
	@P_Name nvarchar(50),
	@P_Email nvarchar(30),
	@P_Password nvarchar(50),
	@P_BirthDate Datetime,
	@P_Status nvarchar(10)
)
AS
BEGIN
	UPDATE TBL_User
	SET
        UserCode = @P_UserCode,
        Name = @P_Name,
        Email = @P_Email,
        Password = @P_Password,
        BirthDate = @P_BirthDate,
        Status = @P_Status,
        Updated = GETDATE()
    WHERE Id = @P_Id
END
GO