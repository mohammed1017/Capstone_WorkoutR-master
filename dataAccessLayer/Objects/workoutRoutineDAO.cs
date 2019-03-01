using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAccessLayer.Objects
{
    public class bodyPartDAO
    {
        //constructors
        public int bodyPartID { get; set; }
        public string bodyPartName { get; set; }
    }
    
    // creating exercise data object
    public class exerciseDAO
    {
        public int exerciseID { get; set; }
        public string exerciseName { get; set; }
        public string exerciseDescription { get; set; }
        public int FK_bodyPart { get; set; }
    }

    // creating person(user) data object
    public class personDAO
    {
        public int personID { get; set; }
        public string personFirstName { get; set; }
        public string personLastName { get; set; }
        public string personAddress { get; set; }
        public string personCity { get; set; }
        public string personState { get; set; }
        public string personZip { get; set; }
        public string personPhone { get; set; }
        public int FK_roleID { get; set; }
        public string personUsername { get; set; }
        public string personPassword { get; set; }
    }

    // creating roles data object
    public class rolesDAO
    {
        public int roleID { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
    }

    // creating routine Data object
    public class routineDAO
    {
        public int routineID { get; set; }
        public string routineName { get; set; }       
        public int FK_personID { get; set; }
        public DateTime login { get; set; }  
        public int totalSets { get; set; }
        public int totalReps { get; set; }
        public int totalExercise { get; set; }
    }

    // creating routine exercises data object
    public class routineWorkoutDAO
    {
        public int routineWorkoutID { get; set; }
        public int FK_exerciseID { get; set; }
        public int FK_routineWorkoutID { get; set; }
        public int routineWSets { get; set; }
        public int routineWReps { get; set; }
        public int routineWRest { get; set; }
        public string exerciseName { get; set; }
        public string routineName { get; set; }
    }

    public class weightsDAO
    {
        public int WeightsID { get; set; }
        public int lbs { get; set; }
        public int FK_routineWorkID { get; set; }
    }
}
