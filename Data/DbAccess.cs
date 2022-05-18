using ApartmentInventoryAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ApartmentInventoryAPI.Data
{
    // Ideally this should be written as a data access library file and referenced by the API. 
    // It should also use data sets and the entity framework.
    public class DbAccess
    {
        // Get the connection string for the DB from the web config file.
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        // Get a list of all apartments.
        public IEnumerable<Apartment> GetApartmentList()
        {
            return GetAptList("GetApartmentList");
        }

        // Get apartment by ID
        public Apartment GetApartmentById(int id)
        {
            return GetSingleApartment("GetApartmentById", id);
        }

        // Get the apartment by code.
        public Apartment GetApartmentByCode(string code)
        {
            return GetSingleApartment("GetApartmentByCode", 0, code);
        }

        // Get Apartment list by block.
        public IEnumerable<Apartment> GetApartmentsByBlock(string block)
        {
            return GetAptList("GetApartmentByBlock", block);
        }

        // Get all available apartments.
        public IEnumerable<Apartment> GetAvailableApartments()
        {
            return GetAptList("GetAvailableApartments");
        }

        private IEnumerable<Apartment> GetAptList(string method, string param = "")
        {
            List<Apartment> aptList = new List<Apartment>();

            SqlCommand command = new SqlCommand(method, con);
            command.CommandType = CommandType.StoredProcedure;

            // Check to see if the param is empty.
            if (!String.IsNullOrEmpty(param))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Block",
                    SqlDbType = SqlDbType.NChar,
                    Size = 10,
                    Value = param,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameter);
            }
            con.Open();

            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                // Traverse the results adding each apartment to  the list.
                while (dataReader.Read())
                {
                    aptList.Add(new Apartment
                    {
                        id = (int)dataReader["id"],
                        code = ((string)dataReader["code"]).Trim(),
                        location = (string)dataReader["site_location"],
                        apartment_number = (int)dataReader["number"],
                        block = ((string)dataReader["block"]).Trim(),
                        isOccupied = (int)dataReader["is_occupied"],
                        leaseExpiryDate = (DateTime)dataReader["lease_expiry"]
                    });
                }
            }
            con.Close();
            return aptList;
        }

        // Get a single apartment by Id or Code.
        private Apartment GetSingleApartment(string method, int id = 0, string code = "")
        {
            Apartment apartment = new Apartment();
            SqlParameter parameter = new SqlParameter();

            SqlCommand command = new SqlCommand(method, con);
            command.CommandType = CommandType.StoredProcedure;

            switch (method)
            {
                case "GetApartmentById":
                    parameter.ParameterName = "@Id";
                    parameter.SqlDbType = SqlDbType.Int;
                    parameter.Value = id;

                    break;
                case "GetApartmentByCode":
                    parameter.ParameterName = "@Code";
                    parameter.SqlDbType = SqlDbType.NChar;
                    parameter.Size = 10;
                    parameter.Value = code;
                    break;
                default:
                    break;
            }

            parameter.Direction = ParameterDirection.Input;
            command.Parameters.Add(parameter);

            con.Open();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                // Traverse the results adding each apartment to  the list.
                if (dataReader.Read())
                {
                    apartment.id = (int)dataReader["id"];
                    apartment.code = ((string)dataReader["code"]).Trim();
                    apartment.location = (string)dataReader["site_location"];
                    apartment.apartment_number = (int)dataReader["number"];
                    apartment.block = ((string)dataReader["block"]).Trim();
                    apartment.isOccupied = (int)dataReader["is_occupied"];
                    apartment.leaseExpiryDate = (DateTime)dataReader["lease_expiry"];
                }
            }
            con.Close();
            return apartment;
        }

        // Insert a new apartment record into the table.
        public void AddNewApartment(Apartment apt)
        {
            SqlCommand command = new SqlCommand("AddNewApartment", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@code", apt.code);
            command.Parameters.AddWithValue("@site_location", apt.location);
            command.Parameters.AddWithValue("@number", apt.apartment_number);
            command.Parameters.AddWithValue("@block", apt.block);
            command.Parameters.AddWithValue("@isOccupied", apt.isOccupied);
            command.Parameters.AddWithValue("@leaseExpiry", apt.leaseExpiryDate);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }

        // Update an apartment based on id.
        internal void UpdateApartment(int id, Apartment apt)
        {
            SqlCommand command = new SqlCommand("UpdateApartment", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@code", apt.code);
            command.Parameters.AddWithValue("@site_location", apt.location);
            command.Parameters.AddWithValue("@number", apt.apartment_number);
            command.Parameters.AddWithValue("@block", apt.block);
            command.Parameters.AddWithValue("@isOccupied", apt.isOccupied);
            command.Parameters.AddWithValue("@leaseExpiry", apt.leaseExpiryDate);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }

        // Delete an apartment from the table based on the id.
        internal void DeleteApartment(int id)
        {
            SqlCommand command = new SqlCommand("DeleteApartment", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", id);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}