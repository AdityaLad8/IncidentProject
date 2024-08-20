using System.ComponentModel.DataAnnotations.Schema;

namespace incidentMgtSystem.API.Models
{
    public class IncidentComments
    {
        public int Id { get; set; }
        
        public string Message { get;set; }

        public int IncId { get; set; }

        public DateTime createdDate { get; set; }


        [ForeignKey("IncId")]
        public virtual IncidentMaster IncidentMaster { get; set; }  
    
         
    
    }
}
