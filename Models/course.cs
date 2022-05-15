using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace CoursesList.Models
{
    public class course
    {
        public string CourseCat { get; set; }
        public DateTime CourseStart { get; set; }
        public string Description { get; set; }
        public string Format { get; set; }
        public string Level { get; set; }
        public int Price { get; set; }
        public static SqlConnection con;
        public static SqlCommand cmd;
        public course()
        {

        }
        public course(string courseCat, DateTime courseStart, string descri, string format, string level, int price)
        {
            CourseCat = courseCat;
            CourseStart = courseStart;
            Description = descri;
            Format = format;
            Level = level;
            Price = price;
        }
        public static List<course> Fetch()
        {
            List<course> Courses=new List<course>();
            con = new SqlConnection("Data Source=LAPTOP-2NOE6BOD\\SQLSERVER2019G3;Initial Catalog=learningportaldb;Integrated Security=true");
            con.Open();
            cmd = new SqlCommand("Get_Course");
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                course C = new course();
                C.CourseCat = dr[0].ToString();
                C.CourseStart = Convert.ToDateTime(dr[1]);
                C.Description = dr[2].ToString();
                C.Format = dr[3].ToString();
                C.Level = dr[4].ToString();
                C.Price = Convert.ToInt32(dr[5]);
                Courses.Add(C);
            }
            return Courses;

        }
        public static void Insert(course C)
        {
            con = new SqlConnection("Data Source=LAPTOP-2NOE6BOD\\SQLSERVER2019G3;Initial Catalog=learningportaldb;Integrated Security=true");
            con.Open();
            cmd = new SqlCommand("Insert_course");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@CourseCat", C.CourseCat);
            cmd.Parameters.AddWithValue("@CourseStart", C.CourseStart);
            cmd.Parameters.AddWithValue("@Description", C.Description);
            cmd.Parameters.AddWithValue("@Format", C.Format);
            cmd.Parameters.AddWithValue("@Level", C.Level);
            cmd.Parameters.AddWithValue("@Price", C.Price);
            cmd.ExecuteNonQuery();

        }
        public static bool Delete(string CourseCat)
        {
            con = new SqlConnection("Data Source=LAPTOP-2NOE6BOD\\SQLSERVER2019G3;Initial Catalog=learningportaldb;Integrated Security=true");
            con.Open();
            cmd = new SqlCommand("Delete_course");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@CourseCat", CourseCat);
            if (cmd.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //public static bool Update(string CourseCat, course C)
        //{
        //    con = new SqlConnection("Data Source=LAPTOP-2NOE6BOD\\SQLSERVER2019G3;Initial Catalog=learningportaldb;Integrated Security=true"); 
        //    con.Open();

        //    cmd = new SqlCommand("Course_Update");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Connection = con;
        //    cmd.Parameters.AddWithValue("@CourseCat", C.CourseCat);
        //    cmd.Parameters.AddWithValue("@CourseStart", C.CourseStart);
        //    cmd.Parameters.AddWithValue("@Description", C.Description);
        //    cmd.Parameters.AddWithValue("@Format", C.Format);
        //    cmd.Parameters.AddWithValue("@Level", C.Level);
        //    cmd.Parameters.AddWithValue("@Price", C.Price);
        //    cmd.ExecuteNonQuery();
          
        //        return true;
            
            
        //}

    }
}
