namespace incidentMgtSystem.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string firstname { get;set; }    
        public string lastname { get; set; }
        public string email { get; set; }   
        public string mobileno { get; set; }    
        public DateTime createdDateTime { get; set; }   


    }
}
