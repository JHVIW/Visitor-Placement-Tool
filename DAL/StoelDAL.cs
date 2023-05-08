using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.Extensions.Configuration;
using Models;

namespace DAL
{
    public class StoelDAL : IStoelDAL
    {
        private readonly string _connectionString;

        public StoelDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public void CreateStoel(Stoel stoel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Stoel (Rij_ID, Nummer) VALUES (@Rij_ID, @Nummer); SELECT CAST(SCOPE_IDENTITY() AS INT)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Rij_ID", stoel.Rij_ID);
                    command.Parameters.AddWithValue("@Nummer", stoel.Nummer);

                    connection.Open();
                    stoel.ID = (int)command.ExecuteScalar();
                }
            }
        }

        public Stoel GetStoelById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Stoel WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int rijId = Convert.ToInt32(reader["Rij_ID"]);
                    int nummer = Convert.ToInt32(reader["Nummer"]);
                    int? bezoekerId = reader.IsDBNull(reader.GetOrdinal("Bezoeker_ID")) ? null : (int?)Convert.ToInt32(reader["Bezoeker_ID"]);
                    Stoel stoel = new Stoel(id, rijId, nummer, bezoekerId);
                    return stoel;
                }
                else
                {
                    return null;
                }
            }
        }
        public IEnumerable<Stoel> GetAllStoelenByRijId(int rijId)
        {
            List<Stoel> stoelen = new List<Stoel>();
            string query = "SELECT * FROM Stoel WHERE Rij_ID = @Rij_ID ORDER BY Nummer ASC";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Rij_ID", rijId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["ID"];
                            int rij_ID = (int)reader["Rij_ID"];
                            int nummer = (int)reader["Nummer"];
                            int? bezoeker_ID = reader["Bezoeker_ID"] == DBNull.Value ? null : (int?)reader["Bezoeker_ID"];
                            Stoel stoel = new Stoel(id, rij_ID, nummer, bezoeker_ID);
                            stoelen.Add(stoel);
                        }
                    }
                }
            }

            return stoelen;
        }

        public void UpdateStoel(Stoel stoel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Stoel SET Bezoeker_ID = @Bezoeker_ID WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Bezoeker_ID", stoel.Bezoeker_ID ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@ID", stoel.ID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteStoel(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Stoel WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
