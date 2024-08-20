namespace incidentMgtSystem.API.Models
{
   using Microsoft.EntityFrameworkCore;

    public class IncidentDBContext : DbContext
    {
        
        //register all the tables
        public DbSet<UserLogin> tbl_UserLogin { get; set; }
        public DbSet<User> tbl_User { get;set; }  
        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<UserRoles> tbl_UserRoles { get;set; }
        public DbSet<IncidentMaster> tbl_IncidentMaster { get; set; }
        public DbSet<IncidentComments> tbl_incidentComments { get; set; }
        public DbSet<incidentMasterJson>tbl_incidentMasterJsons { get; set; }
        public DbSet<TenantMaster> tbl_TenantMaster { get; set; }

        public DbSet<CityMaster> tbl_CityMaster { get; set; }
        public DbSet<StateMaster>tbl_StateMaster  { get; set; }
        public DbSet<CountryMaster> tbl_CountryMaster { get; set; }


        public IncidentDBContext(DbContextOptions<IncidentDBContext> options) : base(options)
        {

        }
        


    }

}