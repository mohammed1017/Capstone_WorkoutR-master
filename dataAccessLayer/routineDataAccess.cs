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
    public class routineDataAccess
    {
        static string connectionStrings = ConfigurationManager.ConnectionStrings["Workout Routine"].ConnectionString;
        static logger _logger = new logger();
        public void addingRoutine(routineDAO addRoutine)
        {
            try
            {
                //create a connection to a database using our connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_addRoutine", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        //where the values are sent to the command
                        _command.Parameters.AddWithValue("@routineName", addRoutine.routineName);
                        _command.Parameters.AddWithValue("@FK_personID", addRoutine.FK_personID);
                        _command.Parameters.AddWithValue("@login", addRoutine.login);
                        _command.Parameters.AddWithValue("@totalSets", addRoutine.totalSets);
                        _command.Parameters.AddWithValue("@totalReps", addRoutine.totalReps);
                        _command.Parameters.AddWithValue("@totalExercise", addRoutine.totalExercise);


                        // this is where the connection is open
                        _connection.Open();

                        // this is where we will execute the command
                        _command.ExecuteNonQuery();

                    }
                }
            }
            catch(Exception _error)
            {
                // putting error into a file
                _logger.logError(_error);
            }
        }
        public void deletingRoutine(int deleteRoutine)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_deleteRoutine", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;

                        _command.Parameters.AddWithValue("@routineID", deleteRoutine);
                        _connection.Open();

                        // this is where we will execute the command
                        _command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception _error)
            {
                _logger.logError(_error);
            }
        }
        public List<routineDAO> listAllRoutine(int personID)
        {
            // making a new instance of the list 
            List<routineDAO> _routineList = new List<routineDAO>();

            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_viewRoutine", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        _command.Parameters.AddWithValue("@personID", personID);

                        //attempt to open connection
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
                                    routineDAO routineToList = new routineDAO();
                                    routineToList.routineID = _reader.GetInt32(0);
                                    routineToList.routineName = (string)_reader["routineName"];
                                    routineToList.FK_personID = _reader.GetInt32(2);
                                    routineToList.login = _reader.GetDateTime(3);
                                    routineToList.totalSets = _reader.GetInt32(4);
                                    routineToList.totalReps= _reader.GetInt32(5);
                                    routineToList.totalExercise = _reader.GetInt32(6);


                                    // adding values to varibale _personList.add
                                    _routineList.Add(routineToList);
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
            catch(Exception _error)
            {
                _logger.logError(_error);
            }

            // returning routine list
            return _routineList;
        }
        public void updateRoutine(routineDAO updateRoutine)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_updateRoutine", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        //where the values are sent to the command
                        _command.Parameters.AddWithValue("@routineID", updateRoutine.routineID);
                        _command.Parameters.AddWithValue("@routineName", updateRoutine.routineName);
                        _command.Parameters.AddWithValue("@FK_personID", updateRoutine.FK_personID);
                        _command.Parameters.AddWithValue("@login", updateRoutine.login);
                        _command.Parameters.AddWithValue("@totalSets", updateRoutine.totalSets);
                        _command.Parameters.AddWithValue("@totalReps", updateRoutine.totalReps);
                        _command.Parameters.AddWithValue("@totalExercise", updateRoutine.totalExercise);

                        // this is where the connection is open
                        _connection.Open();

                        // this is where we will execute the command
                        _command.ExecuteNonQuery();

                    }
                }
            }
            catch(Exception _error)
            {
                // putting error into a file
                _logger.logError(_error);
            }
        }
        public void updateSetsReps(routineDAO _routineSetsReps, int routineID)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_updateSetsReps", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        //where the values are sen to the command

                        _command.Parameters.AddWithValue("@routineWSets", _routineSetsReps.totalSets);
                        _command.Parameters.AddWithValue("@routineWReps", _routineSetsReps.totalReps);
                        _command.Parameters.AddWithValue("@routineWExercise", _routineSetsReps.totalExercise);
                        _command.Parameters.AddWithValue("@routineID", routineID);

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
        public routineDAO listSingleRoutine(int personID,int routineID)
        {
            // making a new instance of the list 
            routineDAO _singleRoutine = new routineDAO();

            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_viewSingleRoutine", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        _command.Parameters.AddWithValue("@personID", personID);
                        _command.Parameters.AddWithValue("@routineID", routineID);
                    

                        //attempt to open connection
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

                                   
                                    _singleRoutine.routineName = (string)_reader["routineName"];                                    
                                    _singleRoutine.login = _reader.GetDateTime(_reader.GetOrdinal("login"));
                                    _singleRoutine.totalSets = _reader.GetInt32(_reader.GetOrdinal("totalSets"));
                                    _singleRoutine.totalReps = _reader.GetInt32(_reader.GetOrdinal("totalReps"));
                                    _singleRoutine.totalExercise = _reader.GetInt32(_reader.GetOrdinal("totalExercise"));

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

            // returning routine list
            return _singleRoutine;
        }
    }
}
