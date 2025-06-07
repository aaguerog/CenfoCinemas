

using DataAccess.DAO;
using DataAccess.DAOs;

public class Program
{
    public static void Main(string[] args)
    {
        var sqlOperation = new SqlOperation();

        sqlOperation.ProcedureName = "CRE_USER_PR";

        sqlOperation.AddStringParameter("P_UserCode", "aaguero");
        sqlOperation.AddStringParameter("P_Name", "Allan");
        sqlOperation.AddStringParameter("P_Email", "aaguero@ucenfotec.ac.cr");
        sqlOperation.AddStringParameter("P_Password", "Cenfotec123!");
        sqlOperation.AddStringParameter("P_Status", "AC");
        sqlOperation.AddDateTimeParam("P_BirthDate", DateTime.Now);

        var sqlDao = SqlDao.GetInstance();

        sqlDao.ExecuteProcedure(sqlOperation);
    }
}