using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Xispirito.Models;

namespace Xispirito.DAL
{
    public class AdministratorDAL : IDatabase<Administrator>
    {
        //// Casa.
        //private string connectionString = @"Data Source=DESKTOP-29C0T41\SQLEXPRESS;Initial Catalog=XispiritoDB;Integrated Security=True";
            
        // Trabalho.
        private string connectionString = @"Data Source=AM21\SQLEXPRESS;Initial Catalog=XispiritoDB;Integrated Security=True";

        public void Insert(Administrator objAdministrator)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "INSERT INTO Administrator VALUES (@nm_administrator, @email_administrator, @ft_administrator, @pw_administrator, @isActive)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nm_administrator", objAdministrator.GetName());
            cmd.Parameters.AddWithValue("@email_administrator", objAdministrator.GetEmail());
            cmd.Parameters.AddWithValue("@ft_administrator", objAdministrator.GetPicture());
            cmd.Parameters.AddWithValue("@pw_administrator", objAdministrator.GetEncryptedPassword());
            cmd.Parameters.AddWithValue("@isActive", objAdministrator.GetIsActive());
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public Administrator Select(int administratorId)
        {
            Administrator objAdministrator = null;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Viewer WHERE id_viewer = @id_viewer";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id_administrator", administratorId);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows && dr.Read())
            {
                objAdministrator = new Administrator(
                    administratorId,
                    dr["nm_administrator"].ToString(),
                    dr["email_administrator"].ToString(),
                    dr["ft_administrator"].ToString(),
                    dr["pw_administrator"].ToString(),
                    Convert.ToBoolean(dr["isActive"])
                );
            }
            conn.Close();

            return objAdministrator;
        }

        public void Update(Administrator objAdministrator)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "UPDATE Administrator SET nm_administrator = @nm_administrator, email_administrator = @email_administrator, ft_administrator = @ft_administrator, pw_administrator = @pw_administrator, isActive = @isActive WHERE id_administrator = @id_administrator";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nm_administrator", objAdministrator.GetName());
            cmd.Parameters.AddWithValue("@email_administrator", objAdministrator.GetEmail());
            cmd.Parameters.AddWithValue("@ft_administrator", objAdministrator.GetPicture());
            cmd.Parameters.AddWithValue("@pw_administrator", objAdministrator.GetEncryptedPassword());
            cmd.Parameters.AddWithValue("@isActive", objAdministrator.GetIsActive());
            cmd.Parameters.AddWithValue("@id_administrator", objAdministrator.GetId());

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void Delete(int administratorId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "UPDATE Administrator SET isActive = @isActive WHERE id_administrator = @id_administrator";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@isActive", false);
            cmd.Parameters.AddWithValue("@id_administrator", administratorId);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public List<Administrator> List()
        {
            List<Administrator> administratorList = null;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Viewer Where isActive = 1";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                administratorList = new List<Administrator>();

                while (dr.Read())
                {
                    Administrator objAdministrator = new Administrator(
                        Convert.ToInt32(dr["id_administrator"]),
                        dr["nm_administrator"].ToString(),
                        dr["email_administrator"].ToString(),
                        dr["ft_administrator"].ToString(),
                        dr["pw_administrator"].ToString(),
                        Convert.ToBoolean(dr["isActive"])
                    );
                    administratorList.Add(objAdministrator);
                }
            }
            conn.Close();

            return administratorList;
        }

        public bool SignIn(string administratorEmail, string administratorEncryptedPassword)
        {
            bool validSpeaker = false;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Administrator WHERE email_administrator = @email_administrator AND pw_administrator = @pw_administrator";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email_administrator", administratorEmail);
            cmd.Parameters.AddWithValue("@pw_administrator", administratorEncryptedPassword);

            SqlDataReader dr = cmd.ExecuteReader();
            validSpeaker = dr.HasRows;

            return validSpeaker;
        }
    }
}