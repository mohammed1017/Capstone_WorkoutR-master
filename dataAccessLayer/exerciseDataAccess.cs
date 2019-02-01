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
    public class exerciseDataAccess
    {
        static string connectionStrings = ConfigurationManager.ConnectionStrings["Workout Routine"].ConnectionString;
        static logger _logger = new logger();
        public void addingExercise(exerciseDAO addExercise)
        {
            try
            {
                //create a connection to a database using our connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_addExercise", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        //where the values are sent to the command
                        _command.Parameters.AddWithValue("@exerciseName", addExercise.exerciseName);
                        _command.Parameters.AddWithValue("@exerciseDescription", addExercise.exerciseDescription);
                        _command.Parameters.AddWithValue("@FK_bodyPart", addExercise.FK_bodyPart);

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
        public void deletingExercise(int deleteExercise)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_deleteExercise", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;

                        _command.Parameters.AddWithValue("@exerciseID", deleteExercise);
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
        public List<exerciseDAO> listAllExercise()
        {
            // making a new instance of the list 
            List<exerciseDAO> _exerciseList = new List<exerciseDAO>();

            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_viewExercise", _connection))
                    {
                        // specify what type of command is to be used
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
                                    exerciseDAO exerciseToList = new exerciseDAO();
                                    exerciseToList.exerciseID = _reader.GetInt32(_reader.GetOrdinal("exerciseID"));
                                    exerciseToList.exerciseName = (string)_reader["exerciseName"];
                                    exerciseToList.exerciseDescription = (string)_reader["exerciseDescription"];
                                    exerciseToList.FK_bodyPart = _reader.GetInt32(_reader.GetOrdinal("FK_bodyPart"));

                                    // adding values to varibale _personList.add
                                    _exerciseList.Add(exerciseToList);
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

            // returning exercise list
            return _exerciseList;
        }
        public void updateExercise(exerciseDAO updateExercise)
        {
            try
            {
                //create a connection to a database using our connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_updateExercise", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        //where the values are sent to the command
                        _command.Parameters.AddWithValue("@exerciseID", updateExercise.exerciseID);
                        _command.Parameters.AddWithValue("@exerciseName", updateExercise.exerciseName);
                        _command.Parameters.AddWithValue("@exerciseDescription", updateExercise.exerciseDescription);
                        _command.Parameters.AddWithValue("@FK_bodyPart", updateExercise.FK_bodyPart);

                        // this is where the connection is open
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
        public List<exerciseDAO> bodyPartExercise(int FK_bodyPart)
        {
            // making a new instance of the list 
            List<exerciseDAO> _exerciseList = new List<exerciseDAO>();

            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_viewExercise", _connection))
                    {
                        // specify what type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        //where the values are sent to the command
                        _command.Parameters.AddWithValue("@FK_bodyPart",FK_bodyPart );

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
                                    exerciseDAO exerciseToList = new exerciseDAO();
                                    exerciseToList.exerciseID = _reader.GetInt32(_reader.GetOrdinal("exerciseID"));
                                    exerciseToList.exerciseName = (string)_reader["exerciseName"];
                                    exerciseToList.exerciseDescription = (string)_reader["exerciseDescription"];

                                    // adding values to varibale _personList.add
                                    _exerciseList.Add(exerciseToList);
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

            // returning exercise list
            return _exerciseList;
        }
        public exerciseDAO exercise (int exerciseID)
        {
            List<exerciseDAO> listExercise = listAllExercise();

            foreach (exerciseDAO exercise in listExercise)
            {
                if (exercise.exerciseID == exerciseID)
                {
                    return exercise;
                }
            }
            return new exerciseDAO();
            
        }
        public exerciseDAO exercise(string exerciseName)
        {
            List<exerciseDAO> listExercise = listAllExercise();

            foreach (exerciseDAO exercise in listExercise)
            {
                if (exercise.exerciseName == exerciseName)
                {
                    return exercise;
                }
            }
            return new exerciseDAO();

        }
    }
}
