using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Xispirito.Models;

namespace Xispirito.DAL
{
    public class ViewerCertificateDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["XispiritoDB"].ConnectionString;

        public void RegisterUserCertificate(ViewerCertificate objViewerCertificate)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "INSERT INTO Viewer_Certified VALUES (@pt_certified, @email_viewer, @id_certified)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@pt_certified", objViewerCertificate.GetCertificatePicture());
            cmd.Parameters.AddWithValue("@email_viewer", objViewerCertificate.GetViewerEmail());
            cmd.Parameters.AddWithValue("@id_certified", objViewerCertificate.GetCertificateId());

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<ViewerCertificate> GetAllUserCertificates(string userEmail)
        {
            List<ViewerCertificate> userCertificates = null;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Viewer_Certified WHERE email_viewer = @email_viewer";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email_viewer", userEmail);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                userCertificates = new List<ViewerCertificate>();

                while (dr.Read())
                {
                    ViewerCertificate viewerCertificate = new ViewerCertificate(
                        dr["pt_certified"].ToString(),
                        dr["email_viewer"].ToString(),
                        Convert.ToInt32(dr["id_certified"])
                    );
                    userCertificates.Add(viewerCertificate);
                }
            }
            conn.Close();

            return userCertificates;
        }
    }
}