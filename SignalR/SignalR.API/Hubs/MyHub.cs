﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.API.Hubs
{
    public class MyHub : Hub
    {
        public static List<string> Names { get; set; } = new List<string>();
        public async Task SendName(string name)
        {
           Names.Add(name);
           await Clients.All.SendAsync("ReceiveName", name);  //Bağlı olan tüm clientlara bildiri gönderir.
        }
        public async Task GetNames()
        {
            await Clients.All.SendAsync("ReceiveNames",Names);  
        }
    }
}
