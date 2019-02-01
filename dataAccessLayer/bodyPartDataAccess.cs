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
    public class bodyPartDataAccess
    {
        // to hold my connection strings to connect to database
        static string connectionStrings = ConfigurationManager.ConnectionStrings["Workout Routine"].ConnectionString;

        static logger _logger = new logger();
        // adding a body part method
        public void addingBodyPart(bodyPartDAO addBodyPart)
        {
            try
            {
                // using sql connection connecting strings
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_addBodyPart", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        //where the values are sent to the command
                        _command.Parameters.AddWithValue("@bodyPartName", addBodyPart.bodyPartName);

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
        // deleting a body part method in database
        public void deletingBodyPart(bodyPartDAO deleteBodyPart)
        {
            try
            {
                // using a sql connection connection strings
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_deleteBodyPart", _connection))
                    {
                        // specifying what type of command to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        // where the values are send to the command
                        _command.Parameters.AddWithValue("@bodyPartID", deleteBodyPart.bodyPartID);
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
        // viewing all body part in database
        public List<bodyPartDAO> listAllBodyPart()
        {
            // making a new instance of the list 
            List<bodyPartDAO> _bodyPartList = new List<bodyPartDAO>();

            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_viewBodyPart", _connection))
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
                                    bodyPartDAO bodyPartToList = new bodyPartDAO();
                                    bodyPartToList.bodyPartID = _reader.GetInt32(0);
                                    bodyPartToList.bodyPartName = _reader.GetString(1);


                                    // adding values to varibale _personList.add
                                    _bodyPartList.Add(bodyPartToList);
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
                // putting error into a file
                _logger.logError(_error);
            }

            return _bodyPartList;
        }
        public void updateBodyPart(bodyPartDAO updateBodyPart)
        {
            try
            {
                //create a connection to a database using our connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand _command = new SqlCommand("sp_updateBodyPart", _connection))
                    {
                        // specify whay type of command is to be used
                        _command.CommandType = CommandType.StoredProcedure;

                        //where the values are sen to the command
                        _command.Parameters.AddWithValue("@bodyPartID", updateBodyPart.bodyPartID);
                        _command.Parameters.AddWithValue("@bodyPartName", updateBodyPart.bodyPartName);


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
    }
}
