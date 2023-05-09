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
    public class EvenementDAL : IEvenementDAL
    {
        private readonly string _connectionString;

        public EvenementDAL(IConfiguration configuration)
        {
            _connectionString = "Server=mssqlstud.fhict.local;Database=dbi482609_eventtool;User Id=dbi482609_eventtool;Password=Rviw2003%;";
        }

        public void CreateEvenement(Evenement evenement)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                string query = "INSERT INTO Evenement (Naam, Datum, Maximum_aantal_bezoekers) VALUES (@Naam, @Datum, @MaxAantalBezoekers);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Naam", evenement.Naam);
                    command.Parameters.AddWithValue("@Datum", evenement.Datum);
                    command.Parameters.AddWithValue("@MaxAantalBezoekers", evenement.MaximumAantalBezoekers);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Evenement GetEvenementById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Evenement WHERE ID = @Id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var evenement = new Evenement
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            Naam = reader.GetString(reader.GetOrdinal("Naam")),
                            Datum = reader.GetDateTime(reader.GetOrdinal("Datum")),
                            MaximumAantalBezoekers = reader.GetInt32(reader.GetOrdinal("Maximum_aantal_bezoekers"))
                        };
                        return evenement;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public IEnumerable<Evenement> GetAllEvenementen()
        {
            string query = "SELECT * FROM Evenement";
            List<Evenement> evenementen = new List<Evenement>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Evenement evenement = new Evenement
                            {
                                ID = (int)reader["ID"],
                                Naam = (string)reader["Naam"],
                                Datum = (DateTime)reader["Datum"],
                                MaximumAantalBezoekers = (int)reader["Maximum_aantal_bezoekers"]
                            };

                            evenementen.Add(evenement);
                        }
                    }
                }
            }

            return evenementen;
        }

        public void UpdateEvenement(Evenement evenement)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Evenement SET Naam = @Naam, Datum = @Datum, Maximum_aantal_bezoekers = @MaximumAantalBezoekers WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", evenement.ID);
                    command.Parameters.AddWithValue("@Naam", evenement.Naam);
                    command.Parameters.AddWithValue("@Datum", evenement.Datum);
                    command.Parameters.AddWithValue("@MaximumAantalBezoekers", evenement.MaximumAantalBezoekers);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEvenement(int evenementId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Evenement WHERE ID = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", evenementId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
