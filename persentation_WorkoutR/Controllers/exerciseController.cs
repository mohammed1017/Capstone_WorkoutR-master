using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dataAccessLayer;
using persentation_WorkoutR.Models;
using utilityLogger;


namespace persentation_WorkoutR.Controllers
{
    public class exerciseController : Controller
    {
        // making new instance of presentation mapper
        static presentationMapper _mapper = new presentationMapper();
        // making new instance of exercise data eccess
        static exerciseDataAccess _exerciseDataAccess = new exerciseDataAccess();

        static bodyPartDataAccess bodyPartDataAccess = new bodyPartDataAccess();
        // making new instance of the logger
        static logger _logger = new logger();

        // GET: exercise
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addExercise(exerciseModel _addExercise)
        {
            if ((int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                try
                {
                    // if model state is valid
                    if (ModelState.IsValid)
                    {

                        try
                        {
                            // adding exercise to the database
                            _exerciseDataAccess.addingExercise(_mapper.map(_addExercise));
                            // return back to exercises view
                            return RedirectToAction("viewExercise");
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
        public ActionResult updateExercise(exerciseModel _updateExercise)
        {
            if ((int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                try
                {
                    // if model state is valid
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            // updating the exercise in the database
                            _exerciseDataAccess.updateExercise(_mapper.map(_updateExercise));
                            // return back to exercise view
                            return RedirectToAction("viewExercise");
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
        public ActionResult addExercise()
        {
            if ((int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                exerciseModel model = new exerciseModel();
                model.bodyPartList = _mapper.map(bodyPartDataAccess.listAllBodyPart());
                // return add exercise view
                return View("addExercise", model);
            }

            return View("Error");
        }

        [HttpGet]
        // setting action name to update exercise
        [ActionName("updateExercise")]
        public ActionResult updateExerciseGet(exerciseModel _updateExercise)
        {
            if ((int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                try
                {
                    _updateExercise.bodyPartList = _mapper.map(bodyPartDataAccess.listAllBodyPart());
                    // making session variable using exercise model 
                    Session["exerciseID"] = _updateExercise.exerciseID;
                    // return back update exercise view 
                    return View(_updateExercise);
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
        public ActionResult deleteExercise(int _deleteExercise)
        {
            if ((int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                try
                {
                    // delete exercise from the database with the exercise id
                    _exerciseDataAccess.deletingExercise(_deleteExercise);
                    // return back to exercise view
                    return RedirectToAction("viewExercise");
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
        public ActionResult viewExercise()
        {
            if ((int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                try
                {

                    // making new instance of the view model 
                    viewModel viewExercise = new viewModel();
                    // listing all exercises into exercise list from the database
                    viewExercise.exerciseList = _mapper.map(_exerciseDataAccess.listAllExercise());
                    // returning back the viewExercise page with the list
                    return View(viewExercise);
                }
                catch (Exception _error)
                {
                    // putting error into a file
                    _logger.logError(_error);
                }
            }
            // return the the error page
            return View("Error");
        }

    }
}