namespace STUDENTATTDENCE.Model
{
    public class StudentAttendanceModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; } = "";

        public decimal AttendancePercentage { get; set; }
    }
}