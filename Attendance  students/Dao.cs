using System;
using System.Data.SqlClient;
using Com.Wipro.Attendance.Util;

namespace Com.Wipro.Attendance.Dao
{
    public class AttendanceDAO
    {
        public void ViewAttendance()
        {
            using (var con = DBUtil.GetDBConnection())
            {
                con.Open();

                // Verify table exists in this database
                using (var check = new SqlCommand("SELECT OBJECT_ID('dbo.ATTENDANCE_TBL','U')", con))
                {
                    var id = check.ExecuteScalar();
                    if (id == null || id == DBNull.Value)
                        throw new InvalidOperationException($"Table dbo.ATTENDANCE_TBL not found in database '{con.Database}'.");
                }

                using (var cmd = new SqlCommand(
                    "SELECT Attendance_ID, Student_ID, Attendance_Status, Attendance_Date FROM dbo.ATTENDANCE_TBL", con))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Console.WriteLine($"{dr["Attendance_ID"]} {dr["Student_ID"]} {dr["Attendance_Status"]} {dr["Attendance_Date"]}");
                    }
                }
            }
        }

        public void MarkAttendance(string studentId, string status)
        {
            SqlConnection con = DBUtil.GetDBConnection();

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO dbo.ATTENDANCE_TBL " +
                "(Student_ID, Attendance_Status, Attendance_Date) " +
                "VALUES (@sid, @status, GETDATE())", con);

            cmd.Parameters.AddWithValue("@sid", studentId);
            cmd.Parameters.AddWithValue("@status", status);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("Attendance Marked Successfully");
        }
    }
}
