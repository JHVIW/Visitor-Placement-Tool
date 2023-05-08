using System;
using System.Collections;
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
    public class GroepDAL : IGroepDAL
    {
        private readonly string _connectionString;
        private readonly EvenementDAL _evenementDAL;

        public GroepDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
            _evenementDAL = new EvenementDAL(configuration);
        }

        public void CreateGroep(Groep groep)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Groep (ID, Evenement_ID, Aanmeldingsdatum, Totaal_aantal_bezoekers, Kinderen_aantal, Volwassenen_aantal) VALUES (@ID, @Evenement_ID, @Aanmeldingsdatum, @Totaal_aantal_bezoekers, @Kinderen_aantal, @Volwassenen_aantal)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", groep.ID);
                command.Parameters.AddWithValue("@Evenement_ID", groep.Evenement_ID);
                command.Parameters.AddWithValue("@Aanmeldingsdatum", groep.Aanmeldingsdatum);
                command.Parameters.AddWithValue("@Totaal_aantal_bezoekers", groep.TotaalAantalBezoekers);
                command.Parameters.AddWithValue("@Kinderen_aantal", groep.KinderenAantal);
                command.Parameters.AddWithValue("@Volwassenen_aantal", groep.VolwassenenAantal);

                command.ExecuteNonQuery();
            }
        }

        public Groep GetGroepById(int groepId)
        {

            string query = "SELECT * FROM Groep WHERE ID = @GroepId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@GroepId", groepId);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int evenementId = reader.GetInt32(reader.GetOrdinal("Evenement_ID"));
                        DateTime aanmeldingsdatum = reader.GetDateTime(reader.GetOrdinal("Aanmeldingsdatum"));
                        int totaalAantalBezoekers = reader.GetInt32(reader.GetOrdinal("Totaal_aantal_bezoekers"));
                        int kinderenAantal = reader.GetInt32(reader.GetOrdinal("Kinderen_aantal"));
                        int volwassenenAantal = reader.GetInt32(reader.GetOrdinal("Volwassenen_aantal"));
                        return new Groep(groepId, evenementId, aanmeldingsdatum, totaalAantalBezoekers, kinderenAantal, volwassenenAantal);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public IEnumerable<Groep> GetAllGroepenByEvenementId(int evenementId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var groepen = new List<Groep>();
                var query = "SELECT * FROM Groep WHERE Evenement_ID = @EvenementId";

                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EvenementId", evenementId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var groep = new Groep(
                                id: (int)reader["ID"],
                                evenementId: (int)reader["Evenement_ID"],
                                aanmeldingsdatum: (DateTime)reader["Aanmeldingsdatum"],
                                totaalAantalBezoekers: (int)reader["Totaal_aantal_bezoekers"],
                                kinderenAantal: (int)reader["Kinderen_aantal"],
                                volwassenenAantal: (int)reader["Volwassenen_aantal"]
                            );

                            groepen.Add(groep);
                        }
                    }
                }

                return groepen;
            }
        }

        public void UpdateGroep(Groep groep)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Groep SET Aanmeldingsdatum=@Aanmeldingsdatum, Totaal_aantal_bezoekers=@TotaalAantalBezoekers, Kinderen_aantal=@KinderenAantal, Volwassenen_aantal=@VolwassenenAantal WHERE ID=@ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", groep.ID);
                command.Parameters.AddWithValue("@Aanmeldingsdatum", groep.Aanmeldingsdatum);
                command.Parameters.AddWithValue("@TotaalAantalBezoekers", groep.TotaalAantalBezoekers);
                command.Parameters.AddWithValue("@KinderenAantal", groep.KinderenAantal);
                command.Parameters.AddWithValue("@VolwassenenAantal", groep.VolwassenenAantal);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteGroep(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Groep WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
 }
