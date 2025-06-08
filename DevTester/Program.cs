

using DataAccess.DAO;
using DataAccess.DAOs;

public class Program
{
    public static void Main(string[] args)
    {
        var sqlOperation = new SqlOperation();

        /*sqlOperation.ProcedureName = "CRE_USER_PR";

        sqlOperation.AddStringParameter("P_UserCode", "aaguero");
        sqlOperation.AddStringParameter("P_Name", "Allan");
        sqlOperation.AddStringParameter("P_Email", "aaguero@ucenfotec.ac.cr");
        sqlOperation.AddStringParameter("P_Password", "Cenfotec123!");
        sqlOperation.AddStringParameter("P_Status", "AC");
        sqlOperation.AddDateTimeParam("P_BirthDate", DateTime.Now);*/

        sqlOperation.ProcedureName = "CRE_MOVIE_PR";

        sqlOperation.AddStringParameter("P_Title", "The Matrix");
        sqlOperation.AddStringParameter("P_Description", "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.");
        sqlOperation.AddDateTimeParam("P_ReleaseDate", new DateTime(1999, 3, 31));
        sqlOperation.AddStringParameter("P_Genre", "Sci-Fi");
        sqlOperation.AddStringParameter("P_Director", "Lana Wachowski, Lilly Wachowski");

        var sqlDao = SqlDao.GetInstance();

        sqlDao.ExecuteProcedure(sqlOperation);

    }
}