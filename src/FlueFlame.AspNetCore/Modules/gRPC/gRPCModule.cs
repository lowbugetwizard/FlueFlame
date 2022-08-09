using FlueFlame.AspNetCore.Common;

namespace FlueFlame.AspNetCore.Modules.gRPC;

public class GRpcModule : AspNetModuleBase
{
    public GRpcModule(FlueFlameHost application) : base(application)
    {
    }
}