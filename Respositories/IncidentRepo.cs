using incidentMgtSystem.API.Models;
namespace incidentMgtSystem.API.Respositories
{
    public class IncidentRepo
    {

        //added dependency of dbcontext class
        public readonly IncidentDBContext _dbContext;

        public IncidentRepo(IncidentDBContext dBContext)
        {
            _dbContext = dBContext;

        }

        //here get object of incident Master
        //and this obj save to db
        //if save successfully retun true 1 or false 0
        //after this call this function in incidentservice layer

        public bool SaveIncident(IncidentMaster incidentMaster)
        {
            _dbContext.tbl_IncidentMaster.Add(incidentMaster);
             return _dbContext.SaveChanges()>0;

        }



    }
}

