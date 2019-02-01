using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dataAccessLayer;
using dataAccessLayer.Objects;
using persentation_WorkoutR.Models;
using utilityLogger;
using businessLogicLayer;
using System.Security.Cryptography;
using System.Text;

namespace persentation_WorkoutR.Controllers
{
    public class personController : Controller
    {
        // making new instance of logger
        static logger _logger = new logger();
        //making new instance of the mapper 
        static presentationMapper _mapper = new presentationMapper();
        // new insatance of data access for person
        static personDataAccess _personDataAccess = new personDataAccess();

        // hashing the password
        static string GetMd5Hash(MD5 md5Hash, string password)
        {
            // convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            //Create a new stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            //loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // return the hexadecimal string.
            return sBuilder.ToString();
        }
        // verify the hash against a string .
        static bool VerifyMd5Hash(MD5 md5Hash, string password, string hash)
        {
            //hash the inout
            string hashOfInput = GetMd5Hash(md5Hash, password);
            // create a Stringcomparer and compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        // GET: person
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult login(personModel _person)
        {
            try
            {
                // checking if model state is valid
                if (ModelState.IsValid)
                {
                    try
                    {
                        // setting up a user model to return from user  login
                        personModel _personMod = new personModel();

                        // hashing the password
                        using (MD5 md5hash = MD5.Create())
                        {

                            string hash = GetMd5Hash(md5hash, _person.personPassword);
                            // checking if hash password is same as input hash
                            if (VerifyMd5Hash(md5hash, _person.personPassword, hash))
                            {
                                // setting hashed password to person password
                                _person.personPassword = hash;
                            }
                        }


                        // filling user model object with value from mapped data access object
                        _personMod = _mapper.map(_personDataAccess.personSignIn(_mapper.map(_person)));
                        // use _userMod to fill session variable
                        Session["personID"] = _personMod.personID;
                        Session["personUsername"] = _personMod.personUsername;
                        Session["personPassword"] = _personMod.personPassword;
                        Session["FK_RoleID"] = _personMod.FK_roleID;


                        // checking  if username or password is null
                        if (Session["personUsername"] == null || Session["personPassword"] == null)
                        {
                            // returning back to sign in page 
                            return RedirectToAction("login");
                        }
                        else
                        {
                            // direct them to profile
                            return RedirectToAction("profile", "person");
                        }
                    }
                    catch (Exception _error)
                    {
                        // putting error into a file
                        _logger.logError(_error);
                    }
                }
                return View();
            }
            catch (Exception _error)
            {
                // putting error into a file
                _logger.logError(_error);
            }
            // returning them the error page
            return View("Error");
        }

        [HttpPost]
        public ActionResult register(personModel _addPerson)
        {
            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, _addPerson.personPassword);
                    _addPerson.personPassword = hash;
                }

