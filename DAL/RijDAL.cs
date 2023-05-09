using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public class RijDAL : IRijDAL
    {
        private readonly string _connectionString;

        public RijDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public void CreateRij(Rij rij)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Rij (Vak_ID, Nummer, Aantal_stoelen) VALUES (@Vak_ID, @Nummer, @Aantal_stoelen); SELECT CAST(SCOPE_IDENTITY() AS INT)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Vak_ID", rij.Vak_ID);
                    command.Parameters.AddWithValue("@Nummer", rij.Nummer);
                    command.Parameters.AddWithValue("@Aantal_stoelen", rij.AantalStoelen);

                    connection.Open();
                    rij.ID = (int)command.ExecuteScalar();
                }
            }
        }

        public Rij GetRijById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Rij WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int vakId = Convert.ToInt32(reader["Vak_ID"]);
                    int nummer = Convert.ToInt32(reader["Nummer"]);
                    int aantalStoelen = Convert.ToInt32(reader["Aantal_stoelen"]);
                    Rij rij = new Rij(id, vakId, nummer, aantalStoelen);
                    return rij;
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<Rij> GetAllRijenByVakId(int vakId)
        {
            List<Rij> rijen = new List<Rij>();
            string query = "SELECT ID, Vak_ID, Nummer, Aantal_stoelen FROM Rij WHERE Vak_ID = @Vak_ID ORDER BY Nummer ASC";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Vak_ID", vakId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["ID"];
                            int vak_ID = (int)reader["Vak_ID"];
                            int nummer = (int)reader["Nummer"];
                            int aantal_stoelen = (int)reader["Aantal_stoelen"];
                            Rij rij = new Rij(id, vak_ID, nummer, aantal_stoelen);
                            rijen.Add(rij);
                        }
                    }
                }
            }
            return rijen;
        }

        public void UpdateRij(Rij rij)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Rij SET Nummer=@Nummer, Aantal_stoelen=@Aantal_stoelen WHERE ID=@ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Nummer", rij.Nummer);
                command.Parameters.AddWithValue("@Aantal_stoelen", rij.AantalStoelen);
                command.Parameters.AddWithValue("@ID", rij.ID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteRij(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Rij WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
