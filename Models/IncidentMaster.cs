using incidentMgtSystem.API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace incidentMgtSystem.API.Models
{
    public class IncidentMaster
    {
        public int Id { get; set; } 

        public string Description { get; set; } 
        //enum 
        public IncidentStatus Status { get; set; }  

        public string Symptoms { get; set; }    

        public int RequesterId { get; set; }
        //BranchID
        public int TenantId { get; set; }   

        public int CityId { get; set; } 

        public Priority Priority { get; set; } 
        
        public Urgency Urgency { get; set; }    

        public DateTime CreatedDate { get; set; }

        [ForeignKey("RequesterId")]
        public virtual User Requester { get; set; }

        [ForeignKey("TenantId")]
        public virtual TenantMaster Tenant { get; set; }

        [ForeignKey("CityId")]
        public virtual CityMaster City { get; set; }
    }

    public class incidentMasterJson
    {
        public int Id { get; set; }

        public string Json { get; set;}

        public DateTime CreatedDate { get; set;}

        [ForeignKey("RequesterId")]
        public virtual User Requester { get; set; }

    }
}
