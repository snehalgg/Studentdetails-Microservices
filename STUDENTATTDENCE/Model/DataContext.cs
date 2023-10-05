
using System.Data.SqlClient;


namespace STUDENTATTDENCE.Model
{
    //Attendance
    //https://localhost:7151/api/StudentAttendance
    public class DataContext
    {
        SqlConnection conn = new SqlConnection(@"Data Source=FGLAPNL207HFZT\SQLEXPRESS;Initial Catalog=WEBAPI_DB;Integrated Security=True;");
        List<StudentAttendanceModel> listofobj = new List<StudentAttendanceModel>();

        public IEnumerable<StudentAttendanceModel> GetAllStudentAttendanceDetail()
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from StudentAttendance", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                StudentAttendanceModel sm = new StudentAttendanceModel()
                {
                    StudentID = rdr.GetInt32(0),
                    StudentName = rdr.GetString(1),
                    AttendancePercentage = rdr.GetDecimal(2),
                };
                listofobj.Add(sm);
            }



            conn.Close();



            return listofobj;
        }





        public void AddStudentAttendanceDetail(StudentAttendanceModel sm)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"INSERT INTO StudentAttendance (StudentID, StudentName, AttendancePercentage) VALUES ({sm.StudentID},'{sm.StudentName}', {sm.AttendancePercentage})", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }




        public void UpdateStudentAttendanceDetail(int id, StudentAttendanceModel sm)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"Update StudentAttendance set StudentName='{sm.StudentName}',AttendancePercentage={sm.AttendancePercentage} where StudentID={id}", conn);
            cmd.ExecuteNonQuery();



            conn.Close();
        }



        public void DeleteStudentAttendanceDetail(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"delete from StudentAttendance where StudentID={id}", conn);
            cmd.ExecuteNonQuery();



            conn.Close();
        }
    }
}