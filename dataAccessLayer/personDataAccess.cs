using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using dataAccessLayer.Objects;
using System.Data.SqlClient;
using System.Data;
using utilityLogger;

namespace dataAccessLayer
{
    public class personDataAccess
    {
        static string connectionStrings = ConfigurationManager.ConnectionStrings["Workout Routine"].ConnectionString;
        static logger _logger = new logger();
        public void addingPerson(personDAO addPerson)
        {
            try
            {
                //create a connection to a database using our connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_addPerson", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        //where the values are sent to the command
                        _command.Parameters.AddWithValue("@personFirstName", addPerson.personFirstName);
                        _command.Parameters.AddWithValue("@personLastName", addPerson.personLastName);
                        _command.Parameters.AddWithValue("@personAddress", addPerson.personFirstName);
                        _command.Parameters.AddWithValue("@personCity", addPerson.personCity);
                        _command.Parameters.AddWithValue("@personState", addPerson.personState);
                        _command.Parameters.AddWithValue("@personZip", addPerson.personZip);
                        _command.Parameters.AddWithValue("@personPhone", addPerson.personPhone);
                        _command.Parameters.AddWithValue("@personUsername", addPerson.personUsername);
                        _command.Parameters.AddWithValue("@personPassword", addPerson.personPassword);


                        // this is where the connection is open
                        _connection.Open();

                        // this is where we will execute the command
                        _command.ExecuteNonQuery();

                    }

                }

            }

