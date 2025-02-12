namespace GardenApp.Models
{
    public class User
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsCorporate { get; set; }

        public User()
        {
            Username = string.Empty;
            PhoneNumber = string.Empty;
            IsCorporate = false;
        }
    }
}
