﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Xispirito.Models;

namespace Xispirito.DAL
{
    public class SpeakerDAL : IDatabase<Speaker>
    {
        //// Casa.
        //private string connectionString = @"Data Source=DESKTOP-29C0T41\SQLEXPRESS;Initial Catalog=XispiritoDB;Integrated Security=True";

        // Trabalho.
        private string connectionString = @"Data Source=AM21\SQLEXPRESS;Initial Catalog=XispiritoDB;Integrated Security=True";

        public void Insert(Speaker objSpeaker)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "INSERT INTO Speaker VALUES (@nm_speaker, @email_speaker, @ft_speaker, @pf_speaker, @pw_speaker, @isActive)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nm_viewer", objSpeaker.GetName());
            cmd.Parameters.AddWithValue("@email_viewer", objSpeaker.GetEmail());
            cmd.Parameters.AddWithValue("@ft_viewer", objSpeaker.GetPicture());
            cmd.Parameters.AddWithValue("@pf_speaker", objSpeaker.GetSpeakerProfession());
            cmd.Parameters.AddWithValue("@pw_speaker", objSpeaker.GetEncryptedPassword());
            cmd.Parameters.AddWithValue("@isActive", objSpeaker.GetIsActive());
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public Speaker Select(int speakerId)
        {
            Speaker objSpeaker = null;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Speaker WHERE id_speaker = @id_speaker";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id_speaker", speakerId);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows && dr.Read())
            {
                objSpeaker = new Speaker(
                    speakerId,
                    dr["nm_speaker"].ToString(),
                    dr["email_speaker"].ToString(),
                    dr["ft_speaker"].ToString(),
                    dr["pf_speaker"].ToString(),
                    dr["pw_speaker"].ToString(),
                    Convert.ToBoolean(dr["isActive"])
                );
            }
            conn.Close();

            return objSpeaker;
        }

        public void Update(Speaker objSpeaker)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "UPDATE Speaker SET nm_speaker = @nm_speaker, email_speaker = @email_speaker, ft_viewer = @ft_speaker, pw_viwer = @pw_speaker, isActive = @isActive WHERE id_viewer = @id_viewer";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nm_speaker", objSpeaker.GetName());
            cmd.Parameters.AddWithValue("@email_speaker", objSpeaker.GetEmail());
            cmd.Parameters.AddWithValue("@ft_speaker", objSpeaker.GetPicture());
            cmd.Parameters.AddWithValue("@pw_speaker", objSpeaker.GetEncryptedPassword());
            cmd.Parameters.AddWithValue("@isActive", objSpeaker.GetIsActive());
            cmd.Parameters.AddWithValue("@id_speaker", objSpeaker.GetId());

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void Delete(int speakerId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "UPDATE Speaker SET isActive = @isActive WHERE id_speaker = @id_speaker";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@isActive", false);
            cmd.Parameters.AddWithValue("@id_viewer", speakerId);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public List<Speaker> List()
        {
            List<Speaker> speakerList = null;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Speaker Where isActive = 1";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                speakerList = new List<Speaker>();

                while (dr.Read())
                {
                    Speaker objSpeaker = new Speaker(
                        Convert.ToInt32(dr["id_speaker"]),
                        dr["nm_speaker"].ToString(),
                        dr["email_speaker"].ToString(),
                        dr["ft_speaker"].ToString(),
                        dr["pf_speaker"].ToString(),
                        dr["pw_speaker"].ToString(),
                        Convert.ToBoolean(dr["isActive"])
                    );
                    speakerList.Add(objSpeaker);
                }
            }
            conn.Close();

            return speakerList;
        }

        public bool SignIn(string speakerEmail, string speakerEncryptedPassword)
        {
            bool validSpeaker = false;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Speaker WHERE email_speaker = @email_speaker AND pw_speaker = @pw_speaker";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email_speaker", speakerEmail);
            cmd.Parameters.AddWithValue("@pw_speaker", speakerEncryptedPassword);

            SqlDataReader dr = cmd.ExecuteReader();
            validSpeaker = dr.HasRows;

            return validSpeaker;
        }
    }
}