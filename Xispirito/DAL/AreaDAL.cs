﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Xispirito.Models;

namespace Xispirito.DAL
{
    public class AreaDAL : IDatabase<Area>
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["XispiritoDB"].ConnectionString;

        public void Insert(Area objArea)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "INSERT INTO Viewer VALUES (@area, @isActive)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@area", objArea.GetArea());
            cmd.Parameters.AddWithValue("@isActive", objArea.GetIsActive());
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public Area Select(int areaId)
        {
            Area area = null;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Area WHERE id_area = @id_area";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id_area", areaId);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows && dr.Read())
            {
                area = new Area(
                    areaId,
                    dr["area"].ToString(),
                    Convert.ToBoolean(dr["isActive"])
                );
            }
            conn.Close();

            return area;
        }

        public void Update(Area objArea)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "UPDATE Area SET area = @area, isActive = @isActive WHERE id_viewer = @id_viewer";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@area", objArea.GetArea());
            cmd.Parameters.AddWithValue("@isActive", objArea.GetIsActive());
            cmd.Parameters.AddWithValue("@id_viewer", objArea.GetId());

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void Delete(int areaId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "UPDATE Area SET isActive = @isActive WHERE id_area = @id_area";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@isActive", false);
            cmd.Parameters.AddWithValue("@id_area", areaId);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public List<Area> List()
        {
            List<Area> areaList = null;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Area Where isActive = 1";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                areaList = new List<Area>();

                while (dr.Read())
                {
                    Area objArea = new Area(
                        Convert.ToInt32(dr["id_area"]),
                        dr["area"].ToString(),
                        Convert.ToBoolean(dr["isActive"])
                    );
                    areaList.Add(objArea);
                }
            }
            conn.Close();

            return areaList;
        }
    }
}