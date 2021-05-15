using System;
using System.Collections.Generic;
using Rocket.API;
using Rocket.Unturned.Chat;

namespace GroupToggler.Command
{
    public class GroupToggleCommand : IRocketCommand
    {
        public GroupToggle Instance => GroupToggle.Instance;
        public Configuration Config => GroupToggle.Instance.Configuration.Instance;
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "grouptoggle";

        public string Help => $"{Instance.Translate("CommandHelp")}";

        public string Syntax => $"{Instance.Translate("CommandSyntax")}";

        public List<string> Aliases => new List<string>() { "gt", "gtoggle" };

        public List<string> Permissions => new List<string>() { "grouptoggle" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            
            if (!(caller is ConsolePlayer))
            {
                switch (Rocket.Core.R.Permissions.AddPlayerToGroup(Config.groupName, caller))
                {
                    case RocketPermissionsProviderResult.Success:
                        UnturnedChat.Say(caller, $"{Instance.Translate("AddedToGroup")}");
                        return;
                    case RocketPermissionsProviderResult.DuplicateEntry:
                        switch (Rocket.Core.R.Permissions.RemovePlayerFromGroup(Config.groupName, caller))
                        {
                            case RocketPermissionsProviderResult.Success:
                                UnturnedChat.Say(caller, $"{Instance.Translate("RemovedFromGroup")}");
                                return;
                            default:
                                UnturnedChat.Say(caller, $"{Instance.Translate("UnknownErrorRemoving")}");
                                return;
                        }
                    case RocketPermissionsProviderResult.GroupNotFound:
                        
                        UnturnedChat.Say(caller, $"{Instance.Translate("GroupNotFound",Config.groupName)}");
                        return;
                    default:
                        UnturnedChat.Say(caller, $"{Instance.Translate("UnknownErrorAdding")}");
                        return;
                }
            }
            else
            {
                UnturnedChat.Say(caller, $"{Instance.Translate("ConsoleCannotCall")}");
            }
        }
    }
}