using System.Text.Json;
using GardenApp.Models;

namespace GardenApp.Services
{
    public class UserService
    {
        private const string UsersFileName = "Users.json";
        private List<User> _users;

        public UserService()
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, UsersFileName);

            if (!File.Exists(filePath))
            {
                // Create an empty user list if the file doesn't exist
                _users = new List<User>();
                SaveUsers(); // This will create the file with an empty user list
                return;
            }

            string jsonString = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<UserData>(jsonString);
            _users = data?.Users ?? new List<User>();
        }

        private void SaveUsers()
        {
            var data = new UserData { Users = _users };
            string jsonString = JsonSerializer.Serialize(data);
            string filePath = Path.Combine(FileSystem.AppDataDirectory, UsersFileName);

            // To make ssure the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            File.WriteAllText(filePath, jsonString);
        }

        public bool AuthenticateUser(string username, string phoneNumber)
        {
            return _users.Any(u => u.Username == username && u.PhoneNumber == phoneNumber);
        }

        public bool CreateUser(string username, string phoneNumber, bool isCorporate = false)
        {
            if (_users.Any(u => u.Username == username))
            {
                return false; // Username already exists
            }

            _users.Add(new User { Username = username, PhoneNumber = phoneNumber, IsCorporate = isCorporate });
            SaveUsers();
            return true;
        }

        public User GetUser(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }

        private class UserData
        {
            public List<User> Users { get; set; }
        }
    }
}
