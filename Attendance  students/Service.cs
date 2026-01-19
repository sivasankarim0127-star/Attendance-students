using System;
using Com.Wipro.Attendance.Dao;

namespace Com.Wipro.Attendance.Service
{
    public class AttendanceMain
    {
        public static void Start()
        {
            AttendanceDAO dao = new AttendanceDAO();

            Console.WriteLine("1. View Attendance");
            Console.WriteLine("2. Mark Attendance");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                dao.ViewAttendance();
            }
            else if (choice == 2)
            {
                Console.Write("Enter Student ID: ");
                string sid = Console.ReadLine();

                Console.Write("Enter Status (Present/Absent): ");
                string status = Console.ReadLine();

                dao.MarkAttendance(sid, status);
            }
            else
            {
                Console.WriteLine("Invalid Choice");
            }
        }
    }
}
