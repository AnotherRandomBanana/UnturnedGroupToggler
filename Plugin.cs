using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;

namespace GroupToggler
{
    public class GroupToggle : RocketPlugin<Configuration>
    {
        public static GroupToggle Instance = null;

        protected override void Load()
        {
            Instance = this;
            Logger.Log("Loaded group toggler plugin.");
        }
        protected override void Unload()
        {
            Instance = null;
            Logger.Log("Group toggler command has been unloaded.");
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "AddedToGroup", "Added you to group." },
            { "RemovedFromGroup", "Removed you from group." },
            { "UnknownErrorRemoving", "Unknown error whilst removing you from group." },
            { "GroupNotFound", "{0} group was not found" },
            { "UnknownErrorAdding", "Unknown error whilst adding you to group." },
            { "ConsoleCannotCall", "This command cannot be called from console." },
            { "CommandHelp", "Toggles a permission group." },
            { "CommandSyntax", "/grouptoggle"}
        };
    }
}