                // checking if model state is valid
                if (ModelState.IsValid)
                {
                    try
                    {   // adding the person to the database                   
                        _personDataAccess.addingPerson(_mapper.map(_addPerson));

                        // returned them back to login
                        return View("login");
                    }
                    catch (Exception _error)
                    {
                        // putting error into a file
                        _logger.logError(_error);
                    }
                }
                return View();
            }
            catch (Exception _error)
            {
                // putting error into a file
                _logger.logError(_error);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult updatePerson(personModel _updatePerson)
        {

            try
            {
                // checking if role id matches to 1,2, or 3  and the current user
                if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3 && _updatePerson.personID == (int)Session["personID"])
                {
                    // checking if model state is valid
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            // update the profile in the database
                            _personDataAccess.updatePerson(_mapper.map(_updatePerson));
                            // redirecting to profile  
                            return RedirectToAction("profile", _updatePerson);
                        }
                        catch (Exception _error)
                        {
                            // putting error into a file
                            _logger.logError(_error);
                        }
                    }

                    return View();
                }
            }
            catch (Exception _error)
            {
                // putting error into a file
                _logger.logError(_error);
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult updatePassPerson(personModel _updatePerson)
        {
            try
            {
                // checking if role id matches to 1,2, or 3  and the current user
                if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3 && _updatePerson.personID == (int)Session["personID"])
                {
                    using (MD5 md5Hash = MD5.Create())
                    {
                        string hash = GetMd5Hash(md5Hash, _updatePerson.personPassword);
                        _updatePerson.personPassword = hash;
                    }
                    // checking if model state is valid
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            // update the profile in the database
                            _personDataAccess.updatePerson(_mapper.map(_updatePerson));

                            Session["personUsername"] = _updatePerson.personUsername;
                            Session["personPassword"] = _updatePerson.personPassword;
                            // redirecting to profile  
                            return RedirectToAction("profile", _updatePerson);
                        }
                        catch (Exception _error)
                        {
                            // putting error into a file
                            _logger.logError(_error);
                        }
                    }
                    return View();
                }
            }
            catch (Exception _error)
            {
                // putting error into a file
                _logger.logError(_error);
            }
            return View("Error");
        }

        //HTTP GET______________________________________________________________________________

        [HttpGet]
        public ActionResult login()
        {
            // checking if user already signed in
            if (Session["personUsername"] != null || Session["personPassword"] != null)
            {
                // making new instance of person model
                personModel person = new personModel();
                person.personID = (int)Session["personID"];
                // redirecting them back to profile page
                return RedirectToAction("profile", person);
            }
            else
            {
                // retuning login view
                return View();
            }
        }

        [HttpGet]
        public ActionResult profile(personModel person)
        {
            if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                // making new instance of person model called current person
                personModel currentPerson = new personModel();

                // adding session variable username and password to the current person model
                currentPerson.personUsername = (string)Session["personUsername"];
                currentPerson.personPassword = (string)Session["personPassword"];

                // using the data access to get the information of the current user signed in
                currentPerson = _mapper.map(_personDataAccess.personSignIn(_mapper.map(currentPerson)));

                // returning the view with the currrent person
                return View(currentPerson);
            }

            return View("Error");
        }

        [HttpGet]
        public ActionResult register()
        {
            // checking if user already signed in
            if (Session["personUsername"] != null || Session["personPassword"] != null)
            {
                // making new instance of person model
                personModel person = new personModel();
                person.personID = (int)Session["personID"];

                // redirect them back to profile
                return RedirectToAction("profile", person);
            }
            else
            {
                // retuning Register view
                return View();
            }

        }

        [HttpGet]
        public ActionResult viewPerson()
        {
            try
            {
                // checking if the role id is 2 or 3 to view the memebers
                if ((int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
                {

                    // making new insatance of view model called person view
                    viewModel personView = new viewModel();

                    // getting access to the database to list all the members
                    personView.personList = _mapper.map(_personDataAccess.listAllPerson());

                    // storing the person list into the role list in preson view model  
                    personView.roleList = _mapper.map(_personDataAccess.listAllRoles());

                    Session["viewRoles"] = personView.roleList;
                    return View(personView);
                }
            }
            catch (Exception _error)
            {
                // putting error into a file
                _logger.logError(_error);
            }
            return View("Error");
        }

        [HttpGet]
        // making the action name update person
        [ActionName("updatePerson")]
        public ActionResult updateProfileGet(personModel _updatePerson)
        {
            if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3 && _updatePerson.personID == (int)Session["personID"])
            {
                try
                {
                    // make ing person id and role id set to session variable role and person ID
                    _updatePerson.personID = (int)Session["personID"];
                    _updatePerson.FK_roleID = (int)Session["FK_roleID"];
                    _updatePerson.personUsername = (string)Session["personUsername"];
                    _updatePerson.personPassword = (string)Session["personPassword"];

                    // retruning view with updated profile
                    return View(_updatePerson);
                }
                catch (Exception _error)
                {
                    // putting error into a file
                    _logger.logError(_error);
                }
            }
            // returning error
            return View("Error");
        }

        [HttpGet]
        public ActionResult logout()
        {
            // clearing session
            Session.Clear();
            // returning back to home page
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult deletePerson(int _deletePerson)
        {
            // checking if role ID is 3
            if ((int)Session["FK_RoleID"] == 3)
            {
                try
                {
                    // deleting the person in database with the personID
                    _personDataAccess.deletingPerson(_deletePerson);

                    // return back to person view
                    return RedirectToAction("viewPerson");
                }
                catch (Exception _error)
                {
                    // putting error into a file
                    _logger.logError(_error);
                }
            }
            // return to error page
            return View("Error");
        }

        [HttpGet]
        // setting action name to update roles
        [ActionName("updateRoles")]
        public ActionResult updateRolesG(int roleID, int personID)
        {
            // checking if roleID is 3
            if ((int)Session["FK_roleID"] == 3)
            {
                try
                {
                    // updating the roles based of role and person ID
                    _personDataAccess.updateRoles(roleID, personID);

                    // redirecting to view Person
                    return RedirectToAction("viewPerson");

                }
                catch (Exception _error)
                {
                    // putting error into a file
                    _logger.logError(_error);
                }
            }

            return View("Error");
        }

        [HttpGet]
        // making the action name update person
        [ActionName("updatePassPerson")]
        public ActionResult updatePassPersonGet(personModel _updatePassPerson)
        {
            if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3 && _updatePassPerson.personID == (int)Session["personID"])
            {
                try
                {
                    // make ing person id and role id set to session variable role and person ID
                    _updatePassPerson.personID = (int)Session["personID"];
                    _updatePassPerson.FK_roleID = (int)Session["FK_roleID"];

                    // retruning view with updated profile
                    return View(_updatePassPerson);
                }
                catch (Exception _error)
                {
                    // putting error into a file
                    _logger.logError(_error);
                }
            }
            // returning error
            return View("Error");
        }
    }
}
