using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Xispirito.Models;

namespace Xispirito.DAL
{
    public class ViewerLectureDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["XispiritoDB"].ConnectionString;

        public void RegisterUserToLecture(string viewerEmail, int lectureId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "INSERT INTO Viewer_Lecture VALUES (@email_viewer, @id_lecture, @isActive)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email_viewer", viewerEmail);
            cmd.Parameters.AddWithValue("@id_lecture", lectureId);
            cmd.Parameters.AddWithValue("@isActive", true);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public bool VerifyUserAlreadyRegistered(string viewerEmail, int lectureId)
        {
            bool userAlreadyRegistered = false;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Viewer_Lecture WHERE @email_viewer = email_viewer AND @id_lecture = id_lecture)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email_viewer", viewerEmail);
            cmd.Parameters.AddWithValue("@id_lecture", lectureId);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                userAlreadyRegistered = true;
            }

            return userAlreadyRegistered;
        }
    }
}