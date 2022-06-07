using System.Configuration;
using System.Data.SqlClient;
using Xispirito.Models;

namespace Xispirito.DAL
{
    public class AdministratorLectureDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["XispiritoDB"].ConnectionString;

        public void RegisterUserToLecture(AdministratorLecture objAdministratorLecture)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "INSERT INTO Administrator_Lecture VALUES (@email_administrator, @id_lecture)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email_administrator", objAdministratorLecture.GetAdministrator().GetEmail());
            cmd.Parameters.AddWithValue("@id_lecture", objAdministratorLecture.GetLecture().GetId());

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool VerifyUserAlreadyRegistered(AdministratorLecture objAdministratorLecture)
        {
            bool userAlreadyRegistered = false;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Administrator_Lecture WHERE email_administrator = @email_administrator AND id_lecture = @id_lecture";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email_administrator", objAdministratorLecture.GetAdministrator().GetEmail());
            cmd.Parameters.AddWithValue("@id_lecture", objAdministratorLecture.GetLecture().GetId());

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                userAlreadyRegistered = true;
            }

            return userAlreadyRegistered;
        }

        public void DeleteUserSubscription(AdministratorLecture objAdministratorLecture)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "DELETE FROM Administrator_Lecture WHERE email_administrator = @email_administrator AND id_lecture = @id_lecture";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email_administrator", objAdministratorLecture.GetAdministrator().GetEmail());
            cmd.Parameters.AddWithValue("@id_lecture", objAdministratorLecture.GetLecture().GetId());

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}