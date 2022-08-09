using System.Net;
using FlueFlame.AspNetCore.Modules.Response;
using FlueFlame.Extensions.Assertions.NUnit;
using Testing.TestData.AspNetCore.Models;

namespace Testing.Tests.AspNet.NUnit.Assertions.SignalR;

public class SignalRAssertionsTests : TestBase
{
    [Test]
    public void Test()
    {
        Application
            .SignalR
            .ConnectHub("Home")
            .On(methodName: "Hello",
                rsp => rsp.AsText
                    .AssertLength(6)
                    .AssertMatch("TestMessage"))
            .Send("TestMessage");
    }
}