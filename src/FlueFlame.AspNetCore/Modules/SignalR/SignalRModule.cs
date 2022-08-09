using System;
using FlueFlame.AspNetCore.Common;
using FlueFlame.AspNetCore.Modules.Response;
using Microsoft.AspNetCore.SignalR.Client;

namespace FlueFlame.AspNetCore.Modules.SignalR;

public class SignalRModule : AspNetModuleBase
{
    public SignalRModule(FlueFlameHost application) : base(application)
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:53353/ChatHub")
            .Build();

        connection.On("Hello", () => { });
        connection.SendAsync("Hello", new object());
    }
    public SignalRModule ConnectHub(string hubName)
    {
        throw new System.NotImplementedException();
    }

    public SignalRModule On(string methodName, Action<ResponseModule> assert)
    {
        throw new NotImplementedException();
    }

    public SignalRModule Send(params object[] values)
    {
        throw new NotImplementedException();
    }
}