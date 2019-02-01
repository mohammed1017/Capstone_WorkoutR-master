using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dataAccessLayer;
using persentation_WorkoutR.Models;
using utilityLogger;
using businessLogicLayer;
using businessLogicLayer.Objects;

namespace persentation_WorkoutR.Controllers
{
    public class routineWorkoutController : Controller
    {
        // making new instance of the presentation mapper
        static presentationMapper _mapper = new presentationMapper();
        // making new instance if routine Workout data access 
        static routineWorkoutDataAccess _routineWorkoutDataAccess = new routineWorkoutDataAccess();
        // making new instance of exercise data access
        static exerciseDataAccess _exerciseData = new exerciseDataAccess();
        // making new instance of bodypart data access
        static bodyPartDataAccess _bodyPartData = new bodyPartDataAccess();
        // making new instance of logger
        static logger _logger = new logger();

        // GET: routine
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addRoutineWorkout(routineWorkoutModel _addRoutineWorkout)
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
                            // using session varible to get the FK routineWorkoutID 
                            _addRoutineWorkout.FK_routineWorkoutID = (int)Session["FK_routineWorkoutID"];
                            // then adding the the routin workout to the database with the ID
                            _routineWorkoutDataAccess.addingRoutineWorkout(_mapper.map(_addRoutineWorkout));

                            // making new instance of routine model
                            routineModel modelforID = new routineModel();
                            // setting routineID for modelforID to addingRoutineWorkout FK routineWorkout ID
                            modelforID.routineID = _addRoutineWorkout.FK_routineWorkoutID;

                            // return back to routineWorkout page that belongs to the modelforID
                            return RedirectToAction("viewRoutineWorkout", modelforID);
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
            return View("Error");
        }

        [HttpPost]
        public ActionResult updateRoutineWorkout(routineWorkoutModel _updateRoutineWorkout)
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
                            // getting the FK_routineWorkoutID from session variable FK_routineWorkoutID 
                            _updateRoutineWorkout.FK_routineWorkoutID = (int)Session["FK_routineWorkoutID"];

                            // updating the the routine exercises based to the id 
                            _routineWorkoutDataAccess.updateRoutineWorkout(_mapper.map(_updateRoutineWorkout));

                            // making new instance of routine model
                            routineModel modelforid = new routineModel();
                            // setting routineID to updated FK routineWorkoutID
                            modelforid.routineID = _updateRoutineWorkout.FK_routineWorkoutID;

                            // returning back the page view routine workout
                            return RedirectToAction("viewRoutineWorkout", modelforid);
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
            return View("Error");
        }

        //HTTP GET______________________________________________________________________________

        [HttpGet]
        // setting action name to addRoutineWorkout
        [ActionName("addRoutineWorkout")]
        public ActionResult addRoutineWorkoutG()
        {
            if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                try
                {
                    // making new instance of the view model
                    viewModel viewExercise = new viewModel();
                    // using the database of all exercise and adding back to exercise list
                    viewExercise.exerciseList = _mapper.map(_exerciseData.listAllExercise());

                   
                    viewExercise.bodyPartList = _mapper.map(_bodyPartData.listAllBodyPart());

                    // making new instance of routineWorkout model
                    routineWorkoutModel routineWorkoutModel = new routineWorkoutModel();
                    // populating the routineWorkoutmodel exercise list with view model exercise listt
                    routineWorkoutModel.exerciseList = viewExercise.exerciseList;
                    routineWorkoutModel.bodyPartList = viewExercise.bodyPartList;
                    // setting variable view exercise to the routine workout model exercise list
                    Session["viewExercise"] = routineWorkoutModel.exerciseList;
                    Session["viewBodyPart"] = routineWorkoutModel.bodyPartList;

                    // return the view  with routine workout model
                    return View(routineWorkoutModel);
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
        public ActionResult viewRoutineWorkout(routineModel _viewRoutine)
        {
            if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {

                try
                {
                    // setting personID to the session varibale personID
                    int _personID = (int)Session["personID"];

                    // showing routineID in url
                    // setting routineID to the view routine routineID
                    int _routineID = _viewRoutine.routineID;

                    // making new instance of the view model
                    viewModel viewRoutineW = new viewModel();
                    // populating routine workout list from the batabase that matches personID and routineID
                    viewRoutineW.routineWorkoutList = _mapper.map(_routineWorkoutDataAccess.listAllRoutineWorkout(_personID, _routineID));

                    // setting session variable FK_routineWorkoutID to view routine. routineID
                    Session["FK_routineWorkoutID"] = _viewRoutine.routineID;

                    // return back view with view routine Workout
                    return View(viewRoutineW);
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


        [HttpGet]
        // setting action name 
        [ActionName("updateRoutineWorkout")]
        public ActionResult updateRoutineWorkoutGet(routineWorkoutModel routineWorkout)
        {
            if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                try
                {
                    // making new instance of view model
                    viewModel viewExercise = new viewModel();
                    // poplating exercise model, exercise list from database
                    viewExercise.exerciseList = _mapper.map(_exerciseData.listAllExercise());
                    Session["viewBodyPart"] = _mapper.map(_bodyPartData.listAllBodyPart());

                    routineWorkoutModel routineWorkoutModel = new routineWorkoutModel();
                    routineWorkoutModel.exerciseList = viewExercise.exerciseList;
                    Session["viewExercise"] = routineWorkoutModel.exerciseList;


                    // setting session varibale routineWorkoutID to routineWorkoutID
                    Session["routineWorkoutID"] = routineWorkout.routineWorkoutID;

                    // setting exercise list to view exercise model exercise list
                    routineWorkout.exerciseList = viewExercise.exerciseList;

                    exerciseModel exercise = _mapper.map(_exerciseData.exercise(routineWorkout.exerciseName));
                    routineWorkout.FK_exerciseID = exercise.exerciseID;
                    routineWorkout.bodyPartID = exercise.FK_bodyPart;
                    
                    // return view, routine Workout
                    return View(routineWorkout);
                }
                catch (Exception _error)
                {
                    // putting error into a file
                    _logger.logError(_error);
                }
            }
            // return back error page
            return View("Error");
        }

        [HttpGet]
        public ActionResult deleteRoutineWorkout(int _deleteRoutineWorkout)
        {
            if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                try
                {
                    // deleting the routineWorkout based to the ID from the database
                    _routineWorkoutDataAccess.deletingRoutineWorkout(_deleteRoutineWorkout);

                    // making new instance of the routine
                    routineModel modelforid = new routineModel();

                    // setting routineID to the session fk_routineworkout ID
                    modelforid.routineID = (int)Session["FK_routineWorkoutID"];

                    // redirect back to new routineworkout using model for id model
                    return RedirectToAction("viewRoutineWorkout", modelforid);
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
    }
}
