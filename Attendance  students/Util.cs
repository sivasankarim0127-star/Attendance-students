using System.Data.SqlClient;

namespace Com.Wipro.Attendance.Util
{
    public class DBUtil
    {
        public static SqlConnection GetDBConnection()
        {
            return new SqlConnection(
                "Data Source=localhost\\SQLEXPRESS;" +
                "Initial Catalog=AttendanceRecordsysDB;" +
                "Integrated Security=True");
        }
    }
}
