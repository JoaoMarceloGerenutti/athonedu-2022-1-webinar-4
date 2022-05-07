using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Xispirito.Models.Classes;
using Xispirito.Models.Interfaces;

namespace Xispirito.DAL
{
    public class ViewerDAL : IDatabase<Viewer>
    {
        private string connectionString = @"Data Source=DESKTOP-29C0T41\SQLEXPRESS;Initial Catalog=XispiritoDB;Integrated Security=True";

        public void InsertUser(Viewer user)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "INSERT INTO Viewer VALUES (@nm_viewer, @email_viewer, @ft_viewer, @sn_viwer, @isActive)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nm_viewer", user.GetId());
            cmd.Parameters.AddWithValue("@email_viewer", user.GetEmail());
            cmd.Parameters.AddWithValue("@ft_viewer", user.GetPicture());
            cmd.Parameters.AddWithValue("@sn_viwer", user.GetEncryptedPassword());
            cmd.Parameters.AddWithValue("@isActive", user.GetIsActive());
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public Viewer SelectUser(int userId)
        {
            Viewer viewer = null;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Viewer WHERE id_viewer = @id_viewer";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("id_viewer", userId);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows && dr.Read())
            {
                viewer = new Viewer(
                    userId,
                    dr["nm_viewer"].ToString(),
                    dr["email_viewer"].ToString(),
                    dr["ft_viewer"].ToString(),
                    dr["sn_viwer"].ToString(),
                    Convert.ToBoolean(dr["isActive"])
                );
            }
            conn.Close();

            return viewer;
        }

        public void UpdateUser(Viewer user)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "UPDATE Viewer SET nm_viewer = @nm_viewer, email_viewer = @email_viewer, ft_viewer = @ft_viewer, sn_viwer = @sn_viwer, isActive = @isActive WHERE id_viewer = @id_viewer";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nm_viewer", user.GetName());
            cmd.Parameters.AddWithValue("@email_viewer", user.GetEmail());
            cmd.Parameters.AddWithValue("@ft_viewer", user.GetPicture());
            cmd.Parameters.AddWithValue("@sn_viwer", user.GetEncryptedPassword());
            cmd.Parameters.AddWithValue("@isActive", user.GetIsActive());
            cmd.Parameters.AddWithValue("@id_viewer", user.GetId());

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void DeleteUser(int userId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "UPDATE Viewer SET isActive = @isActive WHERE id_viewer = @id_viewer";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@isActive", false);
            cmd.Parameters.AddWithValue("@id_viewer", userId);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public List<Viewer> ListUser()
        {
            List<Viewer> viewerList = null;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Viewer Where isActive = 1";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                viewerList = new List<Viewer>();

                while (dr.Read())
                {
                    Viewer objViewer = new Viewer(
                        Convert.ToInt32(dr["id_viewer"]),
                        dr["nm_viewer"].ToString(),
                        dr["email_viewer"].ToString(),
                        dr["ft_viewer"].ToString(),
                        dr["sn_viwer"].ToString(),
                        Convert.ToBoolean(dr["isActive"])
                    );
                    viewerList.Add(objViewer);
                }
            }
            conn.Close();

            return viewerList;
        }
    }
}