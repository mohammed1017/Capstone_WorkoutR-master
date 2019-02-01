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
using businessLogicLayer.Objects;

namespace persentation_WorkoutR.Controllers
{
    public class routineController : Controller
    {
        // making new instances of the presentation mapper 
        static presentationMapper _mapper = new presentationMapper();
        // making new instance of the business logic mapper
        static BL_mapper _blMapper = new BL_mapper();
        // new instance of routine data access
        static routineDataAccess _routineDataAccess = new routineDataAccess();
        // new instance of workout logic from business logic
        workoutLogic _workoutLogic = new workoutLogic();
        // new instance of the logger
        static logger _logger = new logger();

        // GET: routine
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addRoutine(routineModel _addRoutine)
        {
            if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3 && _addRoutine.FK_personID == (int)Session["personID"])
            {
                try
                {
                    // if model state is valid
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            // adding routine back to the database 
                            _routineDataAccess.addingRoutine(_mapper.map(_addRoutine));

                            // redirecting back to view Routine   
                            return RedirectToAction("viewRoutine");
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
            }
            // returning error page
            return View("Error");
        }

        [HttpPost]
        public ActionResult updateRoutine(routineModel _updateRoutine)
        {
            if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                try
                {
                    // if model state is valid
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            // updating the routine in database
                            _routineDataAccess.updateRoutine(_mapper.map(_updateRoutine));
                            // redirecting back to view routine
                            return RedirectToAction("viewRoutine");
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
            }
            // return error page
            return View("Error");
        }

        //HTTP GET______________________________________________________________________________

        [HttpGet]
        // making the action name to add routine
        [ActionName("addRoutine")]
        public ActionResult addRoutineGet(routineModel _addRoutine)
        {
            if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                // adding personID variable from session to the routine 
                _addRoutine.FK_personID = (int)Session["personID"];
                // getting the add routine view
                return View(_addRoutine);
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult viewRoutine()
        {
            if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                try
                {
                    // making int variable personid to view routines for that member
                    int _personID = (int)Session["personID"];

                    // new instance of view model 
                    viewModel viewRoutine = new viewModel();
                    // getting the list from view model to map it the data access to view all routines
                    viewRoutine.routineList = _mapper.map(_routineDataAccess.listAllRoutine(_personID));


                    //making a for loop to count total sets and reps and exercises for the routine
                    for (int i = 0; i < viewRoutine.routineList.Count(); i++)
                    {
                        // making an int variable to hold routineid
                        int _routineID = viewRoutine.routineList[i].routineID;
                        // make data access object with listing single routine
                        routineDAO routine = _routineDataAccess.listSingleRoutine(_personID, _routineID);
                        // calling in the business logic layer with the object and routine and person id's
                        _workoutLogic.addSets(_blMapper.map(routine), _routineID, _personID);
                    }

                    // updated view 
                    viewRoutine.routineList = _mapper.map(_routineDataAccess.listAllRoutine(_personID));
                    return View(viewRoutine);
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
        [ActionName("updateRoutine")]
        public ActionResult updateRoutineGet(routineModel routine)
        {
            if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                try
                {
                    //  making session id routine and person id with routine model
                    Session["routineID"] = routine.routineID;
                    Session["FK_personID"] = routine.FK_personID;

                    // returning view of routine 
                    return View(routine);
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
        public ActionResult deleteRoutine(int _deleteRoutine)
        {
            if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                try
                {
                    // deleting routine based on the routine id in the database
                    _routineDataAccess.deletingRoutine(_deleteRoutine);
                    // redirecting back to view routines
                    return RedirectToAction("viewRoutine");
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

    }
}