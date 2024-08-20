using incidentMgtSystem.API.Models;
using Microsoft.EntityFrameworkCore;
namespace incidentMgtSystem.API.Respositories
{
    public class AccountRepo
    {

        //added dependency of dbcontext class
        public readonly IncidentDBContext _dbContext;
        public AccountRepo(IncidentDBContext dBContext) {
        


            _dbContext = dBContext;
        
        }

        public UserLogin validateLoginDetails(string username, string password)
        {
            //verify credential in db if matching return user record not matching return user null
            //that logic is in service layer.
           UserLogin user = _dbContext.tbl_UserLogin.Where(p=>p.username.Equals(username)&&p.password.Equals(password)).Include(password=>password.User).FirstOrDefault();
         // UserLogin user = _dbContext.tbl_UserLogin.Where (p=>p.username.Equals(username)&& p.password.Equals(password));
            return user;
        
        }
        

        
    }
}
