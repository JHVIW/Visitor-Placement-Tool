﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DTO;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
namespace DAL
{
    public class BezoekerDAL : IBezoekerDAL
    {
        private readonly string _connectionString;

        public BezoekerDAL(IConfiguration configuration)
        {
            _connectionString = "Server=mssqlstud.fhict.local;Database=dbi482609_eventtool;User Id=dbi482609_eventtool;Password=Rviw2003%;";
        }

        public void CreateBezoeker(Bezoeker bezoeker)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = "INSERT INTO Bezoeker (Evenement_ID, Naam, Geboortedatum, Groep_ID) " +
                            "VALUES (@EvenementID, @Naam, @Geboortedatum, @Groep_ID)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EvenementID", bezoeker.Evenement_ID);
                    command.Parameters.AddWithValue("@Naam", bezoeker.Naam);
                    command.Parameters.AddWithValue("@Geboortedatum", bezoeker.Geboortedatum);
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
                            Groep_ID = reader.IsDBNull(reader.GetOrdinal("Groep_ID")) ? null : reader.GetInt32(reader.GetOrdinal("Groep_ID")),
                            Evenement_ID = reader.GetInt32(reader.GetOrdinal("Evenement_ID")),
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
                    int? groepId = reader["Groep_ID"] as int?;
                    int evenementId = (int)reader["Evenement_ID"];

                    Bezoeker bezoeker = new Bezoeker
                    {
                        ID = id,
                        Naam = naam,
                        Geboortedatum = geboortedatum,
                        Groep_ID = groepId,
                        Evenement_ID = evenementId
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
                SqlCommand command = new SqlCommand("UPDATE Bezoeker SET Naam = @Naam, Geboortedatum = @Geboortedatum, Leeftijd = @Leeftijd, Groep_ID = @Groep_ID, Evenement_ID = @Evenement_ID WHERE ID = @ID", connection);

                command.Parameters.AddWithValue("@Naam", bezoeker.Naam);
                command.Parameters.AddWithValue("@Geboortedatum", bezoeker.Geboortedatum);
                command.Parameters.AddWithValue("@Groep_ID", bezoeker.Groep_ID ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@ID", bezoeker.ID);
                command.Parameters.AddWithValue("@Evenement_ID", bezoeker.Evenement_ID);

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
