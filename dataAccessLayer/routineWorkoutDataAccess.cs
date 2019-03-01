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
    public class routineWorkoutDataAccess
    {
        static string connectionStrings = ConfigurationManager.ConnectionStrings["Workout Routine"].ConnectionString;
        static logger _logger = new logger();
        public void addingRoutineWorkout(routineWorkoutDAO addRoutineWorkout)
        {
            try
            {
                //create a connection to a database using our connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_addRoutineWorkout", _connection))
                    {
                        // specify what type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        //where the values are sent to the command
                        _command.Parameters.AddWithValue("@FK_exerciseID", addRoutineWorkout.FK_exerciseID);
                        _command.Parameters.AddWithValue("@FK_routineWorkoutID", addRoutineWorkout.FK_routineWorkoutID);
                        _command.Parameters.AddWithValue("@routineWSets", addRoutineWorkout.routineWSets);
                        _command.Parameters.AddWithValue("@routineWReps", addRoutineWorkout.routineWReps);
                        _command.Parameters.AddWithValue("@routineWRest", addRoutineWorkout.routineWRest);

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
        public void deletingRoutineWorkout(int deleteRoutineWorkout)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_deleteRoutineWorkout", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;

                        _command.Parameters.AddWithValue("@routineWorkoutID", deleteRoutineWorkout);
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
        public List<routineWorkoutDAO> listAllRoutineWorkout(int personID, int routineID)
        {
            // making a new instance of the list 
            List<routineWorkoutDAO> _routineWorkoutList = new List<routineWorkoutDAO>();
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_viewRoutineWorkout", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        _command.Parameters.AddWithValue("@personID", personID);
                        _command.Parameters.AddWithValue("@routineID", routineID);


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
                                    routineWorkoutDAO routineWorkoutToList = new routineWorkoutDAO();
                                    routineWorkoutToList.routineWorkoutID = _reader.GetInt32(_reader.GetOrdinal("routineWorkoutID"));
                                    routineWorkoutToList.exerciseName = (string)_reader["exerciseName"];
                                    routineWorkoutToList.routineName = (string)_reader["routineName"];
                                    routineWorkoutToList.routineWSets = _reader.GetByte(_reader.GetOrdinal("routineWSets"));
                                    routineWorkoutToList.routineWReps = _reader.GetByte(_reader.GetOrdinal("routineWReps"));
                                    routineWorkoutToList.routineWRest = _reader.GetInt16(_reader.GetOrdinal("routineWRest"));



                                    // adding values to varibale _personList.add
                                    _routineWorkoutList.Add(routineWorkoutToList);
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

            // returning routine workou list
            return _routineWorkoutList;
        }
        public void updateRoutineWorkout(routineWorkoutDAO updateRoutineWorkout)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_updateRoutineWorkout", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        //where the values are sen to the command
                        _command.Parameters.AddWithValue("@routineWorkoutID", updateRoutineWorkout.routineWorkoutID);
                        _command.Parameters.AddWithValue("@FK_exerciseID", updateRoutineWorkout.FK_exerciseID);
                        _command.Parameters.AddWithValue("@FK_routineWorkoutID", updateRoutineWorkout.FK_routineWorkoutID);
                        _command.Parameters.AddWithValue("@routineWSets", updateRoutineWorkout.routineWSets);
                        _command.Parameters.AddWithValue("@routineWReps", updateRoutineWorkout.routineWReps);
                        _command.Parameters.AddWithValue("@routineWRest", updateRoutineWorkout.routineWRest);

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


        public void addWeights(weightsDAO addWeights)
        {
            try
            {
                //create a connection to a database using our connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_addingWeights", _connection))
                    {
                        // specify what type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        //where the values are sent to the command
                        _command.Parameters.AddWithValue("@lbs", addWeights.lbs);
                        _command.Parameters.AddWithValue("@FK_routineWorkID", addWeights.FK_routineWorkID);
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
        public List<weightsDAO> listAllWeights(int FK_routineWorkID)
        {
                        // making a new instance of the list 
            List<weightsDAO> _weightsList = new List<weightsDAO>();
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_viewRoutineWorkout", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        _command.Parameters.AddWithValue("@FK_routineWorkID", FK_routineWorkID);


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
                                    weightsDAO weightsToList = new weightsDAO();
                                    weightsToList.WeightsID = _reader.GetInt32(_reader.GetOrdinal("weightsID"));
                                    weightsToList.lbs = _reader.GetInt32(_reader.GetOrdinal("lbs"));
                                    weightsToList.FK_routineWorkID = _reader.GetInt32(_reader.GetOrdinal("FK_routineWorkID"));



                                    // adding values to varibale _personList.add
                                    _weightsList.Add(weightsToList);
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

            // returning routine workou list
            return _weightsList;
        }
        public void updateWeights(weightsDAO updateWeights)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_updateWeights", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        //where the values are sen to the command
                        _command.Parameters.AddWithValue("@weightsID", updateWeights.WeightsID);
                        _command.Parameters.AddWithValue("@lbs", updateWeights.lbs);
                        _command.Parameters.AddWithValue("@FK_routineWorkID", updateWeights.FK_routineWorkID);


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
