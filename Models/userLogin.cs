using System.ComponentModel.DataAnnotations.Schema;

namespace incidentMgtSystem.API.Models
{
    public class UserLogin
    {
        public int id { get;set; }  

        public string username { get; set; }

        public string password { get; set; }

        public string IsActive { get; set; }

        public DateTime lastlogin { get; set; }

        public int Userid { get; set; }


        //foreign key of user table 
        //using user id propery
        //if you use userid as foreignkey it will load all the data for user as well beacuse of foreign key attribute
        //added virtual --> for lazy loading --> 
        [ForeignKey("Userid")]
        public virtual User User { get; set; }  
    }
}
