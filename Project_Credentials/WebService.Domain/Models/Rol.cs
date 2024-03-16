namespace Project_Credentials.Models
{
    public class Rol
    {

        public Rol()
        { 
        
            Users = new HashSet<User>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}

        public Guid UpdatedBy { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}
