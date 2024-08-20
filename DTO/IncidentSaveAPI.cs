using incidentMgtSystem.API.Enums;

namespace incidentMgtSystem.API.DTO
{
    public class IncidentSaveAPIRequest
    {
        //fields get from end user

        public string Description { get; set; }

        public string Symptoms { get; set; }

        public int TenantId { get; set; }

        public int CityId { get; set; }

        public Priority Priority { get; set; }

        public Urgency Urgency { get; set; }


    }

    public class IncidentSaveAPIResponse : ResponseBase
    {
        //response
       
    }
}
