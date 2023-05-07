using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;
using System.Data.SqlClient;
namespace DAL
{
    public class BezoekerDAL : IBezoekerDAL
    {
        private readonly string _connectionString;
        public BezoekerDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateBezoeker(Bezoeker bezoeker)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = "INSERT INTO Bezoeker (ID, Naam, Geboortedatum, Leeftijd, Groep_ID) " +
                            "VALUES (@ID, @Naam, @Geboortedatum, @Leeftijd, @Groep_ID)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", bezoeker.ID);
                    command.Parameters.AddWithValue("@Naam", bezoeker.Naam);
                    command.Parameters.AddWithValue("@Geboortedatum", bezoeker.Geboortedatum);
                    command.Parameters.AddWithValue("@Leeftijd", bezoeker.Leeftijd);
                    command.Parameters.AddWithValue("@Groep_ID", bezoeker.Groep_ID);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Bezoeker GetBezoekerById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = "SELECT * FROM Bezoeker WHERE ID = @ID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        var bezoeker = new Bezoeker
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            Naam = reader.GetString(reader.GetOrdinal("Naam")),
                            Geboortedatum = reader.GetDateTime(reader.GetOrdinal("Geboortedatum")),
                            Leeftijd = reader.GetInt32(reader.GetOrdinal("Leeftijd")),
                            Groep_ID = reader.IsDBNull(reader.GetOrdinal("Groep_ID")) ? null : reader.GetInt32(reader.GetOrdinal("Groep_ID"))
                        };

                        return bezoeker;
                    }
                }
            }
        }

        public List<Bezoeker> GetAllBezoekers()
        {
            List<Bezoeker> bezoekers = new List<Bezoeker>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Bezoeker", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string naam = (string)reader["Naam"];
                    DateTime geboortedatum = (DateTime)reader["Geboortedatum"];
                    int leeftijd = (int)reader["Leeftijd"];
                    int? groepId = reader["Groep_ID"] as int?;

                    Bezoeker bezoeker = new Bezoeker
                    {
                        ID = id,
                        Naam = naam,
                        Geboortedatum = geboortedatum,
                        Leeftijd = leeftijd,
                        Groep_ID = groepId
                    };

                    bezoekers.Add(bezoeker);
                }
            }

            return bezoekers;
        }

        public void UpdateBezoeker(Bezoeker bezoeker)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE Bezoeker SET Naam = @Naam, Geboortedatum = @Geboortedatum, Leeftijd = @Leeftijd, Groep_ID = @Groep_ID WHERE ID = @ID", connection);

                command.Parameters.AddWithValue("@Naam", bezoeker.Naam);
                command.Parameters.AddWithValue("@Geboortedatum", bezoeker.Geboortedatum);
                command.Parameters.AddWithValue("@Leeftijd", bezoeker.Leeftijd);
                command.Parameters.AddWithValue("@Groep_ID", bezoeker.Groep_ID ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@ID", bezoeker.ID);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void DeleteBezoeker(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Bezoeker WHERE ID = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
 }
