using dataAccessLayer;
using persentation_WorkoutR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using utilityLogger;

namespace persentation_WorkoutR.Controllers
{
    public class weightsController : Controller
    {
        // making new instance of the presentation mapper
        static presentationMapper _mapper = new presentationMapper();

        // making new instance if routine Workout data access 
        static routineWorkoutDataAccess _routineWorkoutDataAccess = new routineWorkoutDataAccess();

        // making new instance of logger
        static logger _logger = new logger();

        [HttpPost]
        public ActionResult addWeights(weightsModel _addWeights)
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
                            Session["weightsID"] = _addWeights.WeightsID;

                            _routineWorkoutDataAccess.addWeights(_mapper.map(_addWeights));

                            routineWorkoutModel modelForID = new routineWorkoutModel();
                            modelForID.routineWorkoutID = _addWeights.FK_routineWorkID;

                            // return back to routineWorkout page that belongs to the modelforID
                            return RedirectToAction("viewRoutineWorkout", "routineWorkout", modelForID);
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
        public ActionResult updateWeights(weightsModel _updateWeights)
        {
            if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {


                // if model state is valid
                if (ModelState.IsValid)
                {
                    try
                    {
                        // getting the FK_routineWorkoutID from session variable FK_routineWorkoutID 
                        _updateWeights.FK_routineWorkID = (int)Session["FK_routineWorkID"];

                        // updating the the routine exercises based to the id 
                        _routineWorkoutDataAccess.updateWeights(_mapper.map(_updateWeights));

                        // making new instance of routine model
                        routineModel modelforid = new routineModel();
                        // setting routineID to updated FK routineWorkoutID
                        modelforid.routineID = _updateWeights.FK_routineWorkID;

                        // returning back the page view routine workout
                        return RedirectToAction("viewRoutineWorkout", modelforid);
                    }
                    catch (Exception _error)
                    {
                        // putting error into a file
                        _logger.logError(_error);
                    }
                }

            }
            return View();
        }


        [HttpGet]
        [ActionName("addWeights")]
        public ActionResult addWeightsGet(weightsModel _addWeights)
        {
            if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                try
                {
                    Session["FK_routineWorkID"] = _addWeights.FK_routineWorkID;

                    return View(_addWeights);
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
        [ActionName("updateWeights")]
        public ActionResult updateWeightsGet(weightsModel _updateWeights)
        {
            if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                try
                {
                    _updateWeights.FK_routineWorkID = (int)Session["FK_routineWorkID"];

                    // returning view of routine 
                    return View(_updateWeights);
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

    //[HttpGet]
    //public ActionResult viewWeights(routineWorkoutModel _routineW)
    //{
    //    if ((int)Session["FK_roleID"] == 1 || (int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
    //    {

    //        try
    //        {
    //            int FK_routineWorkID = _routineW.routineWorkoutID;


    //            // making new instance of the view model
    //            viewModel viewWeightsW = new viewModel();
    //            // populating routine workout list from the batabase that matches personID and routineID
    //             viewWeightsW.weightsList = _mapper.map(_routineWorkoutDataAccess.listAllWeights(FK_routineWorkID));


    //            // return back view with view routine Workout
    //            return View(viewWeightsW);
    //        }
    //        catch (Exception _error)
    //        {
    //            // putting error into a file
    //            _logger.logError(_error);
    //        }
    //    }
    //    // return error page
    //    return View("Error");
    //}


}