using Rocket.API;

namespace GroupToggler
{
    public class Configuration : IRocketPluginConfiguration
    {
        public string groupName;
        public string commandName;
        public string permissionName;
        public void LoadDefaults()
        {
            groupName = "Police";
        }
    }
}
