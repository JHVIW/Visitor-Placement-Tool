using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Interfaces;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class VakDAL : IVakDAL
    {
        private readonly string _connectionString;

        public VakDAL(IConfiguration configuration)
        {
            _connectionString = "Server=mssqlstud.fhict.local;Database=dbi482609_eventtool;User Id=dbi482609_eventtool;Password=Rviw2003%;";
        }

        public void CreateVak(Vak vak)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Vak (Evenement_ID, Letter, Aantal_rijen, Aantal_stoelen_per_rij) VALUES (@Evenement_ID, @Letter, @Aantal_rijen, @Aantal_stoelen_per_rij); SELECT CAST(SCOPE_IDENTITY() AS INT)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Evenement_ID", vak.Evenement_ID);
                    command.Parameters.AddWithValue("@Letter", vak.Letter.ToString());
                    command.Parameters.AddWithValue("@Aantal_rijen", vak.AantalRijen);
                    command.Parameters.AddWithValue("@Aantal_stoelen_per_rij", vak.AantalStoelenPerRij);

                    connection.Open();
                    vak.ID = (int)command.ExecuteScalar();
                }
            }
        }

        public Vak GetVakById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Vak WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int evenementId = Convert.ToInt32(reader["Evenement_ID"]);
                    char letter = Convert.ToChar(reader["Letter"]);
                    int aantalRijen = Convert.ToInt32(reader["Aantal_rijen"]);
                    int aantalStoelenPerRij = Convert.ToInt32(reader["Aantal_stoelen_per_rij"]);
                    Vak vak = new Vak(id, evenementId, letter, aantalRijen, aantalStoelenPerRij);
                    return vak;
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<Vak> GetAllVakkenByEvenementId(int evenementId)
        {
            List<Vak> vakken = new List<Vak>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Vak WHERE Evenement_ID = @Evenement_ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Evenement_ID", evenementId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            char letter = Convert.ToChar(reader["Letter"]);
                            int aantalRijen = Convert.ToInt32(reader["Aantal_rijen"]);
                            int aantalStoelenPerRij = Convert.ToInt32(reader["Aantal_stoelen_per_rij"]);
                            Vak vak = new Vak(id, evenementId, letter, aantalRijen, aantalStoelenPerRij);
                            vakken.Add(vak);
                        }
                    }
                }
            }

            return vakken;
        }

        public void UpdateVak(Vak vak)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Vak SET Letter=@Letter, Aantal_rijen=@Aantal_rijen, Aantal_stoelen_per_rij=@Aantal_stoelen_per_rij WHERE ID=@ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Letter", vak.Letter);
                command.Parameters.AddWithValue("@Aantal_rijen", vak.AantalRijen);
                command.Parameters.AddWithValue("@Aantal_stoelen_per_rij", vak.AantalStoelenPerRij);
                command.Parameters.AddWithValue("@ID", vak.ID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteVak(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Vak WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

}
