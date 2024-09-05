using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace LoginFormApp
{
    public class User
    {
        private List<Identity> identities;

        public User()
        {
            identities = new List<Identity>();
        }

        public void LoadUsersFromJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            identities = JsonConvert.DeserializeObject<List<Identity>>(json);
        }

        public bool IsValid(string username, string password)
        {
            return identities.Any(identity =>
                identity.Username == username && identity.Password == password);
        }
    }
}
