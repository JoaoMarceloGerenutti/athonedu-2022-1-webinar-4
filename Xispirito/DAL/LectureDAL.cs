using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Xispirito.Models;

namespace Xispirito.DAL
{
    public class LectureDAL : IDatabase<Lecture>
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["XispiritoDB"].ConnectionString;

        public void Insert(Lecture objLecture)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "INSERT INTO Lecture VALUES (@nm_lecture, @pt_lecture, @tm_lecture, dt_lecture, dc_lecture, mod_lecture, rt_lecture, lt_lecture, isActive)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nm_lecture", objLecture.GetName());
            cmd.Parameters.AddWithValue("@pt_lecture", objLecture.GetPicture());
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
                objLecture = new Lecture(
                    lectureId,
                    dr["nm_lecture"].ToString(),
                    dr["pt_lecture"].ToString(),
                    Convert.ToInt32(dr["tm_lecture"]),
                    Convert.ToDateTime(dr["dt_lecture"]),
                    dr["dc_lecture"].ToString(),
                    Enum.GetName(typeof(Modality), Convert.ToInt32(dr["mod_lecture"])),
                    Convert.ToBoolean(dr["rt_lecture"]),
                    Convert.ToInt32(dr["lt_lecture"]),
                    Convert.ToBoolean(dr["isActive"])
                );
            }
            conn.Close();

            return objLecture;
        }

        public List<Lecture> UpcomingLecturesList(int lectureQuantity)
        {
            List<Lecture> lectureList = null;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Lecture WHERE isActive = 1 ORDER BY dt_lecture DESC";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                lectureList = new List<Lecture>();

                for (int i = 0; i < lectureQuantity; i++)
                {
                    if (dr.Read())
                    {
                        Lecture objLecture = new Lecture(
                            Convert.ToInt32(dr["id_lecture"]),
                            dr["nm_lecture"].ToString(),
                            dr["pt_lecture"].ToString(),
                            Convert.ToInt32(dr["tm_lecture"]),
                            Convert.ToDateTime(dr["dt_lecture"]),
                            dr["dc_lecture"].ToString(),
                            Enum.GetName(typeof(Modality), Convert.ToInt32(dr["mod_lecture"])),
                            Convert.ToBoolean(dr["rt_lecture"]),
                            Convert.ToInt32(dr["lt_lecture"]),
                            Convert.ToBoolean(dr["isActive"])
                        );
                        lectureList.Add(objLecture);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            conn.Close();

            return lectureList;
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