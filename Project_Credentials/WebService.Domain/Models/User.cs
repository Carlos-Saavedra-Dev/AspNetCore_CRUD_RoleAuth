namespace Project_Credentials.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; }   
        public string Password { get; set; }  
        public Guid RolId { get; set; }

        public bool Status { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
