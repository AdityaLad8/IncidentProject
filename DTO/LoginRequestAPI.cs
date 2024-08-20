   namespace incidentMgtSystem.API.DTO
{
    public class LoginRequest
   {
        public string username { get; set; }

        public string password { get; set; }
   }

   public class LoginResponse :ResponseBase   {
        /*public string username;

        public string password;*/

        public string JwtToken { get; set; }   
   }
}
