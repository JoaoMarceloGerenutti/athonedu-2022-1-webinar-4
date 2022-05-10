using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Xispirito.Models;

namespace Xispirito.DAL
{
    public class LectureDAL : IDatabase<Lecture>
    {
        //// Casa.
        //private string connectionString = @"Data Source=DESKTOP-29C0T41\SQLEXPRESS;Initial Catalog=XispiritoDB;Integrated Security=True";

        // Trabalho.
        private string connectionString = @"Data Source=AM21\SQLEXPRESS;Initial Catalog=XispiritoDB;Integrated Security=True";

        public void Insert(Lecture objLecture)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "INSERT INTO Lecture VALUES (@nm_lecture, @tm_lecture, dt_lecture, dc_lecture, mod_lecture, rt_lecture, lt_lecture, isActive)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nm_lecture", objLecture.GetName());
            cmd.Parameters.AddWithValue("@tm_lecture", objLecture.GetTime());
            cmd.Parameters.AddWithValue("@dt_lecture", objLecture.GetDate());
            cmd.Parameters.AddWithValue("@dc_lecture", objLecture.GetDescription());
            cmd.Parameters.AddWithValue("@mod_lecture", objLecture.GetModality());
            cmd.Parameters.AddWithValue("@rt_lecture", objLecture.GetIsLimited());
            cmd.Parameters.AddWithValue("@lt_lecture", objLecture.GetLimit());
            cmd.Parameters.AddWithValue("@isActive", objLecture.GetIsActive());
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public Lecture Select(int lectureId)
        {
            Lecture objLecture = null;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Lecture WHERE id_lecture = @id_lecture";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id_lecture", lectureId);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows && dr.Read())
            {
                //objLecture = new Lecture(
                //    lectureId,
                //    dr["nm_lecture"].ToString(),
                //    Convert.ToInt32(dr["tm_lecture"]),
                //    Convert.ToDateTime(dr["dt_lecture"]),
                //    dr["dc_lecture"].ToString(),
                //    Convert.ToBoolean(dr["mod_lecture"]),
                //    Convert.ToBoolean(dr["rt_lecture"]),
                //    Convert.ToInt32(dr["lt_lecture"]),
                //    Convert.ToBoolean(dr["isActive"])
                //);
            }
            conn.Close();

            return objLecture;
        }

        public void Update(Lecture objLecture)
        {
            throw new NotImplementedException();
        }

        public void Delete(int lectureId)
        {
            throw new NotImplementedException();
        }

        public List<Lecture> List()
        {
            throw new NotImplementedException();
        }
    }
}