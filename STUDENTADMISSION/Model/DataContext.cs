using System.Data;
using System.Data.SqlClient;

namespace STUDENTADMISSION.Model
{
    public class DataContext
    {
        SqlConnection conn = new SqlConnection(@"Data Source=FGLAPNL207HFZT\SQLEXPRESS;Initial Catalog=WEBAPI_DB;Integrated Security=True;");
        List<StudentAdmissionDetailsModel> listofobj = new List<StudentAdmissionDetailsModel>();

        public IEnumerable<StudentAdmissionDetailsModel> GetAllStudentAdmissionDetailsModel()
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Students", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                StudentAdmissionDetailsModel sm = new StudentAdmissionDetailsModel()
                {
                    StudentID = rdr.GetInt32(0),
                    StudentName = rdr.GetString(1),
                    StudentClass = rdr.GetString(2),
                    DateofJoining = rdr.GetDateTime(3),
                };
                listofobj.Add(sm);
            }



            conn.Close();



            return listofobj;
        }





        public void AddStudentAdmissionDetailsModel(StudentAdmissionDetailsModel sm)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"INSERT INTO Students (StudentID, StudentName,StudentClass, DateofJoining) VALUES ({sm.StudentID},'{sm.StudentName}','{sm.StudentClass}', '{sm.DateofJoining}')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }




        public void UpdateStudentAdmissionDetailsModel(int id, StudentAdmissionDetailsModel sm)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"Update Students set StudentName='{sm.StudentName}',StudentClass='{sm.StudentClass}',DateofJoining='{sm.DateofJoining}' where StudentID={id}", conn);
            cmd.ExecuteNonQuery();



            conn.Close();
        }



        public void DeleteStudentAdmissionDetailsModel(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"delete from Students where StudentID={id}", conn);
            cmd.ExecuteNonQuery();



            conn.Close();
        }
    }
}