            catch (Exception _error)
            {
                // putting error into a file
                _logger.logError(_error);
            }
        }
        public void deletingPerson(int deletePerson)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_deletePerson", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;

                        _command.Parameters.AddWithValue("@personID", deletePerson);
                        _connection.Open();

                        // this is where we will execute the command
                        _command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception _error)
            {
                _logger.logError(_error);
            }
        }
        public List<personDAO> listAllPerson()
        {
            // making a new instance of the list 
            List<personDAO> _personList = new List<personDAO>();
            try
            {

                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_viewPerson", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        _connection.Open();
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            // checking if the _reader has rows
                            if (_reader.HasRows)
                            {
                                // loop to go through the columns
                                while (_reader.Read())
                                {
                                    // new instance of to store all the values into persontolist.
                                    personDAO personToList = new personDAO();
                                    personToList.personID = _reader.GetInt32(_reader.GetOrdinal("personID"));
                                    personToList.personFirstName = (string)_reader["personFirstName"];
                                    personToList.personLastName = (string)_reader["personLastName"];
                                    personToList.personAddress = (string)_reader["personAddress"];
                                    personToList.personCity = (string)_reader["personCity"];
                                    personToList.personState = (string)_reader["personState"];
                                    personToList.personZip = (string)_reader["personZip"];
                                    personToList.personPhone = (string)_reader["personPhone"];
                                    personToList.FK_roleID = _reader.GetInt32(_reader.GetOrdinal("FK_roleID"));
                                    personToList.personUsername = (string)_reader["personUsername"];
                                    personToList.personPassword = (string)_reader["personPassword"];

                                    // adding values to varibale _personList.add
                                    _personList.Add(personToList);
                                }
                            }
                            else
                            {
                                // showing error if no data found
                                Console.WriteLine("No data found");
                            }
                        }
                    }
                }
            }
            catch (Exception _error)
            {
                _logger.logError(_error);
            }

            // returning person list
            return _personList;
        }
        public void updatePerson(personDAO updatePerson)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_updatePerson", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        //where the values are sen to the command
                        _command.Parameters.AddWithValue("@personID", updatePerson.personID);
                        _command.Parameters.AddWithValue("@personFirstName", updatePerson.personFirstName);
                        _command.Parameters.AddWithValue("@personLastName", updatePerson.personLastName);
                        _command.Parameters.AddWithValue("@personAddress", updatePerson.personAddress);
                        _command.Parameters.AddWithValue("@personCity", updatePerson.personCity);
                        _command.Parameters.AddWithValue("@personState", updatePerson.personState);
                        _command.Parameters.AddWithValue("@personZip", updatePerson.personZip);
                        _command.Parameters.AddWithValue("@personPhone", updatePerson.personPhone);
                        _command.Parameters.AddWithValue("@FK_roleID", updatePerson.FK_roleID);
                        _command.Parameters.AddWithValue("@personUsername", updatePerson.personUsername);
                        _command.Parameters.AddWithValue("@personPassword", updatePerson.personPassword);

                        // this is where the connection is open
                        _connection.Open();

                        // this is where we will execute the command
                        _command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception _error)
            {
                // putting error into a file
                _logger.logError(_error);
            }
        }
        public personDAO personSignIn(personDAO personSignIn)
        {
            personDAO _personSignIn = new personDAO();
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_personSignIn", _connection))
                    {

                        _command.CommandType = CommandType.StoredProcedure;

                        _command.Parameters.AddWithValue("@personUserName", personSignIn.personUsername);
                        _command.Parameters.AddWithValue("@personPassword", personSignIn.personPassword);

                        _connection.Open();

                        using (SqlDataReader _reader = _command.ExecuteReader())
                            if (_reader.HasRows)
                            {
                                while (_reader.Read())
                                {

                                    _personSignIn.personID = _reader.GetInt32(0);
                                    _personSignIn.personFirstName = _reader.GetString(1);
                                    _personSignIn.personLastName = _reader.GetString(2);
                                    _personSignIn.personAddress = _reader.GetString(3);
                                    _personSignIn.personCity = _reader.GetString(4);
                                    _personSignIn.personState = _reader.GetString(5);
                                    _personSignIn.personZip = _reader.GetString(6);
                                    _personSignIn.personPhone = _reader.GetString(7);
                                    _personSignIn.FK_roleID = _reader.GetInt32(8);
                                    _personSignIn.personUsername = _reader.GetString(9);
                                    _personSignIn.personPassword = _reader.GetString(10);

                                }
                            }
                            else
                            {
                                Console.WriteLine("No data found");
                            }
                    }
                }
            }
            catch (Exception _error)
            {
                // putting error into a file
                _logger.logError(_error);
            }

            return _personSignIn;
        }
        public List<rolesDAO> listAllRoles()
        {
            // making a new instance of the list 
            List<rolesDAO> _rolesList = new List<rolesDAO>();
            try
            {

                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_viewRole", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        _connection.Open();
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            // checking if the _reader has rows
                            if (_reader.HasRows)
                            {
                                // loop to go through the columns
                                while (_reader.Read())
                                {
                                    // new instance of to store all the values into persontolist.
                                    rolesDAO rolesToList = new rolesDAO();
                                    rolesToList.roleID = _reader.GetInt32(_reader.GetOrdinal("roleID"));
                                    rolesToList.roleName = (string)_reader["roleName"];
                                    rolesToList.roleDescription = (string)_reader["roleDescription"];

                                    // adding values to varibale _personList.add
                                    _rolesList.Add(rolesToList);
                                }
                            }
                            else
                            {
                                // showing error if no data found
                                Console.WriteLine("No data found");
                            }
                        }
                    }
                }
            }
            catch (Exception _error)
            {
                _logger.logError(_error);
            }

            // returning person list
            return _rolesList;
        }
        public void updateRoles(int roleID, int personID)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_updateRoles", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        //where the values are sen to the command

                        _command.Parameters.AddWithValue("@FK_roleID", roleID);
                        _command.Parameters.AddWithValue("@personID", personID);

                        // this is where the connection is open
                        _connection.Open();

                        // this is where we will execute the command
                        _command.ExecuteNonQuery();

                    }
                }
            }

            catch (Exception _error)
            {
                // putting error into a file
                _logger.logError(_error);
            }
        }
    }
}