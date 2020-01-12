﻿using Model;
using OCUnion;
using ServerOnlineCity.Model;
using ServerOnlineCity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Transfer;

namespace ServerOnlineCity.ChatService
{
    internal sealed class EverybodyLogoffCmd : IChatCmd
    {
        public string CmdID => "everybodylogoff";

        public Grants GrantsForRun => Grants.SuperAdmin | Grants.DiscordBot;

        public string Help => ChatManager.prefix + "everybodylogoff: all online users will be given a command to save and disconnect, except for the admin, until the server is rebooted";

        public ModelStatus Execute(ref PlayerServer player, Chat chat, List<string> argsM)
        {
            // grants check before run cmd
            //if (!player.IsAdmin)
            //{
            //    ChatManager.PostCommandPrivatPostActivChat(player, chat, "Command only for admin");
            //    return;
            //}

            var data = Repository.GetData;
            lock (data)
            {
                data.EverybodyLogoff = true;
            }

            var msg = "Server is preparing to shut down (EverybodyLogoffCmd)";
            Loger.Log(msg);
            return new ModelStatus()
            {
                Status = 0,
                Message = msg,
            };
        }
    }
}