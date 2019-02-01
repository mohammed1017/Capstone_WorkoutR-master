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
    public class bodyPartController : Controller
    {
        //
        // making new instance of presentation mapper
        static presentationMapper _mapper = new presentationMapper();
        // making new instance of exercise data eccess
        static bodyPartDataAccess _bodyPartDataAccess = new bodyPartDataAccess();
        // making new instance of the logger
        static logger _logger = new logger();
        // GET: bodyPart
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult viewBodyPart()
        {
            if ((int)Session["FK_roleID"] == 2 || (int)Session["FK_roleID"] == 3)
            {
                try
                {

                    // making new instance of the view model 
                    viewModel viewBodyPart = new viewModel();
                    // listing all exercises into exercise list from the database
                    viewBodyPart.bodyPartList = _mapper.map(_bodyPartDataAccess.listAllBodyPart());
                    // returning back the viewExercise page with the list
                    return View(viewBodyPart);
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