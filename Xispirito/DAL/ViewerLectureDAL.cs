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

        public void RegisterUserToLecture(ViewerLecture objViewerLecture)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "INSERT INTO Viewer_Lecture VALUES (@email_viewer, @id_lecture)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email_viewer", objViewerLecture.GetViewerEmail());
            cmd.Parameters.AddWithValue("@id_lecture", objViewerLecture.GetLectureId());

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool VerifyUserAlreadyRegistered(ViewerLecture objViewerLecture)
        {
            bool userAlreadyRegistered = false;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Viewer_Lecture WHERE email_viewer = @email_viewer AND id_lecture = @id_lecture";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email_viewer", objViewerLecture.GetViewerEmail());
            cmd.Parameters.AddWithValue("@id_lecture", objViewerLecture.GetLectureId());

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                userAlreadyRegistered = true;
            }

            return userAlreadyRegistered;
        }

        public void DeleteUserSubscription(ViewerLecture objViewerLecture)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "DELETE FROM Viewer_Lecture WHERE email_viewer = @email_viewer AND id_lecture = @id_lecture";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email_viewer", objViewerLecture.GetViewerEmail());
            cmd.Parameters.AddWithValue("@id_lecture", objViewerLecture.GetLectureId());

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